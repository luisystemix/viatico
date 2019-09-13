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
    public partial class frmRegionesApoyadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            if (!IsPostBack)
            {
                LblIdUser.Text = Session["IdUser"].ToString();
                //Cargar_COMBO();
                Llenar_DDLRegional();
                Llenar_DDLCAMPANHIA();
                Desplegar_CAMP_APOYADAS();
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
            DataTable dt = User.DB_Desplegar_USUARIO(LblIdUser.Text);
            if (Convert.ToInt32(dt.Rows[0][6].ToString()) == 15 || Convert.ToInt32(dt.Rows[0][6].ToString()) == 5)
            {
                //DDLRegional.Items.Insert(0, new ListItem(dt.Rows[0][5].ToString(), dt.Rows[0][4].ToString(), true));
                //DDLRegional.Enabled = false;
                DDLRegion.Items.Insert(0, new ListItem(dt.Rows[0][13].ToString(), dt.Rows[0][13].ToString(), true));
                DDLRegion.Enabled = false;
            }
        }
        #endregion
        #region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS
        private void Llenar_DDLCAMPANHIA()
        {
            DB_AP_Campanhia cam = new DB_AP_Campanhia();
            DataTable dt = new DataTable();
            dt = cam.DB_Seleccionar_CAMPANHIA_REG(DDLRegion.SelectedValue, "INICIADO");
            DDLCamp.DataSource = dt;
            DDLCamp.DataValueField = "Id_Campanhia";
            DDLCamp.DataTextField = "Nombre";
            DDLCamp.DataBind();
        }
        #endregion
        #region OBTENER LA LISTA DE LAS CAMPOAÑAS APOYADAS
        protected void Desplegar_CAMP_APOYADAS()
        {
            //if (DDLRegion.SelectedValue != "TODOS")
            //{
                DB_RegionesApoyadas ListRegCamp = new DB_RegionesApoyadas();
                GVCampEmapa.DataSource = ListRegCamp.DB_Desplegar_CAMP_APOYADAS("", DDLRegion.SelectedValue, Convert.ToInt32(DDLCamp.SelectedValue), 0, "APOYO_CAMPANIA");
                GVCampEmapa.DataBind();
            //}
            //else 
            //{
            //    DB_RegionesApoyadas ListRegCamp = new DB_RegionesApoyadas();
            //    GVCampEmapa.DataSource = ListRegCamp.DB_Desplegar_CAMP_APOYADAS("", DDLRegion.SelectedValue, Convert.ToInt32(0), 0, "APOYO_CAMPANIA");
            //    GVCampEmapa.DataBind();
            //}
        }
        #endregion
        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DDLRegional();
            Desplegar_CAMP_APOYADAS();
            LblMsj.Text = string.Empty;
        }
        protected void GVCampEmapa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DB_RegionesApoyadas ListRegCamp = new DB_RegionesApoyadas();
            DataTable dt = new DataTable();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Dep = DataBinder.Eval(e.Row.DataItem, "Departamento").ToString();
                string prog = DataBinder.Eval(e.Row.DataItem, "Programa").ToString();
                int idcamp = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Campanhia").ToString());
                int idreg = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Regional").ToString());
                var image = e.Row.FindControl("ImgEstado") as Image;
                dt = ListRegCamp.DB_Desplegar_CAMP_APOYADAS(Dep, prog, idcamp, idreg, "NUM_ORG");
                ((Label)e.Row.FindControl("LblNumOrg")).Text = dt.Rows[0][0].ToString();
                dt = ListRegCamp.DB_Desplegar_CAMP_APOYADAS(Dep, prog, idcamp, 0, "NUM_PROD");
                ((Label)e.Row.FindControl("LblNumProd")).Text = dt.Rows[0][0].ToString();
                dt = ListRegCamp.DB_Desplegar_CAMP_APOYADAS(Dep, prog, idcamp, 0, "SUP_APOYADA");
                if (dt.Rows[0][1].ToString() != "")
                {
                    ((Label)e.Row.FindControl("LblSupInscrita")).Text = dt.Rows[0][1].ToString();
                }
                else 
                {
                    ((Label)e.Row.FindControl("LblSupInscrita")).Text = "0";
                }
                if (dt.Rows[0][2].ToString()!="")
                {
                    ((Label)e.Row.FindControl("LblSupApoyada")).Text = dt.Rows[0][2].ToString();
                }
                else
                {
                    ((Label)e.Row.FindControl("LblSupApoyada")).Text = "0";       
                }
                dt = ListRegCamp.DB_Desplegar_CAMP_APOYADAS(Dep, prog, idcamp, 0, "NUM_PROD_DEP");
                ((Label)e.Row.FindControl("LblNumDepurados")).Text = dt.Rows[0][0].ToString();
            }
        }

        protected void DDLRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DDLRegional();
            Llenar_DDLCAMPANHIA();
            Desplegar_CAMP_APOYADAS();
        }

        protected void ImbBtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("IdCamp", DDLCamp.SelectedValue);
            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Control/repRegionesApoyadas.aspx?ci=" + "0");
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
        }

        protected void GVCampEmapa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            DB_EXT_DesignacionOrg ListDesOrg = new DB_EXT_DesignacionOrg();
            DB_RegionesApoyadas ListRegCamp = new DB_RegionesApoyadas();
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVCampEmapa.Columns[6].Visible = true;
            Desplegar_CAMP_APOYADAS();
            Session.Add("Prog", GVCampEmapa.Rows[rowIndex].Cells[1].Text);
            Session.Add("IdCamp", DDLCamp.SelectedValue);
            Session.Add("IdReg", GVCampEmapa.Rows[rowIndex].Cells[6].Text);
            StringBuilder sbMensaje = new StringBuilder();
            switch (tipo)
            {
                case "Designacion":

                    dt = ListDesOrg.DB_Seleccionar_DESIGNACION_ORG(Convert.ToInt32(GVCampEmapa.Rows[rowIndex].Cells[6].Text), Convert.ToInt32(DDLCamp.SelectedValue), "", GVCampEmapa.Rows[rowIndex].Cells[1].Text, "REP_LISTASIGNADOS");
                      if(dt.Rows.Count > 0)
                      {
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=800,height=400,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repDesignacionOrgTPE.aspx?ci=" + GVCampEmapa.Rows[rowIndex].Cells[1].Text);
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                      }
                      else
                      {
                          Response.Write("<script>window.alert('No se registró la designación de técnicos de producción, en la regional.');</script>");
                      }
                    break;
                case "Cronograna":

                   ///////////// dt = ListRegCamp.DB_Desplegar_CAMP_APOYADAS("", GVCampEmapa.Rows[rowIndex].Cells[1].Text, Convert.ToInt32(DDLCamp.SelectedValue), Convert.ToInt32(DDLRegional.SelectedValue), "ID_CRONOGRAMA");
                    dt = ListRegCamp.DB_Desplegar_CAMP_APOYADAS("", GVCampEmapa.Rows[rowIndex].Cells[1].Text, Convert.ToInt32(DDLCamp.SelectedValue), Convert.ToInt32(GVCampEmapa.Rows[rowIndex].Cells[6].Text), "ID_CRONOGRAMA");
                   
                    if (dt.Rows.Count != 0)
                    {
                        Session.Add("IdCrono", dt.Rows[0][0].ToString());
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=800,height=400,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Control/repCronogramaTec.aspx?ci=" + GVCampEmapa.Rows[rowIndex].Cells[1].Text);
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    }
                    else 
                    {
                        Response.Write("<script>window.alert('NO se registró un cronograma para la campaña y programa correspondiente.');</script>");
                    }
                    break;
            }
            GVCampEmapa.Columns[6].Visible = false;
            Desplegar_CAMP_APOYADAS();
        }

        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_CAMP_APOYADAS();
        }
    }
}