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
    public partial class frmListaReuniones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LblIdCamp.Text = Session["IdCamp"].ToString();
                DB_AP_Campanhia buscamp = new DB_AP_Campanhia();
                AP_Campanhia ca = new AP_Campanhia();
                ca = buscamp.DB_Buscar_CAMPANHIA(Convert.ToInt32(LblIdCamp.Text));
                LblCamp.Text = ca.Nombre;
                Desplegar_LISTA_REUNIONES();
            }
        }
        #region LINK BUTON
        protected void LnkReunion_Click(object sender, EventArgs e)
        {
            Session.Add("IdCamp",LblIdCamp.Text);
            Response.Redirect("frmReunion.aspx");
        }
        #endregion
        #region FUNCION PARA DESPLEGAR LA LISTA TORAS LAS REUNIONES DE UNA CAMPAÑA
        protected void Desplegar_LISTA_REUNIONES()
        {
            DB_AP_Reunion ListReu = new DB_AP_Reunion();
            GVListaReunion.DataSource = ListReu.DB_Reporte_REUNIONES(1, Convert.ToInt32(LblIdCamp.Text), "LISTAREUNION");
            GVListaReunion.DataBind();
        }
        #endregion

        protected void GVListaReunion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVListaReunion.Columns[0].Visible = true;
            Desplegar_LISTA_REUNIONES();
            Session.Add("IdReunion", GVListaReunion.Rows[rowIndex].Cells[0].Text);
            switch (tipo)
            {
                case "Ver":
                    Response.Redirect("repActaReunion.aspx");
                    break;
            }
        }
    }
}