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
using DataBusiness.DB_General;

namespace WebAplication.Control
{
    public partial class frmFenologiaRegSem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            if (!IsPostBack)
            {
                LblIdUsuario.Text = Session["IdUser"].ToString();
                //Datos_ENCABEZADO();
                //Llenar_DDLCAMPANHIA();
                //LblIdCamp.Text = Session["IdCamp"].ToString();
                //Desplegar_GRILLA();
                Desplegar_GRILLA_ENVIADOS();
            }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        //#region FUNCIONES PARA CARGAR LOS DATOS DE LA ORGANIZACION
        //private void Datos_ENCABEZADO()
        //{
        //    DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
        //    DataTable dt = new DataTable();
        //    dt = Usuario.DB_Desplegar_USUARIO(LblIdUsuario.Text);
        //    LblRegional.Text = dt.Rows[0][5].ToString();
        //    LblIdReg.Text = dt.Rows[0][4].ToString();
        //    LblRegion.Text = dt.Rows[0][10].ToString();
        //}
        //#endregion
        //#region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS
        //private void Llenar_DDLCAMPANHIA()
        //{
        //    DB_AP_Campanhia cam = new DB_AP_Campanhia();
        //    DataTable dt = new DataTable();
        //    dt = cam.DB_Seleccionar_CAMPANHIA_REG_NOFIN(LblRegion.Text);
        //    DDLCamp.DataSource = dt;
        //    DDLCamp.DataValueField = "Id_Campanhia";
        //    DDLCamp.DataTextField = "Nombre";
        //    DDLCamp.DataBind();
        //}
        //#endregion
        private void Desplegar_GRILLA_ENVIADOS()
        {
            DB_EXT_Fenologia fendetalle = new DB_EXT_Fenologia();
            GVEnviadosSemana.DataSource = fendetalle.DB_Seleccionar_ENVIOS_SEMANA_FENOLOGIA("ENVIADO");
            GVEnviadosSemana.DataBind();
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
            Session.Add("IdUser", LblIdUsuario.Text);
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
    }
}