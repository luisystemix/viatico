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
    public class DA_EXT_DesignacionProd
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region SELECCIONAR LOS PRODUCTORES DE LA ORGANIZACION DESIGNADA
        public DataTable DA_Desplegar_DESIGNACION_PROD(string IdUser, int IdCampanhia, int IdRegional, string Programa, int IdInsOrg, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_DESIGNACION_PROD_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Usuario", IdUser);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", IdCampanhia);
                    cmd.Parameters.AddWithValue("@Id_Regional", IdRegional);
                    cmd.Parameters.AddWithValue("@Programa", Programa);
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", IdInsOrg);
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
        #region REGISTRAR NUEVA PRODUCTORES SELECCIONADOS
        public void DA_Registrar_DESIGNACION_PROD(EXT_DesignacionProd dp)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_DESIGNACION_PROD_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Usuario", dp.Id_Usuario);
                    cmd.Parameters.AddWithValue("@Id_Productor", dp.Id_Productor);
                    cmd.Parameters.AddWithValue("@Etapa", dp.Etapa);
                    cmd.Parameters.AddWithValue("@Estado", dp.Estado);
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
        #region CAMBIAR EL ETAPA DEL SEGUIMIENTO EN LA TABLA DE DESIGNACION DE PRODUCTOR
        public void DA_Cambiar_ESTADO(string IdProductor, string etapa)
        {
            try
            {
                string queryString = "UPDATE EXT_DESIGNACION_PROD SET Etapa = '" + etapa + "' WHERE Id_Productor = '" + IdProductor + "' ";
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conexion.Close();
                    //return dt;
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion
        # region SELECCIONA TODoS LOS PRODUCTORES ASIGNADOS Y HABILITADOS
        public DataTable DA_Seleccionar_PROD_ASIGNADO(string IdProductor)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Id_Usuario, Etapa, Estado FROM EXT_DESIGNACION_PROD WHERE Id_Productor = '" + IdProductor + "'", conexion);
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

        #region REGISTRAR LOS TADOS DE LA MUESTRA VALIDA
        public void DA_Registrar_MUESTRA(EXT_MuestraSeguimiento m)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_MUESTRA_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Campanhia", m.Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Id_Regional", m.Id_Regional);
                    cmd.Parameters.AddWithValue("@Programa", m.Programa);
                    cmd.Parameters.AddWithValue("@Num_Org", m.Num_Org);
                    cmd.Parameters.AddWithValue("@Num_Prod", m.Num_Prod);
                    cmd.Parameters.AddWithValue("@Num_Muestra", m.Num_Muestra);
                    cmd.Parameters.AddWithValue("@Num_Tecnicos", m.Num_Tecnicos);
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
        #region LISTAR TODAS LAS MUESTRA DE LA CAMPAÑA, LA REGIONAL Y LOS PROGRAMAS
        public DataTable DA_Desplegar_MUESTRA(int idcamp, int idreg ,string programa ,string parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_MUESTRA_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Campanhia", idcamp);
                    cmd.Parameters.AddWithValue("@Id_Regional", idreg);
                    cmd.Parameters.AddWithValue("@Programa", programa);
                    cmd.Parameters.AddWithValue("@Parametro", parametro);
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

        #region MODIFICAR LOS TADOS DE LA MUESTRA VALIDA
        public void DA_Modificar_MUESTRA(EXT_MuestraSeguimiento m)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_MUESTRA_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Muestra", m.Id_Muestra);
                    cmd.Parameters.AddWithValue("@Num_Org", m.Num_Org);
                    cmd.Parameters.AddWithValue("@Num_Prod", m.Num_Prod);
                    cmd.Parameters.AddWithValue("@Num_Muestra", m.Num_Muestra);
                    cmd.Parameters.AddWithValue("@Num_Tecnicos", m.Num_Tecnicos);
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
