using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity.DE_Registro;
using DataAccess.DA_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_DocVerificadoProv
    {
        #region FUNCION PARA REGISTRAR A LA TABLA DE DOCUMENTOS SOLICITADOS VERIFICACION DE DOCUMENTOS DE LOS PROVEEDORES
        public void DB_Registrar_DOC_VERIFICADO_PROV(AP_DocVerificadoProv dv)
        {
            DA_AP_DocVerificadoProv Ins = new DA_AP_DocVerificadoProv();
            Ins.DA_Registrar_DOC_VERIFICADO_PROV(dv);
        }
        #endregion
    }
}
