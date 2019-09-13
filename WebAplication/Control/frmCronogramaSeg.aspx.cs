using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Text;
using System.Data.SqlClient;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;
using DataBusiness.DB_General;
using DataEntity.DE_Extensiones;
using DataBusiness.DB_Extensiones;

namespace WebAplication.Control
{
    public partial class frmCronogramaSeg : System.Web.UI.Page
    {
        /// <summary>
        /// Recibe el idcronograma en la edicion
        /// </summary>
        private int IdCronogramaEdicion
        {
            get
            {
                if (ViewState["IdCronogramaEdicion"] != null)
                    return (int)ViewState["IdCronogramaEdicion"];

                return 0;
            }
            set { ViewState["IdCronogramaEdicion"] = value; }
        }
        /// <summary>
        /// Objeto Recuoperado para la edicion de Cronograma
        /// </summary>
        public EXT_Cronograma CronogramaEdit
        {
            get
            {
                if (ViewState["CronogramaEdit"] != null)
                    return (EXT_Cronograma)ViewState["CronogramaEdit"];
                else
                    return new EXT_Cronograma();
            }
            set
            {
                ViewState["CronogramaEdit"] = value;
            }
        }
        /// <summary>
        /// Objeto Recuoperado para la edicion de CronogramaDias
        /// </summary>
        public EXT_CronogramaDias CronogramaDiasEdit
        {
            get
            {
                if (ViewState["CronogramaDiasEdit"] != null)
                    return (EXT_CronogramaDias)ViewState["CronogramaDiasEdit"];
                else
                    return new EXT_CronogramaDias();
            }
            set
            {
                ViewState["CronogramaDiasEdit"] = value;
            }
        }
        /// <summary>
        /// Coleccion de Tareas < 100 del Cronograma a editar
        /// </summary>
        public List<EXT_CronogramaDiasAvance> ColCronogramaDiasAvanceEdit
        {
            get
            {
                if (ViewState["ColCronogramaDiasAvanceEdit"] != null)
                    return (List<EXT_CronogramaDiasAvance>)ViewState["ColCronogramaDiasAvanceEdit"];
                else
                    return new List<EXT_CronogramaDiasAvance>();
            }
            set
            {
                ViewState["ColCronogramaDiasAvanceEdit"] = value;
            }
        }
        /// <summary>
        /// Coleccion de Tareas recuperadas No terminadas 
        /// </summary>
        public List<EXT_CronogramaDiasAvance> ColCDANoTerminadas
        {
            get
            {
                if (ViewState["ColCDANoTerminadas"] != null)
                    return (List<EXT_CronogramaDiasAvance>)ViewState["ColCDANoTerminadas"];
                else
                    return new List<EXT_CronogramaDiasAvance>();
            }
            set
            {
                ViewState["ColCDANoTerminadas"] = value;
            }
        }
        /// <summary>
        /// Selecciones a eliminar de lo recuperado
        /// List<EXT_CronogramaDiasAvance> ColCD_TareasEliminar = new List<EXT_CronogramaDiasAvance>();
        /// </summary>
        public List<EXT_CronogramaDiasAvance> ColCronogramaDiasEdit_AEliminar
        {
            get
            {
                if (ViewState["ColCronogramaDiasEdit_AEliminar"] != null)
                    return (List<EXT_CronogramaDiasAvance>)ViewState["ColCronogramaDiasEdit_AEliminar"];
                else
                    return new List<EXT_CronogramaDiasAvance>();
            }
            set
            {
                ViewState["ColCronogramaDiasEdit_AEliminar"] = value;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    Datos_ENCABEZADO();
                    Llenar_ORGANIZACIONES_DESIGNADAS();
                    Llenar_VEHICULO_REGIONAL();
                    LlenarCombosActividades();
                    IdCronogramaEdicion = 0;
                    string idCro = Convert.ToString(Request.QueryString["EditCronograma"]);
                    if ( Convert.ToInt16(idCro) > 0)
                    {                        
                        EditarCoronograma(Convert.ToInt16(idCro));
                    }
                }
                LblMsj.Text = string.Empty;
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCIONES PARA CARGAR LOS DATOS DE LA ORGANIZACION
        private void Datos_ENCABEZADO()
        {
            DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = Usuario.DB_Desplegar_USUARIO(LblIdUsuario.Text);
            LblRegional.Text = dt.Rows[0][5].ToString();
            LblIdReg.Text = dt.Rows[0][4].ToString();
            DB_AP_Campanhia camp = new DB_AP_Campanhia();
            dt = camp.DB_Seleccionar_CAMPANHIA_REG_NOFIN(dt.Rows[0][10].ToString());
            LblCamp.Text = dt.Rows[0][1].ToString();
            LblIdCamp.Text = dt.Rows[0][0].ToString();
        }
        #endregion
        #region FUNCIONES DEL COMBO
        protected void Llenar_ORGANIZACIONES_DESIGNADAS()
        {
            DB_EXT_DesignacionOrg desigorg = new DB_EXT_DesignacionOrg();
            DataTable dt = new DataTable();
            dt = desigorg.DB_Seleccionar_DESIGNACION_ORG(Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblIdCamp.Text), LblIdUsuario.Text, DDLPrograma.SelectedValue, "LISTASIGNADOS");
            DDLOrgAsig.DataSource = dt;
            DDLOrgAsig.DataValueField = "Id_InscripcionOrg";
            DDLOrgAsig.DataTextField = "Sigla";
            DDLOrgAsig.DataBind();
        }
        protected void Llenar_VEHICULO_REGIONAL()
        {
            DB_Regional reg = new DB_Regional();
            DataTable dt = new DataTable();
            dt = reg.DB_Seleccionar_VEHICULO(Convert.ToInt32(LblIdReg.Text));
            DDLVehiculos.DataSource = dt;
            DDLVehiculos.DataValueField = "Id_Vehiculo";
            DDLVehiculos.DataTextField = "Placa";
            DDLVehiculos.DataBind();
        }

        protected void LlenarCombosActividades()
        {
            //Datos de actividades de oficina
            DB_EXT_Actividades reg = new DB_EXT_Actividades();
            DataTable dt = new DataTable();
            dt = reg.DB_ActividadesCronogramaSemanal("OF");
            DDLActividadesOficina.DataSource = dt;
            DDLActividadesOficina.DataValueField = "IdExtActividades";
            DDLActividadesOficina.DataTextField = "Actividad";
            DDLActividadesOficina.DataBind();

            ////Datos de actividades de Apoyo a la produccion y colocacion de cartera
            reg = new DB_EXT_Actividades();
            dt = new DataTable();
            dt = reg.DB_ActividadesCronogramaSemanal("A");
            DDLActividadesApoyoProduccion.DataSource = dt;
            DDLActividadesApoyoProduccion.DataValueField = "IdExtActividades";
            DDLActividadesApoyoProduccion.DataTextField = "Actividad";
            DDLActividadesApoyoProduccion.DataBind();

            ////Datos de actividades Seelccion de empresas proveedoras elegibles
            reg = new DB_EXT_Actividades();
            dt = new DataTable();
            dt = reg.DB_ActividadesCronogramaSemanal("SE");
            DDLActividadesEmpresasProveedoras.DataSource = dt;
            DDLActividadesEmpresasProveedoras.DataValueField = "IdExtActividades";
            DDLActividadesEmpresasProveedoras.DataTextField = "Actividad";
            DDLActividadesEmpresasProveedoras.DataBind();
                        
            ////Datos de actividades Extension agricola
            reg = new DB_EXT_Actividades();
            dt = new DataTable();
            dt = reg.DB_ActividadesCronogramaSemanal("E");
            DDLActividadesExtensionAgricola.DataSource = dt;
            DDLActividadesExtensionAgricola.DataValueField = "IdExtActividades";
            DDLActividadesExtensionAgricola.DataTextField = "Actividad";
            DDLActividadesExtensionAgricola.DataBind();

            ////Datos de actividades de fortalecimiento a organizaciones de productores
            reg = new DB_EXT_Actividades();
            dt = new DataTable();
            dt = reg.DB_ActividadesCronogramaSemanal("F");
            DDLActividadesFortalecimiento.DataSource = dt;
            DDLActividadesFortalecimiento.DataValueField = "IdExtActividades";
            DDLActividadesFortalecimiento.DataTextField = "Actividad";
            DDLActividadesFortalecimiento.DataBind();

            ////Monitoreo de cultivos a pequeños y medianos productores
            reg = new DB_EXT_Actividades();
            dt = new DataTable();
            dt = reg.DB_ActividadesCronogramaSemanal("M");
            DDLActividadesMonitoreo.DataSource = dt;
            DDLActividadesMonitoreo.DataValueField = "IdExtActividades";
            DDLActividadesMonitoreo.DataTextField = "Actividad";
            DDLActividadesMonitoreo.DataBind();

            ////Datos de actividades de Reprogramacion de cancelacion de la deuda
            reg = new DB_EXT_Actividades();
            dt = new DataTable();
            dt = reg.DB_ActividadesCronogramaSemanal("R");
            DDLActividadesReprogramacionDeuda.DataSource = dt;
            DDLActividadesReprogramacionDeuda.DataValueField = "IdExtActividades";
            DDLActividadesReprogramacionDeuda.DataTextField = "Actividad";
            DDLActividadesReprogramacionDeuda.DataBind();

            ////Datos de otras actividades
            reg = new DB_EXT_Actividades();
            dt = new DataTable();
            dt = reg.DB_ActividadesCronogramaSemanal("O");
            DDLActividadesOtros.DataSource = dt;
            DDLActividadesOtros.DataValueField = "IdExtActividades";
            DDLActividadesOtros.DataTextField = "Actividad";
            DDLActividadesOtros.DataBind();


        }
        #endregion
        #region FUNCIONES DE COMBO
        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_ORGANIZACIONES_DESIGNADAS();
        }
        #endregion
        #region FUNCION PARA REGISTRARA TAREAS
        protected void Insertar_TAREA(string tarea)
        {
            try
            {
                LblMsj.Text = string.Empty;
                switch (LblAux.Text)
                {
                    case "LUNES":
                        if (tarea.Contains("(MOV)"))
                        {
                            if (LstLunes.Items.Count == 0)
                            {
                                LblMsj.Text = "Registrar Actividad Previa";
                            }
                            else
                            {
                                int c = LstLunes.Items.Count;
                                string datoant = LstLunes.Items[c - 1].ToString();
                                if (datoant.Contains("(MOV)"))
                                {
                                    LblMsj.Text = "No se puede realizar el registro continuo de Movilidad";
                                }
                                else
                                {
                                    LstLunes.Items.Add(tarea);//**
                                }

                            }
                        }
                        else
                        {
                            LstLunes.Items.Add(tarea);
                        }

                        break;
                    case "MARTES":
                        //LstMartes.Items.Add(tarea);
                        if (tarea.Contains("(MOV)"))
                        {
                            if (LstMartes.Items.Count == 0)
                            {
                                LblMsj.Text = "Registrar Actividad Previa";
                            }
                            else
                            {
                                int c = LstMartes.Items.Count;
                                string datoant = LstMartes.Items[c - 1].ToString();
                                if (datoant.Contains("(MOV)"))
                                {
                                    LblMsj.Text = "No se puede realizar el registro continuo de Movilidad";
                                }
                                else
                                {
                                    LstMartes.Items.Add(tarea);
                                }
                            }
                        }
                        else
                        {
                            LstMartes.Items.Add(tarea);
                        }
                        break;
                    case "MIERCOLES":
                        //LstMiercoles.Items.Add(tarea);
                        if (tarea.Contains("(MOV)"))
                        {
                            if (LstMiercoles.Items.Count == 0)
                            {
                                LblMsj.Text = "Registrar Actividad Previa";
                            }
                            else
                            {
                                int c = LstMiercoles.Items.Count;
                                string datoant = LstMiercoles.Items[c - 1].ToString();
                                if (datoant.Contains("(MOV)"))
                                {
                                    LblMsj.Text = "No se puede realizar el registro continuo de Movilidad";
                                }
                                else
                                {
                                    LstMiercoles.Items.Add(tarea);
                                }
                            }
                        }
                        else
                        {
                            LstMiercoles.Items.Add(tarea);
                        }
                        break;
                    case "JUEVES":
                        //LstJueves.Items.Add(tarea);
                        if (tarea.Contains("(MOV)"))
                        {
                            if (LstJueves.Items.Count == 0)
                            {
                                LblMsj.Text = "Registrar Actividad Previa";
                            }
                            else
                            {
                                int c = LstJueves.Items.Count;
                                string datoant = LstJueves.Items[c - 1].ToString();
                                if (datoant.Contains("(MOV)"))
                                {
                                    LblMsj.Text = "No se puede realizar el registro continuo de Movilidad";
                                }
                                else
                                {
                                    LstJueves.Items.Add(tarea);
                                }
                            }
                        }
                        else
                        {
                            LstJueves.Items.Add(tarea);
                        }
                        break;
                    case "VIERNES":
                        //LstViernes.Items.Add(tarea);
                        if (tarea.Contains("(MOV)"))
                        {
                            if (LstViernes.Items.Count == 0)
                            {
                                LblMsj.Text = "Registrar Actividad Previa";
                            }
                            else
                            {
                                int c = LstViernes.Items.Count;
                                string datoant = LstViernes.Items[c - 1].ToString();
                                if (datoant.Contains("(MOV)"))
                                {
                                    LblMsj.Text = "No se puede realizar el registro continuo de Movilidad";
                                }
                                else
                                {
                                    LstViernes.Items.Add(tarea);
                                }
                            }
                        }
                        else
                        {
                            LstViernes.Items.Add(tarea);
                        }
                        break;
                    case "SABADO":
                        //LstSabado.Items.Add(tarea);
                        if (tarea.Contains("(MOV)"))
                        {
                            if (LstSabado.Items.Count == 0)
                            {
                                LblMsj.Text = "Registrar Actividad Previa";
                            }
                            else
                            {
                                int c = LstSabado.Items.Count;
                                string datoant = LstSabado.Items[c - 1].ToString();
                                if (datoant.Contains("(MOV)"))
                                {
                                    LblMsj.Text = "No se puede realizar el registro continuo de Movilidad";
                                }
                                else
                                {
                                    LstSabado.Items.Add(tarea);
                                }
                            }
                        }
                        else
                        {
                            LstSabado.Items.Add(tarea);
                        }
                        break;
                    case "DOMINGO":
                        //LstDomingo.Items.Add(tarea);
                        if (tarea.Contains("(MOV)"))
                        {
                            if (LstDomingo.Items.Count == 0)
                            {
                                LblMsj.Text = "Registrar Actividad Previa";
                            }
                            else
                            {
                                int c = LstDomingo.Items.Count;
                                string datoant = LstDomingo.Items[c - 1].ToString();
                                if (datoant.Contains("(MOV)"))
                                {
                                    LblMsj.Text = "No se puede realizar el registro continuo de Movilidad";
                                }
                                else
                                {
                                    LstDomingo.Items.Add(tarea);
                                }
                            }
                        }
                        else
                        {
                            LstDomingo.Items.Add(tarea);
                        }
                        break;
                }
                ClearSelectionListBox();
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
        }

        protected void BtnPlaniInsert_Click(object sender, EventArgs e)
        {
            //Insertar_TAREA(DDLPlanificar.SelectedItem.Text);
        }
        protected void BtnSegInsert_Click(object sender, EventArgs e)
        {
           // Insertar_TAREA(DDLSeguimiento.SelectedItem.Text);
        }
        protected void BtnFortalInsert_Click(object sender, EventArgs e)
        {
           // Insertar_TAREA(DDLFortalecimiento.SelectedItem.Text);
        }
        protected void BtnActivInsert_Click(object sender, EventArgs e)
        {
            //Insertar_TAREA(DDLActividades.SelectedItem.Text);
        }
        protected void BtnOrgInsert_Click(object sender, EventArgs e)
        {            
            Insertar_TAREA(("(ORG) "+ DDLOrgAsig.SelectedItem.Text) + (txtDDLOrgAsig.Text == "" ? "" : "(Otro:)" + txtDDLOrgAsig.Text));            
        }
        protected void BtnVehiculo_Click(object sender, EventArgs e)
        {
            Insertar_TAREA(("(MOV) " + DDLVehiculos.SelectedItem.Text) + (txtDDLVehiculos.Text == "" ? "" : "(Otro:)" + txtDDLVehiculos.Text));            
        }
        #endregion
        #region FUNCIONES CHOCK BOB PARA SELECCIONAR DIA
        protected void RdbLunes_CheckedChanged(object sender, EventArgs e)
        {
            LblAux.Text = "LUNES";
            ClearSelectionListBox();
        }
        protected void RdbMartes_CheckedChanged(object sender, EventArgs e)
        {
            LblAux.Text = "MARTES";
            ClearSelectionListBox();
        }
        protected void RdbMiercoles_CheckedChanged(object sender, EventArgs e)
        {
            LblAux.Text = "MIERCOLES";
            ClearSelectionListBox();
        }
        protected void RdbJueves_CheckedChanged(object sender, EventArgs e)
        {
            LblAux.Text = "JUEVES";
            ClearSelectionListBox();
        }
        protected void RdbViernes_CheckedChanged(object sender, EventArgs e)
        {
            LblAux.Text = "VIERNES";
            ClearSelectionListBox();
        }
        protected void RdbSabado_CheckedChanged(object sender, EventArgs e)
        {
            LblAux.Text = "SABADO";
            ClearSelectionListBox();
        }
        protected void RdbDomingo_CheckedChanged(object sender, EventArgs e)
        {
            LblAux.Text = "DOMINGO";
            ClearSelectionListBox();
        }
        #endregion
        #region FUNCION PARA ENVIAR EL CRONOGRAMA
        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtNombre.Text == string.Empty)
                {
                    LblMsj.Text = "Ingrese Nombre de la planificación";
                    return;
                }
                else 
                {
                    DB_EXT_Cronogramas ListC = new DB_EXT_Cronogramas();
                    //DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
                    //int idcronograma = Convert.ToInt32(aux.DB_MaxId("EXT_CRONOGRAMA", "Id_Cronograma"));                         
                    DataTable ListaCronograma = ListC.DB_Desplegar_LISTA_CRONOGRAMAS(LblIdUsuario.Text, 0, 0, "LISTA_CRONOGRAMAS");
                    foreach (DataRow cr in ListaCronograma.Rows)
                    {
                        string nombre = cr["Cronograma"].ToString();
                        if (nombre == TxtNombre.Text)
                        {
                            if (Convert.ToInt16(cr["Id_Cronograma"].ToString()) == IdCronogramaEdicion)
                            {
                                // no controla en nombre 
                            }
                            else
                            {
                                LblMsj.Text = "El Nombre de la Planificación ya existe...";
                                LblMsj.Focus();
                                return;
                            }
                            
                        }                        
                    }

                }
                DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
                DB_EXT_Cronogramas reg = new DB_EXT_Cronogramas();
                EXT_Cronograma crm = new EXT_Cronograma();
                EXT_CronogramaDias crmdia = new EXT_CronogramaDias();                
                if (IdCronogramaEdicion > 0)
                {

                    EXT_Cronograma ObjCr = CronogramaEdit;
                    ObjCr.Fecha_Envio = DateTime.Now;
                    ObjCr.Nombre = TxtNombre.Text;
                    ObjCr.Semana = DDLSemana.SelectedValue;
                    reg.DB_CRONOGRAMA_UPDATE(ObjCr);
                }
                else
                {
                    crm.Id_Campanhia = Convert.ToInt32(LblIdCamp.Text);
                    crm.Id_Usuario = LblIdUsuario.Text;
                    crm.Id_Regional = Convert.ToInt32(LblIdReg.Text);
                    crm.Nombre = TxtNombre.Text;
                    crm.Fecha_Envio = DateTime.Now;
                    crm.Mes = (Convert.ToDateTime(TxtFecha.Text)).AddDays(1).ToString("MM");
                    crm.Semana = DDLSemana.SelectedValue;
                    crm.Observacion = "";
                    crm.Estado = "ENVIADO";
                    reg.DB_Registrar_CRONOGRAMA(crm);
                }
                /*********************************************************/
                int Id_CronogramaAux = 0;
                if (IdCronogramaEdicion > 0)
                    Id_CronogramaAux = IdCronogramaEdicion;
                else
                    Id_CronogramaAux = Convert.ToInt32(aux.DB_MaxId("EXT_CRONOGRAMA", "Id_Cronograma"));

                crmdia.Id_Cronograma = Id_CronogramaAux;
                string diaLunes = "";
                string diaMartes = "";
                string diaMiercoles = "";
                string diaJueves = "";
                string diaViernes = "";
                string diaSabado = "";
                string diaDomingo = "";
                int i = 0;
                List<EXT_CronogramaDiasAvance> ColAvance = new List<EXT_CronogramaDiasAvance>();//LR            
                List<EXT_CronogramaDiasAvance> ColCDAEliminar= new List<EXT_CronogramaDiasAvance>();//LR                  
                for (i = 0; i < LstLunes.Items.Count; i++)
                {
                    diaLunes = diaLunes + "| " + LstLunes.Items[i].ToString();                    
                    int total = LstLunes.Items.Count - i;
                    EXT_CronogramaDiasAvance Avance = new EXT_CronogramaDiasAvance();
                    if (total != 1)
                    {
                        //EXT_CronogramaDiasAvance Avance = new EXT_CronogramaDiasAvance();
                        Avance.Id_Cronograma = Id_CronogramaAux;
                        Avance.FechaDia = LblFLunes.Text;
                        Avance.PorcentajeAvance = 0;
                        Avance.ObservacionAvance = string.Empty;
                        Avance.Dia = "Lunes";
                        Avance.FuenteVerificacion = string.Empty;
                        Avance.Observaciones = string.Empty;
                        string datodia = LstLunes.Items[i].ToString();
                        string datodiasig = LstLunes.Items[i + 1].ToString();
                        if (i == 0)//para primer dato de la lista
                        {
                            if (datodiasig.Contains("(MOV)"))
                            {
                                EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodiasig && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA1 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA1);
                                    Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA1.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA2 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA2);
                                        Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA2.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                }
                                Avance.TareaDia = LstLunes.Items[i].ToString() + "| " + datodiasig;
                            }
                            else
                            {
                                EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA1 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA1);
                                    Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA1.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA2 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA2);
                                        Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA2.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                }
                                Avance.TareaDia = LstLunes.Items[i].ToString();
                            }
                        }
                        else
                        {
                            if (datodia.Contains("(MOV)"))
                            { continue; }
                            else
                            {
                                if (datodiasig.Contains("(MOV)"))
                                {
                                    EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodiasig && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA1 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA1);
                                        Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA1.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert                                        
                                    }
                                    else
                                    {
                                        EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                        if (FilCDA2 != null)
                                        {
                                            ColCDAEliminar.Add(FilCDA2);
                                            Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                            Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                            Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                            Avance.Observaciones = FilCDA2.Observaciones;
                                            Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                        }
                                    }
                                    Avance.TareaDia = LstLunes.Items[i].ToString() + "| " + datodiasig;
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA1 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA1);
                                        Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA1.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                    else
                                    {
                                        EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                        if (FilCDA2 != null)
                                        {
                                            ColCDAEliminar.Add(FilCDA2);
                                            Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                            Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                            Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                            Avance.Observaciones = FilCDA2.Observaciones;
                                            Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                        }
                                    }
                                    Avance.TareaDia = LstLunes.Items[i].ToString();
                                }
                            }
                        }
                        //ColAvance.Add(Avance);
                    }
                    //*****
                    else
                    {                        
                        Avance.Id_Cronograma = Id_CronogramaAux;
                        Avance.FechaDia = LblFLunes.Text;
                        Avance.PorcentajeAvance = 0;
                        Avance.ObservacionAvance = string.Empty;
                        Avance.Dia = "Lunes";
                        Avance.FuenteVerificacion = string.Empty;
                        Avance.Observaciones = string.Empty;
                        string datodia = LstLunes.Items[i].ToString();
                        //string datoanterior = LstMartes.Items[i - 1].ToString();
                        if (datodia.Contains("(MOV)"))
                        { continue; }
                        else
                        { 
                           EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA1 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA1);
                                    Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA1.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA2 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA2);
                                        Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA2.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                }
                                Avance.TareaDia = LstLunes.Items[i].ToString();
                        }
                    }
                    ColAvance.Add(Avance);
                    //*****
                }
                for (i = 0; i < LstMartes.Items.Count; i++)
                {
                    diaMartes = diaMartes + "| " + LstMartes.Items[i].ToString();                    
                    //***** concatena movilidad al ultimo registro
                    int total = LstMartes.Items.Count - i;
                    EXT_CronogramaDiasAvance Avance = new EXT_CronogramaDiasAvance();
                    if (total != 1)
                    {                        
                        Avance.Id_Cronograma = Id_CronogramaAux;
                        Avance.FechaDia = LblFMartes.Text;
                        Avance.PorcentajeAvance = 0;
                        Avance.ObservacionAvance = string.Empty;
                        Avance.Dia = "Martes";
                        Avance.FuenteVerificacion = string.Empty;
                        Avance.Observaciones = string.Empty;
                        string datodia = LstMartes.Items[i].ToString();
                        string datodiasig = LstMartes.Items[i + 1].ToString();
                        if (i == 0)//para primer dato de la lista
                        {
                            if (datodiasig.Contains("(MOV)"))
                            {
                                EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodiasig && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA1 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA1);
                                    Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA1.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA2 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA2);
                                        Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA2.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                }                           
                                Avance.TareaDia = LstMartes.Items[i].ToString() + "| " + datodiasig;
                            }
                            else
                            {
                                EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA1 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA1);
                                    Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA1.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA2 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA2);
                                        Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA2.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                }
                                Avance.TareaDia = LstMartes.Items[i].ToString(); 
                            }
                        }
                        else
                        {
                            if (datodia.Contains("(MOV)"))
                            { continue; }
                            else
                            {
                                if (datodiasig.Contains("(MOV)"))
                                {
                                    EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodiasig && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA1 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA1);
                                        Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA1.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert                                        
                                    }
                                    else
                                    {
                                        EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                        if (FilCDA2 != null)
                                        {
                                            ColCDAEliminar.Add(FilCDA2);
                                            Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                            Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                            Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                            Avance.Observaciones = FilCDA2.Observaciones;
                                            Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                        }
                                    }
                                    Avance.TareaDia = LstMartes.Items[i].ToString() + "| " + datodiasig;
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA1 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA1);
                                        Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA1.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                    else
                                    {
                                        EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                        if (FilCDA2 != null)
                                        {
                                            ColCDAEliminar.Add(FilCDA2);
                                            Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                            Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                            Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                            Avance.Observaciones = FilCDA2.Observaciones;
                                            Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                        }
                                    }
                                    Avance.TareaDia = LstMartes.Items[i].ToString();
                                }
                            }
                        }          
                        //Avance.TareaDia = LstLunes.Items[i].ToString();                        
                        //ColAvance.Add(Avance);
                    }
                    else
                    {
                        Avance.Id_Cronograma = Id_CronogramaAux;
                        Avance.FechaDia = LblFMartes.Text;
                        Avance.PorcentajeAvance = 0;
                        Avance.ObservacionAvance = string.Empty;
                        Avance.Dia = "Martes";
                        Avance.FuenteVerificacion = string.Empty;
                        Avance.Observaciones = string.Empty;
                        string datodia = LstMartes.Items[i].ToString();                        
                        if (datodia.Contains("(MOV)"))
                        { continue; }
                        else
                        {
                            EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                            if (FilCDA1 != null)
                            {
                                ColCDAEliminar.Add(FilCDA1);
                                Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                Avance.Observaciones = FilCDA1.Observaciones;
                                Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                            }
                            else
                            {
                                EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA2 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA2);
                                    Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA2.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                            }
                            Avance.TareaDia = LstMartes.Items[i].ToString();
                        }
                    }
                    ColAvance.Add(Avance);
                    //*****
                }
                for (i = 0; i < LstMiercoles.Items.Count; i++)
                {
                    diaMiercoles = diaMiercoles + "| " + LstMiercoles.Items[i].ToString();                    
                    //***** concatena movilidad al ultimo registro
                    int total = LstMiercoles.Items.Count - i;
                    EXT_CronogramaDiasAvance Avance = new EXT_CronogramaDiasAvance();
                    if (total != 1)
                    {   
                        Avance.Id_Cronograma = Id_CronogramaAux;
                        Avance.FechaDia = LblFMiercoles.Text;
                        Avance.PorcentajeAvance = 0;
                        Avance.ObservacionAvance = string.Empty;
                        Avance.Dia = "Miercoles";
                        Avance.FuenteVerificacion = string.Empty;
                        Avance.Observaciones = string.Empty;
                        string datodia = LstMiercoles.Items[i].ToString();
                        string datodiasig = LstMiercoles.Items[i + 1].ToString();
                        if (i == 0)//para primer dato de la lista
                        {
                            if (datodiasig.Contains("(MOV)"))
                            {
                                EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodiasig && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA1 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA1);
                                    Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA1.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA2 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA2);
                                        Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA2.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                }
                                Avance.TareaDia = LstMiercoles.Items[i].ToString() + "| " + datodiasig;
                            }
                            else
                            {
                                EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA1 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA1);
                                    Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA1.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA2 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA2);
                                        Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA2.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                }
                                Avance.TareaDia = LstMiercoles.Items[i].ToString();
                            }
                        }
                        else
                        {
                            if (datodia.Contains("(MOV)"))
                            { continue; }
                            else
                            {
                                if (datodiasig.Contains("(MOV)"))
                                {
                                    EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodiasig && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA1 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA1);
                                        Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA1.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert                                        
                                    }
                                    else
                                    {
                                        EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                        if (FilCDA2 != null)
                                        {
                                            ColCDAEliminar.Add(FilCDA2);
                                            Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                            Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                            Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                            Avance.Observaciones = FilCDA2.Observaciones;
                                            Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                        }
                                    }
                                    Avance.TareaDia = LstMiercoles.Items[i].ToString() + "| " + datodiasig;
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA1 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA1);
                                        Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA1.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                    else
                                    {
                                        EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                        if (FilCDA2 != null)
                                        {
                                            ColCDAEliminar.Add(FilCDA2);
                                            Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                            Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                            Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                            Avance.Observaciones = FilCDA2.Observaciones;
                                            Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                        }
                                    }
                                    Avance.TareaDia = LstMiercoles.Items[i].ToString();
                                }
                            }
                        }    
                        //Avance.TareaDia = LstLunes.Items[i].ToString();                     
                        //ColAvance.Add(Avance);
                    }
                    else
                    {
                        Avance.Id_Cronograma = Id_CronogramaAux;
                        Avance.FechaDia = LblFMiercoles.Text;
                        Avance.PorcentajeAvance = 0;
                        Avance.ObservacionAvance = string.Empty;
                        Avance.Dia = "Miercoles";
                        Avance.FuenteVerificacion = string.Empty;
                        Avance.Observaciones = string.Empty;
                        string datodia = LstMiercoles.Items[i].ToString();
                        if (datodia.Contains("(MOV)"))
                        { continue; }
                        else
                        {
                            EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                            if (FilCDA1 != null)
                            {
                                ColCDAEliminar.Add(FilCDA1);
                                Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                Avance.Observaciones = FilCDA1.Observaciones;
                                Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                            }
                            else
                            {
                                EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA2 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA2);
                                    Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA2.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                            }
                            Avance.TareaDia = LstMiercoles.Items[i].ToString();
                        }
                    }
                    ColAvance.Add(Avance);
                    //*****
                }
                for (i = 0; i < LstJueves.Items.Count; i++)
                {
                    diaJueves = diaJueves + "| " + LstJueves.Items[i].ToString();
                    //***** concatena movilidad al ultimo registro
                    int total = LstJueves.Items.Count - i;
                    EXT_CronogramaDiasAvance Avance = new EXT_CronogramaDiasAvance();
                    if (total != 1)
                    {   
                        Avance.Id_Cronograma = Id_CronogramaAux;
                        Avance.FechaDia = LblFJueves.Text;
                        Avance.PorcentajeAvance = 0;
                        Avance.ObservacionAvance = string.Empty;
                        Avance.Dia = "Jueves";
                        Avance.FuenteVerificacion = string.Empty;
                        Avance.Observaciones = string.Empty;
                        string datodia = LstJueves.Items[i].ToString();
                        string datodiasig = LstJueves.Items[i + 1].ToString();
                        if (i == 0)//para primer dato de la lista
                        {
                            if (datodiasig.Contains("(MOV)"))
                            {
                                EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodiasig && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA1 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA1);
                                    Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA1.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA2 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA2);
                                        Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA2.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                }
                                Avance.TareaDia = LstJueves.Items[i].ToString() + "| " + datodiasig;
                            }
                            else
                            {
                                EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA1 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA1);
                                    Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA1.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA2 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA2);
                                        Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA2.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                }
                                Avance.TareaDia = LstJueves.Items[i].ToString();
                            }
                        }
                        else
                        {
                            if (datodia.Contains("(MOV)"))
                            { continue; }
                            else
                            {
                                if (datodiasig.Contains("(MOV)"))
                                {
                                    EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodiasig && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA1 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA1);
                                        Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA1.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert                                        
                                    }
                                    else
                                    {
                                        EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                        if (FilCDA2 != null)
                                        {
                                            ColCDAEliminar.Add(FilCDA2);
                                            Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                            Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                            Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                            Avance.Observaciones = FilCDA2.Observaciones;
                                            Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                        }
                                    }
                                    Avance.TareaDia = LstJueves.Items[i].ToString() + "| " + datodiasig;
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA1 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA1);
                                        Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA1.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                    else
                                    {
                                        EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                        if (FilCDA2 != null)
                                        {
                                            ColCDAEliminar.Add(FilCDA2);
                                            Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                            Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                            Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                            Avance.Observaciones = FilCDA2.Observaciones;
                                            Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                        }
                                    }
                                    Avance.TareaDia = LstJueves.Items[i].ToString();
                                }
                            }
                        }  
                        //Avance.TareaDia = LstLunes.Items[i].ToString();
                        //ColAvance.Add(Avance);
                    }
                    else
                    {
                        Avance.Id_Cronograma = Id_CronogramaAux;
                        Avance.FechaDia = LblFJueves.Text;
                        Avance.PorcentajeAvance = 0;
                        Avance.ObservacionAvance = string.Empty;
                        Avance.Dia = "Jueves";
                        Avance.FuenteVerificacion = string.Empty;
                        Avance.Observaciones = string.Empty;
                        string datodia = LstJueves.Items[i].ToString();
                        if (datodia.Contains("(MOV)"))
                        { continue; }
                        else
                        {
                            EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                            if (FilCDA1 != null)
                            {
                                ColCDAEliminar.Add(FilCDA1);
                                Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                Avance.Observaciones = FilCDA1.Observaciones;
                                Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                            }
                            else
                            {
                                EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA2 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA2);
                                    Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA2.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                            }
                            Avance.TareaDia = LstJueves.Items[i].ToString();
                        }
                    }
                    ColAvance.Add(Avance);
                    //*****
                }
                for (i = 0; i < LstViernes.Items.Count; i++)
                {
                    diaViernes = diaViernes + "| " + LstViernes.Items[i].ToString();
                    //***** concatena movilidad al ultimo registro
                    int total = LstViernes.Items.Count - i;
                    EXT_CronogramaDiasAvance Avance = new EXT_CronogramaDiasAvance();
                    if (total != 1)
                    {
                        Avance.Id_Cronograma = Id_CronogramaAux;
                        Avance.FechaDia = LblFViernes.Text;
                        Avance.PorcentajeAvance = 0;
                        Avance.ObservacionAvance = string.Empty;
                        Avance.Dia = "Viernes";
                        Avance.FuenteVerificacion = string.Empty;
                        Avance.Observaciones = string.Empty;
                        string datodia = LstViernes.Items[i].ToString();
                        string datodiasig = LstViernes.Items[i + 1].ToString();
                        if (i == 0)//para primer dato de la lista
                        {
                            if (datodiasig.Contains("(MOV)"))
                            {
                                EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodiasig && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA1 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA1);
                                    Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA1.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA2 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA2);
                                        Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA2.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                }
                                Avance.TareaDia = LstViernes.Items[i].ToString() + "| " + datodiasig;
                            }
                            else
                            {
                                EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA1 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA1);
                                    Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA1.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA2 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA2);
                                        Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA2.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                }
                                Avance.TareaDia = LstViernes.Items[i].ToString();
                            }
                        }
                        else
                        {
                            if (datodia.Contains("(MOV)"))
                            { continue; }
                            else
                            {
                                if (datodiasig.Contains("(MOV)"))
                                {
                                    EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodiasig && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA1 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA1);
                                        Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA1.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert                                        
                                    }
                                    else
                                    {
                                        EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                        if (FilCDA2 != null)
                                        {
                                            ColCDAEliminar.Add(FilCDA2);
                                            Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                            Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                            Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                            Avance.Observaciones = FilCDA2.Observaciones;
                                            Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                        }
                                    }
                                    Avance.TareaDia = LstViernes.Items[i].ToString() + "| " + datodiasig;
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA1 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA1);
                                        Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA1.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                    else
                                    {
                                        EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                        if (FilCDA2 != null)
                                        {
                                            ColCDAEliminar.Add(FilCDA2);
                                            Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                            Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                            Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                            Avance.Observaciones = FilCDA2.Observaciones;
                                            Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                        }
                                    }
                                    Avance.TareaDia = LstViernes.Items[i].ToString();
                                }
                            }
                        }  
                        //Avance.TareaDia = LstLunes.Items[i].ToString();                        
                        //ColAvance.Add(Avance);
                    }
                    else
                    {
                        Avance.Id_Cronograma = Id_CronogramaAux;
                        Avance.FechaDia = LblFViernes.Text;
                        Avance.PorcentajeAvance = 0;
                        Avance.ObservacionAvance = string.Empty;
                        Avance.Dia = "Viernes";
                        Avance.FuenteVerificacion = string.Empty;
                        Avance.Observaciones = string.Empty;
                        string datodia = LstViernes.Items[i].ToString();
                        if (datodia.Contains("(MOV)"))
                        { continue; }
                        else
                        {
                            EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                            if (FilCDA1 != null)
                            {
                                ColCDAEliminar.Add(FilCDA1);
                                Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                Avance.Observaciones = FilCDA1.Observaciones;
                                Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                            }
                            else
                            {
                                EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA2 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA2);
                                    Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA2.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                            }
                            Avance.TareaDia = LstViernes.Items[i].ToString();
                        }
                    }
                    ColAvance.Add(Avance);
                    //*****
                }
                for (i = 0; i < LstSabado.Items.Count; i++)
                {
                    diaSabado = diaSabado + "| " + LstSabado.Items[i].ToString();                    
                    //***** concatena movilidad al ultimo registro
                    int total = LstSabado.Items.Count - i;
                    EXT_CronogramaDiasAvance Avance = new EXT_CronogramaDiasAvance();
                    if (total != 1)
                    {   
                        Avance.Id_Cronograma = Id_CronogramaAux;
                        Avance.FechaDia = LblFSabado.Text;
                        Avance.PorcentajeAvance = 0;
                        Avance.ObservacionAvance = string.Empty;
                        Avance.Dia = "Sabado";
                        Avance.FuenteVerificacion = string.Empty;
                        Avance.Observaciones = string.Empty;
                        string datodia = LstSabado.Items[i].ToString();
                        string datodiasig = LstSabado.Items[i + 1].ToString();
                        if (i == 0)//para primer dato de la lista
                        {
                            if (datodiasig.Contains("(MOV)"))
                            {
                                EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodiasig && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA1 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA1);
                                    Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA1.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA2 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA2);
                                        Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA2.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                }
                                Avance.TareaDia = LstSabado.Items[i].ToString() + "| " + datodiasig;
                            }
                            else
                            {
                                EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA1 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA1);
                                    Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA1.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA2 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA2);
                                        Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA2.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                }
                                Avance.TareaDia = LstSabado.Items[i].ToString();
                            }
                        }
                        else
                        {
                            if (datodia.Contains("(MOV)"))
                            { continue; }
                            else
                            {
                                if (datodiasig.Contains("(MOV)"))
                                {
                                    EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodiasig && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA1 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA1);
                                        Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA1.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert                                        
                                    }
                                    else
                                    {
                                        EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                        if (FilCDA2 != null)
                                        {
                                            ColCDAEliminar.Add(FilCDA2);
                                            Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                            Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                            Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                            Avance.Observaciones = FilCDA2.Observaciones;
                                            Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                        }
                                    }
                                    Avance.TareaDia = LstSabado.Items[i].ToString() + "| " + datodiasig;
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA1 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA1);
                                        Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA1.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                    else
                                    {
                                        EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                        if (FilCDA2 != null)
                                        {
                                            ColCDAEliminar.Add(FilCDA2);
                                            Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                            Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                            Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                            Avance.Observaciones = FilCDA2.Observaciones;
                                            Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                        }
                                    }
                                    Avance.TareaDia = LstSabado.Items[i].ToString();
                                }
                            }
                        } 
                        //Avance.TareaDia = LstLunes.Items[i].ToString();                       
                        //ColAvance.Add(Avance);
                    }
                    else
                    {
                        Avance.Id_Cronograma = Id_CronogramaAux;
                        Avance.FechaDia = LblFSabado.Text;
                        Avance.PorcentajeAvance = 0;
                        Avance.ObservacionAvance = string.Empty;
                        Avance.Dia = "Sabado";
                        Avance.FuenteVerificacion = string.Empty;
                        Avance.Observaciones = string.Empty;
                        string datodia = LstSabado.Items[i].ToString();
                        if (datodia.Contains("(MOV)"))
                        { continue; }
                        else
                        {
                            EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                            if (FilCDA1 != null)
                            {
                                ColCDAEliminar.Add(FilCDA1);
                                Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                Avance.Observaciones = FilCDA1.Observaciones;
                                Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                            }
                            else
                            {
                                EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA2 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA2);
                                    Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA2.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                            }
                            Avance.TareaDia = LstSabado.Items[i].ToString();
                        }
                    }
                    ColAvance.Add(Avance);
                    //*****
                }
                for (i = 0; i < LstDomingo.Items.Count; i++)
                {
                    diaDomingo = diaDomingo + "| " + LstDomingo.Items[i].ToString();                   
                    //***** concatena movilidad al ultimo registro
                    int total = LstDomingo.Items.Count - i;
                    EXT_CronogramaDiasAvance Avance = new EXT_CronogramaDiasAvance();                        
                    if (total != 1)
                    {                        
                        Avance.Id_Cronograma = Id_CronogramaAux;
                        Avance.FechaDia = LblFDomingo.Text;
                        Avance.PorcentajeAvance = 0;
                        Avance.ObservacionAvance = string.Empty;
                        Avance.Dia = "Domingo";
                        Avance.FuenteVerificacion = string.Empty;
                        Avance.Observaciones = string.Empty;
                        string datodia = LstDomingo.Items[i].ToString();
                        string datodiasig = LstDomingo.Items[i + 1].ToString();
                        if (i == 0)//para primer dato de la lista
                        {
                            if (datodiasig.Contains("(MOV)"))
                            {
                                EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodiasig && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA1 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA1);
                                    Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA1.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA2 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA2);
                                        Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA2.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                }
                                Avance.TareaDia = LstDomingo.Items[i].ToString() + "| " + datodiasig;
                            }
                            else
                            {
                                EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA1 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA1);
                                    Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA1.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA2 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA2);
                                        Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA2.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                }
                                Avance.TareaDia = LstDomingo.Items[i].ToString();
                            }
                        }
                        else
                        {
                            if (datodia.Contains("(MOV)"))
                            { continue; }
                            else
                            {
                                if (datodiasig.Contains("(MOV)"))
                                {
                                    EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodiasig && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA1 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA1);
                                        Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA1.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert                                        
                                    }
                                    else
                                    {
                                        EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                        if (FilCDA2 != null)
                                        {
                                            ColCDAEliminar.Add(FilCDA2);
                                            Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                            Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                            Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                            Avance.Observaciones = FilCDA2.Observaciones;
                                            Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                        }
                                    }
                                    Avance.TareaDia = LstDomingo.Items[i].ToString() + "| " + datodiasig;
                                }
                                else
                                {
                                    EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (FilCDA1 != null)
                                    {
                                        ColCDAEliminar.Add(FilCDA1);
                                        Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                        Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                        Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                        Avance.Observaciones = FilCDA1.Observaciones;
                                        Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                    }
                                    else
                                    {
                                        EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                        if (FilCDA2 != null)
                                        {
                                            ColCDAEliminar.Add(FilCDA2);
                                            Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                            Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                            Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                            Avance.Observaciones = FilCDA2.Observaciones;
                                            Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                        }
                                    }
                                    Avance.TareaDia = LstDomingo.Items[i].ToString();
                                }
                            }
                        }  
                        //Avance.TareaDia = LstLunes.Items[i].ToString();                        
                        //ColAvance.Add(Avance);   
                     
                    }
                    else
                    {
                        Avance.Id_Cronograma = Id_CronogramaAux;
                        Avance.FechaDia = LblFDomingo.Text;
                        Avance.PorcentajeAvance = 0;
                        Avance.ObservacionAvance = string.Empty;
                        Avance.Dia = "Domingo";
                        Avance.FuenteVerificacion = string.Empty;
                        Avance.Observaciones = string.Empty;
                        string datodia = LstDomingo.Items[i].ToString();
                        if (datodia.Contains("(MOV)"))
                        { continue; }
                        else
                        {
                            EXT_CronogramaDiasAvance FilCDA1 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                            if (FilCDA1 != null)
                            {
                                ColCDAEliminar.Add(FilCDA1);
                                Avance.PorcentajeAvance = FilCDA1.PorcentajeAvance;
                                Avance.ObservacionAvance = FilCDA1.ObservacionAvance;
                                Avance.FuenteVerificacion = FilCDA1.FuenteVerificacion;
                                Avance.Observaciones = FilCDA1.Observaciones;
                                Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                            }
                            else
                            {
                                EXT_CronogramaDiasAvance FilCDA2 = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == Avance.Dia && x.TareaDia == datodia && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (FilCDA2 != null)
                                {
                                    ColCDAEliminar.Add(FilCDA2);
                                    Avance.PorcentajeAvance = FilCDA2.PorcentajeAvance;
                                    Avance.ObservacionAvance = FilCDA2.ObservacionAvance;
                                    Avance.FuenteVerificacion = FilCDA2.FuenteVerificacion;
                                    Avance.Observaciones = FilCDA2.Observaciones;
                                    Avance.Id_Cronograma = IdCronogramaEdicion;//asignamos el idcronograma para la nuevo insert
                                }
                            }
                            Avance.TareaDia = LstDomingo.Items[i].ToString();
                        }
                    }
                    ColAvance.Add(Avance);
                    //*****

                }                               
                crmdia.FechaLunes = LblFLunes.Text;
                crmdia.Lunes = diaLunes;
                crmdia.FechaMartes = LblFMartes.Text;
                crmdia.Martes = diaMartes;
                crmdia.FechaMiercoles = LblFMiercoles.Text;
                crmdia.Miercoles = diaMiercoles;
                crmdia.FechaJueves = LblFJueves.Text;
                crmdia.Jueves = diaJueves;
                crmdia.FechaViernes = LblFViernes.Text;
                crmdia.Viernes = diaViernes;
                crmdia.FechaSabado = LblFSabado.Text;
                crmdia.Sabado = diaSabado;
                crmdia.FechaDomingo = LblFDomingo.Text;
                crmdia.Domingo = diaDomingo;
                if (IdCronogramaEdicion > 0)//**hoy
                {
                    //se recupera los dias que tengas % 100 ya q se actualiza cronograma dia con todo los datos
                    crmdia.Id_Cronograma = IdCronogramaEdicion;  
                    EXT_CronogramaDias cdia_ = new EXT_CronogramaDias();                    
                    List<EXT_CronogramaDiasAvance> ColDA = ColCronogramaDiasAvanceEdit;
                    List<EXT_CronogramaDiasAvance> ColAvances100 = ColDA.Where(x => x.PorcentajeAvance == 100).ToList();
                    string Lunes_ = string.Empty;
                    string Martes_ = string.Empty;
                    string Miercoles_ = string.Empty;
                    string Jueves_ = string.Empty;
                    string Viernes_ = string.Empty;
                    string Sabado_ = string.Empty;
                    string Domingo_ = string.Empty;
                    foreach (EXT_CronogramaDiasAvance row1 in ColAvances100)
                    {
                        switch (row1.Dia)
                        {
                            case "Lunes":                                
                                List<EXT_CronogramaDiasAvance> ColLunes = ColDA.Where(x => x.Dia == "Lunes").ToList();                                
                                Lunes_ = Lunes_ + "| " + row1.TareaDia; 
                                break;
                            case "Martes":                                
                                List<EXT_CronogramaDiasAvance> ColMartes = ColDA.Where(x => x.Dia == "Martes").ToList();                                
                                Martes_ = Martes_ + "| " + row1.TareaDia;                                    
                                break;
                            case "Miercoles":                                
                                List<EXT_CronogramaDiasAvance> ColMiercoles = ColDA.Where(x => x.Dia == "Miercoles").ToList();                                
                                Miercoles_ = Miercoles_ + "| " + row1.TareaDia;       
                                break;
                            case "Jueves":                                
                                List<EXT_CronogramaDiasAvance> ColJueves = ColDA.Where(x => x.Dia == "Jueves").ToList();                                
                                Jueves_ = Jueves_ + "| " + row1.TareaDia; 
                                break;
                            case "Viernes":                                
                                List<EXT_CronogramaDiasAvance> ColViernes = ColDA.Where(x => x.Dia == "Viernes").ToList();                                
                                Viernes_ = Viernes_ + "| " + row1.TareaDia; 
                                break;
                            case "Sabado":                                
                                List<EXT_CronogramaDiasAvance> ColSabado = ColDA.Where(x => x.Dia == "Sabado").ToList();                                
                                Sabado_ = Sabado_ + "| " + row1.TareaDia; 
                                break;
                            case "Domingo":                                
                                List<EXT_CronogramaDiasAvance> ColDomingo = ColDA.Where(x => x.Dia == "Domingo").ToList();                                
                                Domingo_ = Domingo_ + "| " + row1.TareaDia; 
                                break;
                        }
                    }
                    
                    crmdia.Lunes = Lunes_ + diaLunes;                                        
                    crmdia.Martes = Martes_ + diaMartes;                    
                    crmdia.Miercoles = Miercoles_+ diaMiercoles;                    
                    crmdia.Jueves = Jueves_ + diaJueves;                    
                    crmdia.Viernes =Viernes_ +  diaViernes;                    
                    crmdia.Sabado = Sabado_ + diaSabado;                    
                    crmdia.Domingo = Domingo_ + diaDomingo;
                    
                    reg.DB_CRONOGRAMA_DIA_UPDATE(crmdia);//actualiza todo el objeto se recupera datos de la semana de "ColDA(linea 953)" y se une con lo seleccionado
                    
                    List<EXT_CronogramaDiasAvance> FiltroColAvanceEdit = ColCronogramaDiasEdit_AEliminar;//eliminados
                    List<EXT_CronogramaDiasAvance> ColCDARegistrados = ColCDAEliminar;//se registra en ColCDAEliminar los que no se modificaron los elimina y vuelve a crearlos
                    List<EXT_CronogramaDiasAvance> ColMix = new List<EXT_CronogramaDiasAvance>();
                    foreach (EXT_CronogramaDiasAvance cda in FiltroColAvanceEdit)
                    {
                        ColMix.Add(cda);                          
                    }
                    foreach (EXT_CronogramaDiasAvance cda in ColCDARegistrados)
                    {
                        ColMix.Add(cda);
                    }
                    List<EXT_CronogramaDiasAvance> FiltroColAvanceEdit2 = new List<EXT_CronogramaDiasAvance>();
                    var FiltroColAvanceEdit1 = ColMix.GroupBy(u => u.Id_CronogramaAvance)
                                                                  .Select(grp => new { Id_CronogramaAvance = grp.Key, CustomerList = grp.ToList() })
                                                                  .ToList();
                    foreach (var ed in FiltroColAvanceEdit1)
                    {
                        EXT_CronogramaDiasAvance Objfil = new EXT_CronogramaDiasAvance();
                        Objfil.Id_CronogramaAvance = ed.Id_CronogramaAvance;
                        FiltroColAvanceEdit2.Add(Objfil);
                    }
                    reg.DB_CRONOGRAMA_DIA_AVANCE_DELETE(FiltroColAvanceEdit2);//elimina por idcronogramaavance                    
                    reg.DB_Registrar_CRONOGRAMA_DIA_AVANCE(ColAvance);//los inserta nuevamente con le mismo idcronograma
                    //reg.DB_UPDATE_CRONOGRAMA_DIA_AVANCE(ColAvance);//Actualiza lo insertados ingresando las observacviones y avances
                }
                else
                {
                    reg.DB_Registrar_CRONOGRAMA_DIA(crmdia);
                    reg.DB_Registrar_CRONOGRAMA_DIA_AVANCE(ColAvance);
                }                
                Response.Redirect("frmListCronogramaSeg.aspx");
            }
            catch (Exception Ex)
            {
                //Response.Write("<script>window.alert('"+ Ex +"');</script>");
                //return;
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, Ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        #endregion

        protected void LnkAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Convert.ToDateTime(TxtFecha.Text);
                if (TxtFecha.Text == string.Empty)
                {
                    LblMsj.Text = "El campo Fecha de Inicio no puede ser vacio";
                    return;
                }                
                if (LblFLunes.Text == TxtFecha.Text)
                {
                    LblMsj.Text = "Fechas de Planificación ya Generadas";
                    return;                    
                }
                if (LblFLunes.Text != string.Empty)
                {
                    if (LblFLunes.Text != TxtFecha.Text)
                    {
                        LblFLunes.Text = TxtFecha.Text;
                        LblFMartes.Text = (Convert.ToDateTime(TxtFecha.Text)).AddDays(1).ToString("dd/MM/yyyy");
                        LblFMiercoles.Text = (Convert.ToDateTime(TxtFecha.Text)).AddDays(2).ToString("dd/MM/yyyy");
                        LblFJueves.Text = (Convert.ToDateTime(TxtFecha.Text)).AddDays(3).ToString("dd/MM/yyyy");
                        LblFViernes.Text = (Convert.ToDateTime(TxtFecha.Text)).AddDays(4).ToString("dd/MM/yyyy");
                        LblFSabado.Text = (Convert.ToDateTime(TxtFecha.Text)).AddDays(5).ToString("dd/MM/yyyy");
                        LblFDomingo.Text = (Convert.ToDateTime(TxtFecha.Text)).AddDays(6).ToString("dd/MM/yyyy");
                        Panel1.Enabled = true;
                        LblMsj.Text = string.Empty;
                        return;
                    }
                }                
                if (IdCronogramaEdicion > 0)
                { }
                else
                {
                    LstLunes.Items.Clear();
                    LstMartes.Items.Clear();
                    LstMiercoles.Items.Clear();
                    LstJueves.Items.Clear();
                    LstViernes.Items.Clear();
                    LstSabado.Items.Clear();
                    LstDomingo.Items.Clear();

                    Recuperar_Cronograma();
                    string jose = ((Convert.ToDateTime(TxtFecha.Text)).ToString("D", CultureInfo.CreateSpecificCulture("es-MX")));
                    if (jose[0].ToString() + jose[1].ToString() == "lu")
                    {
                        LblFLunes.Text = TxtFecha.Text;
                        LblFMartes.Text = (Convert.ToDateTime(TxtFecha.Text)).AddDays(1).ToString("dd/MM/yyyy");
                        LblFMiercoles.Text = (Convert.ToDateTime(TxtFecha.Text)).AddDays(2).ToString("dd/MM/yyyy");
                        LblFJueves.Text = (Convert.ToDateTime(TxtFecha.Text)).AddDays(3).ToString("dd/MM/yyyy");
                        LblFViernes.Text = (Convert.ToDateTime(TxtFecha.Text)).AddDays(4).ToString("dd/MM/yyyy");
                        LblFSabado.Text = (Convert.ToDateTime(TxtFecha.Text)).AddDays(5).ToString("dd/MM/yyyy");
                        LblFDomingo.Text = (Convert.ToDateTime(TxtFecha.Text)).AddDays(6).ToString("dd/MM/yyyy");
                        Panel1.Enabled = true;
                        LblMsj.Text = string.Empty;
                    }
                    else
                    {
                        LblMsj.Text = "Su planificación de tareas  tiene que comenzar en lunes";
                    }
                
                } //LR
            }
            catch (Exception Ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, Ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                //Response.Write("<script>window.alert('El campo Fecha de Inicio no puede ser vacio');</script>");
                //return;
            }
            
        }
        #region FUNCIONES PARA ELIMINAR TAREA
        private void Eliminar_LISTA()
        {            
            EXT_CronogramaDiasAvance ObjCDias = new EXT_CronogramaDiasAvance();
            EXT_CronogramaDiasAvance ObjNT = new EXT_CronogramaDiasAvance();
            if (LstLunes.SelectedIndex >= 0)
            {
                //***2
                if (IdCronogramaEdicion > 0)
                {
                    string nombre = LstLunes.SelectedValue;
                    //ObjCDias = ColCronogramaDiasAvanceEdit.Where(x => x.TareaDia == nombre).SingleOrDefault();
                    ObjCDias = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == "Lunes" && x.TareaDia == nombre && x.PorcentajeAvance < 100).SingleOrDefault();
                    if (ObjCDias != null)
                    {
                        //ColCD_TareasEliminar.Add(ObjCDias);                        
                        decimal avance = ObjCDias.PorcentajeAvance;
                        if (avance > 0)
                        {
                            LblMsj.Text = "No se puede eliminar: " + nombre.ToUpper() + "  Avance: " + avance + "%";
                            return;
                        }
                        else
                        { ColCronogramaDiasAvanceEdit.Where(x => x.Dia == "Lunes" && x.TareaDia == nombre && x.PorcentajeAvance < 100).SingleOrDefault().Id_Cronograma = 0; }
                    }
                }
                else
                {
                    //***
                    string selectarea = LstLunes.SelectedValue;
                    //ObjNT = ColCDANoTerminadas.Where(x => x.TareaDia == selectarea).SingleOrDefault();
                    ObjNT = ColCDANoTerminadas.Where(x => x.Dia == "Lunes" && x.TareaDia == selectarea && x.PorcentajeAvance < 100).SingleOrDefault();
                    if (ObjNT != null)
                    {
                        decimal avance = ObjNT.PorcentajeAvance;
                        if (avance > 0)
                        {
                            LblMsj.Text = "No se puede eliminar: " + selectarea.ToUpper() + "  Avance: " + avance + "%";
                            return;
                        }
                    }
                }                
                LstLunes.Items.RemoveAt(LstLunes.SelectedIndex);
            }
            else
            {
                if (LstMartes.SelectedIndex >= 0)
                {
                    //***2
                    if (IdCronogramaEdicion > 0)
                    {
                        string nombre = LstMartes.SelectedValue;
                        //ObjCDias = ColCronogramaDiasAvanceEdit.Where(x => x.TareaDia == nombre).SingleOrDefault();
                        ObjCDias = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == "Martes" && x.TareaDia == nombre && x.PorcentajeAvance < 100).SingleOrDefault();
                        if (ObjCDias != null)
                        {
                            //ColCD_TareasEliminar.Add(ObjCDias);                        
                            decimal avance = ObjCDias.PorcentajeAvance;
                            if (avance > 0)
                            {
                                LblMsj.Text = "No se puede eliminar:" + nombre.ToUpper() + "  Avance " + avance + "%";
                                return;
                            }
                            else
                            { ColCronogramaDiasAvanceEdit.Where(x => x.Dia == "Martes" && x.TareaDia == nombre && x.PorcentajeAvance < 100).SingleOrDefault().Id_Cronograma = 0; }
                        }
                    }
                    else
                    {
                        string selectarea = LstMartes.SelectedValue;
                        //ObjNT = ColCDANoTerminadas.Where(x => x.TareaDia == selectarea).SingleOrDefault();
                        ObjNT = ColCDANoTerminadas.Where(x => x.Dia == "Martes" && x.TareaDia == selectarea && x.PorcentajeAvance < 100).SingleOrDefault();
                        if (ObjNT != null)
                        {
                            decimal avance = ObjNT.PorcentajeAvance;
                            if (avance > 0)
                            {
                                LblMsj.Text = "No se puede eliminar: " + selectarea.ToUpper() + "  Avance: " + avance + "%";
                                return;
                            }
                        }
                    }
                    //***                    
                    LstMartes.Items.RemoveAt(LstMartes.SelectedIndex);
                }
                else
                {
                    if (LstMiercoles.SelectedIndex >= 0)
                    {
                        //***2
                        if (IdCronogramaEdicion > 0)
                        {
                            string nombre = LstMiercoles.SelectedValue;
                            //ObjCDias = ColCronogramaDiasAvanceEdit.Where(x => x.TareaDia == nombre).SingleOrDefault();
                            ObjCDias = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == "Miercoles" && x.TareaDia == nombre && x.PorcentajeAvance < 100).SingleOrDefault();
                            if (ObjCDias != null)
                            {
                                //ColCD_TareasEliminar.Add(ObjCDias);                        
                                decimal avance = ObjCDias.PorcentajeAvance;
                                if (avance > 0)
                                {
                                    LblMsj.Text = "No se puede eliminar:" + nombre.ToUpper() + "  Avance " + avance + "%";
                                    return;
                                }
                                else
                                { ColCronogramaDiasAvanceEdit.Where(x => x.Dia == "Miercoles" && x.TareaDia == nombre && x.PorcentajeAvance < 100).SingleOrDefault().Id_Cronograma = 0; }
                            }
                        }
                        else
                        {
                            string selectarea = LstMiercoles.SelectedValue;
                            //ObjNT = ColCDANoTerminadas.Where(x => x.TareaDia == selectarea).SingleOrDefault();
                            ObjNT = ColCDANoTerminadas.Where(x => x.Dia == "Miercoles" && x.TareaDia == selectarea && x.PorcentajeAvance < 100).SingleOrDefault();
                            if (ObjNT != null)
                            {
                                decimal avance = ObjNT.PorcentajeAvance;
                                if (avance > 0)
                                {
                                    LblMsj.Text = "No se puede eliminar: " + selectarea.ToUpper() + "  Avance: " + avance + "%";
                                    return;
                                }
                            }
                        }
                        //***                        
                        LstMiercoles.Items.RemoveAt(LstMiercoles.SelectedIndex);
                    }
                    else
                    {
                        if (LstJueves.SelectedIndex >= 0)
                        {
                            //***2
                            if (IdCronogramaEdicion > 0)
                            {
                                string nombre = LstJueves.SelectedValue;
                                //ObjCDias = ColCronogramaDiasAvanceEdit.Where(x => x.TareaDia == nombre).SingleOrDefault();
                                ObjCDias = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == "Jueves" && x.TareaDia == nombre && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (ObjCDias != null)
                                {
                                    //ColCD_TareasEliminar.Add(ObjCDias);                        
                                    decimal avance = ObjCDias.PorcentajeAvance;
                                    if (avance > 0)
                                    {
                                        LblMsj.Text = "No se puede eliminar:" + nombre.ToUpper() + "  Avance " + avance + "%";
                                        return;
                                    }
                                    else
                                    { ColCronogramaDiasAvanceEdit.Where(x => x.Dia == "Jueves" && x.TareaDia == nombre && x.PorcentajeAvance < 100).SingleOrDefault().Id_Cronograma = 0; }
                                }
                            }
                            else
                            {
                                //***
                                string selectarea = LstJueves.SelectedValue;
                                //ObjNT = ColCDANoTerminadas.Where(x => x.TareaDia == selectarea).SingleOrDefault();
                                ObjNT = ColCDANoTerminadas.Where(x => x.Dia == "Jueves" && x.TareaDia == selectarea && x.PorcentajeAvance < 100).SingleOrDefault();
                                if (ObjNT != null)
                                {
                                    decimal avance = ObjNT.PorcentajeAvance;
                                    if (avance > 0)
                                    {
                                        LblMsj.Text = "No se puede eliminar: " + selectarea.ToUpper() + "  Avance: " + avance + "%";
                                        return;
                                    }
                                }
                            }                            
                            LstJueves.Items.RemoveAt(LstJueves.SelectedIndex);
                        }
                        else
                        {
                            if (LstViernes.SelectedIndex >= 0)
                            {
                                //***2
                                if (IdCronogramaEdicion > 0)
                                {
                                    string nombre = LstViernes.SelectedValue;
                                    //ObjCDias = ColCronogramaDiasAvanceEdit.Where(x => x.TareaDia == nombre).SingleOrDefault();
                                    ObjCDias = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == "Viernes" && x.TareaDia == nombre && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (ObjCDias != null)
                                    {
                                        //ColCD_TareasEliminar.Add(ObjCDias);                        
                                        decimal avance = ObjCDias.PorcentajeAvance;
                                        if (avance > 0)
                                        {
                                            LblMsj.Text = "No se puede eliminar:" + nombre.ToUpper() + "  Avance " + avance + "%";
                                            return;
                                        }
                                        else
                                        { ColCronogramaDiasAvanceEdit.Where(x => x.Dia == "Viernes" && x.TareaDia == nombre && x.PorcentajeAvance < 100).SingleOrDefault().Id_Cronograma = 0; }
                                    }
                                }
                                else
                                {
                                    //***
                                    string selectarea = LstViernes.SelectedValue;
                                    //ObjNT = ColCDANoTerminadas.Where(x => x.TareaDia == selectarea).SingleOrDefault();
                                    ObjNT = ColCDANoTerminadas.Where(x => x.Dia == "Viernes" && x.TareaDia == selectarea && x.PorcentajeAvance < 100).SingleOrDefault();
                                    if (ObjNT != null)
                                    {
                                        decimal avance = ObjNT.PorcentajeAvance;
                                        if (avance > 0)
                                        {
                                            LblMsj.Text = "No se puede eliminar: " + selectarea.ToUpper() + "  Avance: " + avance + "%";
                                            return;
                                        }
                                    }
                                }                                
                                LstViernes.Items.RemoveAt(LstViernes.SelectedIndex);
                            }
                            else
                            {
                                if (LstSabado.SelectedIndex >= 0)
                                {
                                    //***2
                                    if (IdCronogramaEdicion > 0)
                                    {
                                        string nombre = LstSabado.SelectedValue;
                                        //ObjCDias = ColCronogramaDiasAvanceEdit.Where(x => x.TareaDia == nombre).SingleOrDefault();
                                        ObjCDias = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == "Sabado" && x.TareaDia == nombre && x.PorcentajeAvance < 100).SingleOrDefault();
                                        if (ObjCDias != null)
                                        {
                                            //ColCD_TareasEliminar.Add(ObjCDias);                        
                                            decimal avance = ObjCDias.PorcentajeAvance;
                                            if (avance > 0)
                                            {
                                                LblMsj.Text = "No se puede eliminar:" + nombre.ToUpper() + "  Avance " + avance + "%";
                                                return;
                                            }
                                            else
                                            { ColCronogramaDiasAvanceEdit.Where(x => x.Dia == "Sabado" && x.TareaDia == nombre && x.PorcentajeAvance < 100).SingleOrDefault().Id_Cronograma = 0; }
                                        }
                                    }
                                    else
                                    {
                                        string selectarea = LstSabado.SelectedValue;
                                        //ObjNT = ColCDANoTerminadas.Where(x => x.TareaDia == selectarea).SingleOrDefault();
                                        ObjNT = ColCDANoTerminadas.Where(x => x.Dia == "Sabado" && x.TareaDia == selectarea && x.PorcentajeAvance < 100).SingleOrDefault();
                                        if (ObjNT != null)
                                        {
                                            decimal avance = ObjNT.PorcentajeAvance;
                                            if (avance > 0)
                                            {
                                                LblMsj.Text = "No se puede eliminar: " + selectarea.ToUpper() + "  Avance: " + avance + "%";
                                                return;
                                            }
                                        }
                                    }
                                    //***
                                    
                                    LstSabado.Items.RemoveAt(LstSabado.SelectedIndex);
                                }
                                else
                                {
                                    if (LstDomingo.SelectedIndex >= 0)
                                    {
                                        //***2
                                        if (IdCronogramaEdicion > 0)
                                        {
                                            string nombre = LstDomingo.SelectedValue;
                                            //ObjCDias = ColCronogramaDiasAvanceEdit.Where(x => x.TareaDia == nombre).SingleOrDefault();
                                            ObjCDias = ColCronogramaDiasAvanceEdit.Where(x => x.Dia == "Domingo" && x.TareaDia == nombre && x.PorcentajeAvance < 100).SingleOrDefault();
                                            if (ObjCDias != null)
                                            {
                                                //ColCD_TareasEliminar.Add(ObjCDias);                        
                                                decimal avance = ObjCDias.PorcentajeAvance;
                                                if (avance > 0)
                                                {
                                                    LblMsj.Text = "No se puede eliminar:" + nombre.ToUpper() + "  Avance " + avance + "%";
                                                    return;
                                                }
                                                else
                                                { ColCronogramaDiasAvanceEdit.Where(x => x.Dia == "Domingo" && x.TareaDia == nombre && x.PorcentajeAvance < 100).SingleOrDefault().Id_Cronograma = 0; }
                                            }
                                        }
                                        else
                                        {
                                            string selectarea = LstDomingo.SelectedValue;
                                            //ObjNT = ColCDANoTerminadas.Where(x => x.TareaDia == selectarea).SingleOrDefault();
                                            ObjNT = ColCDANoTerminadas.Where(x => x.Dia == "Domingo" && x.TareaDia == selectarea && x.PorcentajeAvance < 100).SingleOrDefault();
                                            if (ObjNT != null)
                                            {
                                                decimal avance = ObjNT.PorcentajeAvance;
                                                if (avance > 0)
                                                {
                                                    LblMsj.Text = "No se puede eliminar: " + selectarea.ToUpper() + "  Avance: " + avance + "%";
                                                    return;
                                                }
                                            }
                                        }
                                        //***                                        
                                        LstDomingo.Items.RemoveAt(LstDomingo.SelectedIndex);
                                    }
                                    else
                                    {
                                        LblMsj.Text = "Debe Seleccionar la tarea a eliminar";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //List<EXT_CronogramaDiasAvance> ColCD_TareasEliminar = new List<EXT_CronogramaDiasAvance>();
            //ColCD_TareasEliminar.Add(ObjCDias);
            if (ColCronogramaDiasEdit_AEliminar.Count > 0)
            {
                if(ObjCDias != null)
                {
                    List<EXT_CronogramaDiasAvance> ColCD_TareasEliminar1 = new List<EXT_CronogramaDiasAvance>();
                    ColCD_TareasEliminar1 = ColCronogramaDiasEdit_AEliminar;
                    ColCD_TareasEliminar1.Add(ObjCDias);
                    ColCronogramaDiasEdit_AEliminar = ColCD_TareasEliminar1;
                }
            }
            else
            {
                if(ObjCDias != null)
                { 
                    List<EXT_CronogramaDiasAvance> ColCD_TareasEliminar1 = new List<EXT_CronogramaDiasAvance>();                
                    ColCD_TareasEliminar1.Add(ObjCDias);
                    ColCronogramaDiasEdit_AEliminar = ColCD_TareasEliminar1;
                }
            }
            //ColCronogramaDiasEdit_AEliminar = ColCD_TareasEliminar;
        }
        #endregion

        #region RECUPERA ACTIVIDADES DE CRONOGRAMAS ANTERIORES
        /// <summary>
        /// recupera actividades no completadas al 100% de cronogramas anteriores
        /// </summary>
        protected void Recuperar_Cronograma()
        {
            try 
            {
                DB_EXT_Cronogramas ListC = new DB_EXT_Cronogramas();
                //DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
                //int idcronograma = Convert.ToInt32(aux.DB_MaxId("EXT_CRONOGRAMA", "Id_Cronograma"));            
                DataTable ListaCronograma = ListC.DB_Desplegar_LISTA_CRONOGRAMAS(LblIdUsuario.Text, 0, 0, "LISTA_CRONOGRAMAS");
                foreach(DataRow cr in ListaCronograma.Rows)
                {
                    int idcronograma = Convert.ToInt16(cr["Id_Cronograma"].ToString());
                    //DataTable CronogramaAvance = ListC.DB_Desplegar_LISTA_ACTIVIDADES_CRONOGRAMA(idcronograma);
                    Recuperar_ActiviadadesCronograma(idcronograma);
                }  
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
                      
        }
        
        protected void Recuperar_ActiviadadesCronograma(int idcronograma)
        {
            DB_EXT_Cronogramas ListC = new DB_EXT_Cronogramas();
            List<EXT_CronogramaDiasAvance> ColCDAvance_Aux = new List<EXT_CronogramaDiasAvance>();
            List<EXT_CronogramaDiasAvance> ColNoTerminadas = new List<EXT_CronogramaDiasAvance>();// tareas recuperadas no terminadas
            DataTable CronogramaAvance = ListC.DB_Desplegar_LISTA_ACTIVIDADES_CRONOGRAMA(Convert.ToInt32(idcronograma));
            foreach (DataRow row in CronogramaAvance.Rows)
            {
                //EXT_CronogramaDiasAvance ObjAvance = new EXT_CronogramaDiasAvance();
                decimal avance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                //if (avance < 100)
                //{
                    string dia = row["Dia"].ToString();
                    switch (dia)
                    {
                        case "Lunes": 
                            EXT_CronogramaDiasAvance Avance1 = new EXT_CronogramaDiasAvance();//2                           
                            string tarea1 = row["TareaDia"].ToString();
                            EXT_CronogramaDiasAvance NT1 = new EXT_CronogramaDiasAvance();
                            if (tarea1.Contains("(MOV)") == true)
                            {
                                String value = row["TareaDia"].ToString();
                                Char delimiter = '|';
                                String[] Colstrings = value.Split(delimiter);
                                foreach (var substring in Colstrings)
                                {
                                    EXT_CronogramaDiasAvance Avance_ = new EXT_CronogramaDiasAvance();//2                                      
                                    EXT_CronogramaDiasAvance NT1_ = new EXT_CronogramaDiasAvance();//2                                      
                                    if (avance < 100)
                                    {
                                        LstLunes.Items.Add(substring);
                                        NT1_.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                        NT1_.TareaDia = substring;
                                        NT1_.Dia = row["Dia"].ToString();
                                        NT1_.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                        ColNoTerminadas.Add(NT1_);

                                    }                                    
                                    if (IdCronogramaEdicion > 0)//2
                                    {
                                        Avance_.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                        Avance_.Id_Cronograma = Convert.ToInt16(row["Id_Cronograma"].ToString());
                                        Avance_.FechaDia = row["FechaDia"].ToString();
                                        Avance_.TareaDia = substring;// row["TareaDia"].ToString();
                                        Avance_.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                        Avance_.ObservacionAvance = row["ObservacionAvance"].ToString();
                                        Avance_.Dia = row["Dia"].ToString();
                                        Avance_.FuenteVerificacion = row["FuenteVerificacion"].ToString();
                                        Avance_.Observaciones = row["Observaciones"].ToString();
                                        ColCDAvance_Aux.Add(Avance_);//2
                                    }  
                                }
                            }
                            else
                            {
                                if (avance < 100)
                                {
                                    LstLunes.Items.Add(tarea1);
                                    NT1.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                    NT1.TareaDia = tarea1;
                                    NT1.Dia = row["Dia"].ToString();
                                    NT1.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                    ColNoTerminadas.Add(NT1);
                                }  
                                
                                //2
                                if (IdCronogramaEdicion > 0)
                                {
                                    Avance1.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                    Avance1.Id_Cronograma = Convert.ToInt16(row["Id_Cronograma"].ToString());
                                    Avance1.FechaDia = row["FechaDia"].ToString();
                                    Avance1.TareaDia = row["TareaDia"].ToString();
                                    Avance1.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                    Avance1.ObservacionAvance = row["ObservacionAvance"].ToString();
                                    Avance1.Dia = row["Dia"].ToString();
                                    Avance1.FuenteVerificacion = row["FuenteVerificacion"].ToString();
                                    Avance1.Observaciones = row["Observaciones"].ToString();
                                    ColCDAvance_Aux.Add(Avance1);//2 
                                }
                            }
                            
                            break;
                        case "Martes":
                            EXT_CronogramaDiasAvance Avance2 = new EXT_CronogramaDiasAvance();//2     
                            string tarea2 = row["TareaDia"].ToString();
                            EXT_CronogramaDiasAvance NT2 = new EXT_CronogramaDiasAvance();
                            if (tarea2.Contains("(MOV)") == true)
                            {
                                String value = row["TareaDia"].ToString();
                                Char delimiter = '|';
                                String[] Colstrings = value.Split(delimiter);
                                foreach (var substring in Colstrings)
                                {
                                    EXT_CronogramaDiasAvance Avance_ = new EXT_CronogramaDiasAvance();//2   
                                    EXT_CronogramaDiasAvance NT2_ = new EXT_CronogramaDiasAvance();//2   
                                    if (avance < 100)
                                    {
                                        LstMartes.Items.Add(substring);
                                        NT2_.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                        NT2_.TareaDia = substring;
                                        NT2_.Dia = row["Dia"].ToString();
                                        NT2_.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                        ColNoTerminadas.Add(NT2_);
                                    }
                                    if (IdCronogramaEdicion > 0)//2
                                    {
                                        Avance_.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                        Avance_.Id_Cronograma = Convert.ToInt16(row["Id_Cronograma"].ToString());
                                        Avance_.FechaDia = row["FechaDia"].ToString();
                                        Avance_.TareaDia = substring;// row["TareaDia"].ToString();
                                        Avance_.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                        Avance_.ObservacionAvance = row["ObservacionAvance"].ToString();
                                        Avance_.Dia = row["Dia"].ToString();
                                        Avance_.FuenteVerificacion = row["FuenteVerificacion"].ToString();
                                        Avance_.Observaciones = row["Observaciones"].ToString();
                                        ColCDAvance_Aux.Add(Avance_);//2
                                    }  

                                }
                            }
                            else
                            {
                                if (avance < 100)
                                {
                                    LstMartes.Items.Add(tarea2);
                                    NT2.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                    NT2.TareaDia = tarea2;
                                    NT2.Dia = row["Dia"].ToString();
                                    NT2.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                    ColNoTerminadas.Add(NT2);
                                }  
                                
                                //2
                                if (IdCronogramaEdicion > 0)
                                {
                                    Avance2.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                    Avance2.Id_Cronograma = Convert.ToInt16(row["Id_Cronograma"].ToString());
                                    Avance2.FechaDia = row["FechaDia"].ToString();
                                    Avance2.TareaDia = row["TareaDia"].ToString();
                                    Avance2.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                    Avance2.ObservacionAvance = row["ObservacionAvance"].ToString();
                                    Avance2.Dia = row["Dia"].ToString();
                                    Avance2.FuenteVerificacion = row["FuenteVerificacion"].ToString();
                                    Avance2.Observaciones = row["Observaciones"].ToString();
                                    ColCDAvance_Aux.Add(Avance2);//2 
                                }
                            }
                            break;
                        case "Miercoles":
                            EXT_CronogramaDiasAvance Avance3 = new EXT_CronogramaDiasAvance();//2     
                            string tarea3 = row["TareaDia"].ToString();
                            EXT_CronogramaDiasAvance NT3 = new EXT_CronogramaDiasAvance();//2     
                            if (tarea3.Contains("(MOV)") == true)
                            {
                                String value = row["TareaDia"].ToString();
                                Char delimiter = '|';
                                String[] Colstrings = value.Split(delimiter);
                                foreach (var substring in Colstrings)
                                {                                    
                                    EXT_CronogramaDiasAvance Avance_ = new EXT_CronogramaDiasAvance();//2   
                                    EXT_CronogramaDiasAvance NT3_ = new EXT_CronogramaDiasAvance();//2   
                                    if (avance < 100)
                                    {
                                        LstMiercoles.Items.Add(substring);
                                        NT3_.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                        NT3_.TareaDia = substring;
                                        NT3_.Dia = row["Dia"].ToString();
                                        NT3_.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                        ColNoTerminadas.Add(NT3_);
                                    }
                                    if (IdCronogramaEdicion > 0)//2
                                    {
                                        Avance_.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                        Avance_.Id_Cronograma = Convert.ToInt16(row["Id_Cronograma"].ToString());
                                        Avance_.FechaDia = row["FechaDia"].ToString();
                                        Avance_.TareaDia = substring;// row["TareaDia"].ToString();
                                        Avance_.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                        Avance_.ObservacionAvance = row["ObservacionAvance"].ToString();
                                        Avance_.Dia = row["Dia"].ToString();
                                        Avance_.FuenteVerificacion = row["FuenteVerificacion"].ToString();
                                        Avance_.Observaciones = row["Observaciones"].ToString();
                                        ColCDAvance_Aux.Add(Avance_);//2
                                    }  
                                }
                            }
                            else
                            {
                                
                                if (avance < 100)
                                {
                                    LstMiercoles.Items.Add(tarea3);
                                    NT3.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                    NT3.TareaDia = tarea3;
                                    NT3.Dia = row["Dia"].ToString();
                                    NT3.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                    ColNoTerminadas.Add(NT3);
                                }

                                //2
                                if (IdCronogramaEdicion > 0)
                                {
                                    Avance3.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                    Avance3.Id_Cronograma = Convert.ToInt16(row["Id_Cronograma"].ToString());
                                    Avance3.FechaDia = row["FechaDia"].ToString();
                                    Avance3.TareaDia = row["TareaDia"].ToString();
                                    Avance3.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                    Avance3.ObservacionAvance = row["ObservacionAvance"].ToString();
                                    Avance3.Dia = row["Dia"].ToString();
                                    Avance3.FuenteVerificacion = row["FuenteVerificacion"].ToString();
                                    Avance3.Observaciones = row["Observaciones"].ToString();
                                    ColCDAvance_Aux.Add(Avance3);//2 
                                }
                            }
                            break;
                        case "Jueves":
                            EXT_CronogramaDiasAvance Avance4 = new EXT_CronogramaDiasAvance();//2   
                            string tarea4 = row["TareaDia"].ToString();
                            EXT_CronogramaDiasAvance NT4 = new EXT_CronogramaDiasAvance();
                            if (tarea4.Contains("(MOV)") == true)
                            {
                                String value = row["TareaDia"].ToString();
                                Char delimiter = '|';
                                String[] Colstrings = value.Split(delimiter);
                                foreach (var substring in Colstrings)
                                {
                                    EXT_CronogramaDiasAvance Avance_ = new EXT_CronogramaDiasAvance();//2 
                                    EXT_CronogramaDiasAvance NT4_ = new EXT_CronogramaDiasAvance();
                                    if (avance < 100)
                                    {
                                        LstJueves.Items.Add(substring);
                                        NT4_.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                        NT4_.TareaDia = substring;
                                        NT4_.Dia = row["Dia"].ToString();
                                        NT4_.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                        ColNoTerminadas.Add(NT4_);
                                    }
                                    if (IdCronogramaEdicion > 0)//2
                                    {
                                        Avance_.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                        Avance_.Id_Cronograma = Convert.ToInt16(row["Id_Cronograma"].ToString());
                                        Avance_.FechaDia = row["FechaDia"].ToString();
                                        Avance_.TareaDia = substring;// row["TareaDia"].ToString();
                                        Avance_.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                        Avance_.ObservacionAvance = row["ObservacionAvance"].ToString();
                                        Avance_.Dia = row["Dia"].ToString();
                                        Avance_.FuenteVerificacion = row["FuenteVerificacion"].ToString();
                                        Avance_.Observaciones = row["Observaciones"].ToString();
                                        ColCDAvance_Aux.Add(Avance_);//2
                                    }  
                                }
                            }
                            else
                            {
                                if (avance < 100)
                                {
                                    LstJueves.Items.Add(tarea4);
                                    NT4.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                    NT4.TareaDia = tarea4;
                                    NT4.Dia = row["Dia"].ToString();
                                    NT4.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                    ColNoTerminadas.Add(NT4);
                                }
                                //2
                                if (IdCronogramaEdicion > 0)
                                {
                                    Avance4.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                    Avance4.Id_Cronograma = Convert.ToInt16(row["Id_Cronograma"].ToString());
                                    Avance4.FechaDia = row["FechaDia"].ToString();
                                    Avance4.TareaDia = row["TareaDia"].ToString();
                                    Avance4.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                    Avance4.ObservacionAvance = row["ObservacionAvance"].ToString();
                                    Avance4.Dia = row["Dia"].ToString();
                                    Avance4.FuenteVerificacion = row["FuenteVerificacion"].ToString();
                                    Avance4.Observaciones = row["Observaciones"].ToString();
                                    ColCDAvance_Aux.Add(Avance4);//2 
                                }
                            }
                            break;
                        case "Viernes":
                            EXT_CronogramaDiasAvance Avance5 = new EXT_CronogramaDiasAvance();//2  
                            string tarea5 = row["TareaDia"].ToString();
                            EXT_CronogramaDiasAvance NT5 = new EXT_CronogramaDiasAvance();
                            if (tarea5.Contains("(MOV)") == true)
                            {
                                String value = row["TareaDia"].ToString();
                                Char delimiter = '|';
                                String[] Colstrings = value.Split(delimiter);
                                foreach (var substring in Colstrings)
                                {
                                    EXT_CronogramaDiasAvance Avance_ = new EXT_CronogramaDiasAvance();//2   
                                    EXT_CronogramaDiasAvance NT5_ = new EXT_CronogramaDiasAvance();//2   
                                    if (avance < 100)
                                    {
                                        LstViernes.Items.Add(substring);
                                        NT5_.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                        NT5_.TareaDia = substring;
                                        NT5_.Dia = row["Dia"].ToString();
                                        NT5_.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                        ColNoTerminadas.Add(NT5_);
                                    }
                                    if (IdCronogramaEdicion > 0)//2
                                    {
                                        Avance_.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                        Avance_.Id_Cronograma = Convert.ToInt16(row["Id_Cronograma"].ToString());
                                        Avance_.FechaDia = row["FechaDia"].ToString();
                                        Avance_.TareaDia = substring;// row["TareaDia"].ToString();
                                        Avance_.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                        Avance_.ObservacionAvance = row["ObservacionAvance"].ToString();
                                        Avance_.Dia = row["Dia"].ToString();
                                        Avance_.FuenteVerificacion = row["FuenteVerificacion"].ToString();
                                        Avance_.Observaciones = row["Observaciones"].ToString();
                                        ColCDAvance_Aux.Add(Avance_);//2
                                    }  
                                }
                            }
                            else
                            {
                                if (avance < 100)
                                {
                                    LstViernes.Items.Add(tarea5);
                                    NT5.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                    NT5.TareaDia = tarea5;
                                    NT5.Dia = row["Dia"].ToString();
                                    NT5.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                    ColNoTerminadas.Add(NT5);
                                }
                                //2
                                if (IdCronogramaEdicion > 0)
                                {
                                    Avance5.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                    Avance5.Id_Cronograma = Convert.ToInt16(row["Id_Cronograma"].ToString());
                                    Avance5.FechaDia = row["FechaDia"].ToString();
                                    Avance5.TareaDia = row["TareaDia"].ToString();
                                    Avance5.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                    Avance5.ObservacionAvance = row["ObservacionAvance"].ToString();
                                    Avance5.Dia = row["Dia"].ToString();
                                    Avance5.FuenteVerificacion = row["FuenteVerificacion"].ToString();
                                    Avance5.Observaciones = row["Observaciones"].ToString();
                                    ColCDAvance_Aux.Add(Avance5);//2 
                                }
                            }
                            break;
                        case "Sabado":
                            EXT_CronogramaDiasAvance Avance6 = new EXT_CronogramaDiasAvance();//2  
                            string tarea6 = row["TareaDia"].ToString();
                            EXT_CronogramaDiasAvance NT6 = new EXT_CronogramaDiasAvance();//2  
                            if (tarea6.Contains("(MOV)") == true)
                            {
                                String value = row["TareaDia"].ToString();
                                Char delimiter = '|';
                                String[] Colstrings = value.Split(delimiter);
                                foreach (var substring in Colstrings)
                                {                                    
                                    EXT_CronogramaDiasAvance Avance_ = new EXT_CronogramaDiasAvance();//2   
                                    EXT_CronogramaDiasAvance NT6_ = new EXT_CronogramaDiasAvance();//2   
                                    if (avance < 100)
                                    {
                                        LstSabado.Items.Add(substring);
                                        NT6_.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                        NT6_.TareaDia = substring;
                                        NT6_.Dia = row["Dia"].ToString();
                                        NT6_.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                        ColNoTerminadas.Add(NT6_);
                                    }
                                    if (IdCronogramaEdicion > 0)//2
                                    {
                                        Avance_.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                        Avance_.Id_Cronograma = Convert.ToInt16(row["Id_Cronograma"].ToString());
                                        Avance_.FechaDia = row["FechaDia"].ToString();
                                        Avance_.TareaDia = substring;// row["TareaDia"].ToString();
                                        Avance_.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                        Avance_.ObservacionAvance = row["ObservacionAvance"].ToString();
                                        Avance_.Dia = row["Dia"].ToString();
                                        Avance_.FuenteVerificacion = row["FuenteVerificacion"].ToString();
                                        Avance_.Observaciones = row["Observaciones"].ToString();
                                        ColCDAvance_Aux.Add(Avance_);//2
                                    }  
                                }
                            }
                            else
                            {
                                
                                if (avance < 100)
                                {
                                    LstSabado.Items.Add(tarea6);
                                    NT6.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                    NT6.TareaDia = tarea6;
                                    NT6.Dia = row["Dia"].ToString();
                                    NT6.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                    ColNoTerminadas.Add(NT6);
                                }
                                //2
                                if (IdCronogramaEdicion > 0)
                                {
                                    Avance6.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                    Avance6.Id_Cronograma = Convert.ToInt16(row["Id_Cronograma"].ToString());
                                    Avance6.FechaDia = row["FechaDia"].ToString();
                                    Avance6.TareaDia = row["TareaDia"].ToString();
                                    Avance6.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                    Avance6.ObservacionAvance = row["ObservacionAvance"].ToString();
                                    Avance6.Dia = row["Dia"].ToString();
                                    Avance6.FuenteVerificacion = row["FuenteVerificacion"].ToString();
                                    Avance6.Observaciones = row["Observaciones"].ToString();
                                    ColCDAvance_Aux.Add(Avance6);//2 
                                }
                            }
                            break;
                        case "Domingo":
                            EXT_CronogramaDiasAvance Avance7 = new EXT_CronogramaDiasAvance();//2 
                            string tarea7 = row["TareaDia"].ToString();
                            EXT_CronogramaDiasAvance NT7 = new EXT_CronogramaDiasAvance();
                            if (tarea7.Contains("(MOV)") == true)
                            {
                                String value = row["TareaDia"].ToString();
                                Char delimiter = '|';
                                String[] Colstrings = value.Split(delimiter);
                                foreach (var substring in Colstrings)
                                {                                    
                                    EXT_CronogramaDiasAvance Avance_ = new EXT_CronogramaDiasAvance();//2   
                                    EXT_CronogramaDiasAvance NT7_ = new EXT_CronogramaDiasAvance();//2   
                                    if (avance < 100)
                                    {
                                        LstDomingo.Items.Add(substring);
                                        NT7_.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                        NT7_.TareaDia = substring;
                                        NT7_.Dia = row["Dia"].ToString();
                                        NT7_.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                        ColNoTerminadas.Add(NT7_);
                                    }
                                    if (IdCronogramaEdicion > 0)//2
                                    {
                                        Avance_.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                        Avance_.Id_Cronograma = Convert.ToInt16(row["Id_Cronograma"].ToString());
                                        Avance_.FechaDia = row["FechaDia"].ToString();
                                        Avance_.TareaDia = substring;// row["TareaDia"].ToString();
                                        Avance_.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                        Avance_.ObservacionAvance = row["ObservacionAvance"].ToString();
                                        Avance_.Dia = row["Dia"].ToString();
                                        Avance_.FuenteVerificacion = row["FuenteVerificacion"].ToString();
                                        Avance_.Observaciones = row["Observaciones"].ToString();
                                        ColCDAvance_Aux.Add(Avance_);//2
                                    }  
                                }
                            }
                            else
                            {
                                
                                if (avance < 100)
                                {
                                    LstDomingo.Items.Add(tarea7);
                                    NT7.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                    NT7.TareaDia = tarea7;
                                    NT7.Dia = row["Dia"].ToString();
                                    NT7.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                    ColNoTerminadas.Add(NT7);
                                }
                                //2
                                if (IdCronogramaEdicion > 0)
                                {
                                    Avance7.Id_CronogramaAvance = Convert.ToInt16(row["Id_CronogramaAvance"].ToString());
                                    Avance7.Id_Cronograma = Convert.ToInt16(row["Id_Cronograma"].ToString());
                                    Avance7.FechaDia = row["FechaDia"].ToString();
                                    Avance7.TareaDia = row["TareaDia"].ToString();
                                    Avance7.PorcentajeAvance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                                    Avance7.ObservacionAvance = row["ObservacionAvance"].ToString();
                                    Avance7.Dia = row["Dia"].ToString();
                                    Avance7.FuenteVerificacion = row["FuenteVerificacion"].ToString();
                                    Avance7.Observaciones = row["Observaciones"].ToString();
                                    ColCDAvance_Aux.Add(Avance7);//2 
                                }
                            }
                            break;
                    }
                //}


            }
            ColCronogramaDiasAvanceEdit = ColCDAvance_Aux;
            ColCDANoTerminadas = ColNoTerminadas;
        }
        protected void EditarCoronograma(int idCronEdit)
        {
            try
            {
                IdCronogramaEdicion = Convert.ToInt16(idCronEdit);
                DB_EXT_Cronogramas ConDBCronograma = new DB_EXT_Cronogramas();

                IList<EXT_Cronograma> ColCronograma = new List<EXT_Cronograma>();
                IList<EXT_CronogramaDias> ColCronograma_dia = new List<EXT_CronogramaDias>();

                DataTable DTCronograma = new DataTable();
                DataTable DTCronograma_dia = new DataTable();
                
                DTCronograma = ConDBCronograma.DB_OBTENER_DATOS_CRONOGRAMA_EDICION(IdCronogramaEdicion, "CRONOGRAMA");
                EXT_Cronograma ObjCronograma = new EXT_Cronograma();
                foreach (DataRow rowcrono in DTCronograma.Rows)
                {                    
                    ObjCronograma.Id_Cronograma = Convert.ToInt16(rowcrono["Id_Cronograma"].ToString());
                    ObjCronograma.Id_Campanhia = Convert.ToInt16(rowcrono["Id_Campanhia"].ToString());
                    ObjCronograma.Id_Usuario = LblIdUsuario.Text;
                    ObjCronograma.Id_Regional = Convert.ToInt16(rowcrono["Id_Regional"].ToString());
                    ObjCronograma.Nombre = rowcrono["Nombre"].ToString();
                    ObjCronograma.Fecha_Envio = Convert.ToDateTime(rowcrono["Fecha_Envio"].ToString());
                    ObjCronograma.Mes = rowcrono["Mes"].ToString();
                    ObjCronograma.Semana = rowcrono["Semana"].ToString();
                    ObjCronograma.Observacion = rowcrono["Observacion"].ToString();
                    ObjCronograma.Estado = rowcrono["Estado"].ToString();

                    CronogramaEdit = ObjCronograma;

                    TxtNombre.Text = rowcrono["Nombre"].ToString();
                    DDLSemana.SelectedValue = rowcrono["Semana"].ToString();
                    //DDLSemana.Enabled = false;
                    TxtFecha.Enabled = false;
                    LnkAceptar.Enabled = false;
                    Panel1.Enabled = true;
                    
                }
                CronogramaEdit = ObjCronograma;
                DTCronograma_dia = ConDBCronograma.DB_OBTENER_DATOS_CRONOGRAMA_EDICION(IdCronogramaEdicion, "CRONOGRAMA_DIA");
                EXT_CronogramaDias ObjCronogramaDias = new EXT_CronogramaDias();
                foreach (DataRow rowdia in DTCronograma_dia.Rows)
                {                    
                    ObjCronogramaDias.Id_Cronograma = Convert.ToInt16(rowdia["Id_Cronograma"].ToString());
                    
                    ObjCronogramaDias.FechaLunes = rowdia["FechaLunes"].ToString();
                    ObjCronogramaDias.Lunes = rowdia["Lunes"].ToString();
                    
                    ObjCronogramaDias.FechaMartes = rowdia["FechaMartes"].ToString();
                    ObjCronogramaDias.Martes = rowdia["Martes"].ToString();
                    
                    ObjCronogramaDias.FechaMiercoles = rowdia["FechaMiercoles"].ToString();
                    ObjCronogramaDias.Miercoles = rowdia["Miercoles"].ToString();

                    ObjCronogramaDias.FechaJueves = rowdia["FechaJueves"].ToString();
                    ObjCronogramaDias.Jueves = rowdia["Jueves"].ToString();

                    ObjCronogramaDias.FechaViernes = rowdia["FechaViernes"].ToString();
                    ObjCronogramaDias.Viernes = rowdia["Viernes"].ToString();

                    ObjCronogramaDias.FechaSabado = rowdia["FechaSabado"].ToString();
                    ObjCronogramaDias.Sabado = rowdia["Sabado"].ToString();

                    ObjCronogramaDias.FechaDomingo = rowdia["FechaDomingo"].ToString();
                    ObjCronogramaDias.Domingo = rowdia["Domingo"].ToString();
                    
                    
                    LblFLunes.Text = rowdia["FechaLunes"].ToString();
                    LblFMartes.Text = rowdia["FechaMartes"].ToString();
                    LblFMiercoles.Text = rowdia["FechaMiercoles"].ToString();
                    LblFJueves.Text = rowdia["FechaJueves"].ToString();
                    LblFViernes.Text = rowdia["FechaViernes"].ToString();
                    LblFSabado.Text = rowdia["FechaSabado"].ToString();
                    LblFDomingo.Text = rowdia["FechaDomingo"].ToString();

                    TxtFecha.Text = rowdia["FechaLunes"].ToString();
                    

                }
                CronogramaDiasEdit = ObjCronogramaDias;

                Recuperar_ActiviadadesCronograma(Convert.ToInt16(idCronEdit));

            }
            catch(Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
        }
        #endregion
        /// <summary>
        /// Limpia las selecciones de los listbox
        /// </summary>
        protected void ClearSelectionListBox()
        {
            LstLunes.ClearSelection();
            LstMartes.ClearSelection();
            LstMiercoles.ClearSelection();
            LstJueves.ClearSelection();
            LstViernes.ClearSelection();
            LstSabado.ClearSelection();
            LstDomingo.ClearSelection();
        }
        protected void ImgBtnElininar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Eliminar_LISTA();
                ClearSelectionListBox();
            }
            catch(Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
            
        }

        protected void BtnOrgInsert0_Click(object sender, EventArgs e)
        {
            try 
            {
                Insertar_TAREA((DDLActividadesOficina.SelectedItem.Text) + (txtDDLActividadesOficina.Text == "" ? "" : "(Otro:)" + txtDDLActividadesOficina.Text));
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }            
        }

        protected void BtnOrgInsert1_Click(object sender, EventArgs e)
        {
            try
            {
                Insertar_TAREA((DDLActividadesApoyoProduccion.SelectedItem.Text) + (txtDDLActividadesApoyoProduccion.Text == "" ? "" : "(Otro:)" + txtDDLActividadesApoyoProduccion.Text));
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
            
        }

        protected void BtnOrgInsert2_Click(object sender, EventArgs e)
        {
            try
            {
                Insertar_TAREA((DDLActividadesEmpresasProveedoras.SelectedItem.Text) + (txtDDLActividadesEmpresasProveedoras.Text == "" ? "" : "(Otro:)" + txtDDLActividadesEmpresasProveedoras.Text));
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
            
        }

        protected void BtnOrgInsert3_Click(object sender, EventArgs e)
        {
            try
            {
                Insertar_TAREA((DDLActividadesExtensionAgricola.SelectedItem.Text) + (txtDDLActividadesExtensionAgricola.Text == "" ? "" : "(Otro:)" + txtDDLActividadesExtensionAgricola.Text));
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
            
        }

        protected void BtnOrgInsert4_Click(object sender, EventArgs e)
        {
            try
            {
                Insertar_TAREA((DDLActividadesFortalecimiento.SelectedItem.Text) + (txtDDLActividadesFortalecimiento.Text == "" ? "" : "(Otro:)" + txtDDLActividadesFortalecimiento.Text));
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
            
        }

        protected void BtnOrgInsert5_Click(object sender, EventArgs e)
        {
            try
            {
                Insertar_TAREA((DDLActividadesMonitoreo.SelectedItem.Text) + (txtDDLActividadesMonitoreo.Text == "" ? "" : "(Otro:)" + txtDDLActividadesMonitoreo.Text));            
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
            
        }

        protected void BtnOrgInsert6_Click(object sender, EventArgs e)
        {
            try
            {
                Insertar_TAREA((DDLActividadesReprogramacionDeuda.SelectedItem.Text) + (txtDDLActividadesReprogramacionDeuda.Text == "" ? "" : "(Otro:)" + txtDDLActividadesReprogramacionDeuda.Text));
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
            
        }

        protected void BtnOrgInsert7_Click(object sender, EventArgs e)
        {
            try
            {
                Insertar_TAREA((DDLActividadesOtros.SelectedItem.Text) + (txtDDLActividadesOtros.Text == "" ? "" : "(Otro:)" + txtDDLActividadesOtros.Text));            
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
            
        }

              
    }
}