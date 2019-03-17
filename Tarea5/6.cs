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
        int cont;
        GestorBD.GestorBD GestorBD;
        DataSet dsCliente = new DataSet(), dsSucursal = new DataSet(), dsChecaCliente = new DataSet(), dsArticulo = new DataSet();
        String cadSQL;
        Varios.Comunes comunes = new Varios.Comunes();

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
            String Articulo; int CantArticulo; double Total;
            Articulo = comboBox2.SelectedItem.ToString();
            CantArticulo = Convert.ToInt32(textBox2.Text);
            cadSQL = "Select * from T4Producto p, T4Vende v, T4Sucursal s where s.IdSuc=v.IdSuc and v.IdProd=p.IdProd and p.NombreP='" + Articulo + "' and s.NombreSucursal='"+ comboBox3.SelectedItem.ToString()+"'";
            GestorBD.consBD(cadSQL, dsArticulo, "TablaUnArticulo");
            Total = Convert.ToDouble(dsArticulo.Tables["TablaUnArticulo"].Rows[0]["Precio"].ToString())*CantArticulo;
            if (cont != 0)
            {
                dataGridView1.Rows.Add();
            }
            dataGridView1.Rows[0].Cells["IdProd"].Value = Articulo;
            dataGridView1.Rows[0].Cells["CantArt"].Value = CantArticulo;
            dataGridView1.Rows[0].Cells["PrecioTotalArticulo"].Value = Total;
            comboBox2.SelectedIndex = -1;
            textBox2.Text = "";
            cont = cont + 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cont = 0;
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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
            String Cliente, Sucursal;
            Cliente = comboBox1.SelectedItem.ToString();
            Sucursal = comboBox3.SelectedItem.ToString();

            cadSQL = "Select * from T4Sucursal s, T4Cliente cli, T4CADCOM cad, T4CadenaTieneClientes ctc where cli.RFCCliente=ctc.RFCCliente and ctc.RFCCad=cad.RFCCad and cad.RFCCad=s.RFCCad and cli.NombreCliente='" + Cliente + "' and s.NombreSucursal='" + Sucursal + "'";

            GestorBD.consBD(cadSQL, dsChecaCliente, "TablaChecaCliente");

            if (dsChecaCliente.Tables["TablaChecaCliente"].Rows.Count == 1)
            {
                comboBox2.Visible = true;
                label2.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                dateTimePicker1.Visible = true;
                textBox2.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                dataGridView1.Visible = true;
                
                //2.2- Obtiene y muestra los datos de los Sucursal.
                cadSQL = "Select * from T4Producto p, T4Vende v, T4Sucursal s where s.IDSuc=v.IDSuc and v.IdProd=p.IdProd and s.NombreSucursal='"+comboBox3.SelectedItem.ToString()+"'";
                GestorBD.consBD(cadSQL, dsArticulo, "TablaArticulos");

                comunes.cargaCombo(comboBox2, dsArticulo, "TablaArticulos", "NombreP");
                cont = 0;

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
