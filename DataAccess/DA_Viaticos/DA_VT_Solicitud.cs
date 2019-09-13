using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using DataEntity.DE_Viaticos;
using System.Globalization;

namespace DataAccess.DA_Viaticos
{
    public class DA_VT_Solicitud
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        public DataTable DA_Desplegar_SOLICITUD_USUARIO(string iduser, string estado, string parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("VT_SOLICITUDES_USUARIO", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Usuario", iduser);
                    cmd.Parameters.AddWithValue("@Estado", estado);
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
        #region OBTENER LA LISTA DE SOLICITUDES Y SUS DESTINOS
        public DataTable DA_Desplegar_SOLICITUD_DESTINOS(string idSolicit)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("VT_SOLICITUD_DESTINO", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", idSolicit);
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
        #region OBTENER LA LISTA DE LAS SOLICITUDES CON EL USUARIO PARA REPORTE SOLICITUD
        public DataTable DA_Reporte_SOLICITUD_US(string IdSolicitud, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("VT_SOLICITUD_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", IdSolicitud);
                    cmd.Parameters.AddWithValue("@Parametro", Parametro);
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
        #region DA OBTENER DATOS DE INMEDIATO SUPERIOR POR CI
        public DataTable DA_Datos_InmediatoSuperior_GET(string ci_inm_superior)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("VT_INM_SUPERIOR", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ci_superior", ci_inm_superior);                    
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
        #region CAMBIAR EL ESTADO DE LA SOLICITUD DE VIAJE
        public void DA_Cambiar_ESTADO(string idSolicit, string estado)
        {
            try
            {
                string queryString = "UPDATE VIAT_SOLICITUD SET Estado = '"+estado+"' WHERE Id_Solicitud = '"+idSolicit+"' ";
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conexion.Close();
                    //return dt;
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion
        #region OBTENER El NUMERO DE FILAS DE LÑA TABLA SOLICITUD_DESTINO
        public int DA_Numero_Filas_SOLICITUD(string IdSol)
        {
            //lrojas:29/08/2016 se agrego cont > 0
            string queryString = "SELECT count(*) from VIAT_SOLICITUD_DESTINO WHERE Cont > 0 AND Id_Solicitud = '" + IdSol + "'";
            using (SqlConnection connection = new SqlConnection(conexionString))
            {
                SqlCommand rep = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader myReader = rep.ExecuteReader();
                int CodigoProd = 0;
                if (myReader.Read())
                {
                    CodigoProd = Convert.ToInt32(myReader[0].ToString());
                }
                connection.Close();
                return CodigoProd;
            }
        }
          /*public int DA_Numero_Filas_SOLICITUD(string IdSol)
            {
                string queryString = "SELECT DATEDIFF(DAY, (SELECT MIN(Fecha_Salida) FROM VIAT_SOLICITUD_DESTINO WHERE Id_Solicitud = '" + IdSol + "'),(SELECT MAX(Fecha_Salida) FROM VIAT_SOLICITUD_DESTINO WHERE Id_Solicitud = '" + IdSol + "')) + 1";
                using (SqlConnection connection = new SqlConnection(conexionString))
                {
                    SqlCommand rep = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader myReader = rep.ExecuteReader();
                    int CodigoProd = 0;
                    if (myReader.Read())
                    {
                        CodigoProd = Convert.ToInt32(myReader[0].ToString());
                    }
                    connection.Close();
                    return CodigoProd;
                }
            }*/
        #endregion
        #region LISTAR LA TABLA DESTINOS DE LA SOLICITUD POR ID y TRAMO
        public DataTable DA_Seleccionar_SOLICITUD_DESTINO(string IdSol, int Cont)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("VT_SOLICITUD_DESTINO_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", IdSol);
                    cmd.Parameters.AddWithValue("@Cont", Cont);
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
        #region OBTENER NUMERO DE DIAS, HORAS y MINUTOS DE DOS FECHAS
        public int DA_NumDHM(DateTime f1, DateTime f2, string param)
        {
            //string queryString = "Select DATEDIFF(" + param + ",'" + f1.ToString("dd/MM/yyyy HH:mm:ss") + "' , '" + f2.ToString("dd/MM/yyyy HH:mm:ss") + "')";
            string queryString = "Select DATEDIFF(" + param + ",'" + f1.ToString("yyyy-MM-dd h:mm tt", CultureInfo.InvariantCulture) + "' , '" + f2.ToString("yyyy-MM-dd h:mm tt", CultureInfo.InvariantCulture) + "')";
            using (SqlConnection connection = new SqlConnection(conexionString))
            {
                SqlCommand rep = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader myReader = rep.ExecuteReader();
                int CodigoProd = 0;
                if (myReader.Read())
                {
                    CodigoProd = Convert.ToInt32(myReader[0].ToString());
                }
                connection.Close();
                return CodigoProd;
            }
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        public DataTable DA_Seleccionar_SOLICITUD(string IdSolicitud)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("VT_SOLICITUD", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", IdSolicitud);
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
        #region MODIFICAR LA SOLICITUD
        public void DA_Modificar_SOLICITUD(VT_Solicitud s)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("VT_SOLICITUD_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", s.Id_Solicitud);
                    cmd.Parameters.AddWithValue("@Tipo_Viaje", s.Tipo_Viaje);
                    cmd.Parameters.AddWithValue("@Motivo_Viaje", s.Motivo_Viaje);
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
        #region MODIFICAR LA SOLICITUD_DESTINO
        public void DA_Modificar_SOLICITUD_DESTINO(VT_SolicitudDestino sd)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("VT_SOLICITUD_DESTINO_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", sd.Id_Solicitud);
                    cmd.Parameters.AddWithValue("@Cont", sd.Cont);
                    cmd.Parameters.AddWithValue("@Zona", sd.Zona);
                    cmd.Parameters.AddWithValue("@Destino", sd.Destino);
                    cmd.Parameters.AddWithValue("@Lugar", sd.Lugar);
                    cmd.Parameters.AddWithValue("@Objetivo", sd.Objetivo);
                    cmd.Parameters.AddWithValue("@Fecha_Salida", sd.Fecha_Salida);
                    cmd.Parameters.AddWithValue("@Via_Transporte", sd.Via_Transporte);
                    cmd.Parameters.AddWithValue("@Tipo_Transporte", sd.Tipo_Transporte);
                    cmd.Parameters.AddWithValue("@Nombre_Transporte", sd.Nombre_Transporte);
                    cmd.Parameters.AddWithValue("@Identificador_Trasporte", sd.Identificador_Trasporte);
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
        //*ini* lrojas: 30/08/2016
        /// <summary>
        /// Data Access: Modifica Solicitud Destino, reordena en campo CONT
        /// </summary>
        /// <param name="sd">Objeto_Solicitud_Destino</param>
        /// <param name="nuevo_cont">Envia Nuevo Contador</param>
        public void DA_Modificar_SOLICITUD_DESTINO_CONT(VT_SolicitudDestino ObjSD, int Nuevo_Cont)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("VT_SOLICITUD_DESTINO_UPDATE_CONT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", ObjSD.Id_Solicitud);
                    cmd.Parameters.AddWithValue("@Nuevo_Cont", Nuevo_Cont);                    
                    cmd.Parameters.AddWithValue("@Cont", ObjSD.Cont);
                    cmd.Parameters.AddWithValue("@Tramo", ObjSD.Tramo);
                    cmd.Parameters.AddWithValue("@Zona", ObjSD.Zona);
                    cmd.Parameters.AddWithValue("@Destino", ObjSD.Destino);
                    cmd.Parameters.AddWithValue("@Lugar", ObjSD.Lugar);
                    cmd.Parameters.AddWithValue("@Objetivo", ObjSD.Objetivo);
                    cmd.Parameters.AddWithValue("@Fecha_Salida", ObjSD.Fecha_Salida);
                    cmd.Parameters.AddWithValue("@Via_Transporte", ObjSD.Via_Transporte);
                    cmd.Parameters.AddWithValue("@Tipo_Transporte", ObjSD.Tipo_Transporte);
                    cmd.Parameters.AddWithValue("@Nombre_Transporte", ObjSD.Nombre_Transporte);
                    cmd.Parameters.AddWithValue("@Identificador_Trasporte", ObjSD.Identificador_Trasporte);
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
        //*fin*
        #endregion
        #region REGISTRAR OBSERVACIONES SOLICITUDES DE VIAJE
        public void DA_Registrar_OBSERVACION_SOLICITUD(VT_Observacion o)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("VT_OBSERVACION_SOLICITUD_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", o.Id_Solicitud);
                    cmd.Parameters.AddWithValue("@Observacion", o.Observacion);
                    cmd.Parameters.AddWithValue("@Tipo", o.Tipo);
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
        #region SELECCIONAR OBSERVACION
        public DataTable DA_Seleccionar_OBSERVACION_SOLICITUD(string idsolicitud)
        {
            try
            {
                string queryString = "SELECT Observacion, Tipo FROM VIAT_OBSERVACION WHERE Id_Solicitud='" + idsolicitud + "'";
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
        #region ELIMINAR OBSERVACION
        public void DA_Eliminar_OBSERVACION(string idSolicit)
        {
            try
            {
                string queryString = "DELETE FROM VIAT_OBSERVACION WHERE Id_Solicitud = '" + idSolicit + "' ";
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conexion.Close();
                    //return dt;
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion
        #region ANULAR UNBA SOLICITUD DE VIAJE
        public void DA_Anular_SOLICITUD(string idSolicit, string Detalle, string estado)
        {
            try
            {
                string queryString = "UPDATE VIAT_SOLICITUD SET Estado = '" + estado + "', Descrip_Motivo='"+ Detalle +"'  WHERE Id_Solicitud = '" + idSolicit + "' ";
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conexion.Close();
                    //return dt;
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion
        //**lrojas-25/08/2016
        #region ELIMINAR UNA SOLICITUDE DE DESTINO
        /// <summary>
        /// Elimina un destino (actualiza contador a 0), fechadelete se la obtiene 'getdate()' al actualizar
        /// </summary>
        /// <param name="idSolicitud"></param>
        /// <param name="NroRegistro"></param>
        /// <param name="FechaDelete"></param>
        public void DA_DELETE_SOLICITUD_DESTINO(string idSolicitud, string NroRegistro, DateTime FechaDelete)
        {
            try
            {
                //fechadelete se la obtiene 'getdate()' al actualizar 
                //string queryString = "UPDATE VIAT_SOLICITUD_DESTINO SET Cont = " + 0 + ",Fecha_Salida= GETDATE() WHERE Id_Solicitud = '" + idSolicitud + "' AND Cont =" + NroRegistro;
                string queryString = "UPDATE VIAT_SOLICITUD_DESTINO SET Cont = " + 0 + "WHERE Id_Solicitud = '" + idSolicitud + "' AND Cont =" + NroRegistro;
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conexion.Close();
                    //return dt;
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion
        //**
    }
}
