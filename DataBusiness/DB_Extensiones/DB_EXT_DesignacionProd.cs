using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_Extensiones;
using DataEntity.DE_Extensiones;

namespace DataBusiness.DB_Extensiones
{
    public class DB_EXT_DesignacionProd
    {
        #region SELECCIONAR LOS PRODUCTORES DE LA ORGANIZACION DESIGNADA
        public DataTable DB_Desplegar_DESIGNACION_PROD(string IdUser, int IdCampanhia, int IdRegional, string Programa, int IdInsOrg, string Parametro)
        {
            DA_EXT_DesignacionProd data = new DA_EXT_DesignacionProd();
            return data.DA_Desplegar_DESIGNACION_PROD(IdUser, IdCampanhia, IdRegional, Programa, IdInsOrg, Parametro);
        }
        #endregion
        #region REGISTRAR NUEVA PRODUCTORES SELECCIONADOS
        public void DB_Registrar_DESIGNACION_PROD(EXT_DesignacionProd pd)
        {
            DA_EXT_DesignacionProd Ins = new DA_EXT_DesignacionProd();
            Ins.DA_Registrar_DESIGNACION_PROD(pd);
        }
        #endregion
        #region CAMBIAR EL ETAPA DEL SEGUIMIENTO EN LA TABLA DE DESIGNACION DE PRODUCTOR
        public void DB_Cambiar_ESTADO(string IdProductor, string etapa)
        {
            DA_EXT_DesignacionProd s = new DA_EXT_DesignacionProd();
            s.DA_Cambiar_ESTADO(IdProductor,etapa);
        }
        #endregion
        # region SELECCIONA TODoS LOS PRODUCTORES ASIGNADOS Y HABILITADOS
        public DataTable DB_Seleccionar_PROD_ASIGNADO(string IdProductor)
        {
            DA_EXT_DesignacionProd prod = new DA_EXT_DesignacionProd();
            return prod.DA_Seleccionar_PROD_ASIGNADO(IdProductor);
        }
        #endregion

        #region REGISTRAR LOS TADOS DE LA MUESTRA VALIDA
        public void DB_Registrar_MUESTRA(EXT_MuestraSeguimiento m)
        {
            DA_EXT_DesignacionProd mus = new DA_EXT_DesignacionProd();
            mus.DA_Registrar_MUESTRA(m);
        }
        #endregion
        #region OBTENER LA LISTA DE LAS SOLICITUDES CON EL USUARIO PARA REPORTE SOLICITUD
        public DataTable DB_Desplegar_MUESTRA(int idcamp, int idreg, string programa, string parametro)
        {
            DA_EXT_DesignacionProd data = new DA_EXT_DesignacionProd();
            return data.DA_Desplegar_MUESTRA(idcamp, idreg, programa, parametro);
        }
        #endregion
        #region REGISTRAR LOS TADOS DE LA MUESTRA VALIDA
        public void DB_Modificar_MUESTRA(EXT_MuestraSeguimiento m)
        {
            DA_EXT_DesignacionProd mus = new DA_EXT_DesignacionProd();
            mus.DA_Modificar_MUESTRA(m);
        }
        #endregion
    }
}
