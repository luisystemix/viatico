using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DataBusiness.DB_Extensiones;
using DataBusiness.DB_Registro;
using DataEntity.DE_General;
using DataBusiness.DB_General;
using DataEntity.DE_Registro;

namespace WebAplication.Control
{
    public partial class repCronogramaReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdCamp.Text = Session["IdCamp"].ToString();
                    LblIdReg.Text = Session["IdReg"].ToString();
                    LblMes.Text= Session["Mes"].ToString();
                    Desplegar_LISTA_CRONOGRAMAS();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCION PARA DESPLEGAR LA LISTDE LOS CRONOGRAMS
        protected void Desplegar_LISTA_CRONOGRAMAS()
        {
                DB_EXT_Cronogramas ListC = new DB_EXT_Cronogramas();
                GVCronogramas.DataSource = ListC.DB_Desplegar_LISTA_CRONOGRAMAS(LblMes.Text, Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblIdCamp.Text), "CRONOGRAMAS_REGIONAL");
                GVCronogramas.DataBind();
        }
        #endregion
        protected void GVCronogramas_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();

                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Lunes</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Martes</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Miercoles</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Jueves</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Viernes</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Sabado</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Domingo</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                GVCronogramas.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }

    }
}