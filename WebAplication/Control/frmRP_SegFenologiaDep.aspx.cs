using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DataBusiness.DB_General;
using DataEntity.DE_General;
using DataEntity.DE_Registro;
using DataBusiness.DB_Extensiones;
using DataBusiness.DB_Control;

namespace WebAplication.Control
{
    public partial class frmRP_SegFenologiaDep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    Llenar_DDLCAMPANHIA();
                    Llenar_GRILLA();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS
        private void Llenar_DDLCAMPANHIA()
        {
            //DataTable dt = new DataTable();
            //dt = 
            //DDLCamp.DataSource = dt;
            //DDLCamp.DataValueField = "Id_Campanhia";
            //DDLCamp.DataTextField = "Nombre";
            //DDLCamp.DataBind();
        }
        #endregion
        #region FUNCION PARA DESPLEGAR LA GRILLA
        private void Llenar_GRILLA()
        {
            DB_Regional reg = new DB_Regional();
            GVRegionales.DataSource = reg.DB_Desplegar_REGIONAL();
            GVRegionales.DataBind();
        }
        #endregion

        protected void DDLProg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ImgBtnPrint_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}