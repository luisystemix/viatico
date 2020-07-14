using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Threading;
using DataEntity.DE_Viaticos;
using DataBusiness.DB_Viaticos;
using DataEntity.DE_General;
using DataBusiness.DB_General;
using DataBusiness.DB_Registro;
using System.Web.UI.HtmlControls;

namespace WebAplication.Viaticos
{
    public partial class frmDetalleViajesMes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            if (!IsPostBack)
            {
                Desplegar_REGIONAL();
                //Desplegrar_GRILLA();
            }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        #region FUNCIONES PARA DESPLEGAR REGIONALES EN EL COMBO
        protected void Desplegar_REGIONAL()
        {
            DB_Regional r = new DB_Regional();
            List<Regional> listaR = r.DB_Desplegar_REGIONAL();
            DDLRegional.DataSource = listaR;
            DDLRegional.DataValueField = "Id_Regional";
            DDLRegional.DataTextField = "Nombre";
            DDLRegional.DataBind();
            DDLRegional.Items.Insert(0, new ListItem("Seleccione la Regional", "0", true));
        }
        #endregion
        #region OBTENER LA LISTA DEL PERSONAL QUE VIAJO EN UN INTERVALO DE TIEMPO
        protected void Desplegrar_GRILLA()
        {
            DB_VT_Viaticos lista = new DB_VT_Viaticos();
            GVListaViajes.DataSource = lista.DB_Seleccionar_VIAJES_PERSONAL_FECHAS(Convert.ToInt32(DDLRegional.SelectedValue), Convert.ToDateTime(TxtFechIni.Text), Convert.ToDateTime(TxtFechFin.Text),"VIAJES_MENSUAL");
            GVListaViajes.DataBind();
        }
        #endregion

        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
            lblMensaje.Visible = false;
        }

        protected void BtnCalcular_Click(object sender, EventArgs e)
        {
            int val = validacion();
            if (val > 0)
                return;
            lblMensaje.Text = string.Empty;
            lblMensaje.Visible = false;
            Desplegrar_GRILLA();
        }
        // lrojas: 19/09/2016 
        protected int validacion()
        {
            int val = 0;
            if (DDLRegional.SelectedItem.Text == "Seleccione la Regional")
            {
                lblMensaje.Text = "No se Seleccionó Regional";
                lblMensaje.Visible = true;
                val = 1;
            }
            else
            {
                if (TxtFechIni.Text == string.Empty)
                {
                    lblMensaje.Text = "No se Seleccionó Intervalo de Fecha Desde";
                    lblMensaje.Visible = true;
                    val = 1;
                }
                else
                {
                    if (TxtFechFin.Text == string.Empty)
                    {
                        lblMensaje.Text = "No se Seleccionó Intervalo de Fecha Hasta";
                        lblMensaje.Visible = true;
                        val = 1;
                    }
                }
                
            }
            
            return val;
        }

        protected void GVListaViajes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            DataTable dt = new DataTable();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string IdSolicitud = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Id_Solicitud"));
                dt = sol.DB_Reporte_SOLICITUD_US(IdSolicitud, "FECHA_MAX");
                ((Label)e.Row.FindControl("LblFechRetorno")).Text = dt.Rows[0][0].ToString();
                //((Label)e.Row.FindControl("LblDias")).Text = 
            }
        }

        protected void ImgPrint_Click(object sender, ImageClickEventArgs e)
        {
            int val = validacion();
            if (val > 0)
                return;

            if (GVListaViajes.Rows.Count == 0)
            {
                lblMensaje.Text = "Sin Datos a Exportar";
                lblMensaje.Visible = true;
                return;
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();

            GVListaViajes.EnableViewState = false;

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();
            //Image1.Visible = true;
            Label1.Visible = true;//

            //page.Controls.Add(Image1);
            Label1.Text = "<br/><br/><table align='center' width='800px'><tr align='center'><td><img src='http://201.222.80.212/emapaglobal/img/bannerReport.jpg'alt='EMAPA-Documento' style='float:inherit'/></td><td></td><td></td><td colspan='5'><b style='text-align: center'>EMPRESA DE APOYO A LA PRODUCCION DE ALIMENTOS<br />REPORTE DETALLE DE VIAJES REALIZADOS</b><br>Regional " + DDLRegional.SelectedItem.Text +" del "+ TxtFechIni.Text +" al "+ TxtFechFin.Text  +"<br /></td><td></td><td></td><td></td></tr><tr align='center'><td colspan='11'><b></b> </td></tr></table>";
            page.Controls.Add(Label1);
            // page.Controls.Add(lblGlosa);
            page.Controls.Add(form);

            form.Controls.Add(GVListaViajes);

            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=ReporteDetalleViajes.xls");
            Response.Charset = "UTF-8";
            // Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }
    }
}