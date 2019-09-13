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


namespace WebAplication.Responsable
{
    public partial class frmCrearListaOficial : System.Web.UI.Page
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
                    Desplegar_ORG_LIST_OFI();
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
        #region FUNCION PARA DESPLEGAR LA LISTA DE ORGANIZACIONES EN LA GRILLA
        protected void Desplegar_ORG_LIST_OFI()
        {
           if(DDLCamp.SelectedValue!="")
           {
                LblMsj.Text = string.Empty;
                DB_AP_Registro_Org ListOrg = new DB_AP_Registro_Org();
                GVOrgInsDoc.DataSource = ListOrg.DB_Desplegar_ORG_LIST_OFI(Convert.ToInt32(DDLCamp.SelectedValue), Convert.ToInt32(DDLRegional.SelectedValue), DDLPrograma.SelectedValue, TxtBuscarOrg.Text);
                GVOrgInsDoc.DataBind();
           }
           else
           {
            LblMsj.Text = "No se definieron   campañas";
           }
        }
        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_ORG_LIST_OFI();
        }

        protected void ImgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Desplegar_ORG_LIST_OFI();
        }

        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DDLCAMPANHIA();
            Desplegar_ORG_LIST_OFI();
        }
        #endregion

        protected void GVOrgInsDoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVOrgInsDoc.Columns[7].Visible = true;
            Desplegar_ORG_LIST_OFI();
            //Session.Add("IdInsOrg", GVOrgInsDoc.Rows[rowIndex].Cells[5].Text);
            TSHAK.Components.SecureQueryString querystringSeguro;
            querystringSeguro = new TSHAK.Components.SecureQueryString(new Byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 8 });
            querystringSeguro["IdInsOrg"] = Convert.ToString(GVOrgInsDoc.Rows[rowIndex].Cells[7].Text);
            Session.Add("Estado", "modificar");
            switch (tipo)
            {
                case "ListaOficial":
                    Response.Redirect("frmListaProductorOfi.aspx?data=" + HttpUtility.UrlEncode(Convert.ToString(querystringSeguro)) + "");
                break;
                case "ListaPreliminar":
                if (GVOrgInsDoc.Rows[rowIndex].Cells[5].Text != "APROBADO-CART")
                    {
                      Response.Redirect("frmListaProductorPre.aspx?data=" + HttpUtility.UrlEncode(Convert.ToString(querystringSeguro)) + "");
                    }
                    else
                    {
                        LblMsj.Text = "YA SE APROBÓ LA LISTA OFICIAL, NO SE PUEDEN HACER CAMBIOS";
                    }
                break;
            }
            GVOrgInsDoc.Columns[7].Visible = false;
            Desplegar_ORG_LIST_OFI();
        }

        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_ORG_LIST_OFI();
        }
    }
}