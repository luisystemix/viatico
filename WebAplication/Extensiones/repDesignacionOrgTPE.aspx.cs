using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;
using DataBusiness.DB_General;
using DataEntity.DE_Extensiones;
using DataBusiness.DB_Extensiones;

namespace WebAplication.Extensiones
{
    public partial class repDesignacionOrgTPE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdReg.Text = Session["IdReg"].ToString();
                    LblPrograma.Text = Session["Prog"].ToString();
                    LblIdCamp.Text = Session["IdCamp"].ToString();
                    //Desplegar_USUARIO();
                    Llenar_GVDESIGNADO();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        private void Llenar_GVDESIGNADO()
        {
            DB_EXT_DesignacionOrg ListDesOrg = new DB_EXT_DesignacionOrg();
            GVDesignado.DataSource = ListDesOrg.DB_Seleccionar_DESIGNACION_ORG(Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblIdCamp.Text),"", LblPrograma.Text, "REP_LISTASIGNADOS");
            GVDesignado.DataBind();
        }
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Desplegar_USUARIO()
        {
            DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = Usuario.DB_Desplegar_USUARIO(Session["IdUser"].ToString());
            //LblRegional.Text = dt.Rows[0][5].ToString();
            LblIdReg.Text = dt.Rows[0][4].ToString();
        }
        #endregion
    }
}