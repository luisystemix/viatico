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
    public partial class frmParcelaCoordenadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RangeValidator2.ErrorMessage = "JOSE";

            //RangeValidator2.MaximumValue
            //try
            //{
            if (Session["IdUser"] == null)
            { Response.Redirect("~/About.aspx"); }
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
                /*****************************************************/
                DataTable dtListaPartida1 = new DataTable();
                dtListaPartida1.Columns.AddRange(new DataColumn[4] { new DataColumn("Num_Parcela"), new DataColumn("Num_Punto"), new DataColumn("CoordX"), new DataColumn("CoordY") });
                GVCoord.DataSource = dtListaPartida1;
                GVCoord.DataBind();
                Session["datos"] = dtListaPartida1;
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

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (TxtNumBoleta.Text != "")
            {
                if (TxtFecha.Text != "")
                {
                    LblMsj2.Text = string.Empty;
                    Control_Registrar_SEGUIMIENTO();
                }
                else
                {
                    LblMsj2.Text = "Tiene que especificar la fecha de la boleta del seguimiento técnico realizado";
                }
            }
            else
            {
                LblMsj2.Text = "Tiene que especificar un numero de boleta del seguimiento técnico realizado";
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {

        }
        /******************************** FUNCIONES **************************************/
        #region FUNCIONES PARA CONTROLAR EL USUARIO
        private void Control_FORMULARIO()
        {
          /**************************************************************************/
            DB_EXT_Seguimiento num = new DB_EXT_Seguimiento();
            DataTable dt = new DataTable();
            dt = num.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg.Text), LblIdInsProd.Text, "", "NUMSEG");
            PnlDatsCoord.Visible = true;
            PnlOBsRec.Visible = true;
        }
        #endregion
        #region
        /******************/
        protected void Control_Registrar_SEGUIMIENTO()
        {
            if (GVCoord.Rows.Count > 0)
            {
                LblMsj2.Text = string.Empty;
                Registrar_SEGUIMIENTO();
                Response.Redirect("frmSeguimientoTecnico.aspx");
            }
            else
            {
                LblMsj2.Text = "Tiene que especificar las coordenadas";
            }
        }
        #endregion
        #region FUNCION DE LIMPIAR CAMPOS
        private void Linpiar_CAMPOS() 
        {
            TxtCoordX.Text = string.Empty;
            TxtCoordY.Text = string.Empty;
            txtPunto.Text = string.Empty;
            LblMsj2.Text = string.Empty;
            BtnEnviar.Enabled = true;
        }
        #endregion
        #region REGISTRAR LAS COORDENADAS EN LA GRILLA
        protected void BtnInsertar_Click(object sender, EventArgs e)
        {
           if (TxtCoordX.Text != "" && TxtCoordY.Text != "")
            {
                DataTable dt = Session["datos"] as DataTable;
                DataRow row = dt.NewRow();
                row["Num_Parcela"] = DDLNumParcela.SelectedValue;
                row["Num_Punto"] = txtPunto.Text;
                row["CoordX"] = TxtCoordX.Text;
                row["CoordY"] = TxtCoordY.Text;
                dt.Rows.Add(row);
                GVCoord.DataSource = dt;
                GVCoord.DataBind();
                Session["datos"] = dt;
                Linpiar_CAMPOS();
                BtnEnviar.Enabled = true;
            }
           else
            {
                Response.Write("<script>window.alert('Se necesita la coordenada X y la Y, para identificar el punto');</script>");
            }
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
            //seg.Etapa = LblEtapa.Text;
            seg.Etapa = LblId_Etapa.Text;
            seg.Num_Seg_Cultivo = 0;
            
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
            int id = 0;
            id = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO_PARCELA", "Id_Seguimiento_Parcela"));            
            //scor.Id_Seguimiento_Parcela = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO_PARCELA", "Id_Seguimiento_Parcela"));            
            foreach (GridViewRow dgi in GVCoord.Rows)
            {
                scor.Id_Seguimiento_Parcela = id;
                scor.Id_Productor = LblIdInsProd.Text;
                scor.Num_Parcela = Convert.ToInt32(GVCoord.Rows[dgi.RowIndex].Cells[0].Text);
                scor.Num_Punto = Convert.ToInt16(GVCoord.Rows[dgi.RowIndex].Cells[1].Text); 
                scor.CoordenadaX = GVCoord.Rows[dgi.RowIndex].Cells[2].Text;
                scor.CoordenadaY = GVCoord.Rows[dgi.RowIndex].Cells[3].Text;                
                insSeg.DB_Registrar_SEGUIMIENTO_COORDENADA(scor);
            }
            ///****** inicio nuevo
            //**ADVERSIDAD
            //int id = 0;
            //id = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO_PARCELA", "Id_Seguimiento_Parcela"));
            EXT_AdversidadPresentada ad = new EXT_AdversidadPresentada();
            if (GVAdversidad.Rows.Count > 0)
            {
                foreach (GridViewRow dgi in GVAdversidad.Rows) 
                {
                    ad.Id_Seguimiento_Parcela = id;
                    if (GVAdversidad.Rows[dgi.RowIndex].Cells[0].Text != string.Empty)
                    {
                        ad.Adversidad = GVAdversidad.Rows[dgi.RowIndex].Cells[0].Text;
                        ad.Intencidad = GVAdversidad.Rows[dgi.RowIndex].Cells[1].Text;
                        ad.Porcentage = Convert.ToDecimal(GVAdversidad.Rows[dgi.RowIndex].Cells[2].Text);
                        ad.Fecha_Ocurrencia = Convert.ToDateTime(GVAdversidad.Rows[dgi.RowIndex].Cells[3].Text);
                        //ad.Descripcion = GVAdversidad.Rows[dgi.RowIndex].Cells[4].Text;
                        ad.Descripcion = HttpUtility.HtmlDecode(GVAdversidad.Rows[dgi.RowIndex].Cells[4].Text);
                        ad.Tratamiento = string.Empty;
                        insSeg.DB_Registrar_ADVESIDAD(ad);
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
                        DateTime fecha =  DateTime.Now;
                        adpme.Fecha_Ocurrencia = fecha; //no se ingresa en sp
                        insSeg.DB_Registrar_ADVESIDAD_PME(adpme);
                    }
                }
            }
            ///*** fin nuevo
            //estadoprod.DB_Cambiar_ESTADO(LblIdInsProd.Text, "DISTRIBUCION_SEMILLA");
            estadoprod.DB_Cambiar_ESTADO(LblIdInsProd.Text, "2");
            Response.Write("<script>window.alert('El Registrado de las coordenadas se realizó  Correctamente…..');</script>");
            Response.Redirect("frmSeguimientoTecnico.aspx");
        }
        #endregion

        protected void GVCoord_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string aux = "";
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            DataTable DT = Session["datos"] as DataTable;
            DT.Rows.RemoveAt(rowIndex);
            GVCoord.DataSource = DT;
            GVCoord.DataBind();
            Session["datos"] = DT;
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