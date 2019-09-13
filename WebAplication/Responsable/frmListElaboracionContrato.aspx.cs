using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DataBusiness.DB_Registro;
using DataBusiness.DB_General;
using DataEntity.DE_General;
using DataEntity.DE_Registro;

namespace WebAplication.Responsable
{
    public partial class frmListElaboracionContrato : System.Web.UI.Page
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
                Desplegar_REGISTRO_CONTRATOS_ORG();
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
            string aux =dt.Rows[0][7].ToString();
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
        #region OBTENER LA LISTA DE LAS LAS ORGANIZACIONES LISTAS PARA SU GENERACION DE CONTRATOS EN LA GRILLA
        protected void Desplegar_REGISTRO_CONTRATOS_ORG()
        {
            if(DDLCamp.SelectedValue!="")
            {
                DB_AP_Responsable ListOrg = new DB_AP_Responsable();
                GVResitroContrat.DataSource = ListOrg.DB_Desplegar_REGISTRO_CONTRATOS_ORG(Convert.ToInt32(DDLCamp.SelectedValue), Convert.ToInt32(DDLRegional.SelectedValue), DDLPrograma.SelectedValue);
                GVResitroContrat.DataBind();
                LblMsj.Text = string.Empty;
            }
            else
            {
                LblMsj.Text = "No se definieron   campañas";
            }
        }
        #endregion
        #region CONTROLES DE COMBO PARA ACTUALIZAR LA GRILLA
        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_REGISTRO_CONTRATOS_ORG();
        }
        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DDLCAMPANHIA();
            Desplegar_REGISTRO_CONTRATOS_ORG();
        }
        #endregion
        #region GENERAR CODIGO DE CONTRATO
        protected void Generar_CODIGO_CONTRATO()
        {
            LblNumero.Text = DDLCamp.SelectedItem.Text[0].ToString();
            for (int i = 1; i < DDLCamp.SelectedItem.Text.Count(); i++)
            {
                if (DDLCamp.SelectedItem.Text[i].ToString() == " ")
                {
                    LblNumero.Text = LblNumero.Text + DDLCamp.SelectedItem.Text[i + 3].ToString() + DDLCamp.SelectedItem.Text[i + 4].ToString();
                }
                if (DDLCamp.SelectedItem.Text[i].ToString() == "-")
                {
                    LblNumero.Text = LblNumero.Text + "/" + DDLCamp.SelectedItem.Text[i + 3].ToString() + DDLCamp.SelectedItem.Text[i + 4].ToString();
                }
            }
            /************* CONTRUCCION DE CODIFICACION **************/
            DB_Codificacion cont = new DB_Codificacion();
            int num = cont.DB_Codigo_INFORME();
            string dep = "";
            switch (DDLRegional.SelectedItem.Text)
            {
                case "SANTA CRUZ":
                    dep = "SC";
                    break;
                case "BENI":
                    dep = "BN";
                    break;
                case "COCHABAMBA":
                    dep = "CB";
                    break;
                case "TARIJA":
                    dep = "TJ";
                    break;
                case "POTOSI":
                    dep = "PT";
                    break;
                case "CHUQUISACA":
                    dep = "CH";
                    break;
                case "ORURO":
                    dep = "OR";
                    break;
                case "LA PAZ":
                    dep = "LP";
                    break;
            }
            LblNumero.Text = LblNumero.Text + DDLPrograma.SelectedItem.Text[0].ToString() + "-" + num.ToString() + " " + dep;
        }
        #endregion
        #region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS
        public void Registrar_CONTRATO(int IdInsOrg)
        {
            Generar_CODIGO_CONTRATO();
            AP_ContratoOrg c = new AP_ContratoOrg();
            c.Id_InscripcionOrg = IdInsOrg;
            c.Num_Contrato = LblNumero.Text;
            c.Ci_RepLegalEmapa = "3459923";
            c.ResolucionAdmin = "01-016/2010";
            c.FechaResAdmin = DateTime.Now;
            c.Domicilio = "CALACOTO CALLE 9";
            c.Estado = "ACEPTADO";
            DB_AP_ContratoOrg Ins = new DB_AP_ContratoOrg();
            Ins.DB_Registrar_CONTRATO_ORG(c);
        }
        #endregion
        #region FUNCIONES DE LA GRILLA
        protected void GVResitroContrat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            StringBuilder sbMensaje = new StringBuilder();
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVResitroContrat.Columns[15].Visible = true;
            Desplegar_REGISTRO_CONTRATOS_ORG();
            Session.Add("IdRegional", DDLRegional.SelectedValue);
            Session.Add("IdCamp", DDLCamp.SelectedValue);
            Session.Add("Programa", DDLPrograma.SelectedValue);
            Session.Add("IdInsOrg", GVResitroContrat.Rows[rowIndex].Cells[15].Text);
            switch (tipo)
            {
                case "RevisarDatos":

                    Response.Redirect("frmRevisarDatos.aspx");
                    break;
                case "Contrato":
                    if (GVResitroContrat.Rows[rowIndex].Cells[14].Text == "REGISTRADO")
                    {
                        Modificar_INSCRIP_ORG(Convert.ToInt32(GVResitroContrat.Rows[rowIndex].Cells[15].Text));
                        Registrar_CONTRATO(Convert.ToInt32(GVResitroContrat.Rows[rowIndex].Cells[15].Text));
                    }
                    else 
                    {
                        LblMsj.Text = "LA ORGANIZACIÓN YA FUE APROBADA PARA CONTRATO";
                    }
                    break;
                case "Planilla":
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Registro/repPlanillaProductores.aspx?ci=" + GVResitroContrat.Rows[rowIndex].Cells[15].Text);
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                        //Response.Redirect("../Registro/repPlanillaProductores.aspx");
                    break;
                case "Habilitar":
                    break;
                case "VerDoc":
                    Response.Redirect("../Registro/repVerificacionDocOrg.aspx");
                    break;
            }
            GVResitroContrat.Columns[15].Visible = false;
            Desplegar_REGISTRO_CONTRATOS_ORG();
        }
        #endregion
        #region FUNCION PARA REGISTRAR LA INSCRIPCION DE UNA ORGANIZACION
        protected void Modificar_INSCRIP_ORG(int IdInsOrg)
        {
            DB_AP_Organizacion RegInsOrg = new DB_AP_Organizacion();
            AP_InscripcionOrg io = new AP_InscripcionOrg();
            io.Id_InscripcionOrg = IdInsOrg;
            io.Estado = "APROBADO-PROD";
            RegInsOrg.DB_Modificar_INSCRIP_ORG(io);
        }
        #endregion  
        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_REGISTRO_CONTRATOS_ORG();
        }

        protected void ImgBtnContratos_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("IdRegional", DDLRegional.SelectedValue);
            Session.Add("IdCamp", DDLCamp.SelectedValue);
            Session.Add("Programa", DDLPrograma.SelectedValue);
            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Juridica/repElaboracionContratosMP.aspx?ci=" + DDLRegional.SelectedValue, DDLCamp.SelectedItem.Text, DDLPrograma.SelectedValue);
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
        }
    }
}