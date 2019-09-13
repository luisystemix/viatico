using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.DA_Registro;
using DataEntity.DE_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_Incripcion_Prod
    {
        #region REGISTRAR LOS DATOS DE UNA PERSONA
        public void DB_Registrar_AP_INSCRIPCION_PROD(AP_Productor p)
        {
            DA_AP_Inscripcion_Prod Ins = new DA_AP_Inscripcion_Prod();
            Ins.DA_Registrar_AP_INSCRIPCION_PROD(p);
        }
        #endregion
        #region GENERAR CODIGO DE PROGRAMA Y REGIONAL
        public String DB_PROGRAMA_REGIONAL(String pro, String reg)
        {
            String Cod = "";
            switch (pro)
            {
                case "ARROZ":
                    Cod = "ARZ";
                    break;
                case "SOYA":
                    Cod = "SOY";
                    break;
                case "MAIZ":
                    Cod = "MAI";
                    break;
                case "TRIGO":
                    Cod = "TRI";
                    break;
                default:
                    Cod = "";
                    break;
            }
            if (Cod != "")
            {
                switch (reg)
                {
                    case "LA PAZ":
                        Cod = Cod + "LP";
                        break;
                    case "YACUIBA":
                        Cod = Cod + "YB";
                        break;
                    case "TARIJA":
                        Cod = Cod + "TJ";
                        break;
                    case "COCHABAMBA":
                        Cod = Cod + "CB";
                        break;
                    case "SANTA CRUZ":
                        Cod = Cod + "SC";
                        break;
                    case "BENI":
                        Cod = Cod + "BE";
                        break;
                    case "PANDO":
                        Cod = Cod + "PA";
                        break;
                    case "ORURO":
                        Cod = Cod + "OR";
                        break;
                    case "POTOSI":
                        Cod = Cod + "PT";
                        break;
                    case "CHUQUISACA":
                        Cod = Cod + "CH";
                        break;
                    default:
                        Cod = "";
                        break;
                }
            }
            return Cod;
        }
        #endregion
        #region GENERA CADENA de PROGRAMA REGIONAL
        public String DB_GeneraCodigo2_AP_INSCRIPCION_PRO(Int32 idInscripcionOrg)
        {
            DA_AP_Inscripcion_Prod_Update dat = new DA_AP_Inscripcion_Prod_Update();
            String Prog = "";
            String Reg = "";
            dat.DA_Extraer_AP_INSCRIPCION_ORG_REGIONAL(idInscripcionOrg, ref Prog, ref Reg);
            String Cod = DB_PROGRAMA_REGIONAL(Prog, Reg);
            return Cod;
        }
        #endregion
        #region GENERA CADENA SIGUIENTE DE NUMERO
        public String DB_GeneraCodig_AP_INSCRIPCION_PRO(Int32 Id_NUN)
        {
            String cad = "";
            if (Id_NUN > 0 && Id_NUN <= 9)
            {
                cad = "0000" + Convert.ToString(Id_NUN);
            }
            if (Id_NUN > 9 && Id_NUN <= 99)
            {
                cad = "000" + Convert.ToString(Id_NUN);
            }
            if (Id_NUN > 99 && Id_NUN <= 999)
            {
                cad = "00" + Convert.ToString(Id_NUN);
            }
            if (Id_NUN > 999 && Id_NUN <= 9999)
            {
                cad = "0" + Convert.ToString(Id_NUN);
            }
            if (Id_NUN > 9999)
            {
                cad = Convert.ToString(Id_NUN);
            }
            return cad;
        }
        #endregion
        #region GENERA CADENA SIGUIENTE DE NUMERO
        public String DB_GeneraCodig_CAMPANHIA(Int32 Id_CAMPANHIA)
        {
            String cad = "";
            if (Id_CAMPANHIA >= 0 && Id_CAMPANHIA <= 9)
            {
                cad = "0" + Convert.ToString(Id_CAMPANHIA);
            }
            else
            {
                cad = Convert.ToString(Id_CAMPANHIA);
            }
            return cad;
        }
        #endregion
        #region GENERA CODIGO POR CAMPANHIA
        public String DB_GeneraCodigo_AP_INSCRIPCION_PRO(Int32 Id_Campanhia, Int32 Id_InscripcionOrg, String Programa)
        {
            DA_AP_Inscripcion_Prod dat = new DA_AP_Inscripcion_Prod();
            Int32 sig = dat.DA_SELEC_MAX_COD_AP_INSCIPCION_PROD(Id_InscripcionOrg, Id_Campanhia, Programa);
            String codigo = DB_GeneraCodigo2_AP_INSCRIPCION_PRO(Id_InscripcionOrg) + DB_GeneraCodig_CAMPANHIA(Id_Campanhia) + "-" + DB_GeneraCodig_AP_INSCRIPCION_PRO(sig);
            return codigo;
        }
        #endregion

        #region MODIFICAR LOS DOCUMENTOS PRESENTADOS POR LA ORGANIZACION
        public void DB_Modificar_ESTADO(AP_InscripcionProd ip)
        {
            DA_AP_Inscripcion_Prod prod = new DA_AP_Inscripcion_Prod();
            prod.DA_Modificar_ESTADO(ip);
        }
        #endregion
        #region MODIFICAR LOS DOCUMENTOS PRESENTADOS POR LA ORGANIZACION
        public void DB_Modificar_SUPEFICIE(AP_Productor p)
        {
            DA_AP_Inscripcion_Prod prod = new DA_AP_Inscripcion_Prod();
            prod.DA_Modificar_SUPEFICIE(p);
        }
        #endregion

    }
}
