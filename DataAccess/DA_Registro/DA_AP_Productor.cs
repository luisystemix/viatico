using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataAccess.DA_Registro;
using DataEntity.DE_Registro;

namespace DataAccess.DA_Registro
{
    public class DA_AP_Productor
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region MODIFICAR LOS EL ESTADO DE LA TABLA INSCRIOCION PRODUCTOR
        public void DA_Modificar_ESTADO(AP_Productor p)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_PRODUCTOR_ESTADO_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Productor", p.Id_Productor);
                    cmd.Parameters.AddWithValue("@Estado", p.Estado);
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
        #region MODIFICAR LOS EL ESTADO DE LA TABLA INSCRIOCION PRODUCTOR OJOJOJOJOJOJOJOJJJJJJJJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJOJO
        public void DA_Modificar_OBSERVACION(AP_Productor p)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_PRODUCTOR_OBSERVACION_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Productor", p.Id_Productor);
                    cmd.Parameters.AddWithValue("@Observacion", p.Observacion);
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

        #region #region SELECCIONA DATOS DE UN PRODUCTOR PARA SU ENCABEZADO POR SU ID
        public DataTable DB_Seleccionar_ENCABEZADO_PROD(string idInsProd, string parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_PRODUCTOR_CONSULTA", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Productor", idInsProd);
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
