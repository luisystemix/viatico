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

namespace WebAplication.Responsable
{
    public partial class frmSegMuestraSem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            if (!IsPostBack)
            {
                LblIdUsuario.Text = Session["IdUser"].ToString();
                Llenar_DDLRegional();
                Llenar_DDLCAMPANHIA();
                TxtFechaIni.Text = DateTime.Now.ToString();
                LblFechaFin.Text = (Convert.ToDateTime(TxtFechaIni.Text)).AddDays(-8).ToString("dd/MM/yyyy");
                Llenar_GRILLA();
            }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            } 
        }
        #region FUNCION PARA LLENAR EL COMBO CON EL TIPO DE ORGANIZACION
        private void Llenar_DDLRegional()
        {
            DB_AdminUser User = new DB_AdminUser();
            DataTable dt = User.DB_Desplegar_USUARIO(LblIdUsuario.Text);
            //LblReg.Text = dt.Rows[0][13].ToString();
            if (Convert.ToInt32(dt.Rows[0][6].ToString()) == 17 || Convert.ToInt32(dt.Rows[0][6].ToString()) == 5)
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
        protected void Llenar_GRILLA()
        {
            DB_EXT_SegSemanalTotales data = new DB_EXT_SegSemanalTotales();
            GVSegTec.DataSource = data.DB_Desplegar_SEG_SEMANAL_TOTAL(Convert.ToInt32(DDLRegional.SelectedValue), Convert.ToInt32(DDLCamp.SelectedValue), DDLProg.SelectedValue, "TECNICO_MUESTRA");
            GVSegTec.DataBind();
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
        #region GRAFICA
        protected void grafica(GridView gr) 
        { 
        
        }
        #endregion
        protected void GVSegTec_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DB_EXT_SegSemanalTotales data = new DB_EXT_SegSemanalTotales();
                DataTable dt = new DataTable();
                int muestra = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Muestra"));
                string idusuario = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Id_Usuario"));
                dt = data.DB_Desplegar_SEG_SEMANAL_MUESTRA(Convert.ToInt32(DDLRegional.SelectedValue), Convert.ToInt32(DDLCamp.SelectedValue), DDLProg.SelectedValue, idusuario, "VERIFICACION_PARCELA", DateTime.Now, "NUM_MUESTRA");
                string[] fases = { "Geo Ref", "Siembra", "Cultivo Semana", "Cosecha" };
                int valor1=((Convert.ToInt32(dt.Rows[0][0].ToString())*100)/muestra);
                dt = data.DB_Desplegar_SEG_SEMANAL_MUESTRA(Convert.ToInt32(DDLRegional.SelectedValue), Convert.ToInt32(DDLCamp.SelectedValue), DDLProg.SelectedValue, idusuario, "VERIFICACION_SIEMBRA", DateTime.Now, "SIEMBRA_MUESTRA");
                int valor2 = ((Convert.ToInt32(dt.Rows[0][0].ToString()) * 100) / muestra);
                ///DateTime fecha=Convert.ToDateTime("21/06/2015");
                //DateTime fecha = DateTime.Now;
                dt = data.DB_Desplegar_SEG_SEMANAL_MUESTRA(Convert.ToInt32(DDLRegional.SelectedValue), Convert.ToInt32(DDLCamp.SelectedValue), DDLProg.SelectedValue, idusuario, "VERIFICACION_CULTIVO", Convert.ToDateTime(TxtFechaIni.Text), "CULTIVO_SEMANAL");
                int valor3 = ((Convert.ToInt32(dt.Rows[0][0].ToString()) * 100) / muestra);
                dt = data.DB_Desplegar_SEG_SEMANAL_MUESTRA(Convert.ToInt32(DDLRegional.SelectedValue), Convert.ToInt32(DDLCamp.SelectedValue), DDLProg.SelectedValue, idusuario, "VERIFICACION_COSECHA", DateTime.Now, "COSECHA_MUESTRA");
                int valor4 = ((Convert.ToInt32(dt.Rows[0][0].ToString()) * 100) / muestra);
                decimal[] valor = { valor1, valor2, valor3, valor4 };
                ((Chart)e.Row.FindControl("Chart1")).Series["Series1"].Points.DataBindXY(fases, valor);
            }
        }

        protected void TxtFechaIni_TextChanged(object sender, EventArgs e)
        {
            LblFechaFin.Text = (Convert.ToDateTime(TxtFechaIni.Text)).AddDays(-8).ToString("dd/MM/yyyy");
            Llenar_GRILLA();
        }
    }
}