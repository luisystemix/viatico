using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataEntity.DE_Registro;
using DataBusiness.DB_Registro;

namespace WebAplication.Insumos
{
    public partial class frmControlDocProv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Desplegar_ENCAVEZADO_PROD();
                Desplegar_INS_PROV_DOC_PRESENT();
            }
        }
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Desplegar_ENCAVEZADO_PROD()
        {
            DB_AP_Registro_Org vro = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = vro.DB_Desplegar_ENCAVEZADO_PROV(Convert.ToInt32(Session["IdInsProv"].ToString()));
            LblEmpresa.Text = dt.Rows[0][0].ToString();
            LblIdInsEmp.Text = dt.Rows[0][9].ToString();
            LblCamp.Text = dt.Rows[0][4].ToString();
            LblIdCamp.Text = dt.Rows[0][8].ToString();
            LblPrograma.Text = dt.Rows[0][3].ToString();
            LblInsumo.Text = dt.Rows[0][2].ToString();
        }
        #endregion
        #region OBTENER LA LISTA DE LAS TABLAS INSCRIPCION_ORG => DOCUMENTO_PRESENTADO => DOCUMENTO_SOLICITADO
        protected void Desplegar_INS_PROV_DOC_PRESENT()
        {
            DB_AP_Registro_Org ListOrg = new DB_AP_Registro_Org();
            GVInsProvDocPres.DataSource = ListOrg.DB_Desplegar_INS_PROV_DOC_PRESENT(Convert.ToInt32(LblIdInsEmp.Text));
            GVInsProvDocPres.DataBind();
        }
        #endregion
        #region FUNCIONES DE LA GRILLA
        protected void GVInsProvDocPres_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                bool valor = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Estado"));
                if (valor == true)
                {
                    ((CheckBox)e.Row.FindControl("CbxEstado")).Checked = true;
                    ((CheckBox)e.Row.FindControl("CbxEstado")).Enabled = false;
                    ((TextBox)e.Row.FindControl("TxtObser")).Enabled = false;
                }
                if (valor == false)
                {
                    ((CheckBox)e.Row.FindControl("CbxEstado")).Checked = false;
                }
            }
        }
        #endregion
        #region FUNCION PARA REGISTRAR LOS DATOS DEL DOCUMENTO
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            DB_AP_DocPresentadoProv InsProv = new DB_AP_DocPresentadoProv();
            AP_DocPresentadoProv p = new AP_DocPresentadoProv();
            foreach (GridViewRow dgi in GVInsProvDocPres.Rows)
            {
                CheckBox myCheckBox = (CheckBox)dgi.Cells[3].Controls[1];
                TextBox tx = (TextBox)dgi.Cells[4].Controls[1];
                GVInsProvDocPres.Columns[1].Visible = true;
                GVInsProvDocPres.Columns[2].Visible = true;
                Desplegar_INS_PROV_DOC_PRESENT();
                if (myCheckBox.Checked == true)
                {
                    p.Id_VerificarDoc = Convert.ToInt32(GVInsProvDocPres.Rows[dgi.RowIndex].Cells[2].Text);
                    p.Id_Documento = Convert.ToInt32(GVInsProvDocPres.Rows[dgi.RowIndex].Cells[1].Text);
                    p.Observacion = "";
                    p.Estado = true;
                    InsProv.DB_Modificar_ESTADO(p);
                }
                else 
                {
                    p.Id_VerificarDoc = Convert.ToInt32(GVInsProvDocPres.Rows[dgi.RowIndex].Cells[2].Text);
                    p.Id_Documento = Convert.ToInt32(GVInsProvDocPres.Rows[dgi.RowIndex].Cells[1].Text);
                    p.Observacion = tx.Text;
                    p.Estado = false;
                    InsProv.DB_Modificar_ESTADO(p);
                }
            }
            Response.Redirect("frmRegistroProv.aspx");
        }
        #endregion

        protected void ImgPrint_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("IdInsEmp",LblIdInsEmp);
            Response.Redirect("repVerificacionDocProv.aspx");
        }
    }
}