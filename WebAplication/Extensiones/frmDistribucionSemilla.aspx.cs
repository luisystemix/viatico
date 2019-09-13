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
    public partial class frmDistribucionSemilla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                    LblIdInsProd.Text = Session["IdInsProd"].ToString();
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    LblEtapa.Text = Session["Etapa"].ToString();
                    Datos_Org_ENCABEZADO();
                    Desplegar_PROVEEDOR();
                    /*************************************/
                    DataTable dtListaPartida = new DataTable();
                    dtListaPartida.Columns.AddRange(new DataColumn[8] { new DataColumn("NumBoleta"), new DataColumn("Variedad"), new DataColumn("Categoria"), new DataColumn("Lote"), new DataColumn("Germinacion"), new DataColumn("FechCaducidad"), new DataColumn("Unidad"), new DataColumn("Cantidad") });
                    GVDistribSemilla.DataSource = dtListaPartida;
                    GVDistribSemilla.DataBind();
                    Session["datos"] = dtListaPartida;
                    /****************************************/
                    //Seleccionar_CONTRATO_PROV();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCIONES SELECCIONAR EL CONTRATO DE INSUMO POR EL PRODUTO O INSUMO
        private void Seleccionar_CONTRATO_PROV()
        {
            if (DDLProveedor.SelectedValue != "")
            {
                DB_INS_Insumos ti = new DB_INS_Insumos();
                DataTable dt = new DataTable();
                dt = ti.DB_Seleccionar_TIPO_INSUMOS(Convert.ToInt32(DDLProveedor.SelectedValue), Convert.ToInt32(DDLProducto.SelectedValue), Convert.ToInt32(DDLInsumo.SelectedValue), "TIPO_INSUMO");
                DDLNomComer.DataSource = dt;
                DDLNomComer.DataValueField = "Contador";
                DDLNomComer.DataTextField = "Nombre_Insumo";
                DDLNomComer.DataBind();
                Desplegar_PRODUCTO();
            }
            else 
            {
                BtnEnviar.Enabled = false;
            }
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
            DB_AP_Productor p = new DB_AP_Productor();
            dt = p.DB_Seleccionar_ENCABEZADO_PROD(LblIdInsProd.Text, "DATS_PROD");
            LblProductor.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString();
        }
        #endregion
        #region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS
        private void Desplegar_PROVEEDOR()
        {
            string[] valor = { "0", LblIdCamp.Text, LblIdReg.Text, "SEMILLA", LblProg.Text, "1", "PROV_INSUMO" };
            DB_AP_Proveedor pro = new DB_AP_Proveedor();
            DataTable dt = new DataTable();
            dt = pro.DB_Desplegar_PROVEEDOR_PARAMETROS(valor);
            DDLProveedor.DataSource = dt;
            DDLProveedor.DataValueField = "Id_InscripcionProv";
            DDLProveedor.DataTextField = "Razon_Social";
            DDLProveedor.DataBind();
            Seleccionar_CONTRATO_PROV();
        }
        #endregion
        #region FUNCIONS PARA LLENAR EL COMBOS
        private void Desplegar_PRODUCTO()
        {
            DB_AP_InscripcionProv inp = new DB_AP_InscripcionProv();
            DataTable dt = new DataTable();
            if (DDLNomComer.SelectedValue != "")
            {
                if (DDLProveedor.SelectedValue != "")
                {
                    dt = inp.DB_Seleccionar_CONTRATO_PROV(Convert.ToInt32(DDLNomComer.SelectedValue), Convert.ToInt32(DDLProveedor.SelectedValue), Convert.ToInt32(DDLProducto.SelectedValue), "CONTRATO_PROV");
                    if (dt.Rows.Count > 0)
                    {
                        TxtVariedad.Text = dt.Rows[0][8].ToString();
                        TxtCategoria.Text = dt.Rows[0][9].ToString();
                    }
                    else
                    {
                        TxtVariedad.Text = string.Empty;
                        TxtCategoria.Text = string.Empty;
                    }
                }
                else
                {
                    TxtVariedad.Text = string.Empty;
                    TxtCategoria.Text = string.Empty;
                }
            }
            else
            {
                TxtVariedad.Text = string.Empty;
                TxtCategoria.Text = string.Empty;
            }
        }
        #endregion

        #region VACIAR CAMPOS
        private void Vaciar_CAMPOS()
        {
            TxtVariedad.Text = string.Empty;
            TxtCategoria.Text = string.Empty;
            TxtLote.Text = string.Empty;
            TxtFechaCaducidad.Text = string.Empty;
            TxtCantidad.Text = string.Empty;
            TxtPorcentGermi.Text = string.Empty;
        }
        #endregion
        #region REGISTRAR EN LA GRILLA LOS VALORES DE LA DISTRIBUCION DE SEMILLA
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            LblMsj2.Text = string.Empty;
            if(TxtNumBoleta.Text!="")
            {
                if(TxtVariedad.Text!="")
                {
                    if(TxtCategoria.Text!="")
                    {
                        if (TxtLote.Text != "")
                        {
                            if (TxtFechaCaducidad.Text != "")
                            {
                                if (TxtCantidad.Text != "")
                                {
                                    if (TxtPorcentGermi.Text != "")
                                    {
                                        DataTable dt = Session["datos"] as DataTable;
                                        DataRow row = dt.NewRow();
                                        row["NumBoleta"] = TxtNumBoleta.Text;
                                        row["Cantidad"] = TxtCantidad.Text;
                                        row["Unidad"] = DDLUnidad.Text;
                                        row["Variedad"] = TxtVariedad.Text;
                                        row["Categoria"] = TxtCategoria.Text;
                                        row["Lote"] = TxtLote.Text;
                                        row["Germinacion"] = TxtPorcentGermi.Text;
                                        row["FechCaducidad"] = TxtFechaCaducidad.Text;
                                        dt.Rows.Add(row);
                                        GVDistribSemilla.DataSource = dt;
                                        GVDistribSemilla.DataBind();
                                        Session["datos"] = dt;
                                        Vaciar_CAMPOS();
                                        LblMsj.Text = string.Empty;
                                        BtnEnviar.Enabled = true;
                                    }
                                    else
                                    {
                                        LblMsj.Text = "Debe ingresar el porcentaje de germinación que presenta la semilla";
                                    }
                                }
                                else
                                {
                                    LblMsj.Text = "Debe ingresar la cantidad de semilla que se le distribuyo al productor";
                                }
                            }
                            else
                            {
                                LblMsj.Text = "Debe ingresar la fecha de caducidad de la semilla";
                            }
                        }
                        else
                        {
                            LblMsj.Text = "Debe ingresar el número de lote de la semilla";
                        }
                    }
                    else
                    {
                        LblMsj.Text = "Debe ingresas la categoría de la semilla";
                    }
                }
                else
                {
                    LblMsj.Text = "Debe ingresar la variedad de semilla";
                }
            }
            else
            {
            LblMsj.Text="Es necesario ingresar el número de boleta de distribución de semilla";
            }
        }
        #endregion
        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (TxtLugarDistrib.Text != "")
            {
                //if (TxtProveedor.Text != "")
                //{
                    if (TxtFechaDistrib.Text != "")
                    {
                        if (GVDistribSemilla.Rows.Count > 0)
                        {
                            Registrar_SEGUIMIENTO();
                        }
                        else
                        {
                            LblMsj1.Text = string.Empty;
                            LblMsj2.Text = "Debe registrar los datos de la distribución de semilla para poder enviar el seguimiento realizado";
                        }
                    }
                    else
                    {
                        LblMsj1.Text = "Para continuar es necesario ingresar la fecha de la distribución de semilla";
                    }
                //}
                //else
                //{
                //    LblMsj1.Text = "Para continuar se necesita que ingrese el nombre del  proveedor de semilla";
                //}
            }
            else
            {
                LblMsj1.Text = "Para continuar necesita especificar el lugar donde se realizó la distribución de semilla";
            }
        }
        #region FUNCIONES DE REGISTRO
        protected void Registrar_DISTRIBUCION_DETALLE(int idsegdd)
        {
            DB_EXT_Seguimiento rsd = new DB_EXT_Seguimiento();
            EXT_SeguimientoDistribDetalle sdd = new EXT_SeguimientoDistribDetalle(); 
            DataTable dt = Session["datos"] as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sdd.Id_Seg_Distribucion = idsegdd;
                //sdd.Num_Boleta= Convert.ToInt32(dt.Rows[i][0].ToString());
                sdd.Valor1=dt.Rows[i][1].ToString();
                sdd.Valor2 = dt.Rows[i][2].ToString();
                sdd.Valor3 = dt.Rows[i][3].ToString();
                string aux = dt.Rows[i][5].ToString();
                sdd.Fecha_Caducidad = Convert.ToDateTime(dt.Rows[i][5].ToString());
                sdd.Unidad = dt.Rows[i][6].ToString();
                sdd.Cantidad = Convert.ToDecimal(dt.Rows[i][7].ToString());
                sdd.Valor4 = Convert.ToInt32(dt.Rows[i][4].ToString());
                rsd.DB_RRegistrar_DISTRIBUCION_DETALLE(sdd);
            }
        }
        #endregion
        #region FUNCION DE REGISTRO DEL SEGUIMIENTO
        protected void Registrar_SEGUIMIENTO()
        {
            DB_EXT_DesignacionProd estadoprod = new DB_EXT_DesignacionProd();
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            DB_EXT_Seguimiento insSeg = new DB_EXT_Seguimiento();
            EXT_Seguimiento seg = new EXT_Seguimiento();
            EXT_SeguimientoDistribucion segDist = new EXT_SeguimientoDistribucion();
            seg.Id_InscripcionOrg = Convert.ToInt32(LblIdInsOrg.Text);
            seg.Id_Usuario = LblIdUsuario.Text;
            seg.Id_Productor = LblIdInsProd.Text;
            seg.Id_Campanhia = Convert.ToInt32(LblIdCamp.Text);
            seg.Id_Regional = Convert.ToInt32(LblIdReg.Text);
            seg.Programa = LblProg.Text;
            seg.Etapa = LblEtapa.Text;
            seg.Estado = "ENVIADO";
            seg.Fecha_Envio = DateTime.Now;
            insSeg.DB_Registrar_SEGUIMIENTO(seg);

            segDist.Id_Seguimiento = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO", "Id_Seguimiento"));
            segDist.Programa = LblProg.Text;
            segDist.Nom_Proveedor = DDLProveedor.SelectedItem.Text;
            segDist.Lugar_Distribucion = TxtLugarDistrib.Text;
            segDist.Fecha_Sis = DateTime.Now;
            segDist.Fecha_Distribucion = Convert.ToDateTime(TxtFechaDistrib.Text);
            segDist.Tipo_Insumo = "SEMILLA";
            segDist.Observacion = TxtObser.Text;
            segDist.Num_Boleta = Convert.ToInt32(TxtNumBoleta.Text);
            insSeg.DB_Registrar_SEGUIMIENTO_DISTRIBUCION(segDist);
            Registrar_DISTRIBUCION_DETALLE(Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO_DISTRIBUCION", "Id_Seg_Distribucion")));
            estadoprod.DB_Cambiar_ESTADO(LblIdInsProd.Text, "VERIFICACION_SIEMBRA");
            Response.Redirect("frmSeguimientoTecnico.aspx");
        }
        #endregion

        protected void DDLProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Seleccionar_CONTRATO_PROV();
            Desplegar_PRODUCTO();
        }

        protected void DDLNomComer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_PRODUCTO();
        }

        protected void DDLProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Seleccionar_CONTRATO_PROV();
            Desplegar_PRODUCTO();
        }
        protected void LnkNuevo_Click(object sender, EventArgs e)
        {
            TxtVariedad.Visible = true;
            TxtVariedad.Text = string.Empty;
            TxtCategoria.Text = string.Empty;
            DDLNomComer.Visible = false;
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmSeguimientoTecnico.aspx");
        }
    }
}