using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess.DA_Registro
{
    public class DA_AP_Departamento
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        # region SELECCIONA TODOS LOS DEPARTAMENTOS 
        public DataTable DA_Desplegar_DEPARTAMENTOS()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Id_Departamento, Nombre, Ext FROM VIAT_DEPARTAMENTO WHERE Id_Pais=29 ", conexion);
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
        //# region SELECCIONA LA PROVINCIA POR EL ID
        //public String SeleccionarProv(Int32 id_Prov)
        //{
        //    try
        //    {
        //        using (SqlConnection conexion = new SqlConnection(conexionString))
        //        {
        //            String Prov = "";
        //            SqlConnection CN = new SqlConnection(conexionString);
        //            SqlCommand query = new SqlCommand("SELECT Id_Provincia, Nombre, Departamento FROM AP_PROVINCIA WHERE (Id_Provincia = " + id_Prov + ")", CN);
        //            SqlDataReader Reader;
        //            query.Connection.Open();
        //            Reader = query.ExecuteReader();
        //            if (Reader.Read())
        //            {
        //                Prov = Reader.GetString(0);
        //            }
        //            query.Connection.Close();
        //            return Prov;
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
        //    }
        //}
        //#endregion
    }
}
