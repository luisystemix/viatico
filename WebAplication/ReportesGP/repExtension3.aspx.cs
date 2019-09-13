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

namespace WebAplication.ReportesGP
{
    public partial class repExtension3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            if (!IsPostBack)
            {
                LblPrograma.Text = Session["Prog"].ToString();
                LblCamp.Text = Session["Camp"].ToString();
                LblIdCamp.Text = Session["IdCamp"].ToString();
                LblReg.Text = Session["Reg"].ToString();
                LblIdReg.Text = Session["IdReg"].ToString();
                Llenar_GRILLA();
            }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //} 
        }
        #region FUNCION PARA DESPLEGAR LA GRILLA
        private void Llenar_GRILLA()
        {
            DB_EXT_Reportes rep = new DB_EXT_Reportes();
            GVPRodDep.DataSource = rep.DB_Obtener_SUPERFICIE_INS_APO(Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), 0, 0, LblPrograma.Text, "MUNICIOPIO_ORG");
            GVPRodDep.DataBind();
        }
        #endregion

        protected void DDLProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblTotNumProd.Text = "0";
            LblTotSupInsHa.Text = "0";
            LblTotSupApo.Text = "0";
            LblTotRendFnHa.Text = "0";
            LblTotProdfn.Text = "0";
            Llenar_GRILLA();
        }

        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblTotNumProd.Text = "0";
            LblTotSupInsHa.Text = "0";
            LblTotSupApo.Text = "0";
            LblTotRendFnHa.Text = "0";
            LblTotProdfn.Text = "0";
            Llenar_GRILLA();
        }

        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblTotNumProd.Text = "0";
            LblTotSupInsHa.Text = "0";
            LblTotSupApo.Text = "0";
            LblTotRendFnHa.Text = "0";
            LblTotProdfn.Text = "0";
            Llenar_GRILLA();
        }

        protected void GVPRodDep_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DB_EXT_Reportes rep = new DB_EXT_Reportes();
            DataTable dt = new DataTable();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int idinsorg = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_InscripcionOrg"));
                int idMuni = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Municipio"));
                dt = rep.DB_Obtener_SUPERFICIE_INS_APO(Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), idinsorg, idMuni, LblPrograma.Text, "SUP_INS_APO_MUNI");
                if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                {
                    ((Label)e.Row.FindControl("LblNumP")).Text = dt.Rows[0][0].ToString();
                    ((Label)e.Row.FindControl("LblSupIns")).Text = dt.Rows[0][1].ToString();
                    ((Label)e.Row.FindControl("LblSupApo")).Text = dt.Rows[0][2].ToString();
                }
                else
                {
                    ((Label)e.Row.FindControl("LblNumP")).Text = "0";
                    ((Label)e.Row.FindControl("LblSupIns")).Text = "0.00";
                    ((Label)e.Row.FindControl("LblSupApo")).Text = "0.00";
                }
                dt = rep.DB_Obtener_SUPERFICIE_INS_APO(Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), idinsorg, idMuni, LblPrograma.Text, "RENDIMIENTO_MUNI");
                ((Label)e.Row.FindControl("LblRendFnha")).Text = dt.Rows[0][0].ToString();
                //((Label)e.Row.FindControl("LblProdFn")).Text = Convert.ToString(Math.Round((Convert.ToDecimal(((Label)e.Row.FindControl("LblSupApo")).Text) * Convert.ToDecimal(((Label)e.Row.FindControl("LblRendFnha")).Text)), 2));

                LblTotNumProd.Text = Convert.ToString(Convert.ToDecimal(LblTotNumProd.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblNumP")).Text));
                LblTotSupInsHa.Text = Convert.ToString(Convert.ToDecimal(LblTotSupInsHa.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblSupIns")).Text));
                LblTotSupApo.Text = Convert.ToString(Convert.ToDecimal(LblTotSupApo.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblSupApo")).Text));
                LblTotRendFnHa.Text = Convert.ToString(Convert.ToDecimal(LblTotRendFnHa.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblRendFnha")).Text));
                //LblTotProdfn.Text = Convert.ToString(Convert.ToDecimal(LblTotProdfn.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblProdFn")).Text));   
            }
        }
    }
}