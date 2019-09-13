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
    public partial class frmParcelaSiembra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RangeValidator2.ErrorMessage = "JOSE";

            //RangeValidator2.MaximumValue
            //try
            //{
            if (!IsPostBack)
            {
                LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                LblIdInsProd.Text = Session["IdInsProd"].ToString();
                LblIdUsuario.Text = Session["IdUser"].ToString();
                LblEtapa.Text = Session["Etapa"].ToString();
                LblId_Etapa.Text = Session["Id_Etapa"].ToString();//**LR
                LblEstado.Text = Session["Estado"].ToString();                
                /***************************************/
                Datos_Org_ENCABEZADO();
                Control_FORMULARIO();
                Desplegar_INSUMOS_PRODUCTOR();
                llenadoDDLSistemaSiembra();//lrojas: 06-07-2017
            }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
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
        /******************************** FUNCIONES **************************************/
        #region FUNCIONES PARA CONTROLAR EL USUARIO
        private void Control_FORMULARIO()
        {
            /**************************************************************************/
            DB_EXT_Seguimiento num = new DB_EXT_Seguimiento();
            DataTable dt = new DataTable();
            dt = num.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg.Text), LblIdInsProd.Text, "", "NUMSEG");
            PnlDatsParcela.Visible = true;
            PnlOBsRec.Visible = true;
        }
        #endregion

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {

        }
        protected void LnkAgregarSem_Click(object sender, EventArgs e)
        {

        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (TxtNumBoleta.Text != "")
            {
                if (TxtFecha.Text != "")
                {
                    LblMsj3.Text = string.Empty;
                    Registrar_VERIFICACION_DE_SIEMBRA();
                }
                else
                {
                    LblMsj3.Text = "Tiene que especificar la fecha de la boleta del seguimiento técnico realizado";
                }
            }
            else
            {
                LblMsj3.Text = "Tiene que especificar un numero de boleta del seguimiento técnico realizado";
            }
        }

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
                            if (TxtVariedad.Text != "")
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
            //seg.Etapa = LblEtapa.Text;LR
            seg.Etapa = LblId_Etapa.Text;
            if (LblEtapa.Text == "1")//"VERIFICACION_PARCELA")//LR
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
            //segParc.Hora_Seg = DDLHora.SelectedValue + ":" + DDLMinuto.SelectedValue;
            segParc.Hora_Seg = string.Empty;
            segParc.Fecha_Sis = DateTime.Now;
            segParc.Observacion = TxtObser.Text;
            segParc.Recomendacion = TxtRecomen.Text;
            insSeg.DB_Registrar_SEGUIMIENTO_PARCELA(segParc);

            EXT_SeguimientoCoordenadas scor = new EXT_SeguimientoCoordenadas();
            EXT_SeguimientoSiembra ss = new EXT_SeguimientoSiembra();
            EXT_SeguimientoCultivo sc = new EXT_SeguimientoCultivo();
            //EXT_AdversidadPresentada ad = new EXT_AdversidadPresentada();
                    //string auxVariedad = "";
                    int id = 0;
                    id = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO_PARCELA", "Id_Seguimiento_Parcela"));
                    //ss.Id_Seguimiento_Parcela = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO_PARCELA", "Id_Seguimiento_Parcela"));
                    ss.Id_Seguimiento_Parcela = id;
                    ss.Fecha_SiembraINI = Convert.ToDateTime(TxtFechaIniSiembra.Text);
                    ss.Fecha_SiembraFIN = Convert.ToDateTime(TxtFechaFinSiembra.Text);
                    ss.Sistema_Siembra = DDLSistemaSiembra.SelectedValue;
                    ss.Cultivo_Anterior = TxtCultivoAnt.Text;
                    ss.Variedad_Semilla = TxtVariedad.Text; /*************** VASRIEDAD DE SEMILLLA CUANTOS SE PUEDE REGISTRAR PERO NO GUARDA OJOJOJOJO***************/
                    ss.Avance_Siembra = Convert.ToInt32(TxtAvanceSiem.Text);
                    insSeg.DB_Registrar_SEGUIMIENTO_SIEMBRA(ss);
                    sc.Id_Seguimiento_Parcela = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO_PARCELA", "Id_Seguimiento_Parcela"));
                    switch (LblProg.Text)
                    {
                        case "ARROZ":
                            aux1 = 1;
                            break;
                        case "MAIZ":
                            aux1 = 11;
                            break;
                        case "TRIGO":
                            aux1 = 25;
                            break;
                    }
                    sc.Id_Fenologia = aux1;
                    sc.Estado = "Avance";
                    sc.Porcentaje_FF = Convert.ToInt32(TxtAvanceSiem.Text);
                    sc.Fecha_Cosecha = Convert.ToDateTime("01/01/1900");
                    //insSeg.DB_Registrar_SEGUIMIENTO_CULTIVO(sc);
                    //estadoprod.DB_Cambiar_ESTADO(LblIdInsProd.Text, "VERIFICACION_CULTIVO");
                    estadoprod.DB_Cambiar_ESTADO(LblIdInsProd.Text, "3");

          ///****** inicio nuevo
                    //**ADVERSIDAD
                    //int id = 0;
                    //id = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO_PARCELA", "Id_Seguimiento_Parcela"));
                    EXT_AdversidadPresentada adver = new EXT_AdversidadPresentada();
                    if (GVAdversidad.Rows.Count > 0)
                    {
                        foreach (GridViewRow dgi in GVAdversidad.Rows)
                        {
                            adver.Id_Seguimiento_Parcela = id;
                            if (GVAdversidad.Rows[dgi.RowIndex].Cells[0].Text != string.Empty)
                            {
                                adver.Adversidad = GVAdversidad.Rows[dgi.RowIndex].Cells[0].Text;
                                adver.Intencidad = GVAdversidad.Rows[dgi.RowIndex].Cells[1].Text;
                                adver.Porcentage = Convert.ToDecimal(GVAdversidad.Rows[dgi.RowIndex].Cells[2].Text);
                                adver.Fecha_Ocurrencia = Convert.ToDateTime(GVAdversidad.Rows[dgi.RowIndex].Cells[3].Text);
                                //adver.Descripcion = GVAdversidad.Rows[dgi.RowIndex].Cells[4].Text;
                                adver.Descripcion = HttpUtility.HtmlDecode(GVAdversidad.Rows[dgi.RowIndex].Cells[4].Text);
                                adver.Tratamiento = string.Empty;
                                insSeg.DB_Registrar_ADVESIDAD(adver);
                            }
                        }
                    }
                    //*** plaga, maleza, enfermedad
                    EXT_AdversidadPresentada adpme = new EXT_AdversidadPresentada();
                    if (GV_PlagaMaEnf.Rows.Count > 0)
                    {
                        foreach (GridViewRow dgi in GV_PlagaMaEnf.Rows)
                        {
                            adpme.Id_Seguimiento_Parcela = id;
                            if (GV_PlagaMaEnf.Rows[dgi.RowIndex].Cells[0].Text != string.Empty)
                            {
                                adpme.Adversidad = GV_PlagaMaEnf.Rows[dgi.RowIndex].Cells[0].Text;
                                adpme.Descripcion = GV_PlagaMaEnf.Rows[dgi.RowIndex].Cells[1].Text;
                                adpme.Intencidad = GV_PlagaMaEnf.Rows[dgi.RowIndex].Cells[2].Text;
                                adpme.Tratamiento = GV_PlagaMaEnf.Rows[dgi.RowIndex].Cells[3].Text;
                                adpme.Porcentage = 0;//no se ingresa en sp
                                DateTime fecha = DateTime.Now;
                                adpme.Fecha_Ocurrencia = fecha; //no se ingresa en sp
                                insSeg.DB_Registrar_ADVESIDAD_PME(adpme);
                            }
                        }
                    }
            ///*** fin nuevo

        }
        #endregion
        #region FUNCIONES PARA SELECCIONAR LOS INSUMOS EN SEMILLA I AGROQUIMICOS QUE RETIRO EL PRODUCTOR
        private void Desplegar_INSUMOS_PRODUCTOR()
        {
            DB_EXT_Rendimiento ex = new DB_EXT_Rendimiento();
            DataTable dt = new DataTable();
            dt = ex.DB_Reporte_DETALLE_PLANILLA(Convert.ToInt32(LblIdInsOrg.Text), LblIdInsProd.Text, "SEMILLA", "INSUMO_PRODUCTOR");
            if (dt.Rows.Count > 0)
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

        protected void DDLVariedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtVariedad.Text = DDLVariedad.SelectedItem.Text;
        }
        /// <summary>
        /// Llena sistema de siembra segun región
        /// </summary>
        protected void llenadoDDLSistemaSiembra()
        {
            DB_AP_Registro_Org d_org = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            string iduser = Session["IdUser"].ToString();
            dt = d_org.DB_Desplegar_USUARIO(iduser);
            string region = "";
            DataTable table1 = new DataTable("region");
            table1.Clear();
            foreach(DataRow row in dt.Rows )
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
           
            DDLSistemaSiembra.DataSource = set;
            DDLSistemaSiembra.DataTextField = "text";
            DDLSistemaSiembra.DataValueField = "text";
            DDLSistemaSiembra.DataBind();

        }

        protected void RdbAdeversidadSI_CheckedChanged(object sender, EventArgs e)
        {
            PnlAdversidad.Visible = true;
            //**luis.rojas
            DataTable dtAdversidad = new DataTable();
            DataRow drAdversidad;
            dtAdversidad.TableName = "Adversidad";
            dtAdversidad.Columns.Add(new DataColumn("Adversidad", typeof(string)));
            dtAdversidad.Columns.Add(new DataColumn("Intensidad", typeof(string)));
            dtAdversidad.Columns.Add(new DataColumn("Porcentaje", typeof(int)));
            dtAdversidad.Columns.Add(new DataColumn("Fecha_Ocurrencia", typeof(string)));
            dtAdversidad.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            drAdversidad = dtAdversidad.NewRow();
            dtAdversidad.Rows.Add(drAdversidad);
            ViewState["dtAdversidad"] = dtAdversidad;
            GVAdversidad.DataSource = dtAdversidad;
            GVAdversidad.DataBind();
        }

        protected void RdbAdeversidadNO_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dtTable = (DataTable)ViewState["dtAdversidad"];
            if (dtTable.Rows[0][0].ToString() == "")
            {
                DataTable dtAdversidad = new DataTable();
                ViewState["dtAdversidad"] = dtAdversidad;
                Limpiar_CAMPOS_ADVERSIDAD();
                PnlAdversidad.Visible = false;
                GVAdversidad.DataSource = null;
                GVAdversidad.DataBind();
            }
            else
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, "EXISTEN ADVERSIDADES REGISTRADAS..!");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }

        protected void BtnInsertAdversidad_Click(object sender, EventArgs e)
        {
            //************Evento Adverso
            if (GVAdversidad.Rows.Count > 0)
            {
                foreach (GridViewRow row in GVAdversidad.Rows)
                {
                    string valorcol2 = row.Cells[0].Text;
                    if (row.Cells[0].Text == DDLAdversidad.SelectedValue)
                    {
                        string script = @"<script type='text/javascript'>alert('{0}');</script>";
                        script = string.Format(script, "EVENTO ADVERSO YA SELECCIONADO..!");
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        return;
                    }
                }
            }
            //************intensidad
            if (Convert.ToInt16(TxtIntencidad.Text) == 0)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, "INGRESE INTENSIDAD..!");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
            //************FECHA
            if (txt_fecha_adversidad.Text == string.Empty)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, "INGRESE FECHA OCURRENCIA..!");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
            //*************
            if (ViewState["dtAdversidad"] != null)
            {
                DataTable dtTable = (DataTable)ViewState["dtAdversidad"];
                DataRow drRow = null;
                if (dtTable.Rows.Count > 0)
                {
                    ////**luis.rojas 25/05/2016
                    //if (dtTable.Rows[0]["Adversidad"].ToString() == DDLAdversidad.SelectedValue)
                    //{
                    //    string script = @"<script type='text/javascript'>alert('{0}');</script>";
                    //    script = string.Format(script, "EVENTO ADVERSO YA SELECCIONADO..!");
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    //    return;
                    //}
                    ////**
                    drRow = dtTable.NewRow();
                    drRow["Adversidad"] = DDLAdversidad.SelectedValue.ToString();
                    drRow["Intensidad"] = DDLIntensidad.SelectedValue.ToString();
                    drRow["Porcentaje"] = TxtIntencidad.Text;
                    drRow["Fecha_Ocurrencia"] = txt_fecha_adversidad.Text.Trim();
                    drRow["Descripcion"] = txt_Observacion.Text.Trim();
                }
                if (dtTable.Rows[0][0].ToString() == "")
                {
                    dtTable.Rows[0].Delete();
                    dtTable.AcceptChanges();
                }
                dtTable.Rows.Add(drRow);
                ViewState["dtAdversidad"] = dtTable;
                GVAdversidad.DataSource = dtTable;
                GVAdversidad.DataBind();
                Limpiar_CAMPOS_ADVERSIDAD();
            }
        }

        protected void GVAdversidad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
        }

        protected void GVAdversidad_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["dtAdversidad"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["dtAdversidad"] = dt;
            GVAdversidad.DataSource = ViewState["dtAdversidad"] as DataTable;
            GVAdversidad.DataBind();

            if (dt.Rows.Count == 0)
            {
                DataRow dr;
                dr = dt.NewRow();
                dt.Rows.Add(dr);
                GVAdversidad.DataSource = dt;
                GVAdversidad.DataBind();
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedItem.Text == "SI")
            {
                pnlPlaga.Visible = true;
                DataTable dtPME = new DataTable();
                DataRow drPME;
                dtPME.TableName = "PME";
                dtPME.Columns.Add(new DataColumn("PME", typeof(string)));
                dtPME.Columns.Add(new DataColumn("Detalle", typeof(string)));
                dtPME.Columns.Add(new DataColumn("Intensidad", typeof(string)));
                dtPME.Columns.Add(new DataColumn("Tratamiento", typeof(string)));
                drPME = dtPME.NewRow();
                dtPME.Rows.Add(drPME);
                ViewState["dtPME"] = dtPME;
                GV_PlagaMaEnf.DataSource = dtPME;
                GV_PlagaMaEnf.DataBind();
            }
            else
            {
                DataTable dtTable = (DataTable)ViewState["dtPME"];
                if (dtTable.Rows[0][0].ToString() == "")
                {
                    DataTable dtAdversidad = new DataTable();
                    ViewState["dtPME"] = dtAdversidad;
                    Limpiar_CAMPOS_PLAGA();
                    Limpiar_CAMPOS_MALEZA();
                    Limpiar_CAMPOS_ENFERMEDADES();
                    pnlPlaga.Visible = false;
                }
                else
                {
                    string script = @"<script type='text/javascript'>alert('{0}');</script>";
                    script = string.Format(script, "EXISTEN DATOS REGISTRADOS..!");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }

            }
        }

        protected void BtnAgregarPlaga_Click(object sender, EventArgs e)
        {
            //************               
            if (GV_PlagaMaEnf.Rows.Count > 0)
            {
                foreach (GridViewRow row in GV_PlagaMaEnf.Rows)
                {

                    string valorcol2 = row.Cells[1].Text;
                    if (row.Cells[1].Text == txt_Plagas.Text.Trim())
                    {
                        string script = @"<script type='text/javascript'>alert('{0}');</script>";
                        script = string.Format(script, "PLAGA YA REGISTRADA..!");
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        return;
                    }
                }
            }
            //************
            if (ViewState["dtPME"] != null)
            {
                DataTable dtTable = (DataTable)ViewState["dtPME"];
                DataRow drRow = null;
                if (dtTable.Rows.Count > 0)
                {
                    //if (dtTable.Rows[0]["Detalle"].ToString() == "Plaga "+txt_Plagas.Text.Trim())
                    //{
                    //    string script = @"<script type='text/javascript'>alert('{0}');</script>";
                    //    script = string.Format(script, "PLAGA YA REGISTRADA..!");
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    //    return;
                    //}
                    drRow = dtTable.NewRow();
                    drRow["PME"] = "PLAGA";
                    drRow["Detalle"] = txt_Plagas.Text.Trim();
                    drRow["Intensidad"] = DDLIntensidad_Plaga.SelectedValue.ToString();
                    drRow["Tratamiento"] = txt_Tratamiento_Plagas.Text.Trim();

                }
                if (dtTable.Rows[0][0].ToString() == "")
                {
                    dtTable.Rows[0].Delete();
                    dtTable.AcceptChanges();
                }
                dtTable.Rows.Add(drRow);
                ViewState["dtPME"] = dtTable;
                GV_PlagaMaEnf.DataSource = dtTable;
                GV_PlagaMaEnf.DataBind();
                Limpiar_CAMPOS_PLAGA();
            }
        }

        protected void BtnInsert_Malezas_Click(object sender, EventArgs e)
        {
            if (GV_PlagaMaEnf.Rows.Count > 0)
            {
                foreach (GridViewRow row in GV_PlagaMaEnf.Rows)
                {

                    string valorcol2 = row.Cells[1].Text;
                    if (row.Cells[1].Text == txt_Malezas.Text.Trim())
                    {
                        string script = @"<script type='text/javascript'>alert('{0}');</script>";
                        script = string.Format(script, "MALEZA YA REGISTRADA..!");
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        return;
                    }
                }
            }
            if (ViewState["dtPME"] != null)
            {
                DataTable dtTable = (DataTable)ViewState["dtPME"];
                DataRow drRow = null;
                if (dtTable.Rows.Count > 0)
                {
                    //if (dtTable.Rows[0]["Detalle"].ToString() == "Maleza " + txt_Malezas.Text.Trim())
                    //{
                    //    string script = @"<script type='text/javascript'>alert('{0}');</script>";
                    //    script = string.Format(script, "MALEZA YA REGISTRADA..!");
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    //    return;
                    //}
                    drRow = dtTable.NewRow();
                    drRow["PME"] = "MALEZA";
                    drRow["Detalle"] = txt_Malezas.Text.Trim();
                    drRow["Intensidad"] = DDLIntensidad_Maleza.SelectedValue.ToString();
                    drRow["Tratamiento"] = txt_Tratamiento_Malezas.Text.Trim();

                }
                if (dtTable.Rows[0][0].ToString() == "")
                {
                    dtTable.Rows[0].Delete();
                    dtTable.AcceptChanges();
                }
                dtTable.Rows.Add(drRow);
                ViewState["dtPME"] = dtTable;
                GV_PlagaMaEnf.DataSource = dtTable;
                GV_PlagaMaEnf.DataBind();
                Limpiar_CAMPOS_MALEZA();
            }
        }

        protected void BtnInsert_Enfermedad_Click(object sender, EventArgs e)
        {
            if (GV_PlagaMaEnf.Rows.Count > 0)
            {
                foreach (GridViewRow row in GV_PlagaMaEnf.Rows)
                {

                    string valorcol2 = row.Cells[1].Text;
                    if (row.Cells[1].Text == txt_Enfermedades.Text.Trim())
                    {
                        string script = @"<script type='text/javascript'>alert('{0}');</script>";
                        script = string.Format(script, "ENFERMEDAD YA REGISTRADA..!");
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        return;
                    }
                }
            }
            if (ViewState["dtPME"] != null)
            {
                DataTable dtTable = (DataTable)ViewState["dtPME"];
                DataRow drRow = null;
                if (dtTable.Rows.Count > 0)
                {
                    //if (dtTable.Rows[0]["Detalle"].ToString() == "Enfermedad " + txt_Enfermedades.Text.Trim())
                    //{
                    //    string script = @"<script type='text/javascript'>alert('{0}');</script>";
                    //    script = string.Format(script, "ENFERMEDAD YA REGISTRADA..!");
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    //    return;
                    //}
                    drRow = dtTable.NewRow();
                    drRow["PME"] = "ENFERMEDAD";
                    drRow["Detalle"] = txt_Enfermedades.Text.Trim();
                    drRow["Intensidad"] = DDLIntensidad_Enfermedad.SelectedValue.ToString();
                    drRow["Tratamiento"] = txt_Tratamiento_Enfermedades.Text.Trim();

                }
                if (dtTable.Rows[0][0].ToString() == "")
                {
                    dtTable.Rows[0].Delete();
                    dtTable.AcceptChanges();
                }
                dtTable.Rows.Add(drRow);
                ViewState["dtPME"] = dtTable;
                GV_PlagaMaEnf.DataSource = dtTable;
                GV_PlagaMaEnf.DataBind();
                Limpiar_CAMPOS_ENFERMEDADES();
            }
        }

        protected void GV_PlagaMaEnf_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[3].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Eliminar " + item + "?')) {return false;};";
                    }
                }
            }
        }

        protected void GV_PlagaMaEnf_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["dtPME"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["dtPME"] = dt;
            GV_PlagaMaEnf.DataSource = ViewState["dtPME"] as DataTable;
            GV_PlagaMaEnf.DataBind();
            Limpiar_CAMPOS_PLAGA();
            Limpiar_CAMPOS_MALEZA();
            Limpiar_CAMPOS_ENFERMEDADES();
            if (dt.Rows.Count == 0)
            {
                DataRow dr;
                dr = dt.NewRow();
                dt.Rows.Add(dr);
                GV_PlagaMaEnf.DataSource = dt;
                GV_PlagaMaEnf.DataBind();
            }
        }
        #region FUNCION DE LIMPIAR CAMPOS
        private void Limpiar_CAMPOS_ADVERSIDAD()
        {
            txt_Observacion.Text = string.Empty;
            TxtIntencidad.Text = "0";
            txt_fecha_adversidad.Text = string.Empty;
            Calendar1.Visible = false;
            DDLIntensidad.DataBind();
            DDLIntensidad.SelectedIndex = 0;
        }
        private void Limpiar_CAMPOS_PLAGA()
        {
            txt_Plagas.Text = string.Empty;
            txt_Tratamiento_Plagas.Text = string.Empty;
            DDLIntensidad_Plaga.DataBind();
            DDLIntensidad_Plaga.SelectedIndex = 0;
        }
        private void Limpiar_CAMPOS_MALEZA()
        {
            txt_Malezas.Text = string.Empty;
            txt_Tratamiento_Malezas.Text = string.Empty;
            DDLIntensidad_Maleza.DataBind();
            DDLIntensidad_Maleza.SelectedIndex = 0;
        }
        private void Limpiar_CAMPOS_ENFERMEDADES()
        {
            txt_Enfermedades.Text = string.Empty;
            txt_Tratamiento_Enfermedades.Text = string.Empty;
            DDLIntensidad_Enfermedad.DataBind();
            DDLIntensidad_Enfermedad.SelectedIndex = 0;
        }
        #endregion

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

        protected void DDLAdversidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txt_fecha_adversidad.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }

        protected void DDLIntensidad_Plaga_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLIntensidad_Maleza_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLIntensidad_Enfermedad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}