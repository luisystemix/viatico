using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_General;
using DataEntity.DE_General;
using DataAccess.DA_Control; 

namespace DataBusiness.DB_Control
{
    public class DB_RegionesApoyadas
    {
        #region SELECCIONAR REGIONES APOYADAS POR CAMPAÑAS
        public DataTable DB_Seleccionar_REGIONAL(int idReg)
        {
            DA_Regional reg = new DA_Regional();
            return reg.DA_Seleccionar_REGIONAL(idReg);
        }
        #endregion
        #region OBTENER LA LISTA DE LAS CAMPAÑIAS APOYADAS POR EMAPA
        public DataTable DB_Desplegar_CAMP_APOYADAS(string Depart, string Prog, int IdCamp, int IdRegional, string Parametro)
        {
            DA_RegionesApoyadas data = new DA_RegionesApoyadas();
            return data.DA_Desplegar_CAMP_APOYADAS(Depart, Prog, IdCamp, IdRegional, Parametro);
        }
        #endregion
    }
}
