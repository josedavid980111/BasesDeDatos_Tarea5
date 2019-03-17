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
            dataGridView1.Rows[cont].Cells["IdProd"].Value = comboBox2.SelectedItem.ToString();
            dataGridView1.Rows[cont].Cells["CantArt"].Value = textBox2.Text; ;
            dataGridView1.Rows[cont].Cells["PrecioTotalArticulo"].Value = Convert.ToDouble(textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cont = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
