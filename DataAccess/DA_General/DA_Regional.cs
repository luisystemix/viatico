using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataEntity.DE_Registro;

namespace DataAccess.DA_General
{
    public class DA_Regional
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region DESPLEGAR TODOS LOS DATOS DE LA TABLA REGIONAL
        public DataTable DA_Desplegar_REGIONAL()
        {
            try
            {
                string queryString = "SELECT Id_Regional, Tipo, Nombre, Departamento, Ci_Responsable, Direccion, Telef_Fijo, Telef_Movil, Region, Estado, IdRegional_Padre FROM REGIONAL";
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
        #region SELECCIONAR TODOS LOS DATOS DE LA TABLA REGIONAL POR EL ID
        public DataTable DA_Seleccionar_REGIONAL(int idReg)
        {
            try
            {
                string queryString = "SELECT Tipo, Nombre, Departamento, Ci_Responsable, Direccion, Telef_Fijo, Telef_Movil, Region, Estado FROM REGIONAL WHERE Id_Regional = '"+idReg+"'";
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
        #region OBTENER LA LISTA DE LAS TABLAS ORGANIZACION => INSCRIPCION_ORG => DOCUMENTO_PRESENTADO
        public DataTable DA_Desplegar_REGIONAL_DATOS()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_REGIONAL_DATOS_SELECT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
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
        #region SELECCIONAR TODOS LOS DATOS DE LA TABLA REGIONAL POR EL ID
        public DataTable DA_Seleccionar_VEHICULO(int IdVehiculo)
        {
            try
            {
                string queryString = "SELECT Id_Vehiculo, Id_Regional,Lower(Marca)+'/'+Lower(Tipo)+'/'+ Placa as Placa, Marca, Modelo, Anhio, Estado, Tipo FROM EXT_VEHICULO WHERE Id_Regional = '" + IdVehiculo + "'";
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
