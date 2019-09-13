using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataEntity.DE_Registro;
using DataAccess.DA_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_INS_Insumos
    {
        #region SELECCIONAR ETIPO DE INSUMO
        public DataTable DB_Seleccionar_TIPO_INSUMOS(int idinsprov, int idtipoins, int insumo, string Parametro)
        {
            DA_INS_Insumos tin = new DA_INS_Insumos();
            return tin.DA_Seleccionar_TIPO_INSUMOS(idinsprov, idtipoins, insumo, Parametro);
        }
        #endregion
    }
}
