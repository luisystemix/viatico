using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_Viaticos;

namespace DataBusiness.DB_Viaticos
{
    public class DB_VT_Categoria
    {
        #region OBTENER LA LISTA DE LAS SOLICITUDES CON EL USUARIO PARA REPORTE SOLICITUD
        public DataTable DB_Seleccionar_CATEGORIA(int IdCategoria, string tipo)
        {
            DA_VT_Categoria data = new DA_VT_Categoria();
            return data.DA_Seleccionar_CATEGORIA(IdCategoria,tipo);
        }
        #endregion
    }
}
