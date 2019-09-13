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
    public partial class frmRealizarInforme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdSolicitud.Text = Session["IdSolicitud"].ToString();
                    Cargar_ENCABEZADO();
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
            LblDirigidoA.Text=data.Rows[0][13].ToString();
            DB_VT_Informe aux = new DB_VT_Informe();
            data = aux.DB_Desplegar_DATOS_ESTRUCTURA(LblDirigidoA.Text);
            if (data.Rows.Count > 0)
            {
                if(data.Rows[0][1].ToString()=="GAF")
                {
                    data = aux.DB_Desplegar_DATOS_ESTRUCTURA("GG");
                    LblDirigidoA.Text = data.Rows[0][2].ToString();
                }
                else
                {
                    data = aux.DB_Desplegar_DATOS_ESTRUCTURA("GAF");
                    LblDirigidoA.Text=data.Rows[0][2].ToString();
                }
            }
            else
            {
                data = aux.DB_Desplegar_DATOS_ESTRUCTURA("GAF");
                LblDirigidoA.Text=data.Rows[0][2].ToString();
            }
        }
        #endregion
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            #region
            /*******************************************************/
            // DB_VT_Solicitud s = new DB_VT_Solicitud();
            // DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            // DB_VT_Informe InsInf = new DB_VT_Informe();
            // VT_InformeActividad infact = new VT_InformeActividad();
            // VT_Informe inf = new VT_Informe();
            // inf.Id_Solicitud = LblIdSolicitud.Text;
            // inf.Dirigido_A = "YAMILE IBAÑEZ"; /*****************************  HAY QUE CARGAR DEL PARAMETRO *********************************/
            //// inf.Fecha_Informe = fechaINF();
            // //inf.Fecha_Informe = DateTime.Now;
            // //inf.Fecha_Aprobacion = DateTime.Now;
            // inf.Conclusion = TxtConclucion.Text;
            // inf.Observacion = "";
            // inf.Estado = "ENVIADO";
            // InsInf.DB_Registrar_INFORME(inf);
            // LblIdInf.Text = aux.DB_MaxId("VIAT_INFORME", "Id_Informe");
            // int cont = 1;
            // foreach (DataListItem item in DataList1.Items)                                                                                                                                                                                                                                                                                      
            // {
            //     TextBox tx = (TextBox)item.FindControl("TxtObjetivos");
            //     Label lb = (Label)item.FindControl("FechaDiaLabel");
            //     infact.Id_Informe = Convert.ToInt32(LblIdInf.Text);
            //     infact.Fecha = Convert.ToDateTime(lb.Text);
            //     infact.Cont = cont;
            //     infact.Actividad = tx.Text;
            //     InsInf.DB_Registrar_INFORME_ACTIVIDAD(infact);
            //     cont++;
            // }
            // s.DB_Cambiar_ESTADO(LblIdSolicitud.Text, "INF-ENVIADO");
            // s.DB_Eliminar_OBSERVACION(LblIdSolicitud.Text);

            // StringBuilder sbMensaje = new StringBuilder();
            // sbMensaje.Append("<script type='text/javascript'>");
            // sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repInforme.aspx?ci=" + LblIdSolicitud.Text);
            // sbMensaje.Append("</script>");
            // ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
            // BtnRegistrar.Enabled = false;
            // Response.Redirect("frmListaInformesUs.aspx");
            /*******************************************************/
            #endregion
            DB_VT_Solicitud s = new DB_VT_Solicitud();
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            DB_VT_Informe InsInf = new DB_VT_Informe();
            VT_InformeActividad infact = new VT_InformeActividad();
            VT_Informe inf = new VT_Informe();

            inf.Id_Solicitud = LblIdSolicitud.Text;
            inf.Dirigido_A = LblDirigidoA.Text; 
            inf.Fecha_Informe = DateTime.Now;
            inf.Fecha_Aprobacion = DateTime.Now;
            inf.Conclusion = TxtConclucion.Text;
            inf.Observacion = ""; ;
            inf.Estado = "ENVIADO";
            inf.Objetivo = TxtObjetivo.Text;
            inf.Recomendacion = TxtRecomendacion.Text;
            InsInf.DB_Registrar_INFORME(inf);
            LblIdInf.Text = aux.DB_MaxId("VIAT_INFORME", "Id_Informe");
            int cont = 1;
            foreach (DataListItem item in DataList1.Items)
            {
                TextBox tx = (TextBox)item.FindControl("TxtObjetivos");
                Label lb = (Label)item.FindControl("FechaDiaLabel");
                infact.Id_Informe = Convert.ToInt32(LblIdInf.Text);
                infact.Fecha = Convert.ToDateTime(lb.Text);
                infact.Cont = cont;
                infact.Actividad = tx.Text;
                InsInf.DB_Registrar_INFORME_ACTIVIDAD(infact);
                cont++;
            }
            s.DB_Cambiar_ESTADO(LblIdSolicitud.Text, "INF-ENVIADO");
            //s.DB_Eliminar_OBSERVACION(LblIdSolicitud.Text);

            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repInforme.aspx?ci=" + LblIdSolicitud.Text);
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
            Response.Redirect("frmListaInformesUs.aspx");
        }
        protected DateTime fechaINF()
        {
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            DataTable dts = new DataTable();
            int num = 0;
            dts = sol.DB_Reporte_SOLICITUD_US(LblIdSolicitud.Text, "FECHA_RETORNO");
            DateTime date = Convert.ToDateTime(dts.Rows[0][0].ToString());
            string resultado = String.Format("{0:dddd}", Convert.ToDateTime(dts.Rows[0][0].ToString()));
            if (resultado == "lunes" || resultado == "martes" || resultado == "miércoles")
            {
                num = 2;
            }
            else
            {
                if (resultado == "jueves" || resultado == "viernes" || resultado == "sábado")
                {
                    num = 4;
                }
                else
                {
                    num = 3;
                }
            }
            return date.AddDays(+num);
            //dts = sol.DB_Reporte_SOLICITUD_US(dt.Rows[i][0].ToString(), "DIAS_SIN_INFORME");
            //int aux = Convert.ToInt32(dts.Rows[0][0].ToString()) - num;
        }
    }
}