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
    public class DA_EXT_Cronogramas
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region REGISTRAR CRONOGRAMA
        public void DA_Registrar_CRONOGRAMA(EXT_Cronograma crm)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_CRONOGRAMA_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Campanhia", crm.Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Id_Usuario", crm.Id_Usuario);
                    cmd.Parameters.AddWithValue("@Id_Regional", crm.Id_Regional);
                    cmd.Parameters.AddWithValue("@Nombre", crm.Nombre);
                    cmd.Parameters.AddWithValue("@Fecha_Envio", crm.Fecha_Envio);
                    cmd.Parameters.AddWithValue("@Mes", crm.Mes);
                    cmd.Parameters.AddWithValue("@Semana", crm.Semana);
                    cmd.Parameters.AddWithValue("@Observacion", crm.Observacion);
                    cmd.Parameters.AddWithValue("@Estado", crm.Estado);
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
        /// <summary>
        /// Actualizar Coronograma
        /// </summary>
        /// <param name="crm"></param>
        public void DA_CRONOGRAMA_UPDATE(EXT_Cronograma crm)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_CRONOGRAMA_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Cronograma", crm.Id_Cronograma);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", crm.Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Id_Usuario", crm.Id_Usuario);
                    cmd.Parameters.AddWithValue("@Id_Regional", crm.Id_Regional);
                    cmd.Parameters.AddWithValue("@Nombre", crm.Nombre);
                    cmd.Parameters.AddWithValue("@Fecha_Envio", crm.Fecha_Envio);
                    cmd.Parameters.AddWithValue("@Mes", crm.Mes);
                    cmd.Parameters.AddWithValue("@Semana", crm.Semana);
                    cmd.Parameters.AddWithValue("@Observacion", crm.Observacion);
                    cmd.Parameters.AddWithValue("@Estado", crm.Estado);
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
        #region REGISTRAR CRONOGRAMA DIA
        public void DA_Registrar_CRONOGRAMA_DIA(EXT_CronogramaDias crmDia)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_CRONOGRAMA_DIA_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Cronograma", crmDia.Id_Cronograma);
                    cmd.Parameters.AddWithValue("@FechaLunes", crmDia.FechaLunes);
                    cmd.Parameters.AddWithValue("@Lunes", crmDia.Lunes);
                    cmd.Parameters.AddWithValue("@FechaMartes", crmDia.FechaMartes);
                    cmd.Parameters.AddWithValue("@Martes", crmDia.Martes);
                    cmd.Parameters.AddWithValue("@FechaMiercoles", crmDia.FechaMiercoles);
                    cmd.Parameters.AddWithValue("@Miercoles", crmDia.Miercoles);
                    cmd.Parameters.AddWithValue("@FechaJueves", crmDia.FechaJueves);
                    cmd.Parameters.AddWithValue("@Jueves", crmDia.Jueves);
                    cmd.Parameters.AddWithValue("@FechaViernes", crmDia.FechaViernes);
                    cmd.Parameters.AddWithValue("@Viernes", crmDia.Viernes);
                    cmd.Parameters.AddWithValue("@FechaSabado", crmDia.FechaSabado);
                    cmd.Parameters.AddWithValue("@Sabado", crmDia.Sabado);
                    cmd.Parameters.AddWithValue("@FechaDomingo", crmDia.FechaDomingo);
                    cmd.Parameters.AddWithValue("@Domingo", crmDia.Domingo);
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
        public void DA_CRONOGRAMA_DIA_UPDATE(EXT_CronogramaDias crmDia)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_CRONOGRAMA_DIA_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Cronograma", crmDia.Id_Cronograma);
                    cmd.Parameters.AddWithValue("@FechaLunes", crmDia.FechaLunes);
                    cmd.Parameters.AddWithValue("@Lunes", crmDia.Lunes);
                    cmd.Parameters.AddWithValue("@FechaMartes", crmDia.FechaMartes);
                    cmd.Parameters.AddWithValue("@Martes", crmDia.Martes);
                    cmd.Parameters.AddWithValue("@FechaMiercoles", crmDia.FechaMiercoles);
                    cmd.Parameters.AddWithValue("@Miercoles", crmDia.Miercoles);
                    cmd.Parameters.AddWithValue("@FechaJueves", crmDia.FechaJueves);
                    cmd.Parameters.AddWithValue("@Jueves", crmDia.Jueves);
                    cmd.Parameters.AddWithValue("@FechaViernes", crmDia.FechaViernes);
                    cmd.Parameters.AddWithValue("@Viernes", crmDia.Viernes);
                    cmd.Parameters.AddWithValue("@FechaSabado", crmDia.FechaSabado);
                    cmd.Parameters.AddWithValue("@Sabado", crmDia.Sabado);
                    cmd.Parameters.AddWithValue("@FechaDomingo", crmDia.FechaDomingo);
                    cmd.Parameters.AddWithValue("@Domingo", crmDia.Domingo);
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
        /// <summary>
        /// Insert Cronograma Dias Avance
        /// </summary>
        /// <param name="ColAvance"></param>
        public void DA_Registrar_CRONOGRAMA_DIA_AVANCE(List<EXT_CronogramaDiasAvance> ColAvance)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    foreach (EXT_CronogramaDiasAvance Avance in ColAvance)
                    {
                        SqlCommand cmd = new SqlCommand("EXT_CRONOGRAMA_DIA_AVANCE_INSERT", conexion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id_Cronograma", Avance.Id_Cronograma);
                        cmd.Parameters.AddWithValue("@FechaDia", Avance.FechaDia);
                        cmd.Parameters.AddWithValue("@TareaDia", Avance.TareaDia);
                        cmd.Parameters.AddWithValue("@PorcentajeAvance", Avance.PorcentajeAvance);
                        cmd.Parameters.AddWithValue("@ObservacionAvance", Avance.ObservacionAvance);
                        cmd.Parameters.AddWithValue("@Dia", Avance.Dia);
                        cmd.Parameters.AddWithValue("@FuenteVerificacion", Avance.FuenteVerificacion);
                        cmd.Parameters.AddWithValue("@Observaciones", Avance.Observaciones);
                        conexion.Open();
                        cmd.ExecuteNonQuery();
                        conexion.Close();
                    }                    
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        /// <summary>
        /// Actualiza los avances y observaciones por actividad
        /// </summary>
        /// <param name="ColAvance"></param>
        public void DA_UPDATE_CRONOGRAMA_DIA_AVANCE(List<EXT_CronogramaDiasAvance> ColAvance)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    foreach (EXT_CronogramaDiasAvance Avance in ColAvance)
                    {
                        SqlCommand cmd = new SqlCommand("EXT_CRONOGRAMA_DIA_AVANCE_UPDATE", conexion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id_CronogramaAvance", Avance.Id_CronogramaAvance);
                        cmd.Parameters.AddWithValue("@PorcentajeAvance", Avance.PorcentajeAvance);
                        cmd.Parameters.AddWithValue("@ObservacionAvance", Avance.ObservacionAvance);
                        cmd.Parameters.AddWithValue("@FuenteVerificacion", Avance.FuenteVerificacion);
                        cmd.Parameters.AddWithValue("@Observaciones", Avance.Observaciones);    
                        conexion.Open();
                        cmd.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }

        public void DA_UPDATE_CRONOGRAMA_DIA_AVANCE_ALL(List<EXT_CronogramaDiasAvance> ColAvance)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    foreach (EXT_CronogramaDiasAvance Avance in ColAvance)
                    {                       
                        SqlCommand cmd = new SqlCommand("EXT_CRONOGRAMA_DIA_AVANCE_UPDATE_ALL", conexion);
                        cmd.CommandType = CommandType.StoredProcedure;                       	
                        cmd.Parameters.AddWithValue("@Id_CronogramaAvance", Avance.Id_CronogramaAvance);
                        cmd.Parameters.AddWithValue("@Id_Cronograma", Avance.Id_Cronograma);
                        cmd.Parameters.AddWithValue("@FechaDia", Avance.FechaDia);
                        cmd.Parameters.AddWithValue("@TareaDia", Avance.TareaDia);
                        cmd.Parameters.AddWithValue("@PorcentajeAvance", Avance.PorcentajeAvance);
                        cmd.Parameters.AddWithValue("@ObservacionAvance", Avance.ObservacionAvance);
                        cmd.Parameters.AddWithValue("@Dia", Avance.Dia);
                        cmd.Parameters.AddWithValue("@FuenteVerificacion", Avance.FuenteVerificacion);
                        cmd.Parameters.AddWithValue("@Observaciones", Avance.Observaciones);
                        conexion.Open();
                        cmd.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        public void DA_CRONOGRAMA_DIA_AVANCE_DELETE(List<EXT_CronogramaDiasAvance> ColAvanceDelete)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    foreach (EXT_CronogramaDiasAvance Avance in ColAvanceDelete)
                    {
                        SqlCommand cmd = new SqlCommand("EXT_CRONOGRAMA_DIA_AVANCE_DELETE", conexion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id_CronogramaAvance", Avance.Id_CronogramaAvance);
                        conexion.Open();
                        cmd.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
            }
            catch (Exception err)
            {
                throw (new Exception(err.ToString() + "-" + err.Source.ToString() + "-" + err.Message.ToString()));
            }
        }
        #endregion
        #region OBTENER EL NUMERO TOTAL DE PRODUCTORES y LA SUMA DE LAS SUPERFICIES INSCRITAS Y EJECUTADAS
        public DataTable DA_Desplegar_LISTA_CRONOGRAMAS(string IdUser, int IdCrono, int IdCamp, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_CRONOGRAMA_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Usuario", IdUser);
                    cmd.Parameters.AddWithValue("@Id_Cronograma", IdCrono);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", IdCamp);
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
        /// <summary>
        /// Obtiene datos de Cronograma a Editar-DA
        /// </summary>
        /// <param name="IdCrono"></param>
        /// <param name="Parametro"></param>
        /// <returns></returns>
        public DataTable DA_OBTENER_DATOS_CRONOGRAMA_EDICION(int IdCrono, string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_CRONOGRAMA_DATOS_EDIT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;                    
                    cmd.Parameters.AddWithValue("@Id_Cronograma", IdCrono);                    
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
        /// <summary>
        /// Obtiene todas las Actividades Por Cronogrma
        /// </summary>
        /// <param name="IdCronograma"></param>
        /// <returns></returns>
        public DataTable DA_Desplegar_LISTA_ACTIVIDADES_CRONOGRAMA(int IdCronograma)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EXT_CRONOGRAMA_AVANCE_CONSULTA", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;                    
                    cmd.Parameters.AddWithValue("@Id_Cronograma", IdCronograma);                    
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
        /********************** CRONOGRAMA TECNICO EXTENSION  ***********************/
        #region REGISTRAR CRONOGRAMA
        public void DA_Registrar_CRONOGRAMA_TEC(EXT_CronogramaTec ct)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_CRONOGRAMA_TEC_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Campanhia", ct.Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Id_Regional", ct.Id_Regional);
                    cmd.Parameters.AddWithValue("@Id_Usuario", ct.Id_Usuario);
                    cmd.Parameters.AddWithValue("@Programa", ct.Programa);
                    cmd.Parameters.AddWithValue("@Fecha_Envio", ct.Fecha_Envio);
                    cmd.Parameters.AddWithValue("@Estado", ct.Estado);
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
        #region REGISTRAR CRONOGRAMA
        public void DA_Registrar_CRONOGRAMA_TEC_DETALLE(EXT_CronogramaTecDetalle ctd)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("EXT_CRONOGRAMA_TEC_DETALLE_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Id_Cronograma_Tec", ctd.Id_Cronograma_Tec);
                    cmd.Parameters.AddWithValue("Tarea", ctd.Tarea);
                    cmd.Parameters.AddWithValue("Gestion", ctd.Gestion);
                    cmd.Parameters.AddWithValue("Enero", ctd.Enero);
                    cmd.Parameters.AddWithValue("Febrero", ctd.Febrero);
                    cmd.Parameters.AddWithValue("Marzo", ctd.Marzo);
                    cmd.Parameters.AddWithValue("Abril", ctd.Abril);
                    cmd.Parameters.AddWithValue("Mayo", ctd.Mayo);
                    cmd.Parameters.AddWithValue("Junio", ctd.Junio);
                    cmd.Parameters.AddWithValue("Julio", ctd.Julio);
                    cmd.Parameters.AddWithValue("Agosto", ctd.Agosto);
                    cmd.Parameters.AddWithValue("Septiembre", ctd.Septiembre);
                    cmd.Parameters.AddWithValue("Octubre", ctd.Octubre);
                    cmd.Parameters.AddWithValue("Noviembre", ctd.Noviembre);
                    cmd.Parameters.AddWithValue("Diciembre", ctd.Diciembre);
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
