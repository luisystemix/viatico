using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;
using DataEntity.DE_General;
using DataBusiness.DB_General;
using DataEntity.DE_Registro;
using DataBusiness.DB_Insumos;

namespace WebAplication.Insumos
{
    public partial class frmListaRegistroDitrib : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUser.Text = Session["IdUser"].ToString();
                    Llenar_DDLRegional();
                    Llenar_DDLCAMPANHIA();
                    Desplegar_GRILLA();
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
            DB_Regional reg = new DB_Regional();
            DataTable dt = new DataTable();
            dt = reg.DB_Seleccionar_REGIONAL(Convert.ToInt32(DDLRegional.SelectedValue));
            string aux = dt.Rows[0][7].ToString();
            dt = cam.DB_Seleccionar_CAMPANHIA_REG(aux, "INICIADO");
            DDLCamp.DataSource = dt;
            DDLCamp.DataValueField = "Id_Campanhia";
            DDLCamp.DataTextField = "Nombre";
            DDLCamp.DataBind();
        }
        #endregion
        #region FUNCION PARA LLENAR EL COMBO CON EL TIPO DE ORGANIZACION
        private void Llenar_DDLRegional()
        {
            DB_Regional reg = new DB_Regional();
            List<Regional> Lista = reg.DB_Desplegar_REGIONAL();
            DDLRegional.DataSource = Lista;
            DDLRegional.DataValueField = "Id_Regional";
            DDLRegional.DataTextField = "Nombre";
            DDLRegional.DataBind();
        }
        #endregion

        protected void LnkInportar_Click(object sender, EventArgs e)
        {
            Session.Add("IdCamp",DDLCamp.SelectedValue);
            Session.Add("IdReg", DDLRegional.SelectedValue);
            Session.Add("IdProg",DDLPrograma.SelectedValue);
            Response.Redirect("frmRegistrarDsitribucion.aspx");
        }

        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DDLCAMPANHIA();
            Desplegar_GRILLA();
        }
        protected void DDLInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_GRILLA();
        }
        protected void Desplegar_GRILLA() 
        {
            DB_INS_Distribucion dist = new DB_INS_Distribucion();
            GVListDistribIns.DataSource = dist.DB_Desplegar_INSUMOS_DISTRIBUIDOS(Convert.ToInt32(DDLCamp.SelectedValue), Convert.ToInt32(DDLRegional.SelectedValue), DDLPrograma.SelectedValue, DDLInsumo.SelectedItem.Text, "LIST_DISTRIB");
            GVListDistribIns.DataBind();
        }

        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_GRILLA();
        }

        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_GRILLA();
        }
    }
}