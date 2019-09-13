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
    public partial class repCostos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                if (!IsPostBack)
                {
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                    Seleccionar_DISTRIBUCION_DETALLE();
                    Mostrar_ENCABEZADO();
                    SumaGV(GVDesecacion, LblIBs, LblISus);
                    SumaGV(GVPrepSueloSiem, LblIIBs, LblIISus);
                    SumaGV(GVInsumos, LblIIIBs, LblIIISus);
                    SumaGV(GVServisCultural, LblIVBs, LblIVSus);
                    SumaGV(GVCosechaTrans, LblVBs, LblVSus);
                    Superficie_PROMEDIO();
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
            decimal Bs = 0;
            decimal Sus = 0;
            for (int i = 0; i < GV.Rows.Count; i++)
            {
                Bs = Bs + decimal.Parse(GV.Rows[i].Cells[4].Text);
                Sus = Sus + decimal.Parse(GV.Rows[i].Cells[5].Text);
            }
            Lbs.Text = Bs.ToString();
            Lsus.Text = Sus.ToString();
        }
        private void Suma_TOTAL()
        {
            LblTotBs.Text = (Convert.ToDecimal(LblIBs.Text) + Convert.ToDecimal(LblIIBs.Text) + Convert.ToDecimal(LblIIIBs.Text) + Convert.ToDecimal(LblIVBs.Text) + Convert.ToDecimal(LblVBs.Text)).ToString();
            LblTotSus.Text = (Convert.ToDecimal(LblISus.Text) + Convert.ToDecimal(LblIISus.Text) + Convert.ToDecimal(LblIIISus.Text) + Convert.ToDecimal(LblIVSus.Text) + Convert.ToDecimal(LblVSus.Text)).ToString();

        }
        private void Superficie_PROMEDIO()
        {
            DB_EXT_Costos c=new DB_EXT_Costos();
            DataTable dt = new DataTable();
            dt = c.DB_Reporte_COSTOS_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), "", 0, 0, 0, "PROMEDIO_SUP_COSTOS");
            LblSupPromedio.Text=dt.Rows[0][0].ToString();
        }
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
            DB_EXT_Costos cost = new DB_EXT_Costos();
            GVDesecacion.DataSource = cost.DB_Reporte_COSTOS_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), "", 1, 0, 0, "REP_COSTOS_ESTADOS");
            GVDesecacion.DataBind();
            GVPrepSueloSiem.DataSource = cost.DB_Reporte_COSTOS_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), "", 2, 0, 0, "REP_COSTOS_ESTADOS");
            GVPrepSueloSiem.DataBind();
            GVInsumos.DataSource = cost.DB_Reporte_COSTOS_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), "", 3, 0, 0, "REP_COSTOS_ESTADOS");
            GVInsumos.DataBind();
            GVServisCultural.DataSource = cost.DB_Reporte_COSTOS_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), "", 4, 0, 0, "REP_COSTOS_ESTADOS");
            GVServisCultural.DataBind();
            GVCosechaTrans.DataSource = cost.DB_Reporte_COSTOS_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), "", 5, 0, 0, "REP_COSTOS_ESTADOS");
            GVCosechaTrans.DataBind();
        }
        #endregion

        protected void GVPrepSueloSiem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = new DataTable();
            DB_EXT_Costos c = new DB_EXT_Costos();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int etapa = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Etapa_Cultivo"));
                int insumo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Insumo"));
                int tipo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Tipo_Recurso"));
                string valor = "";
                switch (insumo)
                {
                    case 1:
                    valor = "SEMILLA";
                    break;
                    case 2:
                    valor = "AGROQUIMICO";
                    break;
                    case 3:
                    valor = "COMBUSTIBLE";
                    break;
                    case 4:
                    valor = "MAQUINARIA";
                    break;
                    case 5:
                    valor = "MANO DE OBRA";
                    break;
                    case 6:
                    valor = "TRACCIÓN  ANIMAL";
                    break;
                }
                dt = c.DB_Seleccionar_COSTO_TIPO_RECURSO(tipo);
                e.Row.Cells[3].Text = valor+" - ("+dt.Rows[0][2].ToString()+")";
                dt = c.DB_Reporte_COSTOS_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), "", etapa, insumo, tipo, "SUMA_POR_TIPORECURSO");
                e.Row.Cells[4].Text = dt.Rows[0][0].ToString();
                e.Row.Cells[5].Text = dt.Rows[0][1].ToString();
            }
        }

        protected void GVDesecacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = new DataTable();
            DB_EXT_Costos c = new DB_EXT_Costos();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int etapa = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Etapa_Cultivo"));
                int insumo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Insumo"));
                int tipo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Tipo_Recurso"));
                string valor = "";
                switch (insumo)
                {
                    case 1:
                        valor = "SEMILLA";
                        break;
                    case 2:
                        valor = "AGROQUIMICO";
                        break;
                    case 3:
                        valor = "COMBUSTIBLE";
                        break;
                    case 4:
                        valor = "MAQUINARIA";
                        break;
                    case 5:
                        valor = "MANO DE OBRA";
                        break;
                    case 6:
                        valor = "TRACCIÓN  ANIMAL";
                        break;
                }
                dt = c.DB_Seleccionar_COSTO_TIPO_RECURSO(tipo);
                e.Row.Cells[3].Text = valor + " - (" + dt.Rows[0][2].ToString() + ")";
                dt = c.DB_Reporte_COSTOS_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), "", etapa, insumo, tipo, "SUMA_POR_TIPORECURSO");
                e.Row.Cells[4].Text = dt.Rows[0][0].ToString();
                e.Row.Cells[5].Text = dt.Rows[0][1].ToString();
            }
        }

        protected void GVInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = new DataTable();
            DB_EXT_Costos c = new DB_EXT_Costos();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int etapa = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Etapa_Cultivo"));
                int insumo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Insumo"));
                int tipo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Tipo_Recurso"));
                string valor = "";
                switch (insumo)
                {
                    case 1:
                        valor = "SEMILLA";
                        break;
                    case 2:
                        valor = "AGROQUIMICO";
                        break;
                    case 3:
                        valor = "COMBUSTIBLE";
                        break;
                    case 4:
                        valor = "MAQUINARIA";
                        break;
                    case 5:
                        valor = "MANO DE OBRA";
                        break;
                    case 6:
                        valor = "TRACCIÓN  ANIMAL";
                        break;
                }
                dt = c.DB_Seleccionar_COSTO_TIPO_RECURSO(tipo);
                e.Row.Cells[3].Text = valor + " - (" + dt.Rows[0][2].ToString() + ")";
                dt = c.DB_Reporte_COSTOS_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), "", etapa, insumo, tipo, "SUMA_POR_TIPORECURSO");
                e.Row.Cells[4].Text = dt.Rows[0][0].ToString();
                e.Row.Cells[5].Text = dt.Rows[0][1].ToString();
            }
        }

        protected void GVServisCultural_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = new DataTable();
            DB_EXT_Costos c = new DB_EXT_Costos();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int etapa = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Etapa_Cultivo"));
                int insumo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Insumo"));
                int tipo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Tipo_Recurso"));
                string valor = "";
                switch (insumo)
                {
                    case 1:
                        valor = "SEMILLA";
                        break;
                    case 2:
                        valor = "AGROQUIMICO";
                        break;
                    case 3:
                        valor = "COMBUSTIBLE";
                        break;
                    case 4:
                        valor = "MAQUINARIA";
                        break;
                    case 5:
                        valor = "MANO DE OBRA";
                        break;
                    case 6:
                        valor = "TRACCIÓN  ANIMAL";
                        break;
                }
                dt = c.DB_Seleccionar_COSTO_TIPO_RECURSO(tipo);
                e.Row.Cells[3].Text = valor + " - (" + dt.Rows[0][2].ToString() + ")";
                dt = c.DB_Reporte_COSTOS_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), "", etapa, insumo, tipo, "SUMA_POR_TIPORECURSO");
                e.Row.Cells[4].Text = dt.Rows[0][0].ToString();
                e.Row.Cells[5].Text = dt.Rows[0][1].ToString();
            }
        }

        protected void GVCosechaTrans_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = new DataTable();
            DB_EXT_Costos c = new DB_EXT_Costos();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int etapa = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Etapa_Cultivo"));
                int insumo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Insumo"));
                int tipo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Tipo_Recurso"));
                string valor = "";
                switch (insumo)
                {
                    case 1:
                        valor = "SEMILLA";
                        break;
                    case 2:
                        valor = "AGROQUIMICO";
                        break;
                    case 3:
                        valor = "COMBUSTIBLE";
                        break;
                    case 4:
                        valor = "MAQUINARIA";
                        break;
                    case 5:
                        valor = "MANO DE OBRA";
                        break;
                    case 6:
                        valor = "TRACCIÓN  ANIMAL";
                        break;
                }
                dt = c.DB_Seleccionar_COSTO_TIPO_RECURSO(tipo);
                e.Row.Cells[3].Text = valor + " - (" + dt.Rows[0][2].ToString() + ")";
                dt = c.DB_Reporte_COSTOS_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), "", etapa, insumo, tipo, "SUMA_POR_TIPORECURSO");
                e.Row.Cells[4].Text = dt.Rows[0][0].ToString();
                e.Row.Cells[5].Text = dt.Rows[0][1].ToString();
            }
        }
    }
}