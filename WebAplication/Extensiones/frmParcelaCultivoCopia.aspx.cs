using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;
using DataBusiness.DB_Extensiones;
using DataEntity.DE_Extensiones;

namespace WebAplication.Extensiones
{
    public partial class frmParcelaCultivoCopia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            if (!IsPostBack)
            {
                LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                LblIdInsProd.Text = Session["IdInsProd"].ToString();
                LblIdUsuario.Text = Session["IdUser"].ToString();
                LblEtapa.Text = Session["Etapa"].ToString();
                LblEstado.Text = Session["Estado"].ToString();
                //Control_FORMULARIO();
                Datos_Org_ENCABEZADO();
                Cargar_COMBO();
                Control_FORMULARIO();
                /*****************************************************/
                DataTable dtListaPartida1 = new DataTable();
                dtListaPartida1.Columns.AddRange(new DataColumn[5] { new DataColumn("Adversidad"), new DataColumn("Descripcion"), new DataColumn("Intencidad"), new DataColumn("Porcentaje"), new DataColumn("Tratamiento") });
                GVAdversidad.DataSource = dtListaPartida1;
                GVAdversidad.DataBind();
                Session["datos1"] = dtListaPartida1;
                /*************************************/
                DataTable dtListaPartida = new DataTable();
                dtListaPartida.Columns.AddRange(new DataColumn[5] { new DataColumn("Id_Fenologia"), new DataColumn("FaceFenologica"), new DataColumn("EstadoFF"), new DataColumn("Porcentaje"), new DataColumn("Fecha_Cosecha") });
                GVSegCultivo.DataSource = dtListaPartida;
                GVSegCultivo.DataBind();
                Session["datos"] = dtListaPartida;
                Contro2_FORMULARIO();
                /********************************************/
                Calcularar_AVANCE_SIEMBRA();
                Calcularar_AVANCE_SIEMBRA_CULTIVO();
                /*********************************************/
                ////Desplegar_INSUMOS_PRODUCTOR();
            }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Datos_Org_ENCABEZADO()
        {
            DB_AP_Registro_Org d_org = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = d_org.DB_Desplegar_ENCABEZADO_ORG(Convert.ToInt32(LblIdInsOrg.Text));
            LblOrg.Text = dt.Rows[0][2].ToString();
            LblIdCamp.Text = dt.Rows[0][5].ToString();
            LblCamp.Text = dt.Rows[0][6].ToString();
            LblProg.Text = dt.Rows[0][9].ToString();
            //LblProg.Text = "MAIZ";
            LblIdReg.Text = dt.Rows[0][7].ToString();
            DB_AP_Productor p = new DB_AP_Productor();
            dt = p.DB_Seleccionar_ENCABEZADO_PROD(LblIdInsProd.Text, "DATS_PROD");
            LblProductor.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString();
            LblSup.Text = dt.Rows[0][12].ToString();
            LblComunidad.Text = dt.Rows[0][14].ToString();
            LblMunicipio.Text = dt.Rows[0][15].ToString();
            LblProvincia.Text = dt.Rows[0][16].ToString();
            LblDepart.Text = dt.Rows[0][17].ToString();
        }
        #endregion
        #region FUNCIONES DEL COMBO
        private void Cargar_COMBO()
        {
            DB_EXT_Fenologia nd = new DB_EXT_Fenologia();
            List<EXT_Fenologia> ListaF = nd.DB_Desplegar_FENOLOGIA(LblProg.Text, LblIdInsProd.Text);
            DDLFenologia.DataSource = ListaF;
            DDLFenologia.DataValueField = "Id_Fenologia";
            DDLFenologia.DataTextField = "Nom_Fenologia";
            DDLFenologia.DataBind();
        }
        #endregion
        #region FUNCIONES PARA CONTROLAR EL USUARIO
        private void Control_FORMULARIO()
        {
            /**************************************************************************/
            DB_EXT_Seguimiento num = new DB_EXT_Seguimiento();
            DataTable dt = new DataTable();
            dt = num.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg.Text), LblIdInsProd.Text, "", "NUMSEG");
            if (DDLFenologia.SelectedItem.Text == "FECHA Y AVANCE DE SIEMBRA")
            {
                LblNumSegCult.Text = "1";
            }
            else
            {
                LblNumSegCult.Text = dt.Rows[0][0].ToString();
            }
            PnlOBsRec.Visible = true;
        }
        #endregion
        #region FUNCIONES PARA EL CONTROL DE **************************************?
        private void Contro2_FORMULARIO()
        {

            if (DDLFenologia.SelectedItem.Text == "FECHA Y AVANCE DE SIEMBRA")
            {
                LblFechaFase.Text = "Etapa:";
                DDLEstadoFF.Enabled = false;
                DDLEstadoFF.Items.Insert(0, new ListItem("Avance", "Avance", true));
                DDLEstadoFF.DataBind();
                DDLEstadoFF.ClearSelection();
            }
        }
        #endregion
        #region CARGAR LOS VALORES DE LOS RENDIMIENTOS Y LA SUPERFICIE PARA LA COSECHA
        protected void Seleccionar_VALORES_COSECHA()
        {
            DB_EXT_Rendimiento rend = new DB_EXT_Rendimiento();
            DataTable dt = new DataTable();
            dt = rend.DB_Reporte_DETALLE_PLANILLA_CULTIVO(LblIdInsProd.Text, "SUP_CULTIVADA");
            if(dt.Rows.Count > 0)
            {
                TxtSupSiem.Text = ((Convert.ToDecimal(dt.Rows[0][0].ToString()) * Convert.ToDecimal(dt.Rows[0][1].ToString())) / 100).ToString();
                dt = rend.DB_Reporte_DETALLE_PLANILLA_CULTIVO(LblIdInsProd.Text, "REND_PROD");
                if (dt.Rows.Count > 0)
                {
                    TxtRedimiento.Text = dt.Rows[0][9].ToString();
                    TxtPesoApro.Text = (Convert.ToDecimal(TxtRedimiento.Text) * Convert.ToDecimal(TxtSupSiem.Text)).ToString();
                }
                else 
                {
                    TxtRedimiento.Text = "0";
                    TxtPesoApro.Text = "0";
                }
            }
            else
            {
                TxtSupSiem.Text = "0";
                TxtRedimiento.Text = "0"; 
                TxtPesoApro.Text="0";
            }
            dt = rend.DB_Reporte_DETALLE_PLANILLA_CULTIVO(LblIdInsProd.Text, "FECHA_SIEMBRA");
            TxtFechSiem.Text = dt.Rows[0][1].ToString();
        }
        #endregion
        #region FUNCION PARA CONTROLAR DEL COMBO DE FACE FENOLOGICA DEL CULTIVO
        protected void DDLFenologia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control_FORMULARIO();
            if (DDLFenologia.SelectedItem.Text == "FECHA COSECHA PROBABLE")
            {
                TxtFechaFase.Visible = true;
                DDLEstadoFF.Visible = true;
                DDLEstadoFF.Enabled = true;
                DDLEstadoFF.Items.Clear();
                DDLEstadoFF.Items.Insert(0, new ListItem("Inicial", "Inicial", true));
                DDLEstadoFF.Items.Insert(1, new ListItem("Final", "Final", true));
                DDLEstadoFF.DataBind();
                TxtPorcentaje.Visible = false;
                LblFechaFase.Text = "Fecha:";
                LblValor1.Visible = false;
                Panel1.Visible = false;
            }
            else 
            {
                if (DDLFenologia.SelectedItem.Text == "COSECHA Y ACOPIO")
                {
                    DDLEstadoFF.Enabled = false;
                    DDLEstadoFF.Visible = true;
                    DDLEstadoFF.Items.Insert(0, new ListItem("Avance", "Avance", true));
                    Panel1.Visible=true;
                    TxtFechaFase.Visible = false;
                    TxtPorcentaje.Visible = true;
                    Seleccionar_VALORES_COSECHA();
                }
                else
                {
                    DDLEstadoFF.Enabled = false;
                    DDLEstadoFF.Visible = true;
                    DDLEstadoFF.Items.Insert(0, new ListItem("Avance", "Avance", true));
                    DDLEstadoFF.DataBind();
                    DDLEstadoFF.ClearSelection();
                    TxtFechaFase.Visible = false;
                    LblFechaFase.Text = "Etapa:";
                    TxtPorcentaje.Visible = true;
                    TxtFechaFase.Visible = false;
                    LblValor1.Visible = true;
                    Panel1.Visible = false;
                }

            }
            Calcularar_AVANCE_SIEMBRA();
            Calcularar_PORCENTAJE_FENOLOGIA();
        }
        #endregion
        #region CALCULAR EL AVANCE DE SIEMBRA DEL CULTIVO
        private void Calcularar_AVANCE_SIEMBRA()
        {
            DB_EXT_Rendimiento avsiem = new DB_EXT_Rendimiento();
            DataTable dt = new DataTable();
            dt = avsiem.DB_Reporte_DETALLE_PLANILLA(Convert.ToInt32(DDLFenologia.SelectedValue), LblIdInsProd.Text, DDLEstadoFF.SelectedValue, "INSUMO_ANAVCE_SIEM");
            TxtPorcentaje.Text = dt.Rows[0][0].ToString();
            if (DDLFenologia.SelectedItem.Text == "FECHA Y AVANCE DE SIEMBRA")
            {
                LblAvanSiem.Text = dt.Rows[0][0].ToString();
                if (Convert.ToDecimal(dt.Rows[0][0].ToString()) == 100)
                {
                    TxtPorcentaje.Enabled = false;
                }
                else
                {
                    TxtPorcentaje.Enabled = true;
                }
            }
            else
            {
                TxtPorcentaje.Enabled = true;
            }
        }
        /*****************************/
        private void Calcularar_AVANCE_SIEMBRA_CULTIVO()
        {
            DB_EXT_Rendimiento avsiem = new DB_EXT_Rendimiento();
            DataTable dt = new DataTable();
            dt = avsiem.DB_Reporte_DETALLE_PLANILLA_CULTIVO(LblIdInsProd.Text, "ANAVCE_SIEM");
            LblAvanSiem.Text = dt.Rows[0][0].ToString();
        }
        #endregion
        #region CALCULO DE PORCENTAJES DE LA FACE FENOLOGICA
        private void Calcularar_PORCENTAJE_FENOLOGIA()
        {
            DB_EXT_Rendimiento avsiem = new DB_EXT_Rendimiento();
            DataTable dt = new DataTable();
            dt = avsiem.DB_Reporte_DETALLE_PLANILLA(Convert.ToInt32(DDLFenologia.SelectedValue), LblIdInsProd.Text, DDLEstadoFF.SelectedValue, "INSUMO_ANAVCE_SIEM");
            TxtPorcentaje.Text = dt.Rows[0][0].ToString();
            LblPorcentaje.Text = dt.Rows[0][0].ToString();
        }
        #endregion
        protected void DDLEstadoFF_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TxtPorcentaje_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            LblMsj5.Text = string.Empty;
           
            if (DDLFenologia.SelectedItem.Text == "FECHA COSECHA PROBABLE")
            {
                Registrar_COSECHAPROBABLE();
            } 
            else
            {
                if (DDLFenologia.SelectedItem.Text == "FECHA Y AVANCE DE SIEMBRA")
                {
                    Registrar_AVANCE_DE_SIEMBRA();
                }
                else
                {
                    if (DDLFenologia.SelectedItem.Text == "COSECHA Y ACOPIO")
                    {
                        Registrar_SEGUIMIENTO_AL_CULTIVO();
                    }
                    else
                    {
                        if (Validar_GRILLA() == 0)
                        {
                            if (Convert.ToInt32(LblCont.Text) < Convert.ToInt32(LblAvanSiem.Text))
                            {
                                Registrar_SEGUIMIENTO_AL_CULTIVO();
                            }
                            else
                            {
                                LblMsj5.Text = "El porcentaje de avance de siembra ya se completo al: " + LblAvanSiem.Text;
                            }
                        }
                        else
                        {
                            LblMsj5.Text = "ya existe un valor para: " + DDLFenologia.SelectedItem.Text + " Con el estado de: " + DDLEstadoFF.SelectedValue;
                        }
                    }
                }
            }         
        }

        protected void GVSegCultivo_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (TxtNumBoleta.Text != "")
            {
                if (TxtFecha.Text != "")
                {
                    LblMsj5.Text = string.Empty;
                    Registar_VERIFICACION_DE_CULTIVO();
                }
                else
                {
                    LblMsj5.Text = "Tiene que especificar la fecha de la boleta del seguimiento técnico realizado";
                }
            }
            else
            {
                LblMsj5.Text = "Tiene que especificar un numero de boleta del seguimiento técnico realizado";
            }
        }
        /****************************************/
        protected void Registar_VERIFICACION_DE_CULTIVO()
        {
            if (GVSegCultivo.Rows.Count > 0)
            {
                if (DDLFenologia.SelectedItem.Text == "FECHA Y AVANCE DE SIEMBRA")
                {
                    LblMsj5.Text = string.Empty;
                    Registrar_SEGUIMIENTO();
                    Response.Redirect("frmSeguimientoTecnico.aspx");
                }
                else
                {
                    if (DDLFenologia.SelectedItem.Text == "COSECHA Y ACOPIO")
                    {
                        LblMsj5.Text = string.Empty;
                        Registrar_SEGUIMIENTO();
                        Response.Redirect("frmSeguimientoTecnico.aspx");
          
                    }
                    else
                    {
                        if(DDLFenologia.SelectedItem.Text == "FECHA COSECHA PROBABLE")
                        {
                         LblMsj5.Text = string.Empty;
                         Registrar_SEGUIMIENTO();
                         Response.Redirect("frmSeguimientoTecnico.aspx");
                        }
                        else
                        {
                            if (LblCont.Text == LblAvanSiem.Text)
                            {
                                LblMsj5.Text = string.Empty;
                                Registrar_SEGUIMIENTO();
                                Response.Redirect("frmSeguimientoTecnico.aspx");
                            }
                            else
                            {
                                LblMsj5.Text = "el porcentaje de las Fases de fenologia deben cuadrar con el avance de siembra que se declaro";
                            } 
                        }   
                    }
                }
            }
            else
            {
                LblMsj5.Text = "Necesita registrar los datos del cultivo para continuar";
            }
        }
        #region FUNCION DE REGISTRO DEL SEGUIMIENTO TECNICO
        protected void Registrar_SEGUIMIENTO()
        {
            int aux1 = 0;
            DB_EXT_DesignacionProd estadoprod = new DB_EXT_DesignacionProd();
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            DB_EXT_Seguimiento insSeg = new DB_EXT_Seguimiento();
            EXT_Seguimiento seg = new EXT_Seguimiento();
            EXT_SeguimientoParcela segParc = new EXT_SeguimientoParcela();
            seg.Id_InscripcionOrg = Convert.ToInt32(LblIdInsOrg.Text);
            seg.Id_Usuario = LblIdUsuario.Text;
            seg.Id_Productor = LblIdInsProd.Text;
            seg.Id_Campanhia = Convert.ToInt32(LblIdCamp.Text);
            seg.Id_Regional = Convert.ToInt32(LblIdReg.Text);
            seg.Programa = LblProg.Text;
            if (DDLFenologia.SelectedItem.Text == "COSECHA Y ACOPIO") /*************HAY QUE TRABAJAR AQUI MAÑANA*********************************/
            {
                LblEtapa.Text = "VERIFICACION_COSECHA";
            }
            seg.Etapa = LblEtapa.Text;
            if (LblEtapa.Text == "VERIFICACION_PARCELA")
            {
                seg.Num_Seg_Cultivo = 0;
            }
            else
            {
                seg.Num_Seg_Cultivo = 1;
            }
            seg.Estado = "ENVIADO";
            seg.Fecha_Envio = DateTime.Now;
            seg.Tipo_Seguimiento = Convert.ToInt32(DDLTipoSeg.SelectedValue);
            insSeg.DB_Registrar_SEGUIMIENTO(seg);

            segParc.Id_Seguimiento = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO", "Id_Seguimiento"));
            if (Convert.ToInt32(DDLTipoSeg.SelectedValue) == 1)
            {
                segParc.Boleta_Numero = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO_PARCELA", "Id_Seguimiento_Parcela")) + 1;
            }
            else
            {
                segParc.Boleta_Numero = Convert.ToInt32(TxtNumBoleta.Text);
            }
            segParc.Fecha_Seg = Convert.ToDateTime(TxtFecha.Text);
            DateTime t = DateTime.Now;
            segParc.Hora_Seg = t.Hour.ToString() + ":" + t.Minute.ToString();
            //segParc.Hora_Seg = DDLHora.SelectedValue + ":" + DDLMinuto.SelectedValue;
            segParc.Fecha_Sis = DateTime.Now;
            segParc.Observacion = TxtObser.Text;
            segParc.Recomendacion = TxtRecomen.Text;
            insSeg.DB_Registrar_SEGUIMIENTO_PARCELA(segParc);

            EXT_SeguimientoCoordenadas scor = new EXT_SeguimientoCoordenadas();
            EXT_SeguimientoSiembra ss = new EXT_SeguimientoSiembra();
            EXT_SeguimientoCultivo sc = new EXT_SeguimientoCultivo();
            EXT_AdversidadPresentada ad = new EXT_AdversidadPresentada();
/***********************************************************************/
                    DataTable dt = Session["datos"] as DataTable;
                    int id = 0;
                    id = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO_PARCELA", "Id_Seguimiento_Parcela"));
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {         
                        sc.Id_Seguimiento_Parcela = id;
                        sc.Id_Fenologia = Convert.ToInt32(dt.Rows[i][0].ToString());
                        sc.Estado = dt.Rows[i][2].ToString();
                        if (dt.Rows[i][1].ToString() == "FECHA COSECHA PROBABLE")
                        {
                            sc.Porcentaje_FF = 0;
                            sc.Fecha_Cosecha = Convert.ToDateTime(dt.Rows[i][4].ToString());
                        }
                        else
                        {
                            sc.Porcentaje_FF = Convert.ToInt32(dt.Rows[i][3].ToString());
                            sc.Fecha_Cosecha = Convert.ToDateTime("01/01/1900");
                        }
                        insSeg.DB_Registrar_SEGUIMIENTO_CULTIVO(sc);
                        estadoprod.DB_Cambiar_ESTADO(LblIdInsProd.Text, "VERIFICACION_CULTIVO");
                    }
                    if (LblEtapa.Text == "VERIFICACION_COSECHA")
                    {
                        EXT_SeguimientoCosecha cos = new EXT_SeguimientoCosecha();
                        cos.Id_Seguimiento_Parcela = id;
                        cos.Rendimiento = Convert.ToDecimal(TxtRedimiento.Text);
                        cos.Sup_Sembrada = Convert.ToDecimal(TxtSupSiem.Text);
                        cos.Peso_Aproximado = Convert.ToDecimal(TxtPesoApro.Text);
                        cos.Fecha_Siembra = Convert.ToDateTime(TxtFechSiem.Text);
                        cos.Placa_Camion = TxtPlacaCam.Text;
                        cos.Nom_Chofer=TxtNomChofer.Text;
                        cos.Centro_Acopio = TxtCentroAco.Text;
                        cos.Region = "";
                        insSeg.DB_Registrar_DATOS_COSECHA(cos);
                    }
                    if (GVAdversidad.Rows.Count > 0)
                    {
                        foreach (GridViewRow dgi in GVAdversidad.Rows)
                        {
                            ad.Id_Seguimiento_Parcela = id;
                            ad.Adversidad = GVAdversidad.Rows[dgi.RowIndex].Cells[0].Text;
                            ad.Descripcion = GVAdversidad.Rows[dgi.RowIndex].Cells[1].Text;
                            ad.Intencidad = GVAdversidad.Rows[dgi.RowIndex].Cells[2].Text;
                            ad.Porcentage = Convert.ToDecimal(GVAdversidad.Rows[dgi.RowIndex].Cells[3].Text);
                            ad.Tratamiento = GVAdversidad.Rows[dgi.RowIndex].Cells[4].Text;
                            insSeg.DB_Registrar_ADVESIDAD(ad);
                        }
                    }
        }
        #endregion

        protected void DDLTipoSeg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(DDLTipoSeg.SelectedValue) == 1)
            {
                LblNumBoleta.Text = "N° asignado por el sistema";
                TxtNumBoleta.Enabled = false;
                TxtNumBoleta.Text = "?";
            }
            else
            {
                LblNumBoleta.Text = "N° Boleta de Inspección:";
                TxtNumBoleta.Enabled = true;
                TxtNumBoleta.Text = string.Empty;
            }
        }

        protected void RdbAdeversidadSI_CheckedChanged(object sender, EventArgs e)
        {
            PnlAdversidad.Visible = true;
        }

        protected void RdbAdeversidadNO_CheckedChanged(object sender, EventArgs e)
        {
            PnlAdversidad.Visible = false;
        }

        protected void DDLIntensidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DDLIntensidad.SelectedValue)
            {
                case "0":
                    LblIntencidad.Text = "(0)% ";
                    break;
                case "1":
                    LblIntencidad.Text = "(1 - 25)%";
                    break;
                case "2":
                    LblIntencidad.Text = "(26 - 50)%";
                    break;
                case "3":
                    LblIntencidad.Text = "(51 - 75)%";
                    break;
                case "4":
                    LblIntencidad.Text = "(75 - 100)%";
                    break;
            }
        }

        protected void BtnInsertAdversidad_Click(object sender, EventArgs e)
        {
            DataTable dt = Session["datos1"] as DataTable;
            DataRow row = dt.NewRow();
            row["Adversidad"] = DDLAdversidad.SelectedValue;
            row["Descripcion"] = TxtDescripAdversidad.Text;
            row["Intencidad"] = DDLIntensidad.SelectedValue;
            row["Porcentaje"] = TxtIntencidad.Text;
            row["Tratamiento"] = TxtTratamiento.Text;
            dt.Rows.Add(row);
            GVAdversidad.DataSource = dt;
            GVAdversidad.DataBind();
            Session["datos1"] = dt;
            Linpiar_CAMPOS();
        }
        #region FUNCION DE LIMPIAR CAMPOS
        private void Linpiar_CAMPOS()
        {
            TxtDescripAdversidad.Text = string.Empty;
            TxtIntencidad.Text = "0";
            TxtTratamiento.Text = string.Empty;
            DDLIntensidad.DataBind();
            DDLAdversidad.DataBind();
        }
        #endregion
        #region REGISTRAR EN LA GRILLA LOS VALORES DEL SEGUIMIENTO
        protected void Registrar_COSECHAPROBABLE()
        {
            /*********************************************************************/
             if(TxtFechaFase.Text!="")
             {
                 LblMsj5.Text = string.Empty;
                 DataTable dt = Session["datos"] as DataTable;
                 DataRow row = dt.NewRow();
                 row["Id_Fenologia"] = DDLFenologia.SelectedValue;
                 row["FaceFenologica"] = DDLFenologia.SelectedItem.Text;
                 row["EstadoFF"] = DDLEstadoFF.SelectedValue;
                 row["Porcentaje"] = TxtPorcentaje.Text;
                 row["Fecha_Cosecha"] = TxtFechaFase.Text;
                 dt.Rows.Add(row);
                 GVSegCultivo.DataSource = dt;
                 GVSegCultivo.DataBind();
                 Session["datos"] = dt;
                 TxtFechaFase.Text = string.Empty;
                 /*************/
                 if (DDLEstadoFF.SelectedItem.Text == "Final")
                 {
                     BtnEnviar.Enabled = true;
                     BtnRegistrar.Enabled = false;
                 }
                 else
                 {
                     DDLEstadoFF.Items.Clear();
                     DDLEstadoFF.Items.Insert(0, new ListItem("Final", "Final", true));
                     DDLEstadoFF.DataBind();
                 }
             }
             else
             {
                 Response.Write("<script>window.alert('Necesita especificar la fecha');</script>");
             }

        }
        /*************************************/
        protected void Registrar_AVANCE_DE_SIEMBRA()
        {
            if (Convert.ToInt32(TxtPorcentaje.Text) <= 100)
            {
                if (Convert.ToInt32(TxtPorcentaje.Text) > Convert.ToInt32(LblAvanSiem.Text))
                {
                    if (TxtPorcentaje.Text != "")
                    {
                       LblMsj5.Text = string.Empty;
                       DataTable dt = Session["datos"] as DataTable;
                       DataRow row = dt.NewRow();
                       row["Id_Fenologia"] = DDLFenologia.SelectedValue;
                       row["FaceFenologica"] = DDLFenologia.SelectedItem.Text;
                       row["EstadoFF"] = DDLEstadoFF.SelectedValue;
                       row["Porcentaje"] = TxtPorcentaje.Text;
                       row["Fecha_Cosecha"] = TxtFechaFase.Text;
                       dt.Rows.Add(row);
                       GVSegCultivo.DataSource = dt;
                       GVSegCultivo.DataBind();
                       Session["datos"] = dt;
                       BtnEnviar.Enabled = true;
                       BtnRegistrar.Enabled = false;
                       Linpiar_CAMPOS();
                    }
                    else
                    {
                        LblMsj5.Text = "Error necesiata definir un porcentaje";
                    }
                }
                else
                {
                    LblMsj5.Text = "El avance de siembra NO puede ser MENOR o IGUAL a lo declarado en la inspección anterior";
                }
            }
            else
            {
                LblMsj5.Text = "No se puede registrar  el dato,  porque el avance de siembra ya se encuentra en el 100%";
            }
        }
        /*****************************************/
        protected int Validar_GRILLA()
        {
            int valor = 0;
            foreach (GridViewRow dgi in GVSegCultivo.Rows)
            {
                if (DDLFenologia.SelectedValue == GVSegCultivo.Rows[dgi.RowIndex].Cells[0].Text && DDLEstadoFF.SelectedValue == GVSegCultivo.Rows[dgi.RowIndex].Cells[2].Text)
                {
                    valor = 1;
                    break;
                }
            }
            return valor;
        }

        protected void Registrar_SEGUIMIENTO_AL_CULTIVO()
        {
            if (TxtPorcentaje.Text != "")
            {
                if (Convert.ToInt32(TxtPorcentaje.Text) > 0)//&& Convert.ToInt32(TxtPorcentaje.Text) <= Convert.ToInt32(LblCont.Text))
                {
                    LblCont.Text = (Convert.ToInt32(TxtPorcentaje.Text) + Convert.ToInt32(LblCont.Text)).ToString();
                    if (Convert.ToInt32(LblCont.Text) <= Convert.ToInt32(LblAvanSiem.Text))
                    {
                        LblMsj5.Text = string.Empty;
                        DataTable dt = Session["datos"] as DataTable;
                        DataRow row = dt.NewRow();
                        row["Id_Fenologia"] = DDLFenologia.SelectedValue;
                        row["FaceFenologica"] = DDLFenologia.SelectedItem.Text;
                        row["EstadoFF"] = DDLEstadoFF.SelectedValue;
                        row["Porcentaje"] = TxtPorcentaje.Text;
                        row["Fecha_Cosecha"] = TxtFechaFase.Text;
                        dt.Rows.Add(row);
                        GVSegCultivo.DataSource = dt;
                        GVSegCultivo.DataBind();
                        Session["datos"] = dt;
                        Linpiar_CAMPOS();
                        if (Convert.ToInt32(LblCont.Text) == Convert.ToInt32(LblAvanSiem.Text))
                        {
                            BtnEnviar.Enabled = true;
                        }
                        if (DDLFenologia.SelectedItem.Text == "COSECHA Y ACOPIO")
                        {
                            BtnRegistrar.Enabled = false;
                            DDLFenologia.Enabled = false;
                            BtnEnviar.Enabled = true;
                            Panel1.Enabled = false;
                        }
                    }
                    else
                    {
                        LblMsj5.Text = "El Grado de porcentaje de la fenología no puede ser 0, se requiere que presente una variación para continuar";
                    }
                }
                else
                {
                    LblCont.Text = (Convert.ToInt32(TxtPorcentaje.Text) + Convert.ToInt32(LblCont.Text)).ToString();
                    if (Convert.ToInt32(LblCont.Text) <= Convert.ToInt32(LblAvanSiem.Text))
                    {
                        LblMsj5.Text = string.Empty;
                        DataTable dt = Session["datos"] as DataTable;
                        DataRow row = dt.NewRow();
                        row["Id_Fenologia"] = DDLFenologia.SelectedValue;
                        row["FaceFenologica"] = DDLFenologia.SelectedItem.Text;
                        row["EstadoFF"] = DDLEstadoFF.SelectedValue;
                        row["Porcentaje"] = TxtPorcentaje.Text;
                        row["Fecha_Cosecha"] = TxtFechaFase.Text;
                        dt.Rows.Add(row);
                        GVSegCultivo.DataSource = dt;
                        GVSegCultivo.DataBind();
                        Session["datos"] = dt;
                        Linpiar_CAMPOS();
                        if (Convert.ToInt32(LblCont.Text) == Convert.ToInt32(LblAvanSiem.Text))
                        {
                            BtnEnviar.Enabled = true;
                        }
                        if (DDLFenologia.SelectedItem.Text == "COSECHA Y ACOPIO")
                        {
                            BtnRegistrar.Enabled = false;
                            DDLFenologia.Enabled = false;
                        }
                    }
                    else
                    {
                        LblCont.Text = (Convert.ToInt32(LblCont.Text) - Convert.ToInt32(TxtPorcentaje.Text)).ToString();
                        LblMsj5.Text = "No se puede registar, la siembra esta en un: " + LblAvanSiem.Text + "%";
                    }
                }
            }
            else
            {
                LblMsj5.Text = "Error necesiata definir un porcentaje";
            }




        }
        /****************************************/
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}