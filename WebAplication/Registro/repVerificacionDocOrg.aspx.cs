using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;

namespace WebAplication.Registro
{
    public partial class repVerificacionDocOrg1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdIsnOrg.Text = Session["IdInsOrg"].ToString();
                    Desplegar_INS_ORG_DOC_PRESENT();
                    Desplegar_DOC_VERIF_REPORTE(Convert.ToInt32(LblIdIsnOrg.Text));
                }
            }
            catch 
            {
               // Response.Redirect("~/About.aspx");
            }
        }
        #region OBTENER LA LISTA DE LAS TABLAS INSCRIPCION_ORG => DOCUMENTO_PRESENTADO => DOCUMENTO_SOLICITADO
        protected void Desplegar_INS_ORG_DOC_PRESENT()
        {
            DB_AP_Registro_Org ListOrg = new DB_AP_Registro_Org();
            GVInsOrgDocPres.DataSource = ListOrg.DB_Desplegar_INS_ORG_DOC_PRESENT(Convert.ToInt32(LblIdIsnOrg.Text));
            GVInsOrgDocPres.DataBind();
        }
        #endregion
        #region FUNCION PARA EXTRAER LOS DATOS PARA EL REPORTE DE REGISTRO DE VERIFICACION DE DOCUMENTOS POR EL ID DE LAINSCRIPCION DE LA ORG
        private void Desplegar_DOC_VERIF_REPORTE(int id)
        {
            string[] DatsRep = new string[9];
            DB_AP_Registro_Org dp = new DB_AP_Registro_Org();
            DatsRep = dp.DB_Desplegar_DOC_VERIF_REPORTE(id);
            LblCampanhia.Text = DatsRep[0];
            LblOrganizacion.Text = DatsRep[1];
            LblRegional.Text = DatsRep[2];
            LblNumProd.Text = DatsRep[3];
            LblSuperficie.Text = DatsRep[4];
            LblPrograma.Text = DatsRep[5];
            LblResponsable.Text = DatsRep[6];
            LblFecha.Text = DatsRep[7];
            LblObservacion.Text = DatsRep[8];
            LblCi.Text = DatsRep[9];
        }
        #endregion

        protected void GVInsOrgDocPres_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Boolean valor = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Estado").ToString());
                //string valor2 = DataBinder.Eval(e.Row.DataItem, "EstCamp").ToString();
                var image = e.Row.FindControl("ImgEstado") as Image;
                if (valor == true)
                {
                    e.Row.Cells[1].Text = "PRESENTO";
                    image.ImageUrl = "~/images/img-1.png";
                }
                if (valor == false)
                {
                    e.Row.Cells[1].Text = "NO PRESENTO";
                    image.ImageUrl = "~/images/img-0.png";
                }
                //if (valor2 == "0")
                //{
                //    e.Row.Cells[8].Enabled = false;
                //    e.Row.Cells[9].Enabled = false;
                //    e.Row.Cells[10].Enabled = false;
                //}
            }
        }
    }
}