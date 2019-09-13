using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_Registro;
using DataEntity.DE_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_ContratoOrg
    {
        #region REGISTRAR NUEVO CONTRATO
        public void DB_Registrar_CONTRATO_ORG(AP_ContratoOrg c)
        {
            DA_AP_ContratoOrg Ins = new DA_AP_ContratoOrg();
            Ins.DA_Registrar_CONTRATO_ORG(c);
        }
        #endregion
    }
}
