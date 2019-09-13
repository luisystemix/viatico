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
    public partial class frmFaseFenTrigo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            if (!IsPostBack)
            {
                LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                LblIdUsuario.Text = Session["IdUser"].ToString();
                TxtFechaIni.Text = DateTime.Now.ToString("dd/MM/yyyy");
                LblFechaFin.Text = (Convert.ToDateTime(TxtFechaIni.Text)).AddDays(-8).ToString("dd/MM/yyyy");
                Datos_Org_ENCABEZADO();
                Datos_CULTIVO();
                LblFechaRep.Text = DateTime.Now.ToString();
                if (TxtBoletasFisicas.Text == "")
                {
                    TxtBoletasFisicas.Enabled = false;
                    BtnEnviar.Enabled = false;
                }
                //LblFechaFin.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //LblFechaIni.Text = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
            }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        #region FUNCIONES NUMERO DE SEGUIMIENTOS
        private void Cargar_NUM_SEGUIMIENTOS()
        {
            DB_EXT_Fenologia numBol = new DB_EXT_Fenologia();
            DataTable dt = new DataTable();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 0, Convert.ToInt32(LblIdReg.Text), "0", "0", 0, DateTime.Now, "NUM_SEGUIMIENTOS");
            DDLNumSeg.DataSource = dt;
            DDLNumSeg.DataValueField = "Num_Seg_Cultivo";
            DDLNumSeg.DataTextField = "Num_Seg_Cultivo";
            DDLNumSeg.DataBind();
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
            LblReg.Text = dt.Rows[0][8].ToString();


            Cargar_NUM_SEGUIMIENTOS();
            DB_EXT_Fenologia Luis = new DB_EXT_Fenologia();
            //LblNumSeg.Text = (Luis.DB_MaxNumSeg(Convert.ToInt32(LblIdInsOrg.Text))).ToString();
            LblNumSeg.Text = DDLNumSeg.SelectedValue;
            dt = Luis.DB_Seleccionar_NUMPROD_TOTSUP_ORG(Convert.ToInt32(LblIdInsOrg.Text));
            if (dt.Rows.Count > 0)
            {
                TxtNumBenefVig.Text = dt.Rows[0][0].ToString();
                TxtSupAct.Text = dt.Rows[0][1].ToString();
                TxtSupApo.Text = dt.Rows[0][2].ToString();
            }
        }
        #endregion
        #region 
        private DataTable Busqueda_FENOLOGIA(int idfenologia, string programa, string etapa, string parametro) 
        {
            DB_EXT_Fenologia numBol = new DB_EXT_Fenologia();
            return numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), idfenologia, Convert.ToInt32(LblIdReg.Text), programa, etapa, Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text), parametro);
        }
        #endregion 
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Datos_CULTIVO()
        {
            DB_EXT_Fenologia numBol = new DB_EXT_Fenologia();
            DataTable dt = new DataTable();
            dt = numBol.DB_Datos_SIEMBRA(Convert.ToInt32(LblIdInsOrg.Text), "TRIGO", "VARIEDADES");
            if (dt.Rows.Count > 0)
            {
                TxtVariedadSem.Text = dt.Rows[0][0].ToString();
            }

            dt = numBol.DB_Datos_SIEMBRA(Convert.ToInt32(LblIdInsOrg.Text), "TRIGO", "FECHAMAXMIN");
            if (dt.Rows.Count > 0)
            {
                LblFIniSiem.Text = dt.Rows[0][0].ToString();
                LblFFinSiem.Text = dt.Rows[0][1].ToString();
            }


            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 0, Convert.ToInt32(LblIdReg.Text), "TRIGO", "", 1, DateTime.Now, "NUM_BOLETAS_FISICAS");
            TxtBoletasFisicas.Text = dt.Rows[0][0].ToString();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 0, Convert.ToInt32(LblIdReg.Text), "TRIGO", "", 1, DateTime.Now, "NUM_BOLETAS_MONITOREO");
            TxtBoletasMonitoreo.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 25, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Avance", 1, DateTime.Now, "AVANCE_SIEMBRA");
            LblAvnSiem.Text = dt.Rows[0][0].ToString();
            LblSupSem.Text = Convert.ToString(Math.Round(((Convert.ToDecimal(LblAvnSiem.Text) * Convert.ToDecimal(TxtSupApo.Text)) / 100), 2));

            LblFechaAUX.Text=TxtFechaIni.Text;
            do
            {
                dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 26, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(LblFechaAUX.Text), "PORCENTAGE");
                LblGer1.Text = dt.Rows[0][0].ToString();
         
                dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 27, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(LblFechaAUX.Text), "PORCENTAGE");
                LblPlant1.Text = dt.Rows[0][0].ToString();

                dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 28, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(LblFechaAUX.Text), "PORCENTAGE");
                LblMacolla1.Text = dt.Rows[0][0].ToString();

                dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 29, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(LblFechaAUX.Text), "PORCENTAGE");
                LblEmbu1.Text = dt.Rows[0][0].ToString();

                dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 30, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(LblFechaAUX.Text), "PORCENTAGE");
                LblEspi1.Text = dt.Rows[0][0].ToString();

                dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 31, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(LblFechaAUX.Text), "PORCENTAGE");
                LblFlora1.Text = dt.Rows[0][0].ToString();

                dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 32, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(LblFechaAUX.Text), "PORCENTAGE");
                LblGrano1.Text = dt.Rows[0][0].ToString();

                dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 33, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(LblFechaAUX.Text), "PORCENTAGE");
                LblMadura1.Text = dt.Rows[0][0].ToString();

                LblSuma.Text =(Convert.ToDecimal(LblGer1.Text)+Convert.ToDecimal(LblPlant1.Text)+Convert.ToDecimal(LblMacolla1.Text)+Convert.ToDecimal(LblEmbu1.Text)+Convert.ToDecimal(LblEspi1.Text)+Convert.ToDecimal(LblFlora1.Text)+Convert.ToDecimal(LblGrano1.Text)+Convert.ToDecimal(LblMadura1.Text)).ToString();
                if(Convert.ToDateTime(LblFechaAUX.Text) <= Convert.ToDateTime(LblFIniSiem.Text))
                {
                    break;
                }

                LblFechaAUX.Text = (Convert.ToDateTime(LblFechaAUX.Text)).AddDays(-7).ToString("dd/MM/yyyy");
            }
            while (Convert.ToDecimal(LblSuma.Text) <= 0 );

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 34, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text), "PORCENTAGE_COSECHA");
            LblCosAco1.Text = dt.Rows[0][0].ToString();

            LblMadura1.Text = (Convert.ToDecimal(LblMadura1.Text)-Convert.ToDecimal(LblCosAco1.Text)).ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 34, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text), "RENDIMIENTO");
            LblCosAco2.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 35, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text), "FECHAACOPIO");
            LblFcosechaIni.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 35, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text), "FECHAACOPIO");
            LblFcosechaFin.Text = dt.Rows[0][0].ToString();

        }
        #endregion
        #region FUNCION DE REGISTRO DEL SEGUIMIENTO
        protected void Registrar_ETAPA_FENOLOGICA()
        {
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            DB_EXT_Fenologia regfen = new DB_EXT_Fenologia();
            EXT_FaceFenologicaCultivo fenCultivo = new EXT_FaceFenologicaCultivo();
            EXT_FaceFenologiaTrigo fenTrigo = new EXT_FaceFenologiaTrigo();
            fenCultivo.Id_Campanhia = Convert.ToInt32(LblIdCamp.Text);
            fenCultivo.Id_Regional = Convert.ToInt32(LblIdReg.Text);
            fenCultivo.Id_InscripcionOrg = Convert.ToInt32(LblIdInsOrg.Text);
            fenCultivo.Id_Usuario = LblIdUsuario.Text;
            fenCultivo.Programa = LblProg.Text;
            fenCultivo.Fecha_Registro = DateTime.Now;
            fenCultivo.Num_Boletas_Inspec = Convert.ToInt32(TxtBoletasFisicas.Text);
            fenCultivo.Charla_Tecnica = DDLHuboCharla.SelectedValue;
            fenCultivo.Num_Prod_Vigentes = Convert.ToInt32(TxtNumBenefVig.Text);
            fenCultivo.Sup_Actual = Convert.ToDecimal(TxtSupAct.Text);
            fenCultivo.Variedad_Semilla = TxtVariedadSem.Text;
            fenCultivo.Observacion = TxtObserv.Text;
            fenCultivo.Num_Seg_Cultivo = 0;
            fenCultivo.Num_Boletas_Monitoreo=Convert.ToInt32(TxtBoletasMonitoreo.Text);
            fenCultivo.Precipitacion_Pluvial = Convert.ToInt32(TxtPPmm.Text);
            fenCultivo.Fecha_Semana_Envio = Convert.ToDateTime(TxtFechaIni.Text);
            regfen.DB_Registrar_FACE_FENOLOGICA_CULTIVO(fenCultivo);
            /*************************************** RESGISTRO FENOLOGIA PROGRAMA TRIGO MUESTRA ********************************************/
            fenTrigo.Id_Face_Feonologica = Convert.ToInt32(aux.DB_MaxId("EXT_FACE_FENOLOGICA_CULTIVO", "Id_Face_Feonologica")); ;
            fenTrigo.FechaAvnSiemIni = LblFIniSiem.Text;
            fenTrigo.FechaAvnSiemFin = LblFFinSiem.Text;
            fenTrigo.FechaAvnSiemAvan = Convert.ToDecimal(LblAvnSiem.Text);
            fenTrigo.GerminacionIni = Convert.ToDecimal(LblGer1.Text);
            fenTrigo.PlantulaIni = Convert.ToDecimal(LblPlant1.Text);
            fenTrigo.MacollamientoIni = Convert.ToDecimal(LblMacolla1.Text);
            fenTrigo.EmbucheIni = Convert.ToDecimal(LblEmbu1.Text);
            fenTrigo.EspigazonIni = Convert.ToDecimal(LblEspi1.Text);
            fenTrigo.FloracionIni = Convert.ToDecimal(LblFlora1.Text);
            fenTrigo.LlenadoGranoIni = Convert.ToDecimal(LblGrano1.Text);
            fenTrigo.MaduracionIni = Convert.ToDecimal(LblMadura1.Text);
            fenTrigo.CosechaAcopioAvan = Convert.ToDecimal(LblCosAco1.Text);
            fenTrigo.CosechaAcopioRend = Convert.ToDecimal(LblCosAco2.Text);
            fenTrigo.FechaCosechaIni = LblFcosechaIni.Text;
            fenTrigo.FechaCosechaFin = LblFcosechaFin.Text;
            fenTrigo.Tipo = "MUESTRA";
            fenTrigo.SupSem = Convert.ToDecimal(LblSupSem.Text);
            regfen.DB_Registrar_FACE_FENOLOGICA_TRIGO(fenTrigo);
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (TxtPPmm.Text != "")
            {
                Registrar_ETAPA_FENOLOGICA();
                Response.Redirect("frmListaSegFenologia.aspx");
            }
            else
            {
                LblMsj.Text = "ERROR: Es necesario especificar la precipitación pluvial en esta etapa";
            }
        }
        #endregion

        protected void DDLNumSeg_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblNumSeg.Text = DDLNumSeg.SelectedValue;
            Datos_CULTIVO();
        }

        protected void TxtFechaIni_TextChanged(object sender, EventArgs e)
        {
            LblFechaFin.Text = (Convert.ToDateTime(TxtFechaIni.Text)).AddDays(-8).ToString("dd/MM/yyyy");
            Datos_CULTIVO();
        }

        //protected void TxtAvnSiem_TextChanged(object sender, EventArgs e)
        //{
        //    TxtSupSem.Text = Convert.ToString(Math.Round(((Convert.ToDecimal(TxtAvnSiem.Text) * Convert.ToDecimal(TxtSupApo.Text)) / 100), 2));
        //}
    }
}