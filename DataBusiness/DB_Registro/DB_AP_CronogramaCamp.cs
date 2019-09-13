using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_Registro;
using DataEntity.DE_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_CronogramaCamp
    {
        #region FUNCION PARA DESPLEGAR LA LISTA DE ACTIVIDADES
        public DataTable DB_Desplegar_ACTIVIDADES_CAMP()
        {
            DA_AP_CronogramaCamp data = new DA_AP_CronogramaCamp();
            return data.DB_Desplegar_ACTIVIDADES_CAMP();
        }
        #endregion
        #region FUNCIONES INDEPENDIENTES PARA REGISTRAR EL CRONOGRAMA
        public void DB_Registrar_CRONOGRAMA(AP_CronogramaCamp c)
        {
            DA_AP_CronogramaCamp Ins = new DA_AP_CronogramaCamp();
            Ins.DA_Registrar_CRONOGRAMA(c);
        }
        #endregion
        #region FUNCIONES INDEPENDIENTES PARA REGISTRAR EL CRONOGRAMA DETALLE
        public void DB_Registrar_CRONOGRAMA_DETALLE(AP_CronogramaCampDetalle cd)
        {
            DA_AP_CronogramaCamp Ins = new DA_AP_CronogramaCamp();
            Ins.DA_Registrar_CRONOGRAMA_DETALLE(cd);
        }
        #endregion
        #region FUNCIONES INDEPENDIENTES PARA REGISTRAR EL CRONOGRAMA DETALLE
        public DataTable DB_Desplegar_LISTA_CRONOGRAMAS(int Id, string Parametro) 
        {
            DA_AP_CronogramaCamp Ins = new DA_AP_CronogramaCamp();
            return Ins.DA_Desplegar_LISTA_CRONOGRAMAS(Id,Parametro);
        }
        #endregion
    }
}
