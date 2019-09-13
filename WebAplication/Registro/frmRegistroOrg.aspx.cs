using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataEntity.DE_Registro;
using DataBusiness.DB_Registro;

namespace WebAplication.Registro
{
    public partial class frmRegistroOrg1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                        Desplegar_USUARIO();
                        LblIdCamp.Text = DDLCamp.SelectedValue;
                        Seleccionar_CAMPANHIA_ID();
                        Desplegar_ORG_INS_DOC();
                        
                }
             }
             catch
             {
                 Response.Redirect("~/About.aspx");
             }
        }
        #region FUNCION PARA DESPLEGAR DATOS DE LA CAMPAÑA POR EL ID
        protected void Seleccionar_CAMPANHIA_ID()
        {
            DB_AP_Campanhia cam = new DB_AP_Campanhia();
            AP_Campanhia ca = new AP_Campanhia();
            ca = cam.DB_Buscar_CAMPANHIA(Convert.ToInt32(LblIdCamp.Text));
            LblEstadoCamp.Text = ca.Estado;
        }
        #endregion
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Desplegar_USUARIO()
        {
            DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = Usuario.DB_Desplegar_USUARIO(Session["IdUser"].ToString());
            LblRegional.Text = dt.Rows[0][5].ToString();
            LblIdReg.Text = dt.Rows[0][4].ToString();
            DB_AP_Campanhia camp = new DB_AP_Campanhia();
            dt = camp.DB_Desplegar_CAMPANHIA_REGION(dt.Rows[0][10].ToString());
            DDLCamp.DataSource = dt;
            DDLCamp.DataValueField = "Id_Campanhia";
            DDLCamp.DataTextField = "Nombre";
            DDLCamp.DataBind();
        }
        #endregion
        #region FUNCION PARA DESPLEGAR LA LISTA DE ORGANIZACIONES EN LA GRILLA
        protected void Desplegar_ORG_INS_DOC()
        {
            DB_AP_Registro_Org  ListOrg = new DB_AP_Registro_Org();
            GVOrgInsDoc.DataSource = ListOrg.DB_Desplegar_ORG_INS_DOC(Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), DDLPrograma.SelectedValue, TxtBuscarOrg.Text);
            GVOrgInsDoc.DataBind();
        }
        #endregion
        #region FUNCION PARA REALIZAR NUEVA INSCRIPCION DE ORGANIZACION
        protected void LnkNuevaOrg_Click(object sender, EventArgs e)
        {
            if (LblEstadoCamp.Text == "REGISTRO")
            {
                Session.Add("Estado", "nuevo");
                Session.Add("IdCamp", LblIdCamp.Text);
                Session.Add("Prog", DDLPrograma.SelectedItem.Text);
                Response.Redirect("frmNuevaOrg.aspx");
            }
            else 
            {
                LblMsj.Text = "El estado de la campaña NO está en la etapa de REGISTRO";
            }
        }
        #endregion
        #region FUNCION PARA MODIFICAR UNA INSCRIPCION DE ORGANIZACION
        protected void GVOrgInsDoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVOrgInsDoc.Columns[6].Visible = true;
            Desplegar_ORG_INS_DOC();
            Session.Add("IdInsOrg", GVOrgInsDoc.Rows[rowIndex].Cells[6].Text);
            Session.Add("Estado", "modificar");
            switch (tipo)
            {
                case "Modificar":
                    if (GVOrgInsDoc.Rows[rowIndex].Cells[5].Text == "REGISTRADO")
                    {
                        Response.Redirect("frmNuevaOrg.aspx");
                    }
                    else 
                    {
                        LblMsj.Text = "NO PUEDE REALIZAR CAMBIOS ESTADO: " + GVOrgInsDoc.Rows[rowIndex].Cells[5].Text; 
                    }
                    break;
                case "Revisar-Doc":
                    Response.Redirect("frmControlDocOrg.aspx");
                    break;
            }
            GVOrgInsDoc.Columns[6].Visible = false;
            Desplegar_ORG_INS_DOC();
        }
        #endregion
        #region FUNCION DE EVENTOS COMBO Y LINKBUTTUM 
        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB_AP_Campanhia ca = new DB_AP_Campanhia();
            DataTable dt = new DataTable();
            dt = ca.DB_Seleccionar_CAMPANHIA_PROG(Convert.ToInt32(LblIdCamp.Text), 0, DDLPrograma.SelectedValue, "CAMP_PROG");
            if(dt.Rows.Count > 0)
            {
                LblMsj.Text=string.Empty;
                LnkNuevaOrg.Visible = true;
            }
            else
            {
                LnkNuevaOrg.Visible = false;
                LblMsj.Text = "El programa no está definido en esta campaña";
            }
            Desplegar_ORG_INS_DOC();
        }
        protected void ImgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Desplegar_ORG_INS_DOC();
        }
        #endregion

        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblIdCamp.Text = DDLCamp.SelectedValue;
            Seleccionar_CAMPANHIA_ID();
            Desplegar_ORG_INS_DOC();
        }
    }
}