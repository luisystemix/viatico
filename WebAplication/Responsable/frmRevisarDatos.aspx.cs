using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBusiness.DB_Registro;

namespace WebAplication.Responsable
{
    public partial class frmRevisarDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            if (!IsPostBack)
            {
                LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                Seleccionar_CONTRATOS_ORG();
            }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region 
        protected void Seleccionar_CONTRATOS_ORG()
        {
            DB_AP_Responsable ListOrg = new DB_AP_Responsable();
            GVContrato.DataSource = ListOrg.DB_Seleccionar_CONTRATOS_ORG(Convert.ToInt32(LblIdInsOrg.Text), "juridica");
            GVContrato.DataBind();
        }
        #endregion
    }
}