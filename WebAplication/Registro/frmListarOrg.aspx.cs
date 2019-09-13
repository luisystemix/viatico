using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;

namespace WebAplication.Registro
{
    public partial class frmListarOrg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
               try
               {
                    if (!IsPostBack)
                    {
                        Desplegar_USUARIO();
                        Desplegar_ORG_INS_DOC();
                    }
               }
               catch
               {
                   Response.Redirect("~/About.aspx");
               }
        }
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Desplegar_USUARIO()
        {
            DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = Usuario.DB_Desplegar_USUARIO(Session["IdUser"].ToString());
            LblRegional.Text = dt.Rows[0][5].ToString();
            LblIdReg.Text = dt.Rows[0][4].ToString();
            LblIdRol.Text = dt.Rows[0][6].ToString();
            DB_AP_Campanhia camp = new DB_AP_Campanhia();
            dt = camp.DB_Seleccionar_CAMPANHIA_REG_NOFIN(dt.Rows[0][10].ToString());
            LblCampanhia.Text = dt.Rows[0][1].ToString();
            LblIdCamp.Text = dt.Rows[0][0].ToString();
        }
        #endregion
        #region FUNCION PARA DESPLEGAR LA LISTA DE ORGANIZACIONES EN LA GRILLA
        protected void Desplegar_ORG_INS_DOC()
        {
            DB_AP_Registro_Org ListOrg = new DB_AP_Registro_Org();
            GVOrgInsDoc.DataSource = ListOrg.DB_Desplegar_ORG_INS_DOC(Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), DDLPrograma.SelectedValue, TxtBuscarOrg.Text);
            GVOrgInsDoc.DataBind();
        }
        #endregion
        #region FUNCION PARA REALIZAR NUEVA INSCRIPCION DE ORGANIZACION
        protected void LnkNuevaOrg_Click(object sender, EventArgs e)
        {
            Session.Add("Estado", "nuevo");
            Response.Redirect("frmNuevaOrg.aspx");
        }
        #endregion
        #region FUNCION PARA MODIFICAR UNA INSCRIPCION DE ORGANIZACION
        protected void GVOrgInsDoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            StringBuilder sbMensaje = new StringBuilder();
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVOrgInsDoc.Columns[6].Visible = true;
            Desplegar_ORG_INS_DOC();
            Session.Add("IdInsOrg", GVOrgInsDoc.Rows[rowIndex].Cells[6].Text);
            TSHAK.Components.SecureQueryString querystringSeguro;
            querystringSeguro = new TSHAK.Components.SecureQueryString(new Byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 8 });
            querystringSeguro["IdInsOrg"] = Convert.ToString(GVOrgInsDoc.Rows[rowIndex].Cells[6].Text);
            Session.Add("Estado", "modificar");
            Session.Add("Estado", "modificar");
            switch (tipo)
            {
                case "Productor":
                    if (GVOrgInsDoc.Rows[rowIndex].Cells[5].Text == "REGISTRADO")
                    {
                        switch (Convert.ToInt32(LblIdRol.Text))
                        {
                            case 3:
                                Response.Redirect("frmRegistroProductorOrg.aspx?data=" + HttpUtility.UrlEncode(Convert.ToString(querystringSeguro)) + "");
                                break;
                            case 2:
                                Response.Redirect("frmRegistroProductorOrg.aspx?data=" + HttpUtility.UrlEncode(Convert.ToString(querystringSeguro)) + "");
                                break;
                            case 4:
                                //Response.Redirect("frmListarProductor.aspx");   OJOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                                Response.Redirect("frmListaProductorPre.aspx");
                                break;
                        }
                    }
                    else
                    {
                        LblMsj1.Text = "NO SE PUEDE REGISTRAR MAS PRODUCTORES, ORG.: " + GVOrgInsDoc.Rows[rowIndex].Cells[5].Text;
                    }
                    break;
                case "Planilla":
                    if (GVOrgInsDoc.Rows[rowIndex].Cells[5].Text != "SIN PRODUCTOR")
                    {
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Registro/repPlanillaProductores.aspx?ci=" + GVOrgInsDoc.Rows[rowIndex].Cells[6].Text);
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                        //Response.Redirect("repPlanillaProductores.aspx");
                    }
                    else 
                    {
                        LblMsj1.Text = "SIN PRODUCTORES";
                        GVOrgInsDoc.Columns[6].Visible = false;
                        Desplegar_ORG_INS_DOC();
                    }
                    break;
            }
            GVOrgInsDoc.Columns[6].Visible = false;
            Desplegar_ORG_INS_DOC();
        }
        #endregion
        #region FUNCIONES DEL COMBO Y EL BOTON IMAGEN
        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_ORG_INS_DOC();
            LblMsj1.Text = string.Empty;
        }

        protected void ImgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Desplegar_ORG_INS_DOC();
        }
        #endregion
    }
}