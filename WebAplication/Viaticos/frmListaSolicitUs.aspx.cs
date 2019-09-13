using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using DataEntity.DE_Viaticos;
using DataBusiness.DB_Viaticos;
using DataEntity.DE_General;
using DataBusiness.DB_General;
using DataBusiness.DB_Registro;

namespace WebAplication.Viaticos
{
    public partial class frmListaSolicitUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUser.Text = Session["IdUser"].ToString();
                    Desplegar_SOLICITUD_USUARIO();
                    if (GVListSolicitud.Rows.Count == 0)
                    {
                        LblMsj.Text = "No tiene ninguna solicitud pendiente";
                    }
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Desplegar_SOLICITUD_USUARIO()
        {
           // DB_VT_Viaticos List = new DB_VT_Viaticos();
            DataTable dt = new DataTable();
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            GVListSolicitud.DataSource = lista.DB_Desplegar_SOLICITUD_USUARIO(LblIdUser.Text,"","USUARIO");
            GVListSolicitud.DataBind();
        }
        #endregion
        protected void GVListSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            StringBuilder sbMensaje = new StringBuilder();
            DataTable dt = new DataTable();
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            object IdSolicitud = GVListSolicitud.DataKeys[rowIndex % GVListSolicitud.PageSize].Value;
            Session.Add("IdSolicitud", IdSolicitud.ToString());
            switch (tipo)
            {
                case "Solicitud":           
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repSolicitud.aspx?ci=" + IdSolicitud.ToString());
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "Editar":
                   dt = sol.DB_Reporte_SOLICITUD_US(IdSolicitud.ToString(), "DIAS_SIN_INFORME");
                    int aux = Convert.ToInt32(dt.Rows[0][0].ToString());
                    if (GVListSolicitud.Rows[rowIndex].Cells[6].Text == "OBSERVADO")
                    {
                        LblMsj.Text = "No se puede realizar modificaciones a la solicitud, sobrepaso el límite de 8 Días";
                    }
                    else
                    {
                        //if (GVListSolicitud.Rows[rowIndex].Cells[6].Text == "ENVIADO" || GVListSolicitud.Rows[rowIndex].Cells[6].Text == "OBSERVADO")
                        if (GVListSolicitud.Rows[rowIndex].Cells[6].Text == "ENVIADO")
                        {
                            //if(aux <=8)
                            //{
                            Response.Redirect("frmModificarSolicitud.aspx");
                            //}
                            //else
                            //{
                            //    LblMsj.Text = "No se puede realizar modificaciones a la solicitud";
                            //}
                        }
                        else
                        {
                            LblMsj.Text = "La solicitud de viaje está en estado de " + GVListSolicitud.Rows[rowIndex].Cells[6].Text + ", No se pueden realizar cambios";
                        }  
                    }
                    break;
                case "Memo":
                    if (GVListSolicitud.Rows[rowIndex].Cells[6].Text == "APROBADO" || GVListSolicitud.Rows[rowIndex].Cells[6].Text == "PROCESADO")
                    {
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repMemo.aspx?ci=" + IdSolicitud.ToString());
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    }
                    else
                    {
                        Response.Write("<script>window.alert('por el momento No se APROBO su solicitud vieje');</script>");
                    }
                    break;
            } 
        }

        protected void LnkNuevo_Click(object sender, EventArgs e)
        {
            DB_VT_Viaticos cont = new DB_VT_Viaticos();
            Desplegar_SOLICITUD_USUARIO();
            //if(GVListSolicitud.Rows.Count == 0)
            //{
                Response.Redirect("frmRealizarSolicitud.aspx");
            //}
            //else
            //{
            //    if (cont.DB_Contar_SOLICITUIDES_ENVIADAS(LblIdUser.Text, "OBSERVADO") <= 0)
            //    {
            //        Response.Redirect("frmRealizarSolicitud.aspx");
            //    }
            //    else
            //    {
            //        LblMsj.Text = "Su solicitud no fue atendida o Tiene un informe pendiente";
            //    }
            //}
        }

        protected void GVListSolicitud_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DB_VT_Solicitud sol = new DB_VT_Solicitud();
                VT_Observacion obs = new VT_Observacion();
                string idsol = DataBinder.Eval(e.Row.DataItem, "Id_Solicitud").ToString();
                string estado = DataBinder.Eval(e.Row.DataItem, "Estado").ToString();
                DataTable dt = new DataTable();
                dt = sol.DB_Reporte_SOLICITUD_US(idsol, "OBSERVACION");
                    if (dt.Rows.Count > 0)
                    {
                        ((Label)e.Row.FindControl("LblObs")).Text = dt.Rows[0][1].ToString();
                    }
            }
        }
        protected void GVListSolicitud_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVListSolicitud.PageIndex = e.NewPageIndex;
            Desplegar_SOLICITUD_USUARIO();
        }
    }
}