using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using DataBusiness.DB_Extensiones;

namespace WebAplication.Control
{
    public partial class repCronogramaSeg : System.Web.UI.Page
    {
        private DataTable Cronograma
        {
            get
            {
                if (ViewState["Cronograma"] != null)
                    return (DataTable)ViewState["Cronograma"];

                return new DataTable();
            }
            set { ViewState["Cronograma"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                if (!IsPostBack)
                {
                    LblIdCrono.Text = Session["IdCrono"].ToString();
                    Desplegar_LISTA_CRONOGRAMAS();

                }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        #region FUNCION PARA DESPLEGAR LA LISTDE LOS CRONOGRAMS
        protected void Desplegar_LISTA_CRONOGRAMAS()
        {
            DB_EXT_Cronogramas ListC = new DB_EXT_Cronogramas();
            DataTable dt = new DataTable();
            dt = ListC.DB_Desplegar_LISTA_CRONOGRAMAS("", Convert.ToInt32(LblIdCrono.Text), 0,"CRONOGRAMAS_PERSONAL");
            LblMes.Text = dt.Rows[0][17].ToString();
            LblPersonal.Text = dt.Rows[0][15].ToString();
            LblRegional.Text = dt.Rows[0][19].ToString();
            //GVCronogramas.DataSource = ListC.DB_Desplegar_LISTA_CRONOGRAMAS("", Convert.ToInt32(LblIdCrono.Text), 0, "CRONOGRAMAS_PERSONAL");
            Cronograma = ListC.DB_Desplegar_LISTA_CRONOGRAMAS("", Convert.ToInt32(LblIdCrono.Text), 0, "CRONOGRAMAS_PERSONAL");
            GVCronogramas.DataSource = Cronograma;
            GVCronogramas.DataBind();
        }
        #endregion

        protected void GVCronogramas_RowCreated(object sender, GridViewRowEventArgs e)
        {
            ///******BORRAR            
            //foreach (DataRow row in  Cronograma.Rows)
            //{
            //  string fecha_1 = row["FechaLunes"].ToString();                         
            //}
            ///
            //if(GVCronogramas.Rows.Count > 0)
            //{ 
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridView HeaderGrid = (GridView)sender;
                    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                    TableCell HeaderCell = new TableCell();                                
                    HeaderCell.Text = "";
                    HeaderCell.ColumnSpan = 1;
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    string fecha1 = Cronograma.Rows[0]["FechaLunes"].ToString();
                    HeaderCell.Text = "<div style='text-align: center'>Lunes("+ fecha1 +")</div>";
                    HeaderCell.ColumnSpan = 1;
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    string fecha2 = Cronograma.Rows[0]["FechaMartes"].ToString();
                    HeaderCell.Text = "<div style='text-align: center'>Martes("+ fecha2+")</div>";
                    HeaderCell.ColumnSpan = 1;
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    string fecha3 = Cronograma.Rows[0]["FechaMiercoles"].ToString();
                    HeaderCell.Text = "<div style='text-align: center'>Miercoles(" + fecha3+")</div>";
                    HeaderCell.ColumnSpan = 1;
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    string fecha4 = Cronograma.Rows[0]["FechaJueves"].ToString();
                    HeaderCell.Text = "<div style='text-align: center'>Jueves(" + fecha4 + ")</div>";
                    HeaderCell.ColumnSpan = 1;
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    string fecha5 = Cronograma.Rows[0]["FechaViernes"].ToString();
                    HeaderCell.Text = "<div style='text-align: center'>Viernes(" + fecha5 + ")</div>";
                    HeaderCell.ColumnSpan = 1;
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    string fecha6 = Cronograma.Rows[0]["FechaSabado"].ToString();
                    HeaderCell.Text = "<div style='text-align: center'>Sabado(" + fecha6 + ")</div>";
                    HeaderCell.ColumnSpan = 1;
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    string fecha7 = Cronograma.Rows[0]["FechaDomingo"].ToString();
                    HeaderCell.Text = "<div style='text-align: center'>Domingo(" + fecha7 + ")</div>";
                    HeaderCell.ColumnSpan = 1;
                    HeaderGridRow.Cells.Add(HeaderCell);

                    GVCronogramas.Controls[0].Controls.AddAt(0, HeaderGridRow);
                }
            //}
        }

        protected void GVCronogramas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //string aux = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FechaLunes")); lrojas
            //DB_RegionesApoyadas ListRegCamp = new DB_RegionesApoyadas();
            //DB_EXT_Fenologia Luis = new DB_EXT_Fenologia();
            //DB_EXT_Rendimiento ex = new DB_EXT_Rendimiento();
            //DataTable dt = new DataTable();
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    int IdInsOrg = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_InscripcionOrg").ToString());
            //    int IdComunidad = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Municipio").ToString());
            //    /*****************************/
            //    dt = Luis.DB_Seleccionar_NUMPROD_TOTSUP(IdInsOrg, IdComunidad);
            //    ((Label)e.Row.FindControl("LblNumBenefVig")).Text = dt.Rows[0][0].ToString();
            //    ((Label)e.Row.FindControl("LblSupApoyada")).Text = dt.Rows[0][1].ToString();

            //    dt = ex.DB_Reporte_DETALLE_PLANILLA(IdInsOrg, "", "", "RENDIMIENTO_PROMEDIO");
            //    ((Label)e.Row.FindControl("LblRendimiento")).Text = dt.Rows[0][0].ToString();
            //    try
            //    {
            //        ((Label)e.Row.FindControl("LblProdEstim")).Text = (Convert.ToDecimal(((Label)e.Row.FindControl("LblSupApoyada")).Text) * Convert.ToDecimal(((Label)e.Row.FindControl("LblRendimiento")).Text)).ToString();
            //    }
            //    catch
            //    {
            //        ((Label)e.Row.FindControl("LblProdEstim")).Text = "0";
            //    }
            //}
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    LblValor.Text = (LblAux.Text.Length).ToString();
        //    string aux = "";
        //    for (int i = 0; i < LblAux.Text.Length; i++)
        //    {
        //        if(){}else
        //    }
        //}
    }
}