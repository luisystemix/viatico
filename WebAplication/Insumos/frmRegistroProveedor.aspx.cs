using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;

namespace WebAplication.Insumos
{
    public partial class frmRegistroProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LblIdUser.Text = Session["IdUser"].ToString();
                LblIdCamp.Text = Session["IdCamp"].ToString();
                LblIdReg.Text = Session["Idreg"].ToString();
                LblPrograma.Text = Session["Prog"].ToString();
                Desplegar_PROVEEDOR();
                //Session.Abandon();
                //Llenar_DDLRegional();
                //Llenar_DDLCAMPANHIA();
                //Desplegar_ORG_LIST_OFI();
            }
        }
        #region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS
        private void Desplegar_PROVEEDOR()
        {
            DB_AP_Proveedor pro = new DB_AP_Proveedor();
            DataTable dt = new DataTable();
            dt = pro.DB_Desplegar_PROVEEDOR();
            DDLProveedor.DataSource = dt;
            DDLProveedor.DataValueField = "Id_Proveedor";
            DDLProveedor.DataTextField = "Razon_Social";
            DDLProveedor.DataBind();
            Seleccionar_PROVEEDOR();
        }
        #endregion
        #region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS
        private void Seleccionar_PROVEEDOR()
        {
            DB_AP_Proveedor p = new DB_AP_Proveedor();
            AP_Proveedor Prov = new AP_Proveedor();
            Prov = p.DB_Buscar_PROVEEDOR(DDLProveedor.SelectedValue);
            TxtProveedor.Text = Prov.Razon_Social;
            TxtNIT.Text = Prov.NIT;
            TxtNumTesTim.Text = Prov.Num_Testimonio;
            TxtFechaTestim.Text = Prov.Fecha_Creacion.ToString();
            TxtDomicilio.Text = Prov.Domicilio;
            TxtFono.Text = Prov.Telefono_Ref;
            TxtCorreo.Text = Prov.Correo;
        }
        #endregion
        #region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS
        private void Registrar_PROVEEDOR()
        {
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            DB_AP_Proveedor pro = new DB_AP_Proveedor();
            DB_AP_InscripcionProv insprov = new DB_AP_InscripcionProv();
            AP_Proveedor p = new AP_Proveedor();
            AP_InscripcionProv ip = new AP_InscripcionProv();
            int idprov = 0;
            if (DDLProveedor.Visible == false && TxtProveedor.Visible == true)
            {
                p.Razon_Social = TxtProveedor.Text;
                p.NIT = TxtNIT.Text;
                p.Num_Testimonio = TxtNumTesTim.Text;
                p.Fecha_Creacion = Convert.ToDateTime(TxtFechaTestim.Text);
                p.Departamento = DDLDepartamento.SelectedValue;
                p.Domicilio = TxtDomicilio.Text;
                p.Telefono_Ref = TxtFono.Text;
                p.Correo = TxtCorreo.Text;
                pro.DB_Registrar_PROVEEDOR(p);
                idprov = Convert.ToInt32(aux.DB_MaxId("INS_PROVEEDOR", "Id_Proveedor"));
            }
            else 
            {
                idprov = Convert.ToInt32(DDLProveedor.SelectedValue);
            }
            ip.Id_Campanhia = Convert.ToInt32(LblIdCamp.Text);
            ip.Id_Proveedor = idprov;
            ip.Id_Regional = Convert.ToInt32(LblIdReg.Text);
            ip.Insumo = DDLInsumo.SelectedValue;
            ip.Programa = LblPrograma.Text;
            ip.Matricula_Comercio = "0";
            ip.Domicilio = TxtDomicilio.Text;
            ip.Estado = "APROBADO";
            insprov.DB_Registrar_INSCRIP_PROVEEDOR(ip);
        }
        #endregion
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Registrar_PROVEEDOR();
        }
        protected void LnkNuevo_Click(object sender, EventArgs e)
        {
            DDLProveedor.Visible = false;
            TxtProveedor.Visible = true;
            TxtProveedor.Text = string.Empty;
            TxtNIT.Text = string.Empty;
            TxtNumTesTim.Text = string.Empty;
            TxtFechaTestim.Text = string.Empty;
            TxtDomicilio.Text = string.Empty;
            TxtFono.Text = string.Empty;
            TxtCorreo.Text = string.Empty;
            LnkNuevo.Visible = false;
        }

        protected void DDLProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Seleccionar_PROVEEDOR();
        }
    }
}