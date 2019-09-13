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
using System.Text;

namespace WebAplication.Viaticos
{
    public partial class frmRealizarSolicitud_AddRow : System.Web.UI.Page
    {
        /// <summary>
        /// IdSolicitud pasado por parametro(frmModificarSolicitud) para agregar una nueva fila
        /// </summary>
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
        private bool flag_Origen
        {
            get
            {
                if (ViewState["flag_Origen"] != null)
                    return (bool)ViewState["flag_Origen"];

                return false;
            }
            set { ViewState["flag_Origen"] = value; }
        }         
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
        protected List<VT_SolicitudDestino> registroSolicitudDestino(string P_IdSolicitud)
        {
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            DataTable DT_Sol_Des = new DataTable();
            DT_Sol_Des = sol.DB_Desplegar_SOLICITUD_DESTINOS(P_IdSolicitud);
            List<VT_SolicitudDestino> ColSD = new List<VT_SolicitudDestino>();
            foreach (DataRow r in DT_Sol_Des.Rows)
            {
                if (r["Tramo"].ToString() == "Salida")
                {
                    if (Convert.ToInt32(r["Cont"]) > 0)//lrojas: 26/09/2016
                    {
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
                    }
                }
            }
            Session["datos"] = DT_Sol_Des;
            return ColSD;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {                
                if (!IsPostBack)
                {
                    LblAux.Text = DateTime.Now.ToString();
                    LblIdUser.Text = Session["IdUser"].ToString();                    
                    P_IdSolicitud = Convert.ToString(Request.QueryString["IdSolicitud"]);
                    if (P_IdSolicitud == string.Empty)
                    {
                        LblMsj1.Text = "IdSolicitud Vacio!!";
                        return;
                    }
                    DB_AdminUser User = new DB_AdminUser();
                    DataTable dt = User.DB_Desplegar_USUARIO(LblIdUser.Text);                    
                    string name_reg = dt.Rows[0][5].ToString();                   
                    //**
                    Inicializar_ComboReg(name_reg);
                    DDLDepart.SelectedValue = name_reg;
                    Inicializar_ComboDep(DDLDepart.SelectedValue, LblZona.Text);/**************** cambio el value del combo ******************/
                    //DataTable dtListaPartida = new DataTable();
                    //dtListaPartida.Columns.AddRange(new DataColumn[10] { new DataColumn("Tramo"), new DataColumn("Zona"), new DataColumn("Destino"), new DataColumn("Lugar"), new DataColumn("Objetivo"), new DataColumn("Fecha Salida"), new DataColumn("Via"), new DataColumn("Tipo"), new DataColumn("Nombre"), new DataColumn("IdenTifi") });
                    //GridView1.DataSource = dtListaPartida;
                    //GridView1.DataBind();
                    DataTable DT_Solicitud = new DataTable();
                    DataTable DT_Sol_Des = new DataTable();
                    DB_VT_Solicitud sol = new DB_VT_Solicitud();
                    DT_Solicitud = sol.DB_Reporte_SOLICITUD_US(P_IdSolicitud, "ENCABEZADO");
                    foreach (DataRow row in DT_Solicitud.Rows)
                    { 
                        string Tipo_Sol = row["Tipo_Solicitud"].ToString();
                        string Tipo_Viaje = row["Tipo_Viaje"].ToString();
                        string Regional = row["Nombre"].ToString();//nombre Regional
                        TxtMotiv.Text = row["Motivo_Viaje"].ToString();                        
                        DDLTipSol.SelectedValue = Tipo_Sol;
                        DDLTipViaje.SelectedValue = Tipo_Viaje;
                        DDLDepart.SelectedValue = Regional;
                    }
                    //VT_SolicitudDestino ObjSD = new VT_SolicitudDestino();                    
                        var ColSD = this.registroSolicitudDestino(P_IdSolicitud);
                    if (ColSD.Count>0)
                    {
                        string salida = ColSD.OrderByDescending(x => x.Fecha_Salida).FirstOrDefault().Destino;
                        LblOrigen.Text = salida;
                    }
                    
                    flag_Origen = true;
                    GridView1.DataSource = DT_Sol_Des;
                    GridView1.DataBind();
                    //Session["datos"] = DT_Sol_Des;                    
                    LnkPlanViaje_Click(sender,e);
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
        #region OBTENER LA LISTA DE SOLICITUDES
        protected void Desplegar_SOLICITUD_DESTINOS()
        {
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            GridView1.DataSource = lista.DB_Desplegar_SOLICITUD_DESTINOS(P_IdSolicitud);
            GridView1.DataBind();
        }
        #endregion
        #region FUNCIONES INDEPENDIENTES
        protected void Inicializar_ComboReg(string name_reg)
        {
            /************** DEPARTAMENTOS **************/
            DB_Regional r = new DB_Regional();
            List<Regional> listaR = r.DB_Desplegar_REGIONAL();
            int aux = 0;
            DDLDepart.Items.Clear();
            foreach (Regional row in listaR)
            {
                string text = row.Nombre;
                string value = row.Nombre; //row.Id_Regional.ToString();
                DDLDepart.Items.Insert(aux, new ListItem(text, value, true));
                aux++;
            }

            switch (name_reg)
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
                    break;
                case "TARIJA":
                    DDLDepart.Items.Insert(aux, new ListItem("YACUIBA", "YACUIBA", true));
                    aux++;
                    break;
                case "COCHABAMBA":
                    DDLDepart.Items.Insert(aux, new ListItem("CHAPARE", "CHAPARE", true));
                    aux++;
                    break;
            }

            DDLDepart.DataBind();
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
            if (DDLDepart.SelectedValue != "Defina su Salida:")/****************cambio el value del combo*************/
            {
                Deshabilitar_Campos();
                BtnSalida.Visible = true;
                BtnRetorno.Visible = true;
                LnkPlanViaje.Visible = false;
                LblMsj1.Text = string.Empty;
                //if(flag_Origen==false)
                  //  LblOrigen.Text = DDLDepart.SelectedItem.Text;
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
            LblMedioTrans.Text = "Aereo";
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
            if (RDBUrbana.Checked == true)
            {
                RDBAereo.Checked = true;
                RDBAereo.Enabled = true;
                RDBTerrestre.Checked = false;
            }
            else
            {
                RDBAereo.Checked = false;
                RDBAereo.Enabled = false;
            }
            //**
            LblTexto2.Visible = false;
            TxtLugar.Visible = false;
            LblZona.Text = "Interdepartamental";
            Inicializar_ComboDep(DDLDepart.SelectedValue, LblZona.Text);/****************cambio el value del combo**/
        }

        protected void RDBRural_CheckedChanged(object sender, EventArgs e)
        {
            //lrojas 24/08/2016
            if (RDBRural.Checked == true)
            {
                RDBAereo.Checked = false;
                RDBAereo.Enabled = false;
                RDBTerrestre.Checked = true;
            }
            else
            {
                RDBAereo.Checked = true;
                RDBAereo.Enabled = true;
            }
            //**
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
                case "CHAPARE":
                    aux = "COCHABAMBA";
                    break;
            }
            Inicializar_ComboDep(aux, LblZona.Text); /****************cambio el value del combo**/
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
            LblMedioTrans.Text = "Aereo";
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
            DataTable dt = Session["datos"] as DataTable;
            foreach (DataRow dtRow in dt.Rows)
            {
                string lugarRegistro= dtRow["lugar"].ToString();
                string tramoRegistro = dtRow["tramo"].ToString();
                string fechaRegistro = dtRow["fecha_salida"].ToString();
                var fechaUnicamenteRegistro = fechaRegistro.Split(' ');
                string fechaElegida = this.TxtFecha.Text;
                String horaMinuto = this.DDLHora.Text + ":" + this.DDLMinuto.Text + ":00";
                if (RDBRural.Checked)
                {
                    if (tramoRegistro == "Salida" && !string.IsNullOrEmpty(fechaElegida))
                    {
                        //8:30:00
                        
                        if (Convert.ToDateTime(fechaUnicamenteRegistro[0]) == Convert.ToDateTime(fechaElegida) &&
                               fechaUnicamenteRegistro[1] == horaMinuto)
                        {
                            string script = @"<script type='text/javascript'>alert('{0}');</script>";
                            string nota = "La Fecha ya fue registrada";
                            script = string.Format(script, nota);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                            return;
                        }

                    }
                    /*else
                    {
                        string script = @"<script type='text/javascript'>alert('{0}');</script>";
                        string nota = "La fecha no fue seleccionada.";
                        script = string.Format(script, nota);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        return;
                    }*/
                }
                else
                {
                    if (Convert.ToDateTime(fechaUnicamenteRegistro[0]) == Convert.ToDateTime(fechaElegida) &&
                                fechaUnicamenteRegistro[1] == horaMinuto)
                    {
                        string script = @"<script type='text/javascript'>alert('{0}');</script>";
                        string nota = "La Fecha ya fue registrada";
                        script = string.Format(script, nota);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        return;
                    }
                }

            }
                if (ValidarGrilla() == "si")
            {
                //*ini* lrojas: 28/09/2016 si se selecciona al interior del departamento, se valida que ingrese Lugar
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
                #region
                /*
                //DataTable dt = Session["datos"] as DataTable;
                
                foreach (DataRow dtRow in dt.Rows)
                {
                    string lugarDestino = dtRow["Destino"].ToString();
                    string fechaSalida = dtRow["Fecha_Salida"].ToString();
                    string valorTramo = dtRow["Tramo"].ToString();

                    if (valorTramo == "Retorno")
                    {
                        if (DateTime.Parse(fechaSalida) == DateTime.Parse(TxtFecha.Text))
                        {
                            string mensajeNota = "LA FECHA DE SALIDA DEL REGISTRO QUE DESEA INGRESAR ES MAYOR O IGUAL A LA FECHA DE RETORNO" + TxtFecha.Text;
                            this.mensajePorCondicion(mensajeNota);
                            return;
                        }
                    }
                    else
                    {
                        if (lugarDestino == DDLDestino.SelectedItem.Text)
                        {
                            if (DateTime.Parse(fechaSalida) == DateTime.Parse(TxtFecha.Text))
                            {
                                string mensajeNota = "EL DESTINO: " + DDLDestino.SelectedItem.Text + " YA FUE REGISTRADO CON LA MISMA FECHA: " + TxtFecha.Text;
                                this.mensajePorCondicion(mensajeNota);
                                return;
                            }
                            if (DateTime.Parse(TxtFecha.Text) <= DateTime.Parse(fechaSalida))
                            {
                                string mensajeNota = "EL DESTINO: " + DDLDestino.SelectedItem.Text + " TIENE UNA FECHA IGUAL O MAYOR A LA DE FECHA RETORNO, MODIFIQUE LA FECHA DE RETORNO O MODIFIQUE LA FECHA DEL REGISTRO INGRESADO." + TxtFecha.Text;
                                this.mensajePorCondicion(mensajeNota);
                                return;
                            }

                            #region
                            //DateTime date = Convert.ToDateTime(dtRow["Fecha_Salida"].ToString());
                            //if (dtRow["Zona"].ToString() == "Al interior del Departamento")
                            //{
                            //    //LblZona.Text = "Al interior del Departamento";
                            //}
                            //else
                            //{
                            //    if (date.ToShortDateString() == TxtFecha.Text)
                            //    {
                            //        string script = @"<script type='text/javascript'>alert('{0}');</script>";
                            //        string nota = "EL DESTINO: " + DDLDestino.SelectedItem.Text + " YA FUE REGISTRADO EN FECHA: " + TxtFecha.Text;
                            //        script = string.Format(script, nota);
                            //        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                            //        return;
                            //    }
                            //}
                            #endregion
                        }
                    }                   
                }
                */
                #endregion
                DataRow row = dt.NewRow();
                #region
                //row["Tramo"] = LblTipo.Text;
                //row["Zona"] = LblZona.Text;
                //if (RBExterior.Checked == true)
                //{
                //    row["Destino"] = TxtLugar.Text;
                //}
                //else
                //{
                //    row["Destino"] = DDLDestino.SelectedItem.Text;
                //}

                //if (LblZona.Text == "Interdepartamental")
                //{
                //    LblOrigen.Text = DDLDestino.SelectedItem.Text;
                //}
                //else
                //{
                //    LblOrigen.Text = TxtLugar.Text;
                //}

                //row["Lugar"] = TxtLugar.Text;
                //row["Objetivo"] = TxtObjetiv.Text;
                //row["Fecha_Salida"] = TxtFecha.Text + " " + DDLHora.SelectedValue + ":" + DDLMinuto.SelectedValue;
                //LblAux.Text = TxtFecha.Text + " " + DDLHora.SelectedValue + ":" + DDLMinuto.SelectedValue;
                //row["Via_Transporte"] = LblMedioTrans.Text;
                //row["Tipo_Transporte"] = LblTipoTrans.Text;
                //row["Nombre_Transporte"] = TxtNomTransporte.Text;
                //row["Identificador_Trasporte"] = TxtIdentif.Text;
                //row["Cont"] = "-1";
                //dt.Rows.Add(row);
                #endregion
                DataTable tablaConNuevoRegistro = this.vaciadoRegistros(row, dt);

                GridView1.DataSource = tablaConNuevoRegistro;
                GridView1.DataBind();
                Session["datos"] = tablaConNuevoRegistro;
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
                Panel3.Enabled = true;
                Panel3.Visible = true;//lrojas
            }
        }
        #endregion
        #region FUNCION DE LOS BOTONES DE PLANIFICACION SALIDA Y RETORNO
        protected void BtnRetorno_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {               
                string tramo = row.Cells[0].Text;
                int Cont = Convert.ToInt32(row.Cells[11].Text);
                if (tramo == "Retorno" && Cont > 0)
                {
                    LblMsj1.Text = "Ya se registro Retorno";
                    return;
                }                
            }

            BtnSalida.Enabled = false;
            Panel1.Visible = true;
            Panel2.Visible = false;
            //Panel3.Visible = true;
            LblTipo.Text = "Retorno";
            if (LblZona.Text == "Al interior del Departamento")
            {
                RDBRural.Checked = true;
                LblZona.Text = "Al interior del Departamento";
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
        }
        protected void BtnSalida_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            //Panel2.Visible = true;
            LblTipo.Text = "Salida";
            if (BtnRetorno.Enabled == false)
            {
                if(flag_Origen==false)
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
            flag_Origen = false;
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

        protected void mensajePorCondicion(string cadenaNota)
        {
            string script = @"<script type='text/javascript'>alert('{0}');</script>";
            //string nota = "EL DESTINO: " + DDLDestino.SelectedItem.Text + " YA FUE REGISTRADO EN FECHA: " + TxtFecha.Text;
            script = string.Format(script, cadenaNota);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        protected DataTable vaciadoRegistros(DataRow row, DataTable dt)
        {
            row["Tramo"] = LblTipo.Text;
            row["Zona"] = LblZona.Text;
            row["Destino"] = RBExterior.Checked ? TxtLugar.Text : DDLDestino.SelectedItem.Text;
            LblOrigen.Text = LblZona.Text == "Interdepartamental" ? DDLDestino.SelectedItem.Text : TxtLugar.Text;
            row["Lugar"] = TxtLugar.Text;
            row["Objetivo"] = TxtObjetiv.Text;
            row["Fecha_Salida"] = TxtFecha.Text + " " + DDLHora.SelectedValue + ":" + DDLMinuto.SelectedValue;
            LblAux.Text = TxtFecha.Text + " " + DDLHora.SelectedValue + ":" + DDLMinuto.SelectedValue;
            row["Via_Transporte"] = LblMedioTrans.Text;
            row["Tipo_Transporte"] = LblTipoTrans.Text;
            row["Nombre_Transporte"] = TxtNomTransporte.Text;
            row["Identificador_Trasporte"] = TxtIdentif.Text;
            row["Cont"] = "-1";
            dt.Rows.Add(row);
            return dt;
        }
               
        protected void Registrar_SOLICITUD_DESTINO()
        {
            DB_VT_Viaticos rsd = new DB_VT_Viaticos();
            VT_SolicitudDestino regSolicitudDestino = new VT_SolicitudDestino();
            DataTable sesionDatos= Session["datos"] as DataTable;
            string idSolicitud = sesionDatos.Rows[0].ItemArray[0].ToString();
            rsd.DB_Eliminar_SOLICITUD_DESTINO(idSolicitud);
            int Cantidad_Cont = 1;
            for (int i = 0; i < sesionDatos.Rows.Count; i++)
            {
                string tramo = sesionDatos.Rows[i][2].ToString();
                if (tramo == "Salida")
                {
                    this.InsertSolicitudDestino(sesionDatos, Cantidad_Cont, i, regSolicitudDestino, rsd);
                    Cantidad_Cont++;
                }
            }

            for (int i = 0; i < sesionDatos.Rows.Count; i++)
            {
                string tramo = sesionDatos.Rows[i][2].ToString();
                if (tramo == "Retorno")
                {
                    this.InsertSolicitudDestino(sesionDatos, Cantidad_Cont, i, regSolicitudDestino, rsd);                                        
                    Cantidad_Cont++;
                    break;
                }                
            }
        }

        private void InsertSolicitudDestino(DataTable sesionDatos,int Cantidad_Cont, int i, VT_SolicitudDestino regSolicitudDestino, DB_VT_Viaticos rsd)
        {
            regSolicitudDestino.Id_Solicitud = P_IdSolicitud;
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            regSolicitudDestino.Cont = Cantidad_Cont;
            regSolicitudDestino.Tramo = sesionDatos.Rows[i][2].ToString();
            regSolicitudDestino.Zona = sesionDatos.Rows[i][5].ToString();
            regSolicitudDestino.Destino = sesionDatos.Rows[i][6].ToString();
            regSolicitudDestino.Lugar = sesionDatos.Rows[i][7].ToString();
            regSolicitudDestino.Objetivo = sesionDatos.Rows[i][8].ToString();
            regSolicitudDestino.Fecha_Salida = Convert.ToDateTime(sesionDatos.Rows[i][9].ToString());
            regSolicitudDestino.Via_Transporte = sesionDatos.Rows[i][10].ToString();
            regSolicitudDestino.Tipo_Transporte = sesionDatos.Rows[i][11].ToString();
            regSolicitudDestino.Nombre_Transporte = sesionDatos.Rows[i][12].ToString();
            regSolicitudDestino.Identificador_Trasporte = sesionDatos.Rows[i][13].ToString();
            rsd.DB_Registrar_SOLICITUD_DESTINO(regSolicitudDestino);
        }


        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TxtMotiv.Text != "")
            {
                //Registrar_SOLICITUD();
                Registrar_SOLICITUD_DESTINO();
                BtnGuardar.Enabled = false;
                string idsolicitud = P_IdSolicitud;               
                //Response.Redirect("frmModificarSolicitud.aspx?IdSolicitud=" + idsolicitud);

                StringBuilder sbMensaje = new StringBuilder();
                sbMensaje.Append("<script type='text/javascript'>");
                sbMensaje.AppendFormat("window.close");
                sbMensaje.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());

                Response.Redirect("frmModificarSolicitud.aspx?IdSolicitud=" + idsolicitud);
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
                    //DataTable dtDestino = Session["datos"] as DataTable;
                    if (dtDestino.Rows.Count > 0)
                    {
                        DDLFeriados.Items.Clear();
                        foreach (DataRow r in dtDestino.Rows)
                        {
                            // if (r["Tramo"].ToString() == "Salida" && Convert.ToInt16(r["Cont"].ToString()) > 0)
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
                        DateTime ultima_f_salida = ColSD.OrderByDescending(x => x.Fecha_Salida).FirstOrDefault().Fecha_Salida;
                        var fechaSalida = (ultima_f_salida.ToString().Split())[0];
                        
                        /*if (Convert.ToDateTime(TxtFecha.Text) < Convert.ToDateTime(ultima_f_salida.ToShortDateString()))
                        {
                            Response.Write("<script>window.alert('La fecha debe ser mayor o igual a " + ultima_f_salida.ToShortDateString() + "');</script>");
                            TxtFecha.Text = string.Empty;
                        }*/
                        if (DateTime.Parse(fechaSalida) < DateTime.Parse(TxtFecha.Text))
                        {
                            Response.Write("<script>window.alert('La fecha que ingreso es Mayor o igual a la fecha de Retorno verifique. " + ultima_f_salida.ToShortDateString() + "');</script>");
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

            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }

        protected void Validaciones_feriados(string IdRegional, string fecha)
        {            
            //DB_VT_Feriado viat = new DB_VT_Feriado();
            //DataTable DT_Feriados = new DataTable();
            //List<VT_Feriados> ColFeriado = new List<VT_Feriados>();
            //DT_Feriados = viat.DB_Feriado_ObtenerListado(Convert.ToInt32(IdRegional));
            //foreach (DataRow row in DT_Feriados.Rows)
            //{
            //    VT_Feriados ObjFeriado = new VT_Feriados();
            //    ObjFeriado.Id_Feriado = Convert.ToInt32(row["Id_Feriado"].ToString());
            //    ObjFeriado.Id_Regional = Convert.ToInt32(row["Id_Regional"].ToString());
            //    ObjFeriado.Fecha_Feriado = Convert.ToDateTime(row["Fecha_Feriado"].ToString());
            //    ObjFeriado.Descripcion = row["Descripcion"].ToString();
            //    ObjFeriado.Feriado_Nacional = Convert.ToBoolean(row["Feriado_Nacional"].ToString());
            //    ObjFeriado.Feriado_Departamental = Convert.ToBoolean(row["Feriado_Departamental"].ToString());
            //    ObjFeriado.Estado = Convert.ToBoolean(row["Estado"].ToString());
            //    ColFeriado.Add(ObjFeriado);
            //}
            ////*ini 06/09/2016* lrojas:                                        
            //DateTime fechaactual = DateTime.Now;
            ////DateTime fechaSeleccionada = Convert.ToDateTime(TxtFecha.Text);
            //DateTime fechaSeleccionada = Convert.ToDateTime(fecha);
            //string diaSemana = fechaSeleccionada.DayOfWeek.ToString();
            //switch (diaSemana)
            //{
            //    case "Saturday":
            //        VT_Feriados ObjFeriadoS = ColFeriado.Where(f => f.Fecha_Feriado.ToShortDateString() == Convert.ToDateTime(fechaSeleccionada.AddDays(-1)).ToShortDateString()).SingleOrDefault();
            //        DateTime factual0 = Convert.ToDateTime(fechaactual.ToShortDateString());
            //        DateTime fferiado0 = new DateTime();
            //        // si el viernes es feriado
            //        if (ObjFeriadoS != null)
            //        {
            //            //el registro se lo puede realizar un dia antes (jueves)
            //            DateTime FFeriado = ObjFeriadoS.Fecha_Feriado.AddDays(-1);
            //            fferiado0 = Convert.ToDateTime(FFeriado.ToShortDateString());
            //            if (factual0 < fferiado0)
            //            {
            //                Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
            //                TxtFecha.Text = string.Empty;
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            //if (fechaactual.Day < fechaSeleccionada.AddDays(-2).Day)
            //            if (factual0 < fechaSeleccionada.AddDays(-1))
            //            {
            //                Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
            //                TxtFecha.Text = string.Empty;
            //                return;
            //            }
            //        }
            //    break;
            //    case "Sunday":
            //        VT_Feriados ObjFeriadoD = ColFeriado.Where(f => f.Fecha_Feriado.ToShortDateString() == Convert.ToDateTime(fechaSeleccionada.AddDays(-2)).ToShortDateString()).SingleOrDefault();
            //        DateTime factual1 = Convert.ToDateTime(fechaactual.ToShortDateString());
            //        DateTime fferiado1 = new DateTime();
            //        if (ObjFeriadoD != null)
            //        {
            //            DateTime FFeriado = ObjFeriadoD.Fecha_Feriado.AddDays(-2);
            //            fferiado1 = Convert.ToDateTime(FFeriado.ToShortDateString());
            //            if (factual1 < fferiado1)
            //            {
            //                Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
            //                TxtFecha.Text = string.Empty;
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            if (factual1 < fechaSeleccionada.AddDays(-2))
            //            {
            //                Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
            //                TxtFecha.Text = string.Empty;
            //                return;
            //            }
            //        }
            //    break;
            //    case "Monday"://lunes
            //        VT_Feriados ObjFeriadoL = ColFeriado.Where(f => f.Fecha_Feriado.ToShortDateString() == Convert.ToDateTime(fechaSeleccionada).ToShortDateString()).SingleOrDefault();
            //        DateTime factual2 = Convert.ToDateTime(fechaactual.ToShortDateString());
            //        DateTime fferiado2 = new DateTime();
            //        if (ObjFeriadoL != null)
            //        {
            //            if (factual2 == Convert.ToDateTime(fechaSeleccionada.ToShortDateString()))
            //            {
            //                // se puede registrar
            //            }
            //            else 
            //            {
            //                DateTime FFeriado = ObjFeriadoL.Fecha_Feriado.AddDays(-3);                            
            //                //string fechaset = FFeriado.ToShortDateString(); //**
            //                //Validaciones_feriados(IdRegional, fechaset);    //**
            //                string dia2 = FFeriado.DayOfWeek.ToString();
            //                if (dia2 == "Friday")
            //                {
            //                    VT_Feriados ObjFeriado_ = ColFeriado.Where(f => f.Fecha_Feriado.ToShortDateString() == Convert.ToDateTime(FFeriado).ToShortDateString()).SingleOrDefault();
            //                    DateTime factual_ = Convert.ToDateTime(fechaactual.ToShortDateString());
            //                    DateTime fferiado_ = new DateTime();
            //                    if (ObjFeriado_ != null)
            //                    {
            //                        if (factual_ == Convert.ToDateTime(FFeriado.ToShortDateString()))
            //                        {
            //                            // se puede registrar
            //                        }
            //                        else
            //                        {
            //                            DateTime FFeriado_ = ObjFeriado_.Fecha_Feriado.AddDays(-1);
            //                            fferiado_ = Convert.ToDateTime(FFeriado_.ToShortDateString());
            //                            if (factual_ < fferiado_)
            //                            {
            //                                Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
            //                                TxtFecha.Text = string.Empty;
            //                                return;
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (factual_ == Convert.ToDateTime(FFeriado.ToShortDateString()))
            //                        {
            //                            // se puede registrar
            //                        }
            //                        else
            //                        {
            //                            if (factual_ < FFeriado.AddDays(-1))
            //                            {
            //                                Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
            //                                TxtFecha.Text = string.Empty;
            //                                return;
            //                            }
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    fferiado2 = Convert.ToDateTime(FFeriado.ToShortDateString());
            //                    if (factual2 < fferiado2)
            //                    {
            //                        Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
            //                        TxtFecha.Text = string.Empty;
            //                        return;
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (factual2 == Convert.ToDateTime(fechaSeleccionada.ToShortDateString()))
            //            {
            //                // se puede registrar
            //            }
            //            else
            //            {
            //                if (factual2 < fechaSeleccionada.AddDays(-3))
            //                {
            //                    Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
            //                    TxtFecha.Text = string.Empty;
            //                    return;
            //                }
            //            }
            //        }
            //    break;
            //    //*************************************************************************************************************************************************
            //    case "Tuesday"://martes
            //        VT_Feriados ObjFeriadoM = ColFeriado.Where(f => f.Fecha_Feriado.ToShortDateString() == Convert.ToDateTime(fechaSeleccionada).ToShortDateString()).SingleOrDefault();
            //        DateTime factual3 = Convert.ToDateTime(fechaactual.ToShortDateString());
            //        DateTime fferiado3 = new DateTime();
            //        if (ObjFeriadoM != null)
            //        {
            //            if (factual3 == Convert.ToDateTime(fechaSeleccionada.ToShortDateString()))
            //            {
            //                // se puede registrar
            //            }
            //            else
            //            {
            //                DateTime FFeriado = ObjFeriadoM.Fecha_Feriado.AddDays(-1);
            //                fferiado3 = Convert.ToDateTime(FFeriado.ToShortDateString());
            //                if (factual3 < fferiado3)
            //                {
            //                    Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
            //                    TxtFecha.Text = string.Empty;
            //                    return;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (factual3 == Convert.ToDateTime(fechaSeleccionada.ToShortDateString()))
            //            {
            //                // se puede registrar
            //            }
            //            else
            //            {
            //                if (factual3 < fechaSeleccionada.AddDays(-1))
            //                {
            //                    Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
            //                    TxtFecha.Text = string.Empty;
            //                    return;
            //                }
            //            }
            //        }
            //    break;
            //    case "Wednesday"://miercoles
            //        VT_Feriados ObjFeriadoMr = ColFeriado.Where(f => f.Fecha_Feriado.ToShortDateString() == Convert.ToDateTime(fechaSeleccionada).ToShortDateString()).SingleOrDefault();
            //        DateTime factual4 = Convert.ToDateTime(fechaactual.ToShortDateString());
            //        DateTime fferiado4 = new DateTime();
            //        if (ObjFeriadoMr != null)
            //        {
            //            if (factual4 == Convert.ToDateTime(fechaSeleccionada.ToShortDateString()))
            //            {
            //                // se puede registrar
            //            }
            //            else
            //            {
            //                DateTime FFeriado = ObjFeriadoMr.Fecha_Feriado.AddDays(-1);
            //                fferiado4 = Convert.ToDateTime(FFeriado.ToShortDateString());
            //                if (factual4 < fferiado4)
            //                {
            //                    Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
            //                    TxtFecha.Text = string.Empty;
            //                    return;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (factual4 == Convert.ToDateTime(fechaSeleccionada.ToShortDateString()))
            //            {
            //                // se puede registrar
            //            }
            //            else
            //            {
            //                if (factual4 < fechaSeleccionada.AddDays(-1))
            //                {
            //                    Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
            //                    TxtFecha.Text = string.Empty;
            //                    return;
            //                }
            //            }
            //        }
            //    break;
            //    case "Thursday":
            //        VT_Feriados ObjFeriadoJ = ColFeriado.Where(f => f.Fecha_Feriado.ToShortDateString() == Convert.ToDateTime(fechaSeleccionada).ToShortDateString()).SingleOrDefault();
            //        DateTime factual5 = Convert.ToDateTime(fechaactual.ToShortDateString());
            //        DateTime fferiado5 = new DateTime();
            //        if (ObjFeriadoJ != null)
            //        {
            //            DateTime FFeriado = ObjFeriadoJ.Fecha_Feriado.AddDays(-1);
            //            fferiado5 = Convert.ToDateTime(FFeriado.ToShortDateString());
            //            if (factual5 < fferiado5)
            //            {
            //                Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
            //                TxtFecha.Text = string.Empty;
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            if (factual5 < fechaSeleccionada.AddDays(-1))
            //            {
            //                Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
            //                TxtFecha.Text = string.Empty;
            //                return;
            //            }
            //        }
            //    break;
            //    case "Friday":
            //        VT_Feriados ObjFeriadoV = ColFeriado.Where(f => f.Fecha_Feriado.ToShortDateString() == Convert.ToDateTime(fechaSeleccionada).ToShortDateString()).SingleOrDefault();
            //        DateTime factual6 = Convert.ToDateTime(fechaactual.ToShortDateString());
            //        DateTime fferiado6 = new DateTime();
            //        if (ObjFeriadoV != null)
            //        {
            //            DateTime FFeriado = ObjFeriadoV.Fecha_Feriado.AddDays(-1);
            //            fferiado6 = Convert.ToDateTime(FFeriado.ToShortDateString());
            //            if (factual6 < fferiado6)
            //            {
            //                Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
            //                TxtFecha.Text = string.Empty;
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            if (factual6 < fechaSeleccionada.AddDays(-1))
            //            {
            //                Response.Write("<script>window.alert('Registro fuera de Rango!!!,(El registro debe ser realizado 1 día antes o el mismo día)');</script>");
            //                TxtFecha.Text = string.Empty;
            //                return;
            //            }
            //        }
            //    break;
            //}
            
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
            if (DDLDestino.SelectedItem.Text == DDLDepart.SelectedItem.Text)
            {
                RDBRural.Checked = true;
                RDBUrbana.Checked = false;
                LblTexto2.Visible = true;
                TxtLugar.Visible = true;
                //LblZona.Text = "Departamental";
                LblZona.Text = "Al interior del Departamento";
            }
            else
            {
                RDBUrbana.Checked = true;
                RDBRural.Checked = false;
                LblTexto2.Visible = false;
                TxtLugar.Visible = false;
                LblZona.Text = "Interdepartamental";
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

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string tramo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Tramo"));
                //if (cont == 0)
                //{
                //    e.Row.BackColor = System.Drawing.Color.DarkGray;
                //    e.Row.Enabled = false;
                //}                
            }
        }


        //protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        //{
        //    //Calendar1.SelectedDate = Convert.ToDateTime(TextBox1.Text);
        //    TxtFecha.Text = Calendar1.SelectedDate.ToShortDateString();
        //    Calendar1.Visible = false;
        //}

        //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        //{
        //    Calendar1.Visible = true;
        //}

    }
}