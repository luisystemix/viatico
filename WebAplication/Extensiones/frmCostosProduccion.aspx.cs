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

namespace WebAplication.Extensiones
{
    public partial class frmCostosProduccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    LblIdInsProd.Text = Session["IdInsProd"].ToString();
                    LblEtapa.Text = "COSTOS";
                    Datos_Org_ENCABEZADO();
                    Verificar_COSTO();
                    Cargar_COMBO_PRODUCTO();
                    Cargar_COMBO_ITEM();
                    /*************************************/
                    DataTable dtListaPartida = new DataTable();
                    dtListaPartida.Columns.AddRange(new DataColumn[14] { new DataColumn("valor1"), new DataColumn("valor2"), new DataColumn("valor3"), new DataColumn("valor4"), new DataColumn("valor5"), new DataColumn("valor6"), new DataColumn("valor7"), new DataColumn("valor8"), new DataColumn("valor9"), new DataColumn("valor10"), new DataColumn("valor11"), new DataColumn("valor12"), new DataColumn("valor13"), new DataColumn("valor14") });
                    GVCostos.DataSource = dtListaPartida;
                    GVCostos.DataBind();
                    Session["datos"] = dtListaPartida;
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCION VERIFICA EXIXTENCIA DEL COSTO
        protected void Verificar_COSTO()
        {
            DB_EXT_Costos c = new DB_EXT_Costos();
            DataTable dt = new DataTable();
            dt = c.DB_Seleccionar_COSTOS(0, LblIdInsProd.Text, "PORP_ROD");
            if (dt.Rows.Count > 0)
            {
                DDLTipoSiembra.Items.Insert(0, new ListItem(dt.Rows[0][1].ToString(), dt.Rows[0][1].ToString(), true));
                DDLTipoSiembra.Enabled = false;
            }
        }
        #endregion

        #region FUNCION DE LOS COMBOS
        protected void Cargar_COMBO_PRODUCTO()
        {
            DB_INS_Insumos ins = new DB_INS_Insumos();
            DataTable dt = new DataTable();
            dt = ins.DB_Seleccionar_TIPO_INSUMOS(0, 0, Convert.ToInt32(DDLInsumo.SelectedValue), "INSUMO");
            DDLProducto.DataSource = dt;
            DDLProducto.DataValueField = "Id_Tipo_Insumo";
            DDLProducto.DataTextField = "Tipo_Insumo";
            DDLProducto.DataBind();
        }
        protected void Cargar_COMBO_ITEM()
        {
            DB_INS_Insumos ins = new DB_INS_Insumos();
            DataTable dt = new DataTable();
            dt = ins.DB_Seleccionar_TIPO_INSUMOS(Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(DDLProducto.SelectedValue), Convert.ToInt32(DDLInsumo.SelectedValue), "LISTA_INSUMO");
            DDLItemProd.DataSource = dt;
            if(dt.Rows.Count > 0)
            {
                DDLItemProd.DataValueField = "Nombre_Insumo";
                DDLItemProd.DataTextField = "Nombre_Insumo";
                DDLItemProd.DataBind();
                TxtItemProd.Text = DDLItemProd.SelectedItem.Text;
                TxtItemProd.Visible = false;
                LnkOtros.Visible = true;
            }
            else
            {
                LnkOtros.Visible = false;
                TxtItemProd.Text = string.Empty;
                TxtItemProd.Visible = true;
                DDLItemProd.Visible = false;
            }
        }
        protected void DDLInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_COMBO_PRODUCTO();
            Cargar_COMBO_ITEM();
        }
        #endregion

        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Datos_Org_ENCABEZADO()
        {
            DB_AP_Registro_Org d_org = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = d_org.DB_Desplegar_ENCABEZADO_ORG(Convert.ToInt32(LblIdInsOrg.Text));
            LblOrg.Text = dt.Rows[0][2].ToString();
            LblIdCamp.Text = dt.Rows[0][5].ToString();
            LblCamp.Text = dt.Rows[0][6].ToString();
            LblProg.Text = dt.Rows[0][9].ToString();
            LblIdReg.Text = dt.Rows[0][7].ToString();
            //LblSup.Text = dt.Rows[0][12].ToString();
            DB_AP_Productor p = new DB_AP_Productor();
            dt = p.DB_Seleccionar_ENCABEZADO_PROD(LblIdInsProd.Text, "DATS_PROD");
            LblProductor.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString();
            LblSupProd.Text = dt.Rows[0][13].ToString();
        }
        #endregion
        #region REGISTRAR EN LA GRILLA LOS VALORES DE LA DISTRIBUCION DE AGROQUIMICOS
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        { 
            //if(TxtItemProd.Text !="" && (Convert.ToInt32(DDLInsumo.SelectedValue) == 1 || Convert.ToInt32(DDLInsumo.SelectedValue) == 2))
            //{
                if(TxtCantidad.Text!="")
                {
                    if(TxtPrecio.Text!="")
                    {
                        if(TxtCostoBsHa.Text!="")
                        {
                            if(TxtCostoSusHa.Text!="")
                            {
                                LblMsj1.Text = string.Empty;
                                DataTable dt = Session["datos"] as DataTable;
                                DataRow row = dt.NewRow();
                                row["valor1"] = DDLEtapa.SelectedItem.Text;
                                row["valor2"] = DDLEtapa.SelectedValue;
                                row["valor3"] = DDLInsumo.SelectedItem.Text;
                                row["valor4"] = DDLInsumo.SelectedValue;
                                row["valor5"] = DDLProducto.SelectedItem.Text;
                                row["valor6"] = DDLProducto.SelectedValue;
                                row["valor7"] = TxtItemProd.Text;
                                row["valor8"] = DDLUnidad.SelectedValue;
                                row["valor9"] = TxtCantidad.Text;
                                row["valor10"] = DDLNumApli.SelectedValue;
                                row["valor11"] = TxtPrecio.Text;
                                row["valor12"] = DDLTipoAdquisicion.SelectedValue;
                                row["valor13"] = TxtCostoBsHa.Text;
                                row["valor14"] = TxtCostoSusHa.Text;
                                dt.Rows.Add(row);
                                GVCostos.DataSource = dt;
                                GVCostos.DataBind();
                                Session["datos"] = dt;
                                BtnEnviar.Visible = true;
                                BtnCancelar.Visible = true;
                                Vaciar_CAMPOS();
                                TxtItemProd.Text = string.Empty;
                                //TxtItemProd.Visible = false;
                                //DDLItemProd.Visible = true;
                            }
                            else
                            {
                                LblMsj1.Text = "ERROR Costos en el calculo dolares por Hectarea";
                            }
                        }
                        else
                        {
                            LblMsj1.Text = "ERROR Costos en el calculo bolivianos por Hectarea";
                        }
                    }
                    else
                    {
                        LblMsj1.Text = "ERROR No definio ningun precio para el producto";
                    }
                }
                else
                {
                    LblMsj1.Text = "ERROR No definio ninguna cantidad para el producto";
                }
            //}
            //else
            //{
            //    LblMsj1.Text = "ERROR No definio ningun producto";
            //}
        }
        #endregion
        protected void Vaciar_CAMPOS() 
        {
            TxtItemProd.Text = string.Empty;
            TxtCantidad.Text = "0";
            TxtPrecio.Text = "0";
            TxtCostoBsHa.Text = "0";
            TxtCostoSusHa.Text = "0";
        }
        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            if(TxtFechaInspeccion.Text!="")
            {
                LblMsj.Text = string.Empty;
                Registrar_COSTOS();
                Response.Redirect("frmListaCostos.aspx");
            }
            else
            {
                LblMsj.Text="Tiene que definir la pfecha que fue a realizar el trabajo de estimacion de los costos de producción";
            }
        }
        #region FUNCIONES DE REGISTRO
        protected void Registrar_COSTOS_DETALLE(int idcostd)
        {
            DB_EXT_Seguimiento rsd = new DB_EXT_Seguimiento();
            EXT_CostosDetalle rcd = new EXT_CostosDetalle();
            DataTable dt = Session["datos"] as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rcd.Id_Costos = idcostd;
                rcd.Etapa_Cultivo = Convert.ToInt32(dt.Rows[i][1].ToString());
                rcd.Insumo = Convert.ToInt32(dt.Rows[i][3].ToString());
                rcd.Tipo_Recurso = Convert.ToInt32(dt.Rows[i][5].ToString());
                rcd.Producto = dt.Rows[i][6].ToString();
                rcd.Unidad = dt.Rows[i][7].ToString();
                rcd.Cantidad = Convert.ToDecimal(dt.Rows[i][8].ToString());
                rcd.Num_Apli = Convert.ToInt32(dt.Rows[i][9].ToString());
                rcd.Precio_Unidad = Convert.ToDecimal(dt.Rows[i][10].ToString());
                rcd.Tipo_Adquicicion = dt.Rows[i][11].ToString();
                rcd.Costo_Total_Bs = Convert.ToDecimal(dt.Rows[i][12].ToString());
                rcd.Costo_Total_Sus = Convert.ToDecimal(dt.Rows[i][13].ToString());
                rsd.DB_Registrar_COSTOS_DETALLE(rcd);
            }
        }
        #endregion
        #region FUNCION DE REGISTRO DEL SEGUIMIENTO
        protected void Registrar_COSTOS()
        {
            DataTable dt = new DataTable();
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            DB_EXT_Seguimiento insSeg = new DB_EXT_Seguimiento();
            EXT_Seguimiento seg = new EXT_Seguimiento();
            DB_EXT_Costos c = new DB_EXT_Costos();
            EXT_Costos rc = new EXT_Costos();
            EXT_FechaSegCost fsc = new EXT_FechaSegCost();
            seg.Id_InscripcionOrg = Convert.ToInt32(LblIdInsOrg.Text);
            seg.Id_Usuario = LblIdUsuario.Text;
            seg.Id_Productor = LblIdInsProd.Text;
            seg.Id_Campanhia = Convert.ToInt32(LblIdCamp.Text);
            seg.Id_Regional = Convert.ToInt32(LblIdReg.Text);
            seg.Programa = LblProg.Text;
            seg.Etapa = "COSTOS";
            seg.Num_Seg_Cultivo = 0;
            seg.Estado = "ENVIADO";
            seg.Fecha_Envio = DateTime.Now;
            seg.Tipo_Seguimiento = 0;
            insSeg.DB_Registrar_SEGUIMIENTO(seg);
            int idseg = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO", "Id_Seguimiento"));
            int idCost = 0;
            dt = c.DB_Seleccionar_COSTOS(0, LblIdInsProd.Text, "PORP_ROD");
            if (dt.Rows.Count <= 0)
            {
                rc.Tipo_Siembra = DDLTipoSiembra.SelectedValue;
                rc.Superficie = Convert.ToDecimal(LblSupProd.Text);
                rc.Id_InscripcionOrg = Convert.ToInt32(LblIdInsOrg.Text);
                rc.Id_Productor = LblIdInsProd.Text;
                rc.Id_Seguimiento = idseg;
                insSeg.DB_Registrar_COSTOS(rc);
                idCost = Convert.ToInt32(aux.DB_MaxId("EXT_COSTOS", "Id_Costos"));
            }
            else
            {
                idCost=Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            fsc.Id_Seguimiento = idseg;
            fsc.Id_Costos = idCost;
            fsc.Fecha_Seguimiento = Convert.ToDateTime(TxtFechaInspeccion.Text);
            insSeg.DB_Registrar_FECHA_SEG_COST(fsc);
            Registrar_COSTOS_DETALLE(Convert.ToInt32(aux.DB_MaxId("EXT_COSTOS", "Id_Costos")));
        }
        #endregion

        #region CALCULO DE LOS COSTOS
        private void Calcular_RENDIMIENTO()
        {
            TxtCostoBsHa.Text = (Convert.ToDecimal(TxtCantidad.Text) * Convert.ToDecimal(DDLNumApli.SelectedValue) * Convert.ToDecimal(TxtPrecio.Text)).ToString();
            TxtCostoSusHa.Text = (Math.Round((Convert.ToDecimal(TxtCostoBsHa.Text)/Convert.ToDecimal(TxtDollar.Text)),2)).ToString();         
        }
        protected void TxtCantidad_TextChanged(object sender, EventArgs e)
        {
            Calcular_RENDIMIENTO();
        }
        protected void DDLNumApli_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calcular_RENDIMIENTO();
        }
        protected void TxtPrecio_TextChanged(object sender, EventArgs e)
        {
            Calcular_RENDIMIENTO();
        }
        #endregion

        protected void DDLProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_COMBO_ITEM();
        }

        protected void LnkOtros_Click(object sender, EventArgs e)
        {
            TxtItemProd.Visible = true;
            DDLItemProd.Visible = false;
        }

        protected void DDLItemProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtItemProd.Text = DDLItemProd.SelectedItem.Text;
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmSeguimientoTecnico.aspx");
        }
        protected void GVCostos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //string aux = "";
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            DataTable DT = Session["datos"] as DataTable;
            if (rowIndex != -1)
            DT.Rows.RemoveAt(rowIndex);
            GVCostos.DataSource = DT;
            GVCostos.DataBind();
            Session["datos"] = DT;   
        }
    }
}