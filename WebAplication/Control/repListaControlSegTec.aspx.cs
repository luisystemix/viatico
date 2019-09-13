using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DataBusiness.DB_Registro;
using DataBusiness.DB_General;
using DataEntity.DE_General;
using DataEntity.DE_Registro;
using DataBusiness.DB_Extensiones;
using DataBusiness.DB_Control;

namespace WebAplication.Control
{
    public partial class repListaControlSegTec : System.Web.UI.Page
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
                LblProg.Text = LblPrograma.Text;
                Desplegar_SEGUIMIENTO_TECNICOS();
            }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        #region OBTENER LA LISTA DE LAS CAMPOAÑAS APOYADAS
        protected void Desplegar_SEGUIMIENTO_TECNICOS()
        {
            DB_EXT_Seguimiento segt = new DB_EXT_Seguimiento();
            GVSegTec.DataSource = segt.DB_Desplegar_SEGUIMIENTO_A_TECNICOS(LblIdUsuario.Text, LblPrograma.Text, Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), "SEG_TECNICOS");
            GVSegTec.DataBind();
        }
        #endregion
        protected void GVSegTec_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DB_EXT_Reportes rep = new DB_EXT_Reportes();
            DataTable dt = new DataTable();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int idSeg = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Seguimiento"));
                string etapa = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Etapa"));
                //((Label)e.Row.FindControl("LblNumBolet")).Text = Seleccionar_NUM_BOLETA(idSeg, etapa);
                int valor = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Tipo_Seguimiento"));
                if (valor == 0)
                {
                    e.Row.Cells[8].Text = "En Campo";
                }
                else
                {
                    e.Row.Cells[8].Text = "Por Monitoreo";
                }
            }
        }
    }
}