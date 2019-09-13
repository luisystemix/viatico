using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataEntity.DE_Registro;

namespace DataAccess.DA_Control
{
    public class DA_RegionesApoyadas
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region SELECCIONAR TODOS LOS DATOS DE LA TABLA REGIONAL POR EL ID
        public DataTable DA_Seleccionar_REGIONAL(int idReg)
        {
            try
            {
                string queryString = "SELECT Tipo, Nombre, Departamento, Ci_Responsable, Direccion, Telef_Fijo, Telef_Movil, Region, Estado FROM REGIONAL WHERE Id_Regional = '" + idReg + "'";
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
        #region OBTENER LA LISTA DE LAS CAMPAÑIAS APOYADAS POR EMAPA
        public DataTable DA_Desplegar_CAMP_APOYADAS(string Depart, string Prog, int IdCamp, int IdRegional, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("REP_CAMPANHIA_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Departamento", Depart);
                    cmd.Parameters.AddWithValue("@Programa", Prog);
                    cmd.Parameters.AddWithValue("@IdCamp", IdCamp);
                    cmd.Parameters.AddWithValue("@Id_Regional", IdRegional);
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
