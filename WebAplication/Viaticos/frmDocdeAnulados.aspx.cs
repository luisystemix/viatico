using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using DataEntity.DE_Viaticos;
using DataBusiness.DB_Viaticos;
using DataEntity.DE_General;
using DataBusiness.DB_General;
using DataBusiness.DB_Registro;

namespace WebAplication.Viaticos
{
    public partial class frmDocdeAnulados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Desplegar_REGIONAL();
                    Desplegar_SOLICITUD_USUARIO();
                    //Desplegar_SOLICITUD_OBSERBADOS();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCIONES PARA DESPLEGAR REGIONALES EN EL COMBO
        protected void Desplegar_REGIONAL()
        {
            DB_Regional r = new DB_Regional();
            List<Regional> listaR = r.DB_Desplegar_REGIONAL();
            DDLRegional.DataSource = listaR;
            DDLRegional.DataValueField = "Id_Regional";
            DDLRegional.DataTextField = "Nombre";
            DDLRegional.DataBind();
            DDLRegional.Items.Insert(0, new ListItem("Seleccione la Regional", "0", true));
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Desplegar_SOLICITUD_USUARIO()
        {
            DB_VT_Solicitud lista = new DB_VT_Solicitud();
            GVListSolicitud.DataSource = lista.DB_Desplegar_SOLICITUD_USUARIO(TxtBuscar.Text, DDLRegional.SelectedItem.Text, "ANULADO");
            GVListSolicitud.DataBind();
        }
        #endregion

        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_SOLICITUD_USUARIO();
            TxtBuscar.Text = string.Empty;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Desplegar_SOLICITUD_USUARIO();
        }
    }
}