using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;
using DataBusiness.DB_General;
using DataEntity.DE_Extensiones;
using DataBusiness.DB_Extensiones;

namespace WebAplication.Extensiones
{
    public partial class frmListaSegFenologia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                    Datos_Org_ENCABEZADO();
                    Desplegar_GRILLA();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        private void Desplegar_GRILLA() 
        {
            DB_EXT_Fenologia ListFen = new DB_EXT_Fenologia();
            GVFaseFenologica.DataSource = ListFen.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), 0,0, 0, LblPrograma.Text, "", 0, DateTime.Now,"LISTA_FASE_FENOLOGICA");
            GVFaseFenologica.DataBind();
        }
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Datos_Org_ENCABEZADO()
        {
            DB_AP_Registro_Org d_org = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = d_org.DB_Desplegar_ENCABEZADO_ORG(Convert.ToInt32(LblIdInsOrg.Text));
            LblOrg.Text = dt.Rows[0][2].ToString();
            LblIdCamp.Text = dt.Rows[0][5].ToString();
            LblCamp.Text = dt.Rows[0][6].ToString();
            LblIdReg.Text = dt.Rows[0][7].ToString();
            LblReg.Text = dt.Rows[0][8].ToString();
            LblPrograma.Text = dt.Rows[0][9].ToString();
        }
        #endregion

        protected void LnkBtnEnviar_Click(object sender, EventArgs e)
        {
            Session.Add("IdUser", LblIdUsuario.Text);
            Session.Add("IdInsOrg", LblIdInsOrg.Text);
            Session.Add("IdCamp", LblIdCamp.Text);
            Session.Add("IdReg", LblIdReg.Text);
            Session.Add("Programa", LblPrograma.Text);

            DB_EXT_Fenologia Luis = new DB_EXT_Fenologia();
            if (Luis.DB_MaxNumSeg(Convert.ToInt32(LblIdInsOrg.Text)) > 0)
            {
                switch (LblPrograma.Text)
                {
                    case "TRIGO":
                        //Response.Redirect("frmFenologiaTrigo.aspx");
                        Response.Redirect("frmFaseFenTrigo.aspx");
                        break;
                    case "ARROZ":
                        Response.Redirect("frmFenologiaArroz.aspx");
                        break;
                    case "MAIZ":
                        Response.Redirect("frmFenologiaMaiz.aspx");
                        break;
                }
            }
            else
            {
                LblMsj.Text = "Por el momento NO registro seguimiento técnico a los cultivos, NO se puede procesar esta operación.";
            }
        }

        protected void GVFaseFenologica_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Session.Add("IdUser", LblIdUsuario.Text);
            Session.Add("IdInsOrg", LblIdInsOrg.Text);
            Session.Add("IdCamp", LblIdCamp.Text);
            Session.Add("IdReg", LblIdReg.Text);
            Session.Add("Programa", LblPrograma.Text);
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            Session.Add("NumSegCultivo", GVFaseFenologica.Rows[rowIndex].Cells[0].Text);
            StringBuilder sbMensaje = new StringBuilder();
            switch (tipo)
            {
                case "Reporte":
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repFaceFenologica.aspx?ci=" + GVFaseFenologica.Rows[rowIndex].Cells[0].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
            }
        }

        protected void ImgPrint_Click(object sender, ImageClickEventArgs e)
        {

            Session.Add("IdUser", LblIdUsuario.Text);
            Session.Add("IdInsOrg", "Total");
            Session.Add("IdCamp", LblIdCamp.Text);
            Session.Add("IdReg", LblIdReg.Text);
            Session.Add("Programa", LblPrograma.Text);
            Session.Add("NumSegCultivo", 0);
            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repFaceFenologica.aspx?ci=" + LblIdCamp.Text);
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
        }
    }
}