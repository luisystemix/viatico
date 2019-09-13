using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;
using DataBusiness.DB_General;

namespace WebAplication.Responsable
{
    public partial class frmControlRegional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Desplegar_USUARIO();
                    Llenar_DDLCAMPANHIA();
                    Llenar_DATOS_REGIONAL();
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
            DB_AP_Campanhia camp = new DB_AP_Campanhia();
            List<AP_Campanhia> Lista = camp.DB_Desplegar_CAMPANHIA();
            DDLCamp.DataSource = Lista;
            DDLCamp.DataValueField = "Id_Campanhia";
            DDLCamp.DataTextField = "Nombre";
            DDLCamp.DataBind();
        }
        #endregion
        #region FUNCION PARA DESPLEGAR LA GRILLA CON LA INFORMACION DE LAS REGIONALES
        private void Llenar_DATOS_REGIONAL() 
        {
            DB_Regional dreg = new DB_Regional();
            GVRegional.DataSource = dreg.DB_Desplegar_REGIONAL_DATOS();
            GVRegional.DataBind();
        }
        #endregion

        protected void GVRegional_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVRegional.Columns[9].Visible = true;
            Llenar_DATOS_REGIONAL();
            Session.Add("IdCamp", DDLCamp.SelectedValue);
            Session.Add("IdReg", GVRegional.Rows[rowIndex].Cells[9].Text);
            switch (tipo)
            {
                case "Cronograma":
                    Response.Redirect("../Registro/repCronogramaRegIni.aspx");
                    break;
                case "CronoTec":
                    Response.Redirect("../Control/frmListCronogramaReg.aspx");
                    break;
            }
        }

        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DATOS_REGIONAL();
        }
    }
}