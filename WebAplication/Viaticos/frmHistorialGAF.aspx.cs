using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using DataEntity.DE_Viaticos;
using DataBusiness.DB_Viaticos;
using DataEntity.DE_General;
using DataBusiness.DB_General;
using DataBusiness.DB_Registro;

namespace WebAplication.Viaticos
{
    public partial class frmHistorialGAF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Desplegar_REGIONAL();
                    Desplegar_SOLICITUD_USUARIO();
                    Desplegar_SOLICITUD_OBSERBADOS();
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
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Desplegar_SOLICITUD_USUARIO()
        {
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            GVListSolicitud.DataSource = lista.DB_Desplegar_SOLICITUD_USUARIO(TxtBuscar.Text, DDLRegional.SelectedItem.Text, "FINALIZADO");
            GVListSolicitud.DataBind();
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Desplegar_SOLICITUD_OBSERBADOS()
        {
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            GVListSolicitudObs.DataSource = lista.DB_Desplegar_SOLICITUD_USUARIO("0", "", "OBSERVADOS");
            GVListSolicitudObs.DataBind();
        }
        #endregion
        protected void GVListSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        {            
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            object IdSolicitud = GVListSolicitud.DataKeys[rowIndex % GVListSolicitud.PageSize].Value;
            string EstadoSel = string.Empty;
            DB_VT_Solicitud s = new DB_VT_Solicitud();
            StringBuilder sbMensaje = new StringBuilder();
            
            switch (tipo)
            {
                case "Solicitud":
                    Session.Add("IdSolicitud", IdSolicitud.ToString());
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repSolicitud.aspx?ci=" + GVListSolicitud.Rows[rowIndex].Cells[1].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "Memo":
                    Session.Add("IdSolicitud", IdSolicitud.ToString());
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repMemo.aspx?ci=" + GVListSolicitud.Rows[rowIndex].Cells[1].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "Planilla":
                    Session.Add("IdSolicitud", IdSolicitud.ToString());
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repPlanillaPago.aspx?ci=" + GVListSolicitud.Rows[rowIndex].Cells[1].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "Informe":
                    Session.Add("IdSolicitud", IdSolicitud.ToString());
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repInforme.aspx?ci=" + GVListSolicitud.Rows[rowIndex].Cells[1].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "Aprobar":
                    EstadoSel = ((DropDownList)GVListSolicitud.Rows[rowIndex].FindControl("DDLEstado")).SelectedItem.Text; //GVListSolicitud.Rows[rowIndex].Cells[8].Text
                    s.DB_Cambiar_ESTADO(IdSolicitud.ToString(), EstadoSel);
                    Desplegar_SOLICITUD_USUARIO();
                    break;
            }
        }
        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_SOLICITUD_USUARIO();
            TxtBuscar.Text = string.Empty;
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Desplegar_SOLICITUD_USUARIO();
        }
        protected void GVListSolicitud_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVListSolicitud.PageIndex = e.NewPageIndex;
            Desplegar_SOLICITUD_USUARIO();            
        }
        protected void GVListSolicitudObs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            object IdSolicitud = GVListSolicitudObs.DataKeys[rowIndex % GVListSolicitudObs.PageSize].Value;
            DB_VT_Solicitud s = new DB_VT_Solicitud();
            StringBuilder sbMensaje = new StringBuilder();
            switch (tipo)
            {
                case "Solicitud":
                    Session.Add("IdSolicitud", IdSolicitud.ToString());
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repSolicitud.aspx?ci=" + GVListSolicitudObs.Rows[rowIndex].Cells[1].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "Memo":
                    Session.Add("IdSolicitud", IdSolicitud.ToString());
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repMemo.aspx?ci=" + GVListSolicitudObs.Rows[rowIndex].Cells[1].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "Planilla":
                    Session.Add("IdSolicitud", IdSolicitud.ToString());
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repPlanillaPago.aspx?ci=" + GVListSolicitudObs.Rows[rowIndex].Cells[1].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "Informe":
                    Session.Add("IdSolicitud", IdSolicitud.ToString());
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repInforme.aspx?ci=" + GVListSolicitudObs.Rows[rowIndex].Cells[1].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
            }
        }
        protected void GVListSolicitudObs_PreRender(object sender, EventArgs e)
        {
            if (GVListSolicitudObs.Rows.Count > 0)
            {
                GVListSolicitudObs.UseAccessibleHeader = true;
                GVListSolicitudObs.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void GVListSolicitud_PreRender(object sender, EventArgs e)
        {
            if (GVListSolicitud.Rows.Count > 0)
            {
                GVListSolicitud.UseAccessibleHeader = true;
                GVListSolicitud.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void GVListSolicitudObs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVListSolicitudObs.PageIndex = e.NewPageIndex;
            Desplegar_SOLICITUD_OBSERBADOS();
        }
        protected void GVListSolicitud_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Estado = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Estado"));
                ((DropDownList)e.Row.FindControl("DDLEstado")).SelectedValue = Estado;
            }
        }
    }
}