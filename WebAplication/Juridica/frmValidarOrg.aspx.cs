using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DataBusiness.DB_Registro;
using DataBusiness.DB_General;
using DataEntity.DE_General;
using DataEntity.DE_Registro;

namespace WebAplication.Juridica
{
    public partial class frmValidarOrg : System.Web.UI.Page
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
                    Desplegar_REGISTRO_CONTRATOS_ORG();
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
            DB_AP_Campanhia cam = new DB_AP_Campanhia();
            DB_Regional reg = new DB_Regional();
            DataTable dt = new DataTable();
            dt = reg.DB_Seleccionar_REGIONAL(Convert.ToInt32(DDLRegional.SelectedValue));
            string aux = dt.Rows[0][7].ToString();
            dt = cam.DB_Seleccionar_CAMPANHIA_REG(aux, "INICIADO");
            DDLCamp.DataSource = dt;
            DDLCamp.DataValueField = "Id_Campanhia";
            DDLCamp.DataTextField = "Nombre";
            DDLCamp.DataBind();
        }
        #endregion
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
        #region OBTENER LA LISTA DE LAS LAS ORGANIZACIONES LISTAS PARA SU GENERACION DE CONTRATOS EN LA GRILLA
        protected void Desplegar_REGISTRO_CONTRATOS_ORG()
        {
          if(DDLCamp.SelectedValue!="")
           {
                LblMsj.Text = string.Empty;
                DB_AP_Responsable ListOrg = new DB_AP_Responsable();
                GVOrg.DataSource = ListOrg.DB_Desplegar_REGISTRO_CONTRATOS_ORG(Convert.ToInt32(DDLCamp.SelectedValue), Convert.ToInt32(DDLRegional.SelectedValue), DDLPrograma.SelectedValue);
                GVOrg.DataBind();
           }
          else
          {
                LblMsj.Text = "No se definieron   campañas";
          }
        }
        #endregion
        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DDLCAMPANHIA();
            Desplegar_REGISTRO_CONTRATOS_ORG();
        }
        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_REGISTRO_CONTRATOS_ORG();
        }
        protected void GVOrg_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVOrg.Columns[6].Visible = true;
            Desplegar_REGISTRO_CONTRATOS_ORG();
            Session.Add("IdInsOrg", GVOrg.Rows[rowIndex].Cells[6].Text);
            Session.Add("Estado", "modificar");
            StringBuilder sbMensaje = new StringBuilder();
            switch (tipo)
            {
                case "Revisar":
                    Response.Redirect("frmValidarDatosOrg.aspx");
                    break;
                case "Planilla":

                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Registro/repPlanillaProductores.aspx?ci=" + LblIdRol.Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    //Response.Redirect("repContratoProvision.aspx");
                    break;
                case "Contrato":
                    if (GVOrg.Rows[rowIndex].Cells[5].Text == "APROBADO-LEGAL")
                    {
                       
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Juridica/repContratoProvision.aspx?ci=" + LblIdRol.Text);
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                        //Response.Redirect("repContratoProvision.aspx");
                    }
                    else
                    {
                        LblMsj.Text = "Los datos de la organización aun no fueron aprobados por el área legal";
                    }
                    break;
            }
            GVOrg.Columns[6].Visible = false;
            Desplegar_REGISTRO_CONTRATOS_ORG();
        }
        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_REGISTRO_CONTRATOS_ORG();
        }
    }
}