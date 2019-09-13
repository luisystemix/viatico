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
    public partial class repPpsemanalFenologia : System.Web.UI.Page
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
            try
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
            catch(Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
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
            if (DDLRegional.SelectedValue != "0")
            {
                if (DDLPrograma.SelectedValue != "0")
                {
                    //ColGraficaFinal = ColGrafica.Where(x => x.Id_Regional == Convert.ToInt32(DDLRegional.SelectedValue) && x.Programa == DDLPrograma.SelectedValue).ToList(); //OLD
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
                    //ColGraficaFinal = ColGrafica.Where(x => x.Id_Regional == Convert.ToInt32(DDLRegional.SelectedValue)).ToList();//OLD
                    //*>lrojas:02/12/2016
                    if (ColAmpliaciones.Count > 1)
                    {                        
                        ColGraficaFinal = ColGraficaFinalConAmpliaciones;
                    }
                    else
                    {
                        ColGraficaFinal = ColGrafica.Where(x => x.Id_Regional == Convert.ToInt32(DDLRegional.SelectedValue)).ToList();//OLD
                    }
                    //*>
                }
            }
            else
            {
                if (DDLPrograma.SelectedValue != "0")
                {
                    //ColGraficaFinal = ColGrafica.Where(x => x.Programa == DDLPrograma.SelectedValue).ToList(); //OLD
                    //*>lrojas:02/12/2016
                    if (ColAmpliaciones.Count > 1)
                    {                        
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
                    //*>lrojas:02/12/2016
                    if (ColAmpliaciones.Count > 1)
                    {
                        ColGraficaFinal = ColGraficaFinalConAmpliaciones;
                    }
                    else
                    {
                        ColGraficaFinal = ColGrafica;//OLD
                    }
                    //*>
                }
            }            

            var distinctRows = (from DataRow dRow in DT_GetRepF.Rows
                                select new { col1 = dRow["Reporte_Fecha_Inicio"], col2 = dRow["Reporte_Fecha_Fin"] }).Distinct();

            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColGraficaFiltrada = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();           
            var distinctRowsAsc = distinctRows.OrderBy(x => x.col1);

            if (distinctRowsAsc.Count() > 32)
            {
                lblMensaje.Text = "Se supero el rango de 32 Semanas(20s EstadoFenologico, 12s Cosecha)";
                return;
            }

            Dictionary<string, decimal> d_totales = new Dictionary<string, decimal>();    
        
            ddlSemanas.Items.Clear();
            foreach (var rowfechas in distinctRowsAsc)
            {                
                string value1 = rowfechas.col1.ToString();
                string value2 = rowfechas.col2.ToString();
                //var ww = (from DataRow dRow in DT_GetRepF.Rows
                //                    select new { col1 = dRow["Reporte_Fecha_Inicio"], col2 = dRow["Reporte_Fecha_Fin"] }).Distinct();
                ColGraficaFiltrada = ColGraficaFinal.Where(x => x.Reporte_Fecha_Inicio == Convert.ToDateTime(value1) && x.Reporte_Fecha_Fin == Convert.ToDateTime(value2)).ToList();
                decimal sum = Convert.ToDecimal(ColGraficaFiltrada.Sum(x => x.Ppsemanal).ToString());
                int cantidad = ColGraficaFiltrada.Count();
                decimal total = 0;
                if (cantidad != 0)
                {
                    total = sum / cantidad;
                }
                d_totales.Add("Semana" + Count, total);
                //*** llenamos las semanas                 
                //int isaux = indexsemana + 1;
                int mas1 = Count + 1;
                string item = "Semana " + mas1 + "(del " + Convert.ToDateTime(value1).ToShortDateString() + " al " + Convert.ToDateTime(value2).ToShortDateString() + ")";
                ddlSemanas.Items.Insert(Count, new ListItem(item, "0", true));
                Count++;
            }          
            Dic_Totales = d_totales;
            int rango = d_totales.Count();
            decimal[] array_Ppsemanal = new decimal[32];
            int Count2 = 0;
            foreach (KeyValuePair<string, decimal> pair in d_totales)
            {
                string val = string.Format("{0:n2}", (Math.Truncate(pair.Value * 100) / 100));
                array_Ppsemanal[Count2] = Convert.ToDecimal(val);
                Count2++;               
            }
            
            ddlDatosGrafica.Items.Clear();
            DB_Regional reg = new DB_Regional();
            List<Regional> Lista = reg.DB_Desplegar_REGIONAL();
            //ddlDatosGrafica.Items.Insert(0, new ListItem("Usuario|Regional|Programa|PromedioAvanceCosecha", "0", true));
            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColGraficaFinalAsc = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
            ColGraficaFinalAsc = ColGraficaFinal.OrderBy(x => x.Reporte_Fecha_Inicio).ToList();
            //**llenamos ddlDatosGrafica, el detalle para saber q valores carga en el grafico
            int aux = 0;
            foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica res in ColGraficaFinalAsc)
            {                
                string regional = string.Empty;
                if (Lista.Count != 0)
                {
                    regional = Lista.Where(x => x.Id_Regional == res.Id_Regional).FirstOrDefault().Nombre;
                }
                else
                {
                    regional = res.Id_Regional.ToString();
                }
                string item = res.Id_Usuario + " | " + regional + " | " + res.Programa + " | " + res.Ppsemanal + " | " + res.Reporte_Fecha_Inicio.ToShortDateString() + " al " + res.Reporte_Fecha_Fin.ToShortDateString();
                //DDLRegional.Items.Insert(index, item);
                ddlDatosGrafica.Items.Insert(aux, new ListItem(item, "0", true));
                aux++;
            }
            
            //string sseleccionada = ddlSemanas.SelectedItem.Text;
            string ruta = "../Viaticos/repPpsemanalGrafico.aspx?s1=" + array_Ppsemanal[0].ToString() + "&s2=" + array_Ppsemanal[1].ToString() +
                "&s3=" + array_Ppsemanal[2].ToString() + "&s4=" + array_Ppsemanal[3].ToString() + "&s5=" + array_Ppsemanal[4].ToString() +
                "&s6=" + array_Ppsemanal[5].ToString() + "&s7=" + array_Ppsemanal[6].ToString() + "&s8=" + array_Ppsemanal[7].ToString() +
                "&s9=" + array_Ppsemanal[8].ToString() + "&s10=" + array_Ppsemanal[9].ToString() + "&s11=" + array_Ppsemanal[10].ToString() +
                "&s12=" + array_Ppsemanal[11].ToString() + "&s13=" + array_Ppsemanal[12].ToString() + "&s14=" + array_Ppsemanal[13].ToString() +
                "&s15=" + array_Ppsemanal[14].ToString() + "&s16=" + array_Ppsemanal[15].ToString() + "&s17=" + array_Ppsemanal[16].ToString() +
                "&s18=" + array_Ppsemanal[17].ToString() + "&s19=" + array_Ppsemanal[18].ToString() + "&s20=" + array_Ppsemanal[19].ToString() +
                "&s21=" + array_Ppsemanal[20].ToString() + "&s22=" + array_Ppsemanal[21].ToString() + "&s23=" + array_Ppsemanal[22].ToString() +
                "&s24=" + array_Ppsemanal[23].ToString() + "&s25=" + array_Ppsemanal[24].ToString() + "&s26=" + array_Ppsemanal[25].ToString() +
                "&s27=" + array_Ppsemanal[26].ToString() + "&s28=" + array_Ppsemanal[27].ToString() + "&s29=" + array_Ppsemanal[28].ToString() +
                "&s30=" + array_Ppsemanal[29].ToString() + "&s31=" + array_Ppsemanal[30].ToString() + "&s32=" + array_Ppsemanal[31].ToString();
            
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
        
        protected void ddlSemanas_SelectedIndexChanged1(object sender, EventArgs e)
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
            //int Count = 0;
            //DB_EXT_Seguimiento Seg_ = new DB_EXT_Seguimiento();
            //DataTable DT_GetRepF = new DataTable();
            //DT_GetRepF = Seg_.DB_GET_ETAPAS_FASE_FENOLOGICA();

            //var distinctRows = (from DataRow dRow in DT_GetRepF.Rows
            //                    select new { col1 = dRow["Reporte_Fecha_Inicio"], col2 = dRow["Reporte_Fecha_Fin"] }).Distinct();

            //var distinctRowsAsc = distinctRows.OrderBy(x => x.col1);
            ddlSemanas.Items.Clear();
            ddlSemanas.Items.Insert(0, new ListItem("Seleccione Semana", "0", true));
            //foreach (var rowfechas in distinctRowsAsc)
            //{
            //    Count++;
            //    string value1 = rowfechas.col1.ToString();
            //    string value2 = rowfechas.col2.ToString();
            //    //*** llenamos las semanas                 
            //    //int isaux = indexsemana + 1;
            //    if (Count > 32)
            //    {
            //        lblMensaje.Text = "Se supero el rango de 32 Semanas(20s EstadoFenologico, 12s Cosecha)";
            //        return;
            //    }
            //    else
            //    {
            //        string item = "Semana " + Count + "(del " + Convert.ToDateTime(value1).ToShortDateString() + " al " + Convert.ToDateTime(value2).ToShortDateString() + ")";
            //        string fecha = value1 + "|" + value2;
            //        ddlSemanas.Items.Insert(Count, new ListItem(item, fecha, true));
            //    }
            //    //indexsemana++;
            //}
        }


    }
}