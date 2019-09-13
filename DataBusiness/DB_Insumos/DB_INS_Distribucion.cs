using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_Insumos;
using DataEntity.DE_Insumos;

namespace DataBusiness.DB_Insumos
{
    public class DB_INS_Distribucion
    {
        #region REGISTRAR DISTRIBUCION DE INSUMOS
        public void DB_Registrar_DISTRIBUCION_INSUMO(INS_Distribucion DisIns)
        {
            DA_INS_Distribucion ins = new DA_INS_Distribucion();
            ins.DA_Registrar_DISTRIBUCION_INSUMO(DisIns);
        }
        #endregion
        #region REGISTRAR EL DETALLE DE LA DISTRIBUCION DE INSUMOS
        public void DB_Registrar_DISTRIBUCION_DETALLE_INSUMO(INS_DistribucionDetalle DisInsDet)
        {
            DA_INS_Distribucion insDet = new DA_INS_Distribucion();
            insDet.DA_Registrar_DISTRIBUCION_DETALLE_INSUMO(DisInsDet);
        }
        #endregion
        /**************** FUNCIONES AUXILIARES ********************/
        #region OBTENER EL CODIGO DE PODUCTOR
        public string DB_Seleccionar_IDPRODUCTOR(int idInsOrg, string Prog, string idPersona)
        {
            string aux1 = "";
            DataTable dt = new DataTable();
            DA_INS_Distribucion aux = new DA_INS_Distribucion();
            dt = aux.DA_Seleccionar_IDPRODUCTOR(idInsOrg, Prog, idPersona);
            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else 
            {
                return "NO";
            }
        }
        #endregion

        #region OBTENER LA LISTA DE LOS REGISTROS DE LOS INSUMOS DISTRIBUIDOS 
        public DataTable DB_Desplegar_INSUMOS_DISTRIBUIDOS(int IdCamp, int IdRegional, string Prog, string insumo, string Parametro)
        {
            DA_INS_Distribucion data = new DA_INS_Distribucion();
            return data.DA_Desplegar_INSUMOS_DISTRIBUIDOS(IdCamp, IdRegional, Prog, insumo, Parametro);
        }
        #endregion

    }
}
