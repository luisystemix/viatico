using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataEntity.DE_Registro;

namespace DataAccess.DA_Registro
{
    public class DA_AP_CronogramaCamp
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region FUNCION PARA DESPLEGAR LA LISTA DE ACTIVIDADES
        public DataTable DB_Desplegar_ACTIVIDADES_CAMP()
        {
            try
            {
                string queryString = "SELECT  ROW_NUMBER() OVER (ORDER BY Id_Actividad) AS RowNumber,Id_Actividad, Actividad, Estado, Estado_Camp FROM AP_ACTIVIDADES WHERE Estado=1";
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
        #region FUNCIONES INDEPENDIENTES PARA REGISTRAR EL CRONOGRAMA
        public void DA_Registrar_CRONOGRAMA(AP_CronogramaCamp c)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_CRONOGRAMA_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Campanhia", c.Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Id_Regional", c.Id_Regional);
                    cmd.Parameters.AddWithValue("@Programa", c.Programa);
                    cmd.Parameters.AddWithValue("@Tipo", c.Tipo);
                    cmd.Parameters.AddWithValue("@Fecha", c.Fecha);
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
        #endregion
        #region FUNCIONES INDEPENDIENTES PARA REGISTRAR EL CRONOGRAMA DETALL
        public void DA_Registrar_CRONOGRAMA_DETALLE(AP_CronogramaCampDetalle cd)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_CRONOGRAMA_DETALLE_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Cronograma", cd.Id_Cronograma);
                    cmd.Parameters.AddWithValue("@Id_Actividad", cd.Id_Actividad);
                    cmd.Parameters.AddWithValue("@Numero", cd.Numero);
                    cmd.Parameters.AddWithValue("@Inicio_Planificado", cd.Inicio_Planificado);
                    cmd.Parameters.AddWithValue("@Final_Planificado", cd.Final_Planificado);
                    cmd.Parameters.AddWithValue("@Inicio_Ejecutado", cd.Inicio_Ejecutado);
                    cmd.Parameters.AddWithValue("@Final_Ejecutado", cd.Final_Ejecutado);
                    cmd.Parameters.AddWithValue("@Observacion", cd.Observacion);
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
        #region OBTENER EL NUMERO TOTAL DE PRODUCTORES y LA SUMA DE LAS SUPERFICIES INSCRITAS Y EJECUTADAS
        public DataTable DA_Desplegar_LISTA_CRONOGRAMAS(int Id, string Parametro) 
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_CRONOGRAMA_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Parametro", Parametro);
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
    }
}
