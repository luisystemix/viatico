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
    public partial class frmDistribucionAgroquimico : System.Web.UI.Page
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
                    dtListaPartida.Columns.AddRange(new DataColumn[7] { new DataColumn("NumBoleta"), new DataColumn("Producto"), new DataColumn("NomTec"), new DataColumn("NomComer"), new DataColumn("FechCaducidad"), new DataColumn("Unidad"), new DataColumn("Cantidad") });
                    GVDistribAgroQuim.DataSource = dtListaPartida;
                    GVDistribAgroQuim.DataBind();
                    Session["datos"] = dtListaPartida;
                    /*********************************/
                    //Desplegar_PRODUCTO();
                    Seleccionar_CONTRATO_PROV();
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
            if(DDLProveedor.SelectedValue!="")
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
                BtnEnviar.Enabled=false;
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
        #region FUNCIONS PARA LLENAR EL COMBOS
        private void Desplegar_PROVEEDOR()
        {
            string[] valor = { "0", LblIdCamp.Text, LblIdReg.Text, "AGROQUIMICO", LblProg.Text, "1", "PROV_INSUMO"};
            DB_AP_Proveedor pro = new DB_AP_Proveedor();
            DataTable dt = new DataTable();
            dt = pro.DB_Desplegar_PROVEEDOR_PARAMETROS(valor);
            DDLProveedor.DataSource = dt;
            DDLProveedor.DataValueField = "Id_InscripcionProv";
            DDLProveedor.DataTextField = "Razon_Social";
            DDLProveedor.DataBind();
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
                        TxtNomComer.Text = dt.Rows[0][8].ToString();
                        TxtNomTecnico.Text = dt.Rows[0][9].ToString();
                    }
                    else
                    {
                        TxtNomComer.Text = string.Empty;
                        TxtNomTecnico.Text = string.Empty;
                    }
                }
                else
                {
                    TxtNomComer.Text = string.Empty;
                    TxtNomTecnico.Text = string.Empty;
                }
            }
            else 
            {
                TxtNomComer.Text = string.Empty;
                TxtNomTecnico.Text = string.Empty;
            }
        }
        #endregion
        #region VACIAR CAMPOS
        private void Vaciar_CAMPOS() 
        {
            TxtNomTecnico.Text = string.Empty;
            TxtNomComer.Text = string.Empty;
            TxtFechaCaducidad.Text = string.Empty;
            TxtCantidad.Text = string.Empty;
        }
        #endregion
        #region REGISTRAR EN LA GRILLA LOS VALORES DE LA DISTRIBUCION DE AGROQUIMICOS
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if(TxtNumBoleta.Text!="")
            {
                if(TxtNomTecnico.Text!="")
                {
                    if(TxtNomComer.Text!="")
                    {
                        if(TxtFechaCaducidad.Text!="")
                        {
                            if(TxtCantidad.Text!="")
                            {
                                DataTable dt = Session["datos"] as DataTable;
                                DataRow row = dt.NewRow();
                                row["NumBoleta"] = TxtNumBoleta.Text;
                                row["Producto"] = DDLProducto.SelectedValue;
                                row["NomTec"] = TxtNomTecnico.Text;
                                row["NomComer"] = TxtNomComer.Text;
                                row["FechCaducidad"] = TxtFechaCaducidad.Text;
                                row["Unidad"] = DDLUnidad.SelectedValue;
                                row["Cantidad"] = TxtCantidad.Text;
                                dt.Rows.Add(row);
                                GVDistribAgroQuim.DataSource = dt;
                                GVDistribAgroQuim.DataBind();
                                Session["datos"] = dt;
                                Vaciar_CAMPOS();
                                LblMsj1.Text = string.Empty;
                            }
                            else
                            {
                                LblMsj1.Text = "Debe ingresar la cantidad de producto que se le distribuyo al productor";
                            }
                        }
                        else
                        {
                            LblMsj1.Text = "Debe ingresar la fecha de caducidad del producto";
                        }
                    }
                    else
                    {
                        LblMsj1.Text = "Es necesario ingresar el nombre comercial del producto";
                    }
                }
                else
                {
                    LblMsj1.Text="Es necesario ingresar el nombre tecnico o ingrediente activo del producto";
                }
            }
            else
            {
                LblMsj1.Text = "Es necesario ingresar el número de boleta de distribución de Insumo";
            }
        }
        #endregion
        #region FUNCIONES DE REGISTRO
        protected void Registrar_DISTRIBUCION_DETALLE(int idsegdd)
        {
            DB_EXT_Seguimiento rsd = new DB_EXT_Seguimiento();
            EXT_SeguimientoDistribDetalle sdd = new EXT_SeguimientoDistribDetalle();
            DataTable dt = Session["datos"] as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sdd.Id_Seg_Distribucion = idsegdd;
                sdd.Num_Boleta = Convert.ToInt32(dt.Rows[i][0].ToString());
                sdd.Valor1 = dt.Rows[i][1].ToString();
                sdd.Valor2 = dt.Rows[i][3].ToString();
                sdd.Valor3 = dt.Rows[i][2].ToString();
                sdd.Valor4 = 0;
                sdd.Fecha_Caducidad = Convert.ToDateTime(dt.Rows[i][4].ToString());
                sdd.Unidad = dt.Rows[i][5].ToString();
                sdd.Cantidad = Convert.ToInt32(dt.Rows[i][6].ToString());
                rsd.DB_RRegistrar_DISTRIBUCION_DETALLE(sdd);
            }
        }
        #endregion
        #region FUNCION DE REGISTRO DEL SEGUIMIENTO
        protected void Registrar_SEGUIMIENTO()
        {
            if(TxtLugarDistrib.Text!="")
            {
                //if(TxtProveedor.Text!="")
                //{
                    if(TxtFechaDistrib.Text!="")
                    {
                        if(GVDistribAgroQuim.Rows.Count > 0)
                        {
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
                            seg.Etapa = "DISTRIBUCION_AGROQUIMICO";
                            seg.Estado = "ENVIADO";
                            seg.Fecha_Envio = DateTime.Now;
                            insSeg.DB_Registrar_SEGUIMIENTO(seg);

                            segDist.Id_Seguimiento = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO", "Id_Seguimiento"));
                            segDist.Programa = LblProg.Text;
                            segDist.Nom_Proveedor = DDLProveedor.SelectedItem.Text;
                            segDist.Lugar_Distribucion = TxtLugarDistrib.Text;
                            segDist.Fecha_Sis = DateTime.Now;
                            segDist.Fecha_Distribucion = Convert.ToDateTime(TxtFechaDistrib.Text);
                            segDist.Tipo_Insumo = "AGROQUIMICO";
                            segDist.Observacion = TxtObser.Text;
                            insSeg.DB_Registrar_SEGUIMIENTO_DISTRIBUCION(segDist);
                            Registrar_DISTRIBUCION_DETALLE(Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO_DISTRIBUCION", "Id_Seg_Distribucion")));
                            Response.Redirect("frmSeguimientoTecnico.aspx");
                        }
                        else
                        {
                            LblMsj1.Text = string.Empty;
                            LblMsj2.Text = "Debe registrar los datos de la distribución de insumos para poder enviar el seguimiento realizado";
                        }
                     }
                    else
                    {
                        LblMsj.Text = "Para continuar es necesario ingresar la fecha de la distribución de insumos";
                    }
                //}
                //else
                //{
                //    LblMsj.Text = "Para continuar se necesita que ingrese el nombre del  proveedor de semilla";
                //}
            }
            else
            {
                LblMsj.Text = "Para continuar necesita especificar el lugar donde se realizó la distribución de insumos";
            }
        }
        #endregion
        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            Registrar_SEGUIMIENTO();
        }

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
            DDLNomComer.Visible = false;
            TxtNomComer.Visible = true;
            TxtNomComer.Text = string.Empty;
            TxtNomTecnico.Text = string.Empty;
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmSeguimientoTecnico.aspx");
        }
    }
}