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
using DataEntity.DE_Extensiones;
using DataEntity.DE_Registro;
using DataEntity.DE_General;
using DataBusiness.DB_General;


namespace WebAplication.AnalistasOFC
{
    public partial class frmFenologiaSemana : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!IsPostBack)
                {
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    Llenar_DDLRegional();
                    Llenar_DDLCAMPANHIA();
                    Desplegar_GRILLA_ENVIADOS();
                    //Graficar();
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
                DDLReg.Items.Insert(0, new ListItem(dt.Rows[0][5].ToString(), dt.Rows[0][4].ToString(), true));
                DDLReg.Enabled = false;
            }
            else
            {
                DB_Regional reg = new DB_Regional();
                List<Regional> Lista = reg.DB_Desplegar_REGIONAL();
                DDLReg.DataSource = Lista;
                DDLReg.DataValueField = "Id_Regional";
                DDLReg.DataTextField = "Nombre";
                DDLReg.DataBind();
            }
        }
        #endregion
        #region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS
        private void Llenar_DDLCAMPANHIA()
        {
            DB_AP_Campanhia cam = new DB_AP_Campanhia();
            DB_Regional reg = new DB_Regional();
            DataTable dt = new DataTable();
            dt = reg.DB_Seleccionar_REGIONAL(Convert.ToInt32(DDLReg.SelectedValue));
            string aux = dt.Rows[0][7].ToString();
            dt = cam.DB_Seleccionar_CAMPANHIA_REG_NOFIN(aux);
            DDLCamp.DataSource = dt;
            DDLCamp.DataValueField = "Id_Campanhia";
            DDLCamp.DataTextField = "Nombre";
            DDLCamp.DataBind();
        }
        #endregion
        private void Desplegar_GRILLA_ENVIADOS()
        {
            DB_EXT_Fenologia fendetalle = new DB_EXT_Fenologia();
            GVEnviadosSemana.DataSource = fendetalle.DB_Seleccionar_ENVIOS_SEMANA(Convert.ToInt32(DDLReg.SelectedValue));
            GVEnviadosSemana.DataBind();
        }
        protected void DDLReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DDLCAMPANHIA();
            Desplegar_GRILLA_ENVIADOS();
        }
        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_GRILLA_ENVIADOS();
        }
        protected void DDLProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_GRILLA_ENVIADOS();
        }
        protected void GVEnviadosSemana_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            StringBuilder sbMensaje = new StringBuilder();
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVEnviadosSemana.Columns[8].Visible = true;
            GVEnviadosSemana.Columns[9].Visible = true;
            GVEnviadosSemana.Columns[10].Visible = true;
            Desplegar_GRILLA_ENVIADOS();
            Session.Add("Programa", GVEnviadosSemana.Rows[rowIndex].Cells[3].Text);
            Session.Add("NumSeg", GVEnviadosSemana.Rows[rowIndex].Cells[8].Text);
            Session.Add("IdCamp", GVEnviadosSemana.Rows[rowIndex].Cells[9].Text);
            Session.Add("IdReg", GVEnviadosSemana.Rows[rowIndex].Cells[10].Text);
            Session.Add("fecha", GVEnviadosSemana.Rows[rowIndex].Cells[6].Text);
            switch (tipo)
            {
                case "imprimir":
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Control/repFaceFenologica.aspx?ci=" + GVEnviadosSemana.Rows[rowIndex].Cells[5].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                break;
            }
            GVEnviadosSemana.Columns[8].Visible = false;
            GVEnviadosSemana.Columns[9].Visible = false;
            GVEnviadosSemana.Columns[10].Visible = false;
            Desplegar_GRILLA_ENVIADOS();
        }
        protected void GVEnviadosSemana_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();

                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 5;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Periodo</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                GVEnviadosSemana.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }

    }
}