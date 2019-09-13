using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DataAccess.DA_Registro
{
    public class DA_AP_Municipio
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        # region SELECCIONA TODoS LOS MUNICIPIOS DE UNA PROVINCIA
        public DataTable ID_PROVINCIA_SeleccionarMunicipios(int id_Prov)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Id_Municipio, Id_Provincia, Nombre FROM  AP_MUNICIPIO WHERE (Id_Provincia = '" + id_Prov + "') ORDER BY Nombre", conexion);
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
    }
}
