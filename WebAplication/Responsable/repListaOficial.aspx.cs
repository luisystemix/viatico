using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;

namespace WebAplication.Responsable
{
    public partial class repListaOficial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                Desplegar_ENCABEZADO();
                //string urrl = Request.QueryString["data"];
                //TSHAK.Components.SecureQueryString querystringSeguro;
                //querystringSeguro = new TSHAK.Components.SecureQueryString(new Byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 8 }, urrl);
                ////parametros de otra formulario
                //this.HiddenFieldInsOrg.Value = Convert.ToString(querystringSeguro["IdInsOrg"]);;
                Reporte_LISTA_PROD();
            }
        }
        #region FUNCION PARA DESPLEGAR PLANILLA DE PRODUCTORES EN LA GRILLA
        protected void Reporte_LISTA_PROD()
        {
            DB_AP_Registro_Prod ListRep = new DB_AP_Registro_Prod();
            GVListOfi.DataSource = ListRep.DB_Reporte_PLANILLA_PROD(Convert.ToInt32(LblIdInsOrg.Text), "LISTAOFICIAL");
            GVListOfi.DataBind();
        }
        #endregion
        #region FUNCION QUE CAPURA LOS VALORES DEL ENCABEZADO
        protected void Desplegar_ENCABEZADO()
        {
            DB_AP_Registro_Org vro = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = vro.DB_Desplegar_ENCABEZADO_ORG(Convert.ToInt32(LblIdInsOrg.Text));
            LblRegional.Text = dt.Rows[0][8].ToString();
            LblPrograma.Text = dt.Rows[0][9].ToString();
            LblCampanhia.Text = dt.Rows[0][6].ToString();
        }
        #endregion
    }
}