using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Tarea5
{
    public partial class _4 : Form
    {
        //Atributos
        GestorBD.GestorBD GestorBD;
        OleDbConnection cnOracle;
        Varios.Comunes comunes = new Varios.Comunes();
        String cadSQL;
        DataSet dsCadena = new DataSet(), dsSucursal = new DataSet(), dsArticulo = new DataSet();

        public _4()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            String NombreCadena, NombreSucursal;
            //1- Hcer la conexión a la BD de Oracle
            cnOracle = new OleDbConnection("Provider=MSDAORA; Data Source=xe;" +
              "User ID=system;Password=gonbar");
            cnOracle.Open();

            OleDbCommand funcionAlmacenado;
            OleDbParameter salida, parametro1, parametro2;
            int cant;

            //1- Abrir la conexión a la BD.
            cnOracle = new OleDbConnection("Provider=MSDAORA; Data Source=xe;" +
              "User ID=System;Password=gonbar");
            cnOracle.Open();
            funcionAlmacenado = new OleDbCommand();
            funcionAlmacenado.Connection = cnOracle;

            //2- Especificar el llamado a la función  (en general: al subprograma).
            funcionAlmacenado.CommandText = "CantidadProductos";
            funcionAlmacenado.CommandType = CommandType.StoredProcedure;
            
            
            //3- Especificar los parámetros:
            //a) primero todos los de salida (uno en este caso):
            salida = new OleDbParameter("RETURN_VALUE", OleDbType.Integer,
              4, ParameterDirection.ReturnValue, false, 4, 0, "NombreCadena" + "NombreSucursal", DataRowVersion.Current, 0);
            funcionAlmacenado.Parameters.Add(salida);


            //b) Luego todos los de entrada:
            NombreCadena = comboBox1.SelectedItem.ToString();
            parametro1 = new OleDbParameter("NombreCad", NombreCadena);
            NombreSucursal = comboBox2.SelectedItem.ToString();
            parametro2 = new OleDbParameter("NombreSuc", NombreSucursal);
            funcionAlmacenado.Parameters.Add(parametro1);
            funcionAlmacenado.Parameters.Add(parametro2);

            //4- Ejecutar la función (en general: el subprograma).
            try
            {
                funcionAlmacenado.ExecuteNonQuery();

                //5- Recuperar el (los) valor(es) regresado(s) por medio del (de los)
                //   parámetro(s) de salida.
                cant = Convert.ToInt16(funcionAlmacenado.Parameters["RETURN_VALUE"].Value);
                MessageBox.Show("Cadena: " + NombreCadena + ", Sucursal: " + NombreSucursal +
                    ", Cantidad de Articulos: " + cant);
            }
            catch (OleDbException err)
            {
                MessageBox.Show(err.Message);
            }
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            //6- Cerrar la conexión a la BD.
            cnOracle.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String nombreP, sucursal; int cant, monto;
            OleDbCommand procedimientoAlmacenado;
            OleDbParameter parametro1, parametro2, salida1, salida2;

            //1- Abrir la conexión a la BD.
            cnOracle = new OleDbConnection("Provider=MSDAORA; Data Source=xe;" +
              "User ID=System;Password=gonbar");
            cnOracle.Open();
            procedimientoAlmacenado = new OleDbCommand();
            procedimientoAlmacenado.Connection = cnOracle;

            //2- Especificar el llamado al procedimiento  (en general: al subprograma).
            procedimientoAlmacenado.CommandText = "SucursalesConProducto";
            procedimientoAlmacenado.CommandType = CommandType.StoredProcedure;

            //3- Especificar los parámetros:
            //a) primero todos los de entrada:
            nombreP = comboBox3.SelectedItem.ToString();
            parametro1 = new OleDbParameter("NombreArticulo", nombreP);
            procedimientoAlmacenado.Parameters.Add(parametro1);

            monto = Convert.ToInt32(textBox1.Text);
            parametro2 = new OleDbParameter("Monto", monto);
            procedimientoAlmacenado.Parameters.Add(parametro2);

            //b) luego todos los de salida (uno en este caso):
            salida1 = new OleDbParameter("cant", OleDbType.Integer,
              4, ParameterDirection.Output, false, 4, 0, "nombreP", DataRowVersion.Current, 0);
            salida2 = new OleDbParameter("sucursal", OleDbType.VarChar,
              4, ParameterDirection.Output, false, 4, 0, "monto", DataRowVersion.Current, 0);

            procedimientoAlmacenado.Parameters.Add(salida1);
            procedimientoAlmacenado.Parameters.Add(salida2);

            //4- Ejecutar el procedimiento (en general: el subprograma).
            try
            {
                procedimientoAlmacenado.ExecuteNonQuery();

                //5- Recuperar el (los) valor(es) regresado(s) por medio del (de los)
                //   parámetro(s) de salida.
                cant = Convert.ToInt16(procedimientoAlmacenado.Parameters["cant"].Value);
                sucursal = procedimientoAlmacenado.Parameters["sucursal"].Value.ToString();
                MessageBox.Show("Nombre del Articulo: " + nombreP + " Precio: " + monto +
                    ", Cantidad de Sucursales: " + cant+ ", Sucursal: " + sucursal);
            }
            catch (OleDbException err)
            {
                MessageBox.Show(err.Message);
            }


            comboBox3.SelectedIndex = -1;
            textBox1.Text = "";
            //6- Cerrar la conexión a la BD.
            cnOracle.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Convert.ToInt32(e.KeyChar)==8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void _4_Load(object sender, EventArgs e)
        {
            //1- Hcer la conexión a la BD de Oracle

            GestorBD = new GestorBD.GestorBD("MSDAORA", "System", "gonbar", "xe");

            //2.1- Obtiene y muestra los datos de los Cadena.
            cadSQL = "Select * from T4CADCOM";
            GestorBD.consBD(cadSQL, dsCadena, "TablaCadena");


            comunes.cargaCombo(comboBox1, dsCadena, "TablaCadena", "NombreCadena");

            //2.2- Obtiene y muestra los datos de los Sucursal.
            cadSQL = "Select * from T4Sucursal";
            GestorBD.consBD(cadSQL, dsSucursal, "TablaSucursal");


            comunes.cargaCombo(comboBox2, dsSucursal, "TablaSucursal", "NombreSucursal");

            //2.2- Obtiene y muestra los datos de los Articulos.
            cadSQL = "Select * from T4Producto";
            GestorBD.consBD(cadSQL, dsArticulo, "TablaArticulos");


            comunes.cargaCombo(comboBox3, dsArticulo, "TablaArticulos", "NombreP");


        }
    }
}
