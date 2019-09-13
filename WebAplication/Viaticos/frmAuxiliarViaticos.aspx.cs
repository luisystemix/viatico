using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Threading;
using DataEntity.DE_Viaticos;
using DataBusiness.DB_Viaticos;
using DataEntity.DE_General;
using DataBusiness.DB_General;
using DataBusiness.DB_Registro;

namespace WebAplication.Viaticos
{
    public partial class frmAuxiliarViaticos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Desplegar_REGIONAL();
                    Desplegar_SOLICITUD_USUARIO();
                    //Desplegar_SOLICITUD_PROCESADO();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCIONES PARA DESPLEGAR REGIONALES EN EL COMBO
        protected void Desplegar_REGIONAL()
        {
            DB_Regional r = new DB_Regional();
            List<Regional> listaR = r.DB_Desplegar_REGIONAL();
            DDLRegional.DataSource = listaR;
            DDLRegional.DataValueField = "Id_Regional";
            DDLRegional.DataTextField = "Nombre";
            DDLRegional.DataBind();
            DDLRegional.Items.Insert(0, new ListItem("Seleccione la Regional", "0", true));
        }
        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_SOLICITUD_USUARIO();
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Desplegar_SOLICITUD_USUARIO()
        {
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            GVListSolicitud.DataSource = lista.DB_Desplegar_SOLICITUD_USUARIO("0", DDLRegional.SelectedItem.Text, "PROCESAR");
            GVListSolicitud.DataBind();
        }
        #endregion

        protected void GVListSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            Session.Add("IdSolicitud", GVListSolicitud.Rows[rowIndex].Cells[0].Text);
            DB_VT_Solicitud s = new DB_VT_Solicitud();
            StringBuilder sbMensaje = new StringBuilder();
            switch (tipo)
            {
                case "Solicitud":
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repSolicitud.aspx?ci=" + GVListSolicitud.Rows[rowIndex].Cells[0].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "Memo":
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repMemo.aspx?ci=" + GVListSolicitud.Rows[rowIndex].Cells[0].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "Informe":
                    if (GVListSolicitud.Rows[rowIndex].Cells[8].Text == "INF-APROBADO")
                    {
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repInforme.aspx?ci=" + GVListSolicitud.Rows[rowIndex].Cells[0].Text);
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    }
                    else
                    {
                        Response.Write("<script>window.alert('El Informe No se envió e No se Aprobó por el inmediato superior');</script>");
                    }
                    break;
            }
        }

        protected void GVListSolicitud_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string idsolicit = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Id_Solicitud"));
                DataTable dt = new DataTable();
                DB_VT_Solicitud sol = new DB_VT_Solicitud();
                dt = sol.DB_Seleccionar_OBSERVACION_SOLICITUD(idsolicit);
                if (dt.Rows.Count > 0)
                {
                    ((Label)e.Row.FindControl("LblObs")).Text = dt.Rows[0][0].ToString();
                }
            }
        }
    }
}