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
    public class DA_AP_Organizacion
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region REGISTRAR LA ORGANIZACION
        public void DA_Registrar_ORG(AP_Organizacion o)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_ORGANIZACION_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PERSONERIA_JURIDICA", o.Personeria_Juridica);
                    cmd.Parameters.AddWithValue("@SIGLA", o.Sigla);
                    cmd.Parameters.AddWithValue("@DEPARTAMENTO", o.Departamento);
                    cmd.Parameters.AddWithValue("@RESOLUCION_PREFECT", o.Resolucion_Prefect);
                    cmd.Parameters.AddWithValue("@FECHA_CREACION", o.Fecha_Creacion);
                    cmd.Parameters.AddWithValue("@TIPO", o.Tipo);
                    cmd.Parameters.AddWithValue("@DIMICILIO", o.DomicilioOrg);
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
        #region REGISTRAR LA INSCRIPCION DE UNA ORGANIZACION
        public void DA_Registrar_INSCRIP_ORG(AP_InscripcionOrg io)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_INSCRIPCION_ORG_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Organizacion", io.Id_Organizacion);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", io.Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Id_Regional", io.Id_Regional);
                    cmd.Parameters.AddWithValue("@Programa", io.Programa);
                    cmd.Parameters.AddWithValue("@Fecha_Registro", io.Fecha_Registro);
                    cmd.Parameters.AddWithValue("@Tipo_Produccion", io.Tipo_Produccion);
                    cmd.Parameters.AddWithValue("@Estado", io.Estado);
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
        #region REGISTRAR AL REPRESENTANTE LEGAL DE UNA ORGANIZACION
        public void DA_Registrar_REPRESENT_LEGAL(AP_RepresentLegal rl)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_REPRESENTANTE_LEGAL_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Persona", rl.Id_Persona);
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", rl.Id_InscripcionOrg);
                    cmd.Parameters.AddWithValue("@Tipo_Poder", rl.Tipo_Poder);
                    cmd.Parameters.AddWithValue("@Nun_Testimonio", rl.Nun_Testimonio);
                    cmd.Parameters.AddWithValue("@Domicilio", rl.Domicilio);
                    cmd.Parameters.AddWithValue("@Fecha", rl.Fecha);
                    cmd.Parameters.AddWithValue("@Num_Notaria", rl.Num_Notaria);
                    cmd.Parameters.AddWithValue("@Distrito_Judicial", rl.Distrito_Judicial);
                    cmd.Parameters.AddWithValue("@Abg_A_Cargo", rl.Abg_A_Cargo);
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
        #region BUSCAR ORGANIZACION POR EL ID DE LAORGANIZACION
        public DataTable DA_Buscar_ORG(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_ORGANIZACION_SELECT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Organizacion", id);
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

        # region BUSCAR ORGANIZACION POR DEPARTAMENTO
        /// <summary>
        /// Selecciona Organizaciones por Departamento
        /// </summary>
        /// <param name="Dep"></param>
        /// <returns></returns>
        public DataTable SeleccionarOrganizacion(String Dep)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();                    
                    SqlCommand cmd = new SqlCommand("SELECT Id_Organizacion,Personeria_Juridica,Sigla,Departamento,Resolucion_Prefect,Fecha_Creacion,Tipo,DomicilioOrg FROM  AP_ORGANIZACION WHERE (Departamento = '" + Dep + "') ORDER BY Sigla", conexion);
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

        #region BUSCAR LA INSCRIPCION DE ORGANIZACION POR EL ID DE INSCRIPCION
        public DataTable DA_Buscar_INSCRPCION_ORG(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_INSCRIPCION_ORG_SELECT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", id);
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
        #region BUSCAR AL REPRESENTANTE LEGAL DE UNA ORGANIZACION POR EL ID DE INSCRIPCION
        public DataTable DA_Buscar_REPRESENT_LEGAL(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_REPRESENTANTE_LEGAL_SELECT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", id);
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
        #region MODIFICAR LA ORGANIZACIONES
        public void DA_Modificar_ORG(AP_Organizacion o)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_ORGANIZACION_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Organizacion", o.Id_Organizacion);
                    cmd.Parameters.AddWithValue("@Personeria_Juridica", o.Personeria_Juridica);
                    cmd.Parameters.AddWithValue("@Sigla", o.Sigla);
                    cmd.Parameters.AddWithValue("@Departamento", o.Departamento);
                    cmd.Parameters.AddWithValue("@Resolucion_Prefect", o.Resolucion_Prefect);
                    cmd.Parameters.AddWithValue("@Fecha_Creacion", o.Fecha_Creacion);
                    cmd.Parameters.AddWithValue("@Tipo", o.Tipo);
                    cmd.Parameters.AddWithValue("@DomicilioOrg", o.DomicilioOrg);
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
        #region MODIFICAR LA INSCRIPCION DE UNA ORGANIZACION
        public void DA_Modificar_INSCRIP_ORG(AP_InscripcionOrg io)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_INSCRIPCION_ORG_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", io.Id_InscripcionOrg);
                    cmd.Parameters.AddWithValue("@Estado", io.Estado);
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
        #region MODIFICAR DATOS DEL REPRESENTANTE LEGAL DE UNA ORGANIZACION
        public void DA_Modificar_REPRESENT_LEGAL(AP_RepresentLegal rl)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_REPRESENTANTE_LEGAL_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Persona", rl.Id_Persona);
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", rl.Id_InscripcionOrg);
                    cmd.Parameters.AddWithValue("@Nun_Testimonio", rl.Nun_Testimonio);
                    cmd.Parameters.AddWithValue("@Domicilio", rl.Domicilio);
                    cmd.Parameters.AddWithValue("@Fecha", rl.Fecha);
                    cmd.Parameters.AddWithValue("@Num_Notaria", rl.Num_Notaria);
                    cmd.Parameters.AddWithValue("@Distrito_Judicial", rl.Distrito_Judicial);
                    cmd.Parameters.AddWithValue("@Abg_A_Cargo", rl.Abg_A_Cargo);
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
        #region REGISTRAR LOS DOCUMENTOS SOLICITADOS POR CAMPAÑA
        public void DA_Registrar_DOC_PRESENTADO(int Id_InsOrg, int Id_Campanhia, string Region)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_DOC_PRESENTADO_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_InscripcionOrg", Id_InsOrg);
                    cmd.Parameters.AddWithValue("@Id_Campanhia", Id_Campanhia);
                    cmd.Parameters.AddWithValue("@Region", Region);
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
        /****************************************************/
        #region REGISTRAR LA ORGANIZACION
        public void DA_Registrar_COMU_ORG(AP_Comunidad_Org co)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_COMUNIDAD_ORGANIZACION_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Organizacion", co.Id_Organizacion);
                    cmd.Parameters.AddWithValue("@Id_Comunidad", co.Id_Comunidad);
                    cmd.Parameters.AddWithValue("@Comunidad", co.Comunidad);
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
