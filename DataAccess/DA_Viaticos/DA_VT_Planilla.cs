using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataEntity.DE_Viaticos;

namespace DataAccess.DA_Viaticos
{
    public class DA_VT_Planilla
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region INSERTAR PLANILLA DE VIAJE
        public void DA_Registrar_PLANILLA(VT_Planilla p)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("VT_PLANILLA_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", p.Id_Solicitud);
                    cmd.Parameters.AddWithValue("@Tot_Num_Dias", p.Tot_Num_Dias);
                    cmd.Parameters.AddWithValue("@Tot_Num_Dias15", p.Tot_Num_Dias15);
                    cmd.Parameters.AddWithValue("@Pago_Total", p.Pago_Total);
                    cmd.Parameters.AddWithValue("@Rc_Iva", p.Rc_Iva);
                    cmd.Parameters.AddWithValue("@Liquido_Pagable", p.Liquido_Pagable);
                    cmd.Parameters.AddWithValue("@Num_Cheque", p.Num_Cheque);
                    cmd.Parameters.AddWithValue("@Tasa_Cambio", p.Tasa_Cambio);
                    cmd.Parameters.AddWithValue("@Fecha", p.Fecha);
                    cmd.Parameters.AddWithValue("@Fecha_Atendido", p.Fecha_Atendido);
                    cmd.Parameters.AddWithValue("@MontoPorDia", p.MontoPorDia);
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
        #region INSERTAR PLANILLA POR DIA DE VIAJE
        public void DA_Registrar_PLANILLADIA(VT_PlanillaDia pd)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("VT_PLANILLA_DIA_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Planilla", pd.Id_Planilla);
                    cmd.Parameters.AddWithValue("@Cont", pd.Cont);
                    cmd.Parameters.AddWithValue("@Num_Dias", pd.Num_Dias);
                    cmd.Parameters.AddWithValue("@Area", pd.Area);
                    cmd.Parameters.AddWithValue("@Destino", pd.Destino);
                    cmd.Parameters.AddWithValue("@Monto", pd.Monto);
                    cmd.Parameters.AddWithValue("@Observacion", pd.Observacion);
                    cmd.Parameters.AddWithValue("@FechaDia", pd.FechaDia);
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
        #region OBTENER LA LISTA DE LAS SOLICITUDES CON EL USUARIO PARA REPORTE SOLICITUD
        public DataTable DA_Reporte_DETALLE_PLANILLA(string IdSolicitud, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("VT_PLANILLA_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", IdSolicitud);
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
        #region MODIFICAR LA PLANILLA DE PAGO
        public void DA_Modificar_PLANILLA(VT_Planilla p)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("VT_PLANILLA_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Planilla", p.Id_Planilla);
                    cmd.Parameters.AddWithValue("@Id_Solicitud", p.Id_Solicitud);
                    cmd.Parameters.AddWithValue("@Tot_Num_Dias", p.Tot_Num_Dias);
                    cmd.Parameters.AddWithValue("@Tot_Num_Dias15", p.Tot_Num_Dias15);
                    cmd.Parameters.AddWithValue("@Pago_Total", p.Pago_Total);
                    cmd.Parameters.AddWithValue("@Pago_Total15", p.Pago_Total15);
                    cmd.Parameters.AddWithValue("@Rc_iva", p.Rc_Iva);
                    cmd.Parameters.AddWithValue("@Liquido_Pagable", p.Liquido_Pagable);
                    cmd.Parameters.AddWithValue("@Num_Cheque", p.Num_Cheque);
                    cmd.Parameters.AddWithValue("@Fecha_Atendido", p.Fecha_Atendido);
                    cmd.Parameters.AddWithValue("@MontoPorDia", p.MontoPorDia);
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
        #region MODIFICAR LA PLANILLA DE PAGO POR DIA
        public void DA_Modificar_PLANILLA_DIA(VT_PlanillaDia pd)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("VT_PLANILLA_DIA_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Planilla", pd.Id_Planilla);
                    cmd.Parameters.AddWithValue("@Cont", pd.Cont);
                    cmd.Parameters.AddWithValue("@Num_Dias", pd.Num_Dias);
                    cmd.Parameters.AddWithValue("@Area", pd.Area);
                    cmd.Parameters.AddWithValue("@Destino", pd.Destino);
                    cmd.Parameters.AddWithValue("@Monto", pd.Monto);
                    cmd.Parameters.AddWithValue("@Observacion", pd.Observacion);
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
        #region SELECCIONAR UNA PLANILLA POR EL ID_DE SOLICITUD
        public DataTable DA_Seleccionar_PLANILLA(string idSolicitud)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("VT_PLANILLA_SELECT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Solicitud", idSolicitud);
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
        #region SELECCIONAR LOS DATOS DE LA CUENTA DE UN USUARIO
        public DataTable DA_Seleccionar_CUENTA(string idUser)
        {
            try
            {
                string queryString = "SELECT Cuenta, Banco, Estado FROM VIAT_CUENTA WHERE Id_Usuario = '" +idUser+ "'";
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
