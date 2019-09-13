using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Text;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;
using DataBusiness.DB_General;
using DataEntity.DE_Extensiones;
using DataBusiness.DB_Extensiones;

namespace WebAplication.Extensiones
{
    public partial class frmListaSegOrg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    Datos_ENCABEZADO();
                    Llenar_GVDESIGNADO();
                }
            }
            catch 
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Datos_ENCABEZADO()
        {
            DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = Usuario.DB_Desplegar_USUARIO(LblIdUsuario.Text);
            LblRegional.Text = dt.Rows[0][5].ToString();
            LblIdReg.Text = dt.Rows[0][4].ToString();
            DB_AP_Campanhia camp = new DB_AP_Campanhia();
            dt = camp.DB_Seleccionar_CAMPANHIA_REG_NOFIN(dt.Rows[0][10].ToString());
            LblCamp.Text = dt.Rows[0][1].ToString();
            LblIdCamp.Text = dt.Rows[0][0].ToString();
        }
        #endregion
        #region FUNCION PARA LLENAR DE REGITROS LA GRILLA
        private void Llenar_GVDESIGNADO()
        {
            DB_EXT_DesignacionOrg ListDesOrg = new DB_EXT_DesignacionOrg();
            GVLisOrg.DataSource = ListDesOrg.DB_Seleccionar_DESIGNACION_ORG(Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblIdCamp.Text),LblIdUsuario.Text, DDLPrograma.SelectedValue, "LISTASIGNADOS");
            GVLisOrg.DataBind();
        }
        #endregion
        #region FUNCIONES DEL COMBO
        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_GVDESIGNADO();
        }
        #endregion
        #region FUNCIONES DE LA GRILLA
        protected void GVLisOrg_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DB_EXT_Seguimiento disSem = new DB_EXT_Seguimiento();
            DataTable dt = new DataTable();
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            StringBuilder sbMensaje = new StringBuilder();
            GVLisOrg.Columns[4].Visible = true;
            Llenar_GVDESIGNADO();
            Session.Add("IdInsOrg", GVLisOrg.Rows[rowIndex].Cells[4].Text);
            switch (tipo)
            {
                case "Seguimiento":
                    Response.Redirect("frmSeguimientoTecnico.aspx");
                    break;
                case "Fenologia":
                    Response.Redirect("frmListaSegFenologia.aspx");
                    break;
                case "Semilla":
                    dt = disSem.DB_Reporte_DISTRIBUCION_DETALLE(Convert.ToInt32(GVLisOrg.Rows[rowIndex].Cells[4].Text), "SEMILLA", "REPPROD");
                    if (dt.Rows.Count > 0)
                    {
                        LblMsj.Text = string.Empty;
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repDistribSemillaOrg.aspx?ci=" + GVLisOrg.Rows[rowIndex].Cells[4].Text);
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    }
                    else 
                    {
                        LblMsj.Text = "No existe un reporte para mostrar, a la fecha NO registro un seguimiento a la distribución de semilla.";
                    }
                    break;
                case "Quimicos":
                    dt = disSem.DB_Reporte_DISTRIBUCION_DETALLE(Convert.ToInt32(GVLisOrg.Rows[rowIndex].Cells[4].Text), "AGROQUIMICO", "REPPROD");
                    if (dt.Rows.Count > 0)
                    {
                        LblMsj.Text = string.Empty;
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repDistribAgroQuimOrg.aspx?ci=" + GVLisOrg.Rows[rowIndex].Cells[4].Text);
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    }
                    else 
                    {
                        LblMsj.Text = "No existe un reporte para mostrar, a la fecha NO registro un seguimiento a la distribución de agroquímicos.";
                    }
                    break;
                case "Rendimiento":
                    dt = disSem.DB_Reporte_DISTRIBUCION_DETALLE(Convert.ToInt32(GVLisOrg.Rows[rowIndex].Cells[4].Text), "RENDIMIENTO", "CONTAR_REND"); /***********************/
                    if (dt.Rows.Count > 0)
                    {
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repRendimiento.aspx?ci=" + GVLisOrg.Rows[rowIndex].Cells[4].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    LblMsj.Text = string.Empty;
                    }
                    else
                    {
                        LblMsj.Text = "No existe un reporte para mostrar, a la fecha NO registro un seguimiento para el Rendimiento";
                    }
                    break;
                case "Costos":
                    dt = disSem.DB_Reporte_DISTRIBUCION_DETALLE(Convert.ToInt32(GVLisOrg.Rows[rowIndex].Cells[4].Text), "COSTOS", "CONTAR_COST");/*************************/
                    if (dt.Rows.Count > 0)
                    {
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repCostos.aspx?ci=" + GVLisOrg.Rows[rowIndex].Cells[4].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    }
                    else
                    {
                        LblMsj.Text = "No existe un reporte para mostrar, a la fecha NO registro un seguimiento para calcular los Costos de Producción";
                    }
                    break;
            }
            GVLisOrg.Columns[4].Visible = false;
            Llenar_GVDESIGNADO();
        }
        #endregion

        protected void GVLisOrg_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DB_AP_InscripcionOrg ino = new DB_AP_InscripcionOrg();
            DataTable dt = new DataTable();
            dt = ino.DB_Obtener_SUM_HA_NUM_PROD(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_InscripcionOrg")), "CONTADOR-OFICIAL");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((Label)e.Row.FindControl("LblNumProd")).Text = dt.Rows[0][0].ToString();
            }
        }
    }
}