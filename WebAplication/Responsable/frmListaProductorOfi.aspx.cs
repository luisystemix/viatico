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

namespace WebAplication.Responsable
{
    public partial class frmListarProductor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
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
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        #region FUNCION QUE CAPURA LOS VALORES DEL ENCABEZADO
        protected void Desplegar_ENCABEZADO()
        {
            DB_AP_Registro_Org vro = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = vro.DB_Desplegar_ENCABEZADO_ORG(Convert.ToInt32(((Label)contEncabezado21.FindControl("LblId_Org")).Text));
            //((Label)contEncabezado21.FindControl("LblId_Org")).Text = dt.Rows[0][0].ToString();
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
        #region FUNCION DE BUQUEDA DE PRODUCTOR
        protected void ImgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Desplegar_PRODUCTOR_INS();
        }
        #endregion
        #region FUNCIONES DE LA GRILLA
        protected void GVProdIns_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //bool valor = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Estado"));
                string valor = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Estado"));
                if (valor == "APROBADO")
                {
                    ((CheckBox)e.Row.FindControl("CbxEstado")).Checked = true;
                    ((CheckBox)e.Row.FindControl("CbxEstado")).Enabled = false;
                }
                if (valor != "APROBADO")
                {
                    ((CheckBox)e.Row.FindControl("CbxEstado")).Checked = false;
                }
            }
        }
        #endregion
        #region FUNCION PARA REGISTRAR LA INSCRIPCION DE UNA ORGANIZACION
        protected void Modificar_INSCRIP_ORG(int IdInsOrg)
        {
            DB_AP_Organizacion RegInsOrg = new DB_AP_Organizacion();
            AP_InscripcionOrg io = new AP_InscripcionOrg();
            io.Id_InscripcionOrg = IdInsOrg;
            io.Estado = "APROBADO-CART";
            RegInsOrg.DB_Modificar_INSCRIP_ORG(io);
        }
        #endregion  
        #region FUNCION PARA REGISTRAR A LOS PRODUCTORES HABILITADOS
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            DB_AP_Productor InsProd = new DB_AP_Productor();
            AP_Productor p = new AP_Productor();
            GVProdIns.Columns[7].Visible = true;
            foreach (GridViewRow dgi in GVProdIns.Rows)
            {
                Desplegar_PRODUCTOR_INS();
                CheckBox myCheckBox = (CheckBox)dgi.Cells[8].Controls[1];
                if (myCheckBox.Checked != true)
                {
                    p.Id_Productor = GVProdIns.Rows[dgi.RowIndex].Cells[7].Text;
                    p.Estado = "APROBADO";
                    InsProd.DB_Modificar_ESTADO(p);
                }
            }
            GVProdIns.Columns[7].Visible = false;
            Modificar_INSCRIP_ORG(Convert.ToInt32(((Label)contEncabezado21.FindControl("LblId_Org")).Text));
            Desplegar_PRODUCTOR_INS();
        }
        #endregion
        protected void ImgPrintListOfi_Click(object sender, ImageClickEventArgs e)
        {
            //string aux = ((Label)contEncabezado21.FindControl("LblId_Org")).Text;
            //TSHAK.Components.SecureQueryString querystringSeguro1;
            //querystringSeguro1 = new TSHAK.Components.SecureQueryString(new Byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 8 });
            //querystringSeguro1["IdInsOrg"] = aux;
            Session.Add("IdInsOrg", ((Label)contEncabezado21.FindControl("LblId_Org")).Text);
            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=800,height=400,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Responsable/repListaOficial.aspx?ci=" + ((Label)contEncabezado21.FindControl("LblId_Org")).Text);
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
            //Response.Redirect("repListaOficial.aspx");
        }
    }
}