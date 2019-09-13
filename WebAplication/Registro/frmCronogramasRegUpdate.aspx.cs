using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;

namespace WebAplication.Registro
{
    public partial class frmCronogramasRegUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                if (!IsPostBack)
                {
                    LblIdCrono.Text = Session["IdCrono"].ToString();
                    Reporte_CRONOGRAMA_REGIONAL();
                }
            //}
            //catch
            //{
            //    Response.Redirect("../Responsable/frmControlRegional.aspx");
            //}
        }
        #region FUNCION PARA DESPLEGAR EL CRONOGRAMA INICIAL PRESENTADO POR LA REGIONAL EN LA GRILLA
        protected void Reporte_CRONOGRAMA_REGIONAL()
        {
            DB_AP_CronogramaCamp ListCamp = new DB_AP_CronogramaCamp();
            DataTable dt = new DataTable();
            dt = ListCamp.DB_Desplegar_LISTA_CRONOGRAMAS(Convert.ToInt32(LblIdCrono.Text), "DATOS_ROTULO");
            LblCampanhia.Text = dt.Rows[0][0].ToString();
            LblPrograma.Text = dt.Rows[0][3].ToString();
            LblRegional.Text = dt.Rows[0][2].ToString();

            GVConograma.DataSource = ListCamp.DB_Desplegar_LISTA_CRONOGRAMAS(Convert.ToInt32(LblIdCrono.Text), "CRONOGRAMA");
            GVConograma.DataBind();
        }
        #endregion

        protected void GVConograma_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DateTime fecha = DateTime.Now;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((TextBox)e.Row.FindControl("TxtObserv")).Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Observacion"));
                ((TextBox)e.Row.FindControl("TxtFinEject")).Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Final_Ejecutado"));
                ((TextBox)e.Row.FindControl("TxtInicEject")).Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Inicio_Ejecutado"));
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime fechaini = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Inicio_Ejecutado"));
                DateTime fechafin = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Final_Ejecutado"));
                if (fecha <= fechafin && fecha >= fechaini)
                {
                    e.Row.Cells[2].Text = "ACTIVO";
                    e.Row.Cells[2].Font.Bold = true;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    e.Row.Cells[2].Text = "INACTIVO";
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}