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
    public partial class frmRP_SupRendProdZonas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            if (!IsPostBack)
            {
                LblIdUsuario.Text = Session["IdUser"].ToString();
                Llenar_DDLRegional();
                Llenar_DDLCAMPANHIA();
                Llenar_GRILLA();
            }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //} 
        }
        #region FUNCION PARA LLENAR EL COMBO CON EL TIPO DE ORGANIZACION
        private void Llenar_DDLRegional()
        {
            DB_AdminUser User = new DB_AdminUser();
            DataTable dt = User.DB_Desplegar_USUARIO(LblIdUsuario.Text);
            //LblReg.Text = dt.Rows[0][13].ToString();
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
            DB_Regional reg = new DB_Regional();
            DataTable dt = new DataTable();
            dt = reg.DB_Seleccionar_REGIONAL(Convert.ToInt32(DDLRegional.SelectedValue));
            string aux = dt.Rows[0][7].ToString();
            dt = cam.DB_Seleccionar_CAMPANHIA_REG_NOFIN(aux);
            DDLCamp.DataSource = dt;
            DDLCamp.DataValueField = "Id_Campanhia";
            DDLCamp.DataTextField = "Nombre";
            DDLCamp.DataBind();
        }
        #endregion
        #region FUNCION PARA DESPLEGAR LA GRILLA
        private void Llenar_GRILLA()
        {
            DB_EXT_Reportes rep = new DB_EXT_Reportes();
            GVPRodDep.DataSource = rep.DB_Obtener_SUPERFICIE_INS_APO(Convert.ToInt32(DDLCamp.SelectedValue), Convert.ToInt32(DDLRegional.SelectedValue), 0, 0, DDLProg.SelectedValue, "MUNICIOPIO_ORG");
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
            Llenar_DDLCAMPANHIA();
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
                dt = rep.DB_Obtener_SUPERFICIE_INS_APO(Convert.ToInt32(DDLCamp.SelectedValue), Convert.ToInt32(DDLRegional.SelectedValue), idinsorg, idMuni, DDLProg.SelectedValue, "SUP_INS_APO_MUNI");
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
                dt = rep.DB_Obtener_SUPERFICIE_INS_APO(Convert.ToInt32(DDLCamp.SelectedValue), Convert.ToInt32(DDLRegional.SelectedValue), idinsorg, idMuni, DDLProg.SelectedValue, "RENDIMIENTO_MUNI");
                ((Label)e.Row.FindControl("LblRendFnha")).Text = dt.Rows[0][0].ToString();
                //((Label)e.Row.FindControl("LblProdFn")).Text = Convert.ToString(Math.Round((Convert.ToDecimal(((Label)e.Row.FindControl("LblSupApo")).Text) * Convert.ToDecimal(((Label)e.Row.FindControl("LblRendFnha")).Text)), 2));
                
                LblTotNumProd.Text = Convert.ToString(Convert.ToDecimal(LblTotNumProd.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblNumP")).Text));
                LblTotSupInsHa.Text = Convert.ToString(Convert.ToDecimal(LblTotSupInsHa.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblSupIns")).Text));
                LblTotSupApo.Text = Convert.ToString(Convert.ToDecimal(LblTotSupApo.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblSupApo")).Text));
                LblTotRendFnHa.Text = Convert.ToString(Convert.ToDecimal(LblTotRendFnHa.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblRendFnha")).Text));
                //LblTotProdfn.Text = Convert.ToString(Convert.ToDecimal(LblTotProdfn.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblProdFn")).Text));   
            
            }
        }

        protected void ImgBtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("Prog", DDLProg.SelectedValue);
            Session.Add("IdCamp", DDLCamp.SelectedValue);
            Session.Add("Camp", DDLCamp.SelectedItem.Text);
            Session.Add("IdReg", DDLRegional.SelectedValue);
            Session.Add("Reg", DDLRegional.SelectedItem.Text);
            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../ReportesGP/repExtension3.aspx?ci=" + LblIdCamp.Text);
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
        }
    }
} 