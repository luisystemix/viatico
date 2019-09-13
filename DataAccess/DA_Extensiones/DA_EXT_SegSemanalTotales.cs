using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using DataEntity.DE_Viaticos;

namespace DataAccess.DA_Extensiones
{
    public class DA_EXT_SegSemanalTotales
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region OBTENER LA LISTA DE LOS TOTALES DEL SEGUIMIENTO AL CULTIVO
        public DataTable DA_Desplegar_SEG_SEMANAL_TOTAL(int idreg, int idcamp, string programa, string parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_SEG_SEMANAL_TOTAL", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRegional", idreg);
                    cmd.Parameters.AddWithValue("@IdCampanhia", idcamp);
                    cmd.Parameters.AddWithValue("@Programa", programa);
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
        #region OBTENER LA LISTA DE ORGANIZACIONES CONSU SUPERFICEI APOYADA
        public DataTable DA_Desplegar_ORG_SUPERFICIE_APOYADA(int idreg, int idcamp, string programa, string parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_SEG_SEMANAL_TOTAL", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRegional", idreg);
                    cmd.Parameters.AddWithValue("@IdCampanhia", idcamp);
                    cmd.Parameters.AddWithValue("@Programa", programa);
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
        #region OBTIENE 
        public DataTable DA_Desplegar_SEG_SEMANAL_MUESTRA(int idreg, int idcamp, string programa, string idUsuario, string etapa ,DateTime fecha ,string parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_SEG_MUESTRA_TECNICO", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRegional", idreg);
                    cmd.Parameters.AddWithValue("@IdCampanhia", idcamp);
                    cmd.Parameters.AddWithValue("@Programa", programa);
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@Etapa", etapa);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
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
        #region OBTENER EL SEGUIMIENTO DE LAS ADVERSIDADES
        public DataTable DA_Desplegar_SEG_ADVERSIDAD(int idreg, int idcamp, string programa, int year, int month, string parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_SEG_ADVERSIDAD", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRegional", idreg);
                    cmd.Parameters.AddWithValue("@IdCampanhia", idcamp);
                    cmd.Parameters.AddWithValue("@Programa", programa);
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@Month", month);
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
