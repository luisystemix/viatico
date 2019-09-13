using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_General;
using DataEntity.DE_General;

namespace DataBusiness.DB_General
{
    public class DB_Regional
    {
        #region DESPLEGAR TODOS LOS DATOS DE LA TABLA REGIONAL
        public List<Regional> DB_Desplegar_REGIONAL()
        {
            DA_Regional data = new DA_Regional();
            DataTable dt = new DataTable();
            dt = data.DA_Desplegar_REGIONAL();
            List<Regional> listReg = new List<Regional>();
            foreach (DataRow fila in dt.Rows)
            {
                Regional r = new Regional();
                r.Id_Regional = Convert.ToInt32(fila[0]);
                r.Tipo = Convert.ToString(fila[1]);
                r.Nombre = Convert.ToString(fila[2]);
                r.Departamento = Convert.ToString(fila[3]);
                r.Ci_Responsable = Convert.ToString(fila[4]);
                r.Direccion = Convert.ToString(fila[5]);
                r.Telef_Fijo = Convert.ToString(fila[6]);
                r.Telef_Movil = Convert.ToString(fila[7]);
                r.Region = Convert.ToString(fila[8]);
                r.Estado = Convert.ToString(fila[9]);
                r.IdRegional_Padre = Convert.ToInt16(fila["IdRegional_Padre"]);
                listReg.Add(r);
            }
            return listReg;
        }
        #endregion
        #region SELECCIONAR TODOS LOS DATOS DE LA TABLA REGIONAL POR EL ID
        public DataTable DB_Seleccionar_REGIONAL(int idReg)
        {
            DA_Regional reg = new DA_Regional();
            return reg.DA_Seleccionar_REGIONAL(idReg);
        }
        #endregion
        #region OBTENER LA LISTA DE LAS TABLAS ORGANIZACION => INSCRIPCION_ORG => DOCUMENTO_PRESENTADO
        public DataTable DB_Desplegar_REGIONAL_DATOS()
        {
            DA_Regional data = new DA_Regional();
            return data.DA_Desplegar_REGIONAL_DATOS();
        }
        #endregion
        #region SELECCIONAR TODOS LOS DATOS DE LA TABLA REGIONAL POR EL ID
        public DataTable DB_Seleccionar_VEHICULO(int IdVehiculo)
        {
            DA_Regional reg = new DA_Regional();
            return reg.DA_Seleccionar_VEHICULO(IdVehiculo);
        }
        #endregion
    }
}
