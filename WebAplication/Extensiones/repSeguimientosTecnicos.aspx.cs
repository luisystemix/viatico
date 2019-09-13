using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;
using DataBusiness.DB_Extensiones;
using DataBusiness.DB_General;

namespace WebAplication.Extensiones
{
    public partial class repSeguimientosTecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblNum.Text = Session["IdSeguimiento"].ToString();
                    LblEtapa.Text = Session["Etapa"].ToString();

                    Datos_SEGUIMIENTO_ENCABEZADO();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Datos_SEGUIMIENTO_ENCABEZADO()
        {
            DB_EXT_Seguimiento Seg = new DB_EXT_Seguimiento();
            DataTable dt = new DataTable();
            dt = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "ENCABEZADO");
            LblProductor.Text = dt.Rows[0][0].ToString();
            LblCedula.Text = dt.Rows[0][1].ToString();
            LblOrg.Text = dt.Rows[0][2].ToString();
            LblComunidad.Text = dt.Rows[0][4].ToString();
            LblMunicipio.Text = dt.Rows[0][5].ToString();
            LblProvincia.Text = dt.Rows[0][6].ToString();
            LblDep.Text = dt.Rows[0][7].ToString();
            LblPrograma.Text = dt.Rows[0][8].ToString();
            LblRegional.Text = dt.Rows[0][9].ToString();
            LblCamp.Text = dt.Rows[0][10].ToString();
            LblIdUser.Text = dt.Rows[0][11].ToString();
            DB_Usuario us = new DB_Usuario();
            dt = us.DB_Desplegar_USUARIO(0, LblIdUser.Text, "USUARIO");
            LblTecnico.Text = dt.Rows[0][10].ToString();
            switch(LblEtapa.Text)
            {
                case "VERIFICACION_PARCELA":
                    Panel1.Visible = true;
                    GVCoordenadas.DataSource = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "COORDENADAS");
                    GVCoordenadas.DataBind();
                    dt = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "COORDENADAS");
                    LblFechaSeg.Text = dt.Rows[0][8].ToString();
                    LblHoraSeg.Text = dt.Rows[0][9].ToString();
                    LblObsParcela.Text = dt.Rows[0][11].ToString();
                    LblRecomParcela.Text = dt.Rows[0][12].ToString();
                    break;
                case "VERIFICACION_SIEMBRA":
                    Panel2.Visible = true;
                    GVSiembra.DataSource = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "SIEMBRA");
                    GVSiembra.DataBind();
                    dt = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "SIEMBRA");
                    LblFechaSeg.Text = dt.Rows[0][9].ToString();
                    LblHoraSeg.Text = dt.Rows[0][10].ToString();
                    LblObsParcela0.Text = dt.Rows[0][12].ToString();
                    LblRecomParcela0.Text = dt.Rows[0][13].ToString();
                    break;
                case "VERIFICACION_CULTIVO":
                    Panel3.Visible = true;
                    GVCultivo.DataSource = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "CULTIVO");
                    GVCultivo.DataBind();
                    dt = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "CULTIVO");
                    LblFechaSeg.Text = dt.Rows[0][9].ToString();
                    LblHoraSeg.Text = dt.Rows[0][10].ToString();
                    LblObsParcela1.Text = dt.Rows[0][12].ToString();
                    LblRecomParcela1.Text = dt.Rows[0][13].ToString();
                    GVAdversidad.DataSource = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "ADVERSIDAD");
                    GVAdversidad.DataBind();
                    break;
                case "VERIFICACION_COSECHA":
                    Panel4.Visible = true;
                    GVCosecha.DataSource = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "COSECHA");
                    GVCosecha.DataBind();
                    dt = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "COSECHA");
                    LblFechaSeg.Text = dt.Rows[0][9].ToString();
                    LblHoraSeg.Text = dt.Rows[0][10].ToString();
                    LblObsParcela1.Text = dt.Rows[0][12].ToString();
                    LblRecomParcela1.Text = dt.Rows[0][13].ToString();
                    //GVAdversidad.DataSource = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "ADVERSIDAD");
                    //GVAdversidad.DataBind();
                    break;
            }
        }
        #endregion
    }
}