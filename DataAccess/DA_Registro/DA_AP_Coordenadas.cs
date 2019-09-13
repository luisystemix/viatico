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
    public class DA_AP_Coordenadas
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
        #region REGISTRAR LOS DATOS DE UNA PERSONA
        public void DA_Registrar_AP_COORDENADAS(AP_Coordenadas p)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO AP_COORDENADAS(Id_Plano,Punto,X,Y) Values (@Id_Plano,@Punto,@X,@Y)", conexion);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id_Plano", p.Id_Plano);
                    cmd.Parameters.AddWithValue("@Punto", p.Punto);
                    cmd.Parameters.AddWithValue("@X", p.X);
                    cmd.Parameters.AddWithValue("@Y", p.Y);
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
