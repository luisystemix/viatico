using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataEntity.DE_Extensiones;
using DataAccess.DA_Extensiones;

namespace DataBusiness.DB_Extensiones
{
    public class DB_EXT_Rendimiento
    {
        #region OBTENER LA LISTA DE LAS SOLICITUDES CON EL USUARIO PARA REPORTE SOLICITUD
        public DataTable DB_Reporte_DETALLE_PLANILLA(int IdInscripcionOrg, string IdProductor, string Programa, string Parametro)
        {
            DA_EXT_Rendimiento data = new DA_EXT_Rendimiento();
            return data.DA_Reporte_DETALLE_PLANILLA(IdInscripcionOrg, IdProductor, Programa, Parametro);
        }
        #endregion
        #region OBTENER LA LISTA DE LAS SOLICITUDES CON EL USUARIO PARA REPORTE SOLICITUD
        public DataTable DB_Reporte_DETALLE_PLANILLA_CULTIVO(string IdProductor, string Parametro)
        {
            DA_EXT_Rendimiento data = new DA_EXT_Rendimiento();
            return data.DA_Reporte_DETALLE_PLANILLA_CULTIVO(IdProductor, Parametro);
        }
        #endregion

    }
}
