using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_Registro;
using DataEntity.DE_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_DocVerificado
    {
        #region OBTENER DATOS DE LA TABLA VERIFICACION DE DOCUMENTOS PRESENTADO
        public AP_DocVerificado DB_Desplegar_DOC_VERIF(int Id)
        {
            DA_AP_DocVerificado data = new DA_AP_DocVerificado();
            DataTable dt = new DataTable();
            AP_DocVerificado dv = new AP_DocVerificado();
            dt = data.DA_Desplegar_DOC_VERIF(Id);
            dv.Id_VerificarDoc = Convert.ToInt32(dt.Rows[0][0]);
            dv.Id_InscripcionOrg = Convert.ToInt32(dt.Rows[0][1]);
            dv.NumProductores = Convert.ToInt32(dt.Rows[0][2]);
            dv.SuperficieTotal = Convert.ToDecimal(dt.Rows[0][3]);
            dv.Ci_Revisor = dt.Rows[0][4].ToString();
            dv.Observacion = dt.Rows[0][5].ToString();
            dv.Fecha = Convert.ToDateTime(dt.Rows[0][6].ToString());
            return dv;
        }
        #endregion
        #region FUNCION PARA REGISTRAR A LA TABLA DE DOCUMENTOS SOLICITADOS VERIFICACION DE DOCUMENTOS
        public void DB_Registrar_DOC_VERIFICADO(AP_DocVerificado dv)
        {
            DA_AP_DocVerificado Ins = new DA_AP_DocVerificado();
            Ins.DA_Registrar_DOC_VERIFICADO(dv);
        }
        #endregion
        #region MODIFICAR DATOS DE LA TABLA DOCUMENTO VERIFICADO
        public void DB_Modificar_DOC_VERIF(AP_DocVerificado dv)
        {
            DA_AP_DocVerificado dato = new DA_AP_DocVerificado();
            dato.DA_Modificar_DOC_VERIF(dv);
        }
        #endregion
    }
}
