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
    public class DA_AP_Campanhia
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region DESPLEGAR TODAS LA CAMPAÑIAS
        public DataTable DA_Desplegar_CAMPANHIA()
        {
            try
            {
                string queryString = "SELECT Nombre, CONVERT(Char(10), Fecha_Inicio, 103) As 'Fecha_Inicio', CONVERT(Char(10), Fecha_Final, 103) As 'Fecha_Final', Region, Estado, Id_Campanhia FROM AP_CAMPANHIA ORDER BY Fecha_Final";
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
        #region DESPLEGAR TODAS LA CAMPAÑIAS POR REGION
        public DataTable DA_Desplegar_CAMPANHIA_REGION(string Region)
        {
            try
            {
                string queryString = "SELECT Nombre, CONVERT(Char(10), Fecha_Inicio, 103) As 'Fecha_Inicio', CONVERT(Char(10), Fecha_Final, 103) As 'Fecha_Final', Region, Estado, Id_Campanhia FROM AP_CAMPANHIA WHERE Region= '" + Region + "' ORDER BY Id_Campanhia DESC";
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
        #region REGISTRAR NUEVA CAMPAÑA
        public void DA_Registrar_CAMPANHIA(AP_Campanhia c)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_CAMPANHIA_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", c.Fecha_Inicio);
                    cmd.Parameters.AddWithValue("@Fecha_Final", c.Fecha_Final);
                    cmd.Parameters.AddWithValue("@Region", c.Region);
                    cmd.Parameters.AddWithValue("@Estado", c.Estado);
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
        #region OBTENER LA LISTA DE LAS TABLAS CAMPANHIA => INSCRIPCION_ORG => ORGANIZACION
        public void ExtraerCapanhiaID_INORG(int IdCamp, int IdOrg, ref String nombreOrg, ref String NomPrograma, ref String nombreCamp)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    //DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("GAP_CAMPANHIA_PARAM_ORG", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCAMPANHIA", IdCamp);
                    cmd.Parameters.AddWithValue("@IDORGANIZACION", IdOrg);
                    conexion.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    //rdr.Read();
                    if (rdr.Read())    // En caso de que exista varios valores de retorno sin usar DataTable
                    {
                        nombreOrg = rdr.GetString(rdr.GetOrdinal("ORG_SIGLA"));
                        NomPrograma = rdr.GetString(rdr.GetOrdinal("INS_PROG"));
                        nombreCamp = rdr.GetString(rdr.GetOrdinal("NOM_CAMP"));
                    }
                    else
                    {
                        nombreOrg = "";
                        NomPrograma = "";
                        nombreCamp = "";
                    }
                    conexion.Close();
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion 
        #region BUSCAR CAMPAÑA POR EL ID DE LA CAMPAÑA
        public DataTable DA_Buscar_CAMPANHIA(int id)
        {
            try
            {
                string queryString = "SELECT Id_Campanhia, Nombre, Fecha_Inicio, Fecha_Final, Region, Estado FROM AP_CAMPANHIA WHERE Id_Campanhia= " + id + "";
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
        #region BUSCAR CAMPAÑA POR LA REGION Y EL ESTADO
        public DataTable DA_Seleccionar_CAMPANHIA_REG(string region, string Estado)
        {
            try
            {
                string queryString = "SELECT Id_Campanhia, Nombre, Fecha_Inicio, Fecha_Final, Region, Estado FROM AP_CAMPANHIA WHERE Region= '" + region + "' AND Estado <> '" + Estado + "' ORDER BY Id_Campanhia DESC ";
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
        #region BUSCAR CAMPAÑA POR LA REGION Y EL ESTADO
        public DataTable DA_Seleccionar_CAMPANHIA_REG_NOFIN(string region)
        {
            try
            {
                string queryString = "SELECT Id_Campanhia, Nombre, Fecha_Inicio, Fecha_Final, Region, Estado FROM AP_CAMPANHIA WHERE Region= '" + region + "' AND Estado <> 'FINALIZADO' ";
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


        #region DESPLEGAR TODOS LOS PROGRAMAS DE LA CAMPAÑIAS POR EL ID DEL USUARIO
        public DataTable DA_Desplegar_PROGRAMA_REGION()
        {
            try
            {
                string queryString = "SELECT USUARIO.Id_Usuario, AP_PARAMETROS_CAMP.Programa FROM AP_PARAMETROS_CAMP INNER JOIN AP_CAMPANHIA ON AP_PARAMETROS_CAMP.Id_Campanhia = AP_CAMPANHIA.Id_Campanhia INNER JOIN";
                       queryString +=" USUARIO INNER JOIN REGIONAL ON USUARIO.Id_Regional = REGIONAL.Id_Regional ON AP_CAMPANHIA.Region = REGIONAL.Region";
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

        #region SELECCIONAR LA CAMPAÑA SEGUN SU PROGRAMA PARA VER SI EXISTE Y ESTA ACTIVA
        public DataTable DA_Seleccionar_CAMPANHIA_PROG(int IdCamp,int IdReg, string Programa, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_CAMPANHIA_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Campanhia", IdCamp);
                    cmd.Parameters.AddWithValue("@Id_Regional", IdReg);
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

        #region DESPLEGAR LOS PARAMETROS DE LA CAMPAÑA SELECCIONADA POR ID
        public DataTable DA_Buscar_PARAMETROS_CAMPANHIA(int IdCamp)
        {
            try
            {
                string queryString = "SELECT Id_Campanhia, Tipo_Produccion, Has_Min, Has_Max, Programa, Estado FROM AP_PARAMETROS_CAMP WHERE Id_Campanhia = " + IdCamp + "";
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
    }
}
