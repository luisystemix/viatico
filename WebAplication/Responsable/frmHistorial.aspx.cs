using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using DataBusiness.DB_Registro;

namespace WebAplication.Responsable
{
    public partial class frmHistorial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["ci"] != null)
                    {
                        LblCi.Text = Request.QueryString["ci"];
                        Desplegar_HISTORIAL();
                    }
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCION PARA DESPLEGAR LA LISTA DE ORGANIZACIONES EN LA GRILLA
        protected void Desplegar_HISTORIAL()
        {
            DataTable dt = new DataTable(); 
            DB_AP_Registro_Prod List = new DB_AP_Registro_Prod();
            //dt = List.DB_Desplegar_HISTORIAL(LblCi.Text, "DEUDA");
            //if (dt.Rows.Count!=0)
            //{
                //LblProductor.Text = dt.Rows[0][12].ToString() + " " + dt.Rows[0][13].ToString() + " " + dt.Rows[0][14].ToString();
                //LblExt.Text = dt.Rows[0][16].ToString();
            GVDeuda.DataSource = List.DB_Desplegar_HISTORIAL(LblCi.Text,"DEUDA");            
            GVDeuda.DataBind();
            GVDependencia.DataSource = List.DB_Desplegar_HISTORIAL(LblCi.Text, "DEPENDENCIA");
            GVDependencia.DataBind();
            GVParticipacion.DataSource = List.DB_Desplegar_HISTORIAL(LblCi.Text, "PARTICIPACION");
            GVParticipacion.DataBind();
            //}

        }
        #endregion
    }
}