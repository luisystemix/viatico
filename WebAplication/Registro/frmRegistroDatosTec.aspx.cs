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
using DataBusiness.DB_General;
using DataEntity.DE_General;
//using DataEntity.DE_Registro;

namespace WebAplication.Registro
{
    public partial class frmRegistroDatosTec : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    string urrl = Request.QueryString["data"];
                    TSHAK.Components.SecureQueryString querystringSeguro;
                    querystringSeguro = new TSHAK.Components.SecureQueryString(new Byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 8 }, urrl);
                    Int32 id_Org = Convert.ToInt32(querystringSeguro["id_Org"]);
                    this.HiddenFieldInsOrg.Value = Convert.ToString(id_Org); //
                    Int32 id_Campanhia = Convert.ToInt32(querystringSeguro["id_Campanhia"]);
                    this.HiddenFieldCampanhia.Value = Convert.ToString(id_Campanhia);
                    Int32 id_Comu = Convert.ToInt32(querystringSeguro["id_Com"]);
                    this.HiddenFieldComu.Value = Convert.ToString(id_Comu);
                    this.HiddenFieldCampanhia.Value = Convert.ToString(id_Campanhia);
                    this.HiddenField_ID_PRO.Value = Convert.ToString(querystringSeguro["id_Prod"]);
                    ///////////////////
                    String SIGLA = "";
                    String PROGRAMA = "";
                    String CAMPANHIA = "";
                    DB_AP_Campanhia cam = new DB_AP_Campanhia();
                    cam.ExtraerCapanhiaID_INORG(Convert.ToInt32(this.HiddenFieldCampanhia.Value), Convert.ToInt32(this.HiddenFieldInsOrg.Value), ref SIGLA, ref PROGRAMA, ref CAMPANHIA);
                    contEncabezado21.LabelCamp = CAMPANHIA;
                    contEncabezado21.LabelOrg = SIGLA;
                    contEncabezado21.LabelProg = PROGRAMA;
                    //////////////////
                    DB_AP_Inscripcion_Prod_Update dat = new DB_AP_Inscripcion_Prod_Update();                    
                    System.Data.DataTable tabledataREG = new System.Data.DataTable();
                    tabledataREG = dat.DB_BUSCAR_COMUNIDAD_MUNICIPIO_PROVINCIA(id_Comu);
                    this.LabelProv.Text = Convert.ToString(tabledataREG.Rows[0][5]);
                    this.LabelDep.Text = Convert.ToString(tabledataREG.Rows[0][6]);
                }
                ///               
            }           
        }

         protected void ButtonAgregar_Click(object sender, EventArgs e)
         {
             LabelMen.Text = "";
             DB_AP_Inscripcion_Prod_Update dat = new DB_AP_Inscripcion_Prod_Update();
             this.LabelMen.Text = dat.DB_validar_ASIGNAR_COORDENADAS(this.TextBoxX, this.TextBoxY, this.ListBoxNRO, this.ListBoxX, this.ListBoxY);
             if (this.LabelMen.Text == "") { this.TextBoxX.Text = ""; this.TextBoxY.Text = ""; }   
         }

         protected void ButtonQuitar_Click(object sender, EventArgs e)
         {
             this.LabelMen.Text = "";
             try
             {
                 if (this.ListBoxNRO.SelectedIndex >= 0)
                 {

                     this.ListBoxX.Items.RemoveAt(this.ListBoxNRO.SelectedIndex);
                     this.ListBoxY.Items.RemoveAt(this.ListBoxNRO.SelectedIndex);
                     this.ListBoxNRO.Items.RemoveAt(this.ListBoxNRO.SelectedIndex);
                     Int32 i=1;
                     this.ListBoxNRO.Items.Clear();
                     for (i = 1; i <= this.ListBoxY.Items.Count; i++)
                     {
                         this.ListBoxNRO.Items.Add(Convert.ToString(i));
                     }
                 }
                 else
                 {
                     this.LabelMen.Text = "Debe seleccionar un detalle en la lista de depositos";
                 }
             }
             catch
             {
                 this.LabelMen.Text = "Debe seleccionar un detalle en la lista de depositos...";
             }
         }

         protected void ButtonReg_Click(object sender, EventArgs e)
         {
             DB_AP_Inscripcion_Prod_Update dat = new DB_AP_Inscripcion_Prod_Update();
             String men = dat.DB_validar_REGISTRAR_AP_PLANO_UBICACION_COORDENADAS(this.TextBoxParcela, this.TextBoxDoc, this.ListBoxNRO, this.ListBoxX, this.ListBoxY, this.HiddenField_ID_PRO.Value, Convert.ToInt32(this.HiddenFieldComu.Value));
             if (men == "")
             { 
                 LabelMen.Text = "Datos registrados"; 
             } 
             else
             { 
                 LabelMen.Text = men; 
             }
         }
    }
}