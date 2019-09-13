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
    public partial class repCronogramaTec : System.Web.UI.Page
    {
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
            DB_AP_CronogramaCamp ListC = new DB_AP_CronogramaCamp();
            GVCronogramas.DataSource = ListC.DB_Desplegar_LISTA_CRONOGRAMAS(Convert.ToInt32(LblIdCrono.Text), "LISTA_CRONOGRAMA_TEC");
            GVCronogramas.DataBind();
        }
        #endregion

        protected void GVCronogramas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Boolean mes1 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Enero").ToString());
                Boolean mes2 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Febrero").ToString());
                Boolean mes3 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Marzo").ToString());
                Boolean mes4 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Abril").ToString());
                Boolean mes5 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Mayo").ToString());
                Boolean mes6 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Junio").ToString());
                Boolean mes7 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Julio").ToString());
                Boolean mes8 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Agosto").ToString());
                Boolean mes9 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Septiembre").ToString());
                Boolean mes10 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Octubre").ToString());
                Boolean mes11 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Noviembre").ToString());
                Boolean mes12 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Diciembre").ToString());
                var image1 = e.Row.FindControl("ImgEstado1") as Image;
                var image2 = e.Row.FindControl("ImgEstado2") as Image;
                var image3 = e.Row.FindControl("ImgEstado3") as Image;
                var image4 = e.Row.FindControl("ImgEstado4") as Image;
                var image5 = e.Row.FindControl("ImgEstado5") as Image;
                var image6 = e.Row.FindControl("ImgEstado6") as Image;
                var image7 = e.Row.FindControl("ImgEstado7") as Image;
                var image8 = e.Row.FindControl("ImgEstado8") as Image;
                var image9 = e.Row.FindControl("ImgEstado9") as Image;
                var image10 = e.Row.FindControl("ImgEstado10") as Image;
                var image11 = e.Row.FindControl("ImgEstado11") as Image;
                var image12 = e.Row.FindControl("ImgEstado12") as Image;

                if (mes1 == true)
                {
                    image1.ImageUrl = "~/images/img-1.png";
                }
                //if (mes1 == false)
                //{
                //    image1.ImageUrl = "~/images/img-0.png";
                //}
                if (mes2 == true)
                {
                    image2.ImageUrl = "~/images/img-1.png";
                }
                //if (mes2 == false)
                //{
                //    image2.ImageUrl = "~/images/img-0.png";
                //}
                if (mes3 == true)
                {
                    image3.ImageUrl = "~/images/img-1.png";
                }
                //if (mes3 == false)
                //{
                //    image3.ImageUrl = "~/images/img-0.png";
                //}
                if (mes4 == true)
                {
                    image4.ImageUrl = "~/images/img-1.png";
                }
                //if (mes4 == false)
                //{
                //    image4.ImageUrl = "~/images/img-0.png";
                //}
                if (mes5 == true)
                {
                    image5.ImageUrl = "~/images/img-1.png";
                }
                //if (mes5 == false)
                //{
                //    image5.ImageUrl = "~/images/img-0.png";
                //}
                if (mes6 == true)
                {
                    image6.ImageUrl = "~/images/img-1.png";
                }
                //if (mes6 == false)
                //{
                //    image6.ImageUrl = "~/images/img-0.png";
                //}
                if (mes7 == true)
                {
                    image7.ImageUrl = "~/images/img-1.png";
                }
                //if (mes7 == false)
                //{
                //    image7.ImageUrl = "~/images/img-0.png";
                //}
                if (mes8 == true)
                {
                    image8.ImageUrl = "~/images/img-1.png";
                }
                //if (mes8 == false)
                //{
                //    image8.ImageUrl = "~/images/img-0.png";
                //}
                if (mes9 == true)
                {
                    image9.ImageUrl = "~/images/img-1.png";
                }
                //if (mes9 == false)
                //{
                //    image9.ImageUrl = "~/images/img-0.png";
                //}
                if (mes10 == true)
                {
                    image10.ImageUrl = "~/images/img-1.png";
                }
                //if (mes10 == false)
                //{
                //    image10.ImageUrl = "~/images/img-0.png";
                //}
                if (mes11 == true)
                {
                    image11.ImageUrl = "~/images/img-1.png";
                }
                //if (mes11 == false)
                //{
                //    image11.ImageUrl = "~/images/img-0.png";
                //}
                if (mes12 == true)
                {
                    image12.ImageUrl = "~/images/img-1.png";
                }
                //if (mes12 == false)
                //{
                //    image12.ImageUrl = "~/images/img-0.png";
                //}
            }
        }
    }
}