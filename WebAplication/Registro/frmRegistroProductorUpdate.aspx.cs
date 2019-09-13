using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;
using DataEntity.DE_General;
using System.Threading;

namespace WebAplication.Registro
{
    public partial class frmRegistroProductorUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string urrl = Request.QueryString["data"];
                TSHAK.Components.SecureQueryString querystringSeguro;
                querystringSeguro = new TSHAK.Components.SecureQueryString(new Byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 8 }, urrl);
                Int32 id_Org = Convert.ToInt32(querystringSeguro["id_Org"]);
                this.HiddenFieldInsOrg.Value = Convert.ToString(id_Org); //
                Int32 id_Campanhia = Convert.ToInt32(querystringSeguro["id_Campanhia"]);
                this.HiddenFieldIDPRO.Value = Convert.ToString(querystringSeguro["id_Prod"]);
                String ci = Convert.ToString(querystringSeguro["ci"]);
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
                DB_AP_Inscripcion_Prod_Update dataup = new DB_AP_Inscripcion_Prod_Update();
                ////
                System.Data.DataTable tabledata = new System.Data.DataTable();
                System.Data.DataTable tabledatacom_mun_prov = new System.Data.DataTable();
                tabledata = dataup.DB_BUSCAR_AP_INCRIPCION_PROD_PERSONA(this.HiddenFieldIDPRO.Value, ci);
                tabledatacom_mun_prov = dataup.DB_BUSCAR_COMUNIDAD_MUNICIPIO_PROVINCIA(Convert.ToInt32(tabledata.Rows[0][13]));
                ///
                String DEP = dataup.DB_Desplegar_REGIONAL_AP_INSCRIPCION_ORG(id_Org);
                DB_AP_Provincia data = new DB_AP_Provincia();
                data.DB_Desplegar_PROVINCIAS_DROPDOWNLIST(DEP, DropDownListPROV);
                asignaDatos(tabledata, tabledatacom_mun_prov);
                // DropDownListMUN.Enabled = false;
                //  DropDownListCOM.Enabled = false;
                //DropDownListTipo.Enabled = false;
            }
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
                    per.Id_Persona = this.TextBoxCI.Text;
                    pro.Id_Productor = this.HiddenFieldIDPRO.Value;
                    men = data.ACTUALIZAR_DATOS_PERSONA_AP_INS_PRO(per, pro, Convert.ToInt32(this.HiddenFieldCampanhia.Value), Convert.ToInt32(this.HiddenFieldInsOrg.Value));
                    if (men == "") { this.LabelMen.Text = "datos actualizados"; }
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

        #region FUNCIONES DEL FORMULARIO
        protected void asignaDatos(System.Data.DataTable tabledata, System.Data.DataTable mun_pro_com)
        {
            this.TextBoxCI.Text = Convert.ToString(tabledata.Rows[0][1]);
            this.TextBoxNOM.Text = Convert.ToString(tabledata.Rows[0][3]);
            this.TextBoxPAT.Text = Convert.ToString(tabledata.Rows[0][4]);
            this.TextBoxMAT.Text = Convert.ToString(tabledata.Rows[0][5]);
            this.TextF1TextBoxFE_NAC.Text = Convert.ToString(tabledata.Rows[0][6]);
            this.TextBoxTEL_FIJO.Text = Convert.ToString(tabledata.Rows[0][8]);
            this.TextBoxTEL_MOVIL.Text = Convert.ToString(tabledata.Rows[0][9]);
            this.TextBoxSUP.Text = Convert.ToString(tabledata.Rows[0][19]);
            this.TextBoxRAU.Text = Convert.ToString(tabledata.Rows[0][22]);
            if (Convert.ToBoolean(tabledata.Rows[0][7]) == true) { this.RadioButtonVaron.Checked = true; } else { this.RadioButtonMujer.Checked = true; }
            foreach (ListItem item in DropDownListEXT.Items)
            {
                if (item.Value == Convert.ToString(tabledata.Rows[0][2]))
                {
                    item.Selected = true;
                    break;
                }
            }
            //////
            DB_AP_Municipio mun = new DB_AP_Municipio();
            this.DropDownListMUN.Enabled = true;
            this.DropDownListMUN.Items.Clear();
            mun.DB_Desplegar_MUNICIPIOS_DROPDOWNLIST(Convert.ToInt32(mun_pro_com.Rows[0][4]), DropDownListMUN);
            //////////
            DB_AP_Comunidad com = new DB_AP_Comunidad();
            this.DropDownListCOM.Enabled = true;
            this.DropDownListCOM.Items.Clear();
            com.DB_Desplegar_COMUNIDAD_DROPDOWNLIST(Convert.ToInt32(mun_pro_com.Rows[0][2]), DropDownListCOM);
            //////asigna el valor provincia selecionada
            string dd = Convert.ToString(mun_pro_com.Rows[0][4]);
            foreach (ListItem itemP in DropDownListPROV.Items)
            {
                if (itemP.Value == Convert.ToString(mun_pro_com.Rows[0][4]))
                {
                    itemP.Selected = true;
                    break;
                }
            }
            //////asigna el valor municipio seleccionado
            foreach (ListItem item in DropDownListMUN.Items)
            {
                if (item.Value == Convert.ToString(mun_pro_com.Rows[0][2]))
                {
                    item.Selected = true;
                    break;
                }
            }
            //////asigna el valor municipio comunidad
            foreach (ListItem item in DropDownListCOM.Items)
            {
                if (item.Value == Convert.ToString(mun_pro_com.Rows[0][0]))
                {
                    item.Selected = true;
                    break;
                }
            }
            //////asigna el valor a tipo de beneficiario
            foreach (ListItem item in DropDownListTipo.Items)
            {
                if (item.Value == Convert.ToString(tabledata.Rows[0][17]))
                {
                    item.Selected = true;
                    break;
                }
            }
        }
        #endregion
    }
}