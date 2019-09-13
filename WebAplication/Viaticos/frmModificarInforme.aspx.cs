using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBusiness.DB_Viaticos;
using DataEntity.DE_Viaticos;
using DataBusiness.DB_Registro;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WebAplication.Viaticos
{
    public partial class frmModificarInforme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdSolicitud.Text = Session["IdSolicitud"].ToString();
                    Cargar_ENCABEZADO();
                    Cargar_VALORES();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Cargar_ENCABEZADO()
        {
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            DataTable data = new DataTable();
            data = sol.DB_Reporte_SOLICITUD_US(LblIdSolicitud.Text, "FECHAMAXMINSOLICITUD");
            LblFechaSalida.Text = Convert.ToDateTime(data.Rows[0][0].ToString()).ToString("dd/MM/yyyy");
            LblFechaRetorno.Text = Convert.ToDateTime(data.Rows[0][1].ToString()).ToString("dd/MM/yyyy");
            data = sol.DB_Reporte_SOLICITUD_US(LblIdSolicitud.Text, "ENCABEZADO");
            LblDirigidoA.Text = data.Rows[0][13].ToString();
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Cargar_VALORES()
        {
            DB_VT_Informe inf = new DB_VT_Informe();
            DataTable dt = new DataTable();
            dt = inf.DB_Seleccionar_INFORME(LblIdSolicitud.Text, "INFORME");
            TxtConclucion.Text=dt.Rows[0][3].ToString();
            TxtObjetivo.Text = dt.Rows[0][13].ToString();            
            TxtRecomendacion.Text = dt.Rows[0][15].ToString();
        }
        #endregion
        #region FUNCION PARA CARGAR EL TEXBOS DENTRO DEL DATALIST
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
             if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
             {
                 string motivo = DataBinder.Eval(e.Item.DataItem, "Actividad").ToString();
                 ((TextBox)e.Item.FindControl("TxtActividad")).Text = motivo;
             }  
        }
        #endregion
        #region FUNCION PARA ;MODIFICAR Y ENVIAR EL INFORME DE VIAJE
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            DB_VT_Informe upInf = new DB_VT_Informe();
            DataTable dt = new DataTable();
            dt = upInf.DB_Seleccionar_INFORME(LblIdSolicitud.Text,"INFORME"); 
            VT_InformeActividad infact = new VT_InformeActividad();
            VT_Informe inf = new VT_Informe();
            inf.Id_Solicitud = LblIdSolicitud.Text;
            inf.Conclusion = TxtConclucion.Text;
            inf.Objetivo = TxtObjetivo.Text;
            inf.Recomendacion = TxtRecomendacion.Text;
            inf.Observacion = "";
            inf.Estado = "ENVIADO";
            upInf.DB_Modificar_INFORME(inf);
            int cont = 1;
            foreach (DataListItem item in DataList1.Items)
            {
                TextBox tx = (TextBox)item.FindControl("TxtActividad");
                infact.Id_Informe = Convert.ToInt32(dt.Rows[0][0].ToString());
                infact.Cont = cont;
                infact.Actividad = tx.Text;
                upInf.DB_Modificar_INFORME_ACTIVIDAD(infact);
                cont++;
            }

            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repInforme.aspx?ci=" + LblIdSolicitud.Text);
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
            Response.Redirect("frmListaInformesUs.aspx");
        }
        #endregion
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmListaInformesUs.aspx");
        }
    }
}