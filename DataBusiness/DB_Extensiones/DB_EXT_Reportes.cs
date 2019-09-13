using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_Registro;
using DataEntity.DE_Registro;
using DataAccess.DA_Extensiones;

namespace DataBusiness.DB_Extensiones
{
    public class DB_EXT_Reportes
    {
        #region DESPLEGAR TODAS LA CAMPAÑIAS POR REGION
        public DataTable DB_Desplegar_REGIONALES_NOMBRE(string Camp)
        {
            DA_EXT_Reportes data = new DA_EXT_Reportes();
            return data.DA_Desplegar_REGIONALES_NOMBRE(Camp);
        }
        #endregion
        #region OBTENER LA SUPERFICIE INSCRITA Y APOYADA POR REGIONAL
        public DataTable DB_Obtener_SUPERFICIE_INS_APO(int idcamp, int idreg, int idinsorg, int idmuni,string Programa, string Parametro)
        {
            DA_EXT_Reportes data = new DA_EXT_Reportes();
            return data.DA_Obtener_SUPERFICIE_INS_APO(idcamp, idreg, idinsorg, idmuni, Programa, Parametro);
        }
        #endregion
    }
}
