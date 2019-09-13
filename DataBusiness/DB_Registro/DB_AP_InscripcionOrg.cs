using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_InscripcionOrg
    {
        #region OBTENER EL NUMERO TOTAL DE PRODUCTORES y LA SUMA DE LAS SUPERFICIES INSCRITAS Y EJECUTADAS 
        public DataTable DB_Obtener_SUM_HA_NUM_PROD(int IdInsOrg, string Parametro)
        {
            DA_AP_InscripcionOrg data = new DA_AP_InscripcionOrg();
            return data.DA_Obtener_SUM_HA_NUM_PROD(IdInsOrg, Parametro);
        }
        #endregion
        #region LISTAR ORGANIZACIONES ABILITADAS POR REGIONAL Y CAMPAÑA
        public DataTable DB_Desplegar_ORG_REG_CAMP(string Parametro, int IdInscripOrg, int IdReg, int IdCamp, string Programa) 
        {
            DA_AP_InscripcionOrg list = new DA_AP_InscripcionOrg();
            return list.DA_Desplegar_ORG_REG_CAMP(Parametro, IdInscripOrg, IdReg, IdCamp, Programa);
        }
        #endregion
       /* #region OBTENER DATOS DE LA ORGANIZACION PARA SU ENCABEZADO
        public DataTable DB_Seleccionar_ENCABEZADO_ORG(int IdInsOrg)
        {
            DA_AP_Registro_Org data = new DA_AP_Registro_Org();
            return data.DB_Desplegar_ENCABEZADO_ORG(IdInsOrg);
        }
        #endregion*/
    }
}
