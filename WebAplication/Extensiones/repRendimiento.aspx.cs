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
    public partial class repRendimiento : System.Web.UI.Page
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
            LblCamp.Text = dt.Rows[0][3].ToString();
            LblRegional.Text = dt.Rows[0][2].ToString();
        }
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Seleccionar_DISTRIBUCION_DETALLE()
        {
            DB_EXT_Seguimiento rendi = new DB_EXT_Seguimiento();
            GVListRendimiento.DataSource = rendi.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg.Text),"TODOS","TODOS","SEG_REND_DETALLE");
            GVListRendimiento.DataBind();
        }
        #endregion
    }
}