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
        DataSet dsCadena = new DataSet(), dsSucursal = new DataSet();

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

            OleDbCommand procAlmacenado;
            OleDbParameter salida, parametro1, parametro2;
            int cant;

            //1- Abrir la conexión a la BD.
            cnOracle = new OleDbConnection("Provider=MSDAORA; Data Source=xe;" +
              "User ID=System;Password=gonbar");
            cnOracle.Open();
            procAlmacenado = new OleDbCommand();
            procAlmacenado.Connection = cnOracle;

            //2- Especificar el llamado a la función  (en general: al subprograma).
            procAlmacenado.CommandText = "CantidadProductos";
            procAlmacenado.CommandType = CommandType.StoredProcedure;
            
            
            //3- Especificar los parámetros:
            //a) primero todos los de salida (uno en este caso):
            salida = new OleDbParameter("RETURN_VALUE", OleDbType.Integer,
              4, ParameterDirection.ReturnValue, false, 4, 0, "NombreCadena" + "NombreSucursal", DataRowVersion.Current, 0);
            procAlmacenado.Parameters.Add(salida);


            //b) Luego todos los de entrada:
            NombreCadena = comboBox1.SelectedItem.ToString();
            parametro1 = new OleDbParameter("NombreCad", NombreCadena);
            NombreSucursal = comboBox2.SelectedItem.ToString();
            parametro2 = new OleDbParameter("NombreSuc", NombreSucursal);
            procAlmacenado.Parameters.Add(parametro1);
            procAlmacenado.Parameters.Add(parametro2);

            //4- Ejecutar la función (en general: el subprograma).
            try
            {
                procAlmacenado.ExecuteNonQuery();

                //5- Recuperar el (los) valor(es) regresado(s) por medio del (de los)
                //   parámetro(s) de salida.
                cant = Convert.ToInt16(procAlmacenado.Parameters["RETURN_VALUE"].Value);
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

        }


        private void _4_Load(object sender, EventArgs e)
        {
            //1- Hcer la conexión a la BD de Oracle

            GestorBD = new GestorBD.GestorBD("MSDAORA", "System", "gonbar", "xe");

            //2.1- Obtiene y muestra los datos de los alumnos.
            cadSQL = "Select * from T4CADCOM";
            GestorBD.consBD(cadSQL, dsCadena, "TablaCadena");


            comunes.cargaCombo(comboBox1, dsCadena, "TablaCadena", "NombreCadena");

            //2.2- Obtiene y muestra los datos de los materia.
            cadSQL = "Select * from T4Sucursal";
            GestorBD.consBD(cadSQL, dsSucursal, "TablaSucursal");


            comunes.cargaCombo(comboBox2, dsSucursal, "TablaSucursal", "NombreSucursal");

        }
    }
}
