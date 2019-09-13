using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataEntity.DE_Extensiones;
using DataAccess.DA_Extensiones;

namespace DataBusiness.DB_Extensiones
{
    public class DB_EXT_Fenologia
    {
        #region DESPLEGAR EL CICLO FENOLOGICO SEGUN PROGRAMA
        public List<EXT_Fenologia> DB_Desplegar_FENOLOGIA(string programa, string idprod)
        {
            DA_EXT_Fenologia data = new DA_EXT_Fenologia();
            DataTable dt = new DataTable();
            dt = data.DA_Desplegar_FENOLOGIA(programa, idprod);
            List<EXT_Fenologia> listFen = new List<EXT_Fenologia>();
            foreach (DataRow fila in dt.Rows)
            {
                EXT_Fenologia fe = new EXT_Fenologia();
                fe.Id_Fenologia = Convert.ToInt32(fila[0].ToString());
                fe.Nom_Fenologia= fila[1].ToString();
                fe.Programa = fila[2].ToString();
                listFen.Add(fe);
            }
            return listFen;
        }
        #endregion
        #region DESPLEGAR EL CICLO FENOLOGICO SEGUN PROGRAMA
        public List<EXT_Fenologia> DB_GET_FASES_FENOLOGICAS(string programa)
        {
            DA_EXT_Fenologia data = new DA_EXT_Fenologia();
            DataTable dt = new DataTable();
            dt = data.DA_get_fases_fenologicas(programa);
            List<EXT_Fenologia> listFen = new List<EXT_Fenologia>();
            foreach (DataRow fila in dt.Rows)
            {
                EXT_Fenologia fe = new EXT_Fenologia();
                fe.Id_Fenologia = Convert.ToInt32(fila["id_fenologia"].ToString());
                fe.Nom_Fenologia = fila["nombre_fenologia"].ToString();
                fe.Programa = programa;
                listFen.Add(fe);
            }
            return listFen;
        }
        #endregion

        #region DESPLEGAR EL CICLO FENOLOGICO SEGUN PROGRAMA Y PRODUCTOR
        public List<EXT_Fenologia> DB_Desplegar_FENOLOGIA_PRODUCTOR(string programa, string IdProductor)
        {
            DA_EXT_Fenologia data = new DA_EXT_Fenologia();
            DataTable dt = new DataTable();
            dt = data.DA_Desplegar_FENOLOGIA_PRODUCTOR(programa, IdProductor);
            List<EXT_Fenologia> listFen = new List<EXT_Fenologia>();
            foreach (DataRow fila in dt.Rows)
            {
                EXT_Fenologia fe = new EXT_Fenologia();
                fe.Id_Fenologia = Convert.ToInt32(fila[0].ToString());
                fe.Nom_Fenologia = fila[1].ToString();
                //fe.Programa = fila[2].ToString();
                listFen.Add(fe);
            }
            return listFen;
        }
        #endregion
        #region OBTENER DATOS DE EL NUMERO DE BOLETAS DEL SEGUIMIENTO AL CULTIVO
        public DataTable DB_Datos_FACE_FENOLOGICA(int IdInscripcionOrg, int idCamp, int IdFenologia, int idReg, string Programa, string estado, int numseg, DateTime fecha, string Parametro)
        {
            DA_EXT_Fenologia data = new DA_EXT_Fenologia();
            return data.DA_Datos_FACE_FENOLOGICA(IdInscripcionOrg, idCamp, IdFenologia, idReg, Programa, estado, numseg, fecha, Parametro);
        }
        #endregion
        #region OBTENER DATOS DE EL NUMERO DE BOLETAS DEL SEGUIMIENTO A LA SIEMBRA
        public DataTable DB_Datos_SIEMBRA(int IdInscripcionOrg, string Programa, string Parametro)
        {
            string semilla = "";
            DA_EXT_Fenologia data = new DA_EXT_Fenologia();
            DataTable dt = new DataTable();
            dt = data.DA_Datos_SIEMBRA(IdInscripcionOrg, Programa, Parametro);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    semilla = dt.Rows[i][0].ToString() + ", " + semilla;
                }
                dt.Rows[0][0] = semilla;
                return dt;
            }
            else 
            {
               return dt;
            }
        }
        #endregion

        #region REGISTRAR FACE FENOLOGIA DEL CULTIVO EN GENERAL
        public void DB_Registrar_FACE_FENOLOGICA_CULTIVO(EXT_FaceFenologicaCultivo ffcultivo)
        {
            DA_EXT_Fenologia fen = new DA_EXT_Fenologia();
            fen.DA_Registrar_FACE_FENOLOGICA_CULTIVO(ffcultivo);
        }
        #endregion
        #region REGISTRAR FACE FENOLOGIA TRIGO
        public void DB_Registrar_FACE_FENOLOGICA_TRIGO(EXT_FaceFenologiaTrigo fftrigo)
        {
            DA_EXT_Fenologia fenTri = new DA_EXT_Fenologia();
            fenTri.DA_Registrar_FACE_FENOLOGICA_TRIGO(fftrigo);
        }
        #endregion
        #region REGISTRAR FACE FENOLOGIA MAIZ
        public void DB_Registrar_FACE_FENOLOGICA_MAIZ(EXT_FaceFenologiaMaiz ffMaiz)
        {
            DA_EXT_Fenologia fenMai = new DA_EXT_Fenologia();
            fenMai.DA_Registrar_FACE_FENOLOGICA_MAIZ(ffMaiz);
        }
        #endregion
        #region REGISTRAR FACE FENOLOGIA ARROZ
        public void DB_Registrar_FACE_FENOLOGICA_ARROZ(EXT_FaceFenologiaArroz ffArroz)
        {
            DA_EXT_Fenologia fenArro = new DA_EXT_Fenologia();
            fenArro.DA_Registrar_FACE_FENOLOGICA_ARROZ(ffArroz);
        }
        #endregion
        #region REGISTRAR FACE FENOLOGIA REPORTE DE ENVIO POR SEMANA
        public void DB_Registrar_FACE_FENOLOGICA_SEMANAL(EXT_FaseFenEnvioSem ffsem)
        {
            DA_EXT_Fenologia fen = new DA_EXT_Fenologia();
            fen.DA_Registrar_FACE_FENOLOGICA_SEMANAL(ffsem);
        }
        #endregion
        #region REGISTRAR FACE FENOLOGIA REPORTE DE ENVIO POR SEMANA LOS TOTALES DE LA SEMANA
        public void DB_Registrar_FACE_FENOLOGICA_SEMANAL_ENVIO_TRIGO(EXT_FaseFenEnvioSemanaTrigo ffsem)
        {
            DA_EXT_Fenologia fen = new DA_EXT_Fenologia();
            fen.DA_Registrar_FACE_FENOLOGICA_SEMANAL_ENVIO_TRIGO(ffsem);
        }
        #endregion

        #region MODIFICAR VALOR DE ENVIO POR SEMANA DE LA FASE FENOLOGICA
        public void DB_Indexar_FACE_FENOLOGICA_SEMANAL(int valor, int IdEnvFenSem)
        {
            DA_EXT_Fenologia dato = new DA_EXT_Fenologia();
            dato.DA_Indexar_FACE_FENOLOGICA_SEMANAL(valor, IdEnvFenSem);
        }
        #endregion

        #region DESPLEGAR LOS REGISTROS ENVIADOS DE LAS FENOLOGIA DE LA REGIONAL POR SEMANA
        public DataTable DB_Seleccionar_ENVIOS_SEMANA(int idreg)
        {
            DA_EXT_Fenologia fen = new DA_EXT_Fenologia();
            return fen.DA_Seleccionar_ENVIOS_SEMANA(idreg);
        }
        #endregion

        #region DESPLEGAR LOS REGISTROS ENVIADOS DE LAS FENOLOGIA DE LA REGIONAL POR SEMANA
        public DataTable DB_Seleccionar_ENVIOS_SEMANA_FENOLOGIA(string estado)
        {
            DA_EXT_Fenologia fen = new DA_EXT_Fenologia();
            return fen.DA_Seleccionar_ENVIOS_SEMANA_FENOLOGIA(estado);
        }
        #endregion



        #region DEVOLVER EL MAYOR ID DE CUALQUIER TABLA
        public int DB_MaxNumSeg(int IdInsOrg)
        {
            DA_EXT_Fenologia Luis = new DA_EXT_Fenologia();
            return Luis.DA_MaxNumSeg(IdInsOrg);
        }
        #endregion

        #region DESPLEGAR LOS VALORES DEL MUNERO DE PRODUCTORES ACTIVOS Y LA CANTIDAD EN SUPERFICIE DE CULTIVO EN HECTAREAS
        public DataTable DB_Seleccionar_NUMPROD_TOTSUP(int IdInsOrg, int IdComunidad)
        {
            DA_EXT_Fenologia fen = new DA_EXT_Fenologia();
            return fen.DA_Seleccionar_NUMPROD_TOTSUP(IdInsOrg, IdComunidad);
        }
        #endregion

        #region DESPLEGAR LOS VALORES DEL MUNERO DE PRODUCTORES ACTIVOS Y LA CANTIDAD EN SUPERFICIE DE CULTIVO EN HECTAREAS OJOJOJOJOJOJOJOJOJOJOJO
        public DataTable DB_Seleccionar_NUMPROD_TOTSUP_ORG(int IdInsOrg)
        {
            DA_EXT_Fenologia fen = new DA_EXT_Fenologia();
            return fen.DA_Seleccionar_NUMPROD_TOTSUP_ORG(IdInsOrg);
        }
        #endregion

        #region SELECCIONAR EL SEGUIMIENTO FENOLOGICO PARA EL REPORTE
        public DataTable DB_Reporte_FENOLOGIA_DETALLE(int IdInsOrg, string Programa, int IdCamp, int IdReg, int NuSeg, string Tipo, DateTime fecha,string Parametro)
        {
            DA_EXT_Fenologia fen = new DA_EXT_Fenologia();
            return fen.DA_Reporte_FENOLOGIA_DETALLE(IdInsOrg, Programa, IdCamp, IdReg, NuSeg, Tipo, fecha,Parametro);
        }
        #endregion

        #region OBTENER DATOS DE EL NUMERO DE BOLETAS DEL SEGUIMIENTO AL CULTIVO
        public DataTable DB_FACE_FENOLOGICA(int IdInscripcionOrg, int idCamp, int IdFenologia, int idReg, string Programa, string IdUsuario, string Tipo, string Parametro)
        {
            DA_EXT_Fenologia data = new DA_EXT_Fenologia();
            return data.DA_FACE_FENOLOGICA(IdInscripcionOrg, idCamp, IdFenologia, idReg, Programa, IdUsuario, Tipo, Parametro);
        }
        #endregion

    }
}
