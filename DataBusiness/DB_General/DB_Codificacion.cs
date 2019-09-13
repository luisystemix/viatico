using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_General;

namespace DataBusiness.DB_General
{
    public class DB_Codificacion
    {
        #region INCREMENTAR EN CONTADOR DEL CODIGO
        public string GetCodigo(int idReg, string parametro)
        {
            DA_Codificacion co = new DA_Codificacion();
            DB_Codificacion c = new DB_Codificacion();
            DataTable dt = new DataTable();
            dt = c.codigo(idReg, parametro);
            int cont = Convert.ToInt32(dt.Rows[0][2].ToString()) + 1;
            GetIncrenetCont(Convert.ToInt32(dt.Rows[0][0].ToString()), "VIATICOS");
            return dt.Rows[0][1].ToString() + cont.ToString() + "/" + dt.Rows[0][4].ToString();
        }
        public DataTable codigo(int idreg, string parametro)
        {
            DA_Codificacion cod = new DA_Codificacion();
            return cod.GetCodigo(idreg, parametro);
        }
        public void GetIncrenetCont(int cod,string doc)
        {
            DA_Codificacion c = new DA_Codificacion();
            c.Contador(cod,doc);
        }
        #endregion
        #region BUSCAR CODIGO DE CONTRATO PRINCIPAL
        public int DB_Codigo_INFORME()
        {
            DA_Codificacion cod = new DA_Codificacion();
            DataTable dt = new DataTable();
            dt = cod.DA_Codigo_INFORME();
            int cont = Convert.ToInt32(dt.Rows[0][1].ToString()) + 1;
            GetIncrenetCont(Convert.ToInt32(dt.Rows[0][0].ToString()), dt.Rows[0][2].ToString());
            return cont;
        }
        #endregion
    }
}
