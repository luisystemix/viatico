using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBusiness.DB_General;
using DataEntity.DE_General;
using System.Data;
using System.Text;
using DataBusiness.DB_Extensiones;
using DataEntity.DE_Extensiones;

namespace WebAplication.Viaticos
{
    public partial class repDetalleFenologia : System.Web.UI.Page
    {
        /// <summary>
        /// Dictionary Resultado Promedio Cosecha 
        /// </summary>
        private Dictionary<string, decimal> Dic_Totales
        {
            get
            {
                object d = ViewState["Dic_Totales"];
                return (d == null ? null : (Dictionary<string, decimal>)d);
            }
            set
            {
                ViewState["Dic_Totales"] = value;
            }
        }
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
        protected void Page_Load(object sender, EventArgs e)
        
        {
            if (!IsPostBack)
            {
                if (Session["IdUser"] == null)
                { Response.Redirect("~/About.aspx"); }
                else
                {
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    Llenar_DDLRegional();
                    Get_Semanas();
                    Get_Est_FenologiaxSemanas();
                    
                }                
            }
        }
        private void Llenar_DDLRegional()
        {
            DB_AdminUser User = new DB_AdminUser();
            //DataTable dt = User.DB_Desplegar_USUARIO(LblIdUsuario.Text);
            ////LblReg.Text = dt.Rows[0][13].ToString();
            //if (Convert.ToInt32(dt.Rows[0][6].ToString()) == 15 || Convert.ToInt32(dt.Rows[0][6].ToString()) == 5)
            //{
            //    DDLRegional.Items.Insert(0, new ListItem(dt.Rows[0][5].ToString(), dt.Rows[0][4].ToString(), true));
            //    DDLRegional.Enabled = false;
            //}
            //else
            //{
                DB_Regional reg = new DB_Regional();
                List<Regional> Lista = reg.DB_Desplegar_REGIONAL();
                DDLRegional.DataSource = Lista;
                DDLRegional.DataValueField = "Id_Regional";
                DDLRegional.DataTextField = "Nombre";
                DDLRegional.DataBind();
                DDLRegional.Items.Insert(0, new ListItem("Seleccione la Regional", "0", true));
            //}
        }
        private void Get_Est_FenologiaxSemanas()
        {
            int Count = 0;
            DB_EXT_Seguimiento Seg_ = new DB_EXT_Seguimiento();
            DataTable DT_GetRepF = new DataTable();
            DT_GetRepF = Seg_.DB_GET_ETAPAS_FASE_FENOLOGICA();
            //cabeceras de reporte
            //t2.Id_Usuario, t2.Reporte_Fecha_Inicio, t2.Reporte_Fecha_Fin, t2.Id_Regional, t2.Programa, t2.PromedioAvanceCosecha
            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColGrafica = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColGraficaFinal = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
            foreach (DataRow row in DT_GetRepF.Rows)
            {
                EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ObjGrafico = new EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica();
                ObjGrafico.Id_Seguimiento_Cultivo_Fase = Convert.ToInt32(row["Id_Seguimiento_Cultivo_Fase"].ToString());
                ObjGrafico.Reporte_Fecha_Inicio = Convert.ToDateTime(row["Reporte_Fecha_Inicio"].ToString());
                ObjGrafico.Reporte_Fecha_Fin = Convert.ToDateTime(row["Reporte_Fecha_Fin"].ToString());
                ObjGrafico.Campania = row["Campania"].ToString();
                ObjGrafico.Id_Regional = Convert.ToInt32(row["Id_Regional"].ToString());
                ObjGrafico.Zona = row["Zona"].ToString();
                ObjGrafico.Organizacion = row["Organizacion"].ToString();
                ObjGrafico.Ppsemanal = Convert.ToDecimal(row["Ppsemanal"].ToString());
                ObjGrafico.FechaSiembraInicio = Convert.ToDateTime(row["FechaSiembraInicio"].ToString());
                ObjGrafico.FechaSiembraFinal = Convert.ToDateTime(row["FechaSiembraFinal"].ToString());
                ObjGrafico.AvanceSiembra = Convert.ToDecimal(row["AvanceSiembra"].ToString());
                ObjGrafico.Germinacion = Convert.ToDecimal(row["Germinacion"].ToString());
                ObjGrafico.Plantula = Convert.ToDecimal(row["Plantula"].ToString());
                ObjGrafico.Macollamiento = Convert.ToDecimal(row["Macollamiento"].ToString());
                ObjGrafico.Embuche = Convert.ToDecimal(row["Embuche"].ToString());
                ObjGrafico.Espigazon = Convert.ToDecimal(row["Espigazon"].ToString());
                ObjGrafico.Floracion = Convert.ToDecimal(row["Floracion"].ToString());
                ObjGrafico.Grano = Convert.ToDecimal(row["Grano"].ToString());
                ObjGrafico.Maduracion = Convert.ToDecimal(row["Maduracion"].ToString());
                ObjGrafico.AvanceCosecha = Convert.ToDecimal(row["AvanceCosecha"].ToString());
                ObjGrafico.Rend = Convert.ToDecimal(row["Rend"].ToString());
                ObjGrafico.FechaCosechaInicial = Convert.ToDateTime(row["FechaCosechaInicial"].ToString());
                ObjGrafico.FechaCosechaFinal = Convert.ToDateTime(row["FechaCosechaFinal"].ToString());
                ObjGrafico.Observaciones = row["Observaciones"].ToString();
                ObjGrafico.PromedioAvanceSiembra = Convert.ToDecimal(row["PromedioAvanceSiembra"].ToString());
                ObjGrafico.PromedioAvanceCosecha = Convert.ToDecimal(row["PromedioAvanceCosecha"].ToString());
                ObjGrafico.PromedioRend = Convert.ToDecimal(row["PromedioRend"].ToString());
                ObjGrafico.Elaboradopor = row["Elaboradopor"].ToString();
                ObjGrafico.VoBo = row["VoBo"].ToString();
                ObjGrafico.Id_Usuario = row["Id_Usuario"].ToString();    
                ObjGrafico.Programa = row["Programa"].ToString();                
                ColGrafica.Add(ObjGrafico);
            }           
            string s = ddlSemanas.SelectedValue;
            ////**>>PRUEBA DE AMPLIACION EN REGIONALES lrojas:01/12/2016
            DB_Regional r_ = new DB_Regional();
            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColGraficaFinalConAmpliaciones = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
            List<Regional> ColAmpliaciones = new List<Regional>();
            if (DDLRegional.SelectedValue != "0")
            {
                List<Regional> ColRegionales = r_.DB_Desplegar_REGIONAL();
                ColAmpliaciones = ColRegionales.Where(x => x.IdRegional_Padre == Convert.ToInt32(DDLRegional.SelectedValue)
                                                                   || x.Id_Regional == Convert.ToInt32(DDLRegional.SelectedValue)).ToList();

                foreach (Regional reg_amp in ColAmpliaciones)
                {
                    foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica res_ in ColGrafica)
                    {
                        EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ObjSeg = new EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica();
                        if (res_.Id_Regional == reg_amp.Id_Regional)
                        {
                            ColGraficaFinalConAmpliaciones.Add(res_);
                        }
                    }
                }
            }
            ////**>>
            if (ddlSemanas.SelectedValue != "0" )//|| ddlSemanas.SelectedValue != string.Empty)
            {
                string fini = string.Empty;
                string ffin = string.Empty;
                string[] words = s.Split('|');
                int index = 0;
                foreach (string word in words)
                {
                    if (index == 0)
                    { fini = word; index++; }
                    else
                    { ffin = word; }
                }                
                //ColGraficaFinal = ColGrafica.Where(x => x.Reporte_Fecha_Inicio == Convert.ToDateTime(fini) && x.Reporte_Fecha_Fin == Convert.ToDateTime(ffin)).ToList();
                if (DDLRegional.SelectedValue != "0")//<<<<<<<<<<<<<<<<<<<<<<<
                {
                    if (DDLPrograma.SelectedValue != "0")
                    {
                        //ColGraficaFinal = ColGrafica.Where(x => x.Id_Regional == Convert.ToInt32(DDLRegional.SelectedValue) 
                        //                                    && x.Programa == DDLPrograma.SelectedValue 
                        //                                    && x.Reporte_Fecha_Inicio == Convert.ToDateTime(fini) && x.Reporte_Fecha_Fin == Convert.ToDateTime(ffin)
                        //                                    ).ToList(); //OLD
                        //*>lrojas:01/12/2016
                        if (ColAmpliaciones.Count > 1)
                        {                            
                            ColGraficaFinal = ColGraficaFinalConAmpliaciones.Where(x => x.Programa == DDLPrograma.SelectedValue
                                                                                    && x.Reporte_Fecha_Inicio == Convert.ToDateTime(fini) 
                                                                                    && x.Reporte_Fecha_Fin == Convert.ToDateTime(ffin)
                                                                                    ).ToList();
                        }
                        else
                        {                            
                            ColGraficaFinal = ColGrafica.Where(x => x.Id_Regional == Convert.ToInt32(DDLRegional.SelectedValue)
                                                                && x.Programa == DDLPrograma.SelectedValue
                                                                && x.Reporte_Fecha_Inicio == Convert.ToDateTime(fini) && x.Reporte_Fecha_Fin == Convert.ToDateTime(ffin)
                                                                ).ToList();
                        }
                        //*>
                    }
                    else
                    {
                        //ColGraficaFinal = ColGrafica.Where(x => x.Id_Regional == Convert.ToInt32(DDLRegional.SelectedValue)
                        //    && x.Reporte_Fecha_Inicio == Convert.ToDateTime(fini) && x.Reporte_Fecha_Fin == Convert.ToDateTime(ffin)).ToList();//OLD
                        //*>lrojas:01/12/2016
                        if (ColAmpliaciones.Count > 1)
                        {                            
                            ColGraficaFinal = ColGraficaFinalConAmpliaciones.Where(x => x.Reporte_Fecha_Inicio == Convert.ToDateTime(fini) 
                                                                                    && x.Reporte_Fecha_Fin == Convert.ToDateTime(ffin)).ToList();
                        }
                        else
                        {
                            ColGraficaFinal = ColGrafica.Where(x => x.Id_Regional == Convert.ToInt32(DDLRegional.SelectedValue)
                                                            && x.Reporte_Fecha_Inicio == Convert.ToDateTime(fini) && x.Reporte_Fecha_Fin == Convert.ToDateTime(ffin)).ToList();//OLD
                        }
                        //*>
                    }
                }
                else
                {
                    if (DDLPrograma.SelectedValue != "0")
                    {
                        //ColGraficaFinal = ColGrafica.Where(x => x.Programa == DDLPrograma.SelectedValue
                        //    && x.Reporte_Fecha_Inicio == Convert.ToDateTime(fini) && x.Reporte_Fecha_Fin == Convert.ToDateTime(ffin)).ToList(); //OLD
                        //*>lrojas:01/12/2016
                        if (ColAmpliaciones.Count > 1)
                        {                            
                            ColGraficaFinal = ColGraficaFinalConAmpliaciones.Where(x => x.Programa == DDLPrograma.SelectedValue
                                                            && x.Reporte_Fecha_Inicio == Convert.ToDateTime(fini) && x.Reporte_Fecha_Fin == Convert.ToDateTime(ffin)).ToList();
                        }
                        else
                        {
                            ColGraficaFinal = ColGrafica.Where(x => x.Programa == DDLPrograma.SelectedValue
                                                            && x.Reporte_Fecha_Inicio == Convert.ToDateTime(fini) && x.Reporte_Fecha_Fin == Convert.ToDateTime(ffin)).ToList(); //OLD
                        }
                        //*>
                    }
                    else
                    {
                        //ColGraficaFinal = ColGrafica.Where(x => x.Reporte_Fecha_Inicio == Convert.ToDateTime(fini) && x.Reporte_Fecha_Fin == Convert.ToDateTime(ffin)).ToList(); //OLD
                        //*>lrojas:01/12/2016
                        if (ColAmpliaciones.Count > 1)
                        {                            
                            ColGraficaFinal = ColGraficaFinalConAmpliaciones.Where(x => x.Reporte_Fecha_Inicio == Convert.ToDateTime(fini) && x.Reporte_Fecha_Fin == Convert.ToDateTime(ffin)).ToList();
                        }
                        else
                        {
                            ColGraficaFinal = ColGrafica.Where(x => x.Reporte_Fecha_Inicio == Convert.ToDateTime(fini) && x.Reporte_Fecha_Fin == Convert.ToDateTime(ffin)).ToList(); //OLD
                        }
                        //*>
                    }
                }//<<<<<<<<<<<<<<<<<<<<<<<
            }
            else 
            {
               // ColGraficaFinal = ColGrafica;                     
                if (DDLRegional.SelectedValue != "0")
                {
                    if (DDLPrograma.SelectedValue != "0")
                    {
                        //ColGraficaFinal = ColGrafica.Where(x => x.Id_Regional == Convert.ToInt32(DDLRegional.SelectedValue) && x.Programa == DDLPrograma.SelectedValue).ToList(); // OLD
                        //*>lrojas:01/12/2016
                        if (ColAmpliaciones.Count > 1)
                        {
                            ColGraficaFinal = ColGraficaFinalConAmpliaciones.Where(x => x.Programa == DDLPrograma.SelectedValue).ToList();
                        }
                        else
                        {                            
                            ColGraficaFinal = ColGrafica.Where(x => x.Id_Regional == Convert.ToInt32(DDLRegional.SelectedValue) && x.Programa == DDLPrograma.SelectedValue).ToList();
                        }
                        //*>
                    }
                    else
                    {
                        //ColGraficaFinal = ColGrafica.Where(x => x.Id_Regional == Convert.ToInt32(DDLRegional.SelectedValue)).ToList(); //OLD
                        //*>lrojas:01/12/2016
                        if (ColAmpliaciones.Count > 1)
                        {
                            ColGraficaFinal = ColGraficaFinalConAmpliaciones;                            
                        }
                        else
                        {
                            ColGraficaFinal = ColGrafica.Where(x => x.Id_Regional == Convert.ToInt32(DDLRegional.SelectedValue)).ToList(); //OLD
                        }
                        //*>                        
                    }
                }
                else
                {
                    if (DDLPrograma.SelectedValue != "0")
                    {
                        //ColGraficaFinal = ColGrafica.Where(x => x.Programa == DDLPrograma.SelectedValue).ToList();
                        //*> lrojas:01/12/2016
                        if (ColAmpliaciones.Count > 1)
                        {
                            //ColGraficaFinal = ColGraficaFinalConAmpliaciones.Where(x => x.PromedioAvanceCosecha > 0).ToList();
                            ColGraficaFinal = ColGraficaFinalConAmpliaciones.Where(x => x.Programa == DDLPrograma.SelectedValue).ToList();
                        }
                        else
                        {
                            ColGraficaFinal = ColGrafica.Where(x => x.Programa == DDLPrograma.SelectedValue).ToList();//OLD
                        }
                        //*>
                    }
                    else
                    {
                        //ColGraficaFinal = ColGrafica; //OLD
                        //*>por defector carga todo lrojas:01/12/2016
                        if (ColAmpliaciones.Count > 1)
                        {                            
                            ColGraficaFinal = ColGraficaFinalConAmpliaciones;
                        }
                        else
                        {                            
                            ColGraficaFinal = ColGrafica;//old
                        }
                        //*>                        
                    }
                }
            }
            ddlDatosGrafica.Items.Clear();
            DB_Regional reg = new DB_Regional();
            List<Regional> Lista = reg.DB_Desplegar_REGIONAL();
            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColGraficaFinalAsc = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();            

            Dictionary<string, decimal> d_totales = new Dictionary<string, decimal>();
            //**variable           
            //Convert.ToDecimal(ColGraficaFiltrada.Sum(x => x.Germinacion).ToString());
            decimal germinacion = 0; int c_germinacion = 0; decimal T_ger = 0;
            decimal plantula = 0; int c_plantula = 0; decimal t_plantula = 0;
            decimal macollamiento = 0; int c_macollamiento = 0; decimal t_macollamiento = 0;
            decimal embuche = 0; int c_embuche = 0; decimal t_embuche = 0;
            decimal espigazon = 0; int c_espigazon = 0; decimal t_espigazon = 0;
            decimal floracion = 0; int c_floracion = 0; decimal t_floracion = 0;
            decimal grano = 0; int c_grano = 0; decimal t_grano = 0;
            decimal maduracion = 0; int c_maduracion = 0; decimal t_maduracion = 0;
            ColGraficaFinalAsc = ColGraficaFinal.OrderBy(x => x.Reporte_Fecha_Inicio).ToList();
            //**
            //GERMINACION
            foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ff in ColGraficaFinalAsc)
            {
                if (ff.Germinacion != Convert.ToDecimal("0"))
                {
                    //**
                    int index = 0;
                    string regional = string.Empty;
                    if (Lista.Count != 0)
                    {
                        regional = Lista.Where(x => x.Id_Regional == ff.Id_Regional).FirstOrDefault().Nombre;
                    }
                    else
                    {
                        regional = ff.Id_Regional.ToString();
                    }
                    string item = ff.Id_Usuario + " | " + regional + " | " + ff.Programa + " | Germinación | "+ ff.Germinacion + " | " + ff.Reporte_Fecha_Inicio.ToShortDateString() + " al " + ff.Reporte_Fecha_Fin.ToShortDateString();
                    //DDLRegional.Items.Insert(index, item);
                    ddlDatosGrafica.Items.Insert(index, new ListItem(item, "0", true));
                    //**
                    germinacion = germinacion + ff.Germinacion;
                    c_germinacion++;
                }
            }
            //decimal T_ger = 0;
            if (c_germinacion != 0)
            {
                T_ger = germinacion / c_germinacion;
            }            
            d_totales.Add("GerminacionSemana" + Count, T_ger);
            //**
            //PLANTULA
            foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ff in ColGraficaFinalAsc)
            {
                if (ff.Plantula != Convert.ToDecimal("0"))
                {
                    //**
                    int index = 0;
                    string regional = string.Empty;
                    if (Lista.Count != 0)
                    {
                        regional = Lista.Where(x => x.Id_Regional == ff.Id_Regional).FirstOrDefault().Nombre;
                    }
                    else
                    {
                        regional = ff.Id_Regional.ToString();
                    }
                    string item = ff.Id_Usuario + " | " + regional + " | " + ff.Programa + " | Plantula | " + ff.Plantula + " | " + ff.Reporte_Fecha_Inicio.ToShortDateString() + " al " + ff.Reporte_Fecha_Fin.ToShortDateString();
                    //DDLRegional.Items.Insert(index, item);
                    ddlDatosGrafica.Items.Insert(index, new ListItem(item, "0", true));
                    //**
                    plantula = plantula + ff.Plantula;
                    c_plantula++;
                }
            }
            if (c_plantula != 0)
            {
                t_plantula = plantula / c_plantula;
            }
            d_totales.Add("PlantulaSemana" + Count, t_plantula);
            //**
            //MACOLLAMIENTO
            foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ff in ColGraficaFinalAsc)
            {
                if (ff.Macollamiento != Convert.ToDecimal("0"))
                {
                    //**
                    int index = 0;
                    string regional = string.Empty;
                    if (Lista.Count != 0)
                    {
                        regional = Lista.Where(x => x.Id_Regional == ff.Id_Regional).FirstOrDefault().Nombre;
                    }
                    else
                    {
                        regional = ff.Id_Regional.ToString();
                    }
                    string item = ff.Id_Usuario + " | " + regional + " | " + ff.Programa + " | Macollamiento | " + ff.Macollamiento + " | " + ff.Reporte_Fecha_Inicio.ToShortDateString() + " al " + ff.Reporte_Fecha_Fin.ToShortDateString();
                    //DDLRegional.Items.Insert(index, item);
                    ddlDatosGrafica.Items.Insert(index, new ListItem(item, "0", true));
                    //**
                    macollamiento = macollamiento + ff.Macollamiento;
                    c_macollamiento++;
                }
            }
            if (c_macollamiento != 0)
            {
                t_macollamiento = macollamiento / c_macollamiento;
            }
            d_totales.Add("MacollamientoSemana" + Count, t_macollamiento);
            //**
            //EMBUCHE
            foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ff in ColGraficaFinalAsc)
            {
                if (ff.Embuche != Convert.ToDecimal("0"))
                {
                    //**
                    int index = 0;
                    string regional = string.Empty;
                    if (Lista.Count != 0)
                    {
                        regional = Lista.Where(x => x.Id_Regional == ff.Id_Regional).FirstOrDefault().Nombre;
                    }
                    else
                    {
                        regional = ff.Id_Regional.ToString();
                    }
                    string item = ff.Id_Usuario + " | " + regional + " | " + ff.Programa + " | Embuche | " + ff.Embuche + " | " + ff.Reporte_Fecha_Inicio.ToShortDateString() + " al " + ff.Reporte_Fecha_Fin.ToShortDateString();
                    //DDLRegional.Items.Insert(index, item);
                    ddlDatosGrafica.Items.Insert(index, new ListItem(item, "0", true));
                    //**
                    embuche = embuche + ff.Embuche;
                    c_embuche++;
                }
            }
            if (c_embuche != 0)
            {
                t_embuche = embuche / c_embuche;
            }
            d_totales.Add("EmbucheSemana" + Count, t_embuche);
            //ESPIGAZON
            foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ff in ColGraficaFinalAsc)
            {
                if (ff.Espigazon != Convert.ToDecimal("0"))
                {
                    //**
                    int index = 0;
                    string regional = string.Empty;
                    if (Lista.Count != 0)
                    {
                        regional = Lista.Where(x => x.Id_Regional == ff.Id_Regional).FirstOrDefault().Nombre;
                    }
                    else
                    {
                        regional = ff.Id_Regional.ToString();
                    }
                    string item = ff.Id_Usuario + " | " + regional + " | " + ff.Programa + " | Espigazón | " + ff.Espigazon + " | " + ff.Reporte_Fecha_Inicio.ToShortDateString() + " al " + ff.Reporte_Fecha_Fin.ToShortDateString();
                    //DDLRegional.Items.Insert(index, item);
                    ddlDatosGrafica.Items.Insert(index, new ListItem(item, "0", true));
                    //**
                    espigazon = espigazon + ff.Espigazon;
                    c_espigazon++;
                }
            }
            if (c_espigazon != 0)
            {
                t_espigazon = espigazon / c_espigazon;
            }
            d_totales.Add("EspigazonSemana" + Count, t_espigazon);
            //FLORACION
            foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ff in ColGraficaFinalAsc)
            {
                if (ff.Floracion != Convert.ToDecimal("0"))
                {
                    //**
                    int index = 0;
                    string regional = string.Empty;
                    if (Lista.Count != 0)
                    {
                        regional = Lista.Where(x => x.Id_Regional == ff.Id_Regional).FirstOrDefault().Nombre;
                    }
                    else
                    {
                        regional = ff.Id_Regional.ToString();
                    }
                    string item = ff.Id_Usuario + " | " + regional + " | " + ff.Programa + " | Floración | " + ff.Floracion + " | " + ff.Reporte_Fecha_Inicio.ToShortDateString() + " al " + ff.Reporte_Fecha_Fin.ToShortDateString();
                    //DDLRegional.Items.Insert(index, item);
                    ddlDatosGrafica.Items.Insert(index, new ListItem(item, "0", true));
                    //**
                    floracion = floracion + ff.Floracion;
                    c_floracion++;
                }
            }
            if (c_floracion != 0)
            {
                t_floracion = floracion / c_floracion;
            }
            d_totales.Add("FloracionSemana" + Count, t_floracion);
            //GRANO
            foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ff in ColGraficaFinalAsc)
            {
                if (ff.Grano != Convert.ToDecimal("0"))
                {
                    //**
                    int index = 0;
                    string regional = string.Empty;
                    if (Lista.Count != 0)
                    {
                        regional = Lista.Where(x => x.Id_Regional == ff.Id_Regional).FirstOrDefault().Nombre;
                    }
                    else
                    {
                        regional = ff.Id_Regional.ToString();
                    }
                    string item = ff.Id_Usuario + " | " + regional + " | " + ff.Programa + " | Llenado_Grano | " + ff.Grano + " | " + ff.Reporte_Fecha_Inicio.ToShortDateString() + " al " + ff.Reporte_Fecha_Fin.ToShortDateString();
                    //DDLRegional.Items.Insert(index, item);
                    ddlDatosGrafica.Items.Insert(index, new ListItem(item, "0", true));
                    //**
                    grano = grano + ff.Grano;
                    c_grano++;
                }
            }
            if (c_grano != 0)
            {
                t_grano = grano / c_grano;
            }
            d_totales.Add("GranoSemana" + Count, t_grano);

            //MADURACION
            foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ff in ColGraficaFinalAsc)
            {
                if (ff.Maduracion != Convert.ToDecimal("0"))
                {
                    //**
                    int index = 0;
                    string regional = string.Empty;
                    if (Lista.Count != 0)
                    {
                        regional = Lista.Where(x => x.Id_Regional == ff.Id_Regional).FirstOrDefault().Nombre;
                    }
                    else
                    {
                        regional = ff.Id_Regional.ToString();
                    }
                    string item = ff.Id_Usuario + " | " + regional + " | " + ff.Programa + " | Maduración | " + ff.Maduracion + " | " + ff.Reporte_Fecha_Inicio.ToShortDateString() + " al " + ff.Reporte_Fecha_Fin.ToShortDateString();
                    //DDLRegional.Items.Insert(index, item);
                    ddlDatosGrafica.Items.Insert(index, new ListItem(item, "0", true));
                    //**
                    maduracion = maduracion + ff.Maduracion;
                    c_maduracion++;
                }
            }
            if (c_maduracion != 0)
            {
                t_maduracion = maduracion / c_maduracion;
            }
            d_totales.Add("MaduracionSemana" + Count, t_maduracion);            
                       
            Dic_Totales = d_totales;
            decimal[] arrayProm_Av_Cocecha = new decimal[8];
                      
            int Count2 = 0;
            foreach (KeyValuePair<string, decimal> pair in d_totales)
            {                
                //arrayProm_Av_Cocecha[Count2] = pair.Value;
                string val = string.Format("{0:n2}", (Math.Truncate(pair.Value * 100) / 100));
                arrayProm_Av_Cocecha[Count2] = Convert.ToDecimal(val);
                Count2++;                
            }            
            //ddlDatosGrafica.Items.Clear();
            //DB_Regional reg = new DB_Regional();
            //List<Regional> Lista = reg.DB_Desplegar_REGIONAL();            
            //List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColGraficaFinalAsc = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();            
            //ColGraficaFinalAsc = ColGraficaFinal.OrderBy(x => x.Reporte_Fecha_Inicio).ToList();            

            ////**llenamos ddlDatosGrafica, el detalle para saber q valores carga en el grafico
            //foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica res in ColGraficaFinalAsc)
            //{
            //    int index = 0;
            //    string regional = string.Empty;
            //    if (Lista.Count != 0)
            //    {
            //        regional = Lista.Where(x => x.Id_Regional == res.Id_Regional).FirstOrDefault().Nombre;
            //    }
            //    else
            //    {
            //        regional = res.Id_Regional.ToString();
            //    }
            //    string item = res.Id_Usuario + " | " + regional + " | " + res.Programa + " | " + res.PromedioAvanceCosecha + " | " + res.Reporte_Fecha_Inicio.ToShortDateString() + " al " + res.Reporte_Fecha_Fin.ToShortDateString();
            //    //DDLRegional.Items.Insert(index, item);
            //    ddlDatosGrafica.Items.Insert(index, new ListItem(item, "0", true));
            //}
            string sseleccionada = ddlSemanas.SelectedItem.Text;
            string ruta = "../Viaticos/repDFGraficoSemanas.aspx?s1=" + arrayProm_Av_Cocecha[0].ToString() + "&s2=" + arrayProm_Av_Cocecha[1].ToString() +
                "&s3=" + arrayProm_Av_Cocecha[2].ToString() + "&s4=" + arrayProm_Av_Cocecha[3].ToString() + "&s5=" + arrayProm_Av_Cocecha[4].ToString() +
                "&s6=" + arrayProm_Av_Cocecha[5].ToString() + "&s7=" + arrayProm_Av_Cocecha[6].ToString() + "&s8=" + arrayProm_Av_Cocecha[7].ToString() +
                "&ss=" + sseleccionada;// +"&s10=" + arrayProm_Av_Cocecha[9].ToString() + "&s11=" + arrayProm_Av_Cocecha[10].ToString() +
                //"&s12=" + arrayProm_Av_Cocecha[11].ToString() + "&s13=" + arrayProm_Av_Cocecha[12].ToString() + "&s14=" + arrayProm_Av_Cocecha[13].ToString() + 
                //"&s15=" + arrayProm_Av_Cocecha[14].ToString() + "&s16=" + arrayProm_Av_Cocecha[15].ToString() + "&s17=" + arrayProm_Av_Cocecha[16].ToString() +
                //"&s18=" + arrayProm_Av_Cocecha[17].ToString() + "&s19=" + arrayProm_Av_Cocecha[18].ToString() + "&s20=" + arrayProm_Av_Cocecha[19].ToString();
            iframe1.Attributes.Add("src", ruta);

        }
        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Get_Est_FenologiaxSemanas();                
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }

        }
        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                Get_Est_FenologiaxSemanas();               

            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }

        protected void ddlSemanas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Get_Est_FenologiaxSemanas();

            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        private void Get_Semanas()
        {
            int Count = 0;
            DB_EXT_Seguimiento Seg_ = new DB_EXT_Seguimiento();
            DataTable DT_GetRepF = new DataTable();
            DT_GetRepF = Seg_.DB_GET_ETAPAS_FASE_FENOLOGICA();

            var distinctRows = (from DataRow dRow in DT_GetRepF.Rows
                                select new { col1 = dRow["Reporte_Fecha_Inicio"], col2 = dRow["Reporte_Fecha_Fin"] }).Distinct();

            var distinctRowsAsc = distinctRows.OrderBy(x => x.col1);
            ddlSemanas.Items.Clear();
            ddlSemanas.Items.Insert(0, new ListItem("Seleccione Semana", "0", true));
            foreach (var rowfechas in distinctRowsAsc)
            {
                Count++;
                string value1 = rowfechas.col1.ToString();
                string value2 = rowfechas.col2.ToString();
                //*** llenamos las semanas                 
                //int isaux = indexsemana + 1;
                if (Count > 20)
                {
                    lblMensaje.Text = "Se supero el rango de 20 Semanas";
                    return;
                }
                else
                {
                    string item = "Semana " + Count + "(del " + Convert.ToDateTime(value1).ToShortDateString() + " al " + Convert.ToDateTime(value2).ToShortDateString() + ")";
                    string fecha = value1 + "|" + value2;
                    ddlSemanas.Items.Insert(Count, new ListItem(item, fecha, true));
                }
                //indexsemana++;
            }
        }
    }
}