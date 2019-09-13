using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;
using DataBusiness.DB_General;
using DataEntity.DE_Extensiones;
using DataBusiness.DB_Extensiones;

namespace WebAplication.Extensiones
{
    public partial class repProdSeleccionados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUser.Text = Session["IdUser"].ToString();
                    LblPrograma.Text = Session["Prog"].ToString();
                    Desplegar_USUARIO();
                    Llenar_GVDESIGNADO();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        private void Llenar_GVDESIGNADO()
        {
            DB_EXT_DesignacionProd ListDes = new DB_EXT_DesignacionProd();
            GVDesignado.DataSource = ListDes.DB_Desplegar_DESIGNACION_PROD(LblIdUser.Text, 0, 0, LblPrograma.Text, 0, "LISTDESIGNADOS");
            GVDesignado.DataBind();
        }
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Desplegar_USUARIO()
        {
            DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = Usuario.DB_Desplegar_USUARIO(LblIdUser.Text);
            LblIdReg.Text = dt.Rows[0][4].ToString();
        }
        #endregion
    }
}