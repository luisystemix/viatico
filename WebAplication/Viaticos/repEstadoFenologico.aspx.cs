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
    public partial class repEstadoFenologico : System.Web.UI.Page
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
                    Get_Est_FenologiaxSemanas();
                }
                //Seleccionar_REGION();
                //Obtener_Numero_ORG_PROD();
                //Desplegar_MUESTRAS_REGISTRADAS();
            }
        }
        private void Llenar_DDLRegional()
        {
            DB_AdminUser User = new DB_AdminUser();
            DataTable dt = User.DB_Desplegar_USUARIO(LblIdUsuario.Text);
            //LblReg.Text = dt.Rows[0][13].ToString();
            if (Convert.ToInt32(dt.Rows[0][6].ToString()) == 15 || Convert.ToInt32(dt.Rows[0][6].ToString()) == 5)
            {
                DDLRegional.Items.Insert(0, new ListItem(dt.Rows[0][5].ToString(), dt.Rows[0][4].ToString(), true));
                DDLRegional.Enabled = false;
            }
            else
            {
                DB_Regional reg = new DB_Regional();
                List<Regional> Lista = reg.DB_Desplegar_REGIONAL();
                DDLRegional.DataSource = Lista;
                DDLRegional.DataValueField = "Id_Regional";
                DDLRegional.DataTextField = "Nombre";
                DDLRegional.DataBind();
                DDLRegional.Items.Insert(0, new ListItem("Seleccione la Regional", "0", true));
            }
        }
        private void Get_Est_FenologiaxSemanas()
        {
            int Count = 0;
            DB_EXT_Seguimiento Seg_ = new DB_EXT_Seguimiento();
            DataTable DT_GetRepF = new DataTable();
            DT_GetRepF = Seg_.DB_GET_REP_EST_FENOLOGICO();            
            //cabeceras de reporte
            //t2.Id_Usuario, t2.Reporte_Fecha_Inicio, t2.Reporte_Fecha_Fin, t2.Id_Regional, t2.Programa, t2.PromedioAvanceCosecha
            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColGrafica = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColGraficaFinal = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
            foreach (DataRow row in DT_GetRepF.Rows)
            {
                EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ObjGrafico = new EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica();
                ObjGrafico.Id_Usuario = row["Id_Usuario"].ToString();
                ObjGrafico.Reporte_Fecha_Inicio = Convert.ToDateTime(row["Reporte_Fecha_Inicio"].ToString());
                ObjGrafico.Reporte_Fecha_Fin = Convert.ToDateTime(row["Reporte_Fecha_Fin"].ToString());
                ObjGrafico.Id_Regional = Convert.ToInt32(row["Id_Regional"].ToString());
                ObjGrafico.Programa = row["Programa"].ToString();
                ObjGrafico.PromedioAvanceCosecha = Convert.ToDecimal(row["PromedioAvanceCosecha"].ToString());
                ColGrafica.Add(ObjGrafico);

            }
            ////**>>PRUEBA DE AMPLIACION EN REGIONALES lrojas:30/11/2016
            DB_Regional r_ = new DB_Regional();
            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColGraficaFinalConAmpliaciones = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
            List<Regional> ColAmpliaciones = new List<Regional>();
            if (DDLRegional.SelectedValue != "0")
            {
                List<Regional> ColRegionales = r_.DB_Desplegar_REGIONAL();
                ColAmpliaciones = ColRegionales.Where(x => x.IdRegional_Padre == Convert.ToInt32(DDLRegional.SelectedValue)
                                                                   || x.Id_Regional == Convert.ToInt32(DDLRegional.SelectedValue)).ToList();
                
                foreach (Regional reg in ColAmpliaciones)
                {
                    foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica res in ColGrafica)
                    {
                        EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica ObjSeg = new EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica();
                        if (res.Id_Regional == reg.Id_Regional)
                        {
                            ColGraficaFinalConAmpliaciones.Add(res);
                        }
                    }
                }
            }
            ////**>>
            //*>por defector carga todo lrojas:30/11/2016
            if (ColAmpliaciones.Count > 1)
            {                
                ColGraficaFinal = ColGraficaFinalConAmpliaciones.Where(x => x.PromedioAvanceCosecha > 0).ToList();
            }
            else
            {
                ColGraficaFinal = ColGrafica.Where(x => x.PromedioAvanceCosecha > 0).ToList();//OLD
            }
            //*>

            //ColGraficaFinal = ColGrafica.Where(x=>x.PromedioAvanceCosecha > 0).ToList();//OLD
            //*>*apliacacion de filtros segun seleccion lrojas:30/11/2016
            if (DDLRegional.SelectedValue != "0")
            {               
                if (DDLPrograma.SelectedValue != "0")
                {
                    if (ColAmpliaciones.Count > 1)// si existen ampliaciones de Regionales se  realiza filtro a ColGraficaFinalConAmpliaciones
                    {                        
                        ColGraficaFinal = ColGraficaFinalConAmpliaciones.Where(x => x.Programa == DDLPrograma.SelectedValue && x.PromedioAvanceCosecha > 0).ToList();
                    }
                    else// si no existen ampliaciones de regionales se realiza un filtro a ColGrafica
                    {
                        ColGraficaFinal = ColGrafica.Where(x => x.Id_Regional == Convert.ToInt32(DDLRegional.SelectedValue)
                                                    && x.Programa == DDLPrograma.SelectedValue && x.PromedioAvanceCosecha > 0).ToList();//old
                    }
                }
                else
                {                                   
                    if(ColAmpliaciones.Count > 1)
                    {                       
                        ColGraficaFinal = ColGraficaFinalConAmpliaciones.Where(x => x.PromedioAvanceCosecha > 0).ToList();
                    }
                    else
                    {
                        ColGraficaFinal = ColGrafica.Where(x => x.Id_Regional == Convert.ToInt32(DDLRegional.SelectedValue) && x.PromedioAvanceCosecha > 0).ToList();//old
                    }   
                }
            }
            else
            {
                if (DDLPrograma.SelectedValue != "0")
                {
                    ColGraficaFinal = ColGrafica.Where(x => x.Programa == DDLPrograma.SelectedValue && x.PromedioAvanceCosecha > 0).ToList();
                }
            }
            //*>*
            var distinctRows = (from DataRow dRow in DT_GetRepF.Rows
                          where (decimal)dRow["PromedioAvanceCosecha"] > 0
                          select new { col1 = dRow["Reporte_Fecha_Inicio"], col2 = dRow["Reporte_Fecha_Fin"]}).Distinct();
            //**
            //var distinctRows = (from DataRow dRow in DT_GetRepF.Rows
            //                    select new { col1 = dRow["Reporte_Fecha_Inicio"], col2 = dRow["Reporte_Fecha_Fin"] }).Distinct();   
            
            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColGraficaFiltrada = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
            //var ColGraficaFiltrada23 = ColGrafica.GroupBy(x => x.Reporte_Fecha_Inicio).Select(lg => new
            //                    {
            //                        Owner = lg.Key,
            //                        Boxes = lg.Count(),
            //                        TotalWeight = lg.Sum(w => w.PromedioAvanceCosecha),
            //                        TotalVolume = lg.Sum(w => w.PromedioAvanceCosecha)
            //                    });
            var distinctRowsAsc = distinctRows.OrderBy(x => x.col1);
            Dictionary<string, decimal> d_totales = new Dictionary<string, decimal>();
            //int indexsemana = 0;
            ddlSemanas.Items.Clear();
            foreach (var rowfechas in distinctRowsAsc)
            {
                Count++;
                string value1 = rowfechas.col1.ToString();
                string value2 = rowfechas.col2.ToString();
                //var ww = (from DataRow dRow in DT_GetRepF.Rows
                //                    select new { col1 = dRow["Reporte_Fecha_Inicio"], col2 = dRow["Reporte_Fecha_Fin"] }).Distinct();
                ColGraficaFiltrada = ColGraficaFinal.Where(x => x.Reporte_Fecha_Inicio == Convert.ToDateTime(value1) && x.Reporte_Fecha_Fin == Convert.ToDateTime(value2)).ToList();
                decimal sum = Convert.ToDecimal(ColGraficaFiltrada.Sum(x => x.PromedioAvanceCosecha).ToString());
                int cantidad = ColGraficaFiltrada.Count();
                decimal total = 0;
                if (cantidad != 0)
                {
                    total = sum / cantidad;
                }                
                d_totales.Add("Semana"+Count, total);
                //*** llenamos las semanas                 
                //int isaux = indexsemana + 1;
                string item = "Semana " + Count + "(del " + Convert.ToDateTime(value1).ToShortDateString() + " al " + Convert.ToDateTime(value2).ToShortDateString() + ")";
                ddlSemanas.Items.Insert(Count-1, new ListItem(item, "0", true));
                //indexsemana++;
            }
            //foreach (KeyValuePair<string, decimal> pair in d_totales)
            //{
            //    Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
            //}
            Dic_Totales = d_totales;
            decimal[] arrayProm_Av_Cocecha = new decimal[12];
            //arrayProm_Av_Cocecha[0] = "Socrates";
            //arrayProm_Av_Cocecha[1] = "Plato";            
            int Count2 = -1;
            foreach (KeyValuePair<string, decimal> pair in d_totales)
            {
                Count2++;

                //arrayProm_Av_Cocecha[Count2] = pair.Value;
                string val = string.Format("{0:n2}", (Math.Truncate(pair.Value * 100) / 100));
                arrayProm_Av_Cocecha[Count2] = Convert.ToDecimal(val);
                //arrayProm_Av_Cocecha[1] = "Plato";
                // Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
            }
            //for (int i = 0; i >= arrayProm_Av_Cocecha.Count() - 1; i++)
            //{
            //    var item = arrayProm_Av_Cocecha.ElementAt(i);
            //    var itemKey = item.Key;
            //    var itemValue = item.Value;
            //}

            //t2.Id_Usuario, t2.Reporte_Fecha_Inicio, t2.Reporte_Fecha_Fin, t2.Id_Regional, t2.Programa, t2.PromedioAvanceCosecha
            //DDLRegional.DataSource = ColGrafica;
            //DDLRegional.DataValueField = "Id_Usuario";
            //DDLRegional.DataTextField = "Id_Usuario" + "|" + "Id_Regional" + "|" + "Programa" + "|" + "PromedioAvanceCosecha";
            //DDLRegional.DataBind();
            ddlDatosGrafica.Items.Clear();
            DB_Regional reg_a = new DB_Regional();
            List<Regional> Lista = reg_a.DB_Desplegar_REGIONAL();
            //ddlDatosGrafica.Items.Insert(0, new ListItem("Usuario|Regional|Programa|PromedioAvanceCosecha", "0", true));
            List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColGraficaFinalAsc = new List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica>();
            ColGraficaFinalAsc= ColGraficaFinal.OrderBy(x => x.Reporte_Fecha_Inicio).ToList();
            //**llenamos ddlDatosGrafica, el detalle para saber q valores carga en el grafico
            foreach (EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica res in ColGraficaFinalAsc)
            {
                int index = 0;
                string regional = string.Empty;
                if (Lista.Count != 0)
                {
                    regional = Lista.Where(x => x.Id_Regional == res.Id_Regional).FirstOrDefault().Nombre;
                }
                else
                {
                    regional = res.Id_Regional.ToString();
                }                
                string item = res.Id_Usuario +" | "+regional+" | "+res.Programa+" | "+res.PromedioAvanceCosecha+" | "+res.Reporte_Fecha_Inicio.ToShortDateString()+" al "+res.Reporte_Fecha_Fin.ToShortDateString();
                //DDLRegional.Items.Insert(index, item);
                ddlDatosGrafica.Items.Insert(index, new ListItem(item, "0", true));
            }                        
            //foreach (KeyValuePair<string, decimal> pair in d_totales)
            //{
            //    Count2++;

            //    //arrayProm_Av_Cocecha[Count2] = pair.Value;
            //    string val = string.Format("{0:n2}", (Math.Truncate(pair.Value * 100) / 100));
            //    arrayProm_Av_Cocecha[Count2] = Convert.ToDecimal(val);
            //    //arrayProm_Av_Cocecha[1] = "Plato";
            //    // Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
            //}
            string ruta = "../Viaticos/repEFGrafico.aspx?s1=" + arrayProm_Av_Cocecha[0].ToString() + "&s2=" + arrayProm_Av_Cocecha[1].ToString() +
                "&s3=" + arrayProm_Av_Cocecha[2].ToString() + "&s4=" + arrayProm_Av_Cocecha[3].ToString() + "&s5=" + arrayProm_Av_Cocecha[4].ToString()+
                "&s6=" + arrayProm_Av_Cocecha[5].ToString() + "&s7=" + arrayProm_Av_Cocecha[6].ToString() + "&s8=" + arrayProm_Av_Cocecha[7].ToString()+
                "&s9=" + arrayProm_Av_Cocecha[8].ToString() + "&s10="+ arrayProm_Av_Cocecha[9].ToString() + "&s11=" + arrayProm_Av_Cocecha[10].ToString()+
                "&s12=" + arrayProm_Av_Cocecha[11].ToString();
            iframe1.Attributes.Add("src", ruta); 
  
        }
        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (DDLRegional.SelectedValue == "0")
                //{
                //    return;
                //}
                //else
                //{
                    Get_Est_FenologiaxSemanas();
                //}
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
                //if (DDLPrograma.SelectedValue == "0")
                //{                    
                //    return;
                //}
                //else
                //{
                    Get_Est_FenologiaxSemanas();
                //}
                
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ////ClientScript.RegisterStartupScript(this.GetType(), "myScript", "MostrarOcultarDiv();", true);
            //string script = string.Format("javascript:MostrarOcultarDiv('{0}')", "hola");
            //ScriptManager.RegisterStartupScript(Page, Page.ClientScript.GetType(), "MessageAlert", script, true);
            //lblS1.Text = txtDato.Text;

            int valS1 = Convert.ToInt32(txtDato.Text);
            int valS2 = valS1 + 5;
            //int valS3 = valS2 + 5;
            //int valS4 = valS3 + 5;
            //int valS5 = valS4 + 5;
            //string ruta = "../Viaticos/repEFGrafico.aspx?s1=" + valS1 + "&s2=" + valS2 + "&s3=" + valS3 + "&s4=" + valS4 + "&s5="+valS5;
            string ruta = "../Viaticos/repEFGrafico.aspx?s1=" + valS1+ "&s2="+ valS2;          
            iframe1.Attributes.Add("src", ruta);               
            //StringBuilder sbMensaje = new StringBuilder();
            //sbMensaje.Append("<script type='text/javascript'>");
            //sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repEFGrafico.aspx?s1=" + valS1);
            //sbMensaje.Append("</script>");
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
        }
    }
}