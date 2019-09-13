using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataEntity.DE_Insumos;

namespace DataAccess.DA_Insumos
{
    public class DA_INS_Distribucion
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region REGISTRAR DISTRIBUCION DE INSUMOS
        public void DA_Registrar_DISTRIBUCION_INSUMO(INS_Distribucion DisIns)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("INS_DISTRIBUCION_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Campanhia", DisIns.Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", DisIns.Id_InscripcionOrg);
                    cmd.Parameters.AddWithValue("@Id_InscripcionProv", DisIns.Id_InscripcionProv);
                    cmd.Parameters.AddWithValue("@Id_Regional", DisIns.Id_Regional);
                    cmd.Parameters.AddWithValue("@Programa", DisIns.Programa);
                    cmd.Parameters.AddWithValue("@Insumo", DisIns.Insumo);
                    cmd.Parameters.AddWithValue("@Fecha_Registro", DisIns.Fecha_Registro);
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
        #region REGISTRAR DETALLE DE DISTRIBUCION DE INSUMOS
        public void DA_Registrar_DISTRIBUCION_DETALLE_INSUMO(INS_DistribucionDetalle DisInsDet)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("INS_DISTRIBUCION_DETALLE_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Distribucion", DisInsDet.Id_Distribucion);
                    cmd.Parameters.AddWithValue("@Num_Bol_Cartera", DisInsDet.Num_Bol_Cartera);
                    cmd.Parameters.AddWithValue("@Id_Productor", DisInsDet.Id_Productor);
                    cmd.Parameters.AddWithValue("@Id_Persona", DisInsDet.Id_Persona);
                    cmd.Parameters.AddWithValue("@Id_Tipo_Insumo", DisInsDet.Id_Tipo_Insumo);
                    cmd.Parameters.AddWithValue("@Nombre_Insumo", DisInsDet.Nombre_Insumo);
                    cmd.Parameters.AddWithValue("@Unidad", DisInsDet.Unidad);
                    cmd.Parameters.AddWithValue("@CantidadDosis", DisInsDet.CantidadDosis);
                    cmd.Parameters.AddWithValue("@Precio", DisInsDet.Precio);
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
        /************** FUNCIONES AUXILIARES ****************/
        #region OBTENER EL CODIGO DE PODUCTOR
        public DataTable DA_Seleccionar_IDPRODUCTOR(int idInsOrg, string Prog, string idPersona)
        {
            try
            {
                string queryString = "SELECT Id_Productor FROM AP_INSCRIPCION_PROD WHERE Programa='" + Prog + "' AND Id_InscripcionOrg=" + idInsOrg + " AND Id_Persona='" + idPersona + "'";
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

        #region OBTENER LA LISTA DE LOS REGISTROS DE LOS INSUMOS DISTRIBUIDOS
        public DataTable DA_Desplegar_INSUMOS_DISTRIBUIDOS(int IdCamp, int IdRegional, string Prog, string insumo, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("INS_DISTRIBUCION_CONSULTA", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Campanhia", IdCamp);
                    cmd.Parameters.AddWithValue("@Id_Regional", IdRegional);
                    cmd.Parameters.AddWithValue("@Programa", Prog);
                    cmd.Parameters.AddWithValue("@Insumo", insumo);
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
