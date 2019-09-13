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
    public partial class frmRendimientoMaiz : System.Web.UI.Page
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
                    //LblEtapa.Text = Session["Etapa"].ToString();
                    Datos_Org_ENCABEZADO();
                    Cargar_COMBO();
                    /*************************************/
                    DataTable dtListaPartida = new DataTable();
                    dtListaPartida.Columns.AddRange(new DataColumn[9] { new DataColumn("Id_Fenologia"), new DataColumn("Face_Fenologia"), new DataColumn("Valor1"), new DataColumn("Valor2"), new DataColumn("Valor3"), new DataColumn("Valor4"), new DataColumn("Valor5"), new DataColumn("Valor6"), new DataColumn("Valor7") });
                    GVRendMaiz.DataSource = dtListaPartida;
                    GVRendMaiz.DataBind();
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
            List<EXT_Fenologia> ListaF = nd.DB_Desplegar_FENOLOGIA_PRODUCTOR("MAIZ", LblIdInsProd.Text);
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
        }
        #endregion

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if(TxtNumMazorcas.Text!="")
            {
                if(TxtDistHileras.Text!="")
                {
                    if(TxtNumMazorm2.Text!="")
                    {
                        if(TxtGranosMazorc.Text!="")
                        {
                            if(TxtMilGranos.Text!="")
                            {
                                if(TxtProcentHumendad.Text!="")
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
                                            row["Valor1"] = TxtNumMazorcas.Text;
                                            row["Valor2"] = TxtDistHileras.Text;
                                            row["Valor3"] = TxtNumMazorm2.Text;
                                            row["Valor4"] = TxtGranosMazorc.Text;
                                            row["Valor5"] = TxtMilGranos.Text;
                                            row["Valor6"] = TxtProcentHumendad.Text;
                                            row["Valor7"] = LblTonHa.Text;
                                            dt.Rows.Add(row);
                                            GVRendMaiz.DataSource = dt;
                                            GVRendMaiz.DataBind();
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
                            LblMsj1.Text = "ERROR granos mazorca";
                        }
                    }
                    else
                    {
                        LblMsj1.Text = "ERROR granos mazorca m2";
                    }
                }
                else
                {
                    LblMsj1.Text = "ERROR distancia entre hileras";
                }
            }
            else
            {
                LblMsj1.Text = "ERROR numero de mazorcas";
            }
        }
        private void Linpiar_CAMPOS()
        {
            TxtNumMazorcas.Text = "0";
            TxtDistHileras.Text = "1";
            TxtGranosMazorc.Text = "0";
            TxtMilGranos.Text = "0";
            TxtProcentHumendad.Text = "0";
            LblTonHa.Text = "0";
        }
        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (TxtFechaInspeccion.Text != "")
            {
                if (GVRendMaiz.Rows.Count > 0)
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
                rdd.Valor1 = Convert.ToInt32(dt.Rows[i][2].ToString());
                rdd.Valor2 = Convert.ToInt32(dt.Rows[i][3].ToString());
                rdd.Valor3 = Convert.ToInt32(dt.Rows[i][4].ToString());
                rdd.Valor4 = Convert.ToInt32(dt.Rows[i][5].ToString());
                rdd.Valor5 = Convert.ToDecimal(dt.Rows[i][6].ToString());
                rdd.Valor6 = Convert.ToInt32(dt.Rows[i][7].ToString());
                rdd.Valor7 = Convert.ToDecimal(dt.Rows[i][8].ToString());
                rdd.Valor8 = 0;
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
            seg.Etapa = LblEtapa.Text;
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
            //TxtNumMazorm2.Text = ((Convert.ToDecimal(TxtNumMazorcas.Text) / 5) * (100 / Convert.ToDecimal(TxtDistHileras.Text))).ToString();
            //LblTonHa.Text = (((Convert.ToDecimal(TxtGranosMazorc.Text) * Convert.ToDecimal(TxtNumMazorm2.Text) * Convert.ToDecimal(TxtMilGranos.Text)) / 1000) / 100).ToString();
            TxtNumMazorm2.Text =(Math.Round((Convert.ToDecimal(TxtNumMazorcas.Text) / 5) * (100 / Convert.ToDecimal(TxtDistHileras.Text)),2)).ToString();
            LblTonHa.Text = (Math.Round((((Convert.ToDecimal(TxtGranosMazorc.Text) * Convert.ToDecimal(TxtNumMazorm2.Text) * Convert.ToDecimal(TxtMilGranos.Text)) / 1000) / 100),2)).ToString();
        }
        protected void TxtNumMazorcas_TextChanged(object sender, EventArgs e)
        {
            Calcular_RENDIMIENTO();
        }
        protected void TxtDistHileras_TextChanged(object sender, EventArgs e)
        {
            Calcular_RENDIMIENTO();
        }
        protected void TxtGranosMazorc_TextChanged(object sender, EventArgs e)
        {
            Calcular_RENDIMIENTO();
        }
        protected void TxtMilGranos_TextChanged(object sender, EventArgs e)
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