using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using DataBusiness.DB_Extensiones;
using DataBusiness.DB_Registro;
using DataEntity.DE_General;
using DataBusiness.DB_General;
using DataEntity.DE_Registro;

namespace WebAplication.Control
{
    public partial class frmResultadosRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUser.Text = Session["IdUser"].ToString();
                    Llenar_DDLRegional();
                    Llenar_DDLCAMPANHIA();
                    Desplegar_LISTA_ORGANIZACIONES();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCION PARA LLENAR EL COMBO CON EL TIPO DE ORGANIZACION
        private void Llenar_DDLRegional()
        {
            DB_Regional reg = new DB_Regional();
            List<Regional> Lista = reg.DB_Desplegar_REGIONAL();
            DDLRegional.DataSource = Lista;
            DDLRegional.DataValueField = "Id_Regional";
            DDLRegional.DataTextField = "Nombre";
            DDLRegional.DataBind();
        }
        #endregion
        #region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS
        private void Llenar_DDLCAMPANHIA()
        {
            DB_AP_Campanhia cam = new DB_AP_Campanhia();
            DB_Regional reg = new DB_Regional();
            DataTable dt = new DataTable();
            dt = reg.DB_Seleccionar_REGIONAL(Convert.ToInt32(DDLRegional.SelectedValue));
            string aux = dt.Rows[0][7].ToString();
            dt = cam.DB_Seleccionar_CAMPANHIA_REG_NOFIN(aux);
            DDLCamp.DataSource = dt;
            DDLCamp.DataValueField = "Id_Campanhia";
            DDLCamp.DataTextField = "Nombre";
            DDLCamp.DataBind();
        }
        #endregion
        #region 
        private void Desplegar_LISTA_ORGANIZACIONES()
        {
            DB_AP_InscripcionOrg iorg = new DB_AP_InscripcionOrg();
            GVListaOrg.DataSource = iorg.DB_Desplegar_ORG_REG_CAMP("LISTA_OFICIAL_ORG", 0, Convert.ToInt32(DDLRegional.SelectedValue), Convert.ToInt32(DDLCamp.SelectedValue), DDLPrograma.SelectedValue);
            GVListaOrg.DataBind();
        }
        #endregion
        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DDLCAMPANHIA();
            Desplegar_LISTA_ORGANIZACIONES();
        }
        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_LISTA_ORGANIZACIONES();
        }
        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_LISTA_ORGANIZACIONES();
        }
        protected void GVListaOrg_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVListaOrg.Columns[4].Visible = true;
            Desplegar_LISTA_ORGANIZACIONES();
            Session.Add("IdInsOrg", GVListaOrg.Rows[rowIndex].Cells[4].Text);
            StringBuilder sbMensaje = new StringBuilder();
            switch (tipo)
            {
                case "ListOfi":
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=800,height=400,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Responsable/repListaOficial.aspx?ci=" + GVListaOrg.Rows[rowIndex].Cells[4].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "ListDepu":
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=800,height=400,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Responsable/repListaDepurados.aspx?ci=" + GVListaOrg.Rows[rowIndex].Cells[4].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "ResumOrg":
                    Response.Redirect("../Registro/repCronogramaRegIni.aspx");
                    break;
                case "ResumDocLeg":
                    Response.Redirect("../Control/frmListCronogramaReg.aspx");
                    break;
            }
            GVListaOrg.Columns[4].Visible = false;
            Desplegar_LISTA_ORGANIZACIONES();
        }
    }
}