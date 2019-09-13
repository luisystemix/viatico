using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataBusiness.DB_Registro;
using DataBusiness.DB_General;
using DataEntity.DE_General;

namespace WebAplication.Juridica
{
    public partial class repContratoProvision : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                DB_AP_Responsable ListOrg = new DB_AP_Responsable();
                DataTable dt = new DataTable();
                dt = ListOrg.DB_Seleccionar_CONTRATOS_ORG(Convert.ToInt32(LblIdInsOrg.Text), "juridica");
                LblCodContrato.Text=dt.Rows[0][20].ToString();
                LblPrograma.Text = dt.Rows[0][1].ToString();
                LblOrganizacion.Text = dt.Rows[0][2].ToString();
                LblNumResol.Text = dt.Rows[0][3].ToString();
                LblFechaResol.Text = dt.Rows[0][4].ToString();
                LblRespJuridi.Text = dt.Rows[0][9].ToString();
                LblciRespJuridi.Text = dt.Rows[0][10].ToString();
                LblNumTestim.Text = dt.Rows[0][11].ToString();
                LblNumNotario.Text = dt.Rows[0][12].ToString();
                LblAbogadoACarg.Text = dt.Rows[0][14].ToString();
                LblDistritJudi.Text = dt.Rows[0][13].ToString();
                LblComunidad.Text = dt.Rows[0][26].ToString();
                LblNumicipio.Text = dt.Rows[0][6].ToString();
                LblProvincia.Text=dt.Rows[0][7].ToString();
                LblDepartamento.Text = dt.Rows[0][8].ToString();
                LblCamp.Text = dt.Rows[0][0].ToString();
            }
        }
    }
}