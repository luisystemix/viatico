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

namespace WebAplication.Viaticos
{
    public partial class frmAnulaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Desplegar_SOLICITUD_ANULADAS();
            }
        }
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Desplegar_SOLICITUD_ANULADAS()
        {
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            GVListSolAnulados.DataSource = lista.DB_Desplegar_SOLICITUD_USUARIO("0", "ANULADO", "ANULADOS");
            GVListSolAnulados.DataBind();
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Desplegar_SOLICITUD_USUARIO()
        {
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            DataTable dt = new DataTable();
            dt = lista.DB_Reporte_SOLICITUD_US(TxtCodigo.Text, "SOLICITUD_ANULACION");
            if(dt.Rows.Count > 0)
            {
                LblEstado.Text = dt.Rows[0][7].ToString();
                 if(LblEstado.Text!="ANULADO")
                 {
                    GVListSolicitud.DataSource = dt;
                    GVListSolicitud.DataBind();
                    Panel1.Visible= true;
                 }
                 else
                 {
                     GVListSolicitud.DataSource = dt;
                     GVListSolicitud.DataBind();
                 }
            }
            else
            {
                Response.Write("<script>window.alert('Verifique si el código de solicitud está bien escrito? O Es posible que NO exista la solicitud....');</script>");
                Panel1.Visible = false;
            }
        }
        #endregion

        protected void ImgBtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Desplegar_SOLICITUD_USUARIO();
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            //if (LblEstado.Text == "ENVIADO" || LblEstado.Text == "HABILITADO")
            //{
                if(TxtObsser.Text!="")
                {
                    DB_VT_Solicitud sol = new DB_VT_Solicitud();
                    sol.DB_Anular_SOLICITUD(TxtCodigo.Text, TxtObsser.Text,"ANULADO");
                    Desplegar_SOLICITUD_USUARIO();
                    TxtObsser.Text = string.Empty;
                    Panel1.Visible = false;
                }
                else
                {
                    Response.Write("<script>window.alert('Es necesario describir el motivo de la anulación del documento...');</script>");
                }
                Desplegar_SOLICITUD_ANULADAS();
            //}
            //else
            //{
            //    Response.Write("<script>window.alert('.');</script>");
            //}
        }
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/About.aspx");
        }

        protected void GVListSolAnulados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVListSolAnulados.PageIndex = e.NewPageIndex;
            Desplegar_SOLICITUD_ANULADAS();
        }
    }
}