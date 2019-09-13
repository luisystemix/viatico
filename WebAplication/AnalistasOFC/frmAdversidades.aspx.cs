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
using DataBusiness.DB_Extensiones;
using DataBusiness.DB_Control;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

namespace WebAplication.AnalistasOFC
{
    public partial class frmAdversidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                if (!IsPostBack)
                {
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    Llenar_DDLRegional();
                    Llenar_DDLCAMPANHIA();
                    Llenar_DDYEAR();
                    Llenar_GRILLA();
                    //Graficar();
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
        #region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS
        private void Llenar_DDLCAMPANHIA()
        {
            DB_AP_Campanhia cam = new DB_AP_Campanhia();
            DB_Regional reg = new DB_Regional();
            DataTable dt = new DataTable();
            dt = reg.DB_Seleccionar_REGIONAL(Convert.ToInt32(DDLRegional.SelectedValue));
            string aux = dt.Rows[0][7].ToString();
            dt = cam.DB_Seleccionar_CAMPANHIA_REG_NOFIN(aux);
            DDLCamp.DataSource = dt;
            DDLCamp.DataValueField = "Id_Campanhia";
            DDLCamp.DataTextField = "Nombre";
            DDLCamp.DataBind();
        }
        #endregion
        private void Llenar_DDYEAR()
        {
            DB_EXT_SegSemanalTotales seg = new DB_EXT_SegSemanalTotales();
            DataTable dt = new DataTable();
            dt = seg.DB_Desplegar_SEG_ADVERSIDAD(Convert.ToInt32(DDLRegional.SelectedValue), Convert.ToInt32(DDLCamp.SelectedValue), DDLProg.SelectedValue, 0, 0, "SEGUIMIENTO_YEARS");
            if (dt.Rows.Count > 0)
            {
                DDLYear.DataSource = dt;
                DDLYear.DataValueField = "Fecha_Seg";
                DDLYear.DataTextField = "Fecha_Seg";
            }
            else 
            {
              DDLYear.Items.Insert(0, new ListItem("2015", "2015"));
            }
        }
        private void Llenar_GRILLA() 
        {
            DB_EXT_SegSemanalTotales seg = new DB_EXT_SegSemanalTotales();
            GVAdversidades.DataSource = seg.DB_Desplegar_SEG_ADVERSIDAD(Convert.ToInt32(DDLRegional.SelectedValue), Convert.ToInt32(DDLCamp.SelectedValue), DDLProg.SelectedValue, Convert.ToInt32(DDLYear.SelectedValue), Convert.ToInt32(DDLMonth.SelectedValue), "ADVERSIDADES");
            GVAdversidades.DataBind();
        }
        protected void DDLProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_GRILLA();
        }

        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DDLCAMPANHIA();
            Llenar_GRILLA();
        }

        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_GRILLA();
        }

        protected void ImgBtnPrint_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {

        }

        protected void DDLYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_GRILLA();
        }

        protected void DDLMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_GRILLA();
        }
    }
}