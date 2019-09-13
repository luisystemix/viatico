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
    public partial class frmControlDocOrg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdIsnOrg.Text = Session["IdInsOrg"].ToString();
                    Desplegar_ENCAVEZADO2();
                    Desplegar_INS_ORG_DOC_PRESENT();
                    if (Session["Estado"].ToString() == "modificar")
                    {
                        Desplegar_DOC_VERIF(Convert.ToInt32(LblIdIsnOrg.Text));
                    }
                    else 
                    {
                        TxtNumProd.Text = (Convert.ToInt32("0")).ToString();
                        TxtSupTot.Text=(Convert.ToDecimal("0")).ToString();
                    }
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Desplegar_ENCAVEZADO2()
        {
            DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = Usuario.DB_Desplegar_ENCABEZADO_ORG(Convert.ToInt32(LblIdIsnOrg.Text));
            ((Label)contEncabezado11.FindControl("LblRegional")).Text = dt.Rows[0][8].ToString();
            ((Label)contEncabezado11.FindControl("LblIdRegional")).Text = dt.Rows[0][7].ToString();
            ((Label)contEncabezado11.FindControl("LblCampanhia")).Text = dt.Rows[0][6].ToString();
            ((Label)contEncabezado11.FindControl("LblIdCampanhia")).Text = dt.Rows[0][5].ToString();
            ((Label)contEncabezado11.FindControl("LblPrograma")).Text = dt.Rows[0][9].ToString();
            LblOrganizacion.Text = dt.Rows[0][1].ToString();
        }
        #endregion
        #region FUNCION PARA SELECCIONAR LA TABLA DOCUMENTO VERIFICADO POR EL ID DE LA INSCRIPCION DE LA ORG
        private void Desplegar_DOC_VERIF(int id)
        {
            AP_DocVerificado dv = new AP_DocVerificado();
            DB_AP_DocVerificado dp = new DB_AP_DocVerificado();
            dv = dp.DB_Desplegar_DOC_VERIF(id);
            if (dv.Id_InscripcionOrg == id)
            {
                TxtNumProd.Text = dv.NumProductores.ToString();
                TxtSupTot.Text = dv.SuperficieTotal.ToString();
                TxtObservacion.Text = dv.Observacion;
            }
        }
        #endregion
        #region OBTENER LA LISTA DE LAS TABLAS INSCRIPCION_ORG => DOCUMENTO_PRESENTADO => DOCUMENTO_SOLICITADO
        protected void Desplegar_INS_ORG_DOC_PRESENT()
        {
            DB_AP_Registro_Org ListOrg = new DB_AP_Registro_Org();
            GVInsOrgDocPres.DataSource = ListOrg.DB_Desplegar_INS_ORG_DOC_PRESENT(Convert.ToInt32(LblIdIsnOrg.Text));
            GVInsOrgDocPres.DataBind();
        }
        #endregion
        #region REGISTRAR LA PRESENTACION DE DOCUMENTOS DE LA ORGANIZACION
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            DB_AP_DocPresentado nInsDoc = new DB_AP_DocPresentado();
            AP_DocPresentado i = new AP_DocPresentado();
            int j=0;
            int k = 0;
            CheckBox myCheckBox= new CheckBox();
            foreach (GridViewRow dgi in GVInsOrgDocPres.Rows)
            {
                myCheckBox = (CheckBox)dgi.Cells[2].Controls[1];
                GVInsOrgDocPres.Columns[1].Visible = true;
                Desplegar_INS_ORG_DOC_PRESENT();
                i.Id_Documento = Convert.ToInt32(GVInsOrgDocPres.Rows[j].Cells[1].Text);
                j++;
                i.Id_VerificarDoc = Convert.ToInt32(LblIdIsnOrg.Text);
                i.Estado = Convert.ToBoolean(myCheckBox.Checked);
                nInsDoc.DB_Modificar_DOC_PRESENT(i);
                if (myCheckBox.Checked==true)
                {
                    k++;
                }
            }
            if(k==j)
            {
                Modificar_ESTADO_DOC_VERIF();
            }
            Modificar_DOC_VERIF();
            Response.Redirect("frmRegistroOrg.aspx");
        }
        #endregion
        #region FUNCION PARA MODIFICAR EL ESTADO DE LA TABLA DOCUMENTO VERIFICADO
        private void Modificar_ESTADO_DOC_VERIF()
        {
            AP_DocVerificado dv = new AP_DocVerificado();
            DB_AP_Registro_Org no = new DB_AP_Registro_Org();
            dv.Id_InscripcionOrg = Convert.ToInt32(LblIdIsnOrg.Text);
            dv.Estado = "COMPLETO";
            no.DB_Modificar_ESTADO_DOC_VERIF(dv);
        }
        #endregion
        #region FUNCION PARA MODIFICAR LOS DATOS DE LA TABLA DOCUMENTO VERIFICADO
        private void Modificar_DOC_VERIF()
        {
            if (TxtNumProd.Text != "")
            {
                if (TxtSupTot.Text != "")
                {
                    AP_DocVerificado dv = new AP_DocVerificado();
                    DB_AP_DocVerificado no = new DB_AP_DocVerificado();
                    dv.Id_InscripcionOrg = Convert.ToInt32(LblIdIsnOrg.Text);
                    dv.NumProductores = Convert.ToInt32(TxtNumProd.Text);
                    dv.SuperficieTotal = Convert.ToDecimal(TxtSupTot.Text);
                    dv.Observacion = TxtObservacion.Text;
                    no.DB_Modificar_DOC_VERIF(dv);
                }
                else 
                {
                    LblMsj.Text = "El Campo de texto de superficie no puede estar vacío";
                }
            }
            else 
            {
                LblMsj.Text = "El Campo de texto numero de productores no puede estar vacío";
            }

        }
        #endregion
        #region FUNCIONES DE LA GRILLA
        protected void GVInsOrgDocPres_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                bool valor = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Estado"));
                if (valor == true)
                {
                    ((CheckBox)e.Row.FindControl("CbxEstado")).Checked = true;
                    ((CheckBox)e.Row.FindControl("CbxEstado")).Enabled = false;
                }
                if (valor == false)
                {
                    ((CheckBox)e.Row.FindControl("CbxEstado")).Checked = false;
                }
            }
        }
        #endregion
        #region ENVIAR A IMPRESION
        protected void ImgPrint_Click(object sender, ImageClickEventArgs e)
        {
            StringBuilder sbMensaje = new StringBuilder();
            Session.Add("IdInsOrg", LblIdIsnOrg.Text);
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Registro/repVerificacionDocOrg.aspx?ci=" + LblIdIsnOrg.Text);
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
        }
        #endregion
    }
}