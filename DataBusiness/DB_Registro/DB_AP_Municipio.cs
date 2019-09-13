using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.DA_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_Municipio
    {
        public void DB_Desplegar_MUNICIPIOS_DROPDOWNLIST(int id_Prov, DropDownList Munucipio)
        {
            // VALIDAR DESDE AQUI
            DA_AP_Municipio data = new DA_AP_Municipio();
            System.Data.DataTable Mun = new System.Data.DataTable();
            Mun = data.ID_PROVINCIA_SeleccionarMunicipios(id_Prov);
            Int32 numC = Mun.Rows.Count;
            Int32 i = 0;
            Munucipio.Items.Insert(0, new ListItem("Seleccionar Municipio.", "0"));
            for (i = 0; i < numC; i++)
            {
                //s.Value = Convert.ToString(prov.Rows[i][0]);
                //s.Text = Convert.ToString(prov.Rows[i][1]);
                Munucipio.Items.Insert(i + 1, new ListItem(Convert.ToString(Mun.Rows[i][2]), Convert.ToString(Mun.Rows[i][0])));
            }
        }
    }
}
