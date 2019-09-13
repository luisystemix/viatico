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

namespace WebAplication.Control
{
    public partial class frmRP_SegDocumentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            if (!IsPostBack)
            {
                LblIdUsuario.Text = Session["IdUser"].ToString();
                Llenar_DDLRegional();
                Llenar_DDLCAMPANHIA();
                Llenar_GVDESIGNADO();
            }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //} 
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
            Llenar_GVDESIGNADO();
        }

        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DDLCAMPANHIA();
            Llenar_GVDESIGNADO();
        }

        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_GVDESIGNADO();
        }
        #region FUNCION PARA LLENAR DE REGITROS LA GRILLA
        private void Llenar_GVDESIGNADO()
        {
            DB_EXT_DesignacionOrg ListDesOrg = new DB_EXT_DesignacionOrg();
            GVLisOrg.DataSource = ListDesOrg.DB_Seleccionar_DESIGNACION_ORG(Convert.ToInt32(DDLRegional.SelectedValue), Convert.ToInt32(DDLCamp.SelectedValue), LblIdUsuario.Text, DDLProg.SelectedValue, "LISTADOCUMENTOS");
            GVLisOrg.DataBind();
        }
        #endregion

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
                    Response.Redirect("frmRP_SegFenologias.aspx");
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