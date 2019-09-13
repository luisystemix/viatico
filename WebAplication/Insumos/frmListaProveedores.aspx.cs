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

namespace WebAplication.Insumos
{
    public partial class frmListaProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LblIdUser.Text = Session["IdUser"].ToString();
                Llenar_DDLRegional();
                Llenar_DDLCAMPANHIA();
                Desplegar_PROVEEDOR();
            }
        }
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
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Desplegar_PROVEEDOR()
        {
            if(DDLCamp.SelectedValue!="")
            {
                string[] elementos = new string[] { "1", DDLCamp.SelectedValue, DDLRegional.SelectedValue, "1", DDLPrograma.SelectedValue, "1", "LISTA_PROV" };
                DB_AP_Proveedor p = new DB_AP_Proveedor();
                DataTable dt = new DataTable();
                dt = p.DB_Desplegar_PROVEEDOR_PARAMETROS(elementos);
                GVProveedores.DataSource = dt;
                GVProveedores.DataBind();
            }
            else
            {
            
            }
        }
        #endregion
        protected void LnkNuevo_Click(object sender, EventArgs e)
        {
            Session.Add("Idreg",DDLRegional.SelectedValue);
            Session.Add("Prog", DDLPrograma.SelectedValue);
            Session.Add("IdCamp",DDLCamp.SelectedValue);
            Response.Redirect("frmRegistroProveedor.aspx");
        }
        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DDLCAMPANHIA();
            Desplegar_PROVEEDOR();
        }
        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_PROVEEDOR();
        }
        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_PROVEEDOR();
        }

        protected void GVProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GVProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVProveedores.Columns[8].Visible = true;
            Desplegar_PROVEEDOR();
            Session.Add("IdInsProv", GVProveedores.Rows[rowIndex].Cells[8].Text);
            Session.Add("Insumo", GVProveedores.Rows[rowIndex].Cells[3].Text);
            switch (tipo)
            {
                case "Propuesta":
                    Response.Redirect("frmRegistrarPropuesta.aspx");
                    break;
            }
        }
    }
}