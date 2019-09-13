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
using DataBusiness.DB_Extensiones;
using DataBusiness.DB_Control;
using DataEntity.DE_Extensiones;

namespace WebAplication.Control
{
    public partial class frmListCronogramaSegAvance : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUser.Text = Session["IdUser"].ToString();
                    LblIdCrono.Text = Session["IdCrono"].ToString();
                    Llenar_DDLRegional();
                    Desplegar_LISTA_CRONOGRAMAS();
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
            DB_AdminUser User = new DB_AdminUser();
            DataTable dt = User.DB_Desplegar_USUARIO(LblIdUser.Text);
            LblRegional.Text = dt.Rows[0][5].ToString();
            LblIdReg.Text = dt.Rows[0][4].ToString();
        }
        #endregion

        #region FUNCION PARA DESPLEGAR LA LISTDE LOS CRONOGRAMS
        protected void Desplegar_LISTA_CRONOGRAMAS()
        {
            try
            {
                DB_EXT_Cronogramas ListC = new DB_EXT_Cronogramas();
                //DataTable Conograma = ListC.DB_Desplegar_LISTA_CRONOGRAMAS("", Convert.ToInt32(LblIdCrono.Text), 0, "CRONOGRAMAS_PERSONAL");
                DataTable CronogramaAvance = ListC.DB_Desplegar_LISTA_ACTIVIDADES_CRONOGRAMA(Convert.ToInt32(LblIdCrono.Text));
                GVCronogramas.DataSource = CronogramaAvance;
                GVCronogramas.DataBind();
               
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
            
        }
        #endregion

        protected void GVCronogramas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //StringBuilder sbMensaje = new StringBuilder();
            //string tipo = Convert.ToString(e.CommandName);
            //int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Session.Add("IdCrono", GVCronogramas.Rows[rowIndex].Cells[1].Text);
            //switch (tipo)
            //{
            //    case "imprimir":
            //        sbMensaje.Append("<script type='text/javascript'>");
            //        sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Control/repCronogramaSegAvance.aspx?ci=" + GVCronogramas.Rows[rowIndex].Cells[1].Text);
            //        sbMensaje.Append("</script>");
            //        ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
            //        break;
                
            //}
        }

        protected void GVCronogramas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Porcentaje = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PorcentajeAvance"));
                if (Porcentaje != string.Empty)
                {                   
                   ((TextBox)e.Row.FindControl("txtAvance")).Text = Porcentaje;
                }
                string ObsAv = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ObservacionAvance"));
                if (ObsAv != "")
                {
                    ((TextBox)e.Row.FindControl("txtObsAvance")).Text = ObsAv;
                }
                string Fuente = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FuenteVerificacion"));
                ((TextBox)e.Row.FindControl("txtFuenteVerificacion")).Text = Fuente;
                
                string ObsGeneral = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Observaciones"));
                ((TextBox)e.Row.FindControl("txtObservaciones")).Text = ObsGeneral;
                
                
            }
        }
        protected void ImgPrint_Click(object sender, ImageClickEventArgs e)
        {
            StringBuilder sbMensaje = new StringBuilder();
            Session.Add("IdCrono", LblIdCrono.Text);            
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1300,height=700,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Control/repCronogramaSegAvance.aspx?ci=" + LblIdCrono.Text);
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<EXT_CronogramaDiasAvance> ColAvance = new List<EXT_CronogramaDiasAvance>();
                DB_EXT_Cronogramas reg = new DB_EXT_Cronogramas();
                foreach (GridViewRow row in GVCronogramas.Rows)
                {
                    EXT_CronogramaDiasAvance Avance = new EXT_CronogramaDiasAvance();
                    Avance.Id_CronogramaAvance = Convert.ToInt16(row.Cells[0].Text);
                    TextBox tAvance = (TextBox)row.FindControl("txtAvance");
                    decimal av = Convert.ToDecimal(tAvance.Text);
                    Avance.PorcentajeAvance = av;
                    TextBox tObAvance =(TextBox)row.FindControl("txtObsAvance");
                    string obsav = HttpUtility.HtmlDecode(tObAvance.Text);
                    Avance.ObservacionAvance = obsav;
                    TextBox tFuente = (TextBox)row.FindControl("txtFuenteVerificacion");
                    string Fuente = HttpUtility.HtmlDecode(tFuente.Text);
                    Avance.FuenteVerificacion = Fuente;
                    TextBox tObGral = (TextBox)row.FindControl("txtObservaciones");
                    string ObsGral = HttpUtility.HtmlDecode(tObGral.Text);
                    Avance.Observaciones = ObsGral;

                    ColAvance.Add(Avance);
                }
                //foreach (GridViewRow row in GVCronogramas.Rows)
                //{
                //    CheckBox chkEstado = (CheckBox)row.FindControl("CBXEstado");
                //    chkEstado.Enabled = flag;
                //}            
                reg.DB_UPDATE_CRONOGRAMA_DIA_AVANCE(ColAvance);
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, "INFORMACION REGISTRADA");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
            catch(Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }

           
            
        }
    }
}