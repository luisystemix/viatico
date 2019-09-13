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
    public class DA_AP_InscripcionProv
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region REGISTRAR NUEVA INSCRIPCION DE PROVEEDOR
        public void DA_Registrar_INSCRIP_PROVEEDOR(AP_InscripcionProv ip)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_INSCRIPCION_PROV_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Campanhia", ip.Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Id_Proveedor", ip.Id_Proveedor);
                    cmd.Parameters.AddWithValue("@Id_Regional", ip.Id_Regional);
                    cmd.Parameters.AddWithValue("@Insumo", ip.Insumo);
                    cmd.Parameters.AddWithValue("@Programa", ip.Programa);
                    cmd.Parameters.AddWithValue("@Matricula_Comercio", ip.Matricula_Comercio);
                    cmd.Parameters.AddWithValue("@Domicilio", ip.Domicilio);
                    cmd.Parameters.AddWithValue("@Estado", ip.Estado);
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
        #region BUSCAR LA INSCRIPCION DE PROVEEDOR POR EL ID DE INSCRIPCION
        public DataTable DA_Buscar_INSCRPCION_PROV(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_INSCRIPCION_PROV_SELECT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionProv", id);
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
        #region MODIFICAR LA TABLA INSCRIPCION PROVEEDOR
        public void DA_Modificar_INSCRIP_PROVEEDOR(AP_InscripcionProv ip)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_INSCRIPCION_PROV_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Matricula_Comercio", ip.Matricula_Comercio);
                    cmd.Parameters.AddWithValue("@Domicilio", ip.Domicilio);
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
        /***************************/
        #region REGISTRAR CONTRATO DE INSUMOS
        public void DA_Registrar_CONTRATO_INSUMO(INS_ContratoInsumo ci)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("INS_CONTRATO_INSUMO_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionProv", ci.Id_InscripcionProv);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", ci.Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Id_Regional", ci.Id_Regional);
                    cmd.Parameters.AddWithValue("@Insumo", ci.Insumo);
                    cmd.Parameters.AddWithValue("@Programa", ci.Programa);
                    cmd.Parameters.AddWithValue("@MontoTotal", ci.MontoTotal);
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
        #region REGISTRAR CONTRATO DETALLE DE INSUMOS
        public void DA_Registrar_CONTRATO_INSUMO_DETALLE(INS_DetalleInsumo di)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("INS_DETALLE_INSUMO_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Contrato_Insumo", di.Id_Contrato_Insumo);
                    cmd.Parameters.AddWithValue("@Id_Tipo_Insumo", di.Id_Tipo_Insumo);
                    cmd.Parameters.AddWithValue("@Nombre_Insumo", di.Nombre_Insumo);
                    cmd.Parameters.AddWithValue("@Caracteristica", di.Caracteristica);
                    cmd.Parameters.AddWithValue("@Unidad", di.Unidad);
                    cmd.Parameters.AddWithValue("@CantidadDosis", di.CantidadDosis);
                    cmd.Parameters.AddWithValue("@Num_apli", di.Num_apli);
                    cmd.Parameters.AddWithValue("@Precio", di.Precio);
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

        #region SELECCIONAR EL CONTRATO DE INSUMO POR EL PRODUTO O INSUMO
        public DataTable DA_Seleccionar_CONTRATO_PROV(int contador, int idinsProv, int tipoinsumo, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("INS_CONTRATO_INSUMO_CONSULTA", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Contador", contador);
                    cmd.Parameters.AddWithValue("@Id_InscripcionProv", idinsProv);
                    cmd.Parameters.AddWithValue("@Id_Tipo_Insumo", tipoinsumo);
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
