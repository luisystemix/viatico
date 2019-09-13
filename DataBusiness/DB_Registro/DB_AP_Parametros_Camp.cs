using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_Registro;
using DataEntity.DE_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_Parametros_Camp
    {
        #region BUSCAR EN PA TABLA PARAMETROS CAMPAÑIA
        public List<AP_ParametrosCamp> DB_Desplegar_PARAMETRO_CAMP(int id)
        {
            DA_AP_Parametros_Camp data = new DA_AP_Parametros_Camp();
            DataTable dt = new DataTable();
            dt = data.DA_Desplegar_PARAMETRO_CAMP(id);
            List<AP_ParametrosCamp> listPC = new List<AP_ParametrosCamp>();
            foreach (DataRow fila in dt.Rows)
            {
                AP_ParametrosCamp pc = new AP_ParametrosCamp();
                pc.Id_Campanhia = Convert.ToInt32(fila[0]);
                pc.Tipo_Produccion = Convert.ToString(fila[1]);
                listPC.Add(pc);
            }
            return listPC;
        }
        #endregion
        #region REGISTRAR PARAMETROS DE LA CAMPAÑA
        public void DA_Registrar_PARAMETRO_CAMP(AP_ParametrosCamp pc)
        {
            DA_AP_Parametros_Camp  Ins = new DA_AP_Parametros_Camp();
            Ins.DA_Registrar_PARAMETRO_CAMP(pc);
        }
        #endregion
    }
}
