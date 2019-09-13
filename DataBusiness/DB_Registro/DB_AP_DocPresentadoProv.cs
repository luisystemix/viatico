using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.DA_Registro;
using DataEntity.DE_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_DocPresentadoProv
    {
        #region REGISTRAR LOS DOCUMENTOS SOLICITADOS POR CAMPAÑA A LOS PROVEEDORES
        public void DB_Registrar_DOC_PRESENTADO_PROV(int Id_InsProv, int Id_Campanhia, int tipo)
        {
            DA_AP_DocPresentadoProv Ins = new DA_AP_DocPresentadoProv();
            Ins.DA_Registrar_DOC_PRESENTADO_PROV(Id_InsProv, Id_Campanhia, tipo);
        }
        #endregion
        #region MODIFICAR EL ESTADO DE LOS DOCUMENTOS PRESENTADOS POR EL PROVEEDOR y SU OBSERVACION
        public void DB_Modificar_ESTADO(AP_DocPresentadoProv dpv)
        {
            DA_AP_DocPresentadoProv prod = new DA_AP_DocPresentadoProv();
            prod.DA_Modificar_ESTADO(dpv);
        }
        #endregion
    }
}
