using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataEntity.DE_Extensiones;

namespace DataAccess.DA_Extensiones
{
    public class DA_EXT_DesignacionOrg
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region REGISTRAR LA DESIGNACION DEL TECNICO DE EXTENCIONES
        public void DA_Registrar_DESIGNACION_ORG(EXT_DesignacionOrg d)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_DESIGNACION_ORG_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Usuario", d.Id_Usuario);
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", d.Id_InscripcionOrg);
                    cmd.Parameters.AddWithValue("@Superficie", d.Superficie);
                    cmd.Parameters.AddWithValue("@Num_Productores", d.Num_Productores);
                    cmd.Parameters.AddWithValue("@Estado", d.Estado);
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
        #region SELECCIONAR LA ORGANIZACION PARA REVISAR  SUS DATOS PARA GENERACION DE CONTRATOS
        public DataTable DA_Seleccionar_DESIGNACION_ORG(int IdReg, int IdCamp, string IdUser, string Programa, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_DESIGNACION_ORG_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Regional", IdReg);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", IdCamp);
                    cmd.Parameters.AddWithValue("@Id_Usuario", IdUser);
                    cmd.Parameters.AddWithValue("@Programa", Programa);
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
        #region ELIMINAR UNA FILA DE LA DESIGNACION DE LA ORGANIZACION AL TECNICO
        public void DA_Eliminar_DESIGNACION_ORG(string idusuario, int idinsorg)
        {
            try
            {
                string queryString = "DELETE FROM EXT_DESIGNACION_ORG WHERE Id_Usuario='"+idusuario+"' AND Id_InscripcionOrg="+idinsorg+"";
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conexion.Close();
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion
        #region FUNCION PARA OBTENER EL NUMERO DE ORGANIZACIONES Y NUMERO DE PRODUCTORES TOTAL
        public DataTable DA_Obtener_Numero_ORG_PROD(int idcamp, string programa, int idreg, string parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_DESIGNACION_ORG_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Regional", idreg);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", idcamp);
                    cmd.Parameters.AddWithValue("@Id_Usuario", "jose");
                    cmd.Parameters.AddWithValue("@Programa", programa);
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

        #region FUNCION PARA SELECCIONAR DATOS DE LA TABLA MUESTRA
        public DataTable DA_Seleccionar_DATOS_MUESTRA(int idcamp, string programa, int idreg, string parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_MUESTRA_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Regional", idreg);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", idcamp);
                    cmd.Parameters.AddWithValue("@Programa", programa);
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

        #region REGISTRAR LA DESIGNACION DEL TECNICO DE EXTENCIONES
        public void DA_Actualizar_NUM_PROD(int Id_Regional, int Id_Campanhia, string Id_Usuario,string Programa, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_DESIGNACION_ORG_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Regional", Id_Regional);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Id_Usuario", Id_Usuario);
                    cmd.Parameters.AddWithValue("@Programa", Programa);
                    cmd.Parameters.AddWithValue("@Parametro", Parametro);
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

        public DataTable DA_Seleccionar_DESIGNACION_PROD_ORG_CONSULTAS(int IdReg, int IdCamp, string IdUser, string Programa)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_DESIGNACION_PROD_ORG_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Regional", IdReg);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", IdCamp);
                    cmd.Parameters.AddWithValue("@Id_Usuario", IdUser);
                    cmd.Parameters.AddWithValue("@Programa", Programa);                    
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
    }
}
