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
    public partial class repCostosProductor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                if (!IsPostBack)
                {
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                    LblIdInsProd.Text = Session["IdProductor"].ToString();
                    Seleccionar_DISTRIBUCION_DETALLE();
                    Mostrar_ENCABEZADO();
                    Datos_Org_ENCABEZADO();
                    SumaGV(GVDesecacion, LblIBs, LblISus);
                    SumaGV(GVPrepSueloSiem, LblIIBs, LblIISus);
                    SumaGV(GVInsumos, LblIIIBs, LblIIISus);
                    SumaGV(GVServisCultural, LblIVBs, LblIVSus);
                    SumaGV(GVCosechaTrans, LblVBs, LblVSus);
                    Suma_TOTAL(); 
                }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        private void SumaGV(GridView GV, Label Lbs, Label Lsus)
        {
            decimal Bs=0;
            decimal Sus = 0;
            for (int i = 0; i < GV.Rows.Count; i++)
            {
                Bs = Bs + decimal.Parse(GV.Rows[i].Cells[7].Text);
                Sus = Sus + decimal.Parse(GV.Rows[i].Cells[8].Text);
            }
            Lbs.Text = Bs.ToString();
            Lsus.Text = Sus.ToString();
        }
        private void Suma_TOTAL() 
        {
            LblTotBs.Text = (Convert.ToDecimal(LblIBs.Text) + Convert.ToDecimal(LblIIBs.Text) + Convert.ToDecimal(LblIIIBs.Text) + Convert.ToDecimal(LblIVBs.Text) + Convert.ToDecimal(LblVBs.Text)).ToString();
            LblTotSus.Text = (Convert.ToDecimal(LblISus.Text) + Convert.ToDecimal(LblIISus.Text) + Convert.ToDecimal(LblIIISus.Text) + Convert.ToDecimal(LblIVSus.Text) + Convert.ToDecimal(LblVSus.Text)).ToString();

        }
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Datos_Org_ENCABEZADO()
        {
            DB_AP_Registro_Org d_org = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = d_org.DB_Desplegar_ENCABEZADO_ORG(Convert.ToInt32(LblIdInsOrg.Text));
            LblOrg.Text = dt.Rows[0][2].ToString();
            //LblIdCamp.Text = dt.Rows[0][5].ToString();
            //LblCamp.Text = dt.Rows[0][6].ToString();
            //LblProg.Text = dt.Rows[0][9].ToString();
            //LblIdReg.Text = dt.Rows[0][7].ToString();
            ////LblSup.Text = dt.Rows[0][12].ToString();
            DB_AP_Productor p = new DB_AP_Productor();
            dt = p.DB_Seleccionar_ENCABEZADO_PROD(LblIdInsProd.Text, "DATS_PROD");
            LblProd.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString();
            LblSupProd.Text = dt.Rows[0][13].ToString();
        }
        #endregion


        private void Mostrar_ENCABEZADO()
        {
            DB_EXT_Seguimiento disSem = new DB_EXT_Seguimiento();
            DataTable dt = new DataTable();
            dt = disSem.DB_Reporte_DISTRIBUCION_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), "SEMILLA", "REPDIRSTRIBORG");
            LblCamp.Text = dt.Rows[0][3].ToString();
            LblRegional.Text = dt.Rows[0][2].ToString();
        }
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Seleccionar_DISTRIBUCION_DETALLE()
        {
            DataTable dt = new DataTable();
            DB_EXT_Costos cost = new DB_EXT_Costos();
            GVDesecacion.DataSource = cost.DB_Seleccionar_COSTOS(1, LblIdInsProd.Text, "REP_ETAPA_DETALLE_PRODUCTOR");
            GVDesecacion.DataBind();
            GVPrepSueloSiem.DataSource = cost.DB_Seleccionar_COSTOS(2, LblIdInsProd.Text, "REP_ETAPA_DETALLE_PRODUCTOR");
            GVPrepSueloSiem.DataBind();
            GVInsumos.DataSource = cost.DB_Seleccionar_COSTOS(3, LblIdInsProd.Text, "REP_ETAPA_DETALLE_PRODUCTOR");
            GVInsumos.DataBind();
            GVServisCultural.DataSource = cost.DB_Seleccionar_COSTOS(4, LblIdInsProd.Text, "REP_ETAPA_DETALLE_PRODUCTOR");
            GVServisCultural.DataBind();
            GVCosechaTrans.DataSource = cost.DB_Seleccionar_COSTOS(5, LblIdInsProd.Text, "REP_ETAPA_DETALLE_PRODUCTOR");
            GVCosechaTrans.DataBind();
        }
        #endregion
    }
}