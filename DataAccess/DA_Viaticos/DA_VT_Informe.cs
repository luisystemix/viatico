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
    public class DA_VT_Informe
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        public DataTable DA_Desplegar_SOLICITUD_OBJETIVOS(string idSolicitud, string parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("VT_INFORME_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", idSolicitud);
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
        #region MODIFICAR EL ESTADO DE LA TABLA DOCUMENTO VERIFICADO
        public void DA_Registrar_INFORME(VT_Informe inf)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("VT_INFORME_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", inf.Id_Solicitud);
                    cmd.Parameters.AddWithValue("@Dirigido_A", inf.Dirigido_A);
                    cmd.Parameters.AddWithValue("@Fecha_Informe", inf.Fecha_Informe);
                    cmd.Parameters.AddWithValue("@Fecha_Aprobacion", inf.Fecha_Aprobacion);
                    cmd.Parameters.AddWithValue("@Conclusion", inf.Conclusion);
                    cmd.Parameters.AddWithValue("@Observacion", inf.Observacion);
                    cmd.Parameters.AddWithValue("@Estado", inf.Estado);
                    cmd.Parameters.AddWithValue("@Objetivo", inf.Objetivo);
                    cmd.Parameters.AddWithValue("@Recomendacion", inf.Recomendacion);
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
        #region MODIFICAR EL ESTADO DE LA TABLA DOCUMENTO VERIFICADO
        public void DA_Registrar_INFORME_ACTIVIDAD(VT_InformeActividad infAct)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("VT_INFORME_ACTIVIDAD_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Informe", infAct.Id_Informe);
                    cmd.Parameters.AddWithValue("@Fecha", infAct.Fecha);
                    cmd.Parameters.AddWithValue("@Actividad", infAct.Actividad);
                    cmd.Parameters.AddWithValue("@Cont", infAct.Cont);
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
        #region SELECCIONAR UN INFORME POR EL ID_DE SOLICITUD
        public DataTable DA_Seleccionar_PLANILLA(string idSolicitud)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("VT_INFORME_CONSULTA", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", idSolicitud);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
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
        public DataTable DA_Reporte_INFORME(string IdSolicitud, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("VT_INFORME_CONSULTAS", conexion);
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
        #region CAMBIAR EL ESTADO DEL INFORME DE VIAJE
        public void DA_Cambiar_ESTADOINF(string idSolicit, string estado)
        {
            try
            {
                string queryString = "UPDATE VIAT_INFORME SET Estado = '" + estado + "' WHERE Id_Solicitud = '" + idSolicit + "' ";
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
        #region OBTENER LA LISTA DE LOS DIAS PARA REALIZAR EL INFORME
        public DataTable DA_Desplegar_INFORME_DIAS(string IdSolicitud, string parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("VT_INFORME_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", IdSolicitud);
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
        #region SELECCIONAR LOS DATOS DE UN INFORME POR EL ID
        public DataTable DA_Seleccionar_INFORME(string IdSolicitud, string parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("VT_INFORME_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", IdSolicitud);
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
        #region MODIFICAR EL INFORME
        public void DA_Modificar_INFORME(VT_Informe inf)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("VT_INFORME_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", inf.Id_Solicitud);
                    cmd.Parameters.AddWithValue("@Conclusion", inf.Conclusion);
                    cmd.Parameters.AddWithValue("@Objetivo", inf.Objetivo);
                    cmd.Parameters.AddWithValue("@Recomendacion", inf.Recomendacion);
                    cmd.Parameters.AddWithValue("@Observacion", inf.Observacion);
                    cmd.Parameters.AddWithValue("@Estado", inf.Estado);
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
        #region MODIFICAR EL INFORME ACTIVIDAD
        public void DA_Modificar_INFORME_ACTIVIDAD(VT_InformeActividad infAct)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("VT_INFORME_ACTIVIDAD_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Informe", infAct.Id_Informe);
                    cmd.Parameters.AddWithValue("@Actividad", infAct.Actividad);
                    cmd.Parameters.AddWithValue("@Cont", infAct.Cont);
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


        #region DESPLEGAR DATOS DE LA ESTRUCTURA DE APROBACION
        public DataTable DA_Desplegar_DATOS_ESTRUCTURA(string Valor)
        {
            try
            {
                string queryString = "SELECT Nombre, Sigla, CI_Responsable, Estado, Id_Estructura FROM VIAT_ESTRUCTURA_ORG WHERE(CI_Responsable = '"+ Valor +"') OR Sigla='"+ Valor +"'";
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
    }
}
