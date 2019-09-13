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
    public partial class frmEstadoFenologico : System.Web.UI.Page
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
                    Llenar_GRILLA();
                    //Graficar();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            } 
        }
        protected void Llenar_GRILLA() 
        {
            DB_EXT_SegSemanalTotales data = new DB_EXT_SegSemanalTotales();
            GVEnvioSem.DataSource = data.DB_Desplegar_SEG_SEMANAL_TOTAL(Convert.ToInt32(DDLRegional.SelectedValue),Convert.ToInt32(DDLCamp.SelectedValue),DDLProg.SelectedValue,"TOTALES");
            GVEnvioSem.DataBind();
        } 
        protected void Graficar() 
        {
            DB_EXT_SegSemanalTotales data = new DB_EXT_SegSemanalTotales();
            DataTable dt = new DataTable();

            dt = data.DB_Desplegar_SEG_SEMANAL_TOTAL(Convert.ToInt32(DDLRegional.SelectedValue), Convert.ToInt32(DDLCamp.SelectedValue), DDLProg.SelectedValue, "TOTALES");
            string[] fases = { "GERMINACION EMERGENCIA", "PLANTULA", "MACOLLAMIENTO", "EMBUCHE", "ESPIGAZON", "FLORACION", "LLENADO GRANO", "MADURACION" };

            string jose = GVEnvioSem.Rows[0].Cells[12].Text;
            decimal[] valor = { Convert.ToDecimal(dt.Rows[0][8].ToString()), Convert.ToDecimal(dt.Rows[0][9].ToString()), Convert.ToDecimal(dt.Rows[0][10].ToString()), Convert.ToDecimal(dt.Rows[0][11].ToString()), Convert.ToDecimal(dt.Rows[0][12].ToString()), Convert.ToDecimal(dt.Rows[0][13].ToString()), Convert.ToDecimal(dt.Rows[0][14].ToString()), Convert.ToDecimal(dt.Rows[0][15].ToString()) };

            Chart1.Series["Series1"].Points.DataBindXY(fases, valor);
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

        protected void DDLProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_GRILLA();
        }

        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_GRILLA();
        }

        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_GRILLA();
        }

        protected void GVEnvioSem_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVEnvioSem.Columns[15].Visible = true;
            Llenar_GRILLA();
            switch (tipo)
            {
                case "Ver":
                 DB_EXT_SegSemanalTotales data = new DB_EXT_SegSemanalTotales();
                 LblFechaF.Text = (GVEnvioSem.Rows[rowIndex].Cells[15].Text);
                 LblFechaI.Text = (Convert.ToDateTime(LblFechaF.Text).AddDays(-7)).ToString("dd/MM/yyyy");
                 string[] fases = { "GERMINACION EMERGENCIA", "PLANTULA", "MACOLLAMIENTO", "EMBUCHE", "ESPIGAZON", "FLORACION", "LLENADO GRANO", "MADURACION" };
                 decimal[] valor = { Convert.ToDecimal(GVEnvioSem.Rows[rowIndex].Cells[5].Text), Convert.ToDecimal(GVEnvioSem.Rows[rowIndex].Cells[6].Text), Convert.ToDecimal(GVEnvioSem.Rows[rowIndex].Cells[7].Text), Convert.ToDecimal(GVEnvioSem.Rows[rowIndex].Cells[8].Text), Convert.ToDecimal(GVEnvioSem.Rows[rowIndex].Cells[9].Text), Convert.ToDecimal(GVEnvioSem.Rows[rowIndex].Cells[10].Text), Convert.ToDecimal(GVEnvioSem.Rows[rowIndex].Cells[11].Text), Convert.ToDecimal(GVEnvioSem.Rows[rowIndex].Cells[12].Text) };
                 Chart1.Series["Series1"].Points.DataBindXY(fases, valor);
                break;
            }
            GVEnvioSem.Columns[15].Visible = false;
            Llenar_GRILLA();  
        }
    }
}