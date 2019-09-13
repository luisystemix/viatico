using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DataBusiness.DB_Registro;
using DataBusiness.DB_Extensiones;

namespace WebAplication.Extensiones
{
    public partial class frmListaCostos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        //    try
        //    {
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
            GVListCostos.DataSource = ListSeg.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg.Text), LblIdInsProd.Text, "SEMILLA", "SEGUCOSTO");
            GVListCostos.DataBind();
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
            Session.Add("IdInsProd", LblIdInsProd.Text);
            Response.Redirect("frmCostosProduccion.aspx");
        }

        protected void GVListCostos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            StringBuilder sbMensaje = new StringBuilder();
            GVListCostos.Columns[4].Visible = true;
            Llenar_GVSEGUIMIENTO();
            Session.Add("IdProductor", GVListCostos.Rows[rowIndex].Cells[4].Text);
            Session.Add("IdInsOrg", LblIdInsOrg.Text);
            switch (tipo)
            {
                case "Reporte":
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repCostosProductor.aspx?ci=" + GVListCostos.Rows[rowIndex].Cells[4].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                break;
            }
            GVListCostos.Columns[4].Visible = false;
            Llenar_GVSEGUIMIENTO();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            StringBuilder sbMensaje = new StringBuilder();
            Session.Add("IdProductor", LblIdInsProd.Text);
            Session.Add("IdInsOrg", LblIdInsOrg.Text);
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repCostosProductor.aspx?ci=" + LblIdInsProd.Text);
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
        }
    }
}