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
    public partial class frmRendimientoTrigo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try{
                if (!IsPostBack)
                {
                    LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                    LblIdInsProd.Text = Session["IdInsProd"].ToString();
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    Datos_Org_ENCABEZADO();
                    Cargar_COMBO();
                    /*************************************/
                    DataTable dtListaPartida = new DataTable();
                    dtListaPartida.Columns.AddRange(new DataColumn[8] { new DataColumn("Id_Fenologia"), new DataColumn("Face_Fenologia"), new DataColumn("Valor1"), new DataColumn("Valor2"), new DataColumn("Valor5"), new DataColumn("Valor6"), new DataColumn("Valor7"), new DataColumn("Valor8") });
                    GVRendTrigo.DataSource = dtListaPartida;
                    GVRendTrigo.DataBind();
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
            List<EXT_Fenologia> ListaF = nd.DB_Desplegar_FENOLOGIA_PRODUCTOR("TRIGO",LblIdInsProd.Text);
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
            LblCamp.Text = dt.Rows[0][6].ToString();
            LblProg.Text = dt.Rows[0][9].ToString();
            LblIdReg.Text = dt.Rows[0][7].ToString();
            DB_AP_Productor p = new DB_AP_Productor();
            dt = p.DB_Seleccionar_ENCABEZADO_PROD(LblIdInsProd.Text, "DATS_PROD");
            LblProductor.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString();

            DB_EXT_Rendimiento ex = new DB_EXT_Rendimiento();
            dt = ex.DB_Reporte_DETALLE_PLANILLA(Convert.ToInt32(LblIdInsOrg.Text), LblIdInsProd.Text, LblProg.Text, "VARIEDADESPROD");
            TxtVariedad.Text = dt.Rows[0][0].ToString();
        }
        #endregion
        #region REGISTRAR EN LA GRILLA LOS VALORES DE LA DISTRIBUCION DE AGROQUIMICOS
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if(TxtNumEspigas.Text!="")
            {
                if(TxtNumGranoEspigas.Text!="")
                {
                    if(TxtPesoMilGranos.Text!="")
                    {
                        if(TxtPorcentHumedad.Text!="")
                        {
                            string aux="NO";
                            DataTable dt = Session["datos"] as DataTable;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if(dt.Rows[i][0].ToString()==DDLFaceFenologica.SelectedValue)
                                {
                                  aux="SI";
                                }
                            }
                            if (aux == "NO")
                            {
                                //DataTable dt = Session["datos"] as DataTable;
                                DataRow row = dt.NewRow();
                                row["Id_Fenologia"] = DDLFaceFenologica.SelectedValue;
                                row["Face_Fenologia"] = DDLFaceFenologica.SelectedItem.Text;
                                row["Valor1"] = TxtNumEspigas.Text;
                                row["Valor2"] = TxtNumGranoEspigas.Text;
                                row["Valor5"] = TxtPesoMilGranos.Text;
                                row["Valor6"] = TxtPorcentHumedad.Text;
                                row["Valor7"] = LblKgHect.Text;
                                row["Valor8"] = LblTonHect.Text;
                                dt.Rows.Add(row);
                                GVRendTrigo.DataSource = dt;
                                GVRendTrigo.DataBind();
                                Session["datos"] = dt;
                                BtnEnviar.Visible = true;
                                BtnCancelar.Visible = true;
                                LblMsj1.Text = string.Empty;
                                Linpiar_CAMPOS();
                            }
                            else 
                            {
                                LblMsj1.Text = "Ya registro la face Fenologica que selecciono";
                            }
                        }
                        else
                        {
                            LblMsj1.Text = "Error Porcentaje Humedad";
                        }
                    }
                    else
                    {
                        LblMsj1.Text = "ERROR Peso MIL gramos";
                    }
                }
                else
                {
                    LblMsj1.Text = "ERROR granos espigas";
                }
            }
            else
            {
                LblMsj1.Text = "ERROR Numero de espigas";
            }
        }
        private void Linpiar_CAMPOS() 
        {
            TxtNumEspigas.Text = "0";
            TxtNumGranoEspigas.Text = "0";
            TxtPesoMilGranos.Text = "0";
            TxtPorcentHumedad.Text = "0";
            LblKgHect.Text = "0";
            LblTonHect.Text = "0";
        }
        #endregion
        #region FUNCION PARA ENVIAR EL RENDIMIENTO CALCULADO
        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (TxtFechaInspeccion.Text != "")
            {
                if (GVRendTrigo.Rows.Count > 0)
                {
                    if(TxtVariedad.Text!="")
                    {
                      Registrar_SEGUIMIENTO();
                      Response.Redirect("frmListaRendimiento.aspx");
                    }
                    else
                    {
                        LblMsj.Text = "ERROR ES NECESARIO ESPECIFICAR LA VARIEDAD DE SEMILLA SEMBRADA, PARA PODER CONTINUAR";
                    }
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
                rdd.Id_Fenologia = Convert.ToInt32(dt.Rows[i][0].ToString());
                rdd.Face_Fenologia = dt.Rows[i][1].ToString();
                rdd.Valor1 = Convert.ToDecimal(dt.Rows[i][2].ToString());
                rdd.Valor2 = Convert.ToDecimal(dt.Rows[i][3].ToString());
                rdd.Valor3 = 0;
                rdd.Valor4 = 0;
                rdd.Valor5 = Convert.ToDecimal(dt.Rows[i][4].ToString());
                rdd.Valor6 = Convert.ToDecimal(dt.Rows[i][5].ToString());
                rdd.Valor7 = Convert.ToDecimal(dt.Rows[i][6].ToString());
                rdd.Valor8 = Convert.ToDecimal(dt.Rows[i][7].ToString());
                rsd.DB_Registrar_RENDIMIENTO_DETALLE(rdd);
            }
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
            seg.Num_Seg_Cultivo = 0;
            seg.Estado = "ENVIADO";
            seg.Fecha_Envio = DateTime.Now;
            seg.Tipo_Seguimiento = 0;
            insSeg.DB_Registrar_SEGUIMIENTO(seg);
            rd.Id_Seguimiento = Convert.ToInt32(aux.DB_MaxId("EXT_SEGUIMIENTO", "Id_Seguimiento"));
            rd.Fecha_Sis = DateTime.Now;
            rd.Fech_Inspeccion = Convert.ToDateTime(TxtFechaInspeccion.Text);
            rd.Variedad_Semilla = TxtVariedad.Text;
            insSeg.DB_Registrar_RENDIMIENTO(rd);
            Registrar_RENDIMIENTO_DETALLE(Convert.ToInt32(aux.DB_MaxId("EXT_RENDIMIENTO", "Id_Rendimiento")));
        }
        #endregion
        #region CALCULO DE RENDIMIENTOS
        private void Calcular_RENDIMIENTO()
        {
            LblKgHect.Text = ((Convert.ToDecimal(TxtNumEspigas.Text)*Convert.ToDecimal(TxtNumGranoEspigas.Text)*Convert.ToDecimal(TxtPesoMilGranos.Text))/100).ToString();
            LblTonHect.Text = (Convert.ToDecimal(LblKgHect.Text) / 1000).ToString();
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

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmSeguimientoTecnico.aspx");
        }
    }
}