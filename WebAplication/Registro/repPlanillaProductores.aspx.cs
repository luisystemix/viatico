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
    public partial class repPlanillaProductores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Desplegar_ENCABEZADO();
                Reporte_PLANILLA_PROD();
            }
        }
        #region FUNCION QUE CAPURA LOS VALORES DEL ENCABEZADO
        protected void Desplegar_ENCABEZADO()
        {
            DB_AP_Registro_Org vro = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = vro.DB_Desplegar_ENCABEZADO_ORG(Convert.ToInt32(Session["IdInsOrg"].ToString()));
            LblDepartamento.Text = dt.Rows[0][3].ToString();
            LblNombreOrg.Text = dt.Rows[0][2].ToString();
            LblSiglaOrg.Text = dt.Rows[0][1].ToString();
            LblProg.Text = dt.Rows[0][9].ToString();
            LblCampanhia.Text = dt.Rows[0][6].ToString();
        }
        #endregion
        #region FUNCION PARA DESPLEGAR PLANILLA DE PRODUCTORES EN LA GRILLA
        protected void Reporte_PLANILLA_PROD()
        {
            DB_AP_Registro_Prod lst = new DB_AP_Registro_Prod();
            GVListaProd.DataSource = lst.DB_Reporte_PLANILLA_PROD(Convert.ToInt32(Session["IdInsOrg"].ToString()),"PLANILLA");
            GVListaProd.DataBind();
        }
        #endregion
    }
}