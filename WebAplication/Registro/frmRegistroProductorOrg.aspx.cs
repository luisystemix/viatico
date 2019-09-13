using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DataEntity.DE_Registro;
using DataBusiness.DB_Registro;
using TSHAK.Components;

namespace WebAplication.Registro
{
    public partial class frmRegistroProductorOrg : System.Web.UI.Page
    {
       // Int32 id_Campanhia, id_Org;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string urrl = Request.QueryString["data"];
                TSHAK.Components.SecureQueryString querystringSeguro;
                querystringSeguro = new TSHAK.Components.SecureQueryString(new Byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 8 }, urrl);
                ////parametros de otra formulario
                this.HiddenFieldInsOrg.Value = Convert.ToString(querystringSeguro["IdInsOrg"]);
                DB_AP_Registro_Org idCamp = new DB_AP_Registro_Org();
                this.HiddenFieldCampanhia.Value = Convert.ToString(idCamp.DB_EXTRAE_COMPANHIA_DE_AP_INCRIPCION_ORG(Convert.ToInt32(this.HiddenFieldInsOrg.Value)));
                ///////////////////
                String SIGLA = "";
                String PROGRAMA = "";
                String CAMPANHIA = "";
                DB_AP_Campanhia cam = new DB_AP_Campanhia();
                cam.ExtraerCapanhiaID_INORG(Convert.ToInt32(this.HiddenFieldCampanhia.Value), Convert.ToInt32(this.HiddenFieldInsOrg.Value), ref SIGLA, ref PROGRAMA, ref CAMPANHIA);
                contEncabezado21.LabelCamp = CAMPANHIA;
                contEncabezado21.LabelOrg = SIGLA;
                contEncabezado21.LabelProg = PROGRAMA;
                ///
                INCRIPCION_PROD_PERSONA_INS_ORG(Convert.ToInt32(this.HiddenFieldCampanhia.Value), Convert.ToInt32(this.HiddenFieldInsOrg.Value), "", "", "", "");
            }
        }
        #region FUNCIONES DEL FORMULARIO  ----------/OBTENER LA LISTA DE LAS TABLAS INCRIPCION_PROD => PERSONA => INSCRIPCION_ORG
        protected void INCRIPCION_PROD_PERSONA_INS_ORG(Int32 id_Campanhia, Int32 id_Org, String ci, String nom, String ApP, String ApM)
        {
            DB_AP_Inscripcion_Prod_Update List_INS_PER_ORG = new DB_AP_Inscripcion_Prod_Update();
            GVINSPROPERINSORG.DataSource = List_INS_PER_ORG.DB_Desplegar_INCRIPCIONPROD_PER_INSORG(id_Campanhia, id_Org, ci, nom, ApP, ApM);
            GVINSPROPERINSORG.DataBind();
        }
        #endregion
        #region

        #endregion
        protected void GVINSPROPERINSORG_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                TSHAK.Components.SecureQueryString querystringSeguro;
                querystringSeguro = new TSHAK.Components.SecureQueryString(new Byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 8 });
                querystringSeguro["id_campanhia"] = this.HiddenFieldCampanhia.Value;
                querystringSeguro["id_Org"] = this.HiddenFieldInsOrg.Value;
                int index = Convert.ToInt32(e.CommandArgument);
                //// Retrieve the row that contains the button clicked 
                //// by the user from the Rows collection.
                GridViewRow row = GVINSPROPERINSORG.Rows[index];
                querystringSeguro["id_Prod"] = Convert.ToString(GVINSPROPERINSORG.DataKeys[index].Values[0]);//extre el ID incripcion_PROD
                try
                {
                    if (e.CommandName == "Ir")
                    {
                        querystringSeguro["id_Com"] = Convert.ToString(GVINSPROPERINSORG.DataKeys[index].Values[2]);
                        Response.Redirect("frmRegistroDatosTec.aspx?data=" + HttpUtility.UrlEncode(Convert.ToString(querystringSeguro)) + "");
                    }
                    if (e.CommandName == "Editar")
                    {
                        querystringSeguro["ci"] = Convert.ToString(GVINSPROPERINSORG.DataKeys[index].Values[1]);//extre el CI
                        Response.Redirect("frmRegistroProductorUpdate.aspx?data=" + HttpUtility.UrlEncode(Convert.ToString(querystringSeguro)) + "");
                    }
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        #region EVENTO NUEVO PRODUCTOR
        protected void LnkNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                TSHAK.Components.SecureQueryString querystringSeguro;
                querystringSeguro = new TSHAK.Components.SecureQueryString(new Byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 8 });
                querystringSeguro["id_campanhia"] = this.HiddenFieldCampanhia.Value;
                querystringSeguro["id_Org"] = this.HiddenFieldInsOrg.Value;
                Response.Redirect("frmRegistroProductorNew.aspx?data=" + HttpUtility.UrlEncode(Convert.ToString(querystringSeguro)) + "");
            }
            catch
            {
            }
        }
        #endregion
        #region EVENTO BUSCAR PRODUCTOR
        protected void ImgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            INCRIPCION_PROD_PERSONA_INS_ORG(Convert.ToInt32(this.HiddenFieldCampanhia.Value), Convert.ToInt32(this.HiddenFieldInsOrg.Value), this.TextBoxBuscarOrg.Text, this.TextBoxBuscarOrg.Text, this.TextBoxBuscarOrg.Text, this.TextBoxBuscarOrg.Text);

        }
        #endregion
    }
}