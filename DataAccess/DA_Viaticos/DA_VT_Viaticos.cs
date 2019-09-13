using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using DataEntity.DE_Viaticos;

namespace DataAccess.DA_Viaticos
{
    public class DA_VT_Viaticos
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region DEVOLVER TODOS LOS REGISTROS DE LA TABLA DEPARTAMENTOS
        public DataTable DA_Desplegar_DEPARTAMENTO(string nombredep, string tipo)
        {
            try
            {
                if (tipo == "Interdepartamental")
                {
                  string queryString = "SELECT * FROM VIAT_DEPARTAMENTO WHERE Nombre <> '"+ nombredep +"'";
                  using (SqlConnection conexion = new SqlConnection(conexionString))
                  {
                      conexion.Open();
                      SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                      DataTable dt = new DataTable();
                      da.Fill(dt);
                      conexion.Close();
                      return dt;
                  }
                }
                else 
                {
                  string queryString = "SELECT * FROM VIAT_DEPARTAMENTO WHERE Nombre = '"+ nombredep +"'";
                  using (SqlConnection conexion = new SqlConnection(conexionString))
                  {
                      conexion.Open();
                      SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                      DataTable dt = new DataTable();
                      da.Fill(dt);
                      conexion.Close();
                      return dt;
                  }
                }
                
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion
        #region REGISTRAR SOLICITUDES DE VIAJE
        public void DA_Registrar_SOLICITUD(VT_Solicitud a)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("VT_SOLICITUD_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", a.Id_Solicitud);
                    cmd.Parameters.AddWithValue("@Id_Regional", a.Id_Regional);
                    cmd.Parameters.AddWithValue("@Id_Usuario", a.Id_Usuario);
                    cmd.Parameters.AddWithValue("@Tipo_Salida", a.Tipo_Salida);
                    cmd.Parameters.AddWithValue("@Tipo_Solicitud", a.Tipo_Solicitud);
                    cmd.Parameters.AddWithValue("@Dep_Salida", a.Dep_Salida);
                    cmd.Parameters.AddWithValue("@Cargo", a.Cargo);
                    cmd.Parameters.AddWithValue("@ci_Aprobador", a.ci_Aprobador);
                    cmd.Parameters.AddWithValue("@Cargo_Aprobador", a.Cargo_Aprobador);
                    cmd.Parameters.AddWithValue("@Fecha_Solicitud", a.Fecha_Solicitud);
                    cmd.Parameters.AddWithValue("@Fecha_Aprob", a.Fecha_Aprob);
                    cmd.Parameters.AddWithValue("@Motivo_Viaje", a.Motivo_Viaje);
                    cmd.Parameters.AddWithValue("@Descrip_Motivo", a.Descrip_Motivo);
                    cmd.Parameters.AddWithValue("@Tipo_Viaje", a.Tipo_Viaje);
                    cmd.Parameters.AddWithValue("@Estado", a.Estado);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion 
        #region REGISTRAR LOS DESTINOS DE LAS SOLICITUDES
        public void DA_Registrar_SOLICITUD_DESTINO(VT_SolicitudDestino a)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("VT_SOLICITUD_DESTINO_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", a.Id_Solicitud);
                    cmd.Parameters.AddWithValue("@Cont", a.Cont);
                    cmd.Parameters.AddWithValue("@Tramo", a.Tramo);
                    cmd.Parameters.AddWithValue("@Zona", a.Zona);
                    cmd.Parameters.AddWithValue("@Destino", a.Destino);
                    cmd.Parameters.AddWithValue("@Lugar", a.Lugar);
                    cmd.Parameters.AddWithValue("@Objetivo", a.Objetivo);
                    cmd.Parameters.AddWithValue("@Fecha_Salida", a.Fecha_Salida);
                    cmd.Parameters.AddWithValue("@Via_Transporte", a.Via_Transporte);
                    cmd.Parameters.AddWithValue("@Tipo_Transporte", a.Tipo_Transporte);
                    cmd.Parameters.AddWithValue("@Nombre_Transporte", a.Nombre_Transporte);
                    cmd.Parameters.AddWithValue("@Identificador_Trasporte", a.Identificador_Trasporte);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }

        public void DA_Eliminar_SOLICITUD_DESTINO(String a)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("VIAT_SOLICITUD_DESTINO_DELETE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", a);                    
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion 
        #region DESPLEGAR TODOS LOS DATOS DE LA TABLA REGIONAL
        public DataTable DA_Seleccionar_CUENTA_USUARIO(string idUser)
        {
            try
            {
                string queryString = "SELECT Cuenta, Banco, Estado FROM VIAT_CUENTA WHERE Id_Usuario = '" + idUser + "'";
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conexion.Close();
                    return dt;
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion
        #region REGISTRAR DATOS DE LA CUENTA DEL USUARIO
        public void DA_Registrar_CUENTA(VT_Cuenta c)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("VT_CUENTA_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Usuario", c.Id_Usuario);
                    cmd.Parameters.AddWithValue("@Cuenta", c.Cuenta);
                    cmd.Parameters.AddWithValue("@Banco", c.Banco);
                    cmd.Parameters.AddWithValue("@Estado", c.Estado);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }        
        /// <summary>
        /// Actualiza por Usuario, cuenta de banco
        /// </summary>
        /// <param name="c">Objeto</param>
        public void DA_Modificar_CUENTA(VT_Cuenta c)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("VT_CUENTA_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Usuario", c.Id_Usuario);
                    cmd.Parameters.AddWithValue("@Cuenta", c.Cuenta);
                    cmd.Parameters.AddWithValue("@Banco", c.Banco);
                    //cmd.Parameters.AddWithValue("@Estado", c.Estado);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion 
        #region FUNCIONQUE QUE CALCULA EN NUMERO DE SOLICITUDES QUE PRESENTAN UN ESTADO
        public DataTable DA_Contar_SOLICITUIDES_ENVIADAS(string idUsuario, string estado)
        {
            try
            {
                string queryString = "SELECT COUNT (Id_Solicitud) FROM VIAT_SOLICITUD WHERE Id_Usuario = '"+ idUsuario +"' AND Estado = '"+ estado +"'";
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conexion.Close();
                    return dt;
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion

        #region FUNCION PARA DESPLEGAR LISTA DE FUNCIONARIOS QUE REALIZARON VIAJES EN UN INTERBALO DE FECHAS
        public DataTable DA_Seleccionar_VIAJES_PERSONAL_FECHAS(int idreg, DateTime fechaini, DateTime fechafin, string parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("VT_SOLICITUDES_REPORTES", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fechaini", fechaini);
                    cmd.Parameters.AddWithValue("@fechafin", fechafin);
                    cmd.Parameters.AddWithValue("@idReg", idreg);
                    cmd.Parameters.AddWithValue("@Parametro", parametro);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //cmd.ExecuteNonQuery();
                    da.Fill(dt);
                    conexion.Close();
                    return dt;
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion
    }
}
