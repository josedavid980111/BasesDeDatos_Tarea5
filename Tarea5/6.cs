using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea5
{
    public partial class _6 : Form
    {
        private int cont;
        private GestorBD.GestorBD GestorBD;
        private DataSet dsCliente = new DataSet(), dsSucursal = new DataSet(), dsChecaCliente = new DataSet(), dsArticulo = new DataSet(), dsFactura = new DataSet(), dsPago = new DataSet();
        private String cadSQL;
        private Varios.Comunes comunes = new Varios.Comunes();
        private double TotalDelTotal = 0;
        private String IdS, RFCCli;

        public _6()
        {
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Convert.ToInt32(e.KeyChar) == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                button4.Visible = true;
                String Articulo, IdP; int CantArticulo; double Total;
                Articulo = comboBox2.SelectedItem.ToString();
                CantArticulo = Convert.ToInt32(textBox2.Text);
                cadSQL = "Select * from T4Producto p, T4Vende v, T4Sucursal s where s.IdSuc=v.IdSuc and v.IdProd=p.IdProd and p.NombreP='" + Articulo + "' and s.NombreSucursal='" + comboBox3.SelectedItem.ToString() + "'";
                GestorBD.consBD(cadSQL, dsArticulo, "TablaUnArticulo");
                Total = Convert.ToDouble(dsArticulo.Tables["TablaUnArticulo"].Rows[0]["Precio"].ToString()) * CantArticulo;
                IdP = Convert.ToString(dsArticulo.Tables["TablaUnArticulo"].Rows[0]["IdProd"].ToString());
                dataGridView1.Rows.Add();
                dataGridView1.Rows[cont].Cells["IdP"].Value = Articulo;
                dataGridView1.Rows[cont].Cells["CantArt"].Value = CantArticulo;
                dataGridView1.Rows[cont].Cells["PrecioTotalArticulo"].Value = Total;
                dataGridView1.Rows[cont].Cells["IdProducto"].Value = IdP;
                TotalDelTotal = TotalDelTotal + Total;
                comboBox2.SelectedIndex = -1;
                textBox2.Text = "";
                cont = cont + 1;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Double PagoInicial = Convert.ToDouble(textBox1.Text);
                int folio = 0, folioPago=0;
                int Articulo; int CantArticulo; double Total;
                Random random = new Random();
                Boolean folioAprobado = false;
                while (!folioAprobado)
                {
                    folio = random.Next(1000, 9999);
                    cadSQL = "Select * from T4Factura f where f.folio=" + folio;
                    GestorBD.consBD(cadSQL, dsFactura, "TablaFolio");
                    if (dsFactura.Tables["TablaFolio"].Rows.Count == 0)
                    {
                        folioAprobado = true;
                    }

                }

                cadSQL = "insert into T4Factura values (" + folio + ", date'" + DateTimePicker1.Value.Year + "-" + DateTimePicker1.Value.Month + "-" + DateTimePicker1.Value.Day + "'," + TotalDelTotal + "," + TotalDelTotal + ",'" + RFCCli + "','" + IdS + "')";
                GestorBD.altaBD(cadSQL);
                folioAprobado = false;
                while (!folioAprobado)
                {
                    folioPago = random.Next(1000, 9999);
                    cadSQL = "Select * from t4Pagos p where p.idPago =" + folioPago;
                    GestorBD.consBD(cadSQL, dsPago, "TablaPago");
                    if (dsPago.Tables["TablaPago"].Rows.Count == 0)
                    {
                        folioAprobado = true;
                    }

                }

                cadSQL = "insert into T4Pagos values (" + folioPago + ","+PagoInicial+", date'" + DateTimePicker1.Value.Year + "-" + DateTimePicker1.Value.Month + "-" + DateTimePicker1.Value.Day + "'," +folio+ ")";
                GestorBD.altaBD(cadSQL);


                for (int i = 0; i < cont; i++)
                {

                    CantArticulo = Convert.ToInt32(dataGridView1.Rows[0].Cells["CantArt"].Value);
                    Total = Convert.ToDouble(dataGridView1.Rows[0].Cells["PrecioTotalArticulo"].Value);
                    Articulo = Convert.ToInt32(dataGridView1.Rows[0].Cells["IdProducto"].Value);
                    cadSQL = "Insert into T4Contiene values(" + folio + "," + Articulo + "," + Total + "," + CantArticulo + ")";
                    dataGridView1.Rows.RemoveAt(0);
                    GestorBD.altaBD(cadSQL);
                }
               

                comboBox2.Visible = false;
                label2.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                DateTimePicker1.Visible = false;
                textBox2.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                dataGridView1.Visible = false;
                button4.Visible = false;
                textBox1.Visible = false;
                label6.Visible = false;
                comboBox1.Enabled = true;
                comboBox3.Enabled = true;
                button5.Visible = false;
                button1.Visible = true;
                DateTimePicker1.Value = DateTime.Now;
                comboBox1.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                textBox1.Text = "";
                IdS = "";
                RFCCli = "";
                cont = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                TotalDelTotal = TotalDelTotal - Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["PrecioTotalArticulo"].Value);
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

                cont = cont - 1;
                if (cont == 0)
                {
                    button4.Visible = false;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTimePicker1.Value = DateTime.Now;
            comboBox2.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            DateTimePicker1.Visible = false;
            textBox2.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            dataGridView1.Visible = false;
            button4.Visible = false;
            button1.Visible = true;
            textBox1.Visible = false;
            label6.Visible = false;
            button5.Visible = false;
            comboBox1.Enabled = true;
            comboBox3.Enabled = true;
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;

            for (int i = 0; i < cont; i++)
            {
                dataGridView1.Rows.RemoveAt(i);
            }
            cont = 0;
            IdS = "";
            RFCCli = "";
            textBox2.Text = "";
            comboBox2.SelectedIndex = -1;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }



        private void button1_Click(object sender, EventArgs e)
        {

            
            try
            {
                String Cliente, Sucursal;
                Cliente = comboBox1.SelectedItem.ToString();
                Sucursal = comboBox3.SelectedItem.ToString();
                cadSQL = "Select * from T4Sucursal s, T4Cliente cli, T4CADCOM cad, T4CadenaTieneClientes ctc where cli.RFCCliente=ctc.RFCCliente and ctc.RFCCad=cad.RFCCad and cad.RFCCad=s.RFCCad and cli.NombreCliente='" + Cliente + "' and s.NombreSucursal='" + Sucursal + "'";

                GestorBD.consBD(cadSQL, dsChecaCliente, "TablaChecaCliente");

                if (dsChecaCliente.Tables["TablaChecaCliente"].Rows.Count == 1)
                {
                    comboBox1.Enabled = false;
                    comboBox3.Enabled = false;
                    button5.Visible = true;
                    button1.Visible = false;
                    comboBox2.Visible = true;
                    label2.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    DateTimePicker1.Visible = true;
                    textBox2.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    dataGridView1.Visible = true;
                    textBox1.Visible = true;
                    label6.Visible = true;

                    IdS = dsChecaCliente.Tables["TablaChecaCliente"].Rows[0]["IdSuc"].ToString();
                    RFCCli = dsChecaCliente.Tables["TablaChecaCliente"].Rows[0]["RFCCliente"].ToString();

                    //2.2- Obtiene y muestra los datos de los Sucursal.
                    cadSQL = "Select * from T4Producto p, T4Vende v, T4Sucursal s where s.IDSuc=v.IDSuc and v.IdProd=p.IdProd and s.NombreSucursal='" + comboBox3.SelectedItem.ToString() + "'";
                    GestorBD.consBD(cadSQL, dsArticulo, "TablaArticulos");

                    comunes.cargaCombo(comboBox2, dsArticulo, "TablaArticulos", "NombreP");

                }
                else
                {


                    MessageBox.Show("No hay Datos del Cliente en esa Sucursal");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void _6_Load(object sender, EventArgs e)
        {
            //1- Hcer la conexión a la BD de Oracle

            GestorBD = new GestorBD.GestorBD("MSDAORA", "System", "gonbar", "xe");

            //2.1- Obtiene y muestra los datos de los Cliente.
            cadSQL = "Select * from T4Cliente";
            GestorBD.consBD(cadSQL, dsCliente, "TablaCliente");

            comunes.cargaCombo(comboBox1, dsCliente, "TablaCliente", "NombreCliente");

            //2.2- Obtiene y muestra los datos de los Sucursal.
            cadSQL = "Select * from T4Sucursal";
            GestorBD.consBD(cadSQL, dsSucursal, "TablaSucursal");

            comunes.cargaCombo(comboBox3, dsSucursal, "TablaSucursal", "NombreSucursal");


        }
    }
}