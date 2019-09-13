using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_Viaticos;
using DataEntity.DE_Viaticos;

namespace DataBusiness.DB_Viaticos
{
    public class DB_VT_Informe
    {
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        public DataTable DB_Desplegar_SOLICITUD_OBJETIVOS(string idSolicitud, string parametro)
        {
            DA_VT_Informe data = new DA_VT_Informe();
            return data.DA_Desplegar_SOLICITUD_OBJETIVOS(idSolicitud, parametro);
        }
        #endregion
        #region MODIFICAR EL ESTADO DE LA TABLA DOCUMENTO VERIFICADO
        public void DB_Registrar_INFORME(VT_Informe inf)
        {
            DA_VT_Informe Ins = new DA_VT_Informe();
            Ins.DA_Registrar_INFORME(inf);
        }
        #endregion
        #region MODIFICAR EL ESTADO DE LA TABLA DOCUMENTO VERIFICADO
        public void DB_Registrar_INFORME_ACTIVIDAD(VT_InformeActividad infAct)
        {
            DA_VT_Informe Ins = new DA_VT_Informe();
            Ins.DA_Registrar_INFORME_ACTIVIDAD(infAct);
        }
        #endregion
        #region OBTENER LA LISTA DE LAS SOLICITUDES CON EL USUARIO PARA REPORTE SOLICITUD
        public DataTable DB_Reporte_INFORME(string IdSolicitud, string Parametro)
        {
            DA_VT_Informe data = new DA_VT_Informe();
            return data.DA_Reporte_INFORME(IdSolicitud, Parametro);
        }
        #endregion
        #region CAMBIAR EL ESTADO DEL INFORME DE VIAJE
        public void DB_Cambiar_ESTADOINF(string idSolicit, string estado)
        {
            DA_VT_Informe s = new DA_VT_Informe();
            s.DA_Cambiar_ESTADOINF(idSolicit, estado);
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        public DataTable DB_Desplegar_INFORME_DIAS(string IdSolicitud, string parametro)
        {
            DA_VT_Informe data = new DA_VT_Informe();
            return data.DA_Desplegar_INFORME_DIAS(IdSolicitud, parametro);
        }
        #endregion
        #region SELECCIONAR LOS DATOS DE UN INFORME POR EL ID
        public DataTable DB_Seleccionar_INFORME(string IdSolicitud, string parametro)
        {
            DA_VT_Informe data = new DA_VT_Informe();
            return data.DA_Seleccionar_INFORME(IdSolicitud, parametro);
        }
        #endregion
        #region MODIFICAR EL INFORME
        public void DB_Modificar_INFORME(VT_Informe infAct)
        {
            DA_VT_Informe Ins = new DA_VT_Informe();
            Ins.DA_Modificar_INFORME(infAct);
        }
        #endregion
        #region MODIFICAR EL INFORME ACTIVIDAD
        public void DB_Modificar_INFORME_ACTIVIDAD(VT_InformeActividad infAct)
        {
            DA_VT_Informe Ins = new DA_VT_Informe();
            Ins.DA_Modificar_INFORME_ACTIVIDAD(infAct);
        }
        #endregion



        #region DESPLEGAR TODAS LA CAMPAÑIAS POR REGION
        public DataTable DB_Desplegar_DATOS_ESTRUCTURA(string Valor)
        {
            DA_VT_Informe data = new DA_VT_Informe();
            return data.DA_Desplegar_DATOS_ESTRUCTURA(Valor);
        }
        #endregion
    }
}
