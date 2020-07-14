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
using DataEntity.DE_General;
using DataBusiness.DB_General;
using DataEntity.DE_Viaticos;
using DataBusiness.DB_Registro;

namespace WebAplication.Viaticos
{
    public partial class frmListaSolicitResp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //LblIdUser.Text = Session["IdUser"].ToString();
                    Desplegar_SOLICITUD_USUARIO();
                    Desplegar_SEGUIMIENTO_SOLICITUD();
                    Desplegar_SOLICITUD_USUARIO_FIN();
                }
            }
            catch(Exception ex)
            {
                //Response.Redirect("~/About.aspx");
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Desplegar_SEGUIMIENTO_SOLICITUD()
        {
            DB_AdminUser User = new DB_AdminUser();
            DataTable dt = User.DB_Desplegar_USUARIO(Session["IdUser"].ToString());
            DB_VT_Viaticos List = new DB_VT_Viaticos();
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            GVListSegSolicit.DataSource = lista.DB_Desplegar_SOLICITUD_USUARIO(dt.Rows[0][10].ToString(), "INF-ENVIADO", "APROBADOR");
            GVListSegSolicit.DataBind();
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Desplegar_SOLICITUD_USUARIO()
        {
            DB_AdminUser User = new DB_AdminUser();
            DataTable dt = User.DB_Desplegar_USUARIO(Session["IdUser"].ToString());
            DB_VT_Viaticos List = new DB_VT_Viaticos();
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            GVListSolicitud.DataSource = lista.DB_Desplegar_SOLICITUD_USUARIO(dt.Rows[0][10].ToString(), "ENVIADO", "APROBADOR");
            GVListSolicitud.DataBind();
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Desplegar_SOLICITUD_USUARIO_FIN()
        {
            DB_AdminUser User = new DB_AdminUser();
            DataTable dt = User.DB_Desplegar_USUARIO(Session["IdUser"].ToString());
            DB_VT_Viaticos List = new DB_VT_Viaticos();
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            GVListSegSolicitFin.DataSource = lista.DB_Desplegar_SOLICITUD_USUARIO(dt.Rows[0][10].ToString(), "", "HISTORIAL_APROBADOS");
            GVListSegSolicitFin.DataBind();
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void GVListSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {  
                string tipo = Convert.ToString(e.CommandName);
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Session.Add("IdSolicitud", GVListSolicitud.Rows[rowIndex].Cells[0].Text);
                switch (tipo)
                {
                    case "DarCurso":

                        DB_VT_Solicitud s = new DB_VT_Solicitud();
                        DataTable dt_dh = new DataTable();
                    
                            string Idsolicitud = GVListSolicitud.Rows[rowIndex].Cells[0].Text;
                            string id_user = GVListSolicitud.Rows[rowIndex].Cells[9].Text;
                                                     
                            Desplegar_SEGUIMIENTO_SOLICITUD();
                          
                            DB_AdminUser User = new DB_AdminUser();
                            DataTable dt = User.DB_Desplegar_USUARIO(Session["IdUser"].ToString());
                            string Regional = dt.Rows[0][5].ToString();
                          
                            DB_VT_Solicitud lista = new DB_VT_Solicitud();
                            DataTable DTSolicitud = lista.DB_Desplegar_SOLICITUD_USUARIO("0", Regional, "PROCESAR");
                          
                                Cargar_PLANILLA(id_user, Idsolicitud);//se agrego metodo en formulario
                                s.DB_Cambiar_ESTADO(Idsolicitud, "APROBADO");
                                
                                Desplegar_SOLICITUD_USUARIO();
                                Desplegar_SOLICITUD_USUARIO_FIN();
                                
                        break;
                    case "Ver":
                        Session.Add("IdSolicitud", GVListSolicitud.Rows[rowIndex].Cells[0].Text);
                        StringBuilder sbMensaje = new StringBuilder();
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repSolicitud.aspx?ci=" + GVListSolicitud.Rows[rowIndex].Cells[0].Text);
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                        break;
                }
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        #endregion
        #region PROCESAR LA PLANILLA DE PAGO
        protected void Cargar_PLANILLA(string idUser, string idSolicitud)
        {            
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
            decimal incrementoMontoUrbano = 0;
            decimal incrementoMontoRural = 0;

            p.Id_Solicitud = idSolicitud;
            p.Tot_Num_Dias = 0;
            p.Tot_Num_Dias15 = 0;
            p.Pago_Total = 0;
            p.Pago_Total15 = 0;
            p.Rc_Iva = 0; /*********************************************************** OJO AQUI HAY QUE PONER LOS PARAMETROS DE GESTION ******/
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

            dt2 = cat.DB_Seleccionar_CATEGORIA(Convert.ToInt32(dt1.Rows[0][11].ToString()), dt.Rows[0][3].ToString());  //ID_CATEGORIA , INTERIOR  -> Sale Montos
            //------------------------------JLAH
            sd1 = s1.DB_Seleccionar_SOLICITUD_DESTINO(idSolicitud, 1);  //para obtener la fecha de salida.
            DateTime fechaCambio = new DateTime(2019, 9, 11,0,0,1);
            if (sd1.Fecha_Salida >= fechaCambio)
            { switch (dt1.Rows[0][11].ToString())
                {
                    case "3": incrementoMontoUrbano = 91;
                        incrementoMontoRural = 54;
                        break;
                    case "4":
                        incrementoMontoUrbano = 40;
                        incrementoMontoRural = 24;
                        break;
                    case "5":
                        incrementoMontoUrbano = 30;
                        incrementoMontoRural = 18;
                        break;
                    case "6":
                        incrementoMontoUrbano = 91;
                        incrementoMontoRural = 29;
                        break;
                }
            }

            /***************************************************************/
            //DB_VT_Solicitud sol = new DB_VT_Solicitud();
            int contador = 1;
            int auxiliar = 0;
            for (int i = 1; i <= (numero); i++)
            {
                sd1 = s1.DB_Seleccionar_SOLICITUD_DESTINO(idSolicitud, i);
                sd2 = s1.DB_Seleccionar_SOLICITUD_DESTINO(idSolicitud, (i + 1));
                int dias = sol.DB_NumDHM(Convert.ToDateTime(sd1.Fecha_Salida.ToString()), Convert.ToDateTime(sd2.Fecha_Salida.ToString()), "DD");
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
                            pd.Monto = contdias * (Convert.ToDecimal(dt2.Rows[0][3].ToString()) + incrementoMontoUrbano);
                        }
                        else
                        {
                            //pd.Area = "Departamental";//Al interior del Departamento
                            pd.Area = "Al interior del Departamento";
                            pd.Monto = contdias * (Convert.ToDecimal(dt2.Rows[0][4].ToString()) + incrementoMontoRural);
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
                        contdias =  s1.DB_NumDHM(sd1.Fecha_Salida, sd2.Fecha_Salida, "DD");
                        for (int j = 0; j < contdias; j++)
                        {
                            pd.Id_Planilla = idplani;
                            pd.Cont = contador;
                            pd.Num_Dias = 1;
                            if (sd1.Zona == "Interdepartamental")
                            {
                                pd.Area = "Interdepartamental";
                                pd.Monto = 1 * (Convert.ToDecimal(dt2.Rows[0][3].ToString()) + incrementoMontoUrbano);
                            }
                            else
                            {
                                pd.Area = "Al interior del Departamento";
                                pd.Monto = 1 * (Convert.ToDecimal(dt2.Rows[0][4].ToString()) + incrementoMontoRural);
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
                                pd.Monto = contdias * (Convert.ToDecimal(dt2.Rows[0][3].ToString()) + incrementoMontoUrbano);
                            }
                            else
                            {
                                pd.Area = "Al interior del Departamento";
                                pd.Monto = contdias * (Convert.ToDecimal(dt2.Rows[0][4].ToString()) + incrementoMontoRural);
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
                                pd.Monto = contdias * (Convert.ToDecimal(dt2.Rows[0][3].ToString()) + incrementoMontoUrbano);
                            }
                            else
                            {
                                pd.Area = "Al interior del Departamento";
                                pd.Monto = contdias * (Convert.ToDecimal(dt2.Rows[0][4].ToString()) + incrementoMontoRural);
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
        protected void GVListSegSolicit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            StringBuilder sbMensaje = new StringBuilder();
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Session.Add("IdSolicitud", GVListSegSolicit.Rows[rowIndex].Cells[0].Text);
            switch (tipo)
            {
                case "Solicitud":
                    Session.Add("IdSolicitud", GVListSegSolicit.Rows[rowIndex].Cells[0].Text);
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repSolicitud.aspx?ci=" + GVListSegSolicit.Rows[rowIndex].Cells[0].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "Informe":
                    Session.Add("IdSolicitud", GVListSegSolicit.Rows[rowIndex].Cells[0].Text);
                    if (GVListSegSolicit.Rows[rowIndex].Cells[8].Text == "INF-ENVIADO" || GVListSegSolicit.Rows[rowIndex].Cells[8].Text == "INF-APROBADO" || GVListSegSolicit.Rows[rowIndex].Cells[8].Text == "FINALIZADO")
                    {
                       sbMensaje.Append("<script type='text/javascript'>");
                       sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repInforme.aspx?ci=" + GVListSegSolicit.Rows[rowIndex].Cells[0].Text);
                       sbMensaje.Append("</script>");
                       ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    }
                    else
                    {
                        Response.Write("<script>window.alert('No realiso informe o fue obserbado');</script>");
                    }
                    break;
                case "Aprobar":
                    if (GVListSegSolicit.Rows[rowIndex].Cells[8].Text == "INF-ENVIADO")
                    {
                        DB_VT_Solicitud s = new DB_VT_Solicitud();
                        s.DB_Cambiar_ESTADO(GVListSegSolicit.Rows[rowIndex].Cells[0].Text, "INF-APROBADO");
                        Desplegar_SOLICITUD_USUARIO();
                        Desplegar_SEGUIMIENTO_SOLICITUD();
                    }
                    else
                    {
                        Response.Write("<script>window.alert('El informe debe estar en estado ENVIADO.');</script>");
                    }
                    break;
            }
        }

        protected void GVListSolicitud_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVListSolicitud.PageIndex = e.NewPageIndex;
            Desplegar_SOLICITUD_USUARIO();
            GVListSolicitud.DataBind();
        }
        protected void GVListSegSolicit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVListSegSolicit.PageIndex = e.NewPageIndex;
            Desplegar_SEGUIMIENTO_SOLICITUD();
            GVListSegSolicit.DataBind();
        }
        protected void GVListSegSolicitFin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVListSegSolicitFin.PageIndex = e.NewPageIndex;
            Desplegar_SOLICITUD_USUARIO_FIN();
            GVListSegSolicitFin.DataBind();
        }

        protected void GVListSegSolicitFin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            StringBuilder sbMensaje = new StringBuilder();
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Session.Add("IdSolicitud", GVListSegSolicitFin.Rows[rowIndex].Cells[0].Text);
            switch (tipo)
            {
                case "Solicitud":
                    Session.Add("IdSolicitud", GVListSegSolicitFin.Rows[rowIndex].Cells[0].Text);
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repSolicitud.aspx?ci=" + GVListSegSolicitFin.Rows[rowIndex].Cells[0].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "Informe":
                    Session.Add("IdSolicitud", GVListSegSolicitFin.Rows[rowIndex].Cells[0].Text);
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repInforme.aspx?ci=" + GVListSegSolicitFin.Rows[rowIndex].Cells[0].Text);
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
            }
        }
    }
}