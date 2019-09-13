using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataEntity.DE_Viaticos;
using DataAccess.DA_Viaticos;

namespace DataBusiness.DB_Viaticos
{
    public class DB_VT_Planilla
    {
        #region INSERTAR PLANILLA DE VIAJE
        public void DB_Registrar_PLANILLA(VT_Planilla p)
        {
            DA_VT_Planilla InsPlani = new DA_VT_Planilla();
            InsPlani.DA_Registrar_PLANILLA(p);
        }
        #endregion
        #region INSERTAR PLANILLA POR DIA DE VIAJE
        public void DB_Registrar_PLANILLADIA(VT_PlanillaDia pd)
        {
            DA_VT_Planilla InsPlanD = new DA_VT_Planilla();
            InsPlanD.DA_Registrar_PLANILLADIA(pd);
        }
        #endregion
        #region OBTENER LA LISTA DE LAS SOLICITUDES CON EL USUARIO PARA REPORTE SOLICITUD
        public DataTable DB_Reporte_DETALLE_PLANILLA(string IdSolicitud, string Parametro)
        {
            DA_VT_Planilla data = new DA_VT_Planilla();
            return data.DA_Reporte_DETALLE_PLANILLA(IdSolicitud, Parametro);
        }
        #endregion
        #region MODIFICAR LA PLANILLA DE PAGO
        public void DB_Modificar_PLANILLA(VT_Planilla p)
        {
            DA_VT_Planilla dato = new DA_VT_Planilla();
            dato.DA_Modificar_PLANILLA(p);
        }
        #endregion
        #region MODIFICAR LA PLANILLA DE PAGO POR DIA
        public void DB_Modificar_PLANILLA_DIA(VT_PlanillaDia pd)
        {
            DA_VT_Planilla dato = new DA_VT_Planilla();
            dato.DA_Modificar_PLANILLA_DIA(pd);
        }
        #endregion
        #region SELECCIONAR UNA PLANILLA POR EL ID_DE SOLICITUD
        public VT_Planilla DB_Seleccionar_PLANILLA(string idSolicitud)
        {
            DA_VT_Planilla data = new DA_VT_Planilla();
            DataTable dt = new DataTable();
            dt = data.DA_Seleccionar_PLANILLA(idSolicitud);
            VT_Planilla pl = new VT_Planilla();
            pl.Id_Planilla = Convert.ToInt32(dt.Rows[0][0]);
            pl.Pago_Total = Convert.ToDecimal(dt.Rows[0][1]);
            pl.Rc_Iva = Convert.ToDecimal(dt.Rows[0][2]);
            pl.Liquido_Pagable = Convert.ToDecimal(dt.Rows[0][3]);
            pl.Num_Cheque = dt.Rows[0][4].ToString();
            pl.Tasa_Cambio = Convert.ToDecimal(dt.Rows[0][5].ToString());
            pl.Fecha = Convert.ToDateTime(dt.Rows[0][6].ToString());
            pl.Fecha_Atendido = Convert.ToDateTime(dt.Rows[0][7].ToString());
            return pl;
        }
        #endregion  
        #region SELECCIONAR LOS DATOS DE LA CUENTA DE UN USUARIO
        public VT_Cuenta DB_Seleccionar_CUENTA(string idUser)
        {
            DA_VT_Planilla data = new DA_VT_Planilla();
            DataTable dt = new DataTable();
            VT_Cuenta cta = new VT_Cuenta();
            dt = data.DA_Seleccionar_CUENTA(idUser);
            //*ini* lrojas: 29/09/2016 validacion usario - cuenta
            if (dt.Rows.Count == 0)
            {
                throw new Exception("El usuario " + idUser + " no tiene una cuenta de banco asociada, Actualice al Usuario en 'Administrar Usuario'");
            }
            else
            {
                cta.Cuenta = dt.Rows[0][0].ToString();
                cta.Banco = dt.Rows[0][1].ToString();
                cta.Estado = dt.Rows[0][2].ToString();  
            }
            //*fin*
            return cta;
        }
        #endregion  
    }
}
