using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Viaticos;
using DataEntity.DE_Viaticos;
using System.Text;

namespace WebAplication.Viaticos
{
    public partial class frmModificarSolicitud : System.Web.UI.Page
    {
        string sw = "SI";
        private string P_IdSolicitud
        {
            get
            {
                if (ViewState["P_IdSolicitud"] != null)
                    return (string)ViewState["P_IdSolicitud"];

                return string.Empty;
            }
            set { ViewState["P_IdSolicitud"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //*ini* lrojas:31/08/2016 validacion con retorno de "frmRealizarSolicitud_AddRow"
                    P_IdSolicitud = Convert.ToString(Request.QueryString["IdSolicitud"]);
                    if (P_IdSolicitud == string.Empty)
                        LblIdSolicitud.Text = Session["IdSolicitud"].ToString();
                    else
                        LblIdSolicitud.Text = P_IdSolicitud;
                    //*fin*
                    Desplegar_SOLICITUD_DESTINOS();
                    Seleccionar_SOLICITUD();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region OBTENER DATOS DE LA SOLICITID POR EL ID
        protected void Seleccionar_SOLICITUD()
        {
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            DataTable dt = new DataTable();
            dt = sol.DB_Reporte_SOLICITUD_US(LblIdSolicitud.Text, "ENCABEZADO");
            LblFechaEnvio.Text = dt.Rows[0][5].ToString();
            TxtMotiv.Text = dt.Rows[0][7].ToString();
            LblEstado.Text = dt.Rows[0][10].ToString();
            string aux = "";
            string tipoViaje = dt.Rows[0][9].ToString();
            aux = tipoViaje == "POA" ? "PROGRAMADO EN EL POA" : "DE EMERGENCIA";            
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Desplegar_SOLICITUD_DESTINOS()
        {
            //*ini* lrojas:31/08/2016 Si tiene retorno P_IdSolicitud!="" se agrego filas y debe reordenarse "Cont".
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            if (P_IdSolicitud != string.Empty)
            {               
                DataTable DT_Sol_Des = new DataTable();
                List<VT_SolicitudDestino> ColSD = new List<VT_SolicitudDestino>();
                DT_Sol_Des = lista.DB_Desplegar_SOLICITUD_DESTINOS(LblIdSolicitud.Text);
                foreach (DataRow r in DT_Sol_Des.Rows)
                {
                    //if (r["Tramo"].ToString() == "Salida")
                    //{
                        VT_SolicitudDestino ObjSD = new VT_SolicitudDestino();
                        ObjSD.Tramo = r["Tramo"].ToString();
                        ObjSD.Zona = r["Zona"].ToString();
                        ObjSD.Destino = r["Destino"].ToString();
                        ObjSD.Lugar = r["Lugar"].ToString();
                        ObjSD.Objetivo = r["Objetivo"].ToString();
                        ObjSD.Fecha_Salida = Convert.ToDateTime(r["Fecha_Salida"].ToString());
                        ObjSD.Via_Transporte = r["Via_Transporte"].ToString();
                        ObjSD.Tipo_Transporte = r["Tipo_Transporte"].ToString();
                        ObjSD.Nombre_Transporte = r["Nombre_Transporte"].ToString();
                        ObjSD.Identificador_Trasporte = r["Identificador_Trasporte"].ToString();
                        ObjSD.Cont = Convert.ToInt32(r["Cont"].ToString());
                        ColSD.Add(ObjSD);
                    //}

                }
                List<VT_SolicitudDestino> ColSDSalidas = new List<VT_SolicitudDestino>();
                List<VT_SolicitudDestino> ColSDRetorno = new List<VT_SolicitudDestino>();
                List<VT_SolicitudDestino> ColSDFinal = new List<VT_SolicitudDestino>();
                ColSDSalidas = ColSD.Where(x => x.Tramo == "Salida").ToList().OrderBy(ord=>ord.Fecha_Salida).ToList();
                ColSDRetorno = ColSD.Where(x => x.Tramo == "Retorno").ToList().OrderBy(ord => ord.Fecha_Salida).ToList();
                foreach(VT_SolicitudDestino ObjSD_Salidas in ColSDSalidas)
                {
                    ColSDFinal.Add(ObjSD_Salidas);
                }
                foreach (VT_SolicitudDestino ObjSD_Retorno in ColSDRetorno)
                {
                    ColSDFinal.Add(ObjSD_Retorno);
                }

                GVSolicitud.DataSource = ColSDFinal; //ColSD.OrderBy(x => x.Fecha_Salida).ToList();
                GVSolicitud.DataBind();
                
                int numero = lista.DB_Numero_Filas_SOLICITUD(LblIdSolicitud.Text);// se modifico query con  'cont>0'
                int Aux_Cont = 1;
                foreach (GridViewRow dgi in GVSolicitud.Rows)
                {
                    //int Cont = Convert.ToInt32(GVSolicitud.Rows[dgi.RowIndex].Cells[0].Text);
                    int Cont = Convert.ToInt32(GVSolicitud.DataKeys[dgi.RowIndex].Values[0]);
                    if (Cont > 0)
                    {
                        VT_SolicitudDestino ObjSD = new VT_SolicitudDestino();
                        DropDownList ddlZona = (DropDownList)dgi.Cells[3].Controls[1];
                        DropDownList ddlDestino = (DropDownList)dgi.Cells[4].Controls[1];
                        TextBox txLugar = (TextBox)dgi.Cells[5].Controls[1];
                        TextBox tx1Objetivo = (TextBox)dgi.Cells[6].Controls[1];
                        TextBox tx2 = (TextBox)dgi.Cells[7].Controls[1];
                        DropDownList ddlH = (DropDownList)dgi.Cells[8].Controls[1];
                        DropDownList ddlM = (DropDownList)dgi.Cells[9].Controls[1];
                        //TextBox tx2A = (TextBox)dgi.Cells[7].Controls[1];
                        DropDownList ddlVia_Transporte = (DropDownList)dgi.Cells[10].Controls[1];
                        DropDownList ddlTipo_Transporte = (DropDownList)dgi.Cells[11].Controls[1];
                        TextBox txNombre_Transporte = (TextBox)dgi.Cells[12].Controls[1];
                        TextBox txIdentificador_Trasporte = (TextBox)dgi.Cells[13].Controls[1];

                        ObjSD.Id_Solicitud = LblIdSolicitud.Text;
                        ObjSD.Cont = Convert.ToInt32(GVSolicitud.DataKeys[dgi.RowIndex].Values[0]);
                        ObjSD.Tramo = dgi.Cells[1].Text;
                        ObjSD.Zona = ddlZona.SelectedValue;
                        ObjSD.Destino = ddlDestino.SelectedValue;
                        ObjSD.Lugar = txLugar.Text;
                        ObjSD.Objetivo = tx1Objetivo.Text;
                        ObjSD.Fecha_Salida = Convert.ToDateTime(tx2.Text + " " + ddlH.SelectedValue + ":" + ddlM.SelectedValue);
                        ObjSD.Via_Transporte = ddlVia_Transporte.SelectedValue;
                        ObjSD.Tipo_Transporte = ddlTipo_Transporte.SelectedValue;
                        ObjSD.Nombre_Transporte = txNombre_Transporte.Text;
                        ObjSD.Identificador_Trasporte = txIdentificador_Trasporte.Text;
                        
                        lista.DB_Modificar_SOLICITUD_DESTINO_CONT(ObjSD, ObjSD.Cont);
                        if (Aux_Cont != numero)
                            Aux_Cont++;
                    }
                }
                
            }
            GVSolicitud.DataSource = lista.DB_Desplegar_SOLICITUD_DESTINOS(LblIdSolicitud.Text);
            GVSolicitud.DataBind(); 
        }
        #endregion
        #region FUNCIONES DE LA GRILLA
        protected void GVSolicitud_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //**lrojas:29/08/2016
                //fila deshabilitada y de color si fue eliminada
                int cont = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Cont"));
                if (cont == 0)
                {
                    e.Row.BackColor = System.Drawing.Color.DarkGray;
                    e.Row.Enabled = false;
                }
                //**
                string motivo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Lugar"));
                string zona = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Zona"));
                string destino = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Destino"));
                string objetivo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Objetivo"));
                string fecha = (Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Fecha_Salida"))).ToString("dd/MM/yyyy");
                //string hora = (Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Fecha_Salida"))).ToString("HH:mm");
                string hora = (Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Fecha_Salida"))).ToString("HH");
                string min = (Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Fecha_Salida"))).ToString("mm");
                string viatrans = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Via_Transporte"));
                string tiptrans = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Tipo_Transporte"));
                string nomtrans = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Nombre_Transporte"));
                string identifi = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Identificador_Trasporte"));
                string tramo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Tramo"));

                LinkButton lnkEliminar = e.Row.FindControl("lnkEliminar") as LinkButton;

                ((DropDownList)e.Row.FindControl("DDLZona")).Items.Insert(0, new ListItem(zona, zona, true));
                ((DropDownList)e.Row.FindControl("DDLZona")).DataBind();
                ((DropDownList)e.Row.FindControl("DDLDestino")).Items.Insert(0, new ListItem(destino, destino, true));
                ((DropDownList)e.Row.FindControl("DDLDestino")).DataBind();
                ((TextBox)e.Row.FindControl("TxtFecha")).Text = fecha;
                ((DropDownList)e.Row.FindControl("DDLHora")).Items.Insert(0, new ListItem(hora, hora, true));
                ((DropDownList)e.Row.FindControl("DDLMinuto")).Items.Insert(0, new ListItem(min, min, true));
                ((DropDownList)e.Row.FindControl("DDLViaTrans")).Items.Insert(0, new ListItem(viatrans, viatrans, true));
                ((DropDownList)e.Row.FindControl("DDLViaTrans")).DataBind();
                ((DropDownList)e.Row.FindControl("DDLTipoTrans")).Items.Insert(0, new ListItem(tiptrans, tiptrans, true));
                ((DropDownList)e.Row.FindControl("DDLTipoTrans")).DataBind();
                ((TextBox)e.Row.FindControl("TxtNomTrans")).Text = nomtrans;
                ((TextBox)e.Row.FindControl("TxtIdentifi")).Text = identifi;

                DB_VT_Solicitud lista = new DB_VT_Solicitud();
                //lnkEliminar.Visible = tramo == "Salida" && this.GVSolicitud.Rows.Count >= 1 ? true : false;
                int nroFilas= lista.DB_Desplegar_SOLICITUD_DESTINOS(LblIdSolicitud.Text).Rows.Count;
                if (tramo == "Salida")
                {
                    ((TextBox)e.Row.FindControl("TxtObjetivo")).Text = objetivo;
                    ((TextBox)e.Row.FindControl("TxtMotivo")).Text = motivo;
                    lnkEliminar.Visible = nroFilas > 1 ? true:false;                    
                }
                else
                {
                    ((DropDownList)e.Row.FindControl("DDLZona")).Enabled = false;
                    ((DropDownList)e.Row.FindControl("DDLDestino")).Enabled = false;
                    ((TextBox)e.Row.FindControl("TxtObjetivo")).Enabled = false;
                    ((TextBox)e.Row.FindControl("TxtMotivo")).Enabled = false;
                    lnkEliminar.Visible = false;
                }
            }
        }
        #endregion
        #region MODIFICAR LA SOLICITUD
        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            try 
            { 
                //*ini*lrojas:05092016 validacion fecha retorno
                DB_VT_Solicitud sol = new DB_VT_Solicitud();            
                List<VT_SolicitudDestino> ColSD = new List<VT_SolicitudDestino>();
                foreach (GridViewRow dgi in GVSolicitud.Rows)
                {
                    VT_SolicitudDestino Objsd = new VT_SolicitudDestino();
                    DropDownList ddlZona = (DropDownList)dgi.Cells[3].Controls[1];
                    DropDownList ddlDestino = (DropDownList)dgi.Cells[4].Controls[1];
                    TextBox txLugar = (TextBox)dgi.Cells[5].Controls[1];
                    TextBox txObjetivo = (TextBox)dgi.Cells[6].Controls[1];
                    TextBox tx2 = (TextBox)dgi.Cells[7].Controls[1];
                    DropDownList ddlHora = (DropDownList)dgi.Cells[8].Controls[1];
                    DropDownList ddlMin = (DropDownList)dgi.Cells[9].Controls[1];
                    DropDownList ddlVia_Transporte = (DropDownList)dgi.Cells[10].Controls[1];
                    DropDownList ddlTipo_Transporte = (DropDownList)dgi.Cells[11].Controls[1];
                    TextBox txNombre_Transporte = (TextBox)dgi.Cells[12].Controls[1];
                    TextBox txIdentificador_Trasporte = (TextBox)dgi.Cells[13].Controls[1];
                    Objsd.Id_Solicitud = LblIdSolicitud.Text;
                    Objsd.Cont = Convert.ToInt32(GVSolicitud.DataKeys[dgi.RowIndex].Values[0]);
                    Objsd.Tramo = dgi.Cells[2].Text;
                    Objsd.Zona = ddlZona.SelectedValue;
                    Objsd.Destino = ddlDestino.SelectedValue;
                    Objsd.Lugar = txLugar.Text;
                    Objsd.Objetivo = txObjetivo.Text;
                    Objsd.Fecha_Salida = Convert.ToDateTime(tx2.Text + " " + ddlHora.SelectedValue + ":" + ddlMin.SelectedValue);
                    Objsd.Via_Transporte = ddlVia_Transporte.SelectedValue;
                    Objsd.Tipo_Transporte = ddlTipo_Transporte.SelectedValue;
                    Objsd.Nombre_Transporte = txNombre_Transporte.Text;
                    Objsd.Identificador_Trasporte = txIdentificador_Trasporte.Text;
                    ColSD.Add(Objsd);
                }

                if (ColSD.Count > 1)
                { DateTime datetime1 = ColSD.Where(x => x.Tramo == "Salida" && x.Cont > 0).ToList().OrderByDescending(ord => ord.Fecha_Salida).ToList().FirstOrDefault().Fecha_Salida;
                    DateTime datetime2 = ColSD.Where(x => x.Tramo == "Retorno").ToList().OrderByDescending(ord => ord.Fecha_Salida).ToList().FirstOrDefault().Fecha_Salida;

                    //TimeSpan ts = datetime2 - datetime1;
                    //int tday = datetime2.Day - datetime1.Day;
                    TimeSpan ts = Convert.ToDateTime(datetime2.ToShortDateString()) - Convert.ToDateTime(datetime1.ToShortDateString());
                    int tday = ts.Days;

                    if (tday < 0)
                    {
                        string scriptf = @"<script type='text/javascript'>alert('{0}');</script>";
                        scriptf = string.Format(scriptf, "Observación en la fecha de Retorno a " + datetime1.ToShortDateString());
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", scriptf, false);
                        return;
                    }
                    int tHour = datetime2.Hour - datetime1.Hour;
                    if (tHour <= 0 && tday <= 0)
                    {
                        string scripth = @"<script type='text/javascript'>alert('{0}');</script>";
                        scripth = string.Format(scripth, "La HORA de Retorno debe ser mayor a " + datetime1.Hour + ":" + datetime1.Minute);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", scripth, false);
                        return;
                    }
                }

                //*fin*

                //DB_VT_Solicitud sol = new DB_VT_Solicitud();
                VT_Solicitud s = new VT_Solicitud();
                VT_SolicitudDestino sd = new VT_SolicitudDestino();
                s.Id_Solicitud = LblIdSolicitud.Text;
                s.Tipo_Viaje = DDLTipViaje.SelectedValue;
                s.Motivo_Viaje = TxtMotiv.Text;
                sol.DB_Modificar_SOLICITUD(s);
                foreach (GridViewRow dgi in GVSolicitud.Rows)
                {
                    DropDownList ddlZona = (DropDownList)dgi.Cells[3].Controls[1];
                    DropDownList ddlDestino = (DropDownList)dgi.Cells[4].Controls[1];
                    TextBox txLugar = (TextBox)dgi.Cells[5].Controls[1];
                    TextBox txObjetivo = (TextBox)dgi.Cells[6].Controls[1];
                    TextBox tx2 = (TextBox)dgi.Cells[7].Controls[1];
                    DropDownList ddlHora = (DropDownList)dgi.Cells[8].Controls[1];
                    DropDownList ddlMin = (DropDownList)dgi.Cells[9].Controls[1];
                    DropDownList ddlVia_Transporte = (DropDownList)dgi.Cells[10].Controls[1];
                    DropDownList ddlTipo_Transporte = (DropDownList)dgi.Cells[11].Controls[1];
                    TextBox txNombre_Transporte = (TextBox)dgi.Cells[12].Controls[1];
                    TextBox txIdentificador_Trasporte = (TextBox)dgi.Cells[13].Controls[1];

                    sd.Id_Solicitud = LblIdSolicitud.Text;
                    sd.Cont = Convert.ToInt32(GVSolicitud.DataKeys[dgi.RowIndex].Values[0]);
                    sd.Zona = ddlZona.SelectedValue;
                    sd.Destino = ddlDestino.SelectedValue;
                    sd.Lugar = txLugar.Text;
                    sd.Objetivo = txObjetivo.Text;
                    sd.Fecha_Salida = Convert.ToDateTime(tx2.Text+" "+ ddlHora.SelectedValue+":"+ ddlMin.SelectedValue);
                    sd.Via_Transporte = ddlVia_Transporte.SelectedValue;
                    sd.Tipo_Transporte = ddlTipo_Transporte.SelectedValue;
                    sd.Nombre_Transporte = txNombre_Transporte.Text;
                    sd.Identificador_Trasporte = txIdentificador_Trasporte.Text;
                    sol.DB_Modificar_SOLICITUD_DESTINO(sd);
                }
                if (LblEstado.Text == "OBSERVADO")
                {
                    sol.DB_Cambiar_ESTADO(LblIdSolicitud.Text, "HABILITADO");
                }
                //sol.DB_Eliminar_OBSERVACION(LblIdSolicitud.Text);
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, "- El registro fué modificado correctamente.");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                //Response.Redirect("frmListaSolicitUs.aspx");
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

        protected void TxtFecha_TextChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow dgi in GVSolicitud.Rows)
            {
                TextBox tx2 = (TextBox)dgi.Cells[7].Controls[1];
                DateTime fecha = Convert.ToDateTime(tx2.Text);
                string tramo = dgi.Cells[2].Text.ToString();
                if(tramo=="Retorno")
                {
                    if (fecha < Convert.ToDateTime(LblFechaEnvio.Text))
                    {
                        Response.Write("<script>window.alert('ERROR la fecha de salida no puede ser menor a la fecha de envió de la solicitud');</script>");
                        sw = "NO";
                        BtnModificar.Enabled = false;
                        break;
                    }
                    else
                    {
                        BtnModificar.Enabled = true;
                    }
                }
                
                if (fecha < Convert.ToDateTime(LblFechaEnvio.Text))
                {
                    Response.Write("<script>window.alert('ERROR la fecha de salida no puede ser menor a la fecha de envió de la solicitud');</script>");
                    sw = "NO";
                    BtnModificar.Enabled = false;
                    break;
                }
                else 
                {
                    BtnModificar.Enabled = true;
                }
            }
        }
        // lrojas:25/08/2016(1) ; 30/08/2016(2)
        protected void GVSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string tipo = Convert.ToString(e.CommandName);
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                string IdSolicitud = LblIdSolicitud.Text;
                //Session.Add("IdSolicitud", GVSolicitud.Rows[rowIndex].Cells[0].Text);
                DB_VT_Solicitud DB_Sol = new DB_VT_Solicitud();
                VT_SolicitudDestino Obj_SD = new VT_SolicitudDestino();
                switch (tipo)
                {
                    case "Delete":
                        string NroReg = Convert.ToString(GVSolicitud.DataKeys[rowIndex].Values[0]);
                        DateTime fechaDelete = DateTime.Now;
                        DB_Sol.DB_DELETE_SOLICITUD_DESTINO(IdSolicitud, NroReg, fechaDelete);
                        DB_VT_Solicitud lista = new DB_VT_Solicitud();
                        VT_SolicitudDestino ObjSD = new VT_SolicitudDestino();                        
                        GVSolicitud.DataSource = lista.DB_Desplegar_SOLICITUD_DESTINOS(LblIdSolicitud.Text);
                        GVSolicitud.DataBind();
                        int numero = lista.DB_Numero_Filas_SOLICITUD(LblIdSolicitud.Text);// se modifico query con  'cont>0'
                        int Aux_Cont = 1;
                        foreach (GridViewRow dgi in GVSolicitud.Rows)
                        {
                            int Cont = Convert.ToInt32(GVSolicitud.DataKeys[rowIndex].Values[0]);                            
                            if (Cont > 0)
                            {
                                DropDownList ddlZona = (DropDownList)dgi.Cells[3].Controls[1];
                                DropDownList ddlDestino = (DropDownList)dgi.Cells[4].Controls[1];
                                TextBox txLugar = (TextBox)dgi.Cells[5].Controls[1];
                                TextBox tx1Objetivo = (TextBox)dgi.Cells[6].Controls[1];
                                TextBox tx2 = (TextBox)dgi.Cells[7].Controls[1];
                                DropDownList ddlHora = (DropDownList)dgi.Cells[8].Controls[1];
                                DropDownList ddlMin = (DropDownList)dgi.Cells[9].Controls[1];
                                DropDownList ddlVia_Transporte = (DropDownList)dgi.Cells[10].Controls[1];
                                DropDownList ddlTipo_Transporte = (DropDownList)dgi.Cells[11].Controls[1];
                                TextBox txNombre_Transporte = (TextBox)dgi.Cells[12].Controls[1];
                                TextBox txIdentificador_Trasporte = (TextBox)dgi.Cells[13].Controls[1];

                                ObjSD.Id_Solicitud = LblIdSolicitud.Text;
                                ObjSD.Cont = Convert.ToInt32(GVSolicitud.DataKeys[rowIndex].Values[0]);
                                ObjSD.Tramo = GVSolicitud.Rows[dgi.RowIndex].Cells[2].Text;
                                ObjSD.Zona = ddlZona.SelectedValue;
                                ObjSD.Destino = ddlDestino.SelectedValue;
                                ObjSD.Lugar = txLugar.Text;
                                ObjSD.Objetivo = tx1Objetivo.Text;
                                ObjSD.Fecha_Salida = Convert.ToDateTime(tx2.Text + " " + ddlHora.SelectedValue + ":" + ddlMin.SelectedValue);
                                ObjSD.Via_Transporte = ddlVia_Transporte.SelectedValue;
                                ObjSD.Tipo_Transporte = ddlTipo_Transporte.SelectedValue;
                                ObjSD.Nombre_Transporte = txNombre_Transporte.Text;
                                ObjSD.Identificador_Trasporte = txIdentificador_Trasporte.Text;
                                lista.DB_Modificar_SOLICITUD_DESTINO_CONT(ObjSD, Aux_Cont);
                                if (Aux_Cont != numero)
                                    Aux_Cont++;
                            }                        
                        }
                        break;
                }
                GVSolicitud.DataSource = DB_Sol.DB_Desplegar_SOLICITUD_DESTINOS(LblIdSolicitud.Text);
                GVSolicitud.DataBind();
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }            
        }

        protected void GVSolicitud_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }    
        }

        protected void BtnNuevaFila_Click(object sender, EventArgs e)
        {
            string IdSolicitud = this.LblIdSolicitud.Text;
            Response.Redirect("frmRealizarSolicitud_AddRow.aspx?IdSolicitud=" + IdSolicitud);
        }
    }
}