using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;
using DataBusiness.DB_Extensiones;
using DataEntity.DE_Extensiones;
using DataEntity.DE_Registro;

namespace WebAplication.Extensiones
{
    public partial class repDistribAgroQuimOrg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                    Mostrar_ENCABEZADO();
                    Seleccionar_DISTRIBUCION_DETALLE();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        private void Mostrar_ENCABEZADO()
        {
            DB_EXT_Seguimiento disSem = new DB_EXT_Seguimiento();
            DataTable dt = new DataTable();
            dt = disSem.DB_Reporte_DISTRIBUCION_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), "AGROQUIMICO", "REPDIRSTRIBORG");
            LblCamp.Text = dt.Rows[0][3].ToString();
            LblRegional.Text = dt.Rows[0][2].ToString();
            LblProg.Text = dt.Rows[0][5].ToString();
            LblOrg.Text = dt.Rows[0][4].ToString();
            /*******************************************************/
            //dt = disSem.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg.Text), "TRILP01-00012", "DETALLEDISTRIB");
            //List<EXT_SeguimientoDistribDetalle> Lista = disSem.DB_Desplegar_LISTA_DETALLE_DISTRIB(Convert.ToInt32(LblIdInsOrg.Text), "TRILP01-00013", "DETALLEDISTRIB");
            //DataList2.DataSource = Lista;
            //DataList2.DataBind();
        }
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Seleccionar_DISTRIBUCION_DETALLE()
        {
            DB_EXT_Seguimiento disSem = new DB_EXT_Seguimiento();
            GVListDistQuim.DataSource = disSem.DB_Reporte_DISTRIBUCION_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), "AGROQUIMICO", "REPPROD");
            GVListDistQuim.DataBind();
        }
        #endregion

        protected void GVListDistQuim_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DB_EXT_Seguimiento disSem = new DB_EXT_Seguimiento();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LblAux.Text = string.Empty;
                string valor = DataBinder.Eval(e.Row.DataItem, "Id_Productor").ToString();
                LblAux.Text = valor;
                ((DataList)e.Row.FindControl("DTLNumBolet")).DataSource = disSem.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg.Text), LblAux.Text, "AGROQUIMICO", "DETALLEDISTRIB");
                ((DataList)e.Row.FindControl("DTLNumBolet")).DataBind();
                ((DataList)e.Row.FindControl("DTLFechaDistrib")).DataSource = disSem.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg.Text), LblAux.Text, "AGROQUIMICO", "DETALLEDISTRIB");
                ((DataList)e.Row.FindControl("DTLFechaDistrib")).DataBind();
                ((DataList)e.Row.FindControl("DTLProducto")).DataSource = disSem.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg.Text), LblAux.Text, "AGROQUIMICO", "DETALLEDISTRIB");
                ((DataList)e.Row.FindControl("DTLProducto")).DataBind();
                ((DataList)e.Row.FindControl("DTLNomComer")).DataSource = disSem.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg.Text), LblAux.Text, "AGROQUIMICO", "DETALLEDISTRIB");
                ((DataList)e.Row.FindControl("DTLNomComer")).DataBind();
                ((DataList)e.Row.FindControl("DTLFechCaducid")).DataSource = disSem.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg.Text), LblAux.Text, "AGROQUIMICO", "DETALLEDISTRIB");
                ((DataList)e.Row.FindControl("DTLFechCaducid")).DataBind();
                ((DataList)e.Row.FindControl("DTLUnidad")).DataSource = disSem.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg.Text), LblAux.Text, "AGROQUIMICO", "DETALLEDISTRIB");
                ((DataList)e.Row.FindControl("DTLUnidad")).DataBind();
                ((DataList)e.Row.FindControl("DTLCantidad")).DataSource = disSem.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg.Text), LblAux.Text, "AGROQUIMICO", "DETALLEDISTRIB");
                ((DataList)e.Row.FindControl("DTLCantidad")).DataBind();
            }
        }
    }
}