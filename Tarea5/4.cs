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

        OleDbConnection cnOracle;

        public _4()
        {
            InitializeComponent();
        }

        private void _4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String NombreCadena, NombreSucursal;
            OleDbCommand procAlmacenado;
            OleDbParameter salida, parametro1, parametro2;
            int cant;

            //1- Abrir la conexión a la BD.
            cnOracle = new OleDbConnection("Provider=MSDAORA; Data Source=xe;" +
              "User ID=System;Password=gonbar");
            cnOracle.Open();
            procAlmacenado = new OleDbCommand();
            procAlmacenado.Connection = cnOracle;

            //2- Especificar el llamado al procedimiento  (en general: al subprograma).
            procAlmacenado.CommandText = "CantidadProductos";
            procAlmacenado.CommandType = CommandType.StoredProcedure;

            //b) primero todos los de salida (uno en este caso):
            salida = new OleDbParameter("RETURN_VALUE", OleDbType.Integer,
              4, ParameterDirection.ReturnValue, false, 4, 0, "NombreCadena" + "NombreSucursal", DataRowVersion.Current, 0);
            procAlmacenado.Parameters.Add(salida);

            //3- Especificar los parámetros:
            //a) Luego todos los de entrada:
            NombreCadena = "CC1";
            parametro1 = new OleDbParameter("NombreCad", NombreCadena);
            NombreSucursal = "Sucursal1_CC1";
            parametro2 = new OleDbParameter("NombreSuc", NombreSucursal);
            procAlmacenado.Parameters.Add(parametro1);
            procAlmacenado.Parameters.Add(parametro2);

            //4- Ejecutar el procedimiento (en general: el subprograma).
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

            //6- Cerrar la conexión a la BD.
            cnOracle.Close();
        }
    }
}
