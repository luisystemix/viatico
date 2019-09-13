using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataEntity.DE_Registro;
using DataAccess.DA_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_Proveedor
    {
        #region REGISTRAR NUEVO PROVEEDOR
        public void DB_Registrar_PROVEEDOR(AP_Proveedor p)
        {
            DA_AP_Proveedor Ins = new DA_AP_Proveedor();
            Ins.DA_Registrar_PROVEEDOR(p);
        }
        #endregion
        #region BUSCAR UNA EMPRESA PROVEEDORA POR EL NUMERO DE NIT O EL CODIGO INTERNO 
        public AP_Proveedor DB_Buscar_PROVEEDOR(string valor)
        {
                DA_AP_Proveedor data = new DA_AP_Proveedor();
                DataTable dt = new DataTable();
                dt = data.DA_Buscar_PROVEEDOR(valor);
                AP_Proveedor al = new AP_Proveedor();

                if (dt.Rows.Count != 0)
                {
                    al.Id_Proveedor = Convert.ToInt32(dt.Rows[0][0]);
                    al.Razon_Social = dt.Rows[0][1].ToString();
                    al.NIT = dt.Rows[0][2].ToString();
                    al.Num_Testimonio = dt.Rows[0][3].ToString();
                    al.Fecha_Creacion = Convert.ToDateTime(dt.Rows[0][4]);
                    al.Departamento = dt.Rows[0][5].ToString();
                    al.Domicilio = dt.Rows[0][6].ToString();
                    al.Telefono_Ref = dt.Rows[0][7].ToString();
                    al.Correo = dt.Rows[0][8].ToString();
                }
                return al;
        }
        #endregion
        #region MODIFICAR LA TABLA PROVEEDOR
        public void DB_Modificar_PROVEEDOR(AP_Proveedor p)
        {
            DA_AP_Proveedor dato = new DA_AP_Proveedor();
            dato.DA_Modificar_PROVEEDOR(p);
        }
        #endregion
        #region DESPLEGAR TODA LA LISTA DE PROVEEDORES 
        public DataTable DB_Desplegar_PROVEEDOR()
        {
            DA_AP_Proveedor data = new DA_AP_Proveedor();
            return data.DA_Desplegar_PROVEEDOR();
        }
        #endregion
        #region DESPLEGAR LA LISTA  DE PROVEEDORES
        public DataTable DB_Desplegar_PROVEEDOR_PARAMETROS(string[] valor)
        {
            DA_AP_Proveedor p = new DA_AP_Proveedor();
            return p.DA_Desplegar_PROVEEDOR_PARAMETROS(valor);
        }
        #endregion
    }
}
