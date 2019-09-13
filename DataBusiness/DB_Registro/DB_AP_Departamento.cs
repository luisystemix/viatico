using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.DA_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_Departamento
    {
        // llena el droplist con provincias
        public void DB_Desplegar_DEPARTAMENTOS(DropDownList depart)
        {
            // VALIDAR DESDE AQUI
            DA_AP_Departamento data = new DA_AP_Departamento();
            System.Data.DataTable dep = new System.Data.DataTable();
            dep = data.DA_Desplegar_DEPARTAMENTOS();
            Int32 numC = dep.Rows.Count;
            Int32 i = 0;
            depart.Items.Insert(0, new ListItem("Seleccionar Dep.", "0"));
            for (i = 0; i < numC; i++)
            {
                //s.Value = Convert.ToString(prov.Rows[i][0]);
                //s.Text = Convert.ToString(prov.Rows[i][1]);
                depart.Items.Insert(i + 1, new ListItem(Convert.ToString(dep.Rows[i][1]), Convert.ToString(dep.Rows[i][0])));
            }
        }
    }
}
