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
    public partial class _5 : Form
    {
        //Atributos
        GestorBD.GestorBD GestorBD;
        OleDbConnection cnOracle;
        Varios.Comunes comunes = new Varios.Comunes();

        String cadSQL;
        DataSet dsCadena = new DataSet(), dsSucursal = new DataSet(), dsArticulo = new DataSet();
        DataSet dsFactura = new DataSet(), dsTotal = new DataSet(), dsPagos = new DataSet(), dsMonto = new DataSet();
        DataSet dsActual = new DataSet(), dsRFC = new DataSet();

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            String fecha = dtp5.Value.Day + "/" + dtp5.Value.Month + "/" + dtp5.Value.Year;
            String nombre = cbCliente.Text;
            String RFC;

            //asigna el rfc del cliente buscado

            cadSQL = "select RFCCliente from t4cliente where nombrecliente='" + nombre + "'";
            GestorBD.consBD(cadSQL, dsRFC, "rfc");
            RFC = dsRFC.Tables["rfc"].Rows[0]["RFCCliente"].ToString();

            //2.2- Obtiene y muestra Folios de las facturas del cliente.

            cadSQL = "select f.folio from t4factura f, t4cliente cli where cli.rfccliente=f.rfccliente and cli.RFCCliente='" + RFC + "' and f.fecha between '" + fecha + "' and sysdate";

            GestorBD.consBD(cadSQL, dsFactura, "TablaFactura");
            comunes.cargaCombo(cboNoFactura, dsFactura, "TablaFactura", "Folio");

        }

        private void cboNoFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            String fecha = dtp5.Value.Day + "/" + dtp5.Value.Month + "/" + dtp5.Value.Year;
            String nombre = cbCliente.Text;
            int folio = Convert.ToInt16(cboNoFactura.Text);

            //muestra las compras de la factura en el datagridView
            cadSQL = "select fac.fecha, prod.nombrep as Articulo, con.preciototalarticulo as Total_Articulo from " +
                "t4contiene con, t4factura fac, t4cliente cli, t4producto prod"  +
                " where cli.nombrecliente ='" + nombre + "' and fac.rfccliente = cli.rfccliente  and con.folio = " + folio +
                " and fac.fecha between '" + fecha + "' and sysdate and prod.idprod = con.idprod order by con.folio desc";
            GestorBD.consBD(cadSQL, dsFactura, "factura");
            dtgFac.DataSource = dsFactura.Tables["factura"];


            //muestra el total en label de total
            cadSQL = "select sum(con.preciototalarticulo) as Total from " +
                "t4contiene con, t4factura fac, t4cliente cli, t4producto prod" + "" +
                " where cli.nombrecliente ='" + nombre + "' and fac.rfccliente = cli.rfccliente  and con.folio = " + folio +
                " and fac.fecha between '" + fecha + "' and sysdate and prod.idprod = con.idprod order by con.folio desc";
            GestorBD.consBD(cadSQL, dsTotal, "factura");
            lblTotal.Text = dsTotal.Tables["factura"].Rows[0][0].ToString();


            //muestra el numero de pagos  hechos
            cadSQL = "select count(*) from t4pagos where folio = " + folio;
            GestorBD.consBD(cadSQL, dsPagos, "pagos");
            lblPagosR.Text = dsPagos.Tables["pagos"].Rows[0][0].ToString();

            //muestra el monto total de los pagos
            cadSQL = "select sum(monto) as total from t4pagos where folio = " + folio;
            GestorBD.consBD(cadSQL, dsMonto, "monto");

            String montoTotal = dsMonto.Tables["monto"].Rows[0][0].ToString();
            lblMontoPagos.Text = montoTotal;

            Double totalPagos = Convert.ToDouble(montoTotal);

            //muestra el saldo Actual de la factura
            cadSQL = "select MontoTotal from T4Factura where folio=" + folio;
            GestorBD.consBD(cadSQL, dsActual, "actual");
            lblSaldo.Text= dsActual.Tables["actual"].Rows[0][0].ToString();


        }

        private void _5_Load(object sender, EventArgs e){
            //1- Hcer la conexión a la BD de Oracle

            GestorBD = new GestorBD.GestorBD("MSDAORA", "System", "gonbar", "xe");

            //2.1- Obtiene y muestra los datos de los Cadena.
            cadSQL = "Select * from T4CLIENTE";
            GestorBD.consBD(cadSQL, dsCadena, "TablaCliente");


            comunes.cargaCombo(cbCliente, dsCadena, "TablaCliente", "NombreCliente");

            

        }

        public _5()
        {
            InitializeComponent();
        }
    }
}
