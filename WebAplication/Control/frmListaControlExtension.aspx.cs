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
    public partial class frmListaControlExtension : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            if (!IsPostBack)
            {
                LblIdUsuario.Text = Session["IdUser"].ToString();
                Llenar_DDLCAMPANHIA();
                Desplegar_SEGUIMIENTO_TECNICOS();
                LblFecha.Text = DateTime.Now.ToString();
            }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //} 
        }
        //#region FUNCION PARA LLENAR EL COMBO CON EL TIPO DE ORGANIZACION
        //private void Llenar_DDLRegional()
        //{
        //    DB_AdminUser User = new DB_AdminUser();
        //    DataTable dt = User.DB_Desplegar_USUARIO(LblIdUsuario.Text);
        //    LblReg.Text=dt.Rows[0][13].ToString();
        //    if (Convert.ToInt32(dt.Rows[0][6].ToString()) == 15 || Convert.ToInt32(dt.Rows[0][6].ToString()) == 5)
        //    {
        //        DDLRegional.Items.Insert(0, new ListItem(dt.Rows[0][5].ToString(), dt.Rows[0][4].ToString(), true));
        //        DDLRegional.Enabled = false;
        //    }
        //    else
        //    {
        //        DB_Regional reg = new DB_Regional();
        //        List<Regional> Lista = reg.DB_Desplegar_REGIONAL();
        //        DDLRegional.DataSource = Lista;
        //        DDLRegional.DataValueField = "Id_Regional";
        //        DDLRegional.DataTextField = "Nombre";
        //        DDLRegional.DataBind();
        //    }
        //}
        //#endregion
        #region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS
        private void Llenar_DDLCAMPANHIA()
        {
            DB_AP_Campanhia cam = new DB_AP_Campanhia();
            DataTable dt = new DataTable();
            dt = cam.DB_Desplegar_CAMPANHIA_REGION(DDLRegion.SelectedValue);
            //AP_Campanhia campa= new AP_Campanhia();
            //List<AP_Campanhia> listCamp = new List<AP_Campanhia>();
            //listCamp = cam.DB_Desplegar_CAMPANHIA();
           // DDLCamp.DataSource = listCamp;
            DDLCamp.DataSource = dt;
            DDLCamp.DataValueField = "Id_Campanhia";
            DDLCamp.DataTextField = "Nombre";
            DDLCamp.DataBind();
            //campa= cam.DB_Buscar_CAMPANHIA(Convert.ToInt32(DDLCamp.SelectedValue));
            //LblRegion.Text = campa.Region;
        }
        #endregion
        #region OBTENER LA LISTA DE LAS CAMPOAÑAS APOYADAS
        protected void Desplegar_SEGUIMIENTO_TECNICOS()
        {
            DB_EXT_Reportes reg = new DB_EXT_Reportes();
            DataTable dt = new DataTable();
            dt = reg.DB_Desplegar_REGIONALES_NOMBRE(DDLCamp.SelectedItem.Text);
            GVFenologias.DataSource = dt;
            GVFenologias.DataBind();
        }
        #endregion
        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_SEGUIMIENTO_TECNICOS();
        }
        protected void DDLProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_SEGUIMIENTO_TECNICOS();
        }
        protected void LnkReporte_Click(object sender, EventArgs e)
        {
            //StringBuilder sbMensaje = new StringBuilder();
            //Session.Add("IdInsOrg", 0);
            //Session.Add("IdReg", DDLRegional.SelectedValue);
            //Session.Add("IdCamp", DDLCamp.SelectedValue);
            //Session.Add("Programa", DDLProg.SelectedValue);
            //Session.Add("NumSeg", DDLFenEnviados.SelectedValue);
            //Session.Add("Tipo", DDLTipo.SelectedValue);
            //sbMensaje.Append("<script type='text/javascript'>");
            //sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Control/repFaceFenologica.aspx?ci=" + LblIdUsuario.Text);
            //sbMensaje.Append("</script>");
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
        }

        protected void GVFenologias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = new DataTable();
                DB_EXT_Fenologia tot = new DB_EXT_Fenologia();
                int Idreg = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Regional"));
                dt = tot.DB_Reporte_FENOLOGIA_DETALLE(0, DDLProg.SelectedValue, 0, Idreg, 0, DDLCamp.SelectedItem.Text, DateTime.Now, "TOTALES");
                if (dt.Rows[0][0].ToString() != "")
                {
                    ((Label)e.Row.FindControl("blNumBoletas")).Text = dt.Rows[0][0].ToString();
                    ((Label)e.Row.FindControl("LblProdVig")).Text = dt.Rows[0][1].ToString();
                    ((Label)e.Row.FindControl("LblSupAct")).Text = dt.Rows[0][2].ToString();
                }
                else 
                {
                    ((Label)e.Row.FindControl("blNumBoletas")).Text = "0";
                    ((Label)e.Row.FindControl("LblProdVig")).Text = "0";
                    ((Label)e.Row.FindControl("LblSupAct")).Text = "0";
                }
            }
        }
        protected void GVFenologias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DB_EXT_Seguimiento disSem = new DB_EXT_Seguimiento();
            DataTable dt = new DataTable();
                    string tipo = Convert.ToString(e.CommandName);
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    StringBuilder sbMensaje = new StringBuilder();
                    Session.Add("Programa", DDLProg.SelectedValue);
                    Session.Add("IdCamp", DDLCamp.SelectedValue);
                    Session.Add("IdReg", GVFenologias.Rows[rowIndex].Cells[0].Text);
                    switch (tipo)
                    {
                        case "Seguimiento":
                            sbMensaje.Append("<script type='text/javascript'>");
                            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../AnalistasOFC/repEstadoFenologico.aspx?ci=" + GVFenologias.Rows[rowIndex].Cells[4].Text);
                            sbMensaje.Append("</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                            break;
                        case "Costos":
                    //dt = disSem.DB_Reporte_DISTRIBUCION_DETALLE(Convert.ToInt32(GVLisOrg.Rows[rowIndex].Cells[4].Text), "COSTOS", "CONTAR_COST");/*************************/
                    //if (dt.Rows.Count > 0)
                    //{
                    //sbMensaje.Append("<script type='text/javascript'>");
                    //sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repCostos.aspx?ci=" + GVLisOrg.Rows[rowIndex].Cells[4].Text);
                    //sbMensaje.Append("</script>");
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    //}
                    //else
                    //{
                    //    LblMsj.Text = "No existe un reporte para mostrar, a la fecha NO registro un seguimiento para calcular los Costos de Producción";
                    //}
                            break;
                    }
               
               //}
                //else
                //{
                //    LblMsg.Text = "No hay Informacion Registrada";
                //}
        }

        protected void DDLRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DDLCAMPANHIA();
            Desplegar_SEGUIMIENTO_TECNICOS();
        }
    }
}