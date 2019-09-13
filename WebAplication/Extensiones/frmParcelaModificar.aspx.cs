using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;
using DataBusiness.DB_Extensiones;
using DataBusiness.DB_General;
using DataEntity.DE_Extensiones;

namespace WebAplication.Extensiones
{
    public partial class frmParcelaModificar : System.Web.UI.Page
    {
        /// <summary>
        /// ViewState Id_Productor
        /// </summary>
        private string VS_Id_Productor
        {
            get
            {
                if (ViewState["VS_Id_Productor"] != null)
                    return (string)ViewState["VS_Id_Productor"];

                return string.Empty;
            }
            set { ViewState["VS_Id_Productor"] = value; }
        }
        /// <summary>
        /// ViewState ColSeguimientoCultivo
        /// </summary>
        public IList<EXT_SeguimientoCultivo> ColSeguimientoCultivo
        {
            get
            {
                if (ViewState["ColSeguimientoCultivo"] != null)
                    return (IList<EXT_SeguimientoCultivo>)ViewState["ColSeguimientoCultivo"];
                else
                    return new List<EXT_SeguimientoCultivo>();
            }
            set
            {
                ViewState["ColSeguimientoCultivo"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                if (!IsPostBack)
                {
                    if (Session["IdSeguimiento"] == null)
                    { Response.Redirect("~/About.aspx"); }

                    LblNum.Text = Session["IdSeguimiento"].ToString();
                    LblEtapa.Text = Session["Etapa"].ToString();
                    
                    Datos_SEGUIMIENTO_ENCABEZADO();                    
                }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Datos_SEGUIMIENTO_ENCABEZADO()
        {
            DB_EXT_Seguimiento Seg = new DB_EXT_Seguimiento();
            DataTable dt = new DataTable();
            dt = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "ENCABEZADO");
            LblProductor.Text = dt.Rows[0][0].ToString();
            LblCedula.Text = dt.Rows[0][1].ToString();
            LblOrg.Text = dt.Rows[0][2].ToString();
            LblComunidad.Text = dt.Rows[0][4].ToString();
            LblMunicipio.Text = dt.Rows[0][5].ToString();
            LblProvincia.Text = dt.Rows[0][6].ToString();
            LblDep.Text = dt.Rows[0][7].ToString();
            LblPrograma.Text = dt.Rows[0][8].ToString();
            LblRegional.Text = dt.Rows[0][9].ToString();
            LblCamp.Text = dt.Rows[0][10].ToString();
            LblIdUser.Text = dt.Rows[0][11].ToString();
            
            DB_Usuario us = new DB_Usuario();
            dt = us.DB_Desplegar_USUARIO(0, LblIdUser.Text, "USUARIO");
            LblTecnico.Text = dt.Rows[0][10].ToString();
            switch (LblEtapa.Text)
            {
                //case "VERIFICACION_PARCELA":
                case "VERIFICACION Y/O GEORREFERENCIACION  DE PARCELA":
                    Panel1.Visible = true;
                    //GVCoordenadas.DataSource = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "COORDENADAS");
                    //GVCoordenadas.DataBind();
                    //**
                    DataTable dtgeo = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "COORDENADAS");

                    DataTable dtCoodenadas = new DataTable();
                    DataRow drRow;
                    dtCoodenadas.TableName = "Coodenadas";
                    dtCoodenadas.Columns.Add(new DataColumn("CoordenadaX", typeof(string)));
                    dtCoodenadas.Columns.Add(new DataColumn("CoordenadaY", typeof(string)));
                    dtCoodenadas.Columns.Add(new DataColumn("Num_Parcela", typeof(string)));
                    dtCoodenadas.Columns.Add(new DataColumn("Id_Productor", typeof(string)));
                    dtCoodenadas.Columns.Add(new DataColumn("Num_Punto", typeof(string)));

                    foreach (DataRow dtRow in dtgeo.Rows)
                    {
                        drRow = dtCoodenadas.NewRow();
                        drRow["CoordenadaX"] = dtRow["CoordenadaX"].ToString();
                        drRow["CoordenadaY"] = dtRow["CoordenadaY"].ToString();
                        drRow["Num_Parcela"] = dtRow["Num_Parcela"].ToString();
                        drRow["Id_Productor"] = dtRow["Id_Productor"].ToString();
                            //VS_Id_Productor = dtRow["Id_Productor"].ToString();
                            lblId_Productor.Text = dtRow["Id_Productor"].ToString();
                        drRow["Num_Punto"] = dtRow["Num_Punto"].ToString();
                        dtCoodenadas.Rows.Add(drRow);
                    }

                   //drRow = dtCoodenadas.NewRow();
                   //     drRow["CoordenadaX"] = dtgeo.Rows[13].ToString();//X
                   //     drRow["CoordenadaY"] = dtgeo.Rows[14].ToString();//Y
                   //     drRow["Num_Parcela"] = dtgeo.Rows[16].ToString();
                   //     drRow["Id_Productor"] = dtgeo.Rows[3].ToString();
                   //     drRow["Num_Punto"] = dtgeo.Rows[17].ToString();
                   //     dtCoodenadas.Rows.Add(drRow);
                    ViewState["dtCoodenadas"] = dtCoodenadas;
                    GVCoordenadas.DataSource = dtCoodenadas;
                    GVCoordenadas.DataBind();   
                    //**
                    dt = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "COORDENADAS");
                    TxtnumBol.Text = dt.Rows[0][7].ToString();
                    LblFechaSeg.Text = dt.Rows[0][8].ToString();
                    LblHoraSeg.Text = dt.Rows[0][9].ToString();
                    txtObservacionCoordenadas.Text = dt.Rows[0][11].ToString();
                    //LblObsParcela.Text = dt.Rows[0][11].ToString();
                    txtRecomendacionCoordenadas.Text = dt.Rows[0][12].ToString();
                    //LblRecomParcela.Text = dt.Rows[0][12].ToString();
                    LblIdSegParcela.Text = dt.Rows[0][15].ToString();
                    btn_AddCoordenada.Visible = true;
                    //** obtener adversidad y plagas
                    //Aux: 1.Adversidad_Presentada, 2.Adversidad_Presentadad_PME                                   

                    //DataTable dt_Adversidad = new DataTable();                    
                    //dt_Adversidad=Seg.DB_ADVESIDAD_GET(1, Convert.ToInt32(LblNum.Text));
                    //ViewState["dtAdverdidad"] = dt_Adversidad;
                    //GCAdversidad.DataSource = dt_Adversidad;
                    //GCAdversidad.DataBind();

                    //DataTable dt_Adversidad_PME = new DataTable();
                    //dt_Adversidad_PME=Seg.DB_ADVESIDAD_GET(2, Convert.ToInt32(LblNum.Text));
                    //ViewState["dtAdversidadPME"] = dt_Adversidad_PME;
                    //GVAdversidadPME.DataSource = dt_Adversidad_PME;
                    //GVAdversidadPME.DataBind();
                    //
                    break;
                //case "VERIFICACION_SIEMBRA":
                case "SEGUIMIENTO AL AVANCE DE SIEMBRA":
                    Panel2.Visible = true;
                    //GVSiembra.DataSource = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "SIEMBRA");
                    //GVSiembra.DataBind();
                    //******
                    DataTable dtSiembraGET = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "SIEMBRA");

                    DataTable dtSiembra = new DataTable();
                    DataRow drRowS;
                    dtSiembra.TableName = "Siembra";
                    //Id_Seguimiento_Parcela
                    dtSiembra.Columns.Add(new DataColumn("Id_Seguimiento_Parcela", typeof(string)));
                    dtSiembra.Columns.Add(new DataColumn("FechaSiembraINI", typeof(string)));
                    dtSiembra.Columns.Add(new DataColumn("FechaSiembraFIN", typeof(string)));
                    dtSiembra.Columns.Add(new DataColumn("SistemaSiembra", typeof(string)));
                    dtSiembra.Columns.Add(new DataColumn("CultivoAnterior", typeof(string)));
                    dtSiembra.Columns.Add(new DataColumn("VariedadSemilla", typeof(string)));
                    dtSiembra.Columns.Add(new DataColumn("AvanceSiembra", typeof(string)));

                    foreach (DataRow dtRow in dtSiembraGET.Rows)
                    {
                        drRowS = dtSiembra.NewRow();
                        drRowS["Id_Seguimiento_Parcela"] = dtRow["Id_Seguimiento_Parcela"].ToString();
                        drRowS["FechaSiembraINI"] =  Convert.ToDateTime(dtRow["Fecha_SiembraINI"].ToString()).ToShortDateString();
                        drRowS["FechaSiembraFIN"] = Convert.ToDateTime(dtRow["Fecha_SiembraFIN"].ToString()).ToShortDateString();
                        drRowS["SistemaSiembra"] = dtRow["Sistema_Siembra"].ToString();
                        drRowS["CultivoAnterior"] = dtRow["Cultivo_Anterior"].ToString();
                        drRowS["VariedadSemilla"] = dtRow["Variedad_Semilla"].ToString();
                        drRowS["AvanceSiembra"] = dtRow["Avance_Siembra"].ToString();
                        lblId_Productor.Text = dtRow["Id_Productor"].ToString();
                        dtSiembra.Rows.Add(drRowS);
                    }                  
                    ViewState["dtSiembra"] = dtSiembra;
                    GVSiembra.DataSource = dtSiembra;
                    GVSiembra.DataBind(); 
                    //*********
                    dt = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "SIEMBRA");
                    LblFechaSeg.Text = dt.Rows[0][9].ToString();
                    LblHoraSeg.Text = dt.Rows[0][10].ToString();
                    txtObsParcela.Text = dt.Rows[0][12].ToString();
                    //LblObsParcela0.Text = dt.Rows[0][12].ToString();
                    txtRecParcela.Text = dt.Rows[0][13].ToString();
                    //LblRecomParcela0.Text = dt.Rows[0][13].ToString();
                    TxtnumBol.Text = dt.Rows[0][8].ToString();
                    LblIdSegParcela.Text = dt.Rows[0][20].ToString();
                    break;
                //case "VERIFICACION_CULTIVO":
                case "SEGUIMIENTO Y/O MONITOREO DE CULTIVO":
                    Panel3.Visible = true;
                    //GVCultivo.DataSource = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "CULTIVO");
                    //GVCultivo.DataBind();
                    DataTable dtCultivoGET = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "CULTIVO");
                    DataTable dtCultivo = new DataTable();
                    DataRow drRowC;
                    dtCultivo.TableName = "Cultivo";
                    //Id_Seguimiento_Parcela
                    dtCultivo.Columns.Add(new DataColumn("Id_Seguimiento_Parcela", typeof(string)));
                    dtCultivo.Columns.Add(new DataColumn("Id_Fenologia", typeof(string)));
                    dtCultivo.Columns.Add(new DataColumn("Estado", typeof(string)));
                    dtCultivo.Columns.Add(new DataColumn("Porcentaje_FF", typeof(string)));

                    foreach (DataRow dtRow in dtCultivoGET.Rows)
                    {
                        drRowC = dtCultivo.NewRow();
                        drRowC["Id_Seguimiento_Parcela"] = dtRow["Id_Seguimiento_Parcela"].ToString();
                        //drRowC["Id_Fenologia"] = dtRow["Id_Fenologia"].ToString();
                        lblId_Fenologia.Text = dtRow["Id_Fenologia"].ToString();
                        drRowC["Id_Fenologia"] = lblId_Fenologia.Text;
                        drRowC["Estado"] = dtRow["Estado"].ToString();
                        drRowC["Porcentaje_FF"] = dtRow["Porcentaje_FF"].ToString();
                        lblId_Productor.Text = dtRow["Id_Productor"].ToString();
                        dtCultivo.Rows.Add(drRowC);
                    }
                    ViewState["dtCultivo"] = dtCultivo;
                    GVCultivo.DataSource = dtCultivo;
                    GVCultivo.DataBind(); 

                    //dt = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "CULTIVO");
                    LblFechaSeg.Text = dtCultivoGET.Rows[0][9].ToString();
                    LblHoraSeg.Text = dtCultivoGET.Rows[0][10].ToString();
                    txtObsParcela1.Text = dtCultivoGET.Rows[0][12].ToString();
                    txtRecomParcela1.Text = dtCultivoGET.Rows[0][13].ToString();

                    TxtnumBol.Text = dtCultivoGET.Rows[0][8].ToString(); //numero de boleta
                    LblIdSegParcela.Text = dtCultivoGET.Rows[0][22].ToString(); //Id_Seguimiento_Parcela
                    RECUPERAR_REGISTRO_CULTIVO();
                    break;
            }
            //** obtener adversidad y plagas
            //Aux: 1.Adversidad_Presentada, 2.Adversidad_Presentadad_PME   
            DataTable dt_Adversidad = new DataTable();
            dt_Adversidad = Seg.DB_ADVESIDAD_GET(1, Convert.ToInt32(LblNum.Text));
            ViewState["dtAdverdidad"] = dt_Adversidad;
            GCAdversidad.DataSource = dt_Adversidad;
            GCAdversidad.DataBind();

            DataTable dt_Adversidad_PME = new DataTable();
            dt_Adversidad_PME = Seg.DB_ADVESIDAD_GET(2, Convert.ToInt32(LblNum.Text));
            ViewState["dtAdversidadPME"] = dt_Adversidad_PME;
            GVAdversidadPME.DataSource = dt_Adversidad_PME;
            GVAdversidadPME.DataBind();
        }
        #endregion

        protected void GVCoordenadas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string coX = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CoordenadaX"));
                string coY = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CoordenadaY"));
                string n_parcela = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Num_Parcela"));
                string n_punto = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Num_Punto"));
                
                ((TextBox)e.Row.FindControl("TxtCoordX")).Text = coX;
                ((TextBox)e.Row.FindControl("TxtCoordY")).Text = coY;
                ((TextBox)e.Row.FindControl("TxtNum_Parcela")).Text = n_parcela;
                ((TextBox)e.Row.FindControl("TxtNum_Punto")).Text = n_punto;
            }
            //**lrojas:21-11-2016
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[5].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Eliminar " + item + "?')) {return false;};";                        
                    }
                }
            }
            //**
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            EXT_SeguimientoCoordenadas SegCoo = new EXT_SeguimientoCoordenadas();
            DB_EXT_Seguimiento insSeg = new DB_EXT_Seguimiento();
            EXT_SeguimientoParcela segParc = new EXT_SeguimientoParcela();
            switch (LblEtapa.Text)
            {                
                //case "VERIFICACION_PARCELA":
                case "VERIFICACION Y/O GEORREFERENCIACION  DE PARCELA":
                    //1. eliminamos las coordenadas
                    insSeg.DB_Registrar_SEGUIMIENTO_COORDENADA_DELETE(Convert.ToInt32(LblIdSegParcela.Text));
                    //2. volvemos a insertar las coodenadas
                    foreach (GridViewRow row in GVCoordenadas.Rows)
                    {
                        SegCoo.Id_Seguimiento_Parcela = Convert.ToInt32(LblIdSegParcela.Text);
                        SegCoo.Id_Productor = lblId_Productor.Text;
                        TextBox N_Parcela = (TextBox)row.FindControl("TxtNum_Parcela");
                        SegCoo.Num_Parcela = Convert.ToInt32(N_Parcela.Text);
                        TextBox N_Punto = (TextBox)row.FindControl("TxtNum_Punto");
                        SegCoo.Num_Punto = Convert.ToInt32(N_Punto.Text);
                        TextBox CoodenadaX = (TextBox)row.FindControl("TxtCoordX");
                        SegCoo.CoordenadaX = CoodenadaX.Text;
                        TextBox CoodenadaY = (TextBox)row.FindControl("TxtCoordY");
                        SegCoo.CoordenadaY = CoodenadaY.Text;
                        insSeg.DB_Registrar_SEGUIMIENTO_COORDENADA(SegCoo);
                    }
                    //3. Actualizamos Seguimiento Parcela
                    segParc.Id_Seguimiento = Convert.ToInt32(LblNum.Text);
                    //segParc.Boleta_Numero = Convert.ToInt32(TxtNumBoleta.Text);            
                    //segParc.Fecha_Seg = Convert.ToDateTime(TxtFecha.Text);
                    //segParc.Hora_Seg = DDLHora.SelectedValue + ":" + DDLMinuto.SelectedValue;
                    //segParc.Hora_Seg = string.Empty;
                    //segParc.Fecha_Sis = DateTime.Now;//FECHA SE OBTENDRA DEL SERVER AL EJECUTAR SP
                    segParc.Observacion = HttpUtility.HtmlDecode(txtObservacionCoordenadas.Text);
                    segParc.Recomendacion = HttpUtility.HtmlDecode(txtRecomendacionCoordenadas.Text);
                    insSeg.DB_Registrar_SEGUIMIENTO_PARCELA_UPDATE(segParc);

                   
                    break;
                //case "VERIFICACION_SIEMBRA":
                case "SEGUIMIENTO AL AVANCE DE SIEMBRA":
                    //1. ELIMINAMOS SEGUIMIENTO SIEMBRA
                    insSeg.DB_SEGUIMIENTO_SIEMBRA_DELETE(Convert.ToInt32(LblIdSegParcela.Text));
                    //2. volvemos a insertar 
                    EXT_SeguimientoSiembra ss = new EXT_SeguimientoSiembra();                    
                    //EXT_AdversidadPresentada ad = new EXT_AdversidadPresentada();
                    //if (GVAdversidadPME.Rows.Count > 0)
                    //{
                        foreach (GridViewRow row in GVSiembra.Rows)
                        {
                            ss.Id_Seguimiento_Parcela = Convert.ToInt32(LblIdSegParcela.Text);
                            ss.Fecha_SiembraINI = Convert.ToDateTime(((TextBox)row.FindControl("txtFechaINI")).Text);
                            ss.Fecha_SiembraFIN = Convert.ToDateTime(((TextBox)row.FindControl("txtFechaFIN")).Text);
                            ss.Sistema_Siembra = ((DropDownList)row.FindControl("DDLSistemaSiembra")).SelectedValue;
                            ss.Cultivo_Anterior = HttpUtility.HtmlDecode(((TextBox)row.FindControl("txtCultivoAnterior")).Text);
                            ss.Variedad_Semilla = HttpUtility.HtmlDecode(((TextBox)row.FindControl("txtVariedadSemilla")).Text);
                            ss.Avance_Siembra = Convert.ToInt16(((TextBox)row.FindControl("txtAvanceSiembra")).Text);
                            insSeg.DB_Registrar_SEGUIMIENTO_SIEMBRA(ss);
                        }
                    //}
                    //3. Actualizamos Seguimiento Parcela
                    segParc.Id_Seguimiento = Convert.ToInt32(LblNum.Text);
                    //segParc.Boleta_Numero = Convert.ToInt32(TxtNumBoleta.Text);            
                    //segParc.Fecha_Seg = Convert.ToDateTime(TxtFecha.Text);
                    //segParc.Hora_Seg = DDLHora.SelectedValue + ":" + DDLMinuto.SelectedValue;
                    //segParc.Hora_Seg = string.Empty;
                    //segParc.Fecha_Sis = DateTime.Now;//FECHA SE OBTENDRA DEL SERVER AL EJECUTAR SP
                    segParc.Observacion = HttpUtility.HtmlDecode(txtObsParcela.Text);
                    segParc.Recomendacion = HttpUtility.HtmlDecode(txtRecParcela.Text);
                    insSeg.DB_Registrar_SEGUIMIENTO_PARCELA_UPDATE(segParc);
                    break;
                //case "VERIFICACION_CULTIVO":
                case "SEGUIMIENTO Y/O MONITOREO DE CULTIVO":
                    //***validacion en seleccion de fenologia
                    string valor = ((DropDownList)GVCultivo.Rows[0].FindControl("DDLFaseFenoligia")).SelectedValue;
                    int UltimoIdFenologiaRegistrtado = ColSeguimientoCultivo.FirstOrDefault().Id_Fenologia;
                    if (Convert.ToInt16(valor) < UltimoIdFenologiaRegistrtado)
                    {
                        if (Convert.ToInt16(valor) != Convert.ToInt16(lblId_Fenologia.Text))
                        {
                            string script = @"<script type='text/javascript'>alert('{0}');</script>";
                            script = string.Format(script, "NO PUEDE SELECCIONAR FENOLOGICA HACIA ATRAS..!");
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                            return;
                        }
                    }
                    //***
                    //1. ELIMINAMOS SEGUIMIENTO cultivo
                    insSeg.DB_SEGUIMIENTO_CULTIVO_DELETE(Convert.ToInt32(LblIdSegParcela.Text));
                    //2. volvemos a insertar 
                    EXT_SeguimientoCultivo sc = new EXT_SeguimientoCultivo();
                    //if (GVCultivo.Rows.Count > 0)
                    //{
                        foreach (GridViewRow dgi in GVCultivo.Rows)
                        {
                            sc.Id_Seguimiento_Parcela = Convert.ToInt32(LblIdSegParcela.Text);
                            sc.Id_Fenologia = Convert.ToInt16(((DropDownList)dgi.FindControl("DDLFaseFenoligia")).SelectedValue);
                            sc.Estado = "Avance";
                            sc.Porcentaje_FF = 100;
                            sc.Fecha_Cosecha = insSeg.DB_ObtenerFechaServer();
                            insSeg.DB_Registrar_SEGUIMIENTO_CULTIVO(sc);                            
                        }
                    //}
                    //3. Actualizamos Seguimiento Parcela
                    segParc.Id_Seguimiento = Convert.ToInt32(LblNum.Text);
                    //segParc.Boleta_Numero = Convert.ToInt32(TxtNumBoleta.Text);            
                    //segParc.Fecha_Seg = Convert.ToDateTime(TxtFecha.Text);
                    //segParc.Hora_Seg = DDLHora.SelectedValue + ":" + DDLMinuto.SelectedValue;
                    //segParc.Hora_Seg = string.Empty;
                    //segParc.Fecha_Sis = DateTime.Now;//FECHA SE OBTENDRA DEL SERVER AL EJECUTAR SP
                    segParc.Observacion = HttpUtility.HtmlDecode(txtObsParcela1.Text);
                    segParc.Recomendacion = HttpUtility.HtmlDecode(txtRecomParcela1.Text);
                    insSeg.DB_Registrar_SEGUIMIENTO_PARCELA_UPDATE(segParc);
                    break;
            }            
            //GENERAL PARA CUALQUIER ETAPA
            //4. ELIMINAMOS ADVERSIDAD PRESENTADA
            insSeg.DB_ADVESIDAD_DELETE(Convert.ToInt32(LblIdSegParcela.Text));
            //5. volvemos a insertar Adversidades que esten en el grid.
            EXT_AdversidadPresentada ad = new EXT_AdversidadPresentada();
            if (GCAdversidad.Rows.Count > 0)
            {
                foreach (GridViewRow dgi in GCAdversidad.Rows)
                {
                    ad.Id_Seguimiento_Parcela = Convert.ToInt32(LblIdSegParcela.Text);
                    //if (GCAdversidad.Rows[dgi.RowIndex].Cells[0].Text != string.Empty)
                    //{
                    string adver = ((DropDownList)dgi.FindControl("DDLAdversidad")).SelectedValue;
                    ad.Adversidad = adver;
                    ad.Intencidad = ((DropDownList)dgi.FindControl("DDLIntensidad")).SelectedValue;
                    string PorInt = ((TextBox)dgi.FindControl("TxtPorcentajeIntensidad")).Text;
                    ad.Porcentage = Convert.ToDecimal(PorInt);
                    string fecha = ((TextBox)dgi.FindControl("txtFechaOcurrencia")).Text;
                    ad.Fecha_Ocurrencia = Convert.ToDateTime(fecha);
                    string ObsRec = ((TextBox)dgi.FindControl("txtObs_Rec")).Text;
                    ad.Descripcion = HttpUtility.HtmlDecode(ObsRec);
                    ad.Tratamiento = string.Empty;
                    insSeg.DB_Registrar_ADVESIDAD(ad);
                    //}                            
                }
            }

            //6. ELIMINAMOS ADVERSIDAD PRESENTADA PME
            insSeg.DB_ADVESIDAD_PME_DELETE(Convert.ToInt32(LblIdSegParcela.Text));
            //7. volvemos a insertar Adversidades que esten en el grid.
            EXT_AdversidadPresentada adpme = new EXT_AdversidadPresentada();
            if (GVAdversidadPME.Rows.Count > 0)
            {
                foreach (GridViewRow row in GVAdversidadPME.Rows)
                {
                    adpme.Id_Seguimiento_Parcela = Convert.ToInt32(LblIdSegParcela.Text);
                    //if (GVAdversidadPME.Rows[dgi.RowIndex].Cells[0].Text != string.Empty)
                    //{
                    adpme.Adversidad = ((DropDownList)row.FindControl("DDLAdversidad")).SelectedValue;
                    adpme.Descripcion = HttpUtility.HtmlDecode(((TextBox)row.FindControl("txtDescripcion")).Text);
                    adpme.Intencidad = ((DropDownList)row.FindControl("DDLIntensidad")).SelectedValue;
                    adpme.Tratamiento = HttpUtility.HtmlDecode(((TextBox)row.FindControl("txtTratamiento")).Text);
                    adpme.Porcentage = 0;//no se ingresa en sp
                    DateTime fecha = DateTime.Now;
                    adpme.Fecha_Ocurrencia = fecha; //no se ingresa en sp
                    insSeg.DB_Registrar_ADVESIDAD_PME(adpme);
                    //}
                }
            }
            Response.Redirect("frmListaSegOrg.aspx",true);
            //Response.Redirect("frmSeguimientoTecnico.aspx",true);
        }

        protected void GVCoordenadas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void GVCoordenadas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["dtCoodenadas"] as DataTable;
            int count = dt.Rows.Count;
            if (count == 1)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, "AL MENOS UNA COORDENADA DE VERIFICACIÓN DEBE ESTAR REGISTRADA..!");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
            dt.Rows[index].Delete();
            ViewState["dtCoodenadas"] = dt;
            GVCoordenadas.DataSource = ViewState["dtCoodenadas"] as DataTable;
            GVCoordenadas.DataBind();

            //if (dt.Rows.Count == 0)
            //{
            //    DataRow dr;
            //    dr = dt.NewRow();
            //    dt.Rows.Add(dr);
            //    GVCoordenadas.DataSource = dt;
            //    GVCoordenadas.DataBind();
            //}
        }

        protected void btn_AddCoordenada_Click(object sender, EventArgs e)
        {
            if (ViewState["dtCoodenadas"] != null)
            {
                DataTable dtCoodenadas = (DataTable)ViewState["dtCoodenadas"];
                DataRow drRow;
                drRow = dtCoodenadas.NewRow();
                if (dtCoodenadas.Rows.Count > 0)
                {
                    
                    drRow["CoordenadaX"] = string.Empty;
                    drRow["CoordenadaY"] = string.Empty;
                    drRow["Num_Parcela"] = string.Empty;
                    drRow["Id_Productor"] = lblId_Productor.Text;
                    drRow["Num_Punto"] = string.Empty;
                   
                }
                //if (dtCoodenadas.Rows[0][0].ToString() == "")
                //{
                //    dtCoodenadas.Rows[0].Delete();
                //    dtCoodenadas.AcceptChanges();
                //}
                dtCoodenadas.Rows.Add(drRow);
                ViewState["dtCoodenadas"] = dtCoodenadas;
                GVCoordenadas.DataSource = dtCoodenadas;
                GVCoordenadas.DataBind();
                
            }
        }


        #region EDICION DE ADVERDIDAD  Y  PLAGAS
        protected void GCAdversidad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string Id_Seguimiento = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Id_Seguimiento_Parcela"));
                string Adversidad = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Adversidad"));
                string Intencidad = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Intencidad"));
                string Porcentaje = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Porcentage"));
                string Fecha = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Fecha_Ocurrencia")).ToShortDateString();
                string Descripcion = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Descripcion"));

                ((DropDownList)e.Row.FindControl("DDLAdversidad")).SelectedValue = Adversidad;
                ((DropDownList)e.Row.FindControl("DDLIntensidad")).SelectedValue = Intencidad;
                ((TextBox)e.Row.FindControl("TxtPorcentajeIntensidad")).Text = Porcentaje;
                ((TextBox)e.Row.FindControl("txtFechaOcurrencia")).Text = Fecha;
                ((TextBox)e.Row.FindControl("txtObs_Rec")).Text = Descripcion;
            }
        }
        protected void GCAdversidad_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["dtAdverdidad"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["dtAdverdidad"] = dt;
            GCAdversidad.DataSource = ViewState["dtAdverdidad"] as DataTable;
            GCAdversidad.DataBind();

            //if (dt.Rows.Count == 0)
            //{
            //    DataRow dr;
            //    dr = dt.NewRow();
            //    dt.Rows.Add(dr);
            //    GCAdversidad.DataSource = dt;
            //    GCAdversidad.DataBind();
            //}
        }
        
        protected void btnAdd_Adversidad_Click(object sender, EventArgs e)
        {
            if (ViewState["dtAdverdidad"] != null)
            {
                DataTable dtAdversidad = (DataTable)ViewState["dtAdverdidad"];
                DataRow drRow;
                drRow = dtAdversidad.NewRow();
                //if (dtAdversidad.Rows.Count > 0)
                //{
                    drRow["Id_Seguimiento_Parcela"] = LblIdSegParcela.Text;
                    drRow["Adversidad"] = string.Empty;
                    drRow["Intencidad"] = string.Empty;
                    drRow["Porcentage"] = Convert.ToDecimal("0");
                    drRow["Fecha_Ocurrencia"] = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    drRow["Descripcion"] = string.Empty;

                //}
                //if (dtCoodenadas.Rows[0][0].ToString() == "")
                //{
                //    dtCoodenadas.Rows[0].Delete();
                //    dtCoodenadas.AcceptChanges();
                //}
                dtAdversidad.Rows.Add(drRow);
                ViewState["dtAdverdidad"] = dtAdversidad;
                GCAdversidad.DataSource = dtAdversidad;
                GCAdversidad.DataBind();
            }
        }

        protected void GVAdversidadPME_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string Id_Seguimiento = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Id_Seguimiento_Parcela"));
                string Adversidad = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Adversidad"));
                string Descripcion = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Descripcion"));
                string Intencidad = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Intencidad"));
                string Tratamiento = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Tratamiento"));

                ((DropDownList)e.Row.FindControl("DDLAdversidad")).SelectedValue = Adversidad;
                ((TextBox)e.Row.FindControl("txtDescripcion")).Text = Descripcion;
                ((DropDownList)e.Row.FindControl("DDLIntensidad")).SelectedValue = Intencidad;
                ((TextBox)e.Row.FindControl("txtTratamiento")).Text = Tratamiento;
                
            }
        }

        protected void GVAdversidadPME_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["dtAdversidadPME"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["dtAdversidadPME"] = dt;
            GVAdversidadPME.DataSource = ViewState["dtAdversidadPME"] as DataTable;
            GVAdversidadPME.DataBind();

            //if (dt.Rows.Count == 0)
            //{
            //    DataRow dr;
            //    dr = dt.NewRow();
            //    dt.Rows.Add(dr);
            //    GVAdversidadPME.DataSource = dt;
            //    GVAdversidadPME.DataBind();
            //}
        }

        protected void btnAdd_AdversidadPME_Click(object sender, EventArgs e)
        {
            if (ViewState["dtAdversidadPME"] != null)
            {
                DataTable dtAdversidadPME = (DataTable)ViewState["dtAdversidadPME"];
                DataRow drRow;
                drRow = dtAdversidadPME.NewRow();
                //if (dtAdversidadPME.Rows.Count > 0)
                //{
                    drRow["Id_Seguimiento_Parcela"] = LblIdSegParcela.Text;
                    drRow["Adversidad"] = string.Empty;
                    drRow["Descripcion"] = string.Empty;
                    drRow["Intencidad"] = string.Empty;    
                    drRow["Tratamiento"] = string.Empty;                

                //}                                
                dtAdversidadPME.Rows.Add(drRow);
                ViewState["dtAdversidadPME"] = dtAdversidadPME;
                GVAdversidadPME.DataSource = dtAdversidadPME;
                GVAdversidadPME.DataBind();
            }
        }
        #endregion

        #region SIEMBRA
        protected void GVSiembra_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string Id_Seguimiento = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Id_Seguimiento_Parcela"));
                string FechaInio = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FechaSiembraINI"));
                string FechaFIn = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FechaSiembraFIN"));
                string SistemaSiembra = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SistemaSiembra"));
                string CultivoAnterior = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CultivoAnterior"));
                string VariedadSemilla = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "VariedadSemilla"));
                string AvanceSiembra = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AvanceSiembra"));

                ((TextBox)e.Row.FindControl("txtFechaINI")).Text = FechaInio;
                ((TextBox)e.Row.FindControl("txtFechaFIN")).Text = FechaFIn;
                ((DropDownList)e.Row.FindControl("DDLSistemaSiembra")).SelectedValue = SistemaSiembra;
                ((TextBox)e.Row.FindControl("txtCultivoAnterior")).Text = CultivoAnterior;
                ((TextBox)e.Row.FindControl("txtVariedadSemilla")).Text = VariedadSemilla;
                ((TextBox)e.Row.FindControl("txtAvanceSiembra")).Text = AvanceSiembra;
            }
        }
        #endregion

        #region CULTIVO

        private void RECUPERAR_REGISTRO_CULTIVO()
        {
            DB_EXT_Seguimiento avsiem = new DB_EXT_Seguimiento();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();

            DataTable dt = new DataTable();
            DataRow drnew;
            dt.TableName = "Fenologia";
            dt.Columns.Add(new DataColumn("Id_Fenologia", typeof(int)));
            dt.Columns.Add(new DataColumn("Fenologia", typeof(string)));
            dt.Columns.Add(new DataColumn("EstadoFF", typeof(string)));
            dt.Columns.Add(new DataColumn("Porcentaje", typeof(int)));
            dt.Columns.Add(new DataColumn("Id_Seguimiento_Parcela", typeof(int)));
            drnew = dt.NewRow();
            dt.Rows.Add(drnew);
            ViewState["dtFenologia"] = dt;

            dt1 = avsiem.DB_RECUPERAR_REGISTRO_CULTIVO(lblId_Productor.Text, "3");
            dt2 = avsiem.DB_RECUPERAR_REGISTRO_CULTIVO(lblId_Productor.Text, "VERIFICACION_CULTIVO");
            dt3 = dt1.Clone();
            foreach (DataRow dr in dt2.Rows)
            {
                dt3.ImportRow(dr);
            }
            foreach (DataRow dr in dt1.Rows)
            {
                dt3.ImportRow(dr);
            }
            if (dt3.Rows.Count > 0)
            {
                DataView dv = dt3.DefaultView;
                dv.Sort = "[Id_Seguimiento_Parcela] ASC";
                dt3 = dv.ToTable();
            }           
            IList<EXT_SeguimientoCultivo> ColSC = new List<EXT_SeguimientoCultivo>();
            DataTable dtTable = (DataTable)ViewState["dtFenologia"];
            DataRow drRow = null;
            foreach (DataRow row in dt3.Rows)
            {
                EXT_SeguimientoCultivo ObjSC = new EXT_SeguimientoCultivo();
                if (dtTable.Rows.Count > 0)
                {
                    drRow = dtTable.NewRow();
                    int id_f = Convert.ToInt16(row["Id_Fenologia"].ToString());
                    switch (id_f)
                    {
                        case 26:
                            drRow["Id_Fenologia"] = id_f;
                            drRow["Fenologia"] = "GERMINACION EMERGENCIA";
                            break;
                        case 27:
                            drRow["Id_Fenologia"] = id_f;
                            drRow["Fenologia"] = "PLANTULA";
                            break;
                        case 28:
                            drRow["Id_Fenologia"] = id_f;
                            drRow["Fenologia"] = "MACOLLAMIENTO";
                            break;
                        case 29:
                            drRow["Id_Fenologia"] = id_f;
                            drRow["Fenologia"] = "EMBUCHE";
                            break;
                        case 30:
                            drRow["Id_Fenologia"] = id_f;
                            drRow["Fenologia"] = "ESPIGAZON";
                            break;
                        case 31:
                            drRow["Id_Fenologia"] = id_f;
                            drRow["Fenologia"] = "FLORACION";
                            break;
                        case 32:
                            drRow["Id_Fenologia"] = id_f;
                            drRow["Fenologia"] = "LLENADO GRANO";
                            break;
                        case 33:
                            drRow["Id_Fenologia"] = id_f;
                            drRow["Fenologia"] = "MADURACION";
                            break;
                        case 34:
                            drRow["Id_Fenologia"] = id_f;
                            drRow["Fenologia"] = "GERMINACION EMERGENCIA";
                            break;
                        case 35:
                            drRow["Id_Fenologia"] = id_f;
                            drRow["Fenologia"] = "PLANTULA";
                            break;
                        case 36:
                            drRow["Id_Fenologia"] = id_f;
                            drRow["Fenologia"] = "FASE VEGETATIVA";
                            break;
                        case 37:
                            drRow["Id_Fenologia"] = id_f;
                            drRow["Fenologia"] = "FASE REPRODUCTIVA";
                            break;
                        case 38:
                            drRow["Id_Fenologia"] = id_f;
                            drRow["Fenologia"] = "MADURACION DEL GRANO";
                            break;
                    }
                    //drRow["Id_Fenologia"] = DDLFenologia.SelectedValue;
                    //drRow["Fenologia"] = DDLFenologia.SelectedItem.ToString();
                    drRow["EstadoFF"] = row["Estado"].ToString();
                    drRow["Porcentaje"] = Convert.ToInt16(row["Porcentaje_FF"].ToString());
                    drRow["Id_Seguimiento_Parcela"] = Convert.ToInt16(row["Id_Seguimiento_Parcela"].ToString());

                }
                if (dtTable.Rows[0][0].ToString() == "")
                {
                    dtTable.Rows[0].Delete();
                    dtTable.AcceptChanges();
                }
                dtTable.Rows.Add(drRow);
                //LR:agregamos en ColSC para poder bloquear el boton eliminar a los datos que se recuperen de la BD
                ObjSC.Id_Seguimiento_Parcela = Convert.ToInt16(row["Id_Seguimiento_Parcela"].ToString());
                ObjSC.Id_Fenologia = Convert.ToInt16(row["Id_Fenologia"].ToString());
                ObjSC.Estado = row["Estado"].ToString();
                ObjSC.Porcentaje_FF = Convert.ToInt16(row["Porcentaje_FF"].ToString());
                ColSC.Add(ObjSC);
            }
            ViewState["dtFenologia"] = dtTable;
            IList<EXT_SeguimientoCultivo> ColSeg_Cultivo = new List<EXT_SeguimientoCultivo>();
            
            foreach (DataRow row in dtTable.Rows)
            {
                EXT_SeguimientoCultivo ObjSegCultivo = new EXT_SeguimientoCultivo();
                string idSegPar = row["Id_Seguimiento_Parcela"].ToString();
                string idFenologia = row["Id_Fenologia"].ToString();
                string estado = row["EstadoFF"].ToString();
                string porcentaje = row["Porcentaje"].ToString();
                ObjSegCultivo.Id_Seguimiento_Parcela = Convert.ToInt16(idSegPar);
                ObjSegCultivo.Id_Fenologia = Convert.ToInt16(idFenologia);
                ObjSegCultivo.Estado = estado;
                ObjSegCultivo.Porcentaje_FF = Convert.ToInt16(porcentaje);
                ColSeg_Cultivo.Add(ObjSegCultivo);
            }
            ColSeguimientoCultivo = ColSeg_Cultivo.OrderByDescending(x=>x.Id_Seguimiento_Parcela).ToList();
            //ColSeguimientoCultivo = ColSC;
            //GVSegCultivo.DataSource = dtTable;
            //GVSegCultivo.DataBind();



        }
        protected void DDLFaseFenoligia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = ((DropDownList)GVCultivo.Rows[0].FindControl("DDLFaseFenoligia")).SelectedItem.Value;
            int UltimoIdFenologiaRegistrtado = ColSeguimientoCultivo.FirstOrDefault().Id_Fenologia;
            if (Convert.ToInt16(valor) < UltimoIdFenologiaRegistrtado)
            {
                if (Convert.ToInt16(valor) != Convert.ToInt16(lblId_Fenologia.Text))
                {
                    string script = @"<script type='text/javascript'>alert('{0}');</script>";
                    script = string.Format(script, "NO PUEDE SELECCIONAR FENOLOGICA HACIA ATRAS..!");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    return;
                }
                
            }
        }
        protected void GVCultivo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                string idfenologia = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Id_Fenologia"));

                ((DropDownList)e.Row.FindControl("DDLFaseFenoligia")).SelectedValue = idfenologia;

                /*DropDownList ddlfase = ((DropDownList)e.Row.FindControl("DDLFaseFenoligia"));
                ddlfase = new DropDownList();                
                DB_EXT_Fenologia nd = new DB_EXT_Fenologia();
                List<EXT_Fenologia> ListaF = nd.DB_GET_FASES_FENOLOGICAS(LblPrograma.Text);
                ddlfase.DataSource = ListaF;
                ddlfase.DataValueField = "Id_Fenologia";
                ddlfase.DataTextField = "Nom_Fenologia";
                ddlfase.DataBind();
                
                ddlfase.SelectedValue = idfenologia;*/
            }            
        }
        protected void GVCultivo_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList ddlfase = new DropDownList();
                foreach (GridViewRow gvr in GVCultivo.Rows)
                {
                    ddlfase = ((DropDownList)gvr.FindControl("DDLFaseFenoligia"));

                }
                DB_EXT_Fenologia nd = new DB_EXT_Fenologia();
                List<EXT_Fenologia> ListaF = nd.DB_GET_FASES_FENOLOGICAS(LblPrograma.Text);
                ddlfase.DataSource = ListaF;
                ddlfase.DataValueField = "Id_Fenologia";
                ddlfase.DataTextField = "Nom_Fenologia";
                ddlfase.DataBind();
            }
        }
        #endregion

       

        protected void GVSiembra_Load(object sender, EventArgs e)
        {
            DB_AP_Registro_Org d_org = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            string iduser = Session["IdUser"].ToString();
            dt = d_org.DB_Desplegar_USUARIO(iduser);
            string region = "";
            DataTable table1 = new DataTable("oriente");
            table1.Clear();
            foreach (DataRow row in dt.Rows)
            {
                region = row["Region"].ToString();
            }

            if (region == "ORIENTE")
            {

                table1.Columns.Add("text");
                table1.Columns.Add("value");
                table1.Rows.Add("Tradicional", "Tradicional");
                table1.Rows.Add("Semi-Mecanizado", "Semi-Mecanizado");
                table1.Rows.Add("Siembra Directa", "Siembra Directa");
                table1.Rows.Add("Mecanizada al Boleo", "Mecanizada al Boleo");
                table1.Rows.Add("Mecanizada Convencional", "Mecanizada Convencional");
            }

            if (region == "OCCIDENTE")
            {
                //DataTable table2 = new DataTable("occidente");
                table1.Columns.Add("text");
                table1.Columns.Add("value");
                table1.Rows.Add("Tradicional", "Tradicional");
                table1.Rows.Add("Semi-Mecanizado", "Semi-Mecanizado");
                table1.Rows.Add("Mecanizado", "Mecanizado");
            }

            DataSet set = new DataSet("office");
            set.Tables.Add(table1);

            //DDLSistemaSiembra.DataSource = set;
            //DDLSistemaSiembra.DataTextField = "text";
            //DDLSistemaSiembra.DataValueField = "text";
            //DDLSistemaSiembra.DataBind();

            DropDownList ddlLocation = new DropDownList();
            foreach (GridViewRow gvr in GVSiembra.Rows)
            {
                ddlLocation = ((DropDownList)gvr.FindControl("DDLSistemaSiembra"));               

            }
            ddlLocation.DataSource = set;
            ddlLocation.DataTextField = "text";
            ddlLocation.DataValueField = "text";
            ddlLocation.DataBind();
        }

        protected void GVSiembra_PreRender(object sender, EventArgs e)
        {

        }

        
        /// <summary>
        /// se llena DDLFaseFenoligia
        /// </summary>
        private void llenar_dllfase()
        {
            DropDownList ddlfase = new DropDownList();
            foreach (GridViewRow gvr in GVCultivo.Rows)
            {
                ddlfase = ((DropDownList)gvr.FindControl("DDLFaseFenoligia"));

            }
            DB_EXT_Fenologia nd = new DB_EXT_Fenologia();
            List<EXT_Fenologia> ListaF = nd.DB_GET_FASES_FENOLOGICAS(LblPrograma.Text);
            ddlfase.DataSource = ListaF;
            ddlfase.DataValueField = "Id_Fenologia";
            ddlfase.DataTextField = "Nom_Fenologia";
            ddlfase.DataBind();
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmListaSegOrg.aspx", true);
        }
       

        
    }
}