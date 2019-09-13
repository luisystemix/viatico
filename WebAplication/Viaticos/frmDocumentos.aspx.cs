using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Threading;
using DataBusiness.DB_Viaticos;

namespace WebAplication.Viaticos
{
    public partial class frmDocumentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdSolicitud.Text = Session["IdSolicitud"].ToString();
                    Cargar_ENCABEZADO();
                }
            }
            catch 
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Cargar_ENCABEZADO()
        {
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            DataTable data = new DataTable();
            data = sol.DB_Reporte_SOLICITUD_US(LblIdSolicitud.Text, "ENCABEZADO");
            LblNombre.Text = data.Rows[0][12].ToString();
            LblCargo.Text = data.Rows[0][4].ToString();
            LbLugarFun.Text = data.Rows[0][11].ToString();
            LblEstado.Text = data.Rows[0][10].ToString();
        }
        #endregion
        protected void ImgBtnSolicitud_Click(object sender, ImageClickEventArgs e)
        {
            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repSolicitud.aspx?ci=" + LblIdSolicitud.Text);
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
        }

        protected void ImgBtnMemo_Click(object sender, ImageClickEventArgs e)
        {
            if (LblEstado.Text == "PROCESADO")
            {
                StringBuilder sbMensaje = new StringBuilder();
                sbMensaje.Append("<script type='text/javascript'>");
                sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repMemo.aspx?ci=" + LblIdSolicitud.Text);
                sbMensaje.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
            }
            else
            {
                LblMsj.Text = "DEBE PROCESAR LA PLANILLA DE VIAJE PARA PODER CONTINUAR";
            }
        }

        protected void ImgBtnPlanilla_Click(object sender, ImageClickEventArgs e)
        {
            if (LblEstado.Text == "PROCESADO")
            {
            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repPlanillaPago.aspx?ci=" + LblIdSolicitud.Text);
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
            }
            else
            {
                LblMsj.Text = "DEBE PROCESAR LA PLANILLA DE VIAJE PARA PODER CONTINUAR";
            }
        }

        protected void ImgBtnInforme_Click(object sender, ImageClickEventArgs e)
        {
            if (LblEstado.Text == "PROCESADO")
            {
                StringBuilder sbMensaje = new StringBuilder();
                sbMensaje.Append("<script type='text/javascript'>");
                //sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../AcopioSilos/frmjose.aspx?ci=" + LblIdSolicitud.Text);
                sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repInforme.aspx?ci=" + LblIdSolicitud.Text);
                sbMensaje.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
            }
            else
            {
                LblMsj.Text = "DEBE PROCESAR LA PLANILLA DE VIAJE PARA PODER CONTINUAR";
            }
        }
    }
}