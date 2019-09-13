using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DataBusiness.DB_Registro;
using DataBusiness.DB_General;
using DataEntity.DE_General;
using DataEntity.DE_Registro;
using DataBusiness.DB_Extensiones;
using DataBusiness.DB_Control;

namespace WebAplication.Control
{
    public partial class repAvanceCampanhia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            if (!IsPostBack)
            {
                LblPrograma.Text = Session["Prog"].ToString();
                LblRegional.Text = Session["IdReg"].ToString();
                Desplegar_AVANCE_CAMP();
            }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        #region OBTENER LA LISTA DE LAS CAMPOAÑAS APOYADAS
        protected void Desplegar_AVANCE_CAMP()
        {
            DB_RegionesApoyadas ListRegCamp = new DB_RegionesApoyadas();
            GVAvances.DataSource = ListRegCamp.DB_Desplegar_CAMP_APOYADAS("", LblPrograma.Text, Convert.ToInt32(LblRegional.Text), 0, "AVANCE");
            GVAvances.DataBind();
        }
        #endregion
        protected void GVAvances_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DB_RegionesApoyadas ListRegCamp = new DB_RegionesApoyadas();
            DB_EXT_Fenologia Luis = new DB_EXT_Fenologia();
            DB_EXT_Rendimiento ex = new DB_EXT_Rendimiento();
            DataTable dt = new DataTable();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int IdInsOrg = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_InscripcionOrg").ToString());
                /*****************************/
                dt = Luis.DB_Seleccionar_NUMPROD_TOTSUP(IdInsOrg,0);
                ((Label)e.Row.FindControl("LblNumBenefVig")).Text = dt.Rows[0][0].ToString();
                ((Label)e.Row.FindControl("LblSupApoyada")).Text = dt.Rows[0][1].ToString();
                dt = ex.DB_Reporte_DETALLE_PLANILLA(IdInsOrg, "", "", "RENDIMIENTO_PROMEDIO");
                ((Label)e.Row.FindControl("LblRendimiento")).Text = dt.Rows[0][0].ToString();
                //((Label)e.Row.FindControl("LblProdEstim")).Text = (Convert.ToDecimal(((Label)e.Row.FindControl("LblSupApoyada")).Text) * Convert.ToDecimal(((Label)e.Row.FindControl("LblRendimiento")).Text)).ToString();
            }
        }
    }
}