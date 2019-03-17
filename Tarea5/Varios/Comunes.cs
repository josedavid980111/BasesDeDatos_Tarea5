using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Agregar al inicio del archivo:
using System.Data;
using System.Windows.Forms;		//Para que se pueda usar el tipo: ComboBox.

namespace Tarea5.Varios
{
    class Comunes
    {
        //Aquí se colocan los métodos (y variables) de uso común en todo el proyecto.

        /* Agrega en un ComboBox (primer parámetro), los datos que están en un DataSet
           (segundo parámetro), en la tabla y columna dadas (tercer y cuarto parámetros).
           Los datos se agregan sin repetición.
        */
        public void cargaCombo(ComboBox cbo, DataSet ds, String tabla, String col)
        {
            DataTable tabResul;

            cbo.Items.Clear();
            //La columna 'col' es la que tiene los datos que se agregarán al combo.
            tabResul = ds.Tables[tabla];
            foreach (DataRow fila in tabResul.Rows)
                if (!cbo.Items.Contains(fila[col].ToString().Trim()))
                    cbo.Items.Add(fila[col].ToString().Trim());
        }



    }
}
