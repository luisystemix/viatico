using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataEntity.DE_Registro;
using DataAccess.DA_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_Productor
    {
        #region MODIFICAR LOS DOCUMENTOS PRESENTADOS POR LA ORGANIZACION
        public void DB_Modificar_ESTADO(AP_Productor p)
        {
            DA_AP_Productor prod = new DA_AP_Productor();
            prod.DA_Modificar_ESTADO(p);
        }
        #endregion
        #region MODIFICAR LOS DOCUMENTOS PRESENTADOS POR LA ORGANIZACION
        public void DB_Modificar_OBSERVACION(AP_Productor p)
        {
            DA_AP_Productor prod = new DA_AP_Productor();
            prod.DA_Modificar_OBSERVACION(p);
        }
        #endregion
        #region SELECCIONA DATOS DE UN PRODUCTOR PARA SU ENCABEZADO POR SU ID
        public DataTable DB_Seleccionar_ENCABEZADO_PROD(string idInsProd, string parametro)
        {
            DA_AP_Productor prod = new DA_AP_Productor();
            return prod.DB_Seleccionar_ENCABEZADO_PROD(idInsProd, parametro);
        }
        #endregion

    }
}
