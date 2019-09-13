using DataAccess.DA_Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBusiness.DB_Extensiones
{
    public class DB_EXT_Actividades
    {
        #region REPORTE SELECCIONA LOS COSTOS Y SUS DETALLE POR LA ETAPA DE CULTIVO Y LA ID DE LA INSCRIPCION DE LA ORGANIZACION
        /// <summary>
        /// Metodod que devuelve las actividaddes que seran utilizadas en la programacion del cronograma semanal del rol Tecnicos de Extension
        /// </summary>
        /// <param name="Categoria">Categoria que se requiere recuperar</param>
        /// <returns>Tabla de datos con las actividades para el cronograma semanal del rol tecnicos</returns>
        public System.Data.DataTable DB_ActividadesCronogramaSemanal(string Categoria)
        {
            DA_EXT_Actividades data = new DA_EXT_Actividades();
            return data.DA_Seleccionar_ActividadesCronogramaSemanal(Categoria);
        }
        #endregion
    }
}
