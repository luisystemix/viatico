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
    public partial class frmListaInformesUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUser.Text = Session["IdUser"].ToString();
                    Desplegar_SOLICITUD_USUARIO();                    
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
            DB_VT_Viaticos List = new DB_VT_Viaticos();
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            GVListSolicitud.DataSource = lista.DB_Desplegar_SOLICITUD_USUARIO(LblIdUser.Text, "","PARAINFORME");
            GVListSolicitud.DataBind();
        }
        #endregion
        protected void GVListSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            DataTable dt = new DataTable();
            object IdSolicitud = GVListSolicitud.DataKeys[rowIndex % GVListSolicitud.PageSize].Value;
            dt = sol.DB_Reporte_SOLICITUD_US(IdSolicitud.ToString(), "DIAS_SIN_INFORME");// lrojas: 23/05/2017 SE MODIFICO EL SP EN EL CALCULO DE DIAS HABILES
            int aux = Convert.ToInt32(dt.Rows[0][0].ToString());
            Session.Add("IdSolicitud", IdSolicitud.ToString());
            StringBuilder sbMensaje = new StringBuilder();
            switch (tipo)
            {
                case "Solicitud":
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repSolicitud.aspx?ci=" + IdSolicitud.ToString());
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "Ver":
                    if(GVListSolicitud.Rows[rowIndex].Cells[5].Text=="INF-ENVIADO" || GVListSolicitud.Rows[rowIndex].Cells[5].Text=="INF-APROBADO")
                    {
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repInforme.aspx?ci=" + IdSolicitud.ToString());
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    }
                    else
                    {
                        LblMsj.Text = "No realizo su informe de viaje, No puede continuar";
                    }
                    break;
                case "Realizar":
                    //if ( aux <= 8) // modificado el usuario debe realizar si informe aun pasado los 8 dias luego de ser habilitado
                    //{
                        if(GVListSolicitud.Rows[rowIndex].Cells[5].Text != "OBSERVADO")
                        {
                              if (GVListSolicitud.Rows[rowIndex].Cells[6].Text == "SIN INFORME")
                                {
                                    Response.Redirect("frmRealizarInforme.aspx");
                                }
                                else
                                {
                                    if (GVListSolicitud.Rows[rowIndex].Cells[5].Text == "INF-ENVIADO" || GVListSolicitud.Rows[rowIndex].Cells[5].Text == "INF-APROBADO")
                                    {
                                        LblMsj.Text = "Su informe de viaje, ya fue realizado.";
                                        //Response.Redirect("frmRealizarInforme.aspx");//************                                  
                                    }
                                    else
                                    {
                                        Response.Redirect("frmRealizarInforme.aspx");
                                    }
                                }     
                        }
                        else
                        {
                            LblMsj.Text = "La solicitud fue observada, NO se puede continuar";
                        }
                    /*}
                    else
                    {
                        LblMsj.Text = "NO realizo el informe de viaje en el tiempo de 8 días establecido según reglamento, comuníquese con el administrador.";
                    } */                       
                    break;
                case "Modificar":
                    
                    if (GVListSolicitud.Rows[rowIndex].Cells[5].Text == "INF-ENVIADO")
                    {
                        Response.Redirect("frmModificarInforme.aspx");
                    }
                    else 
                    {
                        if (GVListSolicitud.Rows[rowIndex].Cells[5].Text == "APROBADO")
                        {
                            LblMsj.Text = "No realizo su informe de viaje, No puede continuar";
                        }
                        else
                        {
                            if (GVListSolicitud.Rows[rowIndex].Cells[5].Text == "INF-APROBADO")
                            {
                                LblMsj.Text = "Informe de viaje aprobado, NO puede continuar.";
                            }                            
                        }                        
                    }

                    break;
            } 
        }
        protected void ImgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("frmBorrar.aspx");
        }

        protected void GVListSolicitud_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string valor = DataBinder.Eval(e.Row.DataItem, "EstadoInf").ToString();
                if (valor == "")
                {
                    e.Row.Cells[6].Text = "SIN INFORME";
                }
            }
            /*************************************************/
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DB_VT_Solicitud sol = new DB_VT_Solicitud();
                VT_Observacion obs = new VT_Observacion();
                string idsol = DataBinder.Eval(e.Row.DataItem, "Id_Solicitud").ToString();
                string estado = DataBinder.Eval(e.Row.DataItem, "Estado").ToString();
                DataTable dt = new DataTable();
                dt = sol.DB_Reporte_SOLICITUD_US(idsol, "DIAS_SIN_INFORME");
                int aux = Convert.ToInt32(dt.Rows[0][0].ToString());
                // ((Label)e.Row.FindControl("LblObs")).Text = idsol;
                obs.Id_Solicitud = idsol;
                obs.Observacion = "PASO DE LA FECHA LIMITE DE ENTREGA DE INFORME";
                obs.Tipo = "Solicitud";

                //AHJ: 8 DIAS PERMITIDO PARA OFICINA CENTRAL LA PAZ
                //AHJ: 5 DIAS PERMITIDOS PARA EL RESTO DE LAS REGIONALES

                int dias_permitido = idsol.Substring(6, 3) == "OFC" ? 8 : 5;

                if (aux > dias_permitido && estado == "APROBADO")
                {
                    sol.DB_Cambiar_ESTADO(idsol, "OBSERVADO");
                    sol.DB_Registrar_OBSERVACION_SOLICITUD(obs);
                }
                if (estado == "OBSERVADO")
                {
                    dt = sol.DB_Seleccionar_OBSERVACION_SOLICITUD(idsol);
                    if (dt.Rows.Count > 0)
                    {
                        ((Label)e.Row.FindControl("LblObs")).Text = dt.Rows[0][0].ToString();
                    }
                }
            }
         }
        
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
        }

        protected void GVListSolicitud_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVListSolicitud.PageIndex = e.NewPageIndex;
            Desplegar_SOLICITUD_USUARIO();
        }
    }
}