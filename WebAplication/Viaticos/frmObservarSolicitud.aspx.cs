using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DataBusiness.DB_Viaticos;
using DataEntity.DE_Viaticos;

namespace WebAplication.Viaticos
{
    public partial class frmObservarSolicitud : System.Web.UI.Page
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
            VT_Cuenta cta = new VT_Cuenta();
            DB_VT_Planilla pl = new DB_VT_Planilla();
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            DataTable data = new DataTable();
            data = sol.DB_Reporte_SOLICITUD_US(LblIdSolicitud.Text, "ENCABEZADO");
            LblNombre.Text = data.Rows[0][12].ToString();
            LblMotivo.Text = data.Rows[0][7].ToString();
            LblIdUser.Text = data.Rows[0][1].ToString();
            data = pl.DB_Reporte_DETALLE_PLANILLA(LblIdSolicitud.Text, "DESTINOS");
            LblDestino.Text = data.Rows[0][0].ToString();
        }
        #endregion

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            VT_Observacion obs = new VT_Observacion();
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            obs.Id_Solicitud = LblIdSolicitud.Text;
            obs.Observacion = TxtObs.Text;
            obs.Tipo = "Solicitud";
            sol.DB_Registrar_OBSERVACION_SOLICITUD(obs);
            sol.DB_Cambiar_ESTADO(LblIdSolicitud.Text, "OBSERVADO");
            Response.Redirect("frmListaSolicitGAF.aspx");
        }
    }
}