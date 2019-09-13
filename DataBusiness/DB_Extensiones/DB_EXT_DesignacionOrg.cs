using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_Extensiones;
using DataEntity.DE_Extensiones;

namespace DataBusiness.DB_Extensiones
{
    public class DB_EXT_DesignacionOrg
    {
        #region REGISTRAR LA DESIGNACION DEL TECNICO DE EXTENCIONES
        public void DA_Registrar_DESIGNACION_ORG(EXT_DesignacionOrg d)
        {
            DA_EXT_DesignacionOrg Ins = new DA_EXT_DesignacionOrg();
            Ins.DA_Registrar_DESIGNACION_ORG(d);
        }
        #endregion
        #region SELECCIONAR LA DESIGNACION DE LAS ORGANIZACIONES
        public DataTable DB_Seleccionar_DESIGNACION_ORG(int IdReg, int IdCamp, string IdUser, string Programa, string Parametro)
        {
            DA_EXT_DesignacionOrg data = new DA_EXT_DesignacionOrg();
            return data.DA_Seleccionar_DESIGNACION_ORG(IdReg, IdCamp, IdUser, Programa, Parametro);
        }
        #endregion
        #region ELIMINAR UNA FILA DE LA DESIGNACION DE LA ORGANIZACION AL TECNICO
        public void DB_Eliminar_DESIGNACION_ORG(string idusuario, int idinsorg)
        {
            DA_EXT_DesignacionOrg d = new DA_EXT_DesignacionOrg();
            d.DA_Eliminar_DESIGNACION_ORG(idusuario, idinsorg);
        }
        #endregion
        #region FUNCION PARA OBTENER EL NUMERO DE ORGANIZACIONES Y NUMERO DE PRODUCTORES TOTAL
        public DataTable DB_Obtener_Numero_ORG_PROD(int idcamp, string programa, int idreg, string parametro)
        {
            DA_EXT_DesignacionOrg data = new DA_EXT_DesignacionOrg();
            return data.DA_Obtener_Numero_ORG_PROD(idcamp,programa,idreg,parametro);
        }
        #endregion

        #region FUNCION PARA SELECCIONAR DATOS DE LA TABLA MUESTRA
        public DataTable DB_Seleccionar_DATOS_MUESTRA(int idcamp, string programa, int idreg, string parametro)
        {
            DA_EXT_DesignacionOrg data = new DA_EXT_DesignacionOrg();
            return data.DA_Seleccionar_DATOS_MUESTRA(idcamp, programa, idreg, parametro);
        }
        #endregion

        #region SELECCIONAR LA DESIGNACION DE LAS ORGANIZACIONES
        public void DB_Actualizar_NUM_PROD(int Id_Regional, int Id_Campanhia, string Id_Usuario, string Programa, string Parametro)
        {
            DA_EXT_DesignacionOrg data = new DA_EXT_DesignacionOrg();
            data.DA_Actualizar_NUM_PROD(Id_Regional, Id_Campanhia, Id_Usuario, Programa, Parametro);
        }
        #endregion

        public DataTable DB_Seleccionar_DESIGNACION_PROD_ORG_CONSULTAS(int IdReg, int IdCamp, string IdUser, string Programa)
        {
            DA_EXT_DesignacionOrg data = new DA_EXT_DesignacionOrg();
            return data.DA_Seleccionar_DESIGNACION_PROD_ORG_CONSULTAS(IdReg, IdCamp, IdUser, Programa);
        }
    }
}
