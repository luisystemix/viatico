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
    public partial class frmAvanceCampanhia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    Llenar_DDLRegional();
                    Llenar_DDLCAMPANHIA();
                    Desplegar_AVANCE_CAMP();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCION PARA LLENAR EL COMBO CON EL TIPO DE ORGANIZACION
        private void Llenar_DDLRegional()
        {
            DB_AdminUser User = new DB_AdminUser();
            DataTable dt = User.DB_Desplegar_USUARIO(LblIdUsuario.Text);
            LblReg.Text = dt.Rows[0][13].ToString();
            if (Convert.ToInt32(dt.Rows[0][6].ToString()) == 15 || Convert.ToInt32(dt.Rows[0][6].ToString()) == 5)
            {
                DDLRegional.Items.Insert(0, new ListItem(dt.Rows[0][5].ToString(), dt.Rows[0][4].ToString(), true));
                DDLRegional.Enabled = false;
            }
            else
            {
                DB_Regional reg = new DB_Regional();
                List<Regional> Lista = reg.DB_Desplegar_REGIONAL();
                DDLRegional.DataSource = Lista;
                DDLRegional.DataValueField = "Id_Regional";
                DDLRegional.DataTextField = "Nombre";
                DDLRegional.DataBind();
            }
        }
        #endregion
        #region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS
        private void Llenar_DDLCAMPANHIA()
        {
            DB_AP_Campanhia cam = new DB_AP_Campanhia();
            DataTable dt = new DataTable();
            dt = cam.DB_Seleccionar_CAMPANHIA_REG_NOFIN(LblReg.Text);
            DDLCamp.DataSource = dt;
            DDLCamp.DataValueField = "Id_Campanhia";
            DDLCamp.DataTextField = "Nombre";
            DDLCamp.DataBind();
        }
        #endregion
        #region OBTENER LA LISTA DE LAS CAMPOAÑAS APOYADAS
        protected void Desplegar_AVANCE_CAMP()
        {
            DB_RegionesApoyadas ListRegCamp = new DB_RegionesApoyadas();
            GVAvances.DataSource = ListRegCamp.DB_Desplegar_CAMP_APOYADAS("",DDLProg.SelectedValue, Convert.ToInt32(DDLRegional.SelectedValue), 0, "AVANCE");
            GVAvances.DataBind();
        }
        #endregion

        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_AVANCE_CAMP();
            GVAvances.DataBind();
        }

        protected void DDLRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_AVANCE_CAMP();
            GVAvances.DataBind();
        }

        protected void GVAvances_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DB_RegionesApoyadas ListRegCamp = new DB_RegionesApoyadas();
            DB_EXT_Fenologia Luis = new DB_EXT_Fenologia();
            DB_EXT_Rendimiento ex = new DB_EXT_Rendimiento();
            DataTable dt = new DataTable();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int IdInsOrg = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_InscripcionOrg").ToString());
                int IdComunidad = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Municipio").ToString());
                /*****************************/
                dt = Luis.DB_Seleccionar_NUMPROD_TOTSUP(IdInsOrg, IdComunidad);
                ((Label)e.Row.FindControl("LblNumBenefVig")).Text = dt.Rows[0][0].ToString();
                ((Label)e.Row.FindControl("LblSupApoyada")).Text = dt.Rows[0][1].ToString();

                dt = ex.DB_Reporte_DETALLE_PLANILLA(IdInsOrg, "", "", "RENDIMIENTO_PROMEDIO");
                ((Label)e.Row.FindControl("LblRendimiento")).Text = dt.Rows[0][0].ToString();
                try
                {
                    ((Label)e.Row.FindControl("LblProdEstim")).Text = (Convert.ToDecimal(((Label)e.Row.FindControl("LblSupApoyada")).Text) * Convert.ToDecimal(((Label)e.Row.FindControl("LblRendimiento")).Text)).ToString();
                }
                catch 
                {
                    ((Label)e.Row.FindControl("LblProdEstim")).Text ="0";
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("Prog",DDLProg.SelectedValue);
            Session.Add("IdReg", DDLRegional.SelectedValue);
            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Control/repAvanceCampanhia.aspx?ci=" + "0");
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
        }

        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DDLCAMPANHIA();
            Desplegar_AVANCE_CAMP();
        }
    }
}