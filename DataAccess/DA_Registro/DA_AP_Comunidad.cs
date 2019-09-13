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
    public class DA_AP_Comunidad
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        # region SELECCIONA TODAS LAS COMUNIDADES DE UN MUNICIPIO
        public DataTable DA_AP_COMUNIDAD_SeleccionarComu(Int32 id_Mun)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Id_Comunidad, Id_Municipio, Nombre FROM AP_COMUNIDAD WHERE (Id_Municipio = " + id_Mun + ") ORDER BY Nombre", conexion);
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
        #endregion
        #region REGISTRAR NUEVA COMUNIDAD
        public void DA_Registrar_COMUNIDAD(AP_Comunidad c)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_COMUNIDAD_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Municipio", c.Id_Municipio);
                    cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
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

        /********************************/
        #region REGISTRAR NUEVA CAMPAÑA
        public DataTable DA_Buscar_COMU_ORG(Int32 IdInscripOrg, Int32 IdComunidad, String IdPersona, String Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("AUX_VERIFICAR_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", IdInscripOrg);
                    cmd.Parameters.AddWithValue("@Id_Comunidad", IdComunidad);
                    cmd.Parameters.AddWithValue("@Id_Persona", IdPersona);
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
    }
}
