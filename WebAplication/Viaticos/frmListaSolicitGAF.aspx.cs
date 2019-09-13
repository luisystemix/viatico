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
    public partial class frmListaSolicitGAF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            LblMsg.Text = string.Empty;
                if (!IsPostBack)
                {
                    Desplegar_REGIONAL();
                    Desplegar_SOLICITUD_USUARIO();
                    Desplegar_SOLICITUD_PROCESADO();
                }
            //}
            //catch 
            //{
            //    Response.Redirect("~/About.aspx");
            //}
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
            Desplegar_SOLICITUD_PROCESADO();
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Desplegar_SOLICITUD_USUARIO()
        {
            //lrojas:10/10/2016 se modifico el SP para que tambien recupere los Registros Procesados
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            GVListSolicitud.DataSource = lista.DB_Desplegar_SOLICITUD_USUARIO("0", DDLRegional.SelectedItem.Text, "PROCESAR");
            GVListSolicitud.DataBind();
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES PROCESADAS
        protected void Desplegar_SOLICITUD_PROCESADO()
        {
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            GVListSolicit.DataSource = lista.DB_Desplegar_SOLICITUD_USUARIO(DDLRegional.SelectedItem.Text, "PROCESADO", "VERINFORME");
            GVListSolicit.DataBind();
        }
        #endregion

        #region FUNCIONES DE LA GRILLA
        protected void GVListSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //string IdSolicitud = GVListSolicitud.Rows[rowIndex].Cells[1].Text;
            object IdSolicitud = GVListSolicitud.DataKeys[rowIndex % GVListSolicitud.PageSize].Value;
            Session.Add("IdSolicitud", IdSolicitud.ToString());
            DB_VT_Solicitud s = new DB_VT_Solicitud();
            StringBuilder sbMensaje = new StringBuilder();
            string EstadoSel = ((DropDownList)GVListSolicitud.Rows[rowIndex].FindControl("DDLEstado")).SelectedItem.Text; //GVListSolicitud.Rows[rowIndex].Cells[8].Text
            switch (tipo)
            {                
                case "Aprobar":
                    #region comentado inicialmente
                    ////string val = ((DropDownList)e.Row.FindControl("DDLEstado")).SelectedItem.Text;                    
                    //string Idsol = GVListSolicitud.Rows[rowIndex].Cells[0].Text;
                    ////if (GVListSolicitud.Rows[rowIndex].Cells[8].Text == "HABILITADO")
                    //if (EstadoSel == "HABILITADO")
                    //{
                    //    //GVListSolicitud.Columns[9].Visible = true;
                    //    Desplegar_SOLICITUD_USUARIO();
                    //    Cargar_PLANILLA(GVListSolicitud.Rows[rowIndex].Cells[9].Text, GVListSolicitud.Rows[rowIndex].Cells[0].Text);
                    //    s.DB_Cambiar_ESTADO(GVListSolicitud.Rows[rowIndex].Cells[0].Text, "APROBADO");
                    //    //GVListSolicitud.Columns[9].Visible = false;
                    //    Desplegar_SOLICITUD_USUARIO();
                    //    LblMsg.Text = string.Empty;
                    //}
                    //else
                    //{
                    //    //LblMsg.Text = "La solicitud esta en estado de: " + GVListSolicitud.Rows[rowIndex].Cells[8].Text + " No se puede continuar.";
                    //    LblMsg.Text = "La solicitud " + Idsol.ToUpper() + " esta en estado de: " + EstadoSel.ToUpper() + " No se puede continuar.";
                    //}
                    //*ini* lrojas: actualiza el estado
                    #endregion
                    //s.DB_Cambiar_ESTADO(GVListSolicitud.Rows[rowIndex].Cells[0].Text, EstadoSel);                    
                    s.DB_Cambiar_ESTADO(IdSolicitud.ToString(), EstadoSel);
                    Desplegar_SOLICITUD_USUARIO();
                    Desplegar_SOLICITUD_PROCESADO();
                    LblMsg.Text = string.Empty;
                    //*fin*
                    break;
                case "Observar":
                    //if (GVListSolicitud.Rows[rowIndex].Cells[8].Text == "HABILITADO" || GVListSolicitud.Rows[rowIndex].Cells[8].Text == "ENVIADO")                    
                    if (EstadoSel == "HABILITADO" || EstadoSel == "ENVIADO")
                    {
                        Response.Redirect("frmObservarSolicitud.aspx");
                    }
                    else
                    {
                        LblMsg.Text = "No es posible continuar la solicitud ya fue aprobada.";
                    }
                    break;
                case "Procesar":
                    //if (GVListSolicitud.Rows[rowIndex].Cells[8].Text == "APROBADO" || GVListSolicitud.Rows[rowIndex].Cells[8].Text == "PROCESADO" || GVListSolicitud.Rows[rowIndex].Cells[8].Text == "INF-APROBADO")
                    if (EstadoSel == "APROBADO" || EstadoSel == "PROCESADO" || EstadoSel == "INF-APROBADO")
                    {
                        try//**lrojas: 29/09/2016 validacion usario - cuenta
                        {
                            DB_VT_Solicitud sol = new DB_VT_Solicitud();
                            DataTable data = new DataTable();
                            //data = sol.DB_Reporte_SOLICITUD_US(GVListSolicitud.Rows[rowIndex].Cells[0].Text, "ENCABEZADO");
                            data = sol.DB_Reporte_SOLICITUD_US(IdSolicitud.ToString(), "ENCABEZADO");
                            LblIdUser.Text = data.Rows[0][1].ToString();
                            DB_VT_Planilla pl = new DB_VT_Planilla();
                            pl.DB_Seleccionar_CUENTA(LblIdUser.Text);
                        }
                        catch(Exception ex)
                        {
                            LblMsg.Text = ex.Message;
                            //string scriptf = @"<script type='text/javascript'>alert('{0}');</script>";
                            //scriptf = string.Format(scriptf, ex.Message);
                            //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", scriptf, false);
                            return;                                 
                        }
                        Response.Redirect("frmPlanillaPago.aspx");
                    }
                    else
                    {
                        LblMsg.Text = "No se puede procesar la Solicitud NO esta aprobado";
                    }
                    break;
                case "Solicitud":
                    sbMensaje.Append("<script type='text/javascript'>");
                    //sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repSolicitud.aspx?ci=" + GVListSolicitud.Rows[rowIndex].Cells[0].Text);
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repSolicitud.aspx?ci=" + IdSolicitud);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "Memo":
                    sbMensaje.Append("<script type='text/javascript'>");
                    //sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repMemo.aspx?ci=" + GVListSolicitud.Rows[rowIndex].Cells[0].Text);
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repMemo.aspx?ci=" + IdSolicitud);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "Informe":
                    //if (GVListSolicitud.Rows[rowIndex].Cells[8].Text == "INF-APROBADO")
                    if (EstadoSel == "INF-APROBADO")
                    {
                        sbMensaje.Append("<script type='text/javascript'>");
                        //sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repInforme.aspx?ci=" + GVListSolicitud.Rows[rowIndex].Cells[0].Text);
                        sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repInforme.aspx?ci=" + IdSolicitud);
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
        #endregion
        #region PROCESAR LA PLANILLA DE PAGO
        protected void Cargar_PLANILLA(string idUser, string idSolicitud)
        {
            string lugar="";
            DB_VT_Planilla regP = new DB_VT_Planilla();
            VT_Planilla p = new VT_Planilla();
            VT_PlanillaDia pd = new VT_PlanillaDia();
            VT_SolicitudDestino sd1 = new VT_SolicitudDestino();
            VT_SolicitudDestino sd2 = new VT_SolicitudDestino();
            DB_VT_Solicitud s1 = new DB_VT_Solicitud();
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            int numero = s1.DB_Numero_Filas_SOLICITUD(idSolicitud);// se modifico query con  'cont>0'
            decimal contdias = Convert.ToDecimal("0");
            p.Id_Solicitud = idSolicitud;
            p.Tot_Num_Dias = 0;
            p.Tot_Num_Dias15 = 0;
            p.Pago_Total = 0;
            p.Pago_Total15 = 0;
            p.Rc_Iva = 13; /*********************************************************** OJO AQUI HAY QUE PONER LOS PARAMETROS DE GESTION ******/
            p.Liquido_Pagable = 0;
            p.Num_Cheque = "0";
            p.Tasa_Cambio = 0;
            p.Fecha = DateTime.Now;
            p.Fecha_Atendido = DateTime.Now;
            p.MontoPorDia = 1;
            regP.DB_Registrar_PLANILLA(p);
            int idplani = Convert.ToInt32(aux.DB_MaxId("VIAT_PLANILLA", "Id_Planilla"));
            /**************************************************************/
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            dt = sol.DB_Seleccionar_SOLICITUD(idSolicitud);
            /************************************************************/
            DB_AdminUser us = new DB_AdminUser();
            dt1 = us.DB_Desplegar_USUARIO(idUser);
            /******************************************************/
            DB_VT_Categoria cat = new DB_VT_Categoria();
            string aux1 = dt1.Rows[0][11].ToString();
            string aux2 = dt.Rows[0][3].ToString();
            dt2 = cat.DB_Seleccionar_CATEGORIA(Convert.ToInt32(dt1.Rows[0][11].ToString()), dt.Rows[0][3].ToString());
            /***************************************************************/
            //DB_VT_Solicitud sol = new DB_VT_Solicitud();
            int contador = 1;
            int auxiliar = 0;
            for (int i = 1; i <= (numero); i++)
            {
                sd1 = s1.DB_Seleccionar_SOLICITUD_DESTINO(idSolicitud, i);
                sd2 = s1.DB_Seleccionar_SOLICITUD_DESTINO(idSolicitud, (i + 1));
                int dias = sol.DB_NumDHM(Convert.ToDateTime(sd1.Fecha_Salida.ToString()), Convert.ToDateTime(sd2.Fecha_Salida.ToString()),"DD");
                if (sd1.Fecha_Salida.ToString("dd/MM/yyyy") == sd2.Fecha_Salida.ToString("dd/MM/yyyy"))
                {
                    if (numero == 2)
                    {
                        contdias = Convert.ToDecimal("0.5");
                        pd.Id_Planilla = idplani;
                        pd.Cont = contador;
                        pd.Num_Dias = contdias;
                        if (sd1.Zona == "Interdepartamental")
                        {
                            pd.Area = "Interdepartamental";
                            pd.Monto = contdias * Convert.ToDecimal(dt2.Rows[0][3].ToString());
                        }
                        else
                        {
                            pd.Area = "Al interior del Departamento";
                            pd.Monto = contdias * Convert.ToDecimal(dt2.Rows[0][4].ToString());
                        }
                        pd.Destino = sd1.Destino + " " + sd1.Lugar;
                        pd.Observacion = "SIN PERNOCTE";
                        pd.FechaDia = sd1.Fecha_Salida;
                        regP.DB_Registrar_PLANILLADIA(pd);
                        contador++;
                        break;
                    }
                    else 
                    {
                        pd.Destino = sd1.Destino + " " + sd1.Lugar;
                    }
                }
                else
                {
                    if (sd1.Tramo == "Salida")
                    {
                        contdias = s1.DB_NumDHM(sd1.Fecha_Salida, sd2.Fecha_Salida, "DD");
                        for (int j = 0; j < contdias; j++)
                        {
                                pd.Id_Planilla = idplani;
                                pd.Cont = contador;
                                pd.Num_Dias = 1;
                                if (sd1.Zona == "Interdepartamental")
                                {
                                    pd.Area = "Interdepartamental";
                                    pd.Monto = 1 * Convert.ToDecimal(dt2.Rows[0][3].ToString());
                                }
                                else
                                {
                                    pd.Area = "Al interior del Departamento";
                                    pd.Monto = 1 * Convert.ToDecimal(dt2.Rows[0][4].ToString());
                                }
                            pd.Destino = sd1.Destino + " " + sd1.Lugar;
                            pd.Observacion = "CON PERNOCTE";
                            pd.FechaDia = sd1.Fecha_Salida.AddDays(j);
                            regP.DB_Registrar_PLANILLADIA(pd);
                            auxiliar = j;
                            contador++;
                        }
                    }
                    else
                    {
                        contdias = s1.DB_NumDHM(Convert.ToDateTime(sd1.Fecha_Salida.ToString("dd/MM/yyyy") + " " + "08:00:00"), sd1.Fecha_Salida, "HH");
                        if (contdias > 4) /*************************************** OJO aqui calculamos por hora mayor a 4 horas se contabiliza como medio dia*/
                        {
                            contdias = Convert.ToDecimal("0.5");
                            pd.Id_Planilla = idplani;
                            pd.Cont = contador;
                            pd.Num_Dias = contdias;
                            if (sd1.Zona == "Interdepartamental")
                            {
                                pd.Area = "Interdepartamental";
                                pd.Monto = contdias * Convert.ToDecimal(dt2.Rows[0][3].ToString());
                            }
                            else
                            {
                                pd.Area = "Al interior del Departamento";
                                pd.Monto = contdias * Convert.ToDecimal(dt2.Rows[0][4].ToString());
                            }
                            pd.Destino = sd1.Destino + " " + sd1.Lugar;
                            pd.Observacion = "SIN PERNOCTE";
                            pd.FechaDia = sd1.Fecha_Salida.AddDays(0);
                            regP.DB_Registrar_PLANILLADIA(pd);
                            contador++;
                        }
                        else 
                        {
                            contdias = Convert.ToDecimal("0.0");
                            pd.Id_Planilla = idplani;
                            pd.Cont = contador;
                            pd.Num_Dias = contdias;
                            if (sd1.Zona == "Interdepartamental")
                            {
                                pd.Area = "Interdepartamental";
                                pd.Monto = contdias * Convert.ToDecimal(dt2.Rows[0][3].ToString());
                            }
                            else
                            {
                                pd.Area = "Al interior del Departamento";
                                pd.Monto = contdias * Convert.ToDecimal(dt2.Rows[0][4].ToString());
                            }
                            pd.Destino = sd1.Destino + " " + sd1.Lugar;
                            pd.Observacion = "No se cumplió el periodo de 4 horas que se considera como  medio día de viatico";
                            pd.FechaDia = sd1.Fecha_Salida.AddDays(0);
                            regP.DB_Registrar_PLANILLADIA(pd);
                            contador++;
                        }
                    }
                }
            }
        }
        #endregion

        protected void GVListSolicit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            try
            {
                object IdSolicitud = GVListSolicit.DataKeys[rowIndex % GVListSolicit.PageSize].Value;
                Session.Add("IdSolicitud", IdSolicitud.ToString());
                DB_VT_Solicitud s = new DB_VT_Solicitud();
                StringBuilder sbMensaje = new StringBuilder();
                switch (tipo)
                {
                    case "Solicitud":
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repSolicitud.aspx?ci=" + GVListSolicit.Rows[rowIndex].Cells[1].Text);
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                        break;
                    case "Memo":
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repMemo.aspx?ci=" + GVListSolicit.Rows[rowIndex].Cells[1].Text);
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                        break;
                    case "Planilla":
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repPlanillaPago.aspx?ci=" + GVListSolicit.Rows[rowIndex].Cells[0].Text);
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                        break;
                    case "Informe":
                        if (GVListSolicit.Rows[rowIndex].Cells[8].Text == "PROCESADO")
                        {
                            sbMensaje.Append("<script type='text/javascript'>");
                            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repInforme.aspx?ci=" + GVListSolicit.Rows[rowIndex].Cells[0].Text);
                            sbMensaje.Append("</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                        }
                        else
                        {
                            Response.Write("<script>window.alert('El Informe No se envió e No se Aprobó por el inmediato superior');</script>");
                        }
                        break;
                    case "Finalizar":
                        s.DB_Cambiar_ESTADO(GVListSolicit.Rows[rowIndex].Cells[0].Text, "FINALIZADO");
                        Desplegar_SOLICITUD_PROCESADO();
                        LblMsg.Text = string.Empty;
                        break;
                }
            }
            catch
            {

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
                string Estado = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Estado"));
                ((DropDownList)e.Row.FindControl("DDLEstado")).SelectedValue = Estado;
                //((DropDownList)e.Row.FindControl("DDLEstado")).DataBind();
                //**
                if(dt.Rows.Count > 0)
                {
                  ((Label)e.Row.FindControl("LblObs")).Text = dt.Rows[0][0].ToString();                                      
                }
                //------------------------------------------------------------------------------------------------------------------------
                //var lnkProcesar = ((LinkButton)e.Row.FindControl("lnkProcesar"));
                var lnkProcesar = ((LinkButton)e.Row.FindControl("lnkProcesar"));
                
                var ddlEstado = ((DropDownList)e.Row.FindControl("DDLEstado"));
                //if(ddlEstado.Text == "APROBADO" || ddlEstado.Text == "PROCESADO" || ddlEstado.Text == "INF-APROBADO")
                //{
                //if (lnkProcesar != null)
                //{
                    
                //    if (Estado == "APROBADO" || Estado == "INF-APROBADO")
                //    {

                        lnkProcesar.Enabled = true;
                    //}                    
                    //else
                    //{
                    //    lnkProcesar.Enabled = false;
                    //    lnkProcesar.ToolTip = "No puede generar la planilla el estado no es: Aprobado, Procesado ó Inf-Aprobado.";
                    //}
                //}
                //------------------------------------------------------------------------------------------------------------------------
            }
        }

        protected void GVListSolicit_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void GVListSolicitud_PreRender(object sender, EventArgs e)
        {
            if (GVListSolicitud.Rows.Count > 0)
            {
                GVListSolicitud.UseAccessibleHeader = true;
                GVListSolicitud.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GVListSolicit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVListSolicit.PageIndex = e.NewPageIndex;
            Desplegar_SOLICITUD_PROCESADO();
        }

        protected void GVListSolicitud_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVListSolicitud.PageIndex = e.NewPageIndex;
            Desplegar_SOLICITUD_USUARIO();
        }
    }
}