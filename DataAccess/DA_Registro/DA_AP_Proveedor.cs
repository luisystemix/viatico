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
    public class DA_AP_Proveedor
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region REGISTRAR NUEVO PROVEEDOR
        public void DA_Registrar_PROVEEDOR(AP_Proveedor p)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_PROVEEDOR_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Razon_Social", p.Razon_Social);
                    cmd.Parameters.AddWithValue("@NIT", p.NIT);
                    cmd.Parameters.AddWithValue("@Num_Testimonio", p.Num_Testimonio);
                    cmd.Parameters.AddWithValue("@Fecha_Creacion", p.Fecha_Creacion);
                    cmd.Parameters.AddWithValue("@Departamento", p.Departamento);
                    cmd.Parameters.AddWithValue("@Domicilio", p.Domicilio);
                    cmd.Parameters.AddWithValue("@Telefono_Ref", p.Telefono_Ref);
                    cmd.Parameters.AddWithValue("@Correo", p.Correo);
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
        #region BUSCAR UNA EMPRESA PROVEEDORA POR EL NUMERO DE NIT O EL CODIGO INTERNO
        public DataTable DA_Buscar_PROVEEDOR(string valor)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_PROVEEDOR_SELECT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Valor", valor);
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
        #region MODIFICAR LA TABLA PROVEEDOR
        public void DA_Modificar_PROVEEDOR(AP_Proveedor p)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_PROVEEDOR_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Proveedor", p.Id_Proveedor);
                    cmd.Parameters.AddWithValue("@Razon_Social", p.Razon_Social);
                    cmd.Parameters.AddWithValue("@NIT", p.NIT);
                    cmd.Parameters.AddWithValue("@Num_Testimonio", p.Num_Testimonio);
                    cmd.Parameters.AddWithValue("@Fecha_Creacion", p.Fecha_Creacion);
                    cmd.Parameters.AddWithValue("@Departamento", p.Departamento);
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
        #region DESPLEGAR TODAS LA CAMPAÑIAS POR REGION
        public DataTable DA_Desplegar_PROVEEDOR()
        {
            try
            {
                string queryString = "SELECT Id_Proveedor, Razon_Social, NIT, Num_Testimonio, Fecha_Creacion, Departamento FROM INS_PROVEEDOR";
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

        #region SELECCIONAR LA ORGANIZACION PARA REVISAR  SUS DATOS PARA GENERACION DE CONTRATOS
        public DataTable DA_Desplegar_PROVEEDOR_PARAMETROS(string[] valor)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("INS_PROVEEDOR_CONSULTA", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionProv", Convert.ToInt32(valor[0]));
                    cmd.Parameters.AddWithValue("@Id_Campanhia", Convert.ToInt32(valor[1]));
                    cmd.Parameters.AddWithValue("@Id_Regional", Convert.ToInt32(valor[2]));
                    cmd.Parameters.AddWithValue("@Insumo", valor[3].ToString());
                    cmd.Parameters.AddWithValue("@Programa", valor[4].ToString());
                    cmd.Parameters.AddWithValue("@Estado", valor[5].ToString());
                    cmd.Parameters.AddWithValue("@Parametro", valor[6].ToString());
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
