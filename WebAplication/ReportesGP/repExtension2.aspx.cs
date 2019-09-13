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
    public partial class repExtension2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            if (!IsPostBack)
            {
                LblCamp.Text = Session["Camp"].ToString();
                LblPrograma.Text = Session["Prog"].ToString();
                LblIdCamp.Text = Session["IdCamp"].ToString();
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
            GVPRodDep.DataSource = rep.DB_Desplegar_REGIONALES_NOMBRE(LblCamp.Text);
            GVPRodDep.DataBind();
        }
        #endregion

        protected void GVPRodDep_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DB_EXT_Reportes rep = new DB_EXT_Reportes();
            DataTable dt = new DataTable();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int idcamp = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Campanhia"));
                int idreg = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Regional"));
                dt = rep.DB_Obtener_SUPERFICIE_INS_APO(idcamp, idreg, 0, 0, LblPrograma.Text, "NUM_MUNICIPIOS");
                if (dt.Rows[0][0].ToString() != "")
                {
                    ((Label)e.Row.FindControl("LbNumlMuni")).Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    ((Label)e.Row.FindControl("LbNumlMuni")).Text = "0.00";
                }
                dt = rep.DB_Obtener_SUPERFICIE_INS_APO(idcamp, idreg, 0, 0, LblPrograma.Text, "NUM_ORG");
                if (dt.Rows[0][0].ToString() != "")
                {
                    ((Label)e.Row.FindControl("LblNumOrg")).Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    ((Label)e.Row.FindControl("LblNumOrg")).Text = "0.00";
                }
                dt = rep.DB_Obtener_SUPERFICIE_INS_APO(idcamp, idreg, 0, 0, LblPrograma.Text, "NUM_PROD");
                if (dt.Rows[0][0].ToString() != "")
                {
                    ((Label)e.Row.FindControl("LblNumProd")).Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    ((Label)e.Row.FindControl("LblNumProd")).Text = "0.00";
                }
                dt = rep.DB_Obtener_SUPERFICIE_INS_APO(idcamp, idreg, 0, 0, LblPrograma.Text, "SUP_REGIONAL");
                if (dt.Rows[0][0].ToString() != "")
                {
                    ((Label)e.Row.FindControl("LblNumSup")).Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    ((Label)e.Row.FindControl("LblNumSup")).Text = "0.00";
                }
                LblTotNumMuni.Text = Convert.ToString(Convert.ToDecimal(LblTotNumMuni.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LbNumlMuni")).Text));
                LblTotNumOrgs.Text = Convert.ToString(Convert.ToDecimal(LblTotNumOrgs.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblNumOrg")).Text));
                LblTotNumProd.Text = Convert.ToString(Convert.ToDecimal(LblTotNumProd.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblNumProd")).Text));
                LblTotSupApo.Text = Convert.ToString(Convert.ToDecimal(LblTotSupApo.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblNumSup")).Text));
            }
        }

        protected void DDLProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblTotNumMuni.Text = "0";
            LblTotNumOrgs.Text = "0";
            LblTotNumProd.Text = "0";
            LblTotSupApo.Text = "0";
            Llenar_GRILLA();
        }

        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblTotNumMuni.Text = "0";
            LblTotNumOrgs.Text = "0";
            LblTotNumProd.Text = "0";
            LblTotSupApo.Text = "0";
            Llenar_GRILLA();
        }
    }
}