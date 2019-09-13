using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;
using DataEntity.DE_General;
using System.Threading;
using DataBusiness.DB_General;

namespace WebAplication.Registro
{
    public partial class frmRegistroProductorNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string urrl = Request.QueryString["data"];
                TSHAK.Components.SecureQueryString querystringSeguro;
                querystringSeguro = new TSHAK.Components.SecureQueryString(new Byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 8 }, urrl);
                Int32 id_Org = Convert.ToInt32(querystringSeguro["id_Org"]);
                contEncabezado21.LabelIdInsOrg = (id_Org).ToString();
                this.HiddenFieldInsOrg.Value = Convert.ToString(id_Org); //
                Int32 id_Campanhia = Convert.ToInt32(querystringSeguro["id_Campanhia"]);
                this.HiddenFieldCampanhia.Value = Convert.ToString(id_Campanhia);
                ///////////////////
                String SIGLA = "";
                String PROGRAMA = "";
                String CAMPANHIA = "";
                DB_AP_Campanhia cam = new DB_AP_Campanhia();
                cam.ExtraerCapanhiaID_INORG(id_Campanhia, id_Org, ref SIGLA, ref PROGRAMA, ref CAMPANHIA);
                contEncabezado21.LabelCamp = CAMPANHIA;
                contEncabezado21.LabelOrg = SIGLA;
                contEncabezado21.LabelProg = PROGRAMA;
                ///
                DB_AP_Departamento dep = new DB_AP_Departamento();
                dep.DB_Desplegar_DEPARTAMENTOS(DDLDepartamento);
                
                //DB_AP_Inscripcion_Prod_Update dataup = new DB_AP_Inscripcion_Prod_Update();
                //String DEP = dataup.DB_Desplegar_REGIONAL_AP_INSCRIPCION_ORG(id_Org);
                
                
                //DropDownListMUN.Enabled = false;

                DB_AP_Provincia data = new DB_AP_Provincia();
                data.DB_Desplegar_PROVINCIAS_DROPDOWNLIST(DDLDepartamento.SelectedItem.Text, DropDownListPROV);
                DB_AP_Municipio data1 = new DB_AP_Municipio();
                data1.DB_Desplegar_MUNICIPIOS_DROPDOWNLIST(Convert.ToInt32(this.DropDownListPROV.SelectedValue), DropDownListMUN);
                DropDownListPROV.Enabled = false;
                DropDownListMUN.Enabled = false;
                DropDownListCOM.Enabled = false;
                DropDownListTipo.Enabled = false;
            }
        }
        protected void Baciar_CAMPOS() 
        {
            //StringBuilder sbMensaje = new StringBuilder();
            //TSHAK.Components.SecureQueryString querystringSeguro;
            //querystringSeguro = new TSHAK.Components.SecureQueryString(new Byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 8 });
            //querystringSeguro["IdInsOrg"] = Convert.ToString(contEncabezado21.LabelIdInsOrg);
            //Session.Add("Estado", "modificar");
            TextBoxCI.Text = string.Empty;
            TextBoxNOM.Text = string.Empty;
            TextBoxPAT.Text = string.Empty;
            TextBoxMAT.Text = string.Empty;
            TextF1TextBoxFE_NAC.Text = string.Empty;
            TextBoxTEL_FIJO.Text = string.Empty;
            TextBoxTEL_MOVIL.Text = string.Empty;
            TxtObser.Text = string.Empty;
            TextBoxSUP.Text = string.Empty;
            TextBoxRAU.Text = string.Empty;
            //Response.Redirect("frmRegistroProductorOrg.aspx" + HttpUtility.UrlEncode(Convert.ToString(querystringSeguro)) + "");
        }
        protected void Registrar_Click(object sender, EventArgs e)
        {
            this.LabelMen.Text = "";
            DB_AP_Inscripcion_Prod_Update data = new DB_AP_Inscripcion_Prod_Update();
            Persona per = new Persona();
            String men = "";
            data.DB_Verificar_FORMULARIO_NEW_BENEFICIARIO(this.TextBoxCI, this.DropDownListEXT, this.TextBoxNOM, this.TextBoxPAT, this.TextBoxMAT, this.TextF1TextBoxFE_NAC, this.TextBoxTEL_FIJO, this.TextBoxTEL_MOVIL, this.RadioButtonVaron, this.RadioButtonMujer, ref per, ref men);
            if (men == "")
            {
                AP_Productor pro = new AP_Productor();
                data.DB_Verificar_FORMULARIO_NEW_UBICACION(this.DropDownListMUN, this.DropDownListCOM, this.DropDownListTipo, this.TextBoxSUP, this.TextBoxRAU, this.TextBoxCI, this.TxtObser, ref pro, ref men);
                if (men == "")
                {
                    men = data.VERIFICAR_AGREGAR_DATOS_PERSONA_AP_INS_PRO(per, pro, Convert.ToInt32(this.HiddenFieldCampanhia.Value), Convert.ToInt32(this.HiddenFieldInsOrg.Value));
                    Baciar_CAMPOS(); 
                }
                else
                {
                    this.LabelMen.Text = men;
                }
            }
            else
            {
                this.LabelMen.Text = men;
            }
        }
        protected void DropDownListPROV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DropDownListPROV.SelectedIndex > 0)
            {
                DB_AP_Municipio mun = new DB_AP_Municipio();
                this.DropDownListMUN.Enabled = true;
                this.DropDownListMUN.Items.Clear();
                mun.DB_Desplegar_MUNICIPIOS_DROPDOWNLIST(Convert.ToInt32(this.DropDownListPROV.SelectedValue), DropDownListMUN);
            }
            else
            {
                this.DropDownListMUN.Enabled = false;
                this.DropDownListCOM.Enabled = false;
                this.DropDownListTipo.Enabled = false;
            }
        }

        protected void DropDownListMUN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DropDownListMUN.SelectedIndex > 0)
            {
                DB_AP_Comunidad mun = new DB_AP_Comunidad();
                this.DropDownListCOM.Enabled = true;
                this.DropDownListCOM.Items.Clear();
                mun.DB_Desplegar_COMUNIDAD_DROPDOWNLIST(Convert.ToInt32(this.DropDownListMUN.SelectedValue), DropDownListCOM);
            }
            else
            {
                this.DropDownListCOM.Enabled = false;
                this.DropDownListTipo.Enabled = false;
            }
        }

        protected void DropDownListCOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DropDownListCOM.SelectedIndex > 0)
            {
                this.DropDownListTipo.Enabled = true;
                this.DropDownListTipo.SelectedIndex = 0;
            }
            else
            {
                this.DropDownListTipo.Enabled = false;
            }
        }

        protected void DropDownListTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #region FUNCIONES INDEPENDIENTES BUSCAR PERSONA POR CEDULA DE IDENTIDAD
        private void Buscar_PERSONA(string ci)
        {
            Persona p = new Persona();
            DB_Persona np = new DB_Persona();
            p = np.DB_Buscar_PERSONA(ci);
            if (p.ci == ci)
            {
                TextBoxCI.Text = p.ci;
                TextBoxNOM.Text = p.Nombres;
                TextBoxPAT.Text = p.Primer_ap;
                TextBoxMAT.Text = p.Segundo_ap;
                TextF1TextBoxFE_NAC.Text = (p.Fecha_nacimiento).ToString();
                TextBoxTEL_FIJO.Text = p.Telef_fijo;
                TextBoxTEL_MOVIL.Text = p.Telef_cel;
            }
            else
            {
                limparCampos_PERSONA();
            }
        }
        private void limparCampos_PERSONA()
        {
            TextBoxNOM.Text = string.Empty;
            TextBoxPAT.Text = string.Empty;
            TextBoxMAT.Text = string.Empty;
            TextF1TextBoxFE_NAC.Text = string.Empty;
            TextBoxTEL_FIJO.Text = string.Empty;
            TextBoxTEL_MOVIL.Text = string.Empty;
        }
        #endregion    
        protected void TextBoxCI_TextChanged(object sender, EventArgs e)
        {
            Buscar_PERSONA(TextBoxCI.Text);
        }

        protected void LnkVer_Click(object sender, EventArgs e)
        {
                StringBuilder sbMensaje = new StringBuilder();
                sbMensaje.Append("<script type='text/javascript'>");
                sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=800,height=400,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Responsable/frmHistorial.aspx?ci=" + TextBoxCI.Text);
                sbMensaje.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
        }
        protected void LnkBtnNuevo_Click(object sender, EventArgs e)
        {
            if (LnkBtnNuevo.Text=="Nuevo")
            {
             TxtComunidad.Text = "";
             DropDownListCOM.Visible = false;
             DropDownListPROV.Enabled = true;
             DropDownListMUN.Enabled = true;
             TxtComunidad.Visible = true;
             LnkBtnNuevo.Text = "Registrar";
            }
            else
            {
                DB_AP_Comunidad ic = new DB_AP_Comunidad();
                AP_Comunidad c = new AP_Comunidad();
                c.Id_Municipio = Convert.ToInt32(DropDownListMUN.SelectedValue);
                c.Nombre = TxtComunidad.Text;
                ic.DB_Registrar_COMUNIDAD(c);
                LnkBtnNuevo.Text = "Nuevo";
                TxtComunidad.Visible = false;
                DB_AP_Comunidad mun = new DB_AP_Comunidad();
                this.DropDownListCOM.Enabled = true;
                this.DropDownListCOM.Items.Clear();
                mun.DB_Desplegar_COMUNIDAD_DROPDOWNLIST(Convert.ToInt32(this.DropDownListMUN.SelectedValue), DropDownListCOM);
                DropDownListCOM.Visible = true;
            }
        }

        protected void DDLDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DDLDepartamento.SelectedIndex > 0)
            {
                DB_AP_Provincia prov = new DB_AP_Provincia();
                this.DropDownListPROV.Enabled = true;
                this.DropDownListPROV.Items.Clear();
                prov.DB_Desplegar_PROVINCIAS_DROPDOWNLIST(DDLDepartamento.SelectedItem.Text,DropDownListPROV);
            }
            else
            {
                this.DropDownListPROV.Enabled = false;
                this.DropDownListMUN.Enabled = false;
                this.DropDownListCOM.Enabled = false;
                this.DropDownListTipo.Enabled = false;
            }
        }
    }
}