using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess.DA_Viaticos;
using DataEntity.DE_Viaticos;

namespace DataBusiness.DB_Viaticos
{
    public class DB_VT_Solicitud
    {
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        public DataTable DB_Desplegar_SOLICITUD_USUARIO(string iduser, string estado, string parametro)
        {
            DA_VT_Solicitud data = new DA_VT_Solicitud();
            return data.DA_Desplegar_SOLICITUD_USUARIO(iduser, estado, parametro);
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES Y SUS DESTINOS
        public DataTable DB_Desplegar_SOLICITUD_DESTINOS(string idSolicit)
        {
            DA_VT_Solicitud data = new DA_VT_Solicitud();
            return data.DA_Desplegar_SOLICITUD_DESTINOS(idSolicit);
        }
        #endregion
        #region OBTENER LA LISTA DE LAS SOLICITUDES CON EL USUARIO PARA REPORTE SOLICITUD
        public DataTable DB_Reporte_SOLICITUD_US(string IdSolicitud, string Parametro)
        {
            DA_VT_Solicitud data = new DA_VT_Solicitud();
            return data.DA_Reporte_SOLICITUD_US(IdSolicitud, Parametro);
        }
        #endregion
        #region DB  OBTENER DATOS DE INMEDIATO SUPERIOR POR CI
        public DataTable DB_Datos_InmediatoSuperior_GET(string ci_inm_superior)
        {
            DA_VT_Solicitud data = new DA_VT_Solicitud();
            return data.DA_Datos_InmediatoSuperior_GET(ci_inm_superior);
        }
        #endregion
        #region CAMBIAR EL ESTADO DE LA SOLICITUD DE VIAJE
        public void DB_Cambiar_ESTADO(string idSolicit, string estado)
        {
            DA_VT_Solicitud s = new DA_VT_Solicitud();
            s.DA_Cambiar_ESTADO(idSolicit,estado);
        }
        #endregion
        #region OBTENER El NUMERO DE FILAS DE LÑA TABLA SOLICITUD_DESTINO
        public int DB_Numero_Filas_SOLICITUD(string IdSol)
        {
            DA_VT_Solicitud Solicit = new DA_VT_Solicitud();
            return Solicit.DA_Numero_Filas_SOLICITUD(IdSol);
        }
        #endregion
        #region OBTENER DESTINOS DE LA TABLA SOLICITUD_DESTINOS POR ID y TRAMO
        public VT_SolicitudDestino DB_Seleccionar_SOLICITUD_DESTINO(string IdSol, int cont)
        {
            DA_VT_Solicitud data = new DA_VT_Solicitud();
            DataTable dt = new DataTable();
            dt = data.DA_Seleccionar_SOLICITUD_DESTINO(IdSol, cont);
            VT_SolicitudDestino sd = new VT_SolicitudDestino();
            if (dt.Rows.Count != 0)
            {
                sd.Id_Solicitud = dt.Rows[0][0].ToString();
                sd.Tramo = dt.Rows[0][1].ToString();
                sd.Zona = dt.Rows[0][2].ToString();
                sd.Destino = dt.Rows[0][3].ToString();
                sd.Lugar = dt.Rows[0][4].ToString();
                sd.Objetivo = dt.Rows[0][5].ToString();
                sd.Fecha_Salida = Convert.ToDateTime(dt.Rows[0][6].ToString());
                sd.Via_Transporte = dt.Rows[0][7].ToString();
                sd.Tipo_Transporte = dt.Rows[0][8].ToString();
                sd.Nombre_Transporte = dt.Rows[0][9].ToString();
                sd.Identificador_Trasporte = dt.Rows[0][10].ToString();
                sd.Cont = Convert.ToInt32(dt.Rows[0][11].ToString());
            }
            return sd;
        }
        #endregion
        #region OBTENER NUMERO DE DIAS, HORAS y MINUTOS DE DOS FECHAS
        public int DB_NumDHM(DateTime f1, DateTime f2, string param)
        {
            DA_VT_Solicitud data = new DA_VT_Solicitud();
            return data.DA_NumDHM(f1, f2, param);
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        public DataTable DB_Seleccionar_SOLICITUD(string IdSolicitud)
        {
            DA_VT_Solicitud data = new DA_VT_Solicitud();
            return data.DA_Seleccionar_SOLICITUD(IdSolicitud);
        }
        #endregion
        #region CALCULAR EL NUMERO DE DIAS PARA 
        public int Num_Dias(string  idSolicit) 
        {
            DA_VT_Informe data = new DA_VT_Informe();
            DataTable dt = new DataTable();
            dt = data.DA_Desplegar_SOLICITUD_OBJETIVOS(idSolicit, "FECHAMAXMIN");
            return Convert.ToInt32(dt.Rows[0][1].ToString());
        }
        #endregion
        #region MODIFICAR LA SOLICITUD
        public void DB_Modificar_SOLICITUD(VT_Solicitud s)
        {
            DA_VT_Solicitud dato = new DA_VT_Solicitud();
            dato.DA_Modificar_SOLICITUD(s);
        }
        #endregion
        #region MODIFICAR LA SOLICITUD_DESTINO
        public void DB_Modificar_SOLICITUD_DESTINO(VT_SolicitudDestino sd)
        {
            DA_VT_Solicitud dato = new DA_VT_Solicitud();
            dato.DA_Modificar_SOLICITUD_DESTINO(sd);
        }
        //*ini* lrojas: 30/08/2016
        /// <summary>
        /// Data Business: Modifica Solicitud Destino, reordena en campo CONT
        /// </summary>
        /// <param name="sd">Objeto_Solicitud_Destino</param>
        /// <param name="nuevo_cont">Envia Nuevo Contador</param>
        public void DB_Modificar_SOLICITUD_DESTINO_CONT(VT_SolicitudDestino ObjSD, int Nuevo_Cont)
        {
            DA_VT_Solicitud dato = new DA_VT_Solicitud();
            dato.DA_Modificar_SOLICITUD_DESTINO_CONT(ObjSD, Nuevo_Cont);            
        }
        //*fin*
        #endregion
        #region REGISTRAR OBSERVACIONES A LAS SOLICITUDES DE VIAJE
        public void DB_Registrar_OBSERVACION_SOLICITUD(VT_Observacion o)
        {
            DA_VT_Solicitud Registrar = new DA_VT_Solicitud();
            Registrar.DA_Registrar_OBSERVACION_SOLICITUD(o);
        }
        #endregion
        #region SELECCIONAR OBSERVACION
        public DataTable DB_Seleccionar_OBSERVACION_SOLICITUD(string idsolicitud)
        {
            DA_VT_Solicitud data = new DA_VT_Solicitud();
            return data.DA_Seleccionar_OBSERVACION_SOLICITUD(idsolicitud);
        }
        #endregion
        #region FUNCION PARA ELIMINAR LA OBSERVACION
        public void DB_Eliminar_OBSERVACION(string idSolicit)
        {
            DA_VT_Solicitud s = new DA_VT_Solicitud();
            s.DA_Eliminar_OBSERVACION(idSolicit);
        }
        #endregion
        #region #region ANULAR UNBA SOLICITUD DE VIAJE
        public void DB_Anular_SOLICITUD(string idSolicit, string Detalle, string estado)
        {
            DA_VT_Solicitud s = new DA_VT_Solicitud();
            s.DA_Anular_SOLICITUD(idSolicit, Detalle, estado);
        }
        #endregion
        //**lrojas-25/08/2016
        #region ELIMINAR UNA SOLICITUDE DE DESTINO
        /// <summary>
        /// Elimina un destino (actualiza contador a 0),fechadelete se la obtiene 'getdate()' al actualizar
        /// </summary>
        /// <param name="idSolicitud"></param>
        /// <param name="NroRegistro"></param>
        /// <param name="FechaDelete"></param>
        public void DB_DELETE_SOLICITUD_DESTINO(string idSolicitud, string NroRegistro, DateTime FechaDelete)
        {
            DA_VT_Solicitud s = new DA_VT_Solicitud();
            s.DA_DELETE_SOLICITUD_DESTINO(idSolicitud,NroRegistro,FechaDelete);
        }
        #endregion
    
    }
}
