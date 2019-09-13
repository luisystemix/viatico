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
    public partial class frmFenologiaArroz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                if (!IsPostBack)
                {
                    LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    Datos_Org_ENCABEZADO();
                    Datos_CULTIVO();
                    LblFechaRep.Text = DateTime.Now.ToString();
                    if (TxtNumBoletas.Text == "")
                    {
                        TxtNumBoletas.Enabled = false;
                        BtnEnviar.Enabled = false;
                    }
                }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        #region
        private void Cargar_NUM_SEGUIMIENTOS()
        {
            DB_EXT_Fenologia numBol = new DB_EXT_Fenologia();
            DataTable dt = new DataTable();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 0, Convert.ToInt32(LblIdReg.Text), "0", "0", 0, Convert.ToDateTime(TxtFechaIni.Text),"NUM_SEGUIMIENTOS");
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
                TxtSupApo.Text=dt.Rows[0][2].ToString();
            }
        }
        #endregion
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Datos_CULTIVO()
        {
            DB_EXT_Fenologia numBol = new DB_EXT_Fenologia();
            DataTable dt = new DataTable();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 0, Convert.ToInt32(LblIdReg.Text), "ARROZ", "", 1, Convert.ToDateTime(TxtFechaIni.Text), "NUM_BOLETAS");
            TxtNumBoletas.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 1, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Avance", 1, Convert.ToDateTime(TxtFechaIni.Text), "AVANCE_SIEMBRA");
            LblAvnSiem.Text = dt.Rows[0][0].ToString();
            TxtAvnSiem.Text = LblAvnSiem.Text;
            LblSupSem.Text = Convert.ToString(Math.Round(((Convert.ToDecimal(LblAvnSiem.Text) * Convert.ToDecimal(TxtSupApo.Text)) / 100),2));
            TxtSupSem.Text = LblSupSem.Text;

            dt = numBol.DB_Datos_SIEMBRA(Convert.ToInt32(LblIdInsOrg.Text), "ARROZ", "VARIEDADES");
            if (dt.Rows.Count > 0)
            {
                TxtVariedadSem.Text = dt.Rows[0][0].ToString();
            }

            dt = numBol.DB_Datos_SIEMBRA(Convert.ToInt32(LblIdInsOrg.Text), "ARROZ", "FECHAMAXMIN");
            if (dt.Rows.Count > 0)
            {
                LblFIniSiem.Text = dt.Rows[0][0].ToString();
                TxtFIniSiem.Text = dt.Rows[0][0].ToString();
                LblFFinSiem.Text = dt.Rows[0][1].ToString();
                TxtFFinSiem.Text = dt.Rows[0][1].ToString();
            }
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 2, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Inicial", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblGer1.Text = dt.Rows[0][0].ToString();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 2, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Final", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblGer2.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 3, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Inicial", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblPlant1.Text = dt.Rows[0][0].ToString();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 3, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Final", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblPlant2.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 4, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Inicial", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblMacolla1.Text = dt.Rows[0][0].ToString();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 4, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Final", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblMacolla2.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 5, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Inicial", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblPanicula1.Text = dt.Rows[0][0].ToString();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 5, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Final", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblPanicula2.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 6, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Inicial", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblFlora1.Text = dt.Rows[0][0].ToString();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 6, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Final", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblFlora2.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 7, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Inicial", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblGrano1.Text = dt.Rows[0][0].ToString();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 7, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Final", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblGrano2.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 8, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Inicial", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblMadura1.Text = dt.Rows[0][0].ToString();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 8, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Final", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblMadura2.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 9, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblCosAco1.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 9, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"RENDIMIENTO");
            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 9, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Avance", 0, "RENDIMIENTO");
            LblCosAco2.Text = dt.Rows[0][0].ToString();

            //******************************** FALTA FECHAS   **********************************/
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 10, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Inicial", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"FECHAACOPIO");
            LblFcosechaIni.Text = dt.Rows[0][0].ToString();
            TxtFcosechaIni.Text = dt.Rows[0][0].ToString();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 10, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Final", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"FECHAACOPIO");
            LblFcosechaFin.Text = dt.Rows[0][0].ToString();
            TxtFcosechaFin.Text = dt.Rows[0][0].ToString();
        }
        #endregion
        #region FUNCION DE REGISTRO DEL SEGUIMIENTO
        protected void Registrar_ETAPA_FENOLOGICA()
        {
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            DB_EXT_Fenologia regfen = new DB_EXT_Fenologia();
            EXT_FaceFenologicaCultivo fenCultivo = new EXT_FaceFenologicaCultivo();
            EXT_FaceFenologiaArroz fenArroz = new EXT_FaceFenologiaArroz();
            fenCultivo.Id_Campanhia = Convert.ToInt32(LblIdCamp.Text);
            fenCultivo.Id_Regional = Convert.ToInt32(LblIdReg.Text);
            fenCultivo.Id_InscripcionOrg = Convert.ToInt32(LblIdInsOrg.Text);
            fenCultivo.Id_Usuario = LblIdUsuario.Text;
            fenCultivo.Programa = LblProg.Text;
            fenCultivo.Fecha_Registro = DateTime.Now;
            fenCultivo.Num_Boletas_Inspec = Convert.ToInt32(TxtNumBoletas.Text);
            fenCultivo.Charla_Tecnica = DDLHuboCharla.SelectedValue;
            fenCultivo.Num_Prod_Vigentes = Convert.ToInt32(TxtNumBenefVig.Text);
            fenCultivo.Sup_Actual = Convert.ToDecimal(TxtSupApo.Text);
            fenCultivo.Variedad_Semilla = TxtVariedadSem.Text;
            fenCultivo.Observacion = TxtObserv.Text;
            fenCultivo.Num_Seg_Cultivo = Convert.ToInt32(LblNumSeg.Text);
            regfen.DB_Registrar_FACE_FENOLOGICA_CULTIVO(fenCultivo);
            /*************************************** RESGISTRO FENOLOGIA PROGRAMA ARROZ MUESTRA ********************************************/
            fenArroz.Id_Face_Feonologica = Convert.ToInt32(aux.DB_MaxId("EXT_FACE_FENOLOGICA_CULTIVO", "Id_Face_Feonologica")); ;
            fenArroz.FechaAvnSiemIni = LblFIniSiem.Text;
            fenArroz.FechaAvnSiemFin = LblFFinSiem.Text;
            fenArroz.FechaAvnSiemAvan = Convert.ToDecimal(LblAvnSiem.Text);
            fenArroz.GerminacionIni = Convert.ToDecimal(LblGer1.Text);
            fenArroz.GerminacionFin = Convert.ToDecimal(LblGer2.Text);
            fenArroz.PlantulaIni = Convert.ToDecimal(LblPlant1.Text);
            fenArroz.PlantulaFin = Convert.ToDecimal(LblPlant2.Text);
            fenArroz.MacollamientoIni = Convert.ToDecimal(LblMacolla1.Text);
            fenArroz.MacollamientoFin = Convert.ToDecimal(LblMacolla2.Text);
            fenArroz.PaniculaIni = Convert.ToDecimal(LblPanicula1.Text);
            fenArroz.PaniculaFin = Convert.ToDecimal(LblPanicula2.Text);
            fenArroz.FloracionIni = Convert.ToDecimal(LblFlora1.Text);
            fenArroz.FloracionFin = Convert.ToDecimal(LblFlora2.Text);
            fenArroz.GranoLechosoIni = Convert.ToDecimal(LblGrano1.Text);
            fenArroz.GranoLechosoFin = Convert.ToDecimal(LblGrano2.Text);
            fenArroz.MaduracionIni = Convert.ToDecimal(LblMadura1.Text);
            fenArroz.MaduracionFin = Convert.ToDecimal(LblMadura2.Text);
            fenArroz.CosechaAcopioAvan = Convert.ToDecimal(LblCosAco1.Text);
            fenArroz.CosechaAcopioRend = Convert.ToDecimal(LblCosAco2.Text);
            fenArroz.FechaCosechaIni = LblFcosechaIni.Text;
            fenArroz.FechaCosechaFin = LblFcosechaFin.Text;
            fenArroz.Tipo = "MUESTRA";
            fenArroz.SupSem = Convert.ToDecimal(LblSupSem.Text);
            regfen.DB_Registrar_FACE_FENOLOGICA_ARROZ(fenArroz);
            /*************************************** RESGISTRO FENOLOGIA PROGRAMA ARROZ GLOBAL********************************************/
            fenArroz.Id_Face_Feonologica = Convert.ToInt32(aux.DB_MaxId("EXT_FACE_FENOLOGICA_CULTIVO", "Id_Face_Feonologica")); ;
            fenArroz.FechaAvnSiemIni = TxtFIniSiem.Text;
            fenArroz.FechaAvnSiemFin = TxtFFinSiem.Text;
            fenArroz.FechaAvnSiemAvan = Convert.ToDecimal(TxtAvnSiem.Text);
            fenArroz.GerminacionIni = Convert.ToDecimal(TxtGer1.Text);
            fenArroz.GerminacionFin = Convert.ToDecimal(TxtGer2.Text);
            fenArroz.PlantulaIni = Convert.ToDecimal(TxtPlant1.Text);
            fenArroz.PlantulaFin = Convert.ToDecimal(TxtPlant2.Text);
            fenArroz.MacollamientoIni = Convert.ToDecimal(TxtMacolla1.Text);
            fenArroz.MacollamientoFin = Convert.ToDecimal(TxtMacolla2.Text);
            fenArroz.PaniculaIni = Convert.ToDecimal(TxtPanicula1.Text);
            fenArroz.PaniculaFin = Convert.ToDecimal(TxtPanicula2.Text);
            fenArroz.FloracionIni = Convert.ToDecimal(TxtFlora1.Text);
            fenArroz.FloracionFin = Convert.ToDecimal(TxtFlora2.Text);
            fenArroz.GranoLechosoIni = Convert.ToDecimal(TxtGrano1.Text);
            fenArroz.GranoLechosoFin = Convert.ToDecimal(TxtGrano2.Text);
            fenArroz.MaduracionIni = Convert.ToDecimal(TxtMadura1.Text);
            fenArroz.MaduracionFin = Convert.ToDecimal(TxtMadura2.Text);
            fenArroz.CosechaAcopioAvan = Convert.ToDecimal(TxtCosAco1.Text);
            fenArroz.CosechaAcopioRend = Convert.ToDecimal(TxtCosAco2.Text);
            fenArroz.FechaCosechaIni = TxtFcosechaIni.Text;
            fenArroz.FechaCosechaFin = TxtFcosechaFin.Text;
            fenArroz.Tipo = "GLOBAL";
            fenArroz.SupSem = Convert.ToDecimal(TxtSupSem.Text);
            regfen.DB_Registrar_FACE_FENOLOGICA_ARROZ(fenArroz);
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

        protected void TxtAvnSiem_TextChanged(object sender, EventArgs e)
        {
            TxtSupSem.Text = Convert.ToString(Math.Round(((Convert.ToDecimal(TxtAvnSiem.Text) * Convert.ToDecimal(TxtSupApo.Text)) / 100), 2));
        }
    }
}