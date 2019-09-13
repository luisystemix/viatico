using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataEntity.DE_General;
using DataBusiness.DB_General;
using DataBusiness.DB_Viaticos;
using DataEntity.DE_Viaticos;
using DataBusiness.DB_Registro;

namespace WebAplication.Viaticos
{
    public partial class frmRealizarSolicitud : System.Web.UI.Page
    {
        public List<VT_Feriados> Col_Feriados_VS
        {
            get
            {
                if (ViewState["Col_Feriados_VS"] != null)
                    return (List<VT_Feriados>)ViewState["Col_Feriados_VS"];
                else
                    return new List<VT_Feriados>();
            }
            set
            {
                ViewState["Col_Feriados_VS"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblAux.Text = DateTime.Now.ToString();
                    LblIdUser.Text = Session["IdUser"].ToString();
                    DB_AdminUser User = new DB_AdminUser();
                    DataTable dt = User.DB_Desplegar_USUARIO(LblIdUser.Text);
                    string name_reg = dt.Rows[0][5].ToString();
                    Inicializar_ComboReg(name_reg);
                    DDLDepart.SelectedValue = "0";
                    Inicializar_ComboDep(DDLDepart.SelectedValue, LblZona.Text);/**************** cambio el value del combo ******************/
                    DataTable dtListaPartida = new DataTable();
                    dtListaPartida.Columns.AddRange(new DataColumn[10] { new DataColumn("Tramo"), new DataColumn("Zona"), new DataColumn("Destino"), new DataColumn("Lugar"), new DataColumn("Objetivo"), new DataColumn("Fecha Salida"), new DataColumn("Via"), new DataColumn("Tipo"), new DataColumn("Nombre"), new DataColumn("IdenTifi") });
                    GridView1.DataSource = dtListaPartida;
                    GridView1.DataBind();
                    Session["datos"] = dtListaPartida;
                }
            }
            catch (Exception ex)
            {
                //Response.Redirect("~/About.aspx");
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        #region FUNCIONES INDEPENDIENTES
        protected void Inicializar_ComboReg(string name_reg)
        {
            /************** DEPARTAMENTOS **************/
            DB_Regional r = new DB_Regional();
            List<Regional> listaR = r.DB_Desplegar_REGIONAL();
            DDLDepart.Items.Clear();

            DB_AdminUser User = new DB_AdminUser();
            DataTable dt = User.DB_Desplegar_USUARIO(Session["IdUser"].ToString());

            string regional = dt.Rows[0][5].ToString();
            DDLDepart.Items.Add(new ListItem(regional, regional));
            //lrojas: se agrego listado den la bd tbl regional
            this.LlenaCombosRegionales(name_reg);
            DDLDepart.DataBind();

        }
        protected void LlenaCombosRegionales(string nombreRegional)
        {
            int aux = 0;
            switch (nombreRegional)
            {
                case "SANTA CRUZ":
                    DDLDepart.Items.Insert(aux, new ListItem("4 CAÑADAS", "4 CAÑADAS", true));
                    aux++;
                    DDLDepart.Items.Insert(aux, new ListItem("SAN PEDRO", "SAN PEDRO", true));
                    aux++;
                    DDLDepart.Items.Insert(aux, new ListItem("MONTERO", "MONTERO", true));
                    aux++;
                    DDLDepart.Items.Insert(aux, new ListItem("YAPACANI", "YAPACANI", true));
                    aux++;
                    DDLDepart.Items.Insert(aux, new ListItem("CABEZAS", "CABEZAS", true));
                    aux++;
                    DDLDepart.Items.Insert(aux, new ListItem("SAN JULIAN", "SAN JULIAN", true));
                    aux++;
                    break;
                case "TARIJA":
                    DDLDepart.Items.Insert(aux, new ListItem("YACUIBA", "YACUIBA", true));
                    aux++;
                    break;
                case "COCHABAMBA":
                    DDLDepart.Items.Insert(aux, new ListItem("CHAPARE", "CHAPARE", true));
                    aux++;
                    DDLDepart.Items.Insert(aux, new ListItem("IVIRGARZAMA", "IVIRGARZAMA", true));
                    aux++;
                    break;
                case "ORURO":
                    DDLDepart.Items.Insert(aux, new ListItem("CARACOLLO", "CARACOLLO", true));
                    aux++;
                    break;
            }
        }
        protected void Inicializar_ComboDep(string nombredep, string tipo)
        {
            DB_VT_Viaticos nd = new DB_VT_Viaticos();
            List<VT_Departamento> ListaD = nd.DB_Desplegar_DEPARTAMENTO(nombredep, tipo);
            
            DDLDestino.DataSource = ListaD;
            DDLDestino.DataValueField = "Id_Departamento";
            DDLDestino.DataTextField = "Nombre";
            DDLDestino.DataBind();        
        }
        protected void Deshabilitar_Campos()
        {
            DDLTipSol.Enabled = false;
            DDLTipViaje.Enabled = false;
            DDLTipSalid.Enabled = false;
            DDLDepart.Enabled = false;
        }
        #endregion
        protected void LnkPlanViaje_Click(object sender, EventArgs e)
        {
            //**
            if (DDLDepart.SelectedValue == "0")
            {
                Response.Write("<script>window.alert('Seleccione Lugar de Funciones');</script>");
                LblOrigen.Text = string.Empty;
                return;
            }
            //**
            if (DDLDepart.SelectedValue != "Defina su Salida:")/****************cambio el value del combo*************/
            {
                Deshabilitar_Campos();
                BtnSalida.Visible = true;
                BtnRetorno.Visible = true;
                LnkPlanViaje.Visible = false;
                LblMsj1.Text = string.Empty;
                LblOrigen.Text = DDLDepart.SelectedItem.Text;
            }
            else
            {
                //LblMsj1.Text = "Defina la regional de salida";
                Response.Write("<script>window.alert('Defina la regional de salida');</script>");
            }
        }
        protected void InicializarCampos()
        {
            TxtFecha.Text = String.Empty;
            RDBUrbana.Checked = true;
            RDBRural.Checked = false;
            //LblZona.Text = "Urbana";
            if (RBExterior.Checked != true)
            {
                TxtLugar.Text = String.Empty;
                TxtLugar.Visible = false;
            }
            //LblTexto2.Visible = false;

            TxtObjetiv.Text = String.Empty;
            RDBAereo.Checked = true;
            RDBTerrestre.Checked = false;
            RDBOtros.Checked = false;
            LblMedioTrans.Text = "Aerea";
            RDBParticular.Checked = true;
            RDBEmapa.Checked = false;
            LblTipoTrans.Text = "Particular";
            TxtNomTransporte.Text = String.Empty;
            LblTexto4.Visible = false;
            TxtIdentif.Text = String.Empty;
            TxtIdentif.Visible = false;
            DDLHora.DataBind();
            //DDLDestino.SelectedItem.Text = String.Empty;
        }
        #region FUNCIONES DE CHEKBOX
        protected void RDBUrbana_CheckedChanged(object sender, EventArgs e)
        {
            //lrojas 24/08/2016
            if (RDBUrbana.Checked)
            {
                RDBRural.Checked = false;
                RDBAereo.Checked = true;
                RDBAereo.Enabled = true;
                RDBTerrestre.Checked = false;
                TxtLugar.Text = string.Empty;
            }
            else
            {
                RDBAereo.Checked = false;
                RDBAereo.Enabled = false;
            }
            //**
            InterDepartamental();
        }
        protected void RDBRural_CheckedChanged(object sender, EventArgs e)
        {
            //lrojas 24/08/2016
            if (RDBRural.Checked)
            {
                RDBAereo.Checked = false;
                RDBUrbana.Checked = false;
                RDBAereo.Enabled = false;
                RDBTerrestre.Checked = true;
                RDBEmapa.Enabled = true;
                LblMedioTrans.Text = "Terrestre";//**31082017                
            }
            else
            {
                RDBRural.Checked = false;
                RDBAereo.Checked = true;
                RDBAereo.Enabled = true;
            }
            //**
            InteriorDepto();
        }
        protected void RBExterior_CheckedChanged(object sender, EventArgs e)
        {
            LblTexto2.Visible = true;
            TxtLugar.Visible = true;
            LblZona.Text = "Exterior";
            LblTexto2.Visible = true;
            LblTexto2.Text = "PAÍS:";
            DDLDestino.Visible = false;
        }
        protected void RDBAereo_CheckedChanged(object sender, EventArgs e)
        {
            RDBEmapa.Checked = false;
            RDBEmapa.Enabled = false;
            RDBParticular.Checked = true;
            LblTexto4.Visible = false;
            TxtIdentif.Visible = false;
            LblMedioTrans.Text = "Aerea";
        }
        protected void RDBTerrestre_CheckedChanged(object sender, EventArgs e)
        {
            RDBEmapa.Enabled = true;
            RDBAereo.Checked = true;
            RDBEmapa.Checked = false;
            LblMedioTrans.Text = "Terrestre";
        }
        protected void RDBOtros_CheckedChanged(object sender, EventArgs e)
        {
            LblMedioTrans.Text = "Otros";
        }
        protected void RDBParticular_CheckedChanged(object sender, EventArgs e)
        {
            LblTexto4.Visible = false;
            TxtIdentif.Visible = false;
            LblTipoTrans.Text = "Particular";
        }
        protected void RDBEmapa_CheckedChanged(object sender, EventArgs e)
        {
            LblTexto4.Visible = true;
            TxtIdentif.Visible = true;
            LblTipoTrans.Text = "Emapa";
        }
        #endregion
        protected string ValidarGrilla()
        {
            string aux = "no";
            if (TxtFecha.Text != "")
            {
                //if (TxtObjetiv.Text != "" || LblTipo.Text == "Retorno")
                //    {
                if (TxtNomTransporte.Text != "")
                {
                    if (LblTipoTrans.Text == "Emapa")
                    {
                        if (TxtIdentif.Text != "")
                        {
                            aux = "si";
                            LblMsj1.Text = string.Empty;
                        }
                        else
                        {
                            //LblMsj1.Text = "Necesita especificar la placa del transporte EMAPA";
                            Response.Write("<script>window.alert('Necesita especificar la placa del transporte EMAPA');</script>");
                        }
                    }
                    else
                    {
                        aux = "si";
                        LblMsj1.Text = string.Empty;
                    }
                }
                else
                {
                    //LblMsj1.Text = "Necesita especificar el nombre del transporte";
                    Response.Write("<script>window.alert('Necesita especificar el nombre del transporte');</script>");
                }
                //}
                //else
                //{
                //    LblMsj1.Text = "Necesita especificar el Objetivo que realizara en ese destino";
                //    Response.Write("<script>window.alert('Necesita especificar el Objetivo que realizara en ese destino');</script>");
                //}
            }
            else
            {
                //LblMsj1.Text = "Necesita especificar una fecha de salida";
                Response.Write("<script>window.alert('Necesita especificar una fecha de salida');</script>");
            }
            return aux;
        }
        #region FUNCION ESPECIAL DE REGISTRO DE LOS DATOS DE LA SOLICITU EN LA GRILLA
        protected void BTNRegisDestin_Click(object sender, EventArgs e)
        {
            if (ValidarGrilla() == "si")
            {
                //*ini* lrojas: 27/09/2016 si se selecciona al interior del departamento, se valida que ingrese Lugar
                if (RDBRural.Checked)
                {
                    if (LblTipo.Text == "Salida")
                    {
                        if (TxtLugar.Text.Trim() == string.Empty)
                        {
                            TxtLugar.Focus();
                            string script = @"<script type='text/javascript'>alert('{0}');</script>";
                            string nota = "Ingrese Lugar Destino";
                            script = string.Format(script, nota);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                            return;
                        }
                    }
                }
                //*fin* lrojas: 27/09/2016
                DataTable dt = Session["datos"] as DataTable;
                //**lrojas24/08/2016 // validacion para no repetir registros
                foreach (DataRow dtRow in dt.Rows)
                {
                    if (dtRow["Destino"].ToString() == DDLDestino.SelectedItem.Text)
                    {
                        //string date = TxtFecha.Text + " " + DDLHora.SelectedValue + ":" + DDLMinuto.SelectedValue;
                        DateTime date = Convert.ToDateTime(dtRow["Fecha Salida"].ToString());
                        if (dtRow["Zona"].ToString() == "Al interior del Departamento")
                        {
                            //LblZona.Text = "Al interior del Departamento";
                        }
                        else
                        {
                            if (date.ToShortDateString() == TxtFecha.Text)
                            {
                                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                                string nota = "EL DESTINO: " + DDLDestino.SelectedItem.Text + " YA FUE REGISTRADO EN FECHA: " + TxtFecha.Text;
                                script = string.Format(script, nota);
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                                return;
                            }
                        }
                    }
                }
                //**
                DataRow row = dt.NewRow();
                row["Tramo"] = LblTipo.Text;
                row["Zona"] = LblZona.Text;
                //if (RBExterior.Checked == true)
                //row["Destino"] = RDBRural.Checked ? TxtLugar.Text : DDLDestino.SelectedItem.Text;
                
                //if(RDBRural.Checked)
                    row["Destino"] = DDLDestino.SelectedItem.Text;

                //if (RDBRural.Checked)
                //{
                //    row["Destino"] = TxtLugar.Text;
                //}
                //else
                //{
                //    row["Destino"] = DDLDestino.SelectedItem.Text;
                //}

                if (LblZona.Text == "Interdepartamental")
                {
                    LblOrigen.Text = DDLDestino.SelectedItem.Text;
                }
                else
                {
                    //para rural
                    LblOrigen.Text = TxtLugar.Text;
                }

                row["Lugar"] = TxtLugar.Text;
                row["Objetivo"] = TxtObjetiv.Text;
                row["Fecha Salida"] = TxtFecha.Text + " " + DDLHora.SelectedValue + ":" + DDLMinuto.SelectedValue;
                LblAux.Text = TxtFecha.Text + " " + DDLHora.SelectedValue + ":" + DDLMinuto.SelectedValue;
                row["Via"] = LblMedioTrans.Text;
                row["Tipo"] = LblTipoTrans.Text;
                row["Nombre"] = TxtNomTransporte.Text;
                row["IdenTifi"] = TxtIdentif.Text;
                dt.Rows.Add(row);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Session["datos"] = dt;
                InicializarCampos();
                Panel1.Visible = false;
                if (LblTipo.Text == "Retorno")
                {
                    BtnRetorno.Enabled = false;
                    Panel3.Enabled = true;
                    Panel3.Visible = true;//lrojas
                }
                else
                {
                    BtnRetorno.Enabled = true;
                }
                RDBUrbana.Enabled = false;
                RDBRural.Enabled = false;
            }
        }
        #endregion
        #region FUNCION DE LOS BOTONES DE PLANIFICACION SALIDA Y RETORNO
        protected void BtnRetorno_Click(object sender, EventArgs e)
        {
            BtnSalida.Enabled = false;
            Panel1.Visible = true;
            Panel2.Visible = false;
            //Panel3.Visible = true;
            LblTipo.Text = "Retorno";
            if (LblZona.Text == "Al interior del Departamento")
            {
                RDBRural.Checked = true;
                LblZona.Text = "Al interior del Departamento";
                RDBTerrestre.Checked = true;
                LblMedioTrans.Text = "Terrestre";//**31082017
            }
            else
            {
                RDBUrbana.Checked = true;
                LblZona.Text = "Interdepartamental";
            }
            //RDBRural.Checked = true;
            //LblZona.Text = "Departamental";
            DDLDestino.Items.Clear();
            DDLDestino.Items.Insert(0, new ListItem(DDLDepart.SelectedItem.Text, DDLDepart.SelectedValue, true));
            DDLDestino.Enabled = false;
            DDLHora.SelectedValue = "00";
            DDLMinuto.SelectedValue = "00";
        }
        protected void BtnSalida_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            //Panel2.Visible = true;
            LblTipo.Text = "Salida";
            if (BtnRetorno.Enabled == false)
            {
                LblOrigen.Text = DDLDepart.SelectedItem.Text;
            }
            //else 
            //{
            //    LblOrigen.Text = DDLDestino.SelectedItem.Text;
            //}
            if (LblZona.Text == "Interdepartamental")
            {
                Inicializar_ComboDep(DDLDepart.SelectedValue, LblZona.Text);
                //LblOrigen.Text = DDLDestino.SelectedItem.Text;
            }
            else
            {
                TxtLugar.Text = String.Empty;
                TxtLugar.Visible = true;
                //LblOrigen.Text = TxtLugar.Text;
            }
            DDLHora.SelectedValue = "00";
            DDLMinuto.SelectedValue = "00";
            //**
            RDBUrbana.Enabled = true;
            RDBRural.Enabled = true;
            RDBUrbana.Checked = true;
            RDBAereo.Checked = true;
            RDBAereo.Enabled = true;
            RDBTerrestre.Checked = false;
            LblTexto2.Visible = false;
            TxtLugar.Visible = false;
            LblZona.Text = "Interdepartamental";
            Inicializar_ComboDep(DDLDepart.SelectedValue, LblZona.Text);
            //**
        }
        #endregion
        #region FUNCION DE REGISTRO DE LA SOLICITUD
        protected void Registrar_SOLICITUD()
        {
            /*************** CODIGO DE USIARIO DE LA BASE DE DATOS PRODUCCION ***************/
            DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = Usuario.DB_Desplegar_USUARIO(LblIdUser.Text);
            /*************** INMEDIATO SUPERIOR *************/
            DB_Usuario us = new DB_Usuario();
            DataTable dtus = new DataTable();
            dtus = us.DB_Desplegar_USUARIO(0, LblIdUser.Text, "INMEDIATOSUPERIOR");
            /************* CONTRUCCION DE CODIFICACION **************/
            DB_Codificacion cod = new DB_Codificacion();
            LblIdSolicitud.Text = cod.GetCodigo(Convert.ToInt32(dt.Rows[0][4].ToString()), "VIATICOS");
            DB_VT_Viaticos rs = new DB_VT_Viaticos();
            VT_Solicitud s = new VT_Solicitud();
            s.Id_Solicitud = LblIdSolicitud.Text;
            s.Id_Regional = Convert.ToInt32(dt.Rows[0][4].ToString());
            s.Id_Usuario = LblIdUser.Text;
            s.Tipo_Salida = DDLTipSalid.SelectedValue;
            s.Tipo_Solicitud = DDLTipSol.SelectedValue;
            s.Dep_Salida = DDLDepart.SelectedValue;
            s.Cargo = dt.Rows[0][3].ToString();
            s.ci_Aprobador = dtus.Rows[0][4].ToString();
            s.Cargo_Aprobador = dtus.Rows[0][6].ToString();
            s.Fecha_Solicitud = DateTime.Now;
            s.Fecha_Aprob = DateTime.Now;
            s.Motivo_Viaje = TxtMotiv.Text;
            s.Descrip_Motivo = "";
            s.Tipo_Viaje = DDLTipViaje.SelectedValue;
            s.Estado = "ENVIADO";
            rs.DB_Registrar_SOLICITUD(s);
            Registrar_SOLICITUD_DESTINO();
        }
        protected void Registrar_SOLICITUD_DESTINO()
        {
            DB_VT_Viaticos rsd = new DB_VT_Viaticos();
            VT_SolicitudDestino sd = new VT_SolicitudDestino();
            DataTable dt = Session["datos"] as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sd.Id_Solicitud = LblIdSolicitud.Text;
                sd.Cont = i + 1;
                sd.Tramo = dt.Rows[i][0].ToString();
                sd.Zona = dt.Rows[i][1].ToString();
                sd.Destino = dt.Rows[i][2].ToString();
                sd.Lugar = dt.Rows[i][3].ToString();
                sd.Objetivo = dt.Rows[i][4].ToString();
                sd.Fecha_Salida = Convert.ToDateTime(dt.Rows[i][5].ToString());
                sd.Via_Transporte = dt.Rows[i][6].ToString();
                sd.Tipo_Transporte = dt.Rows[i][7].ToString();
                sd.Nombre_Transporte = dt.Rows[i][8].ToString();
                sd.Identificador_Trasporte = dt.Rows[i][9].ToString();
                rsd.DB_Registrar_SOLICITUD_DESTINO(sd);
            }
        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TxtMotiv.Text != "")
            {
                Registrar_SOLICITUD();
                BtnGuardar.Enabled = false;
                Response.Redirect("frmListaSolicitUs.aspx");
            }
            else
            {
                //LblMsj1.Text = "Necesita especificar el motivo general porque realizara el viaje";
                Response.Write("<script>window.alert('Necesita especificar el motivo general porque realizara el viaje');</script>");
            }
        }
        #endregion

        protected void TxtFecha_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (DDLTipSol.SelectedItem.Text == "DESEMBOLSO")
                {
                    //*ini* lrojas: 05/09/2016 validacion de fechas-feriados
                    DB_AdminUser User = new DB_AdminUser();
                    DataTable dt = User.DB_Desplegar_USUARIO(LblIdUser.Text);
                    string Regional = dt.Rows[0][5].ToString();
                    string IdRegional = dt.Rows[0][4].ToString();
                    //DateTime fechaSeleccionada = Convert.ToDateTime(TxtFecha.Text);
                    //****************************************************************************************************
                    DataTable dtDestino = Session["datos"] as DataTable;
                    List<VT_SolicitudDestino> ColSD = new List<VT_SolicitudDestino>();
                    if (dtDestino.Rows.Count > 0)
                    {
                        DDLFeriados.Items.Clear();
                        foreach (DataRow dtRow in dtDestino.Rows)
                        {
                            if (dtRow["Tramo"].ToString() == "Salida")
                            {
                                VT_SolicitudDestino ObjSD = new VT_SolicitudDestino();
                                ObjSD.Tramo = dtRow["Tramo"].ToString();
                                ObjSD.Zona = dtRow["Zona"].ToString();
                                ObjSD.Destino = dtRow["Destino"].ToString();
                                ObjSD.Lugar = dtRow["Lugar"].ToString();
                                ObjSD.Objetivo = dtRow["Objetivo"].ToString();
                                ObjSD.Fecha_Salida = Convert.ToDateTime(dtRow["Fecha Salida"].ToString());
                                ObjSD.Via_Transporte = dtRow["Via"].ToString();
                                ObjSD.Tipo_Transporte = dtRow["Tipo"].ToString();
                                ObjSD.Nombre_Transporte = dtRow["Nombre"].ToString();
                                ObjSD.Identificador_Trasporte = dtRow["IdenTifi"].ToString();
                                //ObjSD.Cont = Convert.ToInt32(dtRow["Cont"].ToString());
                                ColSD.Add(ObjSD);
                            }
                        }
                        DateTime ultima_f_salida = ColSD.OrderByDescending(x => x.Fecha_Salida).FirstOrDefault().Fecha_Salida; ;
                        if (Convert.ToDateTime(TxtFecha.Text) < Convert.ToDateTime(ultima_f_salida.ToShortDateString()))
                        {
                            Response.Write("<script>window.alert('La fecha debe ser mayor o igual a " + ultima_f_salida.ToShortDateString() + "');</script>");
                            TxtFecha.Text = string.Empty;
                        }
                    }
                    else
                    {
                        fecha_feriado_val(IdRegional, TxtFecha.Text);//** lrojas: 13/09/2016
                    }
                    //****************************************************************************************************
                    //Validaciones_feriados(IdRegional, TxtFecha.Text);  
                }
                else
                {
                    if (Convert.ToDateTime(TxtFecha.Text + " " + DDLHora.SelectedValue + ":" + DDLMinuto.SelectedValue) > Convert.ToDateTime(LblAux.Text))
                    {
                        //LblMsj1.Text = "La fecha No puede ser mayor a la fecha actual, para una solicitud de Reembolso";
                        Response.Write("<script>window.alert('La fecha No puede ser mayor a la fecha actual, para una solicitud de Reembolso');</script>");
                        TxtFecha.Text = string.Empty;
                    }
                    else
                    {
                        LblMsj1.Text = string.Empty;
                    }
                }

                var dtListaPartida = Session["datos"] as DataTable;
                var fechaActual = DateTime.Today.ToShortDateString();
                if (dtListaPartida.Rows.Count > 0)
                {
                    var fechaInicial = Convert.ToDateTime(dtListaPartida.Rows[0].ItemArray[5].ToString()).ToShortDateString();
                    this.tipoViajexFecha(fechaInicial, fechaActual);
                }
                else
                {
                    this.tipoViajexFecha(TxtFecha.Text, fechaActual);
                }
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        protected void tipoViajexFecha(string fecha1, string fecha2)
        {
            if (string.Equals(fecha1, fecha2))
            {
                this.DDLTipViaje.SelectedValue = "EMERGENCIA";
            }
            else
            {
                this.DDLTipViaje.SelectedValue = "POA";
            }
        }
        protected void fecha_feriado_val(string IdRegional, string fecha)
        {
            DDLFeriados.Items.Clear();
            DB_VT_Feriado viat = new DB_VT_Feriado();
            DataTable DT_Feriados = new DataTable();
            DateTime fechaactual = DateTime.Now;
            DateTime fechaSeleccionada = Convert.ToDateTime(fecha);
            if (fechaSeleccionada < Convert.ToDateTime(fechaactual.ToShortDateString()))
            {
                Response.Write("<script>window.alert('Registro fuera de Rango!!!,(Fecha Seleccionada es menor a fecha Actual)');</script>");
                TxtFecha.Text = string.Empty;
                return;
            }
            List<VT_Feriados> ColFeriado = new List<VT_Feriados>();
            DT_Feriados = viat.DB_Feriado_ObtenerListado(Convert.ToInt32(IdRegional));
            foreach (DataRow row in DT_Feriados.Rows)
            {
                VT_Feriados ObjFeriado = new VT_Feriados();
                ObjFeriado.Id_Feriado = Convert.ToInt32(row["Id_Feriado"].ToString());
                ObjFeriado.Id_Regional = Convert.ToInt32(row["Id_Regional"].ToString());
                ObjFeriado.Fecha_Feriado = Convert.ToDateTime(row["Fecha_Feriado"].ToString());
                ObjFeriado.Descripcion = row["Descripcion"].ToString();
                ObjFeriado.Feriado_Nacional = Convert.ToBoolean(row["Feriado_Nacional"].ToString());
                ObjFeriado.Feriado_Departamental = Convert.ToBoolean(row["Feriado_Departamental"].ToString());
                ObjFeriado.Estado = Convert.ToBoolean(row["Estado"].ToString());
                ColFeriado.Add(ObjFeriado);
            }
            //DateTime Ini = Convert.ToDateTime(fechaactual.ToShortDateString());
            DateTime Ini = Convert.ToDateTime(viat.DB_GET_DATE_SERVER().ToShortDateString());
            DateTime Ini_2 = Ini;
            DateTime Fin = Convert.ToDateTime(fechaSeleccionada.ToShortDateString());
            DateTime Fin_2 = Fin;
            int count_diahabil = 0;
            Col_Feriados_VS = new List<VT_Feriados>();
            //if (Ini_2 != Fin_2) //if (Ini_2 != Fin)
            //    Ini_2 = Ini_2.AddDays(1);
            while (Ini_2 <= Fin_2) //while (Ini_2 <= Fin)
            {
                if (Ini_2.DayOfWeek == DayOfWeek.Sunday || Ini_2.DayOfWeek == DayOfWeek.Saturday)
                {
                    //se puede registrar
                    if (Ini_2 == Fin_2)// if (Ini_2 == Fin)
                    {
                        Ini_2 = Ini_2.AddDays(1);
                        Fin_2 = Ini_2; //Fin = Ini_2;
                    }
                    else
                    {
                        Ini_2 = Ini_2.AddDays(1);
                    }
                }
                else
                {
                    VT_Feriados ObjFeriado_fs = ColFeriado.Where(f => f.Fecha_Feriado.ToShortDateString() == Ini_2.ToShortDateString()).SingleOrDefault();
                    if (ObjFeriado_fs != null)
                    {
                        if (Ini_2 == Fin_2) ///if (Ini_2 == Fin)
                        {
                            Ini_2 = Ini_2.AddDays(1);
                            Fin_2 = Ini_2; //Fin = Ini_2;
                        }
                        else
                        {
                            Ini_2 = Ini_2.AddDays(1);
                        }
                        //**
                        Col_Feriados_VS.Add(ObjFeriado_fs);
                        //**
                    }
                    else
                    {
                        Ini_2 = Ini_2.AddDays(1);
                        count_diahabil++;
                        if (count_diahabil > 2)
                        {
                            DDLFeriados.Items.Insert(0, new ListItem("Feriados Registrados", "0", true));
                            int aux = 1;
                            foreach (VT_Feriados row in Col_Feriados_VS)
                            {
                                DateTime ff = row.Fecha_Feriado;
                                string text = ff.ToShortDateString() + " " + row.Descripcion;
                                string value = ff.ToShortDateString();
                                DDLFeriados.Items.Insert(aux, new ListItem(text, value, true));
                                aux++;
                            }
                            DDLFeriados.DataBind();

                            Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
                            TxtFecha.Text = string.Empty;
                            return;
                        }

                    }
                }
            }
            // actualiza la fecha seleccionada (fin)
            //**
            DDLFeriados.Items.Insert(0, new ListItem("Feriados Registrados", "0", true));
            int index = 1;
            foreach (VT_Feriados row in Col_Feriados_VS)
            {
                DateTime ff = row.Fecha_Feriado;
                string text = ff.ToShortDateString() + " " + row.Descripcion;
                string value = ff.ToShortDateString();
                DDLFeriados.Items.Insert(index, new ListItem(text, value, true));
                index++;
            }
            DDLFeriados.DataBind();
            //**
            TxtFecha.Text = Fin.ToShortDateString();//TxtFecha.Text = Fin.ToShortDateString();
            DateTime F_Sel = Convert.ToDateTime(TxtFecha.Text);
            if (Convert.ToDateTime(F_Sel.ToShortDateString()) >= Convert.ToDateTime(Ini.ToShortDateString()))
            {
                if (Convert.ToDateTime(F_Sel.ToShortDateString()) <= Convert.ToDateTime(Fin_2.ToShortDateString()))
                {
                    // dentro de este rango puede registrar solicitud.
                }
                else
                {
                    Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
                    TxtFecha.Text = string.Empty;
                    return;
                }
            }
            else
            {
                Response.Write("<script>window.alert('Registro fuera de Rango!!!');</script>");
                TxtFecha.Text = string.Empty;
                return;
            }
            //*****  
            ////DDLFeriados.Items.Clear();
            //DDLFeriados.Items.Insert(0, new ListItem("Feriados Registrados", "0", true));
            //int index = 1;
            //foreach (VT_Feriados row in Col_Feriados_VS)
            //{
            //    DateTime ff = row.Fecha_Feriado;
            //    string text = ff.ToShortDateString() + " " + row.Descripcion;
            //    string value = ff.ToShortDateString();
            //    DDLFeriados.Items.Insert(index, new ListItem(text, value, true));
            //    index++;
            //}
            //DDLFeriados.DataBind();
            ////string diaSemana = fechaSeleccionada.DayOfWeek.ToString();            
        }
        protected void DDLDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RDBRural.Checked)
            {
                RDBUrbana.Checked = false;
                InteriorDepto();
            }
            else
            {
                RDBRural.Checked = false;
                this.Session["indiceDestino"] = DDLDestino.SelectedValue;
                InterDepartamental();                
            }
        }
        protected void DDLDepart_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblOrigen.Text = DDLDepart.SelectedItem.Text;

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void DDLTipSalid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLTipSalid.SelectedValue == "EXTERIOR")
            {
                RBExterior.Enabled = true;
                RBExterior.Visible = true;
            }
        }
        protected void InteriorDepto()
        {
            LblTexto2.Visible = true;
            TxtLugar.Visible = true;
            LblZona.Text = "Al interior del Departamento";
            DDLDestino.Visible = true;
            LblTexto2.Text = "Lugar:";
            string aux = DDLDepart.SelectedValue;
            switch (DDLDepart.SelectedValue)
            {
                case "YACUIBA":
                    aux = "TARIJA";
                    break;
                case "4 CAÑADAS":
                    aux = "SANTA CRUZ";
                    break;
                case "SAN PEDRO":
                    aux = "SANTA CRUZ";
                    break;
                case "MONTERO":
                    aux = "SANTA CRUZ";
                    break;
                case "YAPACANI":
                    aux = "SANTA CRUZ";
                    break;
                case "CABEZAS":
                    aux = "SANTA CRUZ";
                    break;
                case "SAN JULIAN":
                    aux = "SANTA CRUZ";
                    break;
                case "CHAPARE":
                    aux = "COCHABAMBA";
                    break;
                case "IVIRGARZAMA":
                    aux = "COCHABAMBA";
                    break;
                case "CARACOLLO":
                    aux = "ORURO";
                    break;
            }
            Inicializar_ComboDep(aux, LblZona.Text); /****************cambio el value del combo**/
        }
        protected void InterDepartamental()
        {
            LblTexto2.Visible = false;
            TxtLugar.Visible = false;
            LblZona.Text = "Interdepartamental";
            Inicializar_ComboDep(DDLDepart.SelectedValue, LblZona.Text);/****************cambio el value del combo**/
            if(this.Session["indiceDestino"] != null)
            {
                DDLDestino.SelectedValue = this.Session["indiceDestino"].ToString();
            }            
        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}