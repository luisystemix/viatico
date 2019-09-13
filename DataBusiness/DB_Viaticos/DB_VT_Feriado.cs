using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataEntity.DE_Viaticos;
using DataAccess.DA_Viaticos;


namespace DataBusiness.DB_Viaticos
{
    public class DB_VT_Feriado
    {        
        public DataTable DB_Feriado_ObtenerListado(int Id_Regional)
        {
            DA_VT_Feriado data = new DA_VT_Feriado();
            return data.DA_Feriado_ObtenerListado(Id_Regional);
        }
        /// <summary>
        ///obtiene fecha actual del Servidor
        /// </summary>        
        /// <returns></returns>        
        public DateTime DB_GET_DATE_SERVER()
        {
            DA_VT_Feriado data = new DA_VT_Feriado();
            DateTime al = data.DA_GET_DATE_SERVER();
            return al;
        }
    }
}
