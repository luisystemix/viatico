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
    public partial class frmParcela : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RangeValidator2.ErrorMessage = "JOSE";

            //RangeValidator2.MaximumValue
            //try
            //{
                if (!IsPostBack)
                {
                    LblIdInsOrg.Text=Session["IdInsOrg"].ToString();
                    LblIdInsProd.Text = Session["IdInsProd"].ToString();
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    LblEtapa.Text = Session["Etapa"].ToString();
                    LblEstado.Text = Session["Estado"].ToString();
                    /****************************************/
                                if (LblEtapa.Text == "VERIFICACION_PARCELA")
                                {
                                    DDLTipoSeg.Enabled = false;
                                }
                    /***************************************/
                    //Control_FORMULARIO();
                    Datos_Org_ENCABEZADO();
                    Cargar_COMBO();
                    Control_FORMULARIO();
                    /*****************************************************/
                    DataTable dtListaPartida1 = new DataTable();
                    dtListaPartida1.Columns.AddRange(new DataColumn[5] { new DataColumn("Adversidad"), new DataColumn("Descripcion"), new DataColumn("Intencidad"), new DataColumn("Porcentaje"), new DataColumn("Tratamiento")});
                    GVAdversidad.DataSource = dtListaPartida1;
                    GVAdversidad.DataBind();
                    Session["datos1"] = dtListaPartida1;

                    /*************************************/
                    DataTable dtListaPartida = new DataTable();
                    //dtListaPartida.Columns.AddRange(new DataColumn[9] { new DataColumn("Id_Fenologia"), new DataColumn("FaceFenologica"), new DataColumn("EstadoFF"), new DataColumn("Porcentaje"), new DataColumn("Fecha_Cosecha"), new DataColumn("Tipo"), new DataColumn("Estado"), new DataColumn("Intencidad"), new DataColumn("Tratamiento") });
                    dtListaPartida.Columns.AddRange(new DataColumn[5] { new DataColumn("Id_Fenologia"), new DataColumn("FaceFenologica"), new DataColumn("EstadoFF"), new DataColumn("Porcentaje"), new DataColumn("Fecha_Cosecha")});
                    GVSegCultivo.DataSource = dtListaPartida;
                    GVSegCultivo.DataBind();
                    Session["datos"] = dtListaPartida;

                    /***********************/
                    if (LblProg.Text == "MAIZ")
                    {
                        LblFechaFase.Text = "Etapa:";
                        DDLEstadoFF.Enabled = false;
                        DDLEstadoFF.Items.Insert(0, new ListItem("Avance", "Avance", true));
                        DDLEstadoFF.DataBind();
                        DDLEstadoFF.ClearSelection();
                    }
                    Contro2_FORMULARIO();
                    /********************************************/
                    Calcularar_AVANCE_SIEMBRA();
                    Calcularar_AVANCE_SIEMBRA_CULTIVO();
                    /*********************************************/
                    Desplegar_INSUMOS_PRODUCTOR();
                }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        #region
        private void Contro2_FORMULARIO()
        {

            if (DDLFenologia.SelectedItem.Text == "FECHA Y AVANCE DE SIEMBRA")
            {
                //int aux = 0;
                //DB_EXT_Fenologia numBol = new DB_EXT_Fenologia();
                //DataTable dt = new DataTable();
                //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 0, Convert.ToInt32(LblIdReg.Text), LblProg.Text, "Avance", Convert.ToInt32(LblNumSegCult.Text), "AVANCE_SIEMBRA");
                //aux = Convert.ToInt32(dt.Rows[0][0].ToString());
                //LblPorcentaje.Text = (100 - aux).ToString();
                //TxtPorcentaje.Text = LblPorcentaje.Text;

                LblFechaFase.Text = "Etapa:";
                DDLEstadoFF.Enabled = false;
                DDLEstadoFF.Items.Insert(0, new ListItem("Avance", "Avance", true));
                DDLEstadoFF.DataBind();
                DDLEstadoFF.ClearSelection();
            }
        }
        #endregion
        #region CAÑLCULAR EL AVANCE DE SIEMBRA DEL CULTIVO
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
            //else 
            //{
            //    if(LblProg.Text!="MAIZ")
            //    {
            //        dt = avsiem.DB_Reporte_DETALLE_PLANILLA(Convert.ToInt32(DDLFenologia.SelectedValue), LblIdInsProd.Text, "Inicial", "INSUMO_ANAVCE_SIEM");
            //        dt1 = avsiem.DB_Reporte_DETALLE_PLANILLA(Convert.ToInt32(DDLFenologia.SelectedValue), LblIdInsProd.Text, "Final", "INSUMO_ANAVCE_SIEM");
            //    }
            //    else
            //    {
            //    }
            //    //dt = avsiem.DB_Reporte_DETALLE_PLANILLA(Convert.ToInt32(DDLFenologia.SelectedValue), LblIdInsProd.Text, DDLEstadoFF.SelectedValue, "INSUMO_ANAVCE_SIEM");
            //    //TxtPorcentaje.Text = (100 - Convert.ToInt32(LblPorcentaje.Text)).ToString();
            //    TxtPorcentaje.Enabled = true;
            //}
        }
        #endregion
        //protected void TxtCoordX_KeyPress(Object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Tab)
        //    {
        //        Keybox4.Focus();
        //    }

        //}

        #region FUNCIONES PARA SELECCIONAR LOS INSUMOS EN SEMILLA I AGROQUIMICOS QUE RETIRO EL PRODUCTOR
        private void Desplegar_INSUMOS_PRODUCTOR()
        {
            DB_EXT_Rendimiento ex = new DB_EXT_Rendimiento();
            DataTable dt = new DataTable();
            dt = ex.DB_Reporte_DETALLE_PLANILLA(Convert.ToInt32(LblIdInsOrg.Text), LblIdInsProd.Text, "SEMILLA", "INSUMO_PRODUCTOR");
            if(dt.Rows.Count > 0)
            {
                DDLVariedad.DataSource = dt;
                DDLVariedad.DataValueField = "Valor1";
                DDLVariedad.DataTextField = "Valor1";
                DDLVariedad.DataBind();
                TxtVariedad.Text = DDLVariedad.SelectedValue;
            }
            else
            {
                TxtVariedad.Visible = true;
                DDLVariedad.Visible = false;
            }

        }
        #endregion
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Datos_Org_ENCABEZADO()
        {
            DB_AP_Registro_Org d_org = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = d_org.DB_Desplegar_ENCABEZADO_ORG(Convert.ToInt32(LblIdInsOrg.Text));
            LblOrg.Text=dt.Rows[0][2].ToString();
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
                if (LblEtapa.Text == "VERIFICACION_PARCELA")
                {
                    PnlDatsCoord.Visible = true;
                    PnlDatsParcela.Visible = false;
                    PnlDatsCultivo.Visible = false;
                    PnlOBsRec.Visible = true;
                }
                else
                {
                    if (LblEtapa.Text == "VERIFICACION_SIEMBRA")
                    {
                        PnlDatsCoord.Enabled = false;
                        PnlDatsParcela.Visible = true;
                        PnlOBsRec.Visible = true;
                    }
                    else
                    {
                        if (LblEtapa.Text == "VERIFICACION_CULTIVO")
                        {
                            if (DDLFenologia.SelectedItem.Text == "FECHA Y AVANCE DE SIEMBRA")
                            {
                                LblNumSegCult.Text = "1";
                            }
                            else 
                            {
                                LblNumSegCult.Text = dt.Rows[0][0].ToString();
                            }
                            PnlDatsCoord.Enabled = false;
                            PnlDatsParcela.Enabled = false;
                            PnlDatsCultivo.Visible = true;
                            PnlOBsRec.Visible = true;
                        }
                    }
                }
        }
        #endregion
        #region REGISTRAR EN LA GRILLA LOS VALORES DEL SEGUIMIENTO
        protected void Registrar_COSECHAPROBABLE()
        {
            /**********************************************************************/
            if (TxtFechaFase.Text != "")
            {
                //if (TxtEstadoTipo.Text != "")
                //{
                    if (TxtIntencidad.Text != "")
                    {
                        if (TxtTratamiento.Text != "")
                        {
                            LblMsj4.Text = string.Empty;
                            DataTable dt = Session["datos"] as DataTable;
                            DataRow row = dt.NewRow();
                            row["Id_Fenologia"] = DDLFenologia.SelectedValue;
                            row["FaceFenologica"] = DDLFenologia.SelectedItem.Text;
                            row["EstadoFF"] = DDLEstadoFF.SelectedValue;
                            row["Porcentaje"] = TxtPorcentaje.Text;
                            row["Fecha_Cosecha"] = TxtFechaFase.Text;
                            //row["Tipo"] = "";
                            //row["Estado"] = "";
                            //row["Intencidad"] = TxtIntencidad.Text;
                            //row["Tratamiento"] = TxtTratamiento.Text;
                            dt.Rows.Add(row);
                            GVSegCultivo.DataSource = dt;
                            GVSegCultivo.DataBind();
                            Session["datos"] = dt;
                        }
                        else
                        {
                            LblMsj4.Text = "ERROR necesita registrar un tratamiento";
                        }
                    }
                    else
                    {
                        LblMsj4.Text = "ERROR Necesita ingresar un porcentaje de intencidad de la etapa fenologica";
                    }
                //}
                //else
                //{
                //    LblMsj4.Text = "ERROR Necesita definir un tipo";
                //}
            }
            else
            {
                LblMsj4.Text = "Error necesiata definir una Fecha probable de cosecha";
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

                        if (DDLAdversidad.SelectedValue == "No definido")
                        {
                            LblMsj4.Text = string.Empty;
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
                            //                                  LblPorcentaje.Text = (Convert.ToDecimal(LblPorcentaje.Text) - Convert.ToDecimal(TxtPorcentaje.Text)).ToString();
                            Linpiar_CAMPOS();
                        }
                        else
                        {
                            //if (TxtEstadoTipo.Text != "")
                            //{
                            //    if (TxtIntencidad.Text != "")
                            //    {
                            //        if (TxtTratamiento.Text != "")
                            //        {
                                        LblMsj4.Text = string.Empty;
                                        DataTable dt = Session["datos"] as DataTable;
                                        DataRow row = dt.NewRow();
                                        row["Id_Fenologia"] = DDLFenologia.SelectedValue;
                                        row["FaceFenologica"] = DDLFenologia.SelectedItem.Text;
                                        row["EstadoFF"] = DDLEstadoFF.SelectedValue;
                                        row["Porcentaje"] = TxtPorcentaje.Text;
                                        row["Fecha_Cosecha"] = TxtFechaFase.Text;
                                        //row["Tipo"] = "";
                                        //row["Estado"] = "";
                                        //row["Intencidad"] = TxtIntencidad.Text;
                                        //row["Tratamiento"] = TxtTratamiento.Text;
                                        dt.Rows.Add(row);
                                        GVSegCultivo.DataSource = dt;
                                        GVSegCultivo.DataBind();
                                        Session["datos"] = dt;
                                        BtnEnviar.Enabled = true;
                                        BtnRegistrar.Enabled = false;
                                        //                                  LblPorcentaje.Text = (Convert.ToDecimal(LblPorcentaje.Text) - Convert.ToDecimal(TxtPorcentaje.Text)).ToString();
                                        Linpiar_CAMPOS();
                            //        }
                            //        else
                            //        {
                            //            LblMsj4.Text = "ERROR necesita registrar un tratamiento";
                            //        }
                            //    }
                            //    else
                            //    {
                            //        LblMsj4.Text = "Tiene que especificar el porcentaje  de intensidad que presenta el elemento en el cultivo";
                            //    }
                            //}
                            //else
                            //{
                            //    LblMsj4.Text = "Tiene que especificar el nombre del elemento que presenta el cultivo";
                            //}

                        }


                    }
                    else
                    {
                        LblMsj4.Text = "Error necesiata definir un porcentaje";
                    }
                }
                else
                {
                    LblMsj4.Text = "El avance de siembra NO puede ser MENOR o IGUAL a lo declarado en la inspección anterior";
                }
            }
            else
            {
                LblMsj4.Text = "No se puede registrar  el dato,  porque el avance de siembra ya se encuentra en el 100%";
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
                    if (Convert.ToInt32(TxtPorcentaje.Text) > 0 )//&& Convert.ToInt32(TxtPorcentaje.Text) <= Convert.ToInt32(LblCont.Text))
                    {
                        LblCont.Text = (Convert.ToInt32(TxtPorcentaje.Text) + Convert.ToInt32(LblCont.Text)).ToString();
                        if (Convert.ToInt32(LblCont.Text) <= Convert.ToInt32(LblAvanSiem.Text))
                        {
                            LblMsj4.Text = string.Empty;
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
                            }
                        }
                        else
                        {
                            LblMsj4.Text = "El Grado de porcentaje de la fenología no puede ser 0, se requiere que presente una variación para continuar";
                        }
                    }
                    else
                    {
                        LblCont.Text = (Convert.ToInt32(TxtPorcentaje.Text) + Convert.ToInt32(LblCont.Text)).ToString();
                        if (Convert.ToInt32(LblCont.Text) <= Convert.ToInt32(LblAvanSiem.Text))
                        {
                            LblMsj4.Text = string.Empty;
                            DataTable dt = Session["datos"] as DataTable;
                            DataRow row = dt.NewRow();
                            row["Id_Fenologia"] = DDLFenologia.SelectedValue;
                            row["FaceFenologica"] = DDLFenologia.SelectedItem.Text;
                            row["EstadoFF"] = DDLEstadoFF.SelectedValue;
                            row["Porcentaje"] = TxtPorcentaje.Text;
                            row["Fecha_Cosecha"] = TxtFechaFase.Text;
                            //row["Tipo"] = "";
                            //row["Estado"] = "";
                            //row["Intencidad"] = TxtIntencidad.Text;
                            //row["Tratamiento"] = TxtTratamiento.Text;
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
                            LblMsj4.Text = "No se puede registar, la siembra esta en un: " + LblAvanSiem.Text + "%";
                        }
                    }
                }
                else
                {
                    LblMsj4.Text = "Error necesiata definir un porcentaje";
                }




        }
        /****************************************/
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            LblMsj5.Text = string.Empty;
            if (DDLFenologia.SelectedItem.Text == "FECHA COSECHA PROBABLE")
            {
                Registrar_COSECHAPROBABLE();
            }
            else
            {
                if(DDLFenologia.SelectedItem.Text == "FECHA Y AVANCE DE SIEMBRA")
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
                         if(Convert.ToInt32(LblCont.Text) < Convert.ToInt32(LblAvanSiem.Text))
                         {
                             Registrar_SEGUIMIENTO_AL_CULTIVO();
                         }
                         else
                         {
                             LblMsj4.Text = "El porcentaje de avance de siembra ya se completo al: " + LblAvanSiem.Text;
                         }           
                     }
                     else
                     {
                        LblMsj4.Text = "ya existe un valor para: " + DDLFenologia.SelectedItem.Text + " Con el estado de: " + DDLEstadoFF.SelectedValue;
                     }
                    }     
                }
            }
        }
        #endregion
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
            if(Convert.ToInt32(DDLTipoSeg.SelectedValue)==1)
            {
                 segParc.Boleta_Numero = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO_PARCELA", "Id_Seguimiento_Parcela"))+1;
            }
            else
            {
                segParc.Boleta_Numero = Convert.ToInt32(TxtNumBoleta.Text);
            }
            segParc.Fecha_Seg = Convert.ToDateTime(TxtFecha.Text);
            segParc.Hora_Seg = DDLHora.SelectedValue + ":" + DDLMinuto.SelectedValue;
            segParc.Fecha_Sis = DateTime.Now;
            segParc.Observacion = TxtObser.Text;
            segParc.Recomendacion = TxtRecomen.Text;
            insSeg.DB_Registrar_SEGUIMIENTO_PARCELA(segParc);

            EXT_SeguimientoCoordenadas scor = new EXT_SeguimientoCoordenadas();
            EXT_SeguimientoSiembra ss = new EXT_SeguimientoSiembra();
            EXT_SeguimientoCultivo sc = new EXT_SeguimientoCultivo();
            EXT_AdversidadPresentada ad = new EXT_AdversidadPresentada();
            switch(LblEtapa.Text)
            {
                case "VERIFICACION_PARCELA":
                    scor.Id_Seguimiento_Parcela = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO_PARCELA", "Id_Seguimiento_Parcela"));
                    scor.Id_Productor = LblIdInsProd.Text;
                    for (int i = 0; i < LstCoordX.Items.Count; i++)
                    {
                        scor.CoordenadaX = LstCoordX.Items[i].Text;
                        scor.CoordenadaY = LstCoordY.Items[i].Text;
                        scor.Num_Parcela = Convert.ToInt32(LstNumParcela.Items[i].Text);
                        insSeg.DB_Registrar_SEGUIMIENTO_COORDENADA(scor);
                    }
                    estadoprod.DB_Cambiar_ESTADO(LblIdInsProd.Text, "DISTRIBUCION_SEMILLA");
                    Response.Redirect("frmSeguimientoTecnico.aspx");
                    break;
                case "VERIFICACION_SIEMBRA":
                    string auxVariedad = "";
                    ss.Id_Seguimiento_Parcela = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO_PARCELA", "Id_Seguimiento_Parcela"));
                    ss.Fecha_SiembraINI = Convert.ToDateTime(TxtFechaIniSiembra.Text);
                    ss.Fecha_SiembraFIN = Convert.ToDateTime(TxtFechaFinSiembra.Text);
                    ss.Sistema_Siembra = DDLSistemaSiembra.SelectedValue;
                    ss.Cultivo_Anterior = TxtCultivoAnt.Text;
                    ss.Variedad_Semilla = DDLVariedad.SelectedValue; /***************************************************************************************** VASRIEDAD DE SEMILLLA CUANTOS SE PUEDE REGISTRAR PERO NO GUARDA OJOJOJOJO***************/
                    ss.Avance_Siembra = 0;
                    insSeg.DB_Registrar_SEGUIMIENTO_SIEMBRA(ss);
                    sc.Id_Seguimiento_Parcela = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO_PARCELA", "Id_Seguimiento_Parcela"));
                    switch(LblProg.Text)
                    {
                        case "ARROZ":
                            aux1=1;
                            break;
                        case "MAIZ":
                            aux1=11;
                            break;
                        case "TRIGO":
                            aux1=25;
                            break;
                    }
                        sc.Id_Fenologia = aux1;
                        sc.Estado = "Avance";
                        sc.Porcentaje_FF = Convert.ToInt32(TxtAvanceSiem.Text);
                        sc.Fecha_Cosecha = Convert.ToDateTime("01/01/1900");
                        //sc.Elemento = "";
                        //sc.Nombre_Elemento = "";
                        //sc.Intencidad = 0;
                        //sc.Tratamiento = "";
                    insSeg.DB_Registrar_SEGUIMIENTO_CULTIVO(sc);
                    estadoprod.DB_Cambiar_ESTADO(LblIdInsProd.Text, "VERIFICACION_CULTIVO");

                    break;
                case "VERIFICACION_CULTIVO":
                    DataTable dt = Session["datos"] as DataTable;
                    int id = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        id = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO_PARCELA", "Id_Seguimiento_Parcela"));
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
                        //sc.Elemento = dt.Rows[i][5].ToString();
                        //sc.Nombre_Elemento = dt.Rows[i][6].ToString();
                        //sc.Intencidad = Convert.ToInt32(dt.Rows[i][7].ToString());
                        //sc.Tratamiento = dt.Rows[i][8].ToString();
                        insSeg.DB_Registrar_SEGUIMIENTO_CULTIVO(sc);
                        estadoprod.DB_Cambiar_ESTADO(LblIdInsProd.Text, "VERIFICACION_CULTIVO");
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
                    break;
            }
        }
        #endregion
        #region FUNCION QUE CONTROLA CADA ETAPA DE DEL REGISTRO DEL SEGUIMIENTO Y LOS CAMPOS DIGITADOS
        protected void Registrar_VERIFICACION_DE_PARCELA()
        {
               if(LstCoordX.Items.Count > 0)
                {
                    LblMsj2.Text = string.Empty;
                    Registrar_SEGUIMIENTO();
                    Response.Redirect("frmSeguimientoTecnico.aspx");
                }
                else
                {
                    LblMsj2.Text="Tiene que especificar las coordenadas";
                }
        }
        /****************************************/
        protected void Registrar_VERIFICACION_DE_SIEMBRA()
        {
            if (TxtFechaIniSiembra.Text != "")
            {
                if (TxtFechaFinSiembra.Text != "")
                {
                    if (TxtAvanceSiem.Text != "")
                    {
                        if (TxtCultivoAnt.Text != "")
                        {
                            if (LstVariedadSem.Items.Count > 0)
                            {
                                LblMsj3.Text = string.Empty;
                                Registrar_SEGUIMIENTO();
                                Response.Redirect("frmSeguimientoTecnico.aspx");
                            }
                            else
                            {
                                LblMsj3.Text = "Tiene que especificar la Variedad de semilla que se sembrara";
                            }
                        }
                        else
                        {
                            LblMsj3.Text = "Tiene que especificar el cultivo anterior a esta siembra";
                        }
                    }
                    else
                    {
                        LblMsj3.Text = "Tiene que especificar el porcentage de avance de la ciembra que presenta el cultivo";
                    }
                }
                else
                {
                    LblMsj3.Text = "Tiene que especificar la fecha PROBABLE del final de la siembra";
                }
            }
            else
            {
                LblMsj3.Text = "Tiene que especificar la fecha inicial cuando empezó la siembra";
            }
        }
        /****************************************/
        protected void Registar_VERIFICACION_DE_CULTIVO()
        {
            if (GVSegCultivo.Rows.Count > 0)
            {
                if (DDLFenologia.SelectedItem.Text == "FECHA Y AVANCE DE SIEMBRA")
                {
                    LblMsj4.Text = string.Empty;
                    Registrar_SEGUIMIENTO();
                    Response.Redirect("frmSeguimientoTecnico.aspx");
                }
                else
                {
                    //if (Convert.ToDecimal(LblPorcentaje.Text) == 0)
                    //{
                        if (LblCont.Text == LblAvanSiem.Text)
                        {
                            LblMsj4.Text = string.Empty;
                            Registrar_SEGUIMIENTO();
                            Response.Redirect("frmSeguimientoTecnico.aspx");
                        }
                        else
                        {
                            if (DDLFenologia.SelectedItem.Text == "COSECHA Y ACOPIO" || DDLFenologia.SelectedItem.Text == "FECHA COSECHA PROBABLE")
                            {
                                LblMsj4.Text = string.Empty;
                                Registrar_SEGUIMIENTO();
                                Response.Redirect("frmSeguimientoTecnico.aspx");
                            }
                            else
                            {
                                LblMsj5.Text = "el porcentaje de las Fases de fenologia deben cuadrar con el avance de siembra que se declaro";
                            }
                        }
                    //}
                    //else
                    //{
                    //    LblMsj4.Text = "tiene que terminar el porcentage aun le queda un porcentaje de: " + LblPorcentaje.Text;
                    //}
                }
            }
            else
            {
                LblMsj5.Text = "Necesita registrar los datos del cultivo para continuar";
            }    
        }
        /******************************************/
        protected void Control_Registrar_SEGUIMIENTO()
        {
            if (LblEtapa.Text == "VERIFICACION_PARCELA")
            {
                Registrar_VERIFICACION_DE_PARCELA();
            }
            else
            {
                    if (LblEtapa.Text == "VERIFICACION_SIEMBRA")
                     {
                       Registrar_VERIFICACION_DE_SIEMBRA();
                     }
                     else
                     {
                         if (LblEtapa.Text == "VERIFICACION_CULTIVO")
                         {
                            Registar_VERIFICACION_DE_CULTIVO();
                         }
                  }
             }
        }
        #endregion
        #region FUNCION PARA EVIAR EN SEGUIMIENTO TECNICO
        protected void BtnEnviar_Click(object sender, EventArgs e)
        {

                if (TxtNumBoleta.Text != "")
                {
                     if (TxtFecha.Text != "")
                    {
                        LblMsj5.Text = string.Empty;
                        Control_Registrar_SEGUIMIENTO();
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
        #endregion
        #region FUNCION PARA CONTROLAR DEL COMBO DE FACE FENOLOGICA DEL CULTIVO 
        protected void DDLFenologia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control_FORMULARIO();
                //int aux = 0;
                if (DDLFenologia.SelectedItem.Text == "FECHA Y AVANCE DE SIEMBRA")
                {
                //    DB_EXT_Fenologia numBol = new DB_EXT_Fenologia();
                //    DataTable dt = new DataTable();
                //    dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 0, Convert.ToInt32(LblIdReg.Text), LblProg.Text, "Avance", Convert.ToInt32(LblNumSegCult.Text), "AVANCE_SIEMBRA");
                //    aux = Convert.ToInt32(dt.Rows[0][0].ToString());
                //    LblPorcentaje.Text = (100 - aux).ToString();
                //    TxtPorcentaje.Text = LblPorcentaje.Text;

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
                }
                else
                {
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
                    }
                    else
                    {
                        if (LblProg.Text == "MAIZ")
                        {
                            TxtFechaFase.Visible = false;
                            TxtPorcentaje.Visible = true; ;
                            TxtFechaFase.Visible = false;
                            DDLEstadoFF.Visible = true;
                            LblFechaFase.Text = "Etapa:";
                            DDLEstadoFF.Enabled = true;
                            DDLEstadoFF.Items.Clear();
                            DDLEstadoFF.Items.Insert(0, new ListItem("Avance", "Avance", true));
                            DDLEstadoFF.DataBind();
                            LblValor1.Visible = true;
                        }
                        else
                        {
                            if (DDLFenologia.SelectedItem.Text == "COSECHA Y ACOPIO")
                            {
                                TxtFechaFase.Visible = false;
                                TxtPorcentaje.Visible = true; ;
                                TxtFechaFase.Visible = false;
                                DDLEstadoFF.Visible = true;
                                LblFechaFase.Text = "Etapa:";
                                DDLEstadoFF.Enabled = true;
                                DDLEstadoFF.Items.Clear();
                                DDLEstadoFF.Items.Insert(0, new ListItem("Avance", "Avance", true));
                                DDLEstadoFF.Enabled = false;
                                DDLEstadoFF.DataBind();
                                LblValor1.Visible = true;
                            }
                            else
                            {
                               TxtFechaFase.Visible = false;
                               TxtPorcentaje.Visible = true; ;
                               TxtFechaFase.Visible = false;
                               DDLEstadoFF.Visible = true;
                               LblFechaFase.Text = "Etapa:";
                               DDLEstadoFF.Enabled = true;
                               DDLEstadoFF.Items.Clear();
                               DDLEstadoFF.Items.Insert(0, new ListItem("Inicial", "Inicial", true));
                               DDLEstadoFF.Items.Insert(1, new ListItem("Final", "Final", true));
                               DDLEstadoFF.DataBind();
                               LblValor1.Visible = true;
                            }
                        }
                    }
                }
                Calcularar_AVANCE_SIEMBRA();
                Calcularar_PORCENTAJE_FENOLOGIA();
        }
        #endregion

        protected void TxtPorcentaje_TextChanged(object sender, EventArgs e)
        {
            if (DDLFenologia.SelectedItem.Text == "FECHA Y AVANCE DE SIEMBRA")
            {           
                if (Convert.ToDecimal(TxtPorcentaje.Text) < Convert.ToDecimal(LblPorcentaje.Text))
                 {
                   TxtPorcentaje.Text = string.Empty;
                 }
            } 
        }

        //protected void DDLTipo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DDLTipo.SelectedValue == "No definido") 
        //    {
        //        TxtEstadoTipo.Text = string.Empty;//string.Empty;
        //        TxtIntencidad.Text = "0";
        //        TxtTratamiento.Text = string.Empty; //string.Empty;
        //    }
        //}

        protected void DDLEstadoFF_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Calcularar_AVANCE_SIEMBRA();
            Calcularar_PORCENTAJE_FENOLOGIA();
            //TxtPorcentaje.Text = string.Empty;
        }

        protected void LnkRegCoord_Click(object sender, EventArgs e)
        {
            if (TxtCoordX.Text != "" && TxtCoordY.Text != "")
            {
                LstCoordX.Items.Add(TxtCoordX.Text);
                LstCoordY.Items.Add(TxtCoordY.Text);
                LstNumParcela.Items.Add(DDLNumParcela.SelectedValue);
                TxtCoordX.Text = string.Empty;
                TxtCoordY.Text = string.Empty;
                LblMsj2.Text = string.Empty;
                BtnEnviar.Enabled = true;
            }
            else 
            {
                LblMsj2.Text = "Se necesita la coordenada X y la Y para continuar";
            }
        }

        protected void LnkAgregarSem_Click(object sender, EventArgs e)
        {
            if(TxtVariedad.Text !="")
            {
                LstVariedadSem.Items.Add(TxtVariedad.Text);
                BtnEnviar.Enabled = true;
                LblMsj3.Text = string.Empty;
            }
            else
            {
                LblMsj3.Text = "Es necesario digitar la variedad de semilla a sembrar.";
            }
        }
        protected void LnkBorraCoord_Click(object sender, EventArgs e)
        {
            Eliminar_LISTA();
        }
        #region FUNCIONES PARA ELIMINAR TAREA
        private void Eliminar_LISTA()
        {
            if (LstCoordX.SelectedIndex >= 0)
            {
                int valor = LstCoordX.SelectedIndex;
                LstCoordX.Items.RemoveAt(valor);
                LstCoordY.Items.RemoveAt(valor);
                LstNumParcela.Items.RemoveAt(valor);
                LblMsj2.Text = string.Empty;
            }
            else
            {
                LblMsj2.Text = "Debe seleccionar la coordenada del lado X para borrar";
            } 
        }
        #endregion

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmSeguimientoTecnico.aspx");
        }

        protected void GVSegCultivo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string aux = "";
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            DataTable DT = Session["datos"] as DataTable;

                if (rowIndex != -1)
                    //aux = DT.Rows[rowIndex][3].ToString();
                    if (DDLFenologia.SelectedItem.Text != "FECHA Y AVANCE DE SIEMBRA")
                    {
                      LblCont.Text = (Convert.ToInt32(LblCont.Text) - Convert.ToInt32(DT.Rows[rowIndex][3].ToString())).ToString();
                    }
                    DT.Rows.RemoveAt(rowIndex);
                    GVSegCultivo.DataSource = DT;
                    GVSegCultivo.DataBind();
                    Session["datos"] = DT;
                    if (DDLFenologia.SelectedItem.Text == "COSECHA Y ACOPIO")
                    {
                        BtnRegistrar.Enabled = true;
                        DDLFenologia.Enabled = true;
                    }         
        }

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

        protected void DDLIntensidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(DDLIntensidad.SelectedValue)
            {
                case"0":
                    LblIntencidad.Text = "(0)% ";
                    break;
                case"1":
                    LblIntencidad.Text = "(1 - 25)%";
                    break;
                case"2":
                    LblIntencidad.Text = "(26 - 50)%";
                    break;
                case"3":
                    LblIntencidad.Text = "(51 - 75)%";
                    break;
                case"4":
                    LblIntencidad.Text = "(75 - 100)%";
                    break;
            }
        }

        protected void DDLVariedad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }      
}