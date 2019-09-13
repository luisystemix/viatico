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
using DataEntity.DE_General;
using DataBusiness.DB_General;

namespace WebAplication.AnalistasOFC
{
    public partial class repEstadoFenologico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                if (!IsPostBack)
                {
                    LblPrograma.Text = Session["Programa"].ToString();
                    LblIdCamp.Text = Session["IdCamp"].ToString();
                    LblIdReg.Text = Session["IdReg"].ToString();
                    Llenar_GRILLA();
                    //Graficar();
                }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //} 
        }
        protected void Llenar_GRILLA()
        {
            DB_EXT_SegSemanalTotales data = new DB_EXT_SegSemanalTotales();
            GVEnvioSem.DataSource = data.DB_Desplegar_SEG_SEMANAL_TOTAL(Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblIdCamp.Text), LblPrograma.Text, "TOTALES");
            GVEnvioSem.DataBind();
        } 
    }
}