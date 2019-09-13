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
    public partial class repCronogramaRegIni : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdCamp.Text = Session["IdCamp"].ToString();
                    LblIdReg.Text = Session["IdReg"].ToString();
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
            DB_AP_Registro_Org ListRep = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = ListRep.DB_Reporte_CRONOGRAMA_REGIONAL(Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text));
            LblCampanhia.Text = dt.Rows[0][0].ToString();
            //LblIdCamp.Text = dt.Rows[0][6].ToString();
            LblRegional.Text = dt.Rows[0][1].ToString();
            //LblIdReg.Text = dt.Rows[0][6].ToString();
            LblPrograma.Text = dt.Rows[0][5].ToString();
            LblFecha.Text = dt.Rows[0][7].ToString();
            LblCronograma.Text = dt.Rows[0][6].ToString();
            LblNombre.Text = dt.Rows[0][3].ToString()+" "+dt.Rows[0][4].ToString();;
            GVConograma.DataSource = ListRep.DB_Reporte_CRONOGRAMA_REGIONAL(Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text));
            GVConograma.DataBind();
        }
        #endregion
    }
}