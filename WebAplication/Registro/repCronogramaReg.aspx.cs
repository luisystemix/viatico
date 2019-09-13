using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;

namespace WebAplication.Registro
{
    public partial class repCronogramaReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdCrono.Text = Session["IdCrono"].ToString();
                    Reporte_CRONOGRAMA_REGIONAL();
                }
            }
            catch
            {
                //Response.Redirect("../Responsable/frmControlRegional.aspx");
            }
        }
        #region FUNCION PARA DESPLEGAR EL CRONOGRAMA INICIAL PRESENTADO POR LA REGIONAL EN LA GRILLA
        protected void Reporte_CRONOGRAMA_REGIONAL()
        {
            DB_AP_CronogramaCamp ListCamp = new DB_AP_CronogramaCamp();
            DataTable dt = new DataTable();
            dt = ListCamp.DB_Desplegar_LISTA_CRONOGRAMAS(Convert.ToInt32(LblIdCrono.Text), "DATOS_ROTULO");
            LblCampanhia.Text=dt.Rows[0][0].ToString();
            LblRegional.Text = dt.Rows[0][2].ToString();
            LblPrograma.Text = dt.Rows[0][3].ToString();
            GVConograma.DataSource = ListCamp.DB_Desplegar_LISTA_CRONOGRAMAS(Convert.ToInt32(LblIdCrono.Text), "CRONOGRAMA");
            GVConograma.DataBind();
        }
        #endregion
    }
}