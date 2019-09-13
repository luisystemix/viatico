using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;
using DataBusiness.DB_General;
using DataEntity.DE_General;

namespace WebAplication.Juridica
{
    public partial class repElaboracionContratosMP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*try
            {*/
                if (!IsPostBack)
                {
                    Desplegar_REGISTRO_CONTRATOS_ORG();
                }
            /*}
            catch
            {
                Response.Redirect("~/About.aspx");
            }*/
        }
        #region OBTENER LA LISTA DE LAS LAS ORGANIZACIONES LISTAS PARA SU GENERACION DE CONTRATOS EN LA GRILLA
        protected void Desplegar_REGISTRO_CONTRATOS_ORG()
        {
            int idcamp=Convert.ToInt32(Session["IdCamp"].ToString());
            int idreg =Convert.ToInt32(Session["IdRegional"].ToString());
            string programa=Session["Programa"].ToString();
            DB_AP_Responsable ListOrg = new DB_AP_Responsable();
            GVContrato.DataSource = ListOrg.DB_Desplegar_REGISTRO_CONTRATOS_ORG(idcamp, idreg, programa);
            GVContrato.DataBind();
        }
        #endregion
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}