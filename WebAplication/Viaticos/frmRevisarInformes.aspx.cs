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
    public partial class frmRevisarInformes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                if (!IsPostBack)
                {
                    Llenar_DDLRegional();
                    Desplegar_SOLICITUD_USUARIO();
                    Desplegar_DEUDORES_INFORME();
                    Desplegar_DEUDOR_INFORME();
                }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        } 
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Desplegar_SOLICITUD_USUARIO()
        {
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            GVListSolicitud.DataSource = lista.DB_Desplegar_SOLICITUD_USUARIO(DDLRegional.SelectedItem.Text, "INF-ENVIADO", "VERINFORME_REGIONAL");
            GVListSolicitud.DataBind();
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Desplegar_DEUDOR_INFORME()
        {
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            GVListSolicit.DataSource = lista.DB_Desplegar_SOLICITUD_USUARIO(DDLRegional.SelectedItem.Text, "OBSERVADO", "VERINFORME");
            GVListSolicit.DataBind();
        }
        #endregion
        protected void GVListSolicitud_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DB_VT_Solicitud sol = new DB_VT_Solicitud();
                string valor = DataBinder.Eval(e.Row.DataItem, "EstadoInf").ToString();
                   if (valor == "")
                    {
                        e.Row.Cells[10].Text = "SIN INFORME";
                    }
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
        protected void GVListSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            object IdSolicitud = GVListSolicitud.DataKeys[rowIndex % GVListSolicitud.PageSize].Value;
            Session.Add("IdSolicitud", IdSolicitud.ToString());
            DB_VT_Solicitud s = new DB_VT_Solicitud();
            DB_VT_Informe i = new DB_VT_Informe();
            StringBuilder sbMensaje = new StringBuilder();
            DataTable dt = new DataTable();
            switch (tipo)
            {
                case "Solicitud":
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repSolicitud.aspx?ci=" + GVListSolicitud.Rows[rowIndex].Cells[0].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    LblMsj.Text = "";
                    break;
                case "Informe":
                     
                     dt = i.DB_Seleccionar_INFORME(GVListSolicitud.Rows[rowIndex].Cells[0].Text, "INFORME");

                     if ((GVListSolicitud.Rows[rowIndex].Cells[8].Text == "INF-ENVIADO")) /*&& (dt.Rows[0][4].ToString())=="APROBADO")*/
                    {
                      sbMensaje.Append("<script type='text/javascript'>");
                      sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repInforme.aspx?ci=" + GVListSolicitud.Rows[rowIndex].Cells[0].Text);
                      sbMensaje.Append("</script>");
                      ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                      LblMsj.Text = "";
                    }
                    else
                    {
                        LblMsj.Text = "NO REALIZO SU INFORME DE VIAJE, NO PUEDE CONTINUAR";
                    }
                    break;
                case "Finalizar":
                   
                    if (GVListSolicitud.Rows[rowIndex].Cells[8].Text == "INF-APROBADO")
                    {
                        i.DB_Cambiar_ESTADOINF(GVListSolicitud.Rows[rowIndex].Cells[0].Text, "ACEPTADO");
                        s.DB_Cambiar_ESTADO(GVListSolicitud.Rows[rowIndex].Cells[0].Text, "FINALIZADO");
                        Desplegar_SOLICITUD_USUARIO();
                        LblMsj.Text = "";
                    }
                    else
                    {
                        LblMsj.Text = "NO REALIZO SU INFORME DE VIAJE, NO PUEDE CONTINUAR";
                    }
                    break;
                case "Rechazar":
                        i.DB_Cambiar_ESTADOINF(GVListSolicitud.Rows[rowIndex].Cells[0].Text, "RECHAZADO");
                        Desplegar_SOLICITUD_USUARIO();
                    break;
            }
        }

        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_SOLICITUD_USUARIO();
            Desplegar_DEUDORES_INFORME();
            Desplegar_DEUDOR_INFORME();
        }
        protected void GVListSolicit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            DB_VT_Solicitud s = new DB_VT_Solicitud();
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            object IdSolicitud = GVListSolicit.DataKeys[rowIndex % GVListSolicit.PageSize].Value;
            Session.Add("IdSolicitud", IdSolicitud.ToString());
            switch (tipo)
            {
                case "Rehabilitar":
                       //s.DB_Cambiar_ESTADO(GVListSolicit.Rows[rowIndex].Cells[0].Text, "APROBADO");
                    s.DB_Cambiar_ESTADO(GVListSolicit.Rows[rowIndex].Cells[0].Text, "HABILITADO");
                       //s.DB_Eliminar_OBSERVACION(GVListSolicit.Rows[rowIndex].Cells[0].Text); 
                       Desplegar_SOLICITUD_USUARIO();
                       Desplegar_DEUDOR_INFORME();
                    break;
            }
        }

        #region FUNCION CALCULAR DEUDORES DE INFORME
        protected void Desplegar_DEUDORES_INFORME()
        {
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            VT_Observacion obs = new VT_Observacion();
            DataTable dt = new DataTable();
            DataTable dts = new DataTable();
            DataTable d = new DataTable();
            d = sol.DB_Desplegar_SOLICITUD_USUARIO("0", "APROBADO", "CONTAR_APROBADOS");
            dt = sol.DB_Desplegar_SOLICITUD_USUARIO("0", "APROBADO", "VERINFORME");
            if(dt.Rows.Count > 0)
            {
                int num = 0;
                obs.Observacion = "FECHA LIMITE 8 Días";
                obs.Tipo = "Solicitud";
                string valor = "";
                for (int i = 0; i < Convert.ToInt32(d.Rows[0][0].ToString()); i++)
                {
                    valor = dt.Rows[i][0].ToString();
                    //lrojas 30may2017: se comento ya que el calculo de dias habiles sin sabados y domingos lo realiza el 
                    //SP que se llama en /*sol.DB_Reporte_SOLICITUD_US(valor, "DIAS_SIN_INFORME");*/

                    /*dts = sol.DB_Reporte_SOLICITUD_US(valor, "FECHA_RETORNO");
                    if (dts.Rows.Count == 0)//lrojas: 10/10/2016 validacion si no exite retorno en registro, continue
                        continue;
                    DateTime date = Convert.ToDateTime(dts.Rows[0][0].ToString());                    
                    string resultado = String.Format("{0:dddd}", Convert.ToDateTime(dts.Rows[0][0].ToString()));                    
                    if (resultado == "lunes" || resultado == "martes" || resultado == "miércoles")
                    {
                        num = 2;
                    }
                    else
                    {
                        if (resultado == "jueves" || resultado == "viernes" || resultado == "sábado")
                        {
                            num = 4;
                        }
                        else
                        {
                            num = 3;
                        }
                    }

                    dts = sol.DB_Reporte_SOLICITUD_US(dt.Rows[i][0].ToString(), "DIAS_SIN_INFORME");
                    int aux = Convert.ToInt32(dts.Rows[0][0].ToString()) - num;
                    */
                    dts = sol.DB_Reporte_SOLICITUD_US(valor, "DIAS_SIN_INFORME");
                    int aux = Convert.ToInt32(dts.Rows[0][0].ToString());

                    if (aux >= 8 && dt.Rows[i][6].ToString() == "APROBADO")
                    {
                        sol.DB_Cambiar_ESTADO(dt.Rows[i][0].ToString(), "OBSERVADO");
                        obs.Id_Solicitud = dt.Rows[i][0].ToString();
                        sol.DB_Registrar_OBSERVACION_SOLICITUD(obs);
                    }
                }
            }
            else
            {

            }
           
            Desplegar_DEUDOR_INFORME();
            GVListSolicit.DataBind();
        }
        #endregion

        protected void GVListSolicit_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Desplegar_DEUDORES_INFORME();
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
                if (aux >= 8 && estado == "APROBADO")
                {
                    sol.DB_Cambiar_ESTADO(idsol, "OBSERVADO"); 
                    //sol.DB_Registrar_OBSERVACION_SOLICITUD(obs);
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

        protected void GVListSolicitud_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVListSolicitud.PageIndex = e.NewPageIndex;
            Desplegar_SOLICITUD_USUARIO();
        }

        protected void GVListSolicit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVListSolicit.PageIndex = e.NewPageIndex;
            Desplegar_DEUDOR_INFORME();
        }
    }
}