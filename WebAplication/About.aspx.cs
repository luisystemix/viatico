using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataEntity.DE_Viaticos;
using DataBusiness.DB_Viaticos;
using DataEntity.DE_General;
using DataBusiness.DB_General;
using DataBusiness.DB_Registro;

//using DataBusiness.B_Rol;

namespace WebAplication
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (!IsPostBack)
            {
                if (Session["IdUser"] != null)
                {
                    // EXISTE  EL ID USUARIO .. ej: LQD-6002257
                    // PARA SER USADO EN LA APLICACION
                    //Desplegar_DEUDORES_INFORME();
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }                
            }
        }

        #region FUNCION CALCULAR DEUDORES DE INFORME
        protected void Desplegar_DEUDORES_INFORME()
        {
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            VT_Observacion obs = new VT_Observacion();
            DataTable dt = new DataTable();
            DataTable dts = new DataTable(); 
            dt = sol.DB_Desplegar_SOLICITUD_USUARIO("0", "PROCESADO", "VERINFORME");
            int num = 0;
            obs.Observacion = "PASO DE LA FECHA LIMITE DE ENTREGA DE INFORME";
            obs.Tipo = "Solicitud";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dts = sol.DB_Reporte_SOLICITUD_US(dt.Rows[i][0].ToString(), "DIAS_SIN_INFORME");
                int aux = Convert.ToInt32(dts.Rows[0][0].ToString());
                if (aux > 8 && dt.Rows[i][6].ToString() == "PROCESADO")
                {

                    sol.DB_Cambiar_ESTADO(dt.Rows[0][0].ToString(), "OBSERVADO");
                    obs.Id_Solicitud = dt.Rows[0][0].ToString();
                    sol.DB_Registrar_OBSERVACION_SOLICITUD(obs);
                }
            }
        }
        #endregion
    }
}
