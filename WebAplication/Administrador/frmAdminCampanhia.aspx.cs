using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;

namespace WebAplication.Administrador
{
    public partial class frmAdminCampanhia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Desplegar_CAMPANIHA();
                Desplegar_CAMPANIHA();
            }
        }
        #region FUNCION PARA DESPLEGAR LA LISTA DE LAS CAMPAÑIAS
        protected void Desplegar_CAMPANIHA()
        {
            DB_AP_Campanhia ListCamp = new DB_AP_Campanhia();
            GVListCamp.DataSource = ListCamp.DB_Desplegar_CAMPANHIA();
            GVListCamp.DataBind();
        }
        #endregion

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Add("estado","nuevo");
            Response.Redirect("Inicio.aspx");
        }

        protected void GVListCamp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVListCamp.Columns[5].Visible = true;
            Desplegar_CAMPANIHA();
            Session.Add("IdCamp", GVListCamp.Rows[rowIndex].Cells[5].Text);
            if (GVListCamp.Rows[rowIndex].Cells[4].Text!="FINALIZADO")
            {
                switch (tipo)
                {
                    case "Reuniones":
                        Response.Redirect("frmListaReuniones.aspx");
                        break;
                    case "Informes":
                        break;
                    case "Programa":
                        Session.Add("estado", "programa");
                        Response.Redirect("Inicio.aspx");
                        break;
                }
            }
            else
            {
                GVListCamp.Columns[5].Visible = false;
                Desplegar_CAMPANIHA();
                LblMsj.Text = "La campaña finalizo no se puede modificar los datos";
            }
            
        }
    }
}