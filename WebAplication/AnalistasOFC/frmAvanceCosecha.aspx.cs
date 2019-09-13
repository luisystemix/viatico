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

namespace WebAplication.AnalistasOFC
{
    public partial class frmAvanceCosecha : System.Web.UI.Page
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
                Llenar_GRILLA();
            }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //} 
        }
        #region LLENAR LA GRILLA DE LAS ORGANIZACIONES
        protected void Llenar_GRILLA() 
        {
            DB_EXT_SegSemanalTotales data = new DB_EXT_SegSemanalTotales();
            GVOrgSup.DataSource = data.DB_Desplegar_SEG_SEMANAL_TOTAL(Convert.ToInt32(DDLRegional.SelectedValue),Convert.ToInt32(DDLCamp.SelectedValue),DDLProg.SelectedValue,"ORG_SUP");
            GVOrgSup.DataBind();
        } 
        #endregion
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
            Llenar_GRILLA();
        }

        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_GRILLA();
        }

        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_GRILLA();
        }

        protected void GVOrgSup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DB_EXT_Rendimiento rend = new DB_EXT_Rendimiento();
            DB_EXT_Fenologia numBol = new DB_EXT_Fenologia();
            DataTable dt = new DataTable();
            decimal rendi = 0;
            decimal supe = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int id = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_InscripcionOrg"));
                dt = rend.DB_Reporte_DETALLE_PLANILLA(id, "", "", "RENDIMIENTO_PROMEDIO");
                rendi = Convert.ToDecimal(dt.Rows[0][0].ToString());
                //dt = numBol.DB_Datos_FACE_FENOLOGICA(id, Convert.ToInt32(DDLCamp.SelectedValue), 34, Convert.ToInt32(DDLRegional.SelectedValue), "TRIGO", "Avance", 1, DateTime.Now, "RENDIMIENTO");
                dt = numBol.DB_Datos_FACE_FENOLOGICA(id, Convert.ToInt32(DDLCamp.SelectedValue), 34, Convert.ToInt32(DDLRegional.SelectedValue), "TRIGO", "Avance", 1, DateTime.Now, "PORCENTAGE_COSECHA");
                supe = Convert.ToDecimal(dt.Rows[0][0].ToString());
                decimal valor = (((rendi * Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SumaHas"))) * supe) / 100);
                ((Label)e.Row.FindControl("LblSupCos")).Text = supe.ToString();
                ((Label)e.Row.FindControl("LblFanegasEstim")).Text = valor.ToString();
                switch(DDLUnidades.SelectedValue)
                {
                    case "1":
                        //GVOrgSup.Columns[4].HeaderText = DDLUnidades.SelectedItem.Text;

                    break;
                    case "2":
                        // ((TextBox)e.Row.FindControl("TxtObjetivo")).Text = (((rendi * Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SumaHas"))) * supe) / 100).ToString();
                    break;
                    case "3":
                         //((TextBox)e.Row.FindControl("TxtObjetivo")).Text = (((rendi * Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SumaHas"))) * supe) / 100).ToString();
                    break;
                }
                // ((DropDownList)e.Row.FindControl("DDLZona")).Items.Insert(0, new ListItem(zona, zona, true));


                //if (tramo == "Salida")
                //{
                //    ((DropDownList)e.Row.FindControl("DDLZona")).Items.Insert(0, new ListItem(zona, zona, true));
                //    ((DropDownList)e.Row.FindControl("DDLZona")).DataBind();
                //    ((DropDownList)e.Row.FindControl("DDLDestino")).Items.Insert(0, new ListItem(destino, destino, true));
                //    ((DropDownList)e.Row.FindControl("DDLDestino")).DataBind();
                //    ((TextBox)e.Row.FindControl("TxtObjetivo")).Text = objetivo;
                //    ((TextBox)e.Row.FindControl("TxtFecha")).Text = fecha;
                //    ((DropDownList)e.Row.FindControl("DDLHora")).Items.Insert(0, new ListItem(hora, hora, true));
                //    ((DropDownList)e.Row.FindControl("DDLMinuto")).Items.Insert(0, new ListItem(min, min, true));
                //}
                //else
                //{
                //    ((DropDownList)e.Row.FindControl("DDLZona")).Items.Insert(0, new ListItem(zona, zona, true));
                //    ((DropDownList)e.Row.FindControl("DDLZona")).DataBind();
                //    ((DropDownList)e.Row.FindControl("DDLZona")).Enabled = false;
                //    ((DropDownList)e.Row.FindControl("DDLDestino")).Items.Insert(0, new ListItem(destino, destino, true));
                //    ((DropDownList)e.Row.FindControl("DDLDestino")).DataBind();
                //    ((DropDownList)e.Row.FindControl("DDLDestino")).Enabled = false;
                //    ((TextBox)e.Row.FindControl("TxtObjetivo")).Enabled = fal10se;
                //    ((TextBox)e.Row.FindControl("TxtFecha")).Text = fecha;
                //    ((DropDownList)e.Row.FindControl("DDLHora")).Items.Insert(0, new ListItem(hora, hora, true));
                //    ((DropDownList)e.Row.FindControl("DDLMinuto")).Items.Insert(0, new ListItem(min, min, true));
                //}
            }
        }

        protected void DDLUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}