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

namespace WebAplication.Extensiones
{
    public partial class repDistribSemillaOrg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                    Seleccionar_DISTRIBUCION_DETALLE();
                    Mostrar_ENCABEZADO();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        private void Mostrar_ENCABEZADO() 
        {
            DB_EXT_Seguimiento disSem = new DB_EXT_Seguimiento();
            DataTable dt = new DataTable();
            dt = disSem.DB_Reporte_DISTRIBUCION_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), "SEMILLA", "REPDIRSTRIBORG");
            LblCamp.Text=dt.Rows[0][3].ToString();
            LblRegional.Text=dt.Rows[0][2].ToString();
            LblProg.Text = dt.Rows[0][5].ToString();
            LblOrg.Text = dt.Rows[0][4].ToString();
        }
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Seleccionar_DISTRIBUCION_DETALLE()
        {
            DB_EXT_Seguimiento disSem = new DB_EXT_Seguimiento();
            GVListaSemilla.DataSource = disSem.DB_Reporte_DISTRIBUCION_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), "SEMILLA", "REPDETALLE");
            GVListaSemilla.DataBind();
        }
        #endregion
    }
}