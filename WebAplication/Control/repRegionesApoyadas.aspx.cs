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
    public partial class repRegionesApoyadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                if (!IsPostBack)
                {
                    LblIdCamp.Text = Session["IdCamp"].ToString();
                    Llenar_DDLCAMPANHIA();
                    LblFecha.Text = string.Format("{0:D}", Convert.ToDateTime(DateTime.Now.ToString()));
                    //LblFecha.Text = DateTime.Now.ToString();
                    Desplegar_CAMP_APOYADAS();
                }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        #region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS
        private void Llenar_DDLCAMPANHIA()
        {
            DB_AP_Campanhia cam = new DB_AP_Campanhia();
            AP_Campanhia c = new AP_Campanhia();
            c = cam.DB_Buscar_CAMPANHIA(Convert.ToInt32(LblIdCamp.Text));
            LblCamp.Text = c.Nombre;
            LblRegion.Text = c.Region;
        }
        #endregion
        #region OBTENER LA LISTA DE LAS CAMPOAÑAS APOYADAS
        protected void Desplegar_CAMP_APOYADAS()
        {
            DB_RegionesApoyadas ListRegCamp = new DB_RegionesApoyadas();
            GVCampEmapa.DataSource = ListRegCamp.DB_Desplegar_CAMP_APOYADAS("", LblRegion.Text, Convert.ToInt32(LblIdCamp.Text), 0, "APOYO_CAMPANIA");
            GVCampEmapa.DataBind();
        }
        #endregion
        protected void GVCampEmapa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DB_RegionesApoyadas ListRegCamp = new DB_RegionesApoyadas();
            DataTable dt = new DataTable();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Dep = DataBinder.Eval(e.Row.DataItem, "Departamento").ToString();
                string prog = DataBinder.Eval(e.Row.DataItem, "Programa").ToString();
                int idcamp = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Campanhia").ToString());
                int idreg = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Regional").ToString());
                var image = e.Row.FindControl("Estado") as Image;
                dt = ListRegCamp.DB_Desplegar_CAMP_APOYADAS(Dep, prog, idcamp, idreg, "NUM_ORG");
                ((Label)e.Row.FindControl("LblNumOrg")).Text = dt.Rows[0][0].ToString();
                LblTotOrg.Text = (Convert.ToInt32(LblTotOrg.Text) + Convert.ToInt32(dt.Rows[0][0].ToString())).ToString(); 
                dt = ListRegCamp.DB_Desplegar_CAMP_APOYADAS(Dep, prog, idcamp, 0, "NUM_PROD");
                ((Label)e.Row.FindControl("LblNumProd")).Text = dt.Rows[0][0].ToString();
                LblTotNumBenef.Text = (Convert.ToInt32(LblTotNumBenef.Text) + Convert.ToInt32(dt.Rows[0][0].ToString())).ToString();
                dt = ListRegCamp.DB_Desplegar_CAMP_APOYADAS(Dep, prog, idcamp, 0, "SUP_APOYADA");
                if (dt.Rows[0][1].ToString() != "")
                {
                    ((Label)e.Row.FindControl("LblSupInscrita")).Text = dt.Rows[0][1].ToString();
                    LblTotSupIns.Text = (Convert.ToDecimal(LblTotSupIns.Text) + Convert.ToDecimal(dt.Rows[0][1].ToString())).ToString();
                }
                else
                {
                    ((Label)e.Row.FindControl("LblSupInscrita")).Text = "0";
                }
                if (dt.Rows[0][2].ToString() != "")
                {
                    ((Label)e.Row.FindControl("LblSupApoyada")).Text = dt.Rows[0][2].ToString();
                    LblTotSupApo.Text = (Convert.ToDecimal(LblTotSupApo.Text) + Convert.ToDecimal(dt.Rows[0][2].ToString())).ToString();
                }
                else
                {
                    ((Label)e.Row.FindControl("LblSupApoyada")).Text = "0";
                }

                dt = ListRegCamp.DB_Desplegar_CAMP_APOYADAS(Dep, prog, idcamp, 0, "NUM_PROD_DEP");
                ((Label)e.Row.FindControl("LblNumDepurados")).Text = dt.Rows[0][0].ToString();
                LblTotNumDep.Text = (Convert.ToInt32(LblTotNumDep.Text) + Convert.ToInt32(dt.Rows[0][0].ToString())).ToString();
            }
            
        }
    }
}