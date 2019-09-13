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
using DataEntity.DE_Registro;
using DataBusiness.DB_General;

namespace WebAplication.Control
{
    public partial class repFaceFenologica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            if (!IsPostBack)
            {
                LblIdUsuario.Text = Session["IdUser"].ToString();
                //LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                //LblTipo.Text = Session["Tipo"].ToString();
                LblNumSegCult.Text = Session["NumSeg"].ToString();
                LblPrograma.Text = Session["Programa"].ToString();
                LblIdCamp.Text = Session["IdCamp"].ToString();
                LblIdReg.Text = Session["IdReg"].ToString();
                LblFecha.Text = Session["fecha"].ToString();
                LblFechaIni.Text = (Convert.ToDateTime(LblFecha.Text).AddDays(-7)).ToString("dd/MM/yyyy");
                Mostrar_ENCABEZADO();
                Desplegar_GRILLA();
            }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        private void Desplegar_GRILLA()
        {
            DB_EXT_Fenologia fendetalle = new DB_EXT_Fenologia();
            switch (LblPrograma.Text)
            {
                case "TRIGO":
                        GVDetalleFenologiaTrigo.Visible = true;
                        GVDetalleFenologiaTrigo.DataSource = fendetalle.DB_Reporte_FENOLOGIA_DETALLE(0, LblPrograma.Text, Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblNumSegCult.Text), "", Convert.ToDateTime(LblFecha.Text), "FENOLOGIA_TRIGO");
                        GVDetalleFenologiaTrigo.DataBind();
                        if (GVDetalleFenologiaTrigo.Rows.Count > 0)
                        {
                            Promedios_Totales();
                        }
                    break;
                case "MAIZ":
                        GVDetalleFenologiaMaiz.Visible = true;
                        GVDetalleFenologiaMaiz.DataSource = fendetalle.DB_Reporte_FENOLOGIA_DETALLE(0, LblPrograma.Text, Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblNumSegCult.Text), "", Convert.ToDateTime(LblFecha.Text), "FENOLOGIA_MAIZ");
                        GVDetalleFenologiaMaiz.DataBind();
                    break;
                case "ARROZ":
                        GVDetalleFenologiaArroz.Visible = true;
                        GVDetalleFenologiaArroz.DataSource = fendetalle.DB_Reporte_FENOLOGIA_DETALLE(0, LblPrograma.Text, Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblNumSegCult.Text), "", Convert.ToDateTime(LblFecha.Text), "FENOLOGIA_ARROZ");
                        GVDetalleFenologiaArroz.DataBind();
                    break;
            }
        }
        private void Mostrar_ENCABEZADO()
        {
            DB_Regional reg = new DB_Regional();
            AP_Campanhia camp = new AP_Campanhia();
            DB_AP_Campanhia c = new DB_AP_Campanhia();
            DataTable dt = new DataTable();
            camp = c.DB_Buscar_CAMPANHIA(Convert.ToInt32(LblIdCamp.Text));
            LblCamp.Text = camp.Nombre;
            dt = reg.DB_Seleccionar_REGIONAL(Convert.ToInt32(LblIdReg.Text));
            LblRegional.Text = dt.Rows[0][1].ToString();
        }
        protected void GVDetalleFenologiaArroz_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();

                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 6;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Fecha y avance de siembra</div>";
                HeaderCell.ColumnSpan = 3;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Germinación emergencia</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Plántula</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Macollamiento</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Panicula</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Floración</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Grano Lechoso</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Maduración</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Cosecha y acopio</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Fecha cosecha</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow.Cells.Add(HeaderCell);
                GVDetalleFenologiaArroz.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }
        #region
        protected void Promedios_Totales()
        {
            decimal filas = GVDetalleFenologiaTrigo.Rows.Count;
            decimal suma = GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[5].Text));
            LblTotSupSem.Text = Convert.ToString(Math.Round((suma), 2));
            LblTotNumBenef.Text = Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[4].Text)))), 2));
            LblTotAvSiem.Text = Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[9].Text))) / filas), 2));
            LblTotGerm.Text = Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[10].Text))) / filas), 2));
            LblTotPlant.Text = Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[11].Text))) / filas), 2));
            LblTotMacolla.Text = Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[12].Text))) / filas), 2));
            LblTotEmbu.Text = Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[13].Text))) / filas), 2));
            LblTotEspi.Text = Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[14].Text))) / filas), 2));
            LblTotFlora.Text = Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[15].Text))) / filas), 2));
            LblTotLlenGran.Text = Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[16].Text))) / filas), 2));
            LblTotMadura.Text = Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[17].Text))) / filas), 2));
            LblTotAvCos.Text = Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[18].Text))) / filas), 2));
            LblTotRend.Text = Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[19].Text))) / filas), 2));
        }
        #endregion
        protected void GVDetalleFenologiaTrigo_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();

                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 4;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Semilla</div>";
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Fecha y avance de siembra</div>";
                HeaderCell.ColumnSpan = 3;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>ETAPA FENOLOGICA EN %</div>";
                HeaderCell.ColumnSpan = 8;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Cosecha y acopio</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Fecha cosecha</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow.Cells.Add(HeaderCell);

                GVDetalleFenologiaTrigo.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }
    }
}