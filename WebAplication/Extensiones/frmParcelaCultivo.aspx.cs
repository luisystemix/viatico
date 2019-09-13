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
    public partial class frmParcelaCultivo : System.Web.UI.Page
    {
        
        private string Contador
        {
            get
            {
                if (ViewState["Contador"] != null)
                    return (string)ViewState["Contador"];

                return string.Empty;
            }
            set { ViewState["Contador"] = value; }
        }
        /// <summary>
        /// Coleccion Auxiliar para controlar datos recuperados de la BD del Productor
        /// </summary>
        /// 
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
                
                LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                LblIdInsProd.Text = Session["IdInsProd"].ToString();
                LblIdUsuario.Text = Session["IdUser"].ToString();
                LblEtapa.Text = Session["Etapa"].ToString();
                LblId_Etapa.Text = Session["Id_Etapa"].ToString();//**LR
                LblEstado.Text = Session["Estado"].ToString();
                //DATOS DEL ENCABEZADO ---> DATOS DEL PRODUCTOR
                Datos_Org_ENCABEZADO();
                //CARGA DATOS DE LA FASE FENOLOGICA
                Cargar_COMBO();   
                // CONTADOR NUM DE SEGUIMIENTO CULTIVO    
                Control_FORMULARIO();
                
                /*************************************/
                AddDefaultFirstRecord();

                RECUPERAR_REGISTRO_CULTIVO();

                //DataTable dtListaPartida = new DataTable();
                //dtListaPartida.Columns.AddRange(new DataColumn[5] { new DataColumn("Id_Fenologia"), new DataColumn("FaceFenologica"), new DataColumn("EstadoFF"), new DataColumn("Porcentaje"), new DataColumn("Fecha_Cosecha") });
                //GVSegCultivo.DataSource = dtListaPartida;
                //GVSegCultivo.DataBind();
                //Session["datos"] = dtListaPartida;
                //Contro2_FORMULARIO();
                /*****************************************************/
                DataTable dtListaPartida1 = new DataTable();
                dtListaPartida1.Columns.AddRange(new DataColumn[5] { new DataColumn("Adversidad"), new DataColumn("Descripcion"), new DataColumn("Intencidad"), new DataColumn("Porcentaje"), new DataColumn("Tratamiento") });
                GVAdversidad.DataSource = dtListaPartida1;
                GVAdversidad.DataBind();
                Session["datos1"] = dtListaPartida1;                
                /********************************************/
                Calcularar_AVANCE_SIEMBRA();
                Calcularar_AVANCE_SIEMBRA_CULTIVO();
                /*********************************************/
                ////Desplegar_INSUMOS_PRODUCTOR();
            }            
        }

        #region FUNCION PARA AGREGAR REGISTROS
        private void AddFaseFenologica()
        {
            if (Contador == "1")
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, "SOLO ES PERMITIDO UN REGISTRO DE CULTIVO..!");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
            //************CULTIVO
            if (GVSegCultivo.Rows.Count > 0)
            {
                foreach (GridViewRow row in GVSegCultivo.Rows)
                {
                    string valorcol2 = row.Cells[0].Text;
                    if (valorcol2 == "&nbsp;" && GVSegCultivo.Rows.Count == 1)
                        continue;
                    if (Convert.ToInt16(DDLFenologia.SelectedValue) < Convert.ToInt16(row.Cells[0].Text))
                    {
                        string script = @"<script type='text/javascript'>alert('{0}');</script>";
                        script = string.Format(script, "NO PUEDE SELECCIONAR FENOLOGICA HACIA ATRAS..!");
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        return;
                    }
                }
            }
            //***********PORCENTAJE
            //if (Convert.ToInt16(TxtPorcentaje.Text) == 0)
            //{
            //    string script = @"<script type='text/javascript'>alert('{0}');</script>";
            //    script = string.Format(script, "INGRESE PORCENTAJE DE AVANCE..!");
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            //    return;
            //}
            if (ViewState["dtFenologia"] != null)
            {
                DataTable dtTable = (DataTable)ViewState["dtFenologia"];
                DataRow drRow = null;
                if (dtTable.Rows.Count > 0)
                {
                    //**luis.rojas 25/05/2016
                    if (TxtPorcentaje.Text == "100")
                    {
                        //string script = @"<script type='text/javascript'>alert('{0}');</script>";
                        //script = string.Format(script, "FASE FENOLOGICA " + DDLFenologia.SelectedItem.Text + " al " + TxtPorcentaje.Text + " %");
                        //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        //return;
                    }
                    else
                    {
                        //if (dtTable.Rows[0]["Id_Fenologia"].ToString() == DDLFenologia.SelectedValue)
                        //{
                        //    string script = @"<script type='text/javascript'>alert('{0}');</script>";
                        //    script = string.Format(script, "FASE FENOLOGICA YA SELECCIONADA..!");
                        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        //    return;
                        //}
                    }
                    
                    //**
                    drRow = dtTable.NewRow();
                    drRow["Id_Fenologia"] = DDLFenologia.SelectedValue;
                    drRow["Fenologia"] = DDLFenologia.SelectedItem.ToString();
                    drRow["EstadoFF"] = DDLEstadoFF.SelectedValue;
                    //drRow["Porcentaje"] = TxtPorcentaje.Text;
                    drRow["Porcentaje"] = 100;
                    drRow["Id_Seguimiento_Parcela"] = 0;
                    
                }
                if (dtTable.Rows[0][0].ToString() == "")
                {
                    dtTable.Rows[0].Delete();
                    dtTable.AcceptChanges();
                }
                dtTable.Rows.Add(drRow);
                ViewState["dtFenologia"] = dtTable;
                GVSegCultivo.DataSource = dtTable;
                GVSegCultivo.DataBind();
            }
            Contador = "1";
        }
        #endregion


        #region DATOS POR DEFECTO DE FASE FENOLÓGICA
        private void AddDefaultFirstRecord()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "Fenologia";
            dt.Columns.Add(new DataColumn("Id_Fenologia",typeof(int)));
            dt.Columns.Add(new DataColumn("Fenologia", typeof(string)));
            dt.Columns.Add(new DataColumn("EstadoFF", typeof(string)));
            dt.Columns.Add(new DataColumn("Porcentaje", typeof(int)));
            dt.Columns.Add(new DataColumn("Id_Seguimiento_Parcela", typeof(int)));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            ViewState["dtFenologia"] = dt;
            GVSegCultivo.DataSource = dt;
            GVSegCultivo.DataBind();
            //**
        }
        #endregion
        #region HABILITAR ALERTA DE BOTON ELIMINAR
        protected void GVSegCultivo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                string idsf = e.Row.Cells[5].Text;
                foreach (Button button in e.Row.Cells[4].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Eliminar " + item + "?')) {return false;};";
                    }
                    EXT_SeguimientoCultivo ObjSC = ColSeguimientoCultivo.Where(x => x.Id_Fenologia == Convert.ToInt16(item) && x.Id_Seguimiento_Parcela == Convert.ToInt16(idsf)).SingleOrDefault();
                    if (ObjSC != null)
                        e.Row.Enabled = false;
                }
                
            }           
        }
        #endregion
        protected void GVSegCultivo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["dtFenologia"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["dtFenologia"] = dt;
            GVSegCultivo.DataSource = ViewState["dtFenologia"] as DataTable;
            GVSegCultivo.DataBind();

            if (dt.Rows.Count == 0)
            {
                DataRow dr;
                dr = dt.NewRow();
                dt.Rows.Add(dr);
                GVSegCultivo.DataSource = dt;
                GVSegCultivo.DataBind();
            }
            Contador = "0";
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            LblMsj5.Text = string.Empty;
            AddFaseFenologica();
            

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
        {   /*         
            DB_EXT_Fenologia nd = new DB_EXT_Fenologia();
            List<EXT_Fenologia> ListaF = nd.DB_Desplegar_FENOLOGIA(LblProg.Text, LblIdInsProd.Text);
            DDLFenologia.DataSource = ListaF;
            DDLFenologia.DataValueField = "Id_Fenologia";
            DDLFenologia.DataTextField = "Nom_Fenologia";
            DDLFenologia.DataBind();
             */

            DB_EXT_Fenologia nd = new DB_EXT_Fenologia();
            List<EXT_Fenologia> ListaF = nd.DB_GET_FASES_FENOLOGICAS(LblProg.Text);
            DDLFenologia.DataSource = ListaF;
            DDLFenologia.DataValueField = "Id_Fenologia";
            DDLFenologia.DataTextField = "Nom_Fenologia";
            DDLFenologia.DataBind();

             /*
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Id_Fenologia");
            dt.Columns.Add("Nom_Fenologia");
            
            DataRow fila = dt.NewRow();
            fila["Id_Fenologia"] = "26";
            fila["Nom_Fenologia"] = "GERMINACION EMERGENCIA";
            dt.Rows.Add(fila);
            
            fila = dt.NewRow();
            fila["Id_Fenologia"] = "27";
            fila["Nom_Fenologia"] = "PLANTULA";
            dt.Rows.Add(fila);            
            
            fila = dt.NewRow();
            fila["Id_Fenologia"] = "28";
            fila["Nom_Fenologia"] = "MACOLLAMIENTO";
            dt.Rows.Add(fila);

            fila = dt.NewRow();
            fila["Id_Fenologia"] = "29";
            fila["Nom_Fenologia"] = "EMBUCHE";
            dt.Rows.Add(fila);

            fila = dt.NewRow();
            fila["Id_Fenologia"] = "30";
            fila["Nom_Fenologia"] = "ESPIGAZON";
            dt.Rows.Add(fila);

            fila = dt.NewRow();
            fila["Id_Fenologia"] = "31";
            fila["Nom_Fenologia"] = "FLORACION";
            dt.Rows.Add(fila);

            fila = dt.NewRow();
            fila["Id_Fenologia"] = "32";
            fila["Nom_Fenologia"] = "LLENADO GRANO";
            dt.Rows.Add(fila);

            fila = dt.NewRow();
            fila["Id_Fenologia"] = "33";
            fila["Nom_Fenologia"] = "MADURACION";
            dt.Rows.Add(fila);

            DDLFenologia.DataSource = dt;
            DDLFenologia.DataValueField = "Id_Fenologia";
            DDLFenologia.DataTextField = "Nom_Fenologia";
            DDLFenologia.DataBind();         
            */
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
              //  LblFechaFase.Text = "Etapa:";
              //  DDLEstadoFF.Enabled = false;
              //  DDLEstadoFF.Items.Insert(0, new ListItem("Avance", "Avance", true));
              //  DDLEstadoFF.DataBind();
              //  DDLEstadoFF.ClearSelection();
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
                //TxtSupSiem.Text = ((Convert.ToDecimal(dt.Rows[0][0].ToString()) * Convert.ToDecimal(dt.Rows[0][1].ToString())) / 100).ToString();
                //dt = rend.DB_Reporte_DETALLE_PLANILLA_CULTIVO(LblIdInsProd.Text, "REND_PROD");
                //if (dt.Rows.Count > 0)
                //{
                //    TxtRedimiento.Text = dt.Rows[0][9].ToString();
                //    TxtPesoApro.Text = (Convert.ToDecimal(TxtRedimiento.Text) * Convert.ToDecimal(TxtSupSiem.Text)).ToString();
                //}
                //else 
                //{
                //    TxtRedimiento.Text = "0";
                //    TxtPesoApro.Text = "0";
                //}
            }
            else
            {
                //TxtSupSiem.Text = "0";
                //TxtRedimiento.Text = "0"; 
                //TxtPesoApro.Text="0";
            }
            dt = rend.DB_Reporte_DETALLE_PLANILLA_CULTIVO(LblIdInsProd.Text, "FECHA_SIEMBRA");
           // TxtFechSiem.Text = dt.Rows[0][1].ToString();
        }
        #endregion
        #region FUNCION PARA CONTROLAR DEL COMBO DE FACE FENOLOGICA DEL CULTIVO
        protected void DDLFenologia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control_FORMULARIO();
            if (DDLFenologia.SelectedItem.Text == "FECHA COSECHA PROBABLE")
            {
                //TxtFechaFase.Visible = true;
                //DDLEstadoFF.Visible = true;
                //DDLEstadoFF.Enabled = true;
                //DDLEstadoFF.Items.Clear();
                //DDLEstadoFF.Items.Insert(0, new ListItem("Inicial", "Inicial", true));
                //DDLEstadoFF.Items.Insert(1, new ListItem("Final", "Final", true));
                //DDLEstadoFF.DataBind();
                //TxtPorcentaje.Visible = false;
                //LblFechaFase.Text = "Fecha:";
                //LblValor1.Visible = false;
                //Panel1.Visible = false;
            }
            else 
            {
                if (DDLFenologia.SelectedItem.Text == "COSECHA Y ACOPIO")
                {
                    //DDLEstadoFF.Enabled = false;
                    //DDLEstadoFF.Visible = true;
                    //DDLEstadoFF.Items.Insert(0, new ListItem("Avance", "Avance", true));
                    //Panel1.Visible=true;
                    //TxtFechaFase.Visible = false;
                    //TxtPorcentaje.Visible = true;
                    //Seleccionar_VALORES_COSECHA();
                }
                else
                {
                    //DDLEstadoFF.Enabled = false;
                    //DDLEstadoFF.Visible = true;
                    //DDLEstadoFF.Items.Insert(0, new ListItem("Avance", "Avance", true));
                    //DDLEstadoFF.DataBind();
                    //DDLEstadoFF.ClearSelection();
                    //TxtFechaFase.Visible = false;
                    //LblFechaFase.Text = "Etapa:";
                    //TxtPorcentaje.Visible = true;
                    //TxtFechaFase.Visible = false;
                    //LblValor1.Visible = true;
                    //Panel1.Visible = false;
                }

            }
            Calcularar_AVANCE_SIEMBRA();
            //Calcularar_PORCENTAJE_FENOLOGIA();
        }
        #endregion
        #region CALCULAR EL AVANCE DE SIEMBRA DEL CULTIVO
        private void Calcularar_AVANCE_SIEMBRA()
        {
            DB_EXT_Rendimiento avsiem = new DB_EXT_Rendimiento();
            DataTable dt = new DataTable();
            dt = avsiem.DB_Reporte_DETALLE_PLANILLA(Convert.ToInt32(DDLFenologia.SelectedValue), LblIdInsProd.Text, DDLEstadoFF.SelectedValue, "INSUMO_ANAVCE_SIEM");
            TxtPorcentaje.Text = dt.Rows[0][0].ToString();
            if (Convert.ToDecimal(dt.Rows[0][0].ToString()) == 100)
            {
                TxtPorcentaje.Enabled = false;
            }
            else
            {
                TxtPorcentaje.Enabled = true;
            }
            //if (DDLFenologia.SelectedItem.Text == "FECHA Y AVANCE DE SIEMBRA")
            //{
            //   // LblAvanSiem.Text = dt.Rows[0][0].ToString();
            //    if (Convert.ToDecimal(dt.Rows[0][0].ToString()) == 100)
            //    {
            //        TxtPorcentaje.Enabled = false;
            //    }
            //    else
            //    {
            //        TxtPorcentaje.Enabled = true;
            //    }
            //}
            //else
            //{
            //    TxtPorcentaje.Enabled = true;
            //}
        }
        /*****************************/
        private void Calcularar_AVANCE_SIEMBRA_CULTIVO()
        {
            DB_EXT_Rendimiento avsiem = new DB_EXT_Rendimiento();
            DataTable dt = new DataTable();
            dt = avsiem.DB_Reporte_DETALLE_PLANILLA_CULTIVO(LblIdInsProd.Text, "ANAVCE_SIEM");
            //LblAvanSiem.Text = dt.Rows[0][0].ToString();
        }
        #endregion
        #region CALCULO DE PORCENTAJES DE LA FACE FENOLOGICA
        private void Calcularar_PORCENTAJE_FENOLOGIA()
        {
            DB_EXT_Rendimiento avsiem = new DB_EXT_Rendimiento();
            DataTable dt = new DataTable();
            //dt = avsiem.DB_Reporte_DETALLE_PLANILLA(Convert.ToInt32(DDLFenologia.SelectedValue), LblIdInsProd.Text, DDLEstadoFF.SelectedValue, "INSUMO_ANAVCE_SIEM");
            TxtPorcentaje.Text = dt.Rows[0][0].ToString();
            //LblPorcentaje.Text = dt.Rows[0][0].ToString();
        }
        #endregion

        #region ""
        private void RECUPERAR_REGISTRO_CULTIVO()
        {
            DB_EXT_Seguimiento avsiem = new DB_EXT_Seguimiento();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            //dt = avsiem.DB_RECUPERAR_REGISTRO_CULTIVO(LblIdInsProd.Text, LblId_Etapa.Text);
            //if (dt.Rows.Count == 0)
            //{
            //    dt = avsiem.DB_RECUPERAR_REGISTRO_CULTIVO(LblIdInsProd.Text, "VERIFICACION_CULTIVO");
            //}  
            dt1 = avsiem.DB_RECUPERAR_REGISTRO_CULTIVO(LblIdInsProd.Text, LblId_Etapa.Text);
            dt2 = avsiem.DB_RECUPERAR_REGISTRO_CULTIVO(LblIdInsProd.Text, "VERIFICACION_CULTIVO");
            dt3 = dt1.Clone();
            foreach (DataRow dr in dt2.Rows)
            {
                dt3.ImportRow(dr);
            }
            foreach(DataRow dr in dt1.Rows )
            {
                dt3.ImportRow(dr);
            }
            if (dt3.Rows.Count > 0)
            {
                DataView dv = dt3.DefaultView;
                dv.Sort = "[Id_Seguimiento_Parcela] ASC";               
                dt3 = dv.ToTable();
            }
            //dt3.DefaultView.Sort = "Id_Seguimiento_Parcela ASC";
            //completar
            //dt.Columns.Add(new DataColumn("Id_Fenologia", typeof(int)));
            //dt.Columns.Add(new DataColumn("Fenologia", typeof(string)));
            //dt.Columns.Add(new DataColumn("EstadoFF", typeof(string)));
            //dt.Columns.Add(new DataColumn("Porcentaje", typeof(int)));
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
            ColSeguimientoCultivo = ColSC;
            GVSegCultivo.DataSource = dtTable;
            GVSegCultivo.DataBind();
            
            
            
        }
        #endregion

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
                //
                int pos_ultimo_val = GVSegCultivo.Rows.Count;
                int val_ultima_pos = Convert.ToInt16(GVSegCultivo.Rows[pos_ultimo_val - 1].Cells[5].Text);
                if (val_ultima_pos != 0)
                {
                    LblMsj5.Text = "Necesita registrar los datos del cultivo para continuar";
                    return;
                }
                else
                {
                    Registrar_SEGUIMIENTO();
                    Response.Redirect("frmListaSeguimiento.aspx", true);
                }
                //
                
                //if (DDLFenologia.SelectedItem.Text == "FECHA Y AVANCE DE SIEMBRA")
                //{
                //    LblMsj5.Text = string.Empty;
                //    Registrar_SEGUIMIENTO();
                //    Response.Redirect("frmSeguimientoTecnico.aspx");
                //}
                //else
                //{
                //    if (DDLFenologia.SelectedItem.Text == "COSECHA Y ACOPIO")
                //    {
                //        LblMsj5.Text = string.Empty;
                //        Registrar_SEGUIMIENTO();
                //        Response.Redirect("frmSeguimientoTecnico.aspx");

                //    }
                //    else
                //    {
                //        if (DDLFenologia.SelectedItem.Text == "FECHA COSECHA PROBABLE")
                //        {
                //            LblMsj5.Text = string.Empty;
                //            Registrar_SEGUIMIENTO();
                //            Response.Redirect("frmSeguimientoTecnico.aspx");
                //        }
                //        else
                //        {
                //            //if (LblCont.Text == LblAvanSiem.Text)
                //            //{
                //            //    LblMsj5.Text = string.Empty;
                //            //    Registrar_SEGUIMIENTO();
                //            //    Response.Redirect("frmSeguimientoTecnico.aspx");
                //            //}
                //            //else
                //            //{
                //            //    LblMsj5.Text = "el porcentaje de las Fases de fenologia deben cuadrar con el avance de siembra que se declaro";
                //            //} 
                //        }
                //    }
                //}
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
            //seg.Etapa = LblEtapa.Text; //LR
            seg.Etapa = LblId_Etapa.Text;
            //if (LblEtapa.Text == "VERIFICACION_PARCELA")
            if (LblId_Etapa.Text == "1")//"VERIFICACION_PARCELA")
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
                    //DataTable dt = Session["datos"] as DataTable;
                    int id = 0;
                    id = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO_PARCELA", "Id_Seguimiento_Parcela"));
                    if (GVSegCultivo.Rows.Count > 0)
                    {
                        foreach (GridViewRow dgi in GVSegCultivo.Rows)
                        {
                            if (dgi.Cells[5].Text == "0")
                            {
                                sc.Id_Seguimiento_Parcela = id;
                                sc.Id_Fenologia = Convert.ToInt16(GVSegCultivo.Rows[dgi.RowIndex].Cells[0].Text);
                                sc.Estado = GVSegCultivo.Rows[dgi.RowIndex].Cells[2].Text;
                                sc.Porcentaje_FF = Convert.ToInt16(GVSegCultivo.Rows[dgi.RowIndex].Cells[3].Text);
                                sc.Fecha_Cosecha = Convert.ToDateTime(TxtFecha.Text);
                                insSeg.DB_Registrar_SEGUIMIENTO_CULTIVO(sc);     
                            }
                                                                                  
                        }
                    }
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{         
                    //    sc.Id_Seguimiento_Parcela = id;
                    //    sc.Id_Fenologia = Convert.ToInt32(dt.Rows[i][0].ToString());
                    //    sc.Estado = dt.Rows[i][2].ToString();
                    //    if (dt.Rows[i][1].ToString() == "FECHA COSECHA PROBABLE")
                    //    {
                    //        sc.Porcentaje_FF = 0;
                    //        sc.Fecha_Cosecha = Convert.ToDateTime(dt.Rows[i][4].ToString());
                    //    }
                    //    else
                    //    {
                    //        sc.Porcentaje_FF = Convert.ToInt32(dt.Rows[i][3].ToString());
                    //        sc.Fecha_Cosecha = Convert.ToDateTime("01/01/1900");
                    //    }
                    //    insSeg.DB_Registrar_SEGUIMIENTO_CULTIVO(sc);
                    //    //estadoprod.DB_Cambiar_ESTADO(LblIdInsProd.Text, "VERIFICACION_CULTIVO"); //LR
                    //    estadoprod.DB_Cambiar_ESTADO(LblIdInsProd.Text, "");
                    //}
                    if (LblEtapa.Text == "VERIFICACION_COSECHA")
                    {
                        //EXT_SeguimientoCosecha cos = new EXT_SeguimientoCosecha();
                        //cos.Id_Seguimiento_Parcela = id;
                        //cos.Rendimiento = Convert.ToDecimal(TxtRedimiento.Text);
                        //cos.Sup_Sembrada = Convert.ToDecimal(TxtSupSiem.Text);
                        //cos.Peso_Aproximado = Convert.ToDecimal(TxtPesoApro.Text);
                        //cos.Fecha_Siembra = Convert.ToDateTime(TxtFechSiem.Text);
                        //cos.Placa_Camion = TxtPlacaCam.Text;
                        //cos.Nom_Chofer=TxtNomChofer.Text;
                        //cos.Centro_Acopio = TxtCentroAco.Text;
                        //cos.Region = "";
                        //insSeg.DB_Registrar_DATOS_COSECHA(cos);
                    }
                    if (GVAdversidad.Rows.Count > 0)
                    {
                        foreach (GridViewRow dgi in GVAdversidad.Rows)
                        {
                            ad.Id_Seguimiento_Parcela = id;
                            if(GVAdversidad.Rows[dgi.RowIndex].Cells[0].Text != string.Empty)
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
                                adpme.Tratamiento = HttpUtility.HtmlDecode(GV_PlagaMaEnf.Rows[dgi.RowIndex].Cells[3].Text);
                                adpme.Porcentage = 0;//no se ingresa en sp
                                DateTime fecha = DateTime.Now;
                                adpme.Fecha_Ocurrencia = fecha; //no se ingresa en sp
                                insSeg.DB_Registrar_ADVESIDAD_PME(adpme);
                            }
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
        #region FUNCION DE LIMPIAR CAMPOS
        private void Limpiar_CAMPOS_ADVERSIDAD()
        {
            txt_Observacion.Text = string.Empty;
            TxtIntencidad.Text = "0";
            txt_fecha_adversidad.Text = string.Empty;
            Calendar1.Visible = false;
            DDLIntensidad.DataBind();
            DDLAdversidad.SelectedIndex = 0;
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
        #region REGISTRAR EN LA GRILLA LOS VALORES DEL SEGUIMIENTO
        protected void Registrar_COSECHAPROBABLE()
        {
            /*********************************************************************/
            // if(TxtFechaFase.Text!="")
            // {
             //    LblMsj5.Text = string.Empty;
             //    DataTable dt = Session["datos"] as DataTable;
             //    DataRow row = dt.NewRow();
             //    row["Id_Fenologia"] = DDLFenologia.SelectedValue;
             //    row["FaceFenologica"] = DDLFenologia.SelectedItem.Text;
             //    row["EstadoFF"] = DDLEstadoFF.SelectedValue;
             //    row["Porcentaje"] = TxtPorcentaje.Text;
             //    row["Fecha_Cosecha"] = TxtFechaFase.Text;
             //    dt.Rows.Add(row);
             //    GVSegCultivo.DataSource = dt;
             //    GVSegCultivo.DataBind();
             //    Session["datos"] = dt;
             //    TxtFechaFase.Text = string.Empty;
             //    /*************/
             //    if (DDLEstadoFF.SelectedItem.Text == "Final")
             //    {
             //        BtnEnviar.Enabled = true;
             //        BtnRegistrar.Enabled = false;
             //    }
             //    else
             //    {
             //        DDLEstadoFF.Items.Clear();
             //        DDLEstadoFF.Items.Insert(0, new ListItem("Final", "Final", true));
             //        DDLEstadoFF.DataBind();
             //    }
            // }
            // else
            // {
             //    Response.Write("<script>window.alert('Necesita especificar la fecha');</script>");
            // }

        }
        /*************************************/
        protected void Registrar_AVANCE_DE_SIEMBRA()
        {
            if (Convert.ToInt32(TxtPorcentaje.Text) <= 100)
            {
               // if (Convert.ToInt32(TxtPorcentaje.Text) > Convert.ToInt32(LblAvanSiem.Text))
               // {
                 //   if (TxtPorcentaje.Text != "")
                   // {
                       //LblMsj5.Text = string.Empty;
                       //DataTable dt = Session["datos"] as DataTable;
                       //DataRow row = dt.NewRow();
                       //row["Id_Fenologia"] = DDLFenologia.SelectedValue;
                       //row["FaceFenologica"] = DDLFenologia.SelectedItem.Text;
                       //row["EstadoFF"] = DDLEstadoFF.SelectedValue;
                       //row["Porcentaje"] = TxtPorcentaje.Text;
                       //row["Fecha_Cosecha"] = TxtFechaFase.Text;
                       //dt.Rows.Add(row);
                       //GVSegCultivo.DataSource = dt;
                       //GVSegCultivo.DataBind();
                       //Session["datos"] = dt;
                       //BtnEnviar.Enabled = true;
                       //BtnRegistrar.Enabled = false;
                       //Linpiar_CAMPOS();
              //      }
                //    else
                  //  {
                   //     LblMsj5.Text = "Error necesiata definir un porcentaje";
                    //}
               // }
               // else
               // {
                //    LblMsj5.Text = "El avance de siembra NO puede ser MENOR o IGUAL a lo declarado en la inspección anterior";
               // }
            }
            else
            {
                LblMsj5.Text = "No se puede registrar  el dato,  porque el avance de siembra ya se encuentra en el 100%";
            }
        }
        /*****************************************/
      //  protected int Validar_GRILLA()
       // {
            //int valor = 0;
            //foreach (GridViewRow dgi in GVSegCultivo.Rows)
            //{
            //    if (DDLFenologia.SelectedValue == GVSegCultivo.Rows[dgi.RowIndex].Cells[0].Text && DDLEstadoFF.SelectedValue == GVSegCultivo.Rows[dgi.RowIndex].Cells[2].Text)
            //    {
            //        valor = 1;
            //        break;
            //    }
            //}
            //return valor;
        //}

        //protected void Registrar_SEGUIMIENTO_AL_CULTIVO()
        //{
        //    if (TxtPorcentaje.Text != "")
        //    {
        //        if (Convert.ToInt32(TxtPorcentaje.Text) > 0)//&& Convert.ToInt32(TxtPorcentaje.Text) <= Convert.ToInt32(LblCont.Text))
        //        {
        //            LblCont.Text = (Convert.ToInt32(TxtPorcentaje.Text) + Convert.ToInt32(LblCont.Text)).ToString();
        //            if (Convert.ToInt32(LblCont.Text) <= Convert.ToInt32(LblAvanSiem.Text))
        //            {
        //                LblMsj5.Text = string.Empty;
        //                DataTable dt = Session["datos"] as DataTable;
        //                DataRow row = dt.NewRow();
        //                row["Id_Fenologia"] = DDLFenologia.SelectedValue;
        //                row["FaceFenologica"] = DDLFenologia.SelectedItem.Text;
        //                row["EstadoFF"] = DDLEstadoFF.SelectedValue;
        //                row["Porcentaje"] = TxtPorcentaje.Text;
        //                row["Fecha_Cosecha"] = TxtFechaFase.Text;
        //                dt.Rows.Add(row);
        //                GVSegCultivo.DataSource = dt;
        //                GVSegCultivo.DataBind();
        //                Session["datos"] = dt;
        //                Linpiar_CAMPOS();
        //                if (Convert.ToInt32(LblCont.Text) == Convert.ToInt32(LblAvanSiem.Text))
        //                {
        //                    BtnEnviar.Enabled = true;
        //                }
        //                if (DDLFenologia.SelectedItem.Text == "COSECHA Y ACOPIO")
        //                {
        //                    BtnRegistrar.Enabled = false;
        //                    DDLFenologia.Enabled = false;
        //                    BtnEnviar.Enabled = true;
        //                    Panel1.Enabled = false;
        //                }
        //            }
        //            else
        //            {
        //                LblMsj5.Text = "El Grado de porcentaje de la fenología no puede ser 0, se requiere que presente una variación para continuar";
        //            }
        //        }
        //        else
        //        {
        //            LblCont.Text = (Convert.ToInt32(TxtPorcentaje.Text) + Convert.ToInt32(LblCont.Text)).ToString();
        //            if (Convert.ToInt32(LblCont.Text) <= Convert.ToInt32(LblAvanSiem.Text))
        //            {
        //                LblMsj5.Text = string.Empty;
        //                DataTable dt = Session["datos"] as DataTable;
        //                DataRow row = dt.NewRow();
        //                row["Id_Fenologia"] = DDLFenologia.SelectedValue;
        //                row["FaceFenologica"] = DDLFenologia.SelectedItem.Text;
        //                row["EstadoFF"] = DDLEstadoFF.SelectedValue;
        //                row["Porcentaje"] = TxtPorcentaje.Text;
        //                row["Fecha_Cosecha"] = TxtFechaFase.Text;
        //                dt.Rows.Add(row);
        //                GVSegCultivo.DataSource = dt;
        //                GVSegCultivo.DataBind();
        //                Session["datos"] = dt;
        //                Linpiar_CAMPOS();
        //                if (Convert.ToInt32(LblCont.Text) == Convert.ToInt32(LblAvanSiem.Text))
        //                {
        //                    BtnEnviar.Enabled = true;
        //                }
        //                if (DDLFenologia.SelectedItem.Text == "COSECHA Y ACOPIO")
        //                {
        //                    BtnRegistrar.Enabled = false;
        //                    DDLFenologia.Enabled = false;
        //                }
        //            }
        //            else
        //            {
        //                LblCont.Text = (Convert.ToInt32(LblCont.Text) - Convert.ToInt32(TxtPorcentaje.Text)).ToString();
        //                LblMsj5.Text = "No se puede registar, la siembra esta en un: " + LblAvanSiem.Text + "%";
        //            }
        //        }
        //    }
        //    else
        //    {
        //        LblMsj5.Text = "Error necesiata definir un porcentaje";
        //    }




        //}
        /****************************************/
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {

        }
        #endregion

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
                    GV_PlagaMaEnf.DataSource = null;
                    GV_PlagaMaEnf.DataBind();
                }
                else
                {
                    string script = @"<script type='text/javascript'>alert('{0}');</script>";
                    script = string.Format(script, "EXISTEN DATOS REGISTRADOS..!");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }

            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txt_fecha_adversidad.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
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
                    //drRow["Detalle"] = txt_Plagas.Text.Trim(); //  HttpUtility.HtmlDecode(((TextBox)row.FindControl("txtTratamiento")).Text);
                    drRow["Detalle"] = HttpUtility.HtmlDecode(txt_Plagas.Text.Trim());
                    drRow["Intensidad"] = DDLIntensidad_Plaga.SelectedValue.ToString();
                    drRow["Tratamiento"] = HttpUtility.HtmlDecode(txt_Tratamiento_Plagas.Text.Trim()); 

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
                    drRow["Detalle"] = HttpUtility.HtmlDecode(txt_Malezas.Text.Trim()); 
                    drRow["Intensidad"] = DDLIntensidad_Maleza.SelectedValue.ToString();
                    drRow["Tratamiento"] = HttpUtility.HtmlDecode(txt_Tratamiento_Malezas.Text.Trim()); 

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
                    drRow["Detalle"] = HttpUtility.HtmlDecode(txt_Enfermedades.Text.Trim()); 
                    drRow["Intensidad"] = DDLIntensidad_Enfermedad.SelectedValue.ToString();
                    drRow["Tratamiento"] = HttpUtility.HtmlDecode(txt_Tratamiento_Enfermedades.Text.Trim()); 

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

        protected void DDLIntensidad_Plaga_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLIntensidad_Maleza_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLIntensidad_Enfermedad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TxtPorcentaje_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GVAdversidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLAdversidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

       
    }
}