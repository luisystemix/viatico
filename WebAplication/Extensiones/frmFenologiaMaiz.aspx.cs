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
    public partial class frmFenologiaMaiz : System.Web.UI.Page
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
                    if(TxtNumBoletas.Text=="")
                    {
                        TxtNumBoletas.Enabled = false;
                        BtnEnviar.Enabled = false;
                    }
                }
            //}
            //catch
            //{
            //   Response.Redirect("~/About.aspx");
            //}
        }
        #region
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
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Datos_CULTIVO()
        {
            DB_EXT_Fenologia numBol = new DB_EXT_Fenologia();
            DataTable dt = new DataTable();


            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 0, Convert.ToInt32(LblIdReg.Text), "MAIZ", "", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"NUM_BOLETAS");
            TxtNumBoletas.Text = dt.Rows[0][0].ToString();


            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 11, Convert.ToInt32(LblIdReg.Text), "MAIZ", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text), "AVANCE_SIEMBRA");
            LblAvnSiem.Text = dt.Rows[0][0].ToString();
            LblSupSem.Text = Convert.ToString(Math.Round(((Convert.ToDecimal(LblAvnSiem.Text) * Convert.ToDecimal(TxtSupApo.Text)) / 100), 2));


            dt = numBol.DB_Datos_SIEMBRA(Convert.ToInt32(LblIdInsOrg.Text), "MAIZ", "VARIEDADES");
            if (dt.Rows.Count > 0)
            {
                TxtVariedadSem.Text = dt.Rows[0][0].ToString();
            }
            dt = numBol.DB_Datos_SIEMBRA(Convert.ToInt32(LblIdInsOrg.Text), "MAIZ", "FECHAMAXMIN");
            if (dt.Rows.Count > 0)
            {
                LblFIniSiem.Text = dt.Rows[0][0].ToString();
                LblFFinSiem.Text = dt.Rows[0][1].ToString();
            }
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 12, Convert.ToInt32(LblIdReg.Text), "MAIZ", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblEmerg.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 13, Convert.ToInt32(LblIdReg.Text), "MAIZ", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            Lbl1y2Hojas.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 14, Convert.ToInt32(LblIdReg.Text), "MAIZ", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            Lbl3y4Hojas.Text = dt.Rows[0][0].ToString();
            
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 15, Convert.ToInt32(LblIdReg.Text), "MAIZ", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            Lbl5y6Hojas.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 16, Convert.ToInt32(LblIdReg.Text), "MAIZ", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            Lbl7y8Hojas.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 17, Convert.ToInt32(LblIdReg.Text), "MAIZ", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            Lbl9y10Hojas.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 18, Convert.ToInt32(LblIdReg.Text), "MAIZ", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            Lbl11oMasHojas.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 19, Convert.ToInt32(LblIdReg.Text), "MAIZ", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblFloracion.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 20, Convert.ToInt32(LblIdReg.Text), "MAIZ", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblEstigmas.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 21, Convert.ToInt32(LblIdReg.Text), "MAIZ", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblGranoLechoso.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 22, Convert.ToInt32(LblIdReg.Text), "MAIZ", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblDentadayMadurez.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 23, Convert.ToInt32(LblIdReg.Text), "MAIZ", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblCosAco1.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 23, Convert.ToInt32(LblIdReg.Text), "MAIZ", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"RENDIMIENTO");
            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 9, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Avance", 0, "RENDIMIENTO");
            LblCosAco2.Text = dt.Rows[0][0].ToString();

            /******************************** FALTA EL RENDIMIENTO  **********************************

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text),35, Convert.ToInt32(LblIdReg.Text),"TRIGO", "Inicial", 1, "FECHAACOPIO");
            TxtFcosechaIni.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text),35, Convert.ToInt32(LblIdReg.Text),"TRIGO", "Final", 1, "FECHAACOPIO");
            TxtFcosechaFin.Text = dt.Rows[0][0].ToString();*/
        }
        #endregion
        #region FUNCION DE REGISTRO DEL SEGUIMIENTO
        protected void Registrar_ETAPA_FENOLOGICA()
        {
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            DB_EXT_Fenologia regfen = new DB_EXT_Fenologia();
            EXT_FaceFenologicaCultivo fenCultivo = new EXT_FaceFenologicaCultivo();
            EXT_FaceFenologiaMaiz fenMaiz = new EXT_FaceFenologiaMaiz();
            fenCultivo.Id_Campanhia = Convert.ToInt32(LblIdCamp.Text);
            fenCultivo.Id_Regional = Convert.ToInt32(LblIdReg.Text);
            fenCultivo.Id_InscripcionOrg = Convert.ToInt32(LblIdInsOrg.Text);
            fenCultivo.Id_Usuario = LblIdUsuario.Text;
            fenCultivo.Programa = LblProg.Text;
            fenCultivo.Fecha_Registro = DateTime.Now;
            fenCultivo.Num_Boletas_Inspec = Convert.ToInt32(TxtNumBoletas.Text);
            fenCultivo.Charla_Tecnica = DDLHuboCharla.SelectedValue;
            fenCultivo.Num_Prod_Vigentes = Convert.ToInt32(TxtNumBenefVig.Text);
            fenCultivo.Sup_Actual = Convert.ToDecimal(TxtSupAct.Text);
            fenCultivo.Variedad_Semilla = TxtVariedadSem.Text;
            fenCultivo.Observacion = TxtObserv.Text;
            fenCultivo.Num_Seg_Cultivo = Convert.ToInt32(LblNumSeg.Text);
            regfen.DB_Registrar_FACE_FENOLOGICA_CULTIVO(fenCultivo);
            /*************************************** RESGISTRO FENOLOGIA PROGRAMA MAIZ MUESTRA ********************************************/
            fenMaiz.Id_Face_Feonologica = Convert.ToInt32(aux.DB_MaxId("EXT_FACE_FENOLOGICA_CULTIVO", "Id_Face_Feonologica")); ;
            fenMaiz.FechaAvnSiemIni = LblFIniSiem.Text;
            fenMaiz.FechaAvnSiemFin = LblFFinSiem.Text;
            fenMaiz.FechaAvnSiemAvan = Convert.ToDecimal(LblAvnSiem.Text);
            fenMaiz.Emergencia5dias = Convert.ToDecimal(LblEmerg.Text);
            fenMaiz.HojasDesplegadas1y2 = Convert.ToDecimal(Lbl1y2Hojas.Text);
            fenMaiz.HojasDesplegadas3y4 = Convert.ToDecimal(Lbl3y4Hojas.Text);
            fenMaiz.HojasDesplegadas5y6 = Convert.ToDecimal(Lbl5y6Hojas.Text);
            fenMaiz.HojasDesplegadas7y8 = Convert.ToDecimal(Lbl7y8Hojas.Text);
            fenMaiz.HojasDesplegadas9y10 = Convert.ToDecimal(Lbl9y10Hojas.Text);
            fenMaiz.HojasDesplegadas11oMas = Convert.ToDecimal(Lbl11oMasHojas.Text);
            fenMaiz.FloracionyPolinizacion = Convert.ToDecimal(LblFloracion.Text);
            fenMaiz.EstigmasVisiblesyAmpolla = Convert.ToDecimal(LblEstigmas.Text);
            fenMaiz.GranoLechosoyMasoso = Convert.ToDecimal(LblGranoLechoso.Text);
            fenMaiz.EtapaDentadayMadurez = Convert.ToDecimal(LblDentadayMadurez.Text);
            fenMaiz.CosechaAcopioAvan = Convert.ToDecimal(LblCosAco1.Text);
            fenMaiz.CosechaAcopioRend = Convert.ToDecimal(LblCosAco2.Text);
            fenMaiz.FechaCosechaIni = LblFcosechaIni.Text;
            fenMaiz.FechaCosechaFin = LblFcosechaFin.Text;
            fenMaiz.Tipo = "MUESTRA";
            fenMaiz.SupSem = Convert.ToDecimal(LblSupSem.Text);
            regfen.DB_Registrar_FACE_FENOLOGICA_MAIZ(fenMaiz);
            /*************************************** RESGISTRO FENOLOGIA PROGRAMA MAIZ GLOBAL ********************************************/
            fenMaiz.Id_Face_Feonologica = Convert.ToInt32(aux.DB_MaxId("EXT_FACE_FENOLOGICA_CULTIVO", "Id_Face_Feonologica")); ;
            fenMaiz.FechaAvnSiemIni = TxtFIniSiem.Text;
            fenMaiz.FechaAvnSiemFin = TxtFFinSiem.Text;
            fenMaiz.FechaAvnSiemAvan = Convert.ToDecimal(TxtAvnSiem.Text);
            fenMaiz.Emergencia5dias = Convert.ToDecimal(TxtEmerg.Text);
            fenMaiz.HojasDesplegadas1y2 = Convert.ToDecimal(Txt1y2Hojas.Text);
            fenMaiz.HojasDesplegadas3y4 = Convert.ToDecimal(Txt3y4Hojas.Text);
            fenMaiz.HojasDesplegadas5y6 = Convert.ToDecimal(Txt5y6Hojas.Text);
            fenMaiz.HojasDesplegadas7y8 = Convert.ToDecimal(Txt7y8Hojas.Text);
            fenMaiz.HojasDesplegadas9y10 = Convert.ToDecimal(Txt9y10Hojas.Text);
            fenMaiz.HojasDesplegadas11oMas = Convert.ToDecimal(Txt11oMasHojas.Text);
            fenMaiz.FloracionyPolinizacion = Convert.ToDecimal(TxtFloracion.Text);
            fenMaiz.EstigmasVisiblesyAmpolla = Convert.ToDecimal(TxtEstigmas.Text);
            fenMaiz.GranoLechosoyMasoso = Convert.ToDecimal(TxtGranoLechoso.Text);
            fenMaiz.EtapaDentadayMadurez = Convert.ToDecimal(TxtDentadayMadurez.Text);
            fenMaiz.CosechaAcopioAvan = Convert.ToDecimal(TxtCosAco1.Text);
            fenMaiz.CosechaAcopioRend = Convert.ToDecimal(TxtCosAco2.Text);
            fenMaiz.FechaCosechaIni = TxtFcosechaIni.Text;
            fenMaiz.FechaCosechaFin = TxtFcosechaFin.Text;
            fenMaiz.Tipo = "GLOBAL";
            fenMaiz.SupSem = Convert.ToDecimal(TxtSupSem.Text);
            regfen.DB_Registrar_FACE_FENOLOGICA_MAIZ(fenMaiz);
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (TxtPPmm.Text != "")
            {
                Registrar_ETAPA_FENOLOGICA();
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

        protected void TxtFechaIni_TextChanged(object sender, EventArgs e)
        {
            LblFechaFin.Text = (Convert.ToDateTime(TxtFechaIni.Text)).AddDays(-8).ToString("dd/MM/yyyy");
            Datos_CULTIVO();
        }
    }
}