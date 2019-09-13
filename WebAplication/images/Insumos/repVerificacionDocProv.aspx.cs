using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;

namespace WebAplication.Insumos
{
    public partial class repVerificacionDocProv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LblIdIsnProv.Text = Session["IdInsProv"].ToString();
                Desplegar_DOC_PROV_PRESENT();
            }
        }
        #region OBTENER LA LISTA DE LAS TABLAS INSCRIPCION_PROVEEDOR => DOCUMENTO_PRESENTADO => DOCUMENTO_SOLICITADO
        protected void Desplegar_DOC_PROV_PRESENT()
        {
            DB_AP_Registro_Org ListProv = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = ListProv.DB_Reporte_DOC_PROV_PRESENT(Convert.ToInt32(LblIdIsnProv.Text));
            LblProveedor.Text = dt.Rows[0][0].ToString();
            LblPrograma.Text = dt.Rows[0][2].ToString();
            LblInsumo.Text = dt.Rows[0][1].ToString();
            GVDocVerfProv.DataSource = ListProv.DB_Reporte_DOC_PROV_PRESENT(Convert.ToInt32(LblIdIsnProv.Text));
            GVDocVerfProv.DataBind();
        }
        #endregion

        protected void GVDocVerfProv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Boolean valor = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Estado").ToString());
                //string valor2 = DataBinder.Eval(e.Row.DataItem, "EstCamp").ToString();
                if (valor == true)
                {
                    e.Row.Cells[1].Text = "PRESENTO";
                }
                if (valor == false)
                {
                    e.Row.Cells[1].Text = "NO PRESENTO";
                }
            }
        }
    }
}