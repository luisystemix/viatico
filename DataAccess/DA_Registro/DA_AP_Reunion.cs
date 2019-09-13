using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using DataEntity.DE_Registro;

namespace DataAccess.DA_Registro
{
    public class DA_AP_Reunion
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region REGISTRAR EL ACTA DE REUNIONES
        public void DA_Registrar_REUNION(AP_Reunion r)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_REUNION_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Campanhia", r.Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Id_Regional", r.Id_Regional);
                    cmd.Parameters.AddWithValue("@Tipo_Reunion", r.Tipo_Reunion);
                    cmd.Parameters.AddWithValue("@Lugar", r.Lugar);
                    cmd.Parameters.AddWithValue("@Fecha", r.Fecha);
                    cmd.Parameters.AddWithValue("@Conclusion", r.Conclusion);
                    cmd.Parameters.AddWithValue("@Consulta", "REUNION");
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
        #region REGISTRAR LOS PARTICIPANTES DE LA REUNION
        public void DA_Registrar_ASISTENCIA(AP_ReunionAsistencia ar)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_REUNION_ASISTENCIA_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Reunion", ar.Id_Reunion);
                    cmd.Parameters.AddWithValue("@ci", ar.ci);
                    cmd.Parameters.AddWithValue("@Nombre", ar.Nombre);
                    cmd.Parameters.AddWithValue("@Comunidad", ar.Comunidad);
                    cmd.Parameters.AddWithValue("@Municipio", ar.Municipio);
                    cmd.Parameters.AddWithValue("@Representante", ar.Representante);
                    cmd.Parameters.AddWithValue("@Cargo", ar.Cargo);
                    cmd.Parameters.AddWithValue("@Consulta", "ASISTENCIA");
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
        #region REGISTRAR LOS TEMAR QUE SE TRATARON EN LA REUNION
        public void DA_Registrar_TEMAS(AP_ReunionTareas tr)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_REUNION_TAREA_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Reunion", tr.Id_Reunion);
                    cmd.Parameters.AddWithValue("@Criterios", tr.Criterios);
                    cmd.Parameters.AddWithValue("@Consulta", "TEMAS");
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

        #region DESPLEGAR EL REPORTE DEL ACTA DE REUNION
        public DataTable DA_Reporte_REUNIONES(int idreunion, int idcamp, string consult)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_REUNION_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Reunion", idreunion);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", idcamp);
                    cmd.Parameters.AddWithValue("@Consulta", consult);
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
