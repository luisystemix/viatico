using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess.DA_Extensiones;

namespace DataBusiness.DB_Extensiones
{
    public class DB_EXT_SegSemanalTotales
    {
        #region OBTENER LA LISTA DE LOS TOTALES DEL SEGUIMIENTO AL CULTIVO
        public DataTable DB_Desplegar_SEG_SEMANAL_TOTAL(int idreg, int idcamp, string programa, string parametro)
        {
            DA_EXT_SegSemanalTotales data = new DA_EXT_SegSemanalTotales();
            return data.DA_Desplegar_SEG_SEMANAL_TOTAL(idreg, idcamp, programa, parametro);
        }
        #endregion
        #region OBTENER LA LISTA DE ORGANIZACIONES CONSU SUPERFICEI APOYADA
        public DataTable DB_Desplegar_ORG_SUPERFICIE_APOYADA(int idreg, int idcamp, string programa, string parametro)
        {
            DA_EXT_SegSemanalTotales data = new DA_EXT_SegSemanalTotales();
            return data.DA_Desplegar_ORG_SUPERFICIE_APOYADA(idreg, idcamp, programa, parametro);
        }
        #endregion
        #region OBTENER LA LISTA DE LOS TOTALES DEL SEGUIMIENTO AL CULTIVO
        public DataTable DB_Desplegar_SEG_SEMANAL_MUESTRA(int idreg, int idcamp, string programa, string idUsuario, string etapa, DateTime fecha, string parametro)
        {
            DA_EXT_SegSemanalTotales data = new DA_EXT_SegSemanalTotales();
            return data.DA_Desplegar_SEG_SEMANAL_MUESTRA(idreg,  idcamp,  programa,  idUsuario,  etapa,  fecha,  parametro);
        }
        #endregion


        #region OBTENER EL SEGUIMIENTO DE LAS ADVERSIDADES
        public DataTable DB_Desplegar_SEG_ADVERSIDAD(int idreg, int idcamp, string programa, int year, int month, string parametro)
        {
            DA_EXT_SegSemanalTotales data = new DA_EXT_SegSemanalTotales();
            return data.DA_Desplegar_SEG_ADVERSIDAD(idreg, idcamp, programa, year, month, parametro);
        }
        #endregion
    }
}
