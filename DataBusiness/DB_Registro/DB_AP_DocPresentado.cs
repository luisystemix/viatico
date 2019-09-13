using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity.DE_Registro;
using DataAccess.DA_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_DocPresentado
    {
        #region MODIFICAR VALORES DE LA TABLA DOCUMENTOS PRESENTADOS POR ORGANIZACION 
        public void DB_Modificar_DOC_PRESENT(AP_DocPresentado dp)
        {
            DA_AP_DocPresentado registrar = new DA_AP_DocPresentado();
            registrar.DA_Modificar_DOC_PRESENT(dp);
        }
        #endregion
    }
}

