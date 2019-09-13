using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.DA_Registro;

namespace DataBusiness.DB_Registro
{
   public class DB_AP_Provincia
    {
       // llena el droplist con provincias
       public void DB_Desplegar_PROVINCIAS_DROPDOWNLIST(string Dep, DropDownList Prov)
       {
          // VALIDAR DESDE AQUI
           DA_AP_Provincia data = new DA_AP_Provincia();
           System.Data.DataTable prov = new System.Data.DataTable();
           prov = data.SeleccionarProv(Dep);
           Int32 numC = prov.Rows.Count;
           Int32 i = 0;
           Prov.Items.Insert(0, new ListItem("Seleccionar Prov.", "0"));
           for (i = 0; i < numC; i++)
           {
               //s.Value = Convert.ToString(prov.Rows[i][0]);
               //s.Text = Convert.ToString(prov.Rows[i][1]);
               Prov.Items.Insert(i+1, new ListItem(Convert.ToString(prov.Rows[i][1]), Convert.ToString(prov.Rows[i][0])));
           }           
       }
    }
}
