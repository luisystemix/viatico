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
    public class DB_EXT_Seguimiento
    {
        #region REGISTRAR SEGUIMIENTO
        public void DB_Registrar_SEGUIMIENTO(EXT_Seguimiento seg)
        {
            DA_EXT_Seguimiento reg = new DA_EXT_Seguimiento();
            reg.DA_Registrar_SEGUIMIENTO(seg);
        }
        #endregion
        #region REGISTRAR SEGUIMIENTO PARCELA
        public void DB_Registrar_SEGUIMIENTO_PARCELA(EXT_SeguimientoParcela segParc)
        {
            DA_EXT_Seguimiento regParc = new DA_EXT_Seguimiento();
            regParc.DA_Registrar_SEGUIMIENTO_PARCELA(segParc);
        }
        public void DB_Registrar_SEGUIMIENTO_PARCELA_UPDATE(EXT_SeguimientoParcela segParc)
        {
            DA_EXT_Seguimiento regParc = new DA_EXT_Seguimiento();
            regParc.DA_Registrar_SEGUIMIENTO_PARCELA_UPDATE(segParc);
        }       

        #endregion
        #region REGISTRAR SEGUIMIENTO SIEMBRA
        public void DB_Registrar_SEGUIMIENTO_SIEMBRA(EXT_SeguimientoSiembra segS)
        {
            DA_EXT_Seguimiento regS = new DA_EXT_Seguimiento();
            regS.DA_Registrar_SEGUIMIENTO_SIEMBRA(segS);
        }
        public void DB_SEGUIMIENTO_SIEMBRA_DELETE(int Id_Seguimiento_Parcela)
        {
            DA_EXT_Seguimiento regS = new DA_EXT_Seguimiento();
            regS.DA_SEGUIMIENTO_SIEMBRA_DELETE(Id_Seguimiento_Parcela);
        }
        #endregion
        #region REGISTRAR SEGUIMIENTO COORDENADAS
        public void DB_Registrar_SEGUIMIENTO_COORDENADA(EXT_SeguimientoCoordenadas segC)
        {
            DA_EXT_Seguimiento regC = new DA_EXT_Seguimiento();
            regC.DA_Registrar_SEGUIMIENTO_COORDENADA(segC);
        }
        public void DB_Registrar_SEGUIMIENTO_COORDENADA_DELETE(int  Id_Seguimiento_Parcela)
        {
            DA_EXT_Seguimiento regParc = new DA_EXT_Seguimiento();
            regParc.DA_Registrar_SEGUIMIENTO_COORDENADA_DELETE(Id_Seguimiento_Parcela);
        }
        #endregion
        #region REGISTRAR SEGUIMIENTO AL CULTIVO
        public void DB_Registrar_SEGUIMIENTO_CULTIVO(EXT_SeguimientoCultivo segC)
        {
            DA_EXT_Seguimiento regC = new DA_EXT_Seguimiento();
            regC.DA_Registrar_SEGUIMIENTO_CULTIVO(segC);
        }
        public void DB_SEGUIMIENTO_CULTIVO_DELETE(int Id_Seguimiento_Parcela)
        {
            DA_EXT_Seguimiento regC = new DA_EXT_Seguimiento();
            regC.DA_SEGUIMIENTO_CULTIVO_DELETE(Id_Seguimiento_Parcela);
        }
        #endregion
        #region REGISTRAR ADVERSIDAD PRESENTADA EN EL CULTIVO
        public void DB_Registrar_ADVESIDAD(EXT_AdversidadPresentada adevert)
        {
            DA_EXT_Seguimiento regC = new DA_EXT_Seguimiento();
            regC.DA_Registrar_ADVESIDAD(adevert);
        }
        public void DB_ADVESIDAD_DELETE(int Id_Seguimiento_Parcela)
        {
            DA_EXT_Seguimiento regC = new DA_EXT_Seguimiento();
            regC.DA_ADVESIDAD_DELETE(Id_Seguimiento_Parcela);
        }
        public DataTable DB_ADVESIDAD_GET(int Aux, int Id_Seguimiento)
        {
            DA_EXT_Seguimiento regC = new DA_EXT_Seguimiento();
            return regC.DA_ADVESIDAD_GET(Aux, Id_Seguimiento);
        }
        /// <summary>
        /// Agregar adversidad Plaga, Maleza, Enfermedad
        /// </summary>
        /// <param name="advert"></param>
        public void DB_Registrar_ADVESIDAD_PME(EXT_AdversidadPresentada adevert)
        {
            DA_EXT_Seguimiento regC = new DA_EXT_Seguimiento();
            regC.DA_Registrar_ADVESIDAD_PME(adevert);
        }
        public void DB_ADVESIDAD_PME_DELETE(int Id_Seguimiento_Parcela)
        {
            DA_EXT_Seguimiento regC = new DA_EXT_Seguimiento();
            regC.DA_ADVESIDAD_PME_DELETE(Id_Seguimiento_Parcela);
        }
        #endregion
        #region Verificacion Siembra Cueltivo
        public DataTable DB_CONSULTAR_EXT_SEGUIMIENTO_PARCELA(int Etapa, int IdInsOrg)
        {
            DA_EXT_Seguimiento regC = new DA_EXT_Seguimiento();
            return regC.DA_CONSULTAR_EXT_SEGUIMIENTO_PARCELA(Etapa, IdInsOrg);            
        }
        public DataTable DB_CONSULTAR_EXT_SEGUIMIENTO_SIEMBRA(int Etapa, int IdInsOrg, string IdUsuario)
        {
            DA_EXT_Seguimiento regC = new DA_EXT_Seguimiento();
            return regC.DA_CONSULTAR_EXT_SEGUIMIENTO_SIEMBRA(Etapa, IdInsOrg, IdUsuario);
        }
        public DataTable DB_EXT_CONSULTAR_NOMBRE_MUNICIPIO(int IdInsOrg)
        {
            DA_EXT_Seguimiento regC = new DA_EXT_Seguimiento();
            return regC.DA_EXT_CONSULTAR_NOMBRE_MUNICIPIO(IdInsOrg);
        }

        public DataTable DB_CONSULTAR_EXT_SEGUIMIENTO_CULTIVO(int IdInsOrg, string IdUsuario)
        {
            DA_EXT_Seguimiento regC = new DA_EXT_Seguimiento();
            return regC.DA_CONSULTAR_EXT_SEGUIMIENTO_CULTIVO(IdInsOrg, IdUsuario);
        }
        public DataTable DB_CONSULTAR_EXT_ADVERSIDAD_PRESENTADA(int Etapa, int IdInsOrg, string IdUsuario)
        {
            DA_EXT_Seguimiento regC = new DA_EXT_Seguimiento();
            return regC.DA_CONSULTAR_EXT_ADVERSIDAD_PRESENTADA(Etapa, IdInsOrg, IdUsuario);
        }
        public DataTable DB_CONSULTAR_EXT_ADVERSIDAD_PRESENTADA_PME(int Etapa, int IdInsOrg, string IdUsuario)
        {
            DA_EXT_Seguimiento regC = new DA_EXT_Seguimiento();
            return regC.DA_CONSULTAR_EXT_ADVERSIDAD_PRESENTADA_PME(Etapa, IdInsOrg, IdUsuario);
        }
        #endregion

        #region REGISTRAR SEGUIMIENTO DISTRIBUCION DE INSUMOS
        public void DB_Registrar_SEGUIMIENTO_DISTRIBUCION(EXT_SeguimientoDistribucion segDist)
        {
            DA_EXT_Seguimiento regDist = new DA_EXT_Seguimiento();
            regDist.DA_Registrar_SEGUIMIENTO_DISTRIBUCION(segDist);
        }
        #endregion
        #region REGISTRAR SEGUIMIENTO DISTRIBUCION SEMILLA Y AGROQUIMICO DETALLE
        public void DB_RRegistrar_DISTRIBUCION_DETALLE(EXT_SeguimientoDistribDetalle segDistDet)
        {
            DA_EXT_Seguimiento regDistDet = new DA_EXT_Seguimiento();
            regDistDet.DA_Registrar_DISTRIBUCION_DETALLE(segDistDet);
        }
        #endregion
        #region REGISTRAR RENDIMIENTOS
        public void DB_Registrar_RENDIMIENTO(EXT_Rendimiento rd)
        {
            DA_EXT_Seguimiento regR = new DA_EXT_Seguimiento();
            regR.DA_Registrar_RENDIMIENTO(rd);
        }
        #endregion
        #region REGISTRAR RENDIMIENTOS DETALLE
        public void DB_Registrar_RENDIMIENTO_DETALLE(EXT_RendimientoDetalle rnd)
        {
            DA_EXT_Seguimiento rdd = new DA_EXT_Seguimiento();
            rdd.DA_Registrar_RENDIMIENTO_DETALLE(rnd);
        }
        #endregion
        #region REGISTRAR COSTOS
        public void DB_Registrar_COSTOS(EXT_Costos c)
        {
            DA_EXT_Seguimiento rc = new DA_EXT_Seguimiento();
            rc.DA_Registrar_COSTOS(c);
        }
        #endregion
        #region REGISTRAR COSTOS DETALLE
        public void DB_Registrar_COSTOS_DETALLE(EXT_CostosDetalle cd)
        {
            DA_EXT_Seguimiento rcd = new DA_EXT_Seguimiento();
            rcd.DA_Registrar_COSTOS_DETALLE(cd);
        }
        #endregion
        #region REGISTRAR FECHA DE LA INSPECCION DEL COSTOS
        public void DB_Registrar_FECHA_SEG_COST(EXT_FechaSegCost fsc)
        {
            DA_EXT_Seguimiento rc = new DA_EXT_Seguimiento();
            rc.DA_Registrar_FECHA_SEG_COST(fsc);
        }
        #endregion
        #region REGISTRAR DATOS COSECHA
        public void DB_Registrar_DATOS_COSECHA(EXT_SeguimientoCosecha cos)
        {
            DA_EXT_Seguimiento rc = new DA_EXT_Seguimiento();
            rc.DA_Registrar_DATOS_COSECHA(cos);
        }
        #endregion
        /********* LISTAS ***********/
        #region SELECCIONAR SEGUIMIENTO REALIZADOS POR PRDUCTOR
        public DataTable DB_Desplegar_SEGUIMIENTOS_PROD(int IdInsOrg, string IdProductor, string Insumo, string Parametro)
        {
            DA_EXT_Seguimiento data = new DA_EXT_Seguimiento();
            return data.DA_Desplegar_SEGUIMIENTOS_PROD(IdInsOrg, IdProductor, Insumo, Parametro);
        }
        public List<EXT_SeguimientoPendiente> DB_Desplegar_SEGUIMIENTOS_PENDIENTE()
        {
            DA_EXT_Seguimiento data = new DA_EXT_Seguimiento();
            DataTable dt = new DataTable();
            dt = data.DA_Desplegar_SEGUIMIENTOS_PENDIENTE();
            List<EXT_SeguimientoPendiente> ListSP = new List<EXT_SeguimientoPendiente>();
            foreach (DataRow fila in dt.Rows)
            {
                EXT_SeguimientoPendiente r = new EXT_SeguimientoPendiente();
                r.Id_Seguimiento_pendiente =  Convert.ToInt16(fila["Id_Seguimiento_pendiente"]);
                r.Nombre = Convert.ToString(fila["Nombre"]);
                r.Estado = Convert.ToBoolean(fila["Estado"]);
                r.Nombre_Anterior = Convert.ToString(fila["Nombre_Anterior"]);
                ListSP.Add(r);
            }
            return ListSP;

        }
        /// <summary>
        /// Recupera datos de registro de cultivo por productor
        /// </summary>
        /// <param name="IdProductor"></param>
        /// <param name="Estado"></param>
        /// <returns></returns>
        public DataTable DB_RECUPERAR_REGISTRO_CULTIVO(string IdProductor, string Etapa)
        {
            DA_EXT_Seguimiento data = new DA_EXT_Seguimiento();
            return data.DA_RECUPERAR_REGISTRO_CULTIVO(IdProductor, Etapa);
        }
        #endregion
        /********** REPORTES ***********/
        #region SELECCIONAR LA DISTRIBUCION DE INSUMOS SEMILLA Y QUIMICO
        public DataTable DB_Reporte_DISTRIBUCION_DETALLE(int IdInsOrg, string Insumo, string Parametro)
        {
            DA_EXT_Seguimiento data = new DA_EXT_Seguimiento();
            return data.DA_Reporte_DISTRIBUCION_DETALLE(IdInsOrg, Insumo, Parametro);
        }
        #endregion
        //#region SELECCIONAR SEGUIMIENTO REALIZADOS POR PRDUCTOR
        //public DataTable DB_Desplegar_LISTA_DETALLE_DISTRIB(int IdInsOrg, string IdProductor, string Parametro)
        //{
        //    DA_EXT_Seguimiento data = new DA_EXT_Seguimiento();
        //    return data.DA_Desplegar_SEGUIMIENTOS_PROD(IdInsOrg, IdProductor, Parametro);
        //}
        //#endregion
        #region SELECCIONAR LA DISTRIBUCION DE INSUMOS SEMILLA Y QUIMICO
        public DataTable DB_Reporte_SEGUIMIENTOS(int IdSeguimiento, string Parametro)
        {
            DA_EXT_Seguimiento data = new DA_EXT_Seguimiento();
            return data.DA_Reporte_SEGUIMIENTOS(IdSeguimiento, Parametro);
        }
        #endregion
        public DateTime DB_ObtenerFechaServer()
        {            
            DA_EXT_Seguimiento data = new DA_EXT_Seguimiento();
            DateTime fs= data.DA_ObtenerFechaServer();
            return fs;
        }
        /*************************************** SEGUIMIENTO A LOS TECNICOS *********************************************/
        #region SELECCIONAR SEGUIMIENTO REALIZADOS POR PRDUCTOR
        public DataTable DB_Desplegar_SEGUIMIENTO_A_TECNICOS(string IdUsuario, string Programa, int IdCampanhia, int IdRegional, string Parametro)
        {
            DA_EXT_Seguimiento data = new DA_EXT_Seguimiento();
            return data.DA_Desplegar_SEGUIMIENTO_A_TECNICOS(IdUsuario, Programa, IdCampanhia, IdRegional, Parametro);
        }
        #endregion
        /*********************************************/
        #region CAMBIAR EL ESTADO DE LA SOLICITUD DE VIAJE
        public void DB_Cambiar_ESTADO_SEGUIMIENTO(string IdSeguimiento, string estado)
        {
            DA_EXT_Seguimiento s = new DA_EXT_Seguimiento();
            s.DA_Cambiar_ESTADO_SEGUIMIENTO(IdSeguimiento, estado);
        }
        #endregion
        /*************************************** SEGUIMIENTO A LOS TECNICOS *********************************************/
        #region SELECCIONAR EL NUMERO DE BOLETA DE SEGUIMIENTO REALIZADO
        public DataTable DB_Seleccionar_NUM_BOLETA_SEG(int IdSeguimiento, string etapa)
        {
            DA_EXT_Seguimiento data = new DA_EXT_Seguimiento();
            return data.DA_Seleccionar_NUM_BOLETA_SEG(IdSeguimiento, etapa);
        }
        #endregion

        #region SEGUIMIENTO DE CULTIVO SEGUN FASE FENOLOGICA
        /// <summary>
        /// Registra seguimiento de fase fenologica segun fase fenologica
        /// </summary>
        /// <param name="ObjFaseF"></param>
        /// <returns></returns>
        public void DB_INSERT_SEG_CULTIVO_FASE_FENOLOGIA(List<EXT_Seguimiento_Cultivo_Segun_Fase_Fenologica> ColFaseF)
        {
            DA_EXT_Seguimiento regC = new DA_EXT_Seguimiento();
            regC.DA_INSERT_SEG_CULTIVO_FASE_FENOLOGIA(ColFaseF);
        }
        /// <summary>
        /// Elimina datos registrados por Id_Usuario, no se registra para historial
        /// </summary>
        /// <param name="Id_Usuario"></param>
        /// <returns></returns>
        public void DB_DELETE_SEG_CULTIVO_FASE_FENOLOGIA(string Id_Usuario)
        {
            DA_EXT_Seguimiento regC = new DA_EXT_Seguimiento();
            regC.DA_DELETE_SEG_CULTIVO_FASE_FENOLOGIA(Id_Usuario);
        }
        /// <summary>
        /// Obtiene todos los datos de la fase fenologica
        /// </summary>
        /// <returns></returns>
        public DataTable DA_GET_SEG_CULTIVO_FASE_FENOLOGIA()
        {
            DA_EXT_Seguimiento data = new DA_EXT_Seguimiento();
            return data.DA_GET_SEG_CULTIVO_FASE_FENOLOGIA();
        }
        /// <summary>
        /// Obtiene  total de promedio avance cosecha segun registro seguimiento_fase_fenologica 
        /// </summary>
        /// <returns></returns>
        public DataTable DB_GET_REP_EST_FENOLOGICO()
        {
            DA_EXT_Seguimiento data = new DA_EXT_Seguimiento();
            return data.DA_GET_REP_EST_FENOLOGICO();
        }
        /// <summary>
        /// Obtiene etapas seguimiento_fase_fenologica (Germinacion,Plantula, etc)
        /// </summary>
        /// <returns></returns>
        public DataTable DB_GET_ETAPAS_FASE_FENOLOGICA()
        {
            DA_EXT_Seguimiento data = new DA_EXT_Seguimiento();
            return data.DA_GET_ETAPAS_FASE_FENOLOGICA();
        }

        #endregion
    }
}
