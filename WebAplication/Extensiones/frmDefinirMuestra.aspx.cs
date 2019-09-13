using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;
using DataBusiness.DB_General;
using DataEntity.DE_General;
using DataEntity.DE_Extensiones;
using DataBusiness.DB_Extensiones;

namespace WebAplication.Extensiones
{
    public partial class frmDefinirMuestra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                if (!IsPostBack)
                {
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    Llenar_DDLRegional();
                    Seleccionar_REGION();
                    Obtener_Numero_ORG_PROD();
                    Desplegar_MUESTRAS_REGISTRADAS();
                }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        #region FUNCION PARA LLENAR EL COMBO CON EL TIPO DE ORGANIZACION
        private void Llenar_DDLRegional()
        {
            DB_AdminUser User = new DB_AdminUser();
            DataTable dt = User.DB_Desplegar_USUARIO(LblIdUsuario.Text);
            //LblReg.Text = dt.Rows[0][13].ToString();
            if (Convert.ToInt32(dt.Rows[0][6].ToString()) == 15 || Convert.ToInt32(dt.Rows[0][6].ToString()) == 5)
            {
                DDLRegional.Items.Insert(0, new ListItem(dt.Rows[0][5].ToString(), dt.Rows[0][4].ToString(), true));
                DDLRegional.Enabled = false;
            }
            else
            {
                DB_Regional reg = new DB_Regional();
                List<Regional> Lista = reg.DB_Desplegar_REGIONAL();
                DDLRegional.DataSource = Lista;
                DDLRegional.DataValueField = "Id_Regional";
                DDLRegional.DataTextField = "Nombre";
                DDLRegional.DataBind();
            }
        }
        #endregion
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Seleccionar_REGION()
        {
            DB_Regional reg = new DB_Regional();
            DataTable dt = new DataTable();
            dt = reg.DB_Seleccionar_REGIONAL(Convert.ToInt32(DDLRegional.SelectedValue));
            LblReg.Text = dt.Rows[0][7].ToString();
            Llenar_DDLCAMPANHIA(dt.Rows[0][7].ToString());
        }
        #endregion
        #region FUNCION PARA DESPLEGAR EN LA GRILLA LAS MUESTRAS QUE SE REGISTRARON
        protected void Desplegar_MUESTRAS_REGISTRADAS()
        {
            DB_EXT_DesignacionProd mus = new DB_EXT_DesignacionProd();
            GVMuestras.DataSource = mus.DB_Desplegar_MUESTRA(Convert.ToInt32(DDLCamp.SelectedValue), Convert.ToInt32(DDLRegional.SelectedValue), DDLPrograma.SelectedValue, "MUESTRA");
            GVMuestras.DataBind();
            if(GVMuestras.Rows.Count > 0)
            {
                ImgFormula.Visible = false;
                BtnCalcular.Enabled = false;
                LblTexto1.Visible = false;
            }
            else
            {
                BtnCalcular.Enabled = true;
                ImgFormula.Visible = true;
                LblTexto1.Visible = true;
            }
        }
        #endregion
        #region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS POR REGION
        protected void Llenar_DDLCAMPANHIA(string region)
        {
            DB_AP_Campanhia camp = new DB_AP_Campanhia();
            DataTable Lista = new DataTable();
            Lista = camp.DB_Desplegar_CAMPANHIA_REGION(region);
            DDLCamp.DataSource = Lista;
            DDLCamp.DataValueField = "Id_Campanhia";
            DDLCamp.DataTextField = "Nombre";
            DDLCamp.DataBind();
        }
        #endregion
        #region FUNCION PARA OBTENER EL NUMERO DE ORGANIZACIONES Y NUMERO DE PRODUCTORES TOTAL
        protected void Obtener_Numero_ORG_PROD()
        {
            DB_EXT_DesignacionOrg des = new DB_EXT_DesignacionOrg();
            DataTable dt = new DataTable();
            dt = des.DB_Obtener_Numero_ORG_PROD(Convert.ToInt32(DDLCamp.SelectedValue), DDLPrograma.SelectedValue, Convert.ToInt32(DDLRegional.SelectedValue), "NUM_ORG");
            LblNumOrg.Text = dt.Rows[0][0].ToString();
            dt = des.DB_Obtener_Numero_ORG_PROD(Convert.ToInt32(DDLCamp.SelectedValue), DDLPrograma.SelectedValue, Convert.ToInt32(DDLRegional.SelectedValue), "NUM_PROD");
            LblNumProd.Text = dt.Rows[0][0].ToString();
        }
        #endregion
        #region FUNCIONES DE LOS COMBOS
        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Obtener_Numero_ORG_PROD();
            Desplegar_MUESTRAS_REGISTRADAS();
            LblMsj.Text = string.Empty;
        }

        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Obtener_Numero_ORG_PROD();
            Desplegar_MUESTRAS_REGISTRADAS();
            LblMsj.Text = string.Empty;
        }
        #endregion
        protected void BtnCalcular_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(LblNumProd.Text) != 0)
            {
                ImgFormula.Visible = false;
                LblTexto1.Visible = false;
                LblMuestra.Visible = true;
                LblMuestra.Text = ((Convert.ToDecimal(0.6724) * Convert.ToDecimal(LblNumProd.Text)) / ((((Convert.ToDecimal(LblNumProd.Text)) - Convert.ToDecimal(1)) * Convert.ToDecimal(0.01)) + Convert.ToDecimal(0.6724))).ToString();
                BtnCalcular.Enabled = false;
                BtnRegistrar.Visible = true;
                LblMsj.Text = string.Empty;
            }
            else 
            {
                LblMsj.Text = "No se puede generar una muestra valida con cero productores";
            }
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            EXT_MuestraSeguimiento mus = new EXT_MuestraSeguimiento();
            mus.Id_Campanhia = Convert.ToInt32(DDLCamp.SelectedValue);
            mus.Id_Regional = Convert.ToInt32(DDLRegional.SelectedValue);
            mus.Programa = DDLPrograma.SelectedValue;
            mus.Num_Org = Convert.ToInt32(LblNumOrg.Text);
            mus.Num_Prod = Convert.ToInt32(LblNumProd.Text);
            mus.Num_Muestra = Convert.ToInt32(Math.Round(Convert.ToDecimal(LblMuestra.Text),0));
            mus.Num_Tecnicos = 0;
            DB_EXT_DesignacionProd rm = new DB_EXT_DesignacionProd();
            rm.DB_Registrar_MUESTRA(mus);
            Desplegar_MUESTRAS_REGISTRADAS();
            LblNumOrg.Text = "0";
            LblNumProd.Text = "0";
            LblMuestra.Text = "0";
        }
        #region FUNCIONDES DE LA GRILLA
        protected void GVMuestras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            Session.Add("IdCamp", GVMuestras.Rows[rowIndex].Cells[7].Text);
            Session.Add("IdUser", LblIdUsuario.Text);
            Session.Add("Prog", GVMuestras.Rows[rowIndex].Cells[2].Text);
            Session.Add("Muestra", GVMuestras.Rows[rowIndex].Cells[5].Text);
            Session.Add("NumProd", GVMuestras.Rows[rowIndex].Cells[4].Text);
            Session.Add("IdReg",DDLRegional.SelectedValue);
            Session.Add("Reg", DDLRegional.SelectedItem.Text);
            switch (tipo)
            {
                case "Designar":
                    Response.Redirect("frmDesignarOrgTPE.aspx");
                    break;
            } 
        }
        #endregion

        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Seleccionar_REGION();
            Obtener_Numero_ORG_PROD();
            Desplegar_MUESTRAS_REGISTRADAS();
        }
    }
}