using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataBusiness.DB_Viaticos;
using DataBusiness.DB_General;

namespace WebAplication.Viaticos
{
    public partial class repInforme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                if (!IsPostBack)
                {
                    LblIdSolicit.Text = Session["IdSolicitud"].ToString();
                    Reporte_INFORME();
                }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        protected void Reporte_INFORME()
        {
            DB_Usuario us = new DB_Usuario();
            DB_VT_Informe inf = new DB_VT_Informe();
            DataTable dt = new DataTable();
            dt = inf.DB_Reporte_INFORME(LblIdSolicit.Text, "INFORME");
            if (dt.Rows.Count == 0)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, "No se Genero Informe.");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
            LblDirigidoA.Text = dt.Rows[0][1].ToString();
            
                            //string.Format("{0:D}", Convert.ToDateTime(dt.Rows[0][6].ToString()));
            LblFecha.Text = string.Format("{0:D}", Convert.ToDateTime(dt.Rows[0][2].ToString()));
            LblPersonal.Text = dt.Rows[0][5].ToString() +" "+ dt.Rows[0][6].ToString() +" "+ dt.Rows[0][7].ToString();
            LblUsuario.Text = LblPersonal.Text;
            LblCargo.Text = dt.Rows[0][10].ToString();
            LblCargo1.Text = LblCargo.Text;
            LblConclucion.Text = dt.Rows[0][3].ToString();
            lblObjetivo.Text= dt.Rows[0][13].ToString();            
            lblRecomendacion.Text = dt.Rows[0][15].ToString();
            /*********************************************/
            dt = us.DB_Desplegar_USUARIO(0, dt.Rows[0][1].ToString(), "PERSONAL");
            LblDirigidoA.Text=dt.Rows[0][10].ToString();
            LblCargoA.Text=dt.Rows[0][5].ToString();
            /********************************************************************/
            dt = inf.DB_Reporte_INFORME(LblIdSolicit.Text, "FECHAMAXMIN");
            LblFechaSalida.Text = dt.Rows[0][0].ToString();
            LblFechaRetorno.Text = dt.Rows[0][1].ToString();
            /***********************************************************/
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            dt = sol.DB_Reporte_SOLICITUD_US(LblIdSolicit.Text, "DETALLE");
            /***********************************************************/
            DB_VT_Planilla pl = new DB_VT_Planilla();
            DataTable data = new DataTable();
            if (dt.Rows[0][3].ToString() == "Al interior del Departamento")
            {
                data = pl.DB_Reporte_DETALLE_PLANILLA(LblIdSolicit.Text, "DESTINOS_LUGAR");
                LblDestino.Text = data.Rows[0][0].ToString();
            }
            else
            {
                data = pl.DB_Reporte_DETALLE_PLANILLA(LblIdSolicit.Text, "DESTINOS");
                LblDestino.Text = data.Rows[0][0].ToString();
            }
        }
    }
}