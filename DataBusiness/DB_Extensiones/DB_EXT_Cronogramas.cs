using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataEntity.DE_Extensiones;
using DataAccess.DA_Extensiones;

namespace DataBusiness.DB_Extensiones
{
    public class DB_EXT_Cronogramas
    {
        #region REGISTRAR CRONOGRAMA
        public void DB_Registrar_CRONOGRAMA(EXT_Cronograma crm)
        {
            DA_EXT_Cronogramas reg = new DA_EXT_Cronogramas();
            reg.DA_Registrar_CRONOGRAMA(crm);
        }
        /// <summary>
        /// Actualizar Cronograma
        /// </summary>
        /// <param name="crm"></param>
        public void DB_CRONOGRAMA_UPDATE(EXT_Cronograma crm)
        {
            DA_EXT_Cronogramas reg = new DA_EXT_Cronogramas();
            reg.DA_CRONOGRAMA_UPDATE(crm);
        }
        #endregion
        #region REGISTRAR CRONOGRAMA DIA
        public void DB_Registrar_CRONOGRAMA_DIA(EXT_CronogramaDias crmDia)
        {
            DA_EXT_Cronogramas reg = new DA_EXT_Cronogramas();
            reg.DA_Registrar_CRONOGRAMA_DIA(crmDia);
        }
        public void DB_CRONOGRAMA_DIA_UPDATE(EXT_CronogramaDias crmDia)
        {
            DA_EXT_Cronogramas reg = new DA_EXT_Cronogramas();
            reg.DA_CRONOGRAMA_DIA_UPDATE(crmDia);
        }
        /// <summary>
        /// Insert Cronograma Dias Avance
        /// </summary>
        /// <param name="ColAvance"></param>
        public void DB_Registrar_CRONOGRAMA_DIA_AVANCE(List<EXT_CronogramaDiasAvance> ColAvance)
        {
            DA_EXT_Cronogramas reg = new DA_EXT_Cronogramas();
            reg.DA_Registrar_CRONOGRAMA_DIA_AVANCE(ColAvance);
        }
        /// <summary>
        /// Actualiza los avances y observaciones por actividad
        /// </summary>
        /// <param name="ColAvance"></param>
        public void DB_UPDATE_CRONOGRAMA_DIA_AVANCE(List<EXT_CronogramaDiasAvance> ColAvance)
        {
            DA_EXT_Cronogramas reg = new DA_EXT_Cronogramas();
            reg.DA_UPDATE_CRONOGRAMA_DIA_AVANCE(ColAvance);
        }
        /// <summary>
        /// Actualiza los avances y observaciones por actividad
        /// </summary>
        /// <param name="ColAvance"></param>
        public void DB_UPDATE_CRONOGRAMA_DIA_AVANCE_ALL(List<EXT_CronogramaDiasAvance> ColAvance)
        {
            DA_EXT_Cronogramas reg = new DA_EXT_Cronogramas();
            reg.DA_UPDATE_CRONOGRAMA_DIA_AVANCE_ALL(ColAvance);
        }
        public void DB_CRONOGRAMA_DIA_AVANCE_DELETE(List<EXT_CronogramaDiasAvance> ColAvance)
        {
            DA_EXT_Cronogramas reg = new DA_EXT_Cronogramas();
            reg.DA_CRONOGRAMA_DIA_AVANCE_DELETE(ColAvance);
        }
        #endregion

        #region FUNCIONES INDEPENDIENTES PARA REGISTRAR EL CRONOGRAMA DETALLE
        public DataTable DB_Desplegar_LISTA_CRONOGRAMAS(string IdUser, int IdCrono, int IdCamp, string Parametro)
        {
            DA_EXT_Cronogramas Ins = new DA_EXT_Cronogramas();
            return Ins.DA_Desplegar_LISTA_CRONOGRAMAS(IdUser, IdCrono, IdCamp, Parametro);
        }
        /// <summary>
        /// Obtiene todas las Actividades Por Cronograma
        /// </summary>
        /// <param name="IdCronograma"></param>
        /// <returns></returns>
        public DataTable DB_Desplegar_LISTA_ACTIVIDADES_CRONOGRAMA(int IdCronograma)
        {
            DA_EXT_Cronogramas Ins = new DA_EXT_Cronogramas();
            return Ins.DA_Desplegar_LISTA_ACTIVIDADES_CRONOGRAMA(IdCronograma);
        }
        /// <summary>
        /// Obtiene datos de Cronograma a Editar-DB
        /// </summary>
        /// <param name="IdCrono"></param>
        /// <param name="Parametro"></param>
        /// <returns></returns>
        public DataTable DB_OBTENER_DATOS_CRONOGRAMA_EDICION(int IdCrono,string Parametro)
        {
            DA_EXT_Cronogramas Ins = new DA_EXT_Cronogramas();
            return Ins.DA_OBTENER_DATOS_CRONOGRAMA_EDICION(IdCrono, Parametro);
        }
        #endregion
        /************************* CRONOGRAMA TECNICO DE EXTENSION ******************************/
        #region REGISTRAR CRONOGRAMA
        public void DB_Registrar_CRONOGRAMA_TEC(EXT_CronogramaTec ct)
        {
            DA_EXT_Cronogramas reg = new DA_EXT_Cronogramas();
            reg.DA_Registrar_CRONOGRAMA_TEC(ct);
        }
        #endregion
        #region REGISTRAR CRONOGRAMA DIA
        public void DB_Registrar_CRONOGRAMA_TEC_DETALLE(EXT_CronogramaTecDetalle ctd)
        {
            DA_EXT_Cronogramas reg = new DA_EXT_Cronogramas();
            reg.DA_Registrar_CRONOGRAMA_TEC_DETALLE(ctd);
        }
        #endregion
    }
}
