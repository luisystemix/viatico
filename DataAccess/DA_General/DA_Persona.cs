using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataEntity.DE_General;

namespace DataAccess.DA_General
{
    public class DA_Persona
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region BUSCAR UNA PERSONA POR EL NUMERO DE CEDULA DE IDENTIDAD
        public DataTable DA_Buscar_PERSONA(string Parametro)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_PERSONA_SELECT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PARAMETRO", Parametro);
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
        #region REGISTRAR LOS DATOS DE UNA PERSONA 
        public void DA_Registrar_PERSONA(Persona p)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_PERSONA_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Persona", p.ci);
                    cmd.Parameters.AddWithValue("@ci", p.ci);
                    cmd.Parameters.AddWithValue("@ext", p.ext);
                    cmd.Parameters.AddWithValue("@Nombres", p.Nombres);
                    cmd.Parameters.AddWithValue("@Primer_ap", p.Primer_ap);
                    cmd.Parameters.AddWithValue("@Segundo_ap", p.Segundo_ap);
                    cmd.Parameters.AddWithValue("@Fecha_nacimiento", p.Fecha_nacimiento);
                    cmd.Parameters.AddWithValue("@Sexo", p.Sexo);
                    cmd.Parameters.AddWithValue("@Telef_fijo", p.Telef_fijo);
                    cmd.Parameters.AddWithValue("@Telef_cel", p.Telef_cel);
                    cmd.Parameters.AddWithValue("@Fecha_registro", p.Fecha_registro);
                    cmd.Parameters.AddWithValue("@Estado", p.Estado);
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
        #region MODIFICAR LOS DATOS DE UNA PERSONA
        public void DA_Modificar_PERSONA(Persona p)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_PERSONA_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Persona", p.Id_Persona);
                    cmd.Parameters.AddWithValue("@ci", p.ci);
                    cmd.Parameters.AddWithValue("@ext", p.ext);
                    cmd.Parameters.AddWithValue("@Nombres", p.Nombres);
                    cmd.Parameters.AddWithValue("@Primer_ap", p.Primer_ap);
                    cmd.Parameters.AddWithValue("@Segundo_ap", p.Segundo_ap);
                    cmd.Parameters.AddWithValue("@Fecha_nacimiento", p.Fecha_nacimiento);
                    cmd.Parameters.AddWithValue("@Sexo", p.Sexo);
                    cmd.Parameters.AddWithValue("@Telef_fijo", p.Telef_fijo);
                    cmd.Parameters.AddWithValue("@Telef_cel", p.Telef_cel);
                    cmd.Parameters.AddWithValue("@Fecha_registro", p.Fecha_registro);
                    cmd.Parameters.AddWithValue("@Estado", p.Estado);
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
