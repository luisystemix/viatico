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
    public partial class frmRendimientoArroz : System.Web.UI.Page
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
                    Datos_Org_ENCABEZADO();
                    Cargar_COMBO();
                    /*************************************/
                    DataTable dtListaPartida = new DataTable();
                    dtListaPartida.Columns.AddRange(new DataColumn[7] { new DataColumn("Valor1"), new DataColumn("Valor2"), new DataColumn("Valor3"), new DataColumn("Valor4"), new DataColumn("Valor5"), new DataColumn("Valor6"), new DataColumn("Valor7") });
                    GVRendArroz.DataSource = dtListaPartida;
                    GVRendArroz.DataBind();
                    Session["datos"] = dtListaPartida;
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCIONES DEL COMBO
        private void Cargar_COMBO()
        {
            DB_EXT_Fenologia nd = new DB_EXT_Fenologia();
            List<EXT_Fenologia> ListaF = nd.DB_Desplegar_FENOLOGIA_PRODUCTOR("ARROZ", LblIdInsProd.Text);
            DDLFaceFenologica.DataSource = ListaF;
            DDLFaceFenologica.DataValueField = "Id_Fenologia";
            DDLFaceFenologica.DataTextField = "Nom_Fenologia";
            DDLFaceFenologica.DataBind();
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
            LblProg.Text = dt.Rows[0][9].ToString();
            LblIdReg.Text = dt.Rows[0][7].ToString();
            DB_AP_Productor p = new DB_AP_Productor();
            dt = p.DB_Seleccionar_ENCABEZADO_PROD(LblIdInsProd.Text, "DATS_PROD");
            LblProductor.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString();
            /***********************************************************/
            DB_EXT_Fenologia numBol = new DB_EXT_Fenologia();
            dt = numBol.DB_Datos_SIEMBRA(Convert.ToInt32(LblIdInsOrg.Text), "ARROZ", "VARIEDADES");
            if (dt.Rows.Count > 0)
            {
                LblVariedad.Text = dt.Rows[0][0].ToString();
            }

        }
        #endregion
        #region REGISTRAR VALORES EN LA GRILLA
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(DDLFaceFenologica.SelectedValue)>=6)
            {
                 DataTable dt = Session["datos"] as DataTable;
                 DataRow row = dt.NewRow();
                 row["Valor1"] = TxtNumPanoja.Text;
                 row["Valor2"] = TxtNumExpigillas.Text;
                 row["Valor3"] = TxtNumEspiguillasPanojaVano.Text;
                 row["Valor4"] = TxtPorcentEspiguillasLlenas.Text;
                 row["Valor5"] = TxtPesoMilGranos.Text;
                 row["Valor6"] = TxtPorcentHumedad.Text;
                 row["Valor7"] = LblFanHect.Text;
                 dt.Rows.Add(row);
                 GVRendArroz.DataSource = dt;
                 GVRendArroz.DataBind();
                 Session["datos"] = dt;
                 BtnEnviar.Visible = true;
                 BtnCancelar.Visible = true;
                 LblMsj1.Text = string.Empty;
                 BtnEnviar.Visible = true;
                 BtnCancelar.Visible = true;
                 LblMsj1.Text = string.Empty;
            }
            else
            {
                LblMsj1.Text = "Para un rendimiento adecuado, debe definir la fenología desde la Floración del cultivo.";
            }
        }
        #endregion
        #region FUNCION PARA ENVIAR LOS RENDIMIENTOS
        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (TxtFechaInspeccion.Text != "")
            {
                if (GVRendArroz.Rows.Count > 0)
                {
                    Registrar_SEGUIMIENTO();
                }
                else
                {
                    LblMsj1.Text = "ERROR NO HAY DATOS  DE RENDIMIENTO";
                }
            }
            else
            {
                LblMsj.Text = "ERROR fecha de inspeccion";
            }  
        }
        #endregion
        #region FUNCIONES DE REGISTRO
        protected void Registrar_RENDIMIENTO_DETALLE(int idsegdd)
        {
            DB_EXT_Seguimiento rsd = new DB_EXT_Seguimiento();
            EXT_RendimientoDetalle rdd = new EXT_RendimientoDetalle();
            DataTable dt = Session["datos"] as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rdd.Id_Rendimiento = idsegdd;
                rdd.Id_Fenologia = Convert.ToInt32(DDLFaceFenologica.SelectedValue);
                rdd.Face_Fenologia = DDLFaceFenologica.SelectedItem.Text;
                rdd.Valor1 = Convert.ToDecimal(dt.Rows[i][0].ToString());
                rdd.Valor2 = Convert.ToDecimal(dt.Rows[i][1].ToString());
                rdd.Valor3 = Convert.ToDecimal(dt.Rows[i][2].ToString());
                rdd.Valor4 = Convert.ToDecimal(dt.Rows[i][3].ToString());
                rdd.Valor5 = Convert.ToDecimal(dt.Rows[i][4].ToString());
                rdd.Valor6 = Convert.ToDecimal(dt.Rows[i][5].ToString());
                rdd.Valor7 = Convert.ToDecimal(dt.Rows[i][6].ToString());
                rdd.Valor8 = 0;
                rsd.DB_Registrar_RENDIMIENTO_DETALLE(rdd);
            }
            Response.Redirect("../Extensiones/frmListaRendimiento.aspx");
        }
        #endregion
        #region FUNCION DE REGISTRO DEL SEGUIMIENTO
        protected void Registrar_SEGUIMIENTO()
        {
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            DB_EXT_Seguimiento insSeg = new DB_EXT_Seguimiento();
            EXT_Seguimiento seg = new EXT_Seguimiento();
            EXT_Rendimiento rd = new EXT_Rendimiento();
            seg.Id_InscripcionOrg = Convert.ToInt32(LblIdInsOrg.Text);
            seg.Id_Usuario = LblIdUsuario.Text;
            seg.Id_Productor = LblIdInsProd.Text;
            seg.Id_Campanhia = Convert.ToInt32(LblIdCamp.Text);
            seg.Id_Regional = Convert.ToInt32(LblIdReg.Text);
            seg.Programa = LblProg.Text;
            seg.Etapa = "RENDIMIENTO";
            seg.Fecha_Envio = DateTime.Now;
            seg.Estado = "ENVIADO";
            insSeg.DB_Registrar_SEGUIMIENTO(seg);

            rd.Id_Seguimiento = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO", "Id_Seguimiento"));
            rd.Fecha_Sis = DateTime.Now;
            rd.Fech_Inspeccion = Convert.ToDateTime(TxtFechaInspeccion.Text);
            rd.Variedad_Semilla = LblVariedad.Text;
            insSeg.DB_Registrar_RENDIMIENTO(rd);
            Registrar_RENDIMIENTO_DETALLE(Convert.ToInt32(aux.DB_MaxId("EXT_RENDIMIENTO", "Id_Rendimiento")));
        }
        #endregion
        #region CALCULO DE RENDIMIENTOS
        private void Calcular_RENDIMIENTO()
        {
            //LblKgHect.Text = ((Convert.ToDecimal(TxtNumEspigas.Text) * Convert.ToDecimal(TxtNumGranoEspigas.Text) * Convert.ToDecimal(TxtPesoMilGranos.Text)) / 100).ToString();
            //LblTonHect.Text = (Convert.ToDecimal(LblKgHect.Text) / 1000).ToString();
        }
        protected void TxtNumEspigas_TextChanged(object sender, EventArgs e)
        {
            Calcular_RENDIMIENTO();
        }
        protected void TxtNumGranoEspigas_TextChanged(object sender, EventArgs e)
        {
            Calcular_RENDIMIENTO();
        }
        protected void TxtPesoMilGranos_TextChanged(object sender, EventArgs e)
        {
            Calcular_RENDIMIENTO();
        }
        #endregion

        protected void TxtPorcentEspiguillasLlenas_TextChanged(object sender, EventArgs e)
        {
            TxtPorcentEspiguillasLlenas.Text = Convert.ToString((Convert.ToDecimal(TxtNumEspiguillasPanojaVano.Text) * 100) / Convert.ToDecimal(TxtNumExpigillas.Text));
        }


        protected void LnkRendimiento_Click(object sender, EventArgs e)
        {
            if (TxtNumPanoja.Text != "" && Convert.ToDecimal(TxtNumPanoja.Text) > 0)
            {
                if (TxtNumExpigillas.Text != "" && Convert.ToDecimal(TxtNumExpigillas.Text) >= 1)
                {
                    if (TxtNumEspiguillasPanojaVano.Text != "" && Convert.ToDecimal(TxtNumEspiguillasPanojaVano.Text)>0)
                    {
                        if (TxtPorcentEspiguillasLlenas.Text != "")
                        {
                            if (TxtPesoMilGranos.Text != "" && Convert.ToDecimal(TxtPesoMilGranos.Text)>0)
                            {
                                if (TxtPorcentHumedad.Text != "" && Convert.ToDecimal(TxtPorcentHumedad.Text) > 0)
                                {
                                    TxtPorcentEspiguillasLlenas.Text = Convert.ToString(Math.Round((Convert.ToDecimal(TxtNumEspiguillasPanojaVano.Text) * 100) / Convert.ToDecimal(TxtNumExpigillas.Text),2));
                                    LblFanHect.Text = Convert.ToString(Math.Round((((((((Convert.ToDecimal(TxtNumExpigillas.Text) - Convert.ToDecimal(TxtNumEspiguillasPanojaVano.Text)) * Convert.ToDecimal(TxtNumPanoja.Text)) * Convert.ToDecimal(TxtPesoMilGranos.Text)) / 100) / Convert.ToDecimal("176.64")) * (100 - ((100 * (Convert.ToDecimal(TxtPorcentHumedad.Text) - 14)) / 86))) / 100),2));
                                    BtnRegistrar.Enabled = true;
                                    LblMsj1.Text = string.Empty;
                                }
                                else
                                {
                                    LblMsj1.Text = "ERROR porcentage humedad";
                                }
                            }
                            else
                            {
                                LblMsj1.Text = "ERROR mil granos";
                            }
                        }
                        else
                        {
                            LblMsj1.Text = "ERROR espiguillas llenas";
                        }
                    }
                    else
                    {
                        LblMsj1.Text = "ERROR espiguollas llenas panoja vano";
                    }
                }
                else
                {
                    LblMsj1.Text = "ERROR numero de espiguillas";
                }
            }
            else
            {
                LblMsj1.Text = "ERROR numero de panojas";
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmSeguimientoTecnico.aspx");
        }
    }
}