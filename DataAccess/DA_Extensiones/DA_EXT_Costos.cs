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
    public class DA_EXT_Costos
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region REPORTE SELECCIONA LOS COSTOS Y SUS DETALLE POR LA ETAPA DE CULTIVO Y LA ID DE LA INSCRIPCION DE LA ORGANIZACION
        public DataTable DA_Reporte_COSTOS_DETALLE(int IdInsOrg, string IdProd, int Etapa, int Insumo, int Recurso, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_COSTOS_REPORTE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", IdInsOrg);
                    cmd.Parameters.AddWithValue("@Id_Productor", IdProd);
                    cmd.Parameters.AddWithValue("@Etapa", Etapa);
                    cmd.Parameters.AddWithValue("@Insumo", Insumo);
                    cmd.Parameters.AddWithValue("@Recurso", Recurso);
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

        #region REPORTE SELECCIONA LOS COSTOS Y SUS DETALLE POR LA ETAPA DE CULTIVO Y LA ID DE LA INSCRIPCION DE LA ORGANIZACION
        public DataTable DA_Seleccionar_COSTOS(int idOrg, string idprod, string parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_COSTOS_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", idOrg);
                    cmd.Parameters.AddWithValue("@Id_Productor", idprod);
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

        #region SELECCIONAR TIPO DE RECURSO PARA EL COSTO
        public DataTable DA_Seleccionar_COSTO_TIPO_RECURSO(int valor)
        {
            try
            {
                string queryString = "SELECT Id_Tipo_Insumo, Insumo, Tipo_Insumo FROM INS_TIPO_INSUMO WHERE Id_Tipo_Insumo = " + valor + "";
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
