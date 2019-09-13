using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using DataBusiness.DB_Extensiones;
using DataBusiness.DB_General;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;
using System.Web.UI.HtmlControls;

namespace WebAplication.Control
{
    public partial class repCronogramaSegAvance : System.Web.UI.Page
    {
        private bool ConReporte
        {
            get
            {
                if (ViewState["ConReporte"] != null)
                    return (bool)ViewState["ConReporte"];

                return false;
            }
            set { ViewState["ConReporte"] = value; }
        }
        private DataTable CronogramaReporte
        {
            get
            {
                if (ViewState["CronogramaReporte"] != null)
                    return (DataTable)ViewState["CronogramaReporte"];

                return new DataTable();
            }
            set { ViewState["CronogramaReporte"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdCrono.Text = Session["IdCrono"].ToString();
                    LblIdUser.Text = Session["IdUser"].ToString();
                    Llenar_DDLRegional();
                    Desplegar_LISTA_CRONOGRAMAS();

                }
                if (ConReporte)
                    if (hf1.Value != "false")
                        CargarDatos();
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        string fechas = "dd/mm/aaaa";
        #region FUNCION PARA DESPLEGAR LA LISTDE LOS CRONOGRAMS
        private void Llenar_DDLRegional()
        {
            DB_AdminUser User = new DB_AdminUser();
            DataTable dt = User.DB_Desplegar_USUARIO(LblIdUser.Text);
            LblUser.Text = dt.Rows[0][1].ToString();
            LblRegional.Text = dt.Rows[0][5].ToString();
            LblIdReg.Text = dt.Rows[0][4].ToString();

            
        }
        protected void Desplegar_LISTA_CRONOGRAMAS()
        {
            try
            {
                DB_EXT_Cronogramas ListC = new DB_EXT_Cronogramas();
                //DataTable Conograma = ListC.DB_Desplegar_LISTA_CRONOGRAMAS("", Convert.ToInt32(LblIdCrono.Text), 0, "CRONOGRAMAS_PERSONAL");
                DataTable CronogramaAvance = ListC.DB_Desplegar_LISTA_ACTIVIDADES_CRONOGRAMA(Convert.ToInt32(LblIdCrono.Text));               
                DataTable CronogramaAvanceFiltrado = new DataTable();
                
                CronogramaAvanceFiltrado.Columns.Add("Personal");
                CronogramaAvanceFiltrado.Columns.Add("Regional");
                CronogramaAvanceFiltrado.Columns.Add("Fecha");
                CronogramaAvanceFiltrado.Columns.Add("Tema");
                CronogramaAvanceFiltrado.Columns.Add("Organizaciones");
                CronogramaAvanceFiltrado.Columns.Add("Resultado");
                CronogramaAvanceFiltrado.Columns.Add("Transporte");
                CronogramaAvanceFiltrado.Columns.Add("FVerificacion");
                CronogramaAvanceFiltrado.Columns.Add("Observacion");
                foreach (DataRow row in CronogramaAvance.Rows)
                {
                    decimal avance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                    if (avance < 100)
                    {                        
                        
                        DataRow fila = CronogramaAvanceFiltrado.NewRow();
                        string org = row["TareaDia"].ToString();
                        fila["Personal"] = LblUser.Text;
                        fila["Personal"] = LblUser.Text;
                        fila["Regional"] = LblRegional.Text;
                        fila["Fecha"] = row["FechaDia"].ToString();
                        //** TareaDia <<desglose>>
                        if (org.Contains("(MOV)") == true)
                        {
                            String value = row["TareaDia"].ToString();
                            Char delimiter = '|';
                            String[] Colstrings = value.Split(delimiter);
                            foreach (var substring in Colstrings)
                            {              
                                if (substring.Contains("(ORG)") == true)
                                {
                                    fila["Organizaciones"] = substring.ToString();// row["TareaDia"].ToString();
                                }
                                else
                                {
                                    if (substring.Contains("(MOV)") == true)
                                    {
                                        fila["Transporte"] = substring.ToString();//row["TareaDia"].ToString();
                                    }
                                    else
                                    {
                                        fila["Tema"] = substring.ToString();//row["TareaDia"].ToString();
                                    }
                                }                                
                            }  
                        }
                        else
                        if (org.Contains("(ORG)") == true)
                        {
                            fila["Organizaciones"] = row["TareaDia"].ToString();                            
                        }
                        else
                        {
                            //if (org.Contains("(MOV)") == true)
                            //{                                                             
                            //   fila["Transporte"] = row["TareaDia"].ToString();
                            //}
                            //else
                            //{
                                fila["Tema"] = row["TareaDia"].ToString();    
                            //}
                        }
                        //**
                        fila["Resultado"] = row["ObservacionAvance"].ToString();
                        fila["FVerificacion"] = row["FuenteVerificacion"].ToString();
                        fila["Observacion"] = row["Observaciones"].ToString();
                        CronogramaAvanceFiltrado.Rows.Add(fila);
                        
                    }                    
                }              
                CronogramaReporte = CronogramaAvanceFiltrado;
                GVCronogramas.DataSource = CronogramaAvanceFiltrado;                
                GVCronogramas.DataBind();
                //MergeRows(GVCronogramas);
               ;

            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
        }        
        protected void btnExportExcel_Click(object sender, ImageClickEventArgs e)
        {
            ConReporte = true;
            mvUsuarios.ActiveViewIndex = 1;
            CargarDatos();    
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            mvUsuarios.ActiveViewIndex = 0;
            ConReporte = false;
        }
        //*****
        private void CargarDatos()
        {
            string rutaArchivo = "~/Reportes/RepCronograma.xml";
            C1WebReport1.ReportSource.FileName = Server.MapPath(rutaArchivo);
            C1WebReport1.ReportSource.ReportName = "ReporteMain";
            C1WebReport1.Cache.Enabled = false;
            C1WebReport1.Cache.Expiration = 1;

            //DataTable DTUsuarios = new DataTable();
            //DTUsuarios.Columns.Add("IdUsuario", typeof(string));
            //DTUsuarios.Columns.Add("Nombre", typeof(string));
            //DTUsuarios.Columns.Add("ApellidoPaterno", typeof(string));
            //DTUsuarios.Columns.Add("ApellidoMaterno", typeof(string));
            //DTUsuarios.Columns.Add("CI", typeof(string));
            //DTUsuarios.Columns.Add("fecha", typeof(string));

            //foreach (Usuarios row in ColUsuarios)
            //{
            //    DTUsuarios.Rows.Add(row.IdUsuario.ToString(), row.Nombre, row.ApellidoPaterno, row.ApellidoMaterno, row.CI, row.fecha.ToShortDateString());
            //    //ColAuditoriaDto.Add(ObjAuditoriaDto);
            //}
            int count = 0;
            int ultimo = GVCronogramas.Rows.Count - 1;
            string dia1 = "";
            foreach (GridViewRow row in GVCronogramas.Rows)
            {                   
                if (count == 0)
                {
                    DateTime f1 = Convert.ToDateTime(row.Cells[2].Text);
                    dia1 = f1.Day.ToString();
                }                
                
                if (count == ultimo)
                {
                    DateTime f2 = Convert.ToDateTime(row.Cells[2].Text);
                    fechas = dia1+ " Al " + f2.ToShortDateString();
                }
                count++;
            }
             
            C1WebReport1.Report.Fields["Field4"].Value = fechas;
            C1WebReport1.Report.Fields["fieldTitulo"].Text = "REGIONAL " + Convert.ToString(LblRegional.Text).ToUpper();
            C1WebReport1.Report.Fields["subRepCalificaciones"].Subreport.DataSource.Recordset = CronogramaReporte;
        }
        private void MergeRows(GridView gridView)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                for (int i = 0; i < 2; i++)
                {
                    if (row.Cells[i].Text == previousRow.Cells[i].Text)
                    {
                        row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
                        previousRow.Cells[i].RowSpan + 1;
                        previousRow.Cells[i].Visible = false;
                    }
                }
            }
        }

        #endregion

        protected void GVCronogramas_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    GridView HeaderGrid = (GridView)sender;
            //    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            //    TableCell HeaderCell = new TableCell();
            //    HeaderCell.Text = "";
            //    HeaderCell.ColumnSpan = 1;
            //    HeaderGridRow.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    string fecha1 = Cronograma.Rows[0]["FechaLunes"].ToString();
            //    HeaderCell.Text = "<div style='text-align: center'>Lunes(" + fecha1 + ")</div>";
            //    HeaderCell.ColumnSpan = 1;
            //    HeaderGridRow.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    string fecha2 = Cronograma.Rows[0]["FechaMartes"].ToString();
            //    HeaderCell.Text = "<div style='text-align: center'>Martes(" + fecha2 + ")</div>";
            //    HeaderCell.ColumnSpan = 1;
            //    HeaderGridRow.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    string fecha3 = Cronograma.Rows[0]["FechaMiercoles"].ToString();
            //    HeaderCell.Text = "<div style='text-align: center'>Miercoles(" + fecha3 + ")</div>";
            //    HeaderCell.ColumnSpan = 1;
            //    HeaderGridRow.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    string fecha4 = Cronograma.Rows[0]["FechaJueves"].ToString();
            //    HeaderCell.Text = "<div style='text-align: center'>Jueves(" + fecha4 + ")</div>";
            //    HeaderCell.ColumnSpan = 1;
            //    HeaderGridRow.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    string fecha5 = Cronograma.Rows[0]["FechaViernes"].ToString();
            //    HeaderCell.Text = "<div style='text-align: center'>Viernes(" + fecha5 + ")</div>";
            //    HeaderCell.ColumnSpan = 1;
            //    HeaderGridRow.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    string fecha6 = Cronograma.Rows[0]["FechaSabado"].ToString();
            //    HeaderCell.Text = "<div style='text-align: center'>Sabado(" + fecha6 + ")</div>";
            //    HeaderCell.ColumnSpan = 1;
            //    HeaderGridRow.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    string fecha7 = Cronograma.Rows[0]["FechaDomingo"].ToString();
            //    HeaderCell.Text = "<div style='text-align: center'>Domingo(" + fecha7 + ")</div>";
            //    HeaderCell.ColumnSpan = 1;
            //    HeaderGridRow.Cells.Add(HeaderCell);

            //    GVCronogramas.Controls[0].Controls.AddAt(0, HeaderGridRow);
            //}            
        }

        protected void GVCronogramas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    string Porcentaje = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PorcentajeAvance"));
            //    if (Porcentaje != string.Empty)
            //    {
            //        ((TextBox)e.Row.FindControl("txtAvance")).Text = Porcentaje;
            //    }
            //    string ObsAv = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ObservacionAvance"));
            //    if (ObsAv != "")
            //    {
            //        ((TextBox)e.Row.FindControl("txtObsAvance")).Text = ObsAv;
            //    }
            //    string Fuente = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FuenteVerificacion"));
            //    ((TextBox)e.Row.FindControl("txtFuenteVerificacion")).Text = Fuente;

            //    string ObsGeneral = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Observaciones"));
            //    ((TextBox)e.Row.FindControl("txtObservaciones")).Text = ObsGeneral;


            //}
        }
        
    }
}