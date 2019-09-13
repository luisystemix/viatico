using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;

namespace WebAplication.Insumos
{
    public partial class frmRegistroProv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Desplegar_USUARIO();
                Desplegar_PROV_INS_DOC();
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
            LblCamp.Text = dt.Rows[0][7].ToString();
            LblIdCamp.Text = dt.Rows[0][6].ToString();
        }
        #endregion
        #region FUNCION PARA DESPLEGAR LA LISTA DE RPROVEEDORES EN LA GRILLA
        protected void Desplegar_PROV_INS_DOC()
        {
            DB_AP_Registro_Org ListProv = new DB_AP_Registro_Org();
            GVProvInsDoc.DataSource = ListProv.DB_Desplegar_PROV_INS_DOC(Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), DDLPrograma.SelectedItem.Text, DDLInsumo.SelectedItem.Text, TxtBuscarProv.Text);
            GVProvInsDoc.DataBind();
        }
        #endregion
        #region EVENTO PARA REGISTRAR UNA NUEVA EMPRESA PROVEEDORA
        protected void LnkNuevoProv_Click(object sender, EventArgs e)
        {
            Session.Add("Programa",DDLPrograma.SelectedItem.Text);
            Session.Add("Insumo", DDLInsumo.SelectedItem.Text);
            Session.Add("Estado","nuevo");
            Response.Redirect("frmNuevoProv.aspx");
        }
        #endregion
        #region FUNCIONES DE LA GRILLLA
        protected void GVProvInsDoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVProvInsDoc.Columns[4].Visible = true;
            Desplegar_PROV_INS_DOC();
            Session.Add("IdInsProv", GVProvInsDoc.Rows[rowIndex].Cells[4].Text);
            Session.Add("Estado", "modificar");
            switch (tipo)
            {
                case "Modificar":
                    Response.Redirect("frmNuevoProv.aspx");
                    break;
                case "Revisar-Doc":
                    Response.Redirect("frmControlDocProv.aspx");
                    break;
            } 
        }
        #endregion
        #region FUNCIONES DE LOS CONTROLES 
        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_PROV_INS_DOC();
        }

        protected void DDLInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_PROV_INS_DOC();
        }

        protected void ImgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Desplegar_PROV_INS_DOC();
        }
        #endregion
    }
}