using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using DataAccess.DA_Registro;
using DataEntity.DE_Registro;

namespace DataBusiness.DB_Registro
{
   public class DB_AP_Comunidad
    {
        // llena el droplist con provincias
        public void DB_Desplegar_COMUNIDAD_DROPDOWNLIST(Int32 id_Mun, DropDownList Comu)
        {
            // VALIDAR DESDE AQUI
            DA_AP_Comunidad data = new DA_AP_Comunidad();
            System.Data.DataTable com = new System.Data.DataTable();
            com = data.DA_AP_COMUNIDAD_SeleccionarComu(id_Mun);
            Int32 numC = com.Rows.Count;
            Int32 i = 0;
            Comu.Items.Insert(0, new ListItem("Seleccionar Comunidad.", "0"));
            for (i = 0; i < numC; i++)
            {
               Comu.Items.Insert(i + 1, new ListItem(Convert.ToString(com.Rows[i][2]), Convert.ToString(com.Rows[i][0])));
            }

        }
        #region REGISTRAR NUEVA COMUNIDAD
        public void DB_Registrar_COMUNIDAD(AP_Comunidad c)
        {
            DA_AP_Comunidad insert = new DA_AP_Comunidad();
            insert.DA_Registrar_COMUNIDAD(c);
        }
        #endregion

       /**************************************/
        #region BUSCAR CAMPAÑA POR LA REGION Y EL ESTADO
        public DataTable DB_Buscar_COMU_ORG(Int32 IdInscripOrg, Int32 IdComunidad, String IdPersona, String Parametro)
        {
            DA_AP_Comunidad data = new DA_AP_Comunidad();
            return data.DA_Buscar_COMU_ORG(IdInscripOrg, IdComunidad, IdPersona, Parametro);
        }
        #endregion
    }
}
