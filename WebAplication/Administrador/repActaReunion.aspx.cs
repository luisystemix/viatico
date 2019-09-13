using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;

namespace WebAplication.Administrador
{
    public partial class repActaReunion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LblIdReunion.Text=Session["IdReunion"].ToString();
                Desplegar_Reporte_REUNIONES();
            }
        }
        protected void Desplegar_Reporte_REUNIONES()
        {
            DB_AP_Reunion listReuni = new DB_AP_Reunion();
            DataTable dt = new DataTable();
            dt = listReuni.DB_Reporte_REUNIONES(Convert.ToInt32(LblIdReunion.Text), 0, "REUNION");
            LblTipoReunion.Text = dt.Rows[0][4].ToString();
            LblCamp.Text = dt.Rows[0][1].ToString();
            LblCamp1.Text = dt.Rows[0][1].ToString();
            LblLugar.Text = dt.Rows[0][5].ToString();
            LblRegional.Text = dt.Rows[0][8].ToString();
            LblFecha.Text = dt.Rows[0][6].ToString();
            LblConclu.Text = dt.Rows[0][7].ToString();
            GVAsistencia.DataSource = listReuni.DB_Reporte_REUNIONES(Convert.ToInt32(LblIdReunion.Text), 0, "ASISTENCIA");
            GVAsistencia.DataBind();
            GVTarea.DataSource = listReuni.DB_Reporte_REUNIONES(Convert.ToInt32(LblIdReunion.Text), 0, "TEMAS");
            GVTarea.DataBind();
        }
    }
}