using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using DataEntity.DE_Viaticos;
using DataAccess.DA_Viaticos;

namespace DataBusiness.DB_Viaticos
{
    public class DB_VT_Viaticos
    {
        #region LISTAR LA TABLA SITIO_DEPARTAMENTO
        public List<VT_Departamento> DB_Desplegar_DEPARTAMENTO(string nombredep, string tipo)
        {
            DA_VT_Viaticos data = new DA_VT_Viaticos();
            DataTable dt = new DataTable();
            dt = data.DA_Desplegar_DEPARTAMENTO(nombredep,tipo);
            List<VT_Departamento> ListDepartamento = new List<VT_Departamento>();
            foreach (DataRow fila in dt.Rows)
            {
                VT_Departamento dep = new VT_Departamento();
                dep.Id_Departamento = Convert.ToInt32(fila[0]);
                dep.Id_Pais = Convert.ToInt32(fila[1]);
                dep.Nombre = fila[2].ToString();
                dep.Ext = fila[3].ToString();
                ListDepartamento.Add(dep);
            }
            return ListDepartamento;
        }
        #endregion
        #region REGISTRAR SOLICITUDES DE VIAJE
        public void DB_Registrar_SOLICITUD(VT_Solicitud a)
        {
            DA_VT_Viaticos Inscripcion = new DA_VT_Viaticos();
            Inscripcion.DA_Registrar_SOLICITUD(a);
        }
        #endregion
        #region REGISTRAR LOS DESTINOS DE LAS SOLICITUDES
        public void DB_Registrar_SOLICITUD_DESTINO(VT_SolicitudDestino a)
        {
            DA_VT_Viaticos InscripDestin = new DA_VT_Viaticos();
            InscripDestin.DA_Registrar_SOLICITUD_DESTINO(a);
        }


        public void DB_Eliminar_SOLICITUD_DESTINO(String a)
        {
            DA_VT_Viaticos InscripDestin = new DA_VT_Viaticos();
            InscripDestin.DA_Eliminar_SOLICITUD_DESTINO(a);
        }


        #endregion
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        public DataTable DB_Seleccionar_CUENTA_USUARIO(string idUser)
        {
            DA_VT_Viaticos data = new DA_VT_Viaticos();
            return data.DA_Seleccionar_CUENTA_USUARIO(idUser);
        }
        #endregion
        #region REGISTRAR DATOS DE LA CUENTA DEL USUARIO
        public void DB_Registrar_CUENTA(VT_Cuenta c)
        {
            DA_VT_Viaticos Inscripcion = new DA_VT_Viaticos();
            Inscripcion.DA_Registrar_CUENTA(c);
        }
        /// <summary>
        /// Actualiza por Usuario, cuenta de banco
        /// </summary>
        /// <param name="c">Objeto</param>
        public void DB_Modificar_CUENTA(VT_Cuenta c)
        {
            DA_VT_Viaticos Inscripcion = new DA_VT_Viaticos();
            Inscripcion.DA_Modificar_CUENTA(c);
        }

        #endregion
        #region FUNCIONQUE QUE CALCULA EN NUMERO DE SOLICITUDES QUE PRESENTAN UN ESTADO
        public int DB_Contar_SOLICITUIDES_ENVIADAS(string idUsuario, string estado)
        {
            DA_VT_Viaticos data = new DA_VT_Viaticos();
            DataTable dt = new DataTable();
            dt = data.DA_Contar_SOLICITUIDES_ENVIADAS(idUsuario, estado);
            return Convert.ToInt32(dt.Rows[0][0].ToString());      
        }
        #endregion

        #region FUNCION PARA DESPLEGAR LISTA DE FUNCIONARIOS QUE REALIZARON VIAJES EN UN INTERBALO DE FECHAS
        public DataTable DB_Seleccionar_VIAJES_PERSONAL_FECHAS(int idreg, DateTime fechaini, DateTime fechafin, string parametro)
        {
            DA_VT_Viaticos data = new DA_VT_Viaticos();
            return data.DA_Seleccionar_VIAJES_PERSONAL_FECHAS(idreg, fechaini, fechafin, parametro);
        }
        #endregion
    }
}
 