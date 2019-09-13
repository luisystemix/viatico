using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Threading;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;

namespace WebAplication.Responsable
{
    public partial class frmListaProductorPre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string urrl = Request.QueryString["data"];
                    TSHAK.Components.SecureQueryString querystringSeguro;
                    querystringSeguro = new TSHAK.Components.SecureQueryString(new Byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 8 }, urrl);
                    ////parametros de otra formulario
                    this.HiddenFieldInsOrg.Value = Convert.ToString(querystringSeguro["IdInsOrg"]);
                    ((Label)contEncabezado21.FindControl("LblId_Org")).Text = this.HiddenFieldInsOrg.Value;
                    Desplegar_ENCABEZADO();
                    Desplegar_PRODUCTOR_INS();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCION QUE CAPURA LOS VALORES DEL ENCABEZADO
        protected void Desplegar_ENCABEZADO()
        {
            DB_AP_Registro_Org vro = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = vro.DB_Desplegar_ENCABEZADO_ORG(Convert.ToInt32(((Label)contEncabezado21.FindControl("LblId_Org")).Text));
            ((Label)contEncabezado21.FindControl("LblId_Org")).Text = dt.Rows[0][0].ToString();
            ((Label)contEncabezado21.FindControl("LblOrganizacion")).Text = dt.Rows[0][1].ToString();
            ((Label)contEncabezado21.FindControl("LblPrograma")).Text = dt.Rows[0][9].ToString();
            ((Label)contEncabezado21.FindControl("LblCampanhia")).Text = dt.Rows[0][6].ToString();
            ((Label)contEncabezado21.FindControl("LbLIdCamp")).Text = dt.Rows[0][5].ToString();
        }
        #endregion
        #region FUNCION PARA DESPLEGAR LA LISTA DE ORGANIZACIONES EN LA GRILLA
        protected void Desplegar_PRODUCTOR_INS()
        {
            DB_AP_Registro_Org ListProd = new DB_AP_Registro_Org();
            GVProdIns.DataSource = ListProd.DB_Desplegar_PRODUCTOR_INS(Convert.ToInt32(((Label)contEncabezado21.FindControl("LblId_Org")).Text), TextBoxBuscarOrg.Text);
            GVProdIns.DataBind();
        }
        #endregion
        #region FUNCIONES DE LA GRILLA

        protected void GVProdIns_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            switch (tipo)
            {
                case "Historial":
                StringBuilder sbMensaje = new StringBuilder();
                sbMensaje.Append("<script type='text/javascript'>");
                sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=800,height=400,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Responsable/frmHistorial.aspx?ci=" + GVProdIns.Rows[rowIndex].Cells[1].Text);
                sbMensaje.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                break;
            }
        }
        protected void GVProdIns_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((TextBox)e.Row.FindControl("TxtObser")).Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Observacion"));
            }
        }
        #endregion
        protected void ImgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Desplegar_PRODUCTOR_INS();
        }

        protected void ImgPrintListOfi_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("IdInsOrg", ((Label)contEncabezado21.FindControl("LblId_Org")).Text);

            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=800,height=400,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Responsable/repListaPreliminar.aspx?ci=" + ((Label)contEncabezado21.FindControl("LblId_Org")).Text);
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
            //Response.Redirect("repListaPreliminar.aspx");
        }
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            DB_AP_Productor InsProd = new DB_AP_Productor();
            AP_Productor p = new AP_Productor();
            foreach (GridViewRow dgi in GVProdIns.Rows)
            {
                TextBox tx = (TextBox)dgi.Cells[8].Controls[1];
                GVProdIns.Columns[7].Visible = true;
                Desplegar_PRODUCTOR_INS();
                p.Id_Productor = GVProdIns.Rows[dgi.RowIndex].Cells[7].Text;
                p.Observacion = tx.Text;
                InsProd.DB_Modificar_OBSERVACION(p);
            }
            GVProdIns.Columns[7].Visible = true;
            Desplegar_PRODUCTOR_INS();
            //Session.Add("IdInsOrg", ((Label)contEncabezado21.FindControl("LblId_Org")).Text);
            //Response.Redirect("repListaPreliminar.aspx");
        }
    }
}