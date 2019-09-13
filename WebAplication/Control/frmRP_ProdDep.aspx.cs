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
    public partial class frmRP_ProdDep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    Llenar_DDLCAMPANHIA();
                    Llenar_GRILLA();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            } 
        }
        #region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS
        private void Llenar_DDLCAMPANHIA()
        {
            DB_AP_Campanhia cam = new DB_AP_Campanhia();
            DataTable dt = new DataTable();
            dt = cam.DB_Seleccionar_CAMPANHIA_REG_NOFIN("ORIENTE");
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
            GVPRodDep.DataSource = rep.DB_Desplegar_REGIONALES_NOMBRE(DDLCamp.SelectedItem.Text);
            GVPRodDep.DataBind();
        }
        #endregion
        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblTotSupIns.Text = "0";
            LblTotSupApo.Text = "0";
            LblTotRedFn.Text = "0";
            LblTotProdFn.Text = "0";
            LblTotProdTon.Text = "0";
            Llenar_GRILLA();
        }
        protected void DDLProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblTotSupIns.Text = "0";
            LblTotSupApo.Text = "0";
            LblTotRedFn.Text = "0";
            LblTotProdFn.Text = "0";
            LblTotProdTon.Text = "0";
            Llenar_GRILLA();
        }

        protected void GVPRodDep_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DB_EXT_Reportes rep = new DB_EXT_Reportes();
            DataTable dt = new DataTable();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int idcamp = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Campanhia")); 
                int idreg = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Regional"));     
                dt = rep.DB_Obtener_SUPERFICIE_INS_APO(idcamp, idreg, 0, 0, DDLProg.SelectedValue, "SUP_REGIONAL");
                if (dt.Rows[0][0].ToString()!="")
                {
                    ((Label)e.Row.FindControl("LblSupApo")).Text = dt.Rows[0][0].ToString();
                    ((Label)e.Row.FindControl("LblSupSem")).Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    ((Label)e.Row.FindControl("LblSupApo")).Text = "0.00";
                    ((Label)e.Row.FindControl("LblSupSem")).Text = "0.00";
                }
                dt = rep.DB_Obtener_SUPERFICIE_INS_APO(idcamp, idreg, 0, 0, DDLProg.SelectedValue, "REND_REGIONAL");
                ((Label)e.Row.FindControl("LblRend")).Text = dt.Rows[0][0].ToString();
                ((Label)e.Row.FindControl("LblProdFan")).Text = Convert.ToString(Math.Round((Convert.ToDecimal(((Label)e.Row.FindControl("LblSupSem")).Text) * Convert.ToDecimal(((Label)e.Row.FindControl("LblRend")).Text)),2));
                ((Label)e.Row.FindControl("LblProdTon")).Text = Convert.ToString(Math.Round((Convert.ToDecimal(((Label)e.Row.FindControl("LblProdFan")).Text) * Convert.ToDecimal("0.17664")),2));
                LblTotSupIns.Text = Convert.ToString(Convert.ToDecimal(LblTotSupIns.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblSupApo")).Text));
                LblTotSupApo.Text = Convert.ToString(Convert.ToDecimal(LblTotSupApo.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblSupSem")).Text));
                LblTotRedFn.Text = Convert.ToString(Convert.ToDecimal(LblTotRedFn.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblRend")).Text));
                LblTotProdFn.Text = Convert.ToString(Convert.ToDecimal(LblTotProdFn.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblProdFan")).Text));
                LblTotProdTon.Text = Convert.ToString(Convert.ToDecimal(LblTotProdTon.Text) + Convert.ToDecimal(((Label)e.Row.FindControl("LblProdTon")).Text));
            }
        }

        protected void ImgBtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("Prog", DDLProg.SelectedValue);
            Session.Add("IdCamp", LblIdCamp.Text);
            Session.Add("Camp", DDLCamp.SelectedItem.Text);
            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../ReportesGP/repExtension1.aspx?ci=" + LblIdCamp.Text);
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmRP_SegFenologiaDep.aspx");
        }
    }
}