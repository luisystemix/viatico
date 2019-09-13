using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;
using DataBusiness.DB_Extensiones;

namespace WebAplication.Extensiones
{
    public partial class frmListaDistribSemilla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                if (!IsPostBack)
                {
                    LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                    LblIdInsProd.Text = Session["IdInsProd"].ToString();
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    Datos_Org_ENCABEZADO();
                    Llenar_GVSEGUIMIENTO();
                }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        #region FUNCION PARA LLENAR DE REGITROS LA GRILLA
        private void Llenar_GVSEGUIMIENTO()
        {
            DB_EXT_Seguimiento ListSeg = new DB_EXT_Seguimiento();
            GVDistribSem.DataSource = ListSeg.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg.Text), LblIdInsProd.Text, "SEMILLA", "SEGUIMIENTODISTRIB");
            GVDistribSem.DataBind();
        }
        #endregion
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Datos_Org_ENCABEZADO()
        {
            DB_AP_Registro_Org d_org = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = d_org.DB_Desplegar_ENCABEZADO_ORG(Convert.ToInt32(LblIdInsOrg.Text));
            LblOrg.Text = dt.Rows[0][2].ToString();
            LblIdCamp.Text = dt.Rows[0][5].ToString();
            LblProg.Text = dt.Rows[0][9].ToString();
            LblIdReg.Text = dt.Rows[0][7].ToString();
            DB_AP_Productor p = new DB_AP_Productor();
            dt = p.DB_Seleccionar_ENCABEZADO_PROD(LblIdInsProd.Text, "DATS_PROD");
            LblProductor.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString();
        }
        #endregion

        protected void LnkBtnSegDistSem_Click(object sender, EventArgs e)
        {
            //if (GVDesignado.Rows[rowIndex].Cells[3].Text == "DISTRIBUCION_SEMILLA")
            //{
            Response.Redirect("frmDistribucionSemilla.aspx");
            //}
            //else
            //{
            //    LblMsj.Text = "ya se registro el seguimiento a la distribucion de semilla";
            //}
        }
    }
}