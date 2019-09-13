using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccess.DA_Viaticos
{
    public class DA_VT_Feriado
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        public DataTable DA_Feriado_ObtenerListado(int Id_Regional)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("VT_FERIADOS_GET", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Regional", Id_Regional);
                    //cmd.Parameters.AddWithValue("@Parametro", Parametro);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
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
        public DateTime DA_GET_DATE_SERVER()
        {
            string queryString = "SELECT GETDATE()";
            using (SqlConnection connection = new SqlConnection(conexionString))
            {
                SqlCommand rep = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader myReader = rep.ExecuteReader();
                DateTime Date_Server = new  DateTime();
                if (myReader.Read())
                {
                    Date_Server =  Convert.ToDateTime(myReader[0].ToString());
                }
                connection.Close();
                return Date_Server;
            }
        }
    }
}
