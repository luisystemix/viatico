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
    public class DA_AP_Parametros_Camp
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region BUSCAR EN PA TABLA PARAMETROS CAMPAÑA
        public DataTable DA_Desplegar_PARAMETRO_CAMP(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_PARAMETRO_CAMP_SELECT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Campanhia", id);
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
        #region REGISTRAR PARAMETROS DE LA CAMPAÑA
        public void DA_Registrar_PARAMETRO_CAMP(AP_ParametrosCamp pc)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_PARAMETRO_CAMP_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Campanhia", pc.Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Tipo_Produccion", pc.Tipo_Produccion);
                    cmd.Parameters.AddWithValue("@Has_Min", pc.Has_Min);
                    cmd.Parameters.AddWithValue("@Has_Max", pc.Has_Max);
                    cmd.Parameters.AddWithValue("@Programa", pc.Programa);
                    cmd.Parameters.AddWithValue("@Estado", pc.Estado);
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
    }
}
