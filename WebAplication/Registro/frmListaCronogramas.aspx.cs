using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;

namespace WebAplication.Registro
{
    public partial class frmListaCronogramas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUser.Text = Session["IdUser"].ToString();
                    Desplegar_USUARIO();
                    Desplegar_LISTA_CRONOGRAMAS();
                    Seleccionar_CAMPANHIA_ID();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS
        protected void Llenar_DDLCAMPANHIA(string region)
        {
            DB_AP_Campanhia camp = new DB_AP_Campanhia();
            DataTable Lista = new DataTable();
            Lista = camp.DB_Desplegar_CAMPANHIA_REGION(region);
            DDLCamp.DataSource = Lista;
            DDLCamp.DataValueField = "Id_Campanhia";
            DDLCamp.DataTextField = "Nombre";
            DDLCamp.DataBind();
        }
        #endregion
        #region FUNCION PARA DESPLEGAR LA LISTDE LOS CRONOGRAMS
        protected void Desplegar_LISTA_CRONOGRAMAS()
        {
            DB_AP_CronogramaCamp ListCamp = new DB_AP_CronogramaCamp();
            GVCronogramas.DataSource = ListCamp.DB_Desplegar_LISTA_CRONOGRAMAS(Convert.ToInt32(LblIdReg.Text), "LISTA_CRONOGRAMAS");
            GVCronogramas.DataBind();
        }
        #endregion
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Desplegar_USUARIO()
        {
            DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = Usuario.DB_Desplegar_USUARIO(Session["IdUser"].ToString());
            LblRegional.Text = dt.Rows[0][5].ToString();
            LblIdReg.Text = dt.Rows[0][4].ToString();
            Llenar_DDLCAMPANHIA(dt.Rows[0][10].ToString());
        }
        #endregion
        #region FUNCION PARA DESPLEGAR DATOS DE LA CAMPAÑA POR EL ID
        protected void Seleccionar_CAMPANHIA_ID()
        {
            DB_AP_Campanhia cam = new DB_AP_Campanhia();
            AP_Campanhia ca = new AP_Campanhia();
            ca = cam.DB_Buscar_CAMPANHIA(Convert.ToInt32(DDLCamp.SelectedValue));
            LblEstado.Text = ca.Estado;
        }
        #endregion

        protected void LnkCronograma_Click(object sender, EventArgs e)
        {
            if (LblEstado.Text == "INICIADO")
            {
                Session.Add("Prog",DDLProg.SelectedItem.Text);
                Session.Add("IdCamp",DDLCamp.SelectedValue);
                Response.Redirect("frmCronogramaReg.aspx");
            }
            else
            {
                LblMsj.Text = "El cronograma solo se puede registrar cuando la campaña presenta un estado de INICIADO";
            }
        }
        #region FUNCION DEL COMBO
        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Seleccionar_CAMPANHIA_ID();
        }
        #endregion
        protected void GVCronogramas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            StringBuilder sbMensaje = new StringBuilder();
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVCronogramas.Columns[5].Visible = true;
            Desplegar_LISTA_CRONOGRAMAS();
            Session.Add("IdCrono", GVCronogramas.Rows[rowIndex].Cells[5].Text);
            switch (tipo)
            {
                case "Seguimiento":
                Response.Redirect("frmCronogramasRegUpdate.aspx");
                break;
                case "imprimir":
                sbMensaje.Append("<script type='text/javascript'>");
                sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Registro/repCronogramaReg.aspx?ci=" + GVCronogramas.Rows[rowIndex].Cells[5].Text);
                sbMensaje.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                break;
            }
        }

    }
}