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
    public class DB_EXT_Costos
    {
        #region REPORTE SELECCIONA LOS COSTOS Y SUS DETALLE POR LA ETAPA DE CULTIVO Y LA ID DE LA INSCRIPCION DE LA ORGANIZACION
        public DataTable DB_Reporte_COSTOS_DETALLE(int IdInsOrg, string IdProd, int Etapa, int Insumo, int Recurso, string Parametro)
        {
            DA_EXT_Costos data = new DA_EXT_Costos();
            return data.DA_Reporte_COSTOS_DETALLE(IdInsOrg, IdProd, Etapa, Insumo, Recurso, Parametro);
        }
        #endregion
        #region SELECCIONAR FUNCIONES DE LA TABLA COSTOS
        public DataTable DB_Seleccionar_COSTOS(int idOrg, string idprod, string parametro)
        {
            DA_EXT_Costos data = new DA_EXT_Costos();
            return data.DA_Seleccionar_COSTOS(idOrg, idprod, parametro);
        }
        #endregion

        #region SELECCIONAR TIPO DE RECURSO PARA EL COSTO
        public DataTable DB_Seleccionar_COSTO_TIPO_RECURSO(int valor)
        {
            DA_EXT_Costos data = new DA_EXT_Costos();
            return data.DA_Seleccionar_COSTO_TIPO_RECURSO(valor);
        }
        #endregion
    }
}
