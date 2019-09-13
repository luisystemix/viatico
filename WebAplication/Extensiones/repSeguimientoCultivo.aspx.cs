using DataBusiness.DB_Extensiones;
using DataBusiness.DB_General;
using DataBusiness.DB_Registro;
using DataEntity.DE_Extensiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebAplication.Extensiones
{
    public partial class repSeguimientoCultivo : System.Web.UI.Page
    {
        /// <summary>
        /// flag para saber si se realizo correctamente los promedios
        /// </summary>
        private bool CalculoCorrecto
        {
            get
            {
                if (ViewState["CalculoCorrecto"] != null)
                    return (bool)ViewState["CalculoCorrecto"];

                return false;
            }
            set { ViewState["CalculoCorrecto"] = value; }
        }
        /// <summary>
        /// Verificacion rango de fechas por usuario
        /// </summary>
        private bool ValidacionRangoFechas
        {
            get
            {
                if (ViewState["ValidacionRangoFechas"] != null)
                    return (bool)ViewState["ValidacionRangoFechas"];

                return false;
            }
            set { ViewState["ValidacionRangoFechas"] = value; }
        }
        /// <summary>
        /// Verifica si las fechas del reporte exportado se encuentraregistrado en la BD
        /// </summary>
        private bool ValidadcionExportar
        {
            get
            {
                if (ViewState["ValidadcionExportar"] != null)
                    return (bool)ViewState["ValidadcionExportar"];

                return false;
            }
            set { ViewState["ValidadcionExportar"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
         {
            try
            {
                if (Session["IdUsuario"] == null)
                { Response.Redirect("~/About.aspx"); }

                if (!IsPostBack)
                {
                    //LblNum.Text = Session["IdSeguimiento"].ToString();
                    //LblEtapa.Text = Session["Etapa"].ToString();
                    //LblIdInsProd.Text = Session["IdInsProd"].ToString();
                    //*******                    
                    //LblIdInsOrg.Text = Session["IdInsOrganizacion"].ToString();
                    LblIdUsuario.Text = Session["IdUsuario"].ToString();
                    LblPrograma.Text = Session["ProgramaSeleccionado"].ToString();
                    Llenar_GVDESIGNADO();
                    btCalcularPromedio_Click(sender, e);
                }
                lblmensaje.Text = string.Empty;
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        private void Llenar_GVDESIGNADO()//1 ListaSegOrg
        {
            try
            {
                DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
                DataTable dt = new DataTable();
                dt = Usuario.DB_Desplegar_USUARIO(LblIdUsuario.Text);
                LblReg.Text = dt.Rows[0][5].ToString();
                LblIdReg.Text = dt.Rows[0][4].ToString();
                DB_AP_Campanhia camp = new DB_AP_Campanhia();
                dt = camp.DB_Seleccionar_CAMPANHIA_REG_NOFIN(dt.Rows[0][10].ToString());
                LblCamp.Text = dt.Rows[0][1].ToString();
                LblIdCamp.Text = dt.Rows[0][0].ToString();

                DB_AdminUser User = new DB_AdminUser();               
                DataTable dtuser = User.DB_Desplegar_USUARIO(LblIdUsuario.Text);
                txtNombreUsuario.Text = dtuser.Rows[0][1].ToString();

                //DB_AP_Registro_Org d_org = new DB_AP_Registro_Org();
                //DataTable dt = new DataTable();
                //dt = d_org.DB_Desplegar_ENCABEZADO_ORG(Convert.ToInt32(LblIdInsOrg.Text));
                //LblOrg.Text = dt.Rows[0][2].ToString();
                //LblIdCamp.Text = dt.Rows[0][5].ToString();
                //LblCamp.Text = dt.Rows[0][6].ToString();
                //LblIdReg.Text = dt.Rows[0][7].ToString();
                //LblReg.Text = dt.Rows[0][8].ToString();
                //LblPrograma.Text = dt.Rows[0][9].ToString();    @IdInsOrg


                DB_EXT_DesignacionOrg ListDesOrg = new DB_EXT_DesignacionOrg();
                DB_EXT_Seguimiento ListSeg = new DB_EXT_Seguimiento();
                DataTable DTListaSegOrg = new DataTable();
                DTListaSegOrg = ListDesOrg.DB_Seleccionar_DESIGNACION_ORG(Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblIdCamp.Text), LblIdUsuario.Text, LblPrograma.Text, "LISTASIGNADOS");
                DataTable DTSeguimientoCultivo = new DataTable();
                DTSeguimientoCultivo.Columns.Add("Zona");
                DTSeguimientoCultivo.Columns.Add("Organizacion");
                DTSeguimientoCultivo.Columns.Add("Ppsemanal");
                DTSeguimientoCultivo.Columns.Add("FechaSiembraInicio");
                DTSeguimientoCultivo.Columns.Add("FechaSiembraFinal");
                DTSeguimientoCultivo.Columns.Add("AvanceSiembra");
                DTSeguimientoCultivo.Columns.Add("Germinacion");
                DTSeguimientoCultivo.Columns.Add("Plantula");
                DTSeguimientoCultivo.Columns.Add("Macollamiento");
                DTSeguimientoCultivo.Columns.Add("Embuche");
                DTSeguimientoCultivo.Columns.Add("Espigazon");
                DTSeguimientoCultivo.Columns.Add("Floracion");
                DTSeguimientoCultivo.Columns.Add("Grano");
                DTSeguimientoCultivo.Columns.Add("Maduracion");
                DTSeguimientoCultivo.Columns.Add("AvanceCosecha");
                DTSeguimientoCultivo.Columns.Add("Rend");
                DTSeguimientoCultivo.Columns.Add("FechaCosechaInicial");
                DTSeguimientoCultivo.Columns.Add("FechaCosechaFinal");
                DTSeguimientoCultivo.Columns.Add("Observaciones");
                foreach (DataRow row in DTListaSegOrg.Rows)
                {
                    string IdInsOrg = row["Id_InscripcionOrg"].ToString();
                    //CONCULTAMOS MUNICIPIO DE ORGANIZACION
                    DataTable DTMunicipio = new DataTable();                    
                    DTMunicipio = ListSeg.DB_EXT_CONSULTAR_NOMBRE_MUNICIPIO(Convert.ToInt16(IdInsOrg));
                    DataRow fila = DTSeguimientoCultivo.NewRow();
                    foreach (DataRow rowmun in DTMunicipio.Rows)
                    {
                        fila["Zona"] = rowmun["Nombre"].ToString();
                    }
                    fila["Organizacion"] = row["Personeria_Juridica"].ToString();
                    fila["Ppsemanal"] = string.Empty;   
                    DataTable DTListaSegParcela = new DataTable();
                    DataTable DTListaSegCultivo = new DataTable();
                    DataTable DTListaSegSiembra = new DataTable();
                    DataTable DTListaSegAdversidadPresentadas = new DataTable();
                    DataTable DTListaSegAdversidadPresentadadPME = new DataTable();
                    
                    IList<EXT_SeguimientoParcela> ColSParcela = new List<EXT_SeguimientoParcela>();
                    IList<EXT_SeguimientoCultivo> ColSCultivo = new List<EXT_SeguimientoCultivo>();
                    IList<EXT_SeguimientoSiembra> ColSiembra = new List<EXT_SeguimientoSiembra>();
                    IList<EXT_AdversidadPresentada> ColAdPresentada = new List<EXT_AdversidadPresentada>();
                    IList<EXT_AdversidadPresentada> ColAdPresentadaPME = new List<EXT_AdversidadPresentada>();
                    
                    //DTListaSegParcela = ListSeg.DB_CONSULTAR_EXT_SEGUIMIENTO_PARCELA(2, Convert.ToInt16(IdInsOrg));
                    //foreach (DataRow rowP in DTListaSegParcela.Rows)
                    //{
                    //    EXT_SeguimientoParcela ObjSP = new EXT_SeguimientoParcela();
                    //    ObjSP.Id_Seguimiento_Parcela = Convert.ToInt16(rowP["Id_Seguimiento_Parcela"].ToString());
                    //    ObjSP.Id_Seguimiento = Convert.ToInt16(rowP["Id_Seguimiento"].ToString());
                    //    ObjSP.Boleta_Numero = Convert.ToInt16(rowP["Boleta_Numero"].ToString());
                    //    ObjSP.Fecha_Seg = Convert.ToDateTime(rowP["Fecha_Seg"].ToString());
                    //    ColSParcela.Add(ObjSP);
                    //}
                    //string fechaSiembraInicio = ColSParcela.OrderBy(x => x.Fecha_Seg).FirstOrDefault().ToString();
                    //fila["FechaSiembraInicio"] = fechaSiembraInicio;
                    //string fechaSiembraFinal = ColSParcela.OrderByDescending(x => x.Fecha_Seg).FirstOrDefault().ToString();
                    //fila["FechaSiembraFinal"] = fechaSiembraFinal;

                    //PRODUCTORES SELECCIONADOS 
                    //DataTable DTDesProd = new DataTable();
                    //DB_EXT_DesignacionProd ListDes = new DB_EXT_DesignacionProd();
                    //DTDesProd = ListDes.DB_Desplegar_DESIGNACION_PROD(LblIdUsuario.Text, Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), LblPrograma.Text, Convert.ToInt32(IdInsOrg), "LIST_SELECCION");
                    
                    //SIEMBRA
                    DTListaSegSiembra = ListSeg.DB_CONSULTAR_EXT_SEGUIMIENTO_SIEMBRA(2, Convert.ToInt16(IdInsOrg),LblIdUsuario.Text);
                    foreach (DataRow rowSS in DTListaSegSiembra.Rows)
                    {
                        EXT_SeguimientoSiembra ObjSS = new EXT_SeguimientoSiembra();
                        ObjSS.Id_Seguimiento_Parcela = Convert.ToInt16(rowSS["Id_Seguimiento_Parcela"].ToString());
                        ObjSS.Fecha_SiembraINI = Convert.ToDateTime(rowSS["Fecha_SiembraINI"].ToString());
                        ObjSS.Fecha_SiembraFIN = Convert.ToDateTime(rowSS["Fecha_SiembraFIN"].ToString());
                        ObjSS.Avance_Siembra = Convert.ToInt16(rowSS["Avance_Siembra"].ToString());
                        ColSiembra.Add(ObjSS);
                    }
                    decimal avanceSiembra = Convert.ToDecimal("0");
                    if (ColSiembra.Count != 0)
                    {
                        IList<EXT_SeguimientoSiembra> ColSiembraAux = new List<EXT_SeguimientoSiembra>();
                        //ColSiembraAux = ColSiembra.Where(x => x.Fecha_SiembraINI >= Convert.ToDateTime(TxtFecha1.Text) && x.Fecha_SiembraFIN <= Convert.ToDateTime(TxtFecha2.Text)).ToList();
                        ColSiembraAux = ColSiembra;
                        if (ColSiembraAux.Count != 0)
                        {
                            string fechaSiembraInicio = ColSiembraAux.OrderBy(x => x.Fecha_SiembraINI).FirstOrDefault().Fecha_SiembraINI.ToShortDateString();
                            if (fechaSiembraInicio != string.Empty)
                                fila["FechaSiembraInicio"] = fechaSiembraInicio;
                            else
                                fila["FechaSiembraInicio"] = DateTime.Now.ToShortDateString();

                            string fechaSiembraFinal = ColSiembraAux.OrderByDescending(x => x.Fecha_SiembraFIN).FirstOrDefault().Fecha_SiembraINI.ToShortDateString();
                            if (fechaSiembraFinal != string.Empty)
                                fila["FechaSiembraFinal"] = fechaSiembraFinal;
                            else
                                fila["FechaSiembraFinal"] = DateTime.Now.ToShortDateString();

                            avanceSiembra = ColSiembraAux.Sum(x => x.Avance_Siembra) / ColSiembra.Count;
                            fila["AvanceSiembra"] = avanceSiembra.ToString();
                        }
                        else
                        {
                            fila["FechaSiembraInicio"] = DateTime.Now.ToShortDateString();
                            fila["FechaSiembraFinal"] = DateTime.Now.ToShortDateString();
                            fila["AvanceSiembra"] = avanceSiembra.ToString(); 
                        }
                        
                    }
                    else
                    {
                        fila["FechaSiembraInicio"] = DateTime.Now.ToShortDateString();
                        fila["FechaSiembraFinal"] = DateTime.Now.ToShortDateString();
                        fila["AvanceSiembra"] = avanceSiembra.ToString(); 
                    }        
                    //siempre es 100 al momento de seleccinar, en esta tabla es editable pero se controla 
                    //que la sumatoria sea de 100% AvanceCosecha
                    fila["Germinacion"] = "0";
                    fila["Plantula"] = "0";
                    fila["Macollamiento"] = "0";
                    fila["Embuche"] = "0";
                    fila["Espigazon"] = "0";
                    fila["Floracion"] = "0";
                    fila["Grano"] = "0";
                    fila["Maduracion"] = "0";
                    fila["AvanceCosecha"] = "0";
                    decimal valor = Convert.ToDecimal("0");
                    fila["Rend"] = valor.ToString();   
                    
                    //SIEMBRA  Y CULTIVO
                    DTListaSegCultivo = ListSeg.DB_CONSULTAR_EXT_SEGUIMIENTO_CULTIVO(Convert.ToInt16(IdInsOrg), LblIdUsuario.Text);
                    foreach (DataRow rowSC in DTListaSegCultivo.Rows)
                    {
                        EXT_SeguimientoCultivo ObjSC = new EXT_SeguimientoCultivo();
                        ObjSC.Id_Seguimiento_Parcela = Convert.ToInt16(rowSC["Id_Seguimiento_Parcela"].ToString());
                        ObjSC.Id_Fenologia = Convert.ToInt16(rowSC["Id_Fenologia"].ToString());
                        ObjSC.Estado = rowSC["Estado"].ToString();
                        ObjSC.Porcentaje_FF = Convert.ToInt16(rowSC["Porcentaje_FF"].ToString());
                        ObjSC.Fecha_Cosecha = Convert.ToDateTime(rowSC["Fecha_Cosecha"].ToString());
                        ColSCultivo.Add(ObjSC);
                    }
                    if (ColSCultivo.Count != 0)
                    {
                        IList<EXT_SeguimientoCultivo> ColCultivoAux = new List<EXT_SeguimientoCultivo>();
                        //ColCultivoAux = ColSCultivo.Where(x => x.Fecha_Cosecha >= Convert.ToDateTime(TxtFecha1.Text) && x.Fecha_Cosecha <= Convert.ToDateTime(TxtFecha2.Text)).ToList();
                        ColCultivoAux = ColSCultivo;
                        if (ColCultivoAux.Count != 0)
                        {
                            string fechaCosechaInicial = ColCultivoAux.OrderBy(x => x.Fecha_Cosecha).FirstOrDefault().Fecha_Cosecha.ToShortDateString();
                            if (fechaCosechaInicial != string.Empty)
                                fila["FechaCosechaInicial"] = fechaCosechaInicial;
                            else
                                fila["FechaCosechaInicial"] = DateTime.Now.ToShortDateString();

                            string fechaCosechaFinal = ColCultivoAux.OrderByDescending(x => x.Fecha_Cosecha).FirstOrDefault().Fecha_Cosecha.ToShortDateString();
                            if (fechaCosechaFinal != string.Empty)
                                fila["FechaCosechaFinal"] = fechaCosechaInicial;
                            else
                                fila["FechaCosechaFinal"] = DateTime.Now.ToShortDateString();
                        }
                        else
                        {
                            fila["FechaCosechaInicial"] = DateTime.Now.ToShortDateString();
                            fila["FechaCosechaFinal"] = DateTime.Now.ToShortDateString();
                        }
                        
                    }
                    else
                    {
                        fila["FechaCosechaInicial"] = DateTime.Now.ToShortDateString();
                        fila["FechaCosechaFinal"] = DateTime.Now.ToShortDateString();    
                    }
                    
                 
                    //ADVERSIDAD PRESENTADA (viento, nevadad,...)
                    string Observaciones = string.Empty;
                    string T1 = "ADVERSIDADES_PRESENTADAS_SIEMBRA:";
                    DTListaSegAdversidadPresentadas = ListSeg.DB_CONSULTAR_EXT_ADVERSIDAD_PRESENTADA(2, Convert.ToInt16(IdInsOrg), LblIdUsuario.Text);//2 SIEMBRA                    
                    Observaciones += T1;
                    foreach (DataRow rowAP in DTListaSegAdversidadPresentadas.Rows)
                    {
                        string remplazo = string.Empty;
                        string tratamiento = rowAP["Tratamiento"].ToString();                        
                        if(tratamiento != string.Empty)
                            remplazo = RemplazarCaracteres(tratamiento);
                        //Observaciones += rowAP["Descripcion"].ToString() + "(" + rowAP["Porcentage"].ToString() + ")" + " (Tratamiento)" + rowAP["Tratamiento"].ToString() + ", ";
                        Observaciones += rowAP["Descripcion"].ToString() + "(" + rowAP["Porcentage"].ToString() + "%)" + " (Tratamiento)" + remplazo + ", ";
                    }
                    string T1_1 = "ADVERSIDADES_PRESENTADAS_CULTIVO:";
                    DTListaSegAdversidadPresentadas = ListSeg.DB_CONSULTAR_EXT_ADVERSIDAD_PRESENTADA(3, Convert.ToInt16(IdInsOrg), LblIdUsuario.Text);//3 CULTIVO
                    Observaciones += T1_1;
                    foreach (DataRow rowAP in DTListaSegAdversidadPresentadas.Rows)
                    {
                        string remplazo = string.Empty;
                        string tratamiento = rowAP["Tratamiento"].ToString();
                        if(tratamiento != string.Empty)
                        remplazo = RemplazarCaracteres(tratamiento);
                        //Observaciones += rowAP["Descripcion"].ToString() + "(" + rowAP["Porcentage"].ToString() + ")" + " (Tratamiento)" + rowAP["Tratamiento"].ToString() + ", ";
                        Observaciones += rowAP["Descripcion"].ToString() + "(" + rowAP["Porcentage"].ToString() + "%)" + " (Tratamiento)" + remplazo + ", ";
                    }
                    //ADVERSIDAD PRESENTADA PME
                    string T2 = "ADVERSIDADES_PRESENTADAS(PLAGA,MALEZA,ENFERMEDADES)_SIEMBRA:";
                    Observaciones += T2;
                    DTListaSegAdversidadPresentadadPME = ListSeg.DB_CONSULTAR_EXT_ADVERSIDAD_PRESENTADA_PME(2, Convert.ToInt16(IdInsOrg), LblIdUsuario.Text);
                    foreach (DataRow rowAPPME in DTListaSegAdversidadPresentadadPME.Rows)
                    {
                        string remplazo = string.Empty;
                        string tratamiento = rowAPPME["Tratamiento"].ToString();
                        if(tratamiento != string.Empty)
                        remplazo = RemplazarCaracteres(tratamiento);
                        //Observaciones += rowAPPME["Descripcion"].ToString() + "Tratamiento" + rowAPPME["Tratamiento"].ToString() + ", ";
                        Observaciones += rowAPPME["Descripcion"].ToString() + "(Tratamiento)" + remplazo + ", ";
                    }
                    string T2_1 = "ADVERSIDADES_PRESENTADAS(PLAGA,MALEZA,ENFERMEDADES)_CULTIVO:";
                    Observaciones += T2_1;
                    DTListaSegAdversidadPresentadadPME = ListSeg.DB_CONSULTAR_EXT_ADVERSIDAD_PRESENTADA_PME(3, Convert.ToInt16(IdInsOrg), LblIdUsuario.Text);
                    foreach (DataRow rowAPPME in DTListaSegAdversidadPresentadadPME.Rows)
                    {
                        string remplazo = string.Empty;
                        string tratamiento = rowAPPME["Tratamiento"].ToString();
                        if(tratamiento != string.Empty)
                        remplazo = RemplazarCaracteres(tratamiento);
                        //Observaciones += rowAPPME["Descripcion"].ToString() + "Tratamiento" + rowAPPME["Tratamiento"].ToString() + ", ";
                        Observaciones += rowAPPME["Descripcion"].ToString() + "(Tratamiento)" + remplazo + ", ";
                    }

                    fila["Observaciones"] = Observaciones;
                    DTSeguimientoCultivo.Rows.Add(fila);
                   
                    //Llenar_GVDESIGNADO_2(IdInsOrg);
                }
                GVSeguimientoCultivo.DataSource = DTSeguimientoCultivo;
                GVSeguimientoCultivo.DataBind();
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            
            
        }
        //private void Llenar_GVDESIGNADO_2(string IdInsOrg) // 2 Seguimiento Tecnico
        //{
        //    DB_EXT_DesignacionProd ListDes = new DB_EXT_DesignacionProd();
        //    DataTable dt = new DataTable();
        //    //GVDesignado.DataSource = ListDes.DB_Desplegar_DESIGNACION_PROD(LblIdUsuario.Text, 0, 0, LblPrograma.Text, Convert.ToInt32(LblIdInsOrg.Text), "SEGDESIGNADOS");
        //    //******************************TRATAMIENTO PARA LAS ETAPAS
        //    DB_EXT_Seguimiento ListSegPendiente = new DB_EXT_Seguimiento();
        //    List<EXT_SeguimientoPendiente> LSP = ListSegPendiente.DB_Desplegar_SEGUIMIENTOS_PENDIENTE();
        //    //LSP[0].Nombre_Anterior             
        //    dt = ListDes.DB_Desplegar_DESIGNACION_PROD(LblIdUsuario.Text, 0, 0, LblPrograma.Text,Convert.ToInt32(IdInsOrg), "SEGDESIGNADOS");
        //    dt.Columns.Add("Id_Etapa", typeof(String));
        //    foreach (DataRow fila in dt.Rows)
        //    {
        //        int number1 = 0;
        //        string Etapa = fila["Etapa"].ToString();
        //        bool canConvert = int.TryParse(Etapa, out number1);
        //        if (canConvert == true)
        //        {
        //            foreach (EXT_SeguimientoPendiente row in LSP)
        //            {
        //                int id_sp = row.Id_Seguimiento_pendiente;
        //                int etapaobtenida = Convert.ToInt16(fila["Etapa"]);
        //                if (id_sp == etapaobtenida)
        //                {
        //                    fila["Etapa"] = row.Nombre;
        //                    fila["Id_Etapa"] = row.Id_Seguimiento_pendiente.ToString();
        //                    break;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            foreach (EXT_SeguimientoPendiente row in LSP)
        //            {
        //                string old_name = row.Nombre_Anterior;
        //                string etapaobtenida = fila["Etapa"].ToString();
        //                if (old_name == etapaobtenida)
        //                {
        //                    fila["Etapa"] = row.Nombre;
        //                    fila["Id_Etapa"] = row.Id_Seguimiento_pendiente.ToString();
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    //******************************
        //    //GVDesignado.DataSource = dt;
        //    //GVDesignado.DataBind();
        //    //if (GVDesignado.Rows.Count == 0)
        //    //{
        //    //    LblMsj1.Text = "No se seleccionó productores que formen parte de la muestra.";
        //    //}
        //    //else
        //    //{
        //    //    LblMsj1.Text = string.Empty;
        //    //}

        //}
        private void LenarVerificacionSiembraCultivo(string IdInsOrg)
        {

        }
        private void Llenar_GVSEGUIMIENTO()
        {
            //DB_EXT_Seguimiento ListSeg = new DB_EXT_Seguimiento();            
            ////******************************TRATAMIENTO PARA LAS ETAPAS
            //DB_EXT_Seguimiento ListSegPendiente = new DB_EXT_Seguimiento();
            //DataTable dt = new DataTable();
            //List<EXT_SeguimientoPendiente> LSP = ListSegPendiente.DB_Desplegar_SEGUIMIENTOS_PENDIENTE();
            //dt = ListSeg.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg.Text), LblIdInsProd.Text, "", "SEGUIMIENTO");
            //foreach (DataRow fila in dt.Rows)
            //{
            //    int number1 = 0;
            //    string Etapa = fila["Etapa"].ToString();
            //    bool canConvert = int.TryParse(Etapa, out number1);
            //    if (canConvert == true)
            //    {
            //        foreach (EXT_SeguimientoPendiente row in LSP)
            //        {
            //            int id_sp = row.Id_Seguimiento_pendiente;
            //            int etapaobtenida = Convert.ToInt16(fila["Etapa"]);
            //            if (id_sp == etapaobtenida)
            //            {
            //                fila["Etapa"] = row.Nombre;
            //                break;
            //                //fila["Id_Etapa"] = row.Id_Seguimiento_pendiente.ToString();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        foreach (EXT_SeguimientoPendiente row in LSP)
            //        {
            //            string old_name = row.Nombre_Anterior;
            //            string etapaobtenida = fila["Etapa"].ToString();
            //            if (old_name == etapaobtenida)
            //            {
            //                fila["Etapa"] = row.Nombre;
            //                break;
            //                //fila["Id_Etapa"] = row.Id_Seguimiento_pendiente.ToString();
            //            }
            //        }
            //    }
            //}
            //******************************
            //GVListaSeg.DataSource = dt;
            //GVListaSeg.DataBind();
        }

        protected void GVSeguimientoCultivo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //DTSeguimientoCultivo.Columns.Add("Zona");
            //DTSeguimientoCultivo.Columns.Add("Organizacion");
            //DTSeguimientoCultivo.Columns.Add("Ppsemanal");
            //DTSeguimientoCultivo.Columns.Add("FechaSiembraInicio");
            //DTSeguimientoCultivo.Columns.Add("FechaSiembraFinal");
            //DTSeguimientoCultivo.Columns.Add("AvanceSiembra");
            //DTSeguimientoCultivo.Columns.Add("Germinacion");
            //DTSeguimientoCultivo.Columns.Add("Plantula");
            //DTSeguimientoCultivo.Columns.Add("Macollamiento");
            //DTSeguimientoCultivo.Columns.Add("Embuche");
            //DTSeguimientoCultivo.Columns.Add("Espigazon");
            //DTSeguimientoCultivo.Columns.Add("Floracion");
            //DTSeguimientoCultivo.Columns.Add("Grano");
            //DTSeguimientoCultivo.Columns.Add("Maduracion");
            //DTSeguimientoCultivo.Columns.Add("AvanceCosecha");
            //DTSeguimientoCultivo.Columns.Add("Rend");
            //DTSeguimientoCultivo.Columns.Add("FechaCosechaInicial");
            //DTSeguimientoCultivo.Columns.Add("FechaCosechaFinal");
            //DTSeguimientoCultivo.Columns.Add("Observaciones");
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string zona = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Zona"));
                if (zona != string.Empty)
                {
                    ((TextBox)e.Row.FindControl("txtZona")).Text = zona;
                }
                string ppsemanal = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Ppsemanal"));
                if (ppsemanal != string.Empty)
                {
                    ((TextBox)e.Row.FindControl("txtPpsemanal")).Text = ppsemanal;
                }
                else
                {
                    ((TextBox)e.Row.FindControl("txtPpsemanal")).Text = string.Empty;
                }
                string fsinicio = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FechaSiembraInicio"));
                if (fsinicio != string.Empty)
                {
                    ((TextBox)e.Row.FindControl("txtFechaSiembraInicio")).Text = fsinicio;
                }
                string fsfin = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FechaSiembraFinal"));
                if (fsfin != "")
                {
                    ((TextBox)e.Row.FindControl("txtFechaSiembraFinal")).Text = fsfin;
                }
                string Avsiembra = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AvanceSiembra"));
                if (Avsiembra != "")
                {
                    ((TextBox)e.Row.FindControl("txtAvanceSiembra")).Text = Avsiembra;
                }

                string ger = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Germinacion"));
                if (ger != "")
                {
                    ((TextBox)e.Row.FindControl("txtGerminacion")).Text = ger;
                }
                string pantula = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Plantula"));
                if (pantula != "")
                {
                    ((TextBox)e.Row.FindControl("txtPlantula")).Text = pantula;
                }
                string mac = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Macollamiento"));
                if (mac!= "")
                {
                    ((TextBox)e.Row.FindControl("txtMacollamiento")).Text = mac;
                }
                string embuche = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Embuche"));
                if (embuche != "")
                {
                    ((TextBox)e.Row.FindControl("txtEmbuche")).Text = embuche;
                }
                //****
                string espi = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Espigazon"));
                if (espi != "")
                {
                    ((TextBox)e.Row.FindControl("txtEspigazon")).Text = espi;
                }
                string Floracion = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Floracion"));
                if (Floracion != "")
                {
                    ((TextBox)e.Row.FindControl("txtFloracion")).Text = Floracion;
                }
                string grano = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Grano"));
                if (grano != "")
                {
                    ((TextBox)e.Row.FindControl("txtGrano")).Text = grano;
                }
                string mad = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Maduracion"));
                if (mad != "")
                {
                    ((TextBox)e.Row.FindControl("txtMaduracion")).Text = mad;
                }
                string AvCosecha = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AvanceCosecha"));
                if (AvCosecha != "")
                {
                    ((TextBox)e.Row.FindControl("txtAvanceCosecha")).Text = AvCosecha;
                }
                string rend = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Rend"));
                if (rend != "")
                {
                    ((TextBox)e.Row.FindControl("txtRend")).Text = rend;
                }
                string fcinicio = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FechaCosechaInicial"));
                if (fcinicio != "")
                {
                    ((TextBox)e.Row.FindControl("txtFechaCosechaInicial")).Text = fcinicio;
                }
                string fcfin = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FechaCosechaFinal"));
                if (fcfin != "")
                {
                    ((TextBox)e.Row.FindControl("txtFechaCosechaFinal")).Text = fcfin;
                }
                string obs = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Observaciones"));
                if (obs != "")
                {
                    ((TextBox)e.Row.FindControl("txtObservaciones")).Text = obs;
                }
            }
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtFecha1.Text != string.Empty)
                {
                    if (TxtFecha2.Text != string.Empty)
                    {
                        Llenar_GVDESIGNADO();
                        btCalcularPromedio_Click(sender, e);
                    }
                    else
                    {
                        string script = @"<script type='text/javascript'>alert('{0}');</script>";
                        script = string.Format(script, "Ingrese Fecha Final");
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    }
                }
                else
                {
                    string script = @"<script type='text/javascript'>alert('{0}');</script>";
                    script = string.Format(script, "Ingrese Fecha Inicial");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
                
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            
        }
        private void Llenar_Promedios()
        {
            //decimal PromedioAvanceSiembra = Convert.ToDecimal("0");
            //decimal PromedioAvanceCosecha = Convert.ToDecimal("0");
            //decimal PromedioRend = Convert.ToDecimal("0");
            //try
            //{
            //    foreach (GridViewRow row in GVSeguimientoCultivo.Rows)
            //    {
            //        TextBox AvanceSiembra = (TextBox)row.FindControl("txtAvanceSiembra");
            //        PromedioAvanceSiembra += Convert.ToDecimal(AvanceSiembra.Text);
            //        // txtAvanceCosecha
            //        // txtRend
            //        TextBox AvanceCosecha = (TextBox)row.FindControl("txtAvanceCosecha");
            //        PromedioAvanceCosecha += Convert.ToDecimal(AvanceCosecha.Text);

            //        TextBox AvanceRend = (TextBox)row.FindControl("txtRend");
            //        PromedioRend += Convert.ToDecimal(AvanceRend.Text);

            //    }
            //    decimal TPSiembra = PromedioAvanceSiembra / GVSeguimientoCultivo.Rows.Count;
            //    txtPromedioSiembra.Text = TPSiembra.ToString();
            //    decimal TPCosecha = PromedioAvanceCosecha / GVSeguimientoCultivo.Rows.Count;
            //    txtPromedioCosecha.Text = TPCosecha.ToString();
            //    decimal TPRend = PromedioRend / GVSeguimientoCultivo.Rows.Count;
            //    txtPromedioRend.Text = TPRend.ToString();
            //}
            //catch(Exception ex)
            //{
            // string script = @"<script type='text/javascript'>alert('{0}');</script>";
            //        script = string.Format(script, ex.Message);
            //        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            //}
    
        }
         
        protected void btCalcularPromedio_Click(object sender, EventArgs e)
        {
            decimal PromedioAvanceSiembra = Convert.ToDecimal("0");
            decimal PromedioAvanceCosecha = Convert.ToDecimal("0");
            decimal PromedioRend = Convert.ToDecimal("0");
            CalculoCorrecto = false;
            try
            {
                foreach (GridViewRow row in GVSeguimientoCultivo.Rows)
                {
                    ////valida que no se PPSemanal no se vacio
                    //TextBox PpSemanal = (TextBox)row.FindControl("txtPpsemanal");
                    //PpSemanal.BorderColor = System.Drawing.Color.Empty;
                    //if (PpSemanal.Text == string.Empty)
                    //{
                    //    lblmensaje.Text = "Debe Registre Precipitación Semanal";
                    //    PpSemanal.BorderColor = System.Drawing.Color.PaleVioletRed;
                    //    return;
                    //}
                    //Avance de Cosecha
                    decimal TotalFenologia = Convert.ToDecimal("0");
                    TextBox Germinacion = (TextBox)row.FindControl("txtGerminacion");
                    TotalFenologia += Convert.ToDecimal(Germinacion.Text);
                    TextBox Plantula = (TextBox)row.FindControl("txtPlantula");
                    TotalFenologia += Convert.ToDecimal(Plantula.Text);
                    TextBox Macollamiento = (TextBox)row.FindControl("txtMacollamiento");
                    TotalFenologia += Convert.ToDecimal(Macollamiento.Text);
                    TextBox Embuche = (TextBox)row.FindControl("txtEmbuche");
                    TotalFenologia += Convert.ToDecimal(Embuche.Text);
                    TextBox Espigazon = (TextBox)row.FindControl("txtEspigazon");
                    TotalFenologia += Convert.ToDecimal(Espigazon.Text);
                    TextBox Floracion = (TextBox)row.FindControl("txtFloracion");
                    TotalFenologia += Convert.ToDecimal(Floracion.Text);
                    TextBox Grano = (TextBox)row.FindControl("txtGrano");
                    TotalFenologia += Convert.ToDecimal(Grano.Text);
                    TextBox Maduracion = (TextBox)row.FindControl("txtMaduracion");
                    TotalFenologia += Convert.ToDecimal(Maduracion.Text);
                    TextBox AvCosecha = (TextBox)row.FindControl("txtAvanceCosecha");
                    TotalFenologia += Convert.ToDecimal(AvCosecha.Text);
                    //TextBox AvCosecha = (TextBox)row.FindControl("txtAvanceCosecha");
                    Germinacion.BorderColor = System.Drawing.Color.Empty;
                    Plantula.BorderColor = System.Drawing.Color.Empty;
                    Macollamiento.BorderColor = System.Drawing.Color.Empty;
                    Embuche.BorderColor = System.Drawing.Color.Empty;
                    Espigazon.BorderColor = System.Drawing.Color.Empty;
                    Floracion.BorderColor = System.Drawing.Color.Empty;
                    Grano.BorderColor = System.Drawing.Color.Empty;
                    Maduracion.BorderColor = System.Drawing.Color.Empty;
                    AvCosecha.BorderColor = System.Drawing.Color.Empty;
                    if (TotalFenologia > 100)
                    {
                        Germinacion.BorderColor = System.Drawing.Color.PaleVioletRed; //#FF3300; 
                        Plantula.BorderColor = System.Drawing.Color.PaleVioletRed;
                        Macollamiento.BorderColor = System.Drawing.Color.PaleVioletRed;
                        Embuche.BorderColor = System.Drawing.Color.PaleVioletRed;
                        Espigazon.BorderColor = System.Drawing.Color.PaleVioletRed;
                        Floracion.BorderColor = System.Drawing.Color.PaleVioletRed;
                        Grano.BorderColor = System.Drawing.Color.PaleVioletRed;
                        Maduracion.BorderColor = System.Drawing.Color.PaleVioletRed;
                        AvCosecha.BorderColor = System.Drawing.Color.PaleVioletRed;
                        //AvCosecha.Text = "0";
                        CalculoCorrecto = false;
                        string script = @"<script type='text/javascript'>alert('{0}');</script>";
                        script = string.Format(script, "Los datos Ingreados son mayor a 100 %");
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        return;
                    }
                    //promedios
                    TextBox AvanceSiembra = (TextBox)row.FindControl("txtAvanceSiembra");
                    PromedioAvanceSiembra += Convert.ToDecimal(AvanceSiembra.Text);

                    TextBox AvanceCosecha = (TextBox)row.FindControl("txtAvanceCosecha");
                    PromedioAvanceCosecha += Convert.ToDecimal(AvanceCosecha.Text);

                    TextBox AvanceRend = (TextBox)row.FindControl("txtRend");
                    PromedioRend += Convert.ToDecimal(AvanceRend.Text);

                }
                if (GVSeguimientoCultivo.Rows.Count != 0)
                {
                    decimal TPSiembra = PromedioAvanceSiembra / GVSeguimientoCultivo.Rows.Count;
                    //txtResultado.Text = string.Format("{0:n2}", (Math.Truncate(TPSiembra * 100) / 100)));
                    txtPromedioSiembra.Text = string.Format("{0:n2}", (Math.Truncate(TPSiembra * 100) / 100));
                    //txtPromedioSiembra.Text = TPSiembra.ToString();
                    decimal TPCosecha = PromedioAvanceCosecha / GVSeguimientoCultivo.Rows.Count;
                    txtPromedioCosecha.Text = string.Format("{0:n2}", (Math.Truncate(TPCosecha * 100) / 100));
                    //txtPromedioCosecha.Text = TPCosecha.ToString();
                    decimal TPRend = PromedioRend / GVSeguimientoCultivo.Rows.Count;
                    txtPromedioRend.Text = string.Format("{0:n2}", (Math.Truncate(TPRend * 100) / 100));
                    //txtPromedioRend.Text = TPRend.ToString();
                }
                else
                {
                    txtPromedioSiembra.Text = "0";
                    txtPromedioCosecha.Text = "0";
                    txtPromedioRend.Text = "0";
                }

                CalculoCorrecto = true;
            }
            catch (Exception ex)
            {
                CalculoCorrecto = false;
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                
            }
        }

        protected void btnAux_Click(object sender, EventArgs e)
        {

        }

        protected void ImgPrint_Click(object sender, ImageClickEventArgs e)
        {            
            try
            {
                lblmensaje.Text = string.Empty;
                EventArgs ev = new EventArgs();
                int pps = ValidacionPpSemanal();
                if (pps == 1)
                    return;
                btCalcularPromedio_Click(sender, ev);
                if (CalculoCorrecto == false)
                    return;                
                List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColSegunFF = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
                ColSegunFF = CopiarDatosparaExcel();
                if (ColSegunFF.Count == 0)
                    return;
                //VerificacionDatosxUsuario();
                //if (ValidacionRangoFechas == false)
                //    return;
                VerificacionDatosxUsuarioExportar();
                if (ValidadcionExportar)
                { lblmensaje.Text = "El Archivo Generado no se encuentra registrado en el Sistema (Clic en Guardar)."; }
                else
                { return; }

                GVforexcel.DataSource = ColSegunFF;
                GVforexcel.DataBind();

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                System.IO.StringWriter sw = new System.IO.StringWriter(sb);
                System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

                Page page = new Page();
                HtmlForm form = new HtmlForm();

                GVSeguimientoCultivo.EnableViewState = false;
                // Deshabilitar la validación de eventos, sólo asp.net 2
                page.EnableEventValidation = false;
                // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
                page.DesignerInitialize();
                //Image1.Visible = true;
                lbllogo.Visible = true;
                lblCabecera.Visible = true;
                lblCabecera2.Visible = true;
                lblPromedioAvances.Visible = true;
                lblFirma.Visible = true;
                //page.Controls.Add(Image1);
                
                //lblCabecera.Text = "<br/><br/><table align='center' width='800px'><tr align='center'><td><img src='http://200.105.195.55/emapaglobal/img/bannerReport.jpg'alt='EMAPA-Documento' style='float:inherit'/></td><td></td><td></td><td colspan='5'><b style='text-align: center'>EMPRESA DE APOYO A LA PRODUCCION DE ALIMENTOS<br />REPORTE DE VENTAS PRE VALORADAS</b><br>(Expresado en bolivianos)<br /></td><td></td><td></td><td></td></tr><tr align='center'><td colspan='11'><b></b> </td></tr></table>";
                //<img src='../images/logo1.jpg' style='float:inherit' height='80px' width='130px'/>
                lbllogo.Text = "<div style='width: 1415px'><table border='1' style='text-align: center' ><tr><td width='200' rowspan='3'><img src='../images/logo1.jpg' style='float:inherit' height='80px' width='130px'/></td><td colspan='17'><div style='text-align: center'><strong>REGISTRO</strong></div></td><td width='200'><div style='text-align: center'><strong>E-EMP/GP/P/ 303 R07</strong></div></td></tr><tr><td colspan='17'><div style='text-align: center; width: 1000px' ><strong>SEGUIMIENTO DEL CULTIVO DE TRIGO SEG&#218;N FASE FELONOGICA</strong></div></td><td><div style='text-align: center; width:250px'><strong>Versi&#243;n 2</strong></div></td></tr><tr><td></td><td></td></tr></table></div>";
                lblCabecera.Text = "<br /><br /><div style='width: 1415px'><table border='1' style='text-align: center' ><tr><td>&nbsp;</td><td style='width: 450px' colspan='2'><strong>REPORTE AL: " + TxtFecha1.Text + " al " + TxtFecha2.Text + "</strong></td><td style='width: 100px'></td><td style='width: 450px' colspan='12'><strong>CAMPA&#209;A: " + LblCamp.Text + "</strong></td><td style='width: 100px'></td><td style='width: 450px' colspan='2'><strong>REGIONAL: " + LblReg.Text + "</strong></td></tr></table></div>";
                lblCabecera2.Text = "<br /><br /><div style='width: 1415px'><table border='1'><tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><div style='text-align: center'><td style='width: 55px' colspan='8'><strong>ETAPA FENOLOGICA EN %</strong></td></div><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr></table></div>";
                lblPromedioAvances.Text = "<br /><br /><div style='width: 1415px'><table border='1'><tr><td style='width: 100px'></td><td style='width: 60px'></td><td style='width: 60px'></td><td style='width: 60px'></td><td style='width: 55px'><strong>Promedio</strong></td><td><div style='text-align: center;'><strong>" + txtPromedioSiembra.Text + "</strong></div></td><td style='width: 60px'></td><td style='width: 60px'></td><td style='width: 60px'></td><td style='width: 60px'></td><td style='width: 60px'></td><td style='width: 60px'></td><td style='width: 60px'></td><td style='width: 60px'></td><td><div style='text-align: center;'><strong>" + txtPromedioCosecha.Text + "</strong></div></td><td><div style='text-align: center;'><strong>" + txtPromedioRend .Text+ "</strong></div></td></tr></table></div>";
                lblFirma.Text = "<br /><br /><div style='width: 1415px'><table border='1' style='width: 1070px'><tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><tr><td></td><td colspan='3'><strong>Elaborador por: </strong><strong>" + txtNombreUsuario.Text + "</strong></td><td colspan='5'><strong>VoBo: </strong><strong>" + txtvobo .Text+ "</strong></td></tr><tr><td></td><td><div style='text-align: center; width: 370px;'><strong>Nombre y Cargo</strong></div></td></tr></table></div>";
                page.Controls.Add(lbllogo);
                page.Controls.Add(lblCabecera);
                page.Controls.Add(lblCabecera2);
                //page.Controls.Add(lblPromedioAvances);
                //page.Controls.Add(lblFirma);
                page.Controls.Add(form);                
                form.Controls.Add(GVforexcel);                
                page.Controls.Add(lblPromedioAvances);
                page.Controls.Add(lblFirma);
                page.RenderControl(htw);
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                string fecha = DateTime.Now.ToShortDateString();
                Response.AddHeader("Content-Disposition", "attachment;filename=ReporteSeguimientodelCultivo_" + fecha + ".xls");
                Response.Charset = "UTF-8";
                // Response.ContentEncoding = Encoding.Default;
                Response.Write(sb.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }

           
            
        }
        /// <summary>
        /// Remplaza las cadenas de carateres hmtl
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        private string RemplazarCaracteres(string cadena)
        {
            string tratamiento = cadena;
            //&nbsp;
            if (tratamiento.Contains("&nbsp;") == true)
            {
                tratamiento = tratamiento.Replace("&nbsp;", "");
            } 
            if (tratamiento.Contains("&#225;") == true)
            {
                tratamiento = tratamiento.Replace("&#225;", "á");
            }
            if (tratamiento.Contains("&#233;") == true)
            {
                tratamiento = tratamiento.Replace("&#233;", "é");
            }
            if (tratamiento.Contains("&#237;") == true)
            {
                tratamiento = tratamiento.Replace("&#237;", "í");
            }
            if (tratamiento.Contains("#243;") == true)
            {
                tratamiento = tratamiento.Replace("&#243;", "ó");
            }
            if (tratamiento.Contains("&#250;") == true)
            {
                tratamiento = tratamiento.Replace("&#250;", "ú");
            }
            if (tratamiento.Contains("&#252;") == true)
            {
                tratamiento = tratamiento.Replace("&#252;", "ü");
            }
            if (tratamiento.Contains("&#241;") == true)
            {
                tratamiento = tratamiento.Replace("&#241;", "ñ");
            }
            if (tratamiento.Contains("&#193;") == true)
            {
                tratamiento = tratamiento.Replace("&#193;", "Á");
            }
            if (tratamiento.Contains("&#201;") == true)
            {
                tratamiento = tratamiento.Replace("&#201;", "É");
            }
            if (tratamiento.Contains("&#205;") == true)
            {
                tratamiento = tratamiento.Replace("&#205;", "Í");
            }
            if (tratamiento.Contains("&#211;") == true)
            {
                tratamiento = tratamiento.Replace("&#211;", "Ó");
            }
            if (tratamiento.Contains("&#218;") == true)
            {
                tratamiento = tratamiento.Replace("&#218;", "Ú");
            }
            if (tratamiento.Contains("&#209;") == true)
            {
                tratamiento = tratamiento.Replace("&#209;", "Ñ");
            }
            if (tratamiento.Contains("&#220;") == true)
            {
                tratamiento = tratamiento.Replace("&#220;", "Ü");
            }
            //&#225; á ok
            //&#233; é ok
            //&#237; í ok
            //&#243; ó ok
            //&#250; ú ok
            //&#252; ü ok
            //&#241; ñ ok
            //&#193; Á ok
            //&#201; É ok
            //&#205; Í ok
            //&#211; Ó ok
            //&#218; Ú ok
            //&#209; Ñ ok
            //&#220; Ü ok
            return tratamiento;
            
        }
        /// <summary>
        /// Valida que el campo PpSemanal no este vacio
        /// </summary>
        /// <returns></returns>
        protected int ValidacionPpSemanal()
        {
            int ok = 0;
            foreach (GridViewRow row in GVSeguimientoCultivo.Rows)
            {
                //valida que no se PPSemanal no se vacio
                TextBox PpSemanal = (TextBox)row.FindControl("txtPpsemanal");
                PpSemanal.BorderColor = System.Drawing.Color.Empty;
                if (PpSemanal.Text == string.Empty)
                {
                    lblmensaje.Text = "Debe Registrar Precipitación Semanal";
                    PpSemanal.BorderColor = System.Drawing.Color.PaleVioletRed;
                    ok = 1;            
                }
            }
            return ok;
        }
        protected void ImgSave_Click(object sender, ImageClickEventArgs e)
        {
            DB_EXT_Seguimiento Seg_ = new DB_EXT_Seguimiento();            
            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColSegunFF = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
            lblmensaje.Text = string.Empty;
            try
            {
                EventArgs ev = new EventArgs();
                int pps = ValidacionPpSemanal();
                if (pps == 1)
                    return;
                btCalcularPromedio_Click(sender, ev);
                if (CalculoCorrecto == false)
                    return; 
                ColSegunFF = CopiarDatosparaExcel();
                if (ColSegunFF.Count == 0)
                    return;
                //*********************************************************************************************************************************************
                #region verificacion datos segun rango de fechas por usuario
                //DataTable DT_GetFF = new DataTable();
                //DT_GetFF = Seg_.DA_GET_SEG_CULTIVO_FASE_FENOLOGIA();
                //List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColFenologia = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
                //List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColFenologiaxUsuario = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
                //foreach (DataRow dr in DT_GetFF.Rows)
                //{
                //    EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica SCFF = new EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica();
                //    SCFF.Id_Seguimiento_Cultivo_Fase = Convert.ToInt32(dr["Id_Seguimiento_Cultivo_Fase"].ToString());
                //    SCFF.Reporte_Fecha_Inicio = Convert.ToDateTime(dr["Reporte_Fecha_Inicio"].ToString());
                //    SCFF.Reporte_Fecha_Fin = Convert.ToDateTime(dr["Reporte_Fecha_Fin"].ToString());
                //    //SCFF.Campania = dr["Campania"].ToString();
                //    //SCFF.Id_Regional = Convert.ToInt32(dr["Id_Regional"].ToString());
                //    //SCFF.Zona = dr["Zona"].ToString();
                //    //SCFF.Organizacion = dr["Organizacion"].ToString();
                //    //SCFF.Ppsemanal = Convert.ToDecimal(dr["Ppsemanal"].ToString());
                //    //SCFF.FechaSiembraInicio = Convert.ToDateTime(dr["FechaSiembraInicio"].ToString());
                //    //SCFF.FechaSiembraFinal = Convert.ToDateTime(dr["FechaSiembraFinal"].ToString());
                //    //SCFF.AvanceSiembra = Convert.ToDecimal(dr["AvanceSiembra"].ToString());
                //    //SCFF.Germinacion = Convert.ToDecimal(dr["Germinacion"].ToString());
                //    //SCFF.Plantula = Convert.ToDecimal(dr["Plantula"].ToString());
                //    //SCFF.Macollamiento = Convert.ToDecimal(dr["Macollamiento"].ToString());
                //    //SCFF.Embuche = Convert.ToDecimal(dr["Embuche"].ToString());
                //    //SCFF.Espigazon = Convert.ToDecimal(dr["Espigazon"].ToString());
                //    //SCFF.Floracion = Convert.ToDecimal(dr["Floracion"].ToString());
                //    //SCFF.Grano = Convert.ToDecimal(dr["Grano"].ToString());
                //    //SCFF.Maduracion = Convert.ToDecimal(dr["Maduracion"].ToString());
                //    //SCFF.AvanceCosecha = Convert.ToDecimal(dr["AvanceCosecha"].ToString());
                //    //SCFF.Rend = Convert.ToDecimal(dr["Rend"].ToString());
                //    //SCFF.FechaCosechaInicial = Convert.ToDateTime(dr["FechaCosechaInicial"].ToString());
                //    //SCFF.FechaCosechaFinal = Convert.ToDateTime(dr["FechaCosechaFinal"].ToString());
                //    //SCFF.Observaciones = dr["Observaciones"].ToString();
                //    //SCFF.PromedioAvanceSiembra = Convert.ToDecimal(dr["PromedioAvanceSiembra"].ToString());
                //    //SCFF.PromedioAvanceCosecha = Convert.ToDecimal(dr["PromedioAvanceCosecha"].ToString());
                //    //SCFF.PromedioRend = Convert.ToDecimal(dr["PromedioRend"].ToString());
                //    //SCFF.Elaboradopor = dr["Elaboradopor"].ToString();
                //    //SCFF.VoBo = dr["VoBo"].ToString();
                //    SCFF.Id_Usuario = dr["Id_Usuario"].ToString();
                //    SCFF.Programa = dr["Programa"].ToString();
                //    ColFenologia.Add(SCFF);
                //}
                ////ObjSegunFF.Reporte_Fecha_Inicio = Convert.ToDateTime(TxtFecha1.Text);
                ////ObjSegunFF.Reporte_Fecha_Fin = Convert.ToDateTime(TxtFecha2.Text);
                //ColFenologiaxUsuario = ColFenologia.Where(x => x.Id_Usuario == LblIdUsuario.Text).ToList();
                //if (ColFenologiaxUsuario.Count == 0)
                //{
                //    Seg_.DB_INSERT_SEG_CULTIVO_FASE_FENOLOGIA(ColSegunFF);
                //}
                //else
                //{
                //    List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColxFecha = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();    
                //    string fechainicio0 = TxtFecha1.Text;                            
                //    string fechafin0 = (Convert.ToDateTime(TxtFecha1.Text)).AddDays(6).ToString("dd/MM/yyyy");
                //    foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ff in ColFenologiaxUsuario)
                //    {
                //        EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ObjxFecha = new EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica();
                //        EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ObjxFecha2 = new EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica();
                //        ObjxFecha.Reporte_Fecha_Inicio = ff.Reporte_Fecha_Inicio;
                //        ObjxFecha.Reporte_Fecha_Fin = ff.Reporte_Fecha_Fin;
                //        ObjxFecha.Id_Usuario = ff.Id_Usuario;
                //        ObjxFecha2 = ColxFecha.Where(x => x.Reporte_Fecha_Inicio == ObjxFecha.Reporte_Fecha_Inicio && x.Reporte_Fecha_Fin == ObjxFecha.Reporte_Fecha_Fin && x.Id_Usuario == LblIdUsuario.Text).FirstOrDefault();
                //        if(ObjxFecha2 == null)
                //        {
                //            ColxFecha.Add(ObjxFecha);
                //        }                                                
                //    }
                //    List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColxFechaOrdenada = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();                    
                //    ColxFechaOrdenada = ColxFecha.OrderBy(x=>x.Reporte_Fecha_Inicio).ToList();
                //    foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ext in ColxFechaOrdenada)
                //    {
                //        if (ext.Reporte_Fecha_Inicio == Convert.ToDateTime(TxtFecha1.Text))
                //        {
                //            string fechainicio = TxtFecha1.Text;                            
                //            string fechafin = (Convert.ToDateTime(TxtFecha1.Text)).AddDays(6).ToString("dd/MM/yyyy");
                //            if (Convert.ToDateTime(fechafin) == Convert.ToDateTime(TxtFecha2.Text))
                //            {
                //                if (ext.Id_Usuario == LblIdUsuario.Text)
                //                {
                //                    lblmensaje.Text = "Ya se registro el Rango de Fechas " + TxtFecha1.Text + " al " + TxtFecha2.Text;
                //                    return;
                //                }
                //            }
                //            else
                //            {
                //                lblmensaje.Text = "Rango de Fecha invalido. (Ej: del: " + fechainicio + " al " + fechafin +")";
                //                return;
                //            }
                                
                //        }
                         
                //    }
                   
                //    Seg_.DB_INSERT_SEG_CULTIVO_FASE_FENOLOGIA(ColSegunFF);
                //}
                #endregion
                //*********************************************************************************************************************************************
                VerificacionDatosxUsuario();
                if (ValidacionRangoFechas == false)
                    return;
                Seg_.DB_INSERT_SEG_CULTIVO_FASE_FENOLOGIA(ColSegunFF);
                //Seg_.DB_INSERT_SEG_CULTIVO_FASE_FENOLOGIA(ColSegunFF);
                GVforexcel.DataSource = ColSegunFF;
                GVforexcel.DataBind();
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, "SE GUARDO CON EXITO..!!");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        public List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> CopiarDatosparaExcel()
        {

            int aux = 0;
            DB_EXT_Seguimiento Seg_ = new DB_EXT_Seguimiento();
            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColSegunFF = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColSegunFF1 = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
            //return ColSegunFF1;
            try
            {                
                foreach (GridViewRow row in GVSeguimientoCultivo.Rows)
                {
                    EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ObjSegunFF = new EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica();
                    if (TxtFecha1.Text == string.Empty)
                    {
                        TxtFecha1.Focus();
                        lblmensaje.Text = "No se definio Rango de fechas para el Reporte";
                        return ColSegunFF1;
;
                    }
                    if (TxtFecha2.Text == string.Empty)
                    {
                        TxtFecha2.Focus();
                        lblmensaje.Text = "No se definio Rango de fechas para el Reporte";
                        return ColSegunFF1;
                        
                    }

                    ObjSegunFF.Reporte_Fecha_Inicio = Convert.ToDateTime(TxtFecha1.Text);
                    ObjSegunFF.Reporte_Fecha_Fin = Convert.ToDateTime(TxtFecha2.Text);
                    ObjSegunFF.Campania = LblCamp.Text;
                    ObjSegunFF.Id_Regional = Convert.ToInt16(LblIdReg.Text);

                    TextBox Zona = (TextBox)row.FindControl("txtZona");
                    ObjSegunFF.Zona = Zona.Text;

                    string Organizacion = row.Cells[1].Text;
                    ObjSegunFF.Organizacion = Organizacion;

                    TextBox Ppsemanal = (TextBox)row.FindControl("txtPpsemanal");
                    ObjSegunFF.Ppsemanal = Convert.ToDecimal(Ppsemanal.Text);

                    TextBox FechaSiembraInicio = (TextBox)row.FindControl("txtFechaSiembraInicio");
                    ObjSegunFF.FechaSiembraInicio = Convert.ToDateTime(FechaSiembraInicio.Text);

                    TextBox FechaSiembraFinal = (TextBox)row.FindControl("txtFechaSiembraFinal");
                    ObjSegunFF.FechaSiembraFinal = Convert.ToDateTime(FechaSiembraFinal.Text);

                    TextBox AvanceSiembra = (TextBox)row.FindControl("txtAvanceSiembra");
                    ObjSegunFF.AvanceSiembra = Convert.ToDecimal(AvanceSiembra.Text);

                    TextBox Germinacion = (TextBox)row.FindControl("txtGerminacion");
                    ObjSegunFF.Germinacion = Convert.ToDecimal(Germinacion.Text);

                    TextBox Plantula = (TextBox)row.FindControl("txtPlantula");
                    ObjSegunFF.Plantula = Convert.ToDecimal(Plantula.Text);

                    TextBox Macollamiento = (TextBox)row.FindControl("txtMacollamiento");
                    ObjSegunFF.Macollamiento = Convert.ToDecimal(Macollamiento.Text);

                    TextBox Embuche = (TextBox)row.FindControl("txtEmbuche");
                    ObjSegunFF.Embuche = Convert.ToDecimal(Embuche.Text);

                    TextBox Espigazon = (TextBox)row.FindControl("txtEspigazon");
                    ObjSegunFF.Espigazon = Convert.ToDecimal(Espigazon.Text);

                    TextBox Floracion = (TextBox)row.FindControl("txtFloracion");
                    ObjSegunFF.Floracion = Convert.ToDecimal(Floracion.Text);

                    TextBox Grano = (TextBox)row.FindControl("txtGrano");
                    ObjSegunFF.Grano = Convert.ToDecimal(Grano.Text);

                    TextBox Maduracion = (TextBox)row.FindControl("txtMaduracion");
                    ObjSegunFF.Maduracion = Convert.ToDecimal(Maduracion.Text);

                    TextBox AvanceCosecha = (TextBox)row.FindControl("txtAvanceCosecha");
                    ObjSegunFF.AvanceCosecha = Convert.ToDecimal(AvanceCosecha.Text);

                    TextBox Rend = (TextBox)row.FindControl("txtRend");
                    ObjSegunFF.Rend = Convert.ToDecimal(Rend.Text);

                    TextBox FechaCosechaInicial = (TextBox)row.FindControl("txtFechaCosechaInicial");
                    ObjSegunFF.FechaCosechaInicial = Convert.ToDateTime(FechaCosechaInicial.Text);

                    TextBox FechaCosechaFinal = (TextBox)row.FindControl("txtFechaCosechaFinal");
                    ObjSegunFF.FechaCosechaFinal = Convert.ToDateTime(FechaCosechaFinal.Text);

                    TextBox Observaciones = (TextBox)row.FindControl("txtObservaciones");
                    ObjSegunFF.Observaciones = Observaciones.Text;

                    ObjSegunFF.PromedioAvanceSiembra = Convert.ToDecimal(txtPromedioSiembra.Text);
                    ObjSegunFF.PromedioAvanceCosecha = Convert.ToDecimal(txtPromedioCosecha.Text);
                    ObjSegunFF.PromedioRend = Convert.ToDecimal(txtPromedioRend.Text);
                    ObjSegunFF.Elaboradopor = txtNombreUsuario.Text;
                    ObjSegunFF.VoBo = txtvobo.Text;
                    ObjSegunFF.Id_Usuario = LblIdUsuario.Text;
                    ObjSegunFF.Programa = LblPrograma.Text;

                    ColSegunFF.Add(ObjSegunFF);
                }
                return ColSegunFF;

            }            
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
                //string script = @"<script type='text/javascript'>alert('{0}');</script>";
                //script = string.Format(script, ex.Message);
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                //return ColSegunFF1;
            }
            //if (aux == 0)
            //    ColSegunFF1 = ColSegunFF;
            //return ColSegunFF1;
        }
        /// <summary>
        /// Verificacion por usuario para ver si el rango de fechas ya fue registrado
        /// </summary>
        /// <returns></returns>
        public void VerificacionDatosxUsuario()
        {            
            DB_EXT_Seguimiento Seg_ = new DB_EXT_Seguimiento();     
            DataTable DT_GetFF = new DataTable();
            DT_GetFF = Seg_.DA_GET_SEG_CULTIVO_FASE_FENOLOGIA();
            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColFenologia = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColFenologiaxUsuario = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
            foreach (DataRow dr in DT_GetFF.Rows)
            {
                EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica SCFF = new EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica();
                SCFF.Id_Seguimiento_Cultivo_Fase = Convert.ToInt32(dr["Id_Seguimiento_Cultivo_Fase"].ToString());
                SCFF.Reporte_Fecha_Inicio = Convert.ToDateTime(dr["Reporte_Fecha_Inicio"].ToString());
                SCFF.Reporte_Fecha_Fin = Convert.ToDateTime(dr["Reporte_Fecha_Fin"].ToString());              
                SCFF.Id_Usuario = dr["Id_Usuario"].ToString();
                SCFF.Programa = dr["Programa"].ToString();
                ColFenologia.Add(SCFF);
            }           
            ColFenologiaxUsuario = ColFenologia.Where(x => x.Id_Usuario == LblIdUsuario.Text).ToList();
            if (ColFenologiaxUsuario.Count == 0)
            {
                if (!DiasdeSemana(Convert.ToDateTime(TxtFecha1.Text)))
                {
                    lblmensaje.Text = "La Fecha Inicial " + TxtFecha1.Text + " no es LUNES";
                    ValidacionRangoFechas = false;
                    return;
                }
                if (!DiasdeSemanaDomingo(Convert.ToDateTime(TxtFecha2.Text)))
                {
                    lblmensaje.Text = "La Fecha Inicial " + TxtFecha2.Text + " no es DOMINGO";
                    ValidacionRangoFechas = false;
                    return;
                }
                ValidacionRangoFechas = true;
            }
            else
            {
                List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColxFecha = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
                string fechainicio0 = TxtFecha1.Text;
                string fechafin0 = (Convert.ToDateTime(TxtFecha1.Text)).AddDays(6).ToString("dd/MM/yyyy");
                foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ff in ColFenologiaxUsuario)
                {
                    EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ObjxFecha = new EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica();
                    EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ObjxFecha2 = new EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica();
                    ObjxFecha.Reporte_Fecha_Inicio = ff.Reporte_Fecha_Inicio;
                    ObjxFecha.Reporte_Fecha_Fin = ff.Reporte_Fecha_Fin;
                    ObjxFecha.Id_Usuario = ff.Id_Usuario;
                    ObjxFecha.Programa = ff.Programa;//LblPrograma.Text
                    ObjxFecha2 = ColxFecha.Where(x => x.Reporte_Fecha_Inicio == ObjxFecha.Reporte_Fecha_Inicio && x.Reporte_Fecha_Fin == ObjxFecha.Reporte_Fecha_Fin && x.Id_Usuario == LblIdUsuario.Text && x.Programa == LblPrograma.Text).FirstOrDefault();
                    if (ObjxFecha2 == null)
                    {
                        ColxFecha.Add(ObjxFecha);
                    }
                }
                List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColxFechaOrdenada = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
                ColxFechaOrdenada = ColxFecha.OrderBy(x => x.Reporte_Fecha_Inicio).ToList();
                foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ext in ColxFechaOrdenada)
                {
                    if (!DiasdeSemana(Convert.ToDateTime(TxtFecha1.Text)))
                    {
                        lblmensaje.Text = "La Fecha Inicial " + TxtFecha1.Text + " no es LUNES";
                        ValidacionRangoFechas = false;
                        break;
                    }
                    if (!DiasdeSemanaDomingo(Convert.ToDateTime(TxtFecha2.Text)))
                    {
                        lblmensaje.Text = "La Fecha Inicial " + TxtFecha2.Text + " no es DOMINGO";
                        ValidacionRangoFechas = false;
                        break;
                    }
                    else
                    {
                        ValidacionRangoFechas = true;
                        if (ext.Reporte_Fecha_Inicio == Convert.ToDateTime(TxtFecha1.Text))
                        {
                            string fechainicio = TxtFecha1.Text;
                            string fechafin = (Convert.ToDateTime(TxtFecha1.Text)).AddDays(6).ToString("dd/MM/yyyy");
                            if (Convert.ToDateTime(fechafin) == Convert.ToDateTime(TxtFecha2.Text))
                            {
                                if (ext.Id_Usuario == LblIdUsuario.Text)
                                {
                                    lblmensaje.Text = "Ya se registro el Rango de Fechas " + TxtFecha1.Text + " al " + TxtFecha2.Text;
                                    ValidacionRangoFechas = false;
                                    break;
                                }
                            }
                            else
                            {
                                lblmensaje.Text = "Rango de Fecha invalido. (Ej: del:Lunes " + fechainicio + " al Domingo " + fechafin + ")";
                                ValidacionRangoFechas = false;
                                break;
                            }

                        }
                        
                    }

                }                               
            }            
        }
        /// <summary>
        /// Verifica si la Fecha Inicial es Lunes
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private bool DiasdeSemana(DateTime date)
        {
            string value = date.DayOfWeek.ToString();
            bool Lunes = false;
            switch (value)
            {
                case "Monday":                        
                    Lunes = true;
                    break;
                //case 5:
                //    Console.WriteLine(5);
                //    break;
            }
            return Lunes;
        }
        private bool DiasdeSemanaDomingo(DateTime date)
        {
            string value = date.DayOfWeek.ToString();
            bool Domingo = false;
            switch (value)
            {
                case "Sunday":
                    Domingo = true;
                    break;
                //case 5:
                //    Console.WriteLine(5);
                //    break;
            }
            return Domingo;
        }
        /// <summary>
        /// Verificaca si el archivo exportado ya se guardo en la BD.
        /// </summary>
        /// <returns></returns>
        public void VerificacionDatosxUsuarioExportar()
        {
            DB_EXT_Seguimiento Seg_ = new DB_EXT_Seguimiento();
            DataTable DT_GetFF = new DataTable();
            DT_GetFF = Seg_.DA_GET_SEG_CULTIVO_FASE_FENOLOGIA();
            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColFenologia = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColFenologiaxUsuario = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
            foreach (DataRow dr in DT_GetFF.Rows)
            {
                EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica SCFF = new EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica();
                SCFF.Id_Seguimiento_Cultivo_Fase = Convert.ToInt32(dr["Id_Seguimiento_Cultivo_Fase"].ToString());
                SCFF.Reporte_Fecha_Inicio = Convert.ToDateTime(dr["Reporte_Fecha_Inicio"].ToString());
                SCFF.Reporte_Fecha_Fin = Convert.ToDateTime(dr["Reporte_Fecha_Fin"].ToString());
                SCFF.Id_Usuario = dr["Id_Usuario"].ToString();
                SCFF.Programa = dr["Programa"].ToString();
                ColFenologia.Add(SCFF);
            }
            ColFenologiaxUsuario = ColFenologia.Where(x => x.Id_Usuario == LblIdUsuario.Text).ToList();
            if (ColFenologiaxUsuario.Count == 0)
            {
                ValidadcionExportar = true;
                //ValidacionRangoFechas = true;
            }
            else
            {
                List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColxFecha = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
                string fechainicio0 = TxtFecha1.Text;
                string fechafin0 = (Convert.ToDateTime(TxtFecha1.Text)).AddDays(6).ToString("dd/MM/yyyy");                
                foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ff in ColFenologiaxUsuario)
                {
                    EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ObjxFecha = new EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica();
                    EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ObjxFecha2 = new EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica();
                    ObjxFecha.Reporte_Fecha_Inicio = ff.Reporte_Fecha_Inicio;
                    ObjxFecha.Reporte_Fecha_Fin = ff.Reporte_Fecha_Fin;
                    ObjxFecha.Id_Usuario = ff.Id_Usuario;
                    ObjxFecha.Programa = ff.Programa;//LblPrograma.Text
                    ObjxFecha2 = ColxFecha.Where(x => x.Reporte_Fecha_Inicio == ObjxFecha.Reporte_Fecha_Inicio && x.Reporte_Fecha_Fin == ObjxFecha.Reporte_Fecha_Fin && x.Id_Usuario == LblIdUsuario.Text && x.Programa == LblPrograma.Text).FirstOrDefault();
                    if (ObjxFecha2 == null)
                    {
                        ColxFecha.Add(ObjxFecha);
                    }
                }
                List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColxFechaOrdenada = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
                ColxFechaOrdenada = ColxFecha.OrderBy(x => x.Reporte_Fecha_Inicio).ToList();
                foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ext in ColxFechaOrdenada)
                {
                    if (!DiasdeSemana(Convert.ToDateTime(TxtFecha1.Text)))
                    {
                        lblmensaje.Text = "La Fecha Inicial " + TxtFecha1.Text + " no es LUNES";
                        ValidadcionExportar = false;
                        break;
                    }
                    if (!DiasdeSemanaDomingo(Convert.ToDateTime(TxtFecha2.Text)))
                    {
                        lblmensaje.Text = "La Fecha Inicial " + TxtFecha2.Text + " no es DOMINGO";
                        ValidacionRangoFechas = false;
                        break;
                    }
                    else
                    {
                        //ValidacionRangoFechas = true;
                        ValidadcionExportar = true;
                        if (ext.Reporte_Fecha_Inicio == Convert.ToDateTime(TxtFecha1.Text))
                        {
                            string fechainicio = TxtFecha1.Text;
                            string fechafin = (Convert.ToDateTime(TxtFecha1.Text)).AddDays(6).ToString("dd/MM/yyyy");
                            if (Convert.ToDateTime(fechafin) == Convert.ToDateTime(TxtFecha2.Text))
                            {
                                if (ext.Id_Usuario == LblIdUsuario.Text)
                                {
                                    //lblmensaje.Text = "Ya se registro el Rango de Fechas " + TxtFecha1.Text + " al " + TxtFecha2.Text;
                                    //ValidacionRangoFechas = false;
                                    ValidadcionExportar = true;
                                    break;
                                }
                            }
                            else
                            {
                                lblmensaje.Text = "Rango de Fecha invalido. (Ej: del: " + fechainicio + " al " + fechafin + ")";
                                //ValidacionRangoFechas = false;
                                ValidadcionExportar = false;
                                break;
                            }

                        }

                    }

                }
                //lblmensaje.Text = "El Archivo Generado no se encuentra registrado en el Sistema (Clic en Guardar).";
            }
        }


    }
    
}