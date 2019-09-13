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
    public partial class frmListaControlSegTec : System.Web.UI.Page
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
                Desplegar_SEGUIMIENTO_TECNICOS();
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
        #region OBTENER LA LISTA DE LAS CAMPOAÑAS APOYADAS
        protected void Desplegar_SEGUIMIENTO_TECNICOS()
        {
            DB_EXT_Seguimiento segt = new DB_EXT_Seguimiento();
            GVSegTec.DataSource = segt.DB_Desplegar_SEGUIMIENTO_A_TECNICOS(LblIdUsuario.Text, DDLProg.SelectedValue, Convert.ToInt32(DDLCamp.SelectedValue), Convert.ToInt32(DDLRegional.SelectedValue), "SEG_TECNICOS");
            GVSegTec.DataBind();
        }
        #endregion

        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_SEGUIMIENTO_TECNICOS();
        }

        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DDLCAMPANHIA();
            Desplegar_SEGUIMIENTO_TECNICOS();
        }

        protected void DDLProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_SEGUIMIENTO_TECNICOS();
        }

        protected void GVSegTec_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            StringBuilder sbMensaje = new StringBuilder();
            GVSegTec.Columns[6].Visible = true;
            GVSegTec.Columns[7].Visible = true;
            Desplegar_SEGUIMIENTO_TECNICOS();
            Session.Add("IdSeguimiento", GVSegTec.Rows[rowIndex].Cells[6].Text);
            Session.Add("Etapa", GVSegTec.Rows[rowIndex].Cells[2].Text);
            Session.Add("IdInsOrg", GVSegTec.Rows[rowIndex].Cells[7].Text);
            switch (tipo)
            {
                case "Seguimiento":
                    switch (GVSegTec.Rows[rowIndex].Cells[2].Text)
                    {
                        case "VERIFICACION_PARCELA":
                            sbMensaje.Append("<script type='text/javascript'>");
                            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repSeguimientosTecnicos.aspx?ci=" + GVSegTec.Rows[rowIndex].Cells[5].Text);
                            sbMensaje.Append("</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                            break;
                        case "VERIFICACION_SIEMBRA":
                            sbMensaje.Append("<script type='text/javascript'>");
                            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repSeguimientosTecnicos.aspx?ci=" + GVSegTec.Rows[rowIndex].Cells[5].Text);
                            sbMensaje.Append("</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                            break;
                        case "VERIFICACION_CULTIVO":
                            sbMensaje.Append("<script type='text/javascript'>");
                            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repSeguimientosTecnicos.aspx?ci=" + GVSegTec.Rows[rowIndex].Cells[5].Text);
                            sbMensaje.Append("</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                            break;
                        case "DISTRIBUCION_SEMILLA":
                            sbMensaje.Append("<script type='text/javascript'>");
                            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repDistribSemillaOrg.aspx?ci=" + GVSegTec.Rows[rowIndex].Cells[4].Text);
                            sbMensaje.Append("</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                            break;
                        case "DISTRIBUCION_AGROQUIMICO":
                            sbMensaje.Append("<script type='text/javascript'>");
                            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repDistribAgroQuimOrg.aspx?ci=" + GVSegTec.Rows[rowIndex].Cells[4].Text);
                            sbMensaje.Append("</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                            break;
                    }
                    break;
                case "Aceptar":
                    DB_EXT_Seguimiento seg = new DB_EXT_Seguimiento();
                    seg.DB_Cambiar_ESTADO_SEGUIMIENTO(GVSegTec.Rows[rowIndex].Cells[6].Text,"APROBADO");
                    break;
            }
            GVSegTec.Columns[6].Visible = false;
            GVSegTec.Columns[7].Visible = false;
            Desplegar_SEGUIMIENTO_TECNICOS();
        }
        protected void GVSegTec_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DB_EXT_Reportes rep = new DB_EXT_Reportes();
            DataTable dt = new DataTable();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int idSeg = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Seguimiento"));
                string etapa = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Etapa"));
                ((Label)e.Row.FindControl("LblNumBolet")).Text = Seleccionar_NUM_BOLETA(idSeg,etapa);
                int valor = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Tipo_Seguimiento"));
                if (valor == 0)
                {
                    e.Row.Cells[8].Text = "En Campo";
                }
                else
                {
                    e.Row.Cells[8].Text = "Por Monitoreo";
                }
            }
        }
        #region FUNCION PARA BUSCAR EL NUMERO DE BOLETA
        protected string Seleccionar_NUM_BOLETA(int idSeg, string etapa)
        {
            DB_EXT_Seguimiento numbol = new DB_EXT_Seguimiento();
            DataTable dt = new DataTable();
            dt = numbol.DB_Seleccionar_NUM_BOLETA_SEG(idSeg, etapa);
            return dt.Rows[0][0].ToString();
        }
        #endregion

        protected void ImgBtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            StringBuilder sbMensaje = new StringBuilder();
            Session.Add("IdCamp", DDLCamp.SelectedValue);
            Session.Add("IdReg", DDLRegional.SelectedValue);
            Session.Add("Programa", DDLProg.SelectedValue);
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Control/repListaControlSegTec.aspx?ci=" + LblIdUsuario.Text);
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
        }
    }
}