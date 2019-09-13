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
    public partial class frmFenologiaTrigo : System.Web.UI.Page
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
                    if (TxtNumBoletas.Text == "")
                    {
                        TxtNumBoletas.Enabled = false;
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
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Datos_CULTIVO()
        {
            DB_EXT_Fenologia numBol = new DB_EXT_Fenologia();
            DataTable dt = new DataTable();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 0, Convert.ToInt32(LblIdReg.Text), "TRIGO", "", 1, DateTime.Now, "NUM_BOLETAS");
            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 0, Convert.ToInt32(LblIdReg.Text), "ARROZ", "", 0, "NUM_BOLETAS");
            TxtNumBoletas.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 25, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Avance", 1, DateTime.Now, "AVANCE_SIEMBRA");
            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 1, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Avance", 0, "AVANCE_SIEMBRA");
            LblAvnSiem.Text = dt.Rows[0][0].ToString();
            LblSupSem.Text = Convert.ToString(Math.Round(((Convert.ToDecimal(LblAvnSiem.Text) * Convert.ToDecimal(TxtSupApo.Text)) / 100), 2));

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
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 26, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblGer1.Text = dt.Rows[0][0].ToString();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 26, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblGer2.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 27, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblPlant1.Text = dt.Rows[0][0].ToString();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 27, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblPlant2.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 28, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblMacolla1.Text = dt.Rows[0][0].ToString();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 28, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblMacolla2.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 29, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblEmbu1.Text = dt.Rows[0][0].ToString();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 29, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblEmbu2.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 30, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblEspi1.Text = dt.Rows[0][0].ToString();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 30, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblEspi2.Text = dt.Rows[0][0].ToString();
            
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 31, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");        
            LblFlora1.Text = dt.Rows[0][0].ToString();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 31, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblFlora2.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 32, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblGrano1.Text = dt.Rows[0][0].ToString();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 32, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblGrano2.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 33, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblMadura1.Text = dt.Rows[0][0].ToString();
            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 33, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblMadura2.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 34, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text),"PORCENTAGE");
            LblCosAco1.Text = dt.Rows[0][0].ToString();

            dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 34, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Avance", Convert.ToInt32(LblNumSeg.Text), Convert.ToDateTime(TxtFechaIni.Text), "RENDIMIENTO");
            LblCosAco2.Text = dt.Rows[0][0].ToString();

            //******************************** FALTA FECHAS   **********************************/
            ////dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), 35, "ARROZ", "Inicial", Convert.ToInt32(LblNumSeg.Text), "FECHAACOPIO");
            ////TxtFcosechaIni.Text = dt.Rows[0][0].ToString();
            ////dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), 35, "ARROZ", "Final", Convert.ToInt32(LblNumSeg.Text), "FECHAACOPIO");
            ////TxtFcosechaFin.Text = dt.Rows[0][0].ToString();


            //DB_EXT_Fenologia numBol = new DB_EXT_Fenologia();
            //DataTable dt = new DataTable();

            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 0, Convert.ToInt32(LblIdReg.Text), "TRIGO", "", Convert.ToInt32(LblNumSeg.Text), "NUM_BOLETAS");
            //TxtNumBoletas.Text = dt.Rows[0][0].ToString();

            ////dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 0, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Avance", Convert.ToInt32(LblNumSeg.Text), "AVANCE_SIEMBRA");
            ////TxtAvnSiem.Text = dt.Rows[0][0].ToString();

            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 1, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Avance", 1, "AVANCE_SIEMBRA");
            ////dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 1, Convert.ToInt32(LblIdReg.Text), "ARROZ", "Avance", 0, "AVANCE_SIEMBRA");
            //LblAvnSiem.Text = dt.Rows[0][0].ToString();
            //LblSupSem.Text = Convert.ToString(Math.Round(((Convert.ToDecimal(LblAvnSiem.Text) * Convert.ToDecimal(TxtSupApo.Text)) / 100), 2));



            //dt = numBol.DB_Datos_SIEMBRA(Convert.ToInt32(LblIdInsOrg.Text), "TRIGO", "VARIEDADES");
            //if (dt.Rows.Count > 0)
            //{
            //    TxtVariedadSem.Text = dt.Rows[0][0].ToString();
            //}

            //dt = numBol.DB_Datos_SIEMBRA(Convert.ToInt32(LblIdInsOrg.Text), "TRIGO", "FECHAMAXMIN");
            //if (dt.Rows.Count > 0)
            //{
            //    TxtFIniSiem.Text = dt.Rows[0][0].ToString();
            //    TxtFFinSiem.Text = dt.Rows[0][1].ToString();
            //}
            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 26, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), "PORCENTAGE");
            //TxtGer1.Text = dt.Rows[0][0].ToString();
            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 26, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), "PORCENTAGE");
            //TxtGer2.Text = dt.Rows[0][0].ToString();

            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 27, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), "PORCENTAGE");
            //TxtPlant1.Text = dt.Rows[0][0].ToString();
            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 27, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), "PORCENTAGE");
            //TxtPlant2.Text = dt.Rows[0][0].ToString();

            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 28, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), "PORCENTAGE");
            //TxtMacolla1.Text = dt.Rows[0][0].ToString();
            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 28, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), "PORCENTAGE");
            //TxtMacolla2.Text = dt.Rows[0][0].ToString();

            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 29, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), "PORCENTAGE");
            //TxtEmbu1.Text = dt.Rows[0][0].ToString();
            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 29, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), "PORCENTAGE");
            //TxtEmbu2.Text = dt.Rows[0][0].ToString();

            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 30, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), "PORCENTAGE");
            //TxtEspi1.Text = dt.Rows[0][0].ToString();
            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 30, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), "PORCENTAGE");
            //TxtEspi2.Text = dt.Rows[0][0].ToString();

            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 31, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), "PORCENTAGE");
            //TxtFlora1.Text = dt.Rows[0][0].ToString();
            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 31, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), "PORCENTAGE");
            //TxtFlora2.Text = dt.Rows[0][0].ToString();

            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 32, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), "PORCENTAGE");
            //TxtGrano1.Text = dt.Rows[0][0].ToString();
            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 32, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), "PORCENTAGE");
            //TxtGrano2.Text = dt.Rows[0][0].ToString();

            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 33, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), "PORCENTAGE");
            //TxtMadura1.Text = dt.Rows[0][0].ToString();
            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 33, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), "PORCENTAGE");
            //TxtMadura2.Text = dt.Rows[0][0].ToString();

            //dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), Convert.ToInt32(LblIdCamp.Text), 34, Convert.ToInt32(LblIdReg.Text), "TRIGO", "Avance", Convert.ToInt32(LblNumSeg.Text), "PORCENTAGE");
            //TxtCosAco1.Text = dt.Rows[0][0].ToString();

            /////******************************** FALTA EL RENDIMIENTO  **********************************/

            ////dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), 35, "TRIGO", "Inicial", Convert.ToInt32(LblNumSeg.Text), "FECHAACOPIO");
            ////TxtFcosechaIni.Text = dt.Rows[0][0].ToString();

            ////dt = numBol.DB_Datos_FACE_FENOLOGICA(Convert.ToInt32(LblIdInsOrg.Text), 35, "TRIGO", "Final", Convert.ToInt32(LblNumSeg.Text), "FECHAACOPIO");
            ////TxtFcosechaFin.Text = dt.Rows[0][0].ToString();
        }
        #endregion
        #region FUNCION DE REGISTRO DEL SEGUIMIENTO
        protected void Registrar_ETAPA_FENOLOGICA()
        {
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            DB_EXT_Fenologia regfen = new DB_EXT_Fenologia();
            EXT_FaceFenologicaCultivo fenCultivo =new EXT_FaceFenologicaCultivo();
            EXT_FaceFenologiaTrigo fenTrigo = new EXT_FaceFenologiaTrigo();
            fenCultivo.Id_Campanhia = Convert.ToInt32(LblIdCamp.Text);
            fenCultivo.Id_Regional=Convert.ToInt32(LblIdReg.Text);
            fenCultivo.Id_InscripcionOrg=Convert.ToInt32(LblIdInsOrg.Text);
            fenCultivo.Id_Usuario = LblIdUsuario.Text;
            fenCultivo.Programa = LblProg.Text;
            fenCultivo.Fecha_Registro = DateTime.Now;
            fenCultivo.Num_Boletas_Inspec = Convert.ToInt32(TxtNumBoletas.Text);
            fenCultivo.Charla_Tecnica=DDLHuboCharla.SelectedValue;
            fenCultivo.Num_Prod_Vigentes = Convert.ToInt32(TxtNumBenefVig.Text);
            fenCultivo.Sup_Actual=Convert.ToDecimal(TxtSupAct.Text);
            fenCultivo.Variedad_Semilla=TxtVariedadSem.Text;
            fenCultivo.Observacion =TxtObserv.Text;
            fenCultivo.Num_Seg_Cultivo=0;
            regfen.DB_Registrar_FACE_FENOLOGICA_CULTIVO(fenCultivo);
 /*************************************** RESGISTRO FENOLOGIA PROGRAMA TRIGO MUESTRA ********************************************/           
            fenTrigo.Id_Face_Feonologica = Convert.ToInt32(aux.DB_MaxId("EXT_FACE_FENOLOGICA_CULTIVO", "Id_Face_Feonologica")); ;
            fenTrigo.FechaAvnSiemIni = LblFIniSiem.Text;
            fenTrigo.FechaAvnSiemFin = LblFFinSiem.Text;
            fenTrigo.FechaAvnSiemAvan = Convert.ToDecimal(LblAvnSiem.Text);
            fenTrigo.GerminacionIni = Convert.ToDecimal(LblGer1.Text);
            fenTrigo.GerminacionFin = Convert.ToDecimal(LblGer2.Text);
            fenTrigo.PlantulaIni = Convert.ToDecimal(LblPlant1.Text);
            fenTrigo.PlantulaFin = Convert.ToDecimal(LblPlant2.Text);
            fenTrigo.MacollamientoIni = Convert.ToDecimal(LblMacolla1.Text);
            fenTrigo.MacollamientoFin = Convert.ToDecimal(LblMacolla2.Text);
            fenTrigo.EmbucheIni = Convert.ToDecimal(LblEmbu1.Text);
            fenTrigo.EmbucheFin = Convert.ToDecimal(LblEmbu2.Text);
            fenTrigo.EspigazonIni = Convert.ToDecimal(LblEspi1.Text);
            fenTrigo.EspigazonFin = Convert.ToDecimal(LblEspi2.Text);
            fenTrigo.FloracionIni = Convert.ToDecimal(LblFlora1.Text);
            fenTrigo.FloracionFin = Convert.ToDecimal(LblFlora2.Text);
            fenTrigo.LlenadoGranoIni = Convert.ToDecimal(LblGrano1.Text);
            fenTrigo.LlenadoGranoFin = Convert.ToDecimal(LblGrano2.Text);
            fenTrigo.MaduracionIni = Convert.ToDecimal(LblMadura1.Text);
            fenTrigo.MaduracionFin = Convert.ToDecimal(LblMadura2.Text);
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
            if(TxtPPmm.Text!="")
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