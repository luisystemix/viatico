using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataEntity.DE_Registro;

namespace DataAccess.DA_Extensiones
{
    public class DA_EXT_Reportes
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region DESPLEGAR TODAS LA CAMPAÑIAS POR REGION
        public DataTable DA_Desplegar_REGIONALES_NOMBRE(string Camp)
        {
            try
            {
                string queryString = "SELECT REGIONAL.Id_Regional, REGIONAL.Tipo, REGIONAL.Nombre, REGIONAL.Departamento, REGIONAL.Ci_Responsable, REGIONAL.Direccion, REGIONAL.Telef_Fijo, ";
                       queryString += "REGIONAL.Telef_Movil, REGIONAL.Region, REGIONAL.Estado, AP_CAMPANHIA.Nombre AS Camp, AP_CAMPANHIA.Id_Campanhia ";
                       queryString += "FROM REGIONAL INNER JOIN AP_CAMPANHIA ON REGIONAL.Region = AP_CAMPANHIA.Region WHERE AP_CAMPANHIA.Nombre ='" + Camp + "' ORDER BY REGIONAL.Region";
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
        #region OBTENER LA SUPERFICIE INSCRITA Y APOYADA POR REGIONAL 
        public DataTable DA_Obtener_SUPERFICIE_INS_APO(int idcamp, int idreg, int idinsorg, int idmuni, string Programa, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_REPORTES_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Campanhia", idcamp);
                    cmd.Parameters.AddWithValue("@Id_Regional", idreg);
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", idinsorg);
                    cmd.Parameters.AddWithValue("@Id_Municipio", idmuni);
                    cmd.Parameters.AddWithValue("@Programa", Programa);
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
