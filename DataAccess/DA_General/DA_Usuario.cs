using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataEntity.DE_Registro;
using DataEntity.DE_General;

namespace DataAccess.DA_General
{
    public class DA_Usuario
    {
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO POR PROCEDIMIENTO ALMACENADO
        public DataTable DA_Desplegar_USUARIO(int Id_Regional, string IdUsuario, string Parametro)
        {
            string[] ci = new string[2];
            ci = IdUsuario.Split('-');
            try
            {                
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_USUARIO_CONSULTAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Regional", Id_Regional);
                    cmd.Parameters.AddWithValue("@Id_Usuario", IdUsuario);

                    if (IdUsuario != "0" && string.Equals(Parametro,"Usuario"))
                        cmd.Parameters.AddWithValue("@Id_Persona", ci[1].ToString());
                    else
                        cmd.Parameters.AddWithValue("@Id_Persona", IdUsuario);
                    
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
        #region DESPLEGAR TODOS LOS DATOS DE LA TABLA ROL
        public DataTable DA_Desplegar_ROL(int rol)
        {
            try
            {
                string queryString = "SELECT Id_Rol, Nombre_Rol, Rol, Estado FROM ROLES WHERE Rol = "+rol+"";
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
        /// <summary>
        /// Obtiene Roles de la BD
        /// </summary>
        //lrojas:03102016
        public DataTable DA_Obtener_Roles()
        {
            try
            {
                string queryString = "SELECT Id_Rol, Nombre_Rol, Rol, Estado FROM ROLES";
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
        #region DESPLEGAR TODOS LOS DATOS DE LA TABLA CATEGORIA
        public DataTable DA_Desplegar_CATEGORIA()
        {
            try
            {
                string queryString = "SELECT Id_Categoria, Nombre_Categoria, Estado FROM VIAT_CATEGORIA";
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
        #region DESPLEGAR TODOS LOS DATOS DE LA TABLA ESTRUCTURA ORGANIZACION
        public DataTable DA_Desplegar_INMEDIATO_SUP()
        {
            try
            {
                string queryString = "SELECT Id_Estructura, Nombre, Sigla, CI_Responsable, Estado FROM VIAT_ESTRUCTURA_ORG";
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
        #region REGISTRAR LOS DATOS DE UNA PERSONA
        public void DA_Registrar_USUARIO(Usuario u)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_USUARIO_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Usuario", u.Id_Usuario);
                    cmd.Parameters.AddWithValue("@Id_Persona", u.Id_Persona);
                    cmd.Parameters.AddWithValue("@Id_Regional", u.Id_Regional);
                    cmd.Parameters.AddWithValue("@Id_Rol", u.Id_Rol);
                    cmd.Parameters.AddWithValue("@Id_Categoria", u.Id_Categoria);
                    cmd.Parameters.AddWithValue("@Cargo", u.Cargo);
                    cmd.Parameters.AddWithValue("@Clave", u.Clave);
                    cmd.Parameters.AddWithValue("@Estado", u.Estado);
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

        #region REGISTRAR LOS DATOS DE UNA PERSONA
        /// <summary>
        /// Actualiza Datos Usuario, sin Clave
        /// </summary>
        /// <param name="u"></param>
        public void DA_Modificar_USUARIO_SIN_CLAVE(Usuario u)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_USUARIO_UPDATE_SIN_CLAVE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Usuario", u.Id_Usuario);
                    cmd.Parameters.AddWithValue("@Id_Persona", u.Id_Persona); //se añade campo para poder actualizar en la tabla Usuario.
                    cmd.Parameters.AddWithValue("@Id_Regional", u.Id_Regional);
                    cmd.Parameters.AddWithValue("@Id_Rol", u.Id_Rol);
                    cmd.Parameters.AddWithValue("@Id_Categoria", u.Id_Categoria);
                    cmd.Parameters.AddWithValue("@Cargo", u.Cargo);                    
                    cmd.Parameters.AddWithValue("@Estado", u.Estado);
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
        public void DA_Modificar_USUARIO(Usuario u)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_USUARIO_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Usuario", u.Id_Usuario);
                    cmd.Parameters.AddWithValue("@Id_Regional", u.Id_Regional);
                    cmd.Parameters.AddWithValue("@Id_Rol", u.Id_Rol);
                    cmd.Parameters.AddWithValue("@Id_Categoria", u.Id_Categoria);
                    cmd.Parameters.AddWithValue("@Cargo", u.Cargo);
                    cmd.Parameters.AddWithValue("@Clave", u.Clave);
                    cmd.Parameters.AddWithValue("@Estado", u.Estado);
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
        /// Actualiza Cargo Usuario
        /// </summary>
        /// <param name="user"></param>
        public void DA_Actualizar_Cargo(Usuario user)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_USUARIO_UPDATE_CARGO", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;                    
                    cmd.Parameters.AddWithValue("@Id_Usuario", user.Id_Usuario);
                    cmd.Parameters.AddWithValue("@Cargo", user.Cargo);
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
        #region REGISTRAR LOS DATOS DE UN USUARIO Y SU ESTRUCTURA Y DEPENDENCIA
        public void DA_Registrar_USUARIO_ESTRUCTURA(int  idestructura, string idusuario, string ci)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_USUARIO_ESTRUCTURA_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Estructura", idestructura);
                    cmd.Parameters.AddWithValue("@Id_Usuario", idusuario);
                    cmd.Parameters.AddWithValue("@CI_Responsable", ci);
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
        /// Actualiza Usuario Estructura en la BD
        /// </summary>
        /// <param name="idestructura"></param>
        /// <param name="idusuario"></param>
        /// <param name="ci"></param>
        public void DA_Modificar_USUARIO_ESTRUCTURA(int idestructura, string idusuario, string ci)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("GAP_USUARIO_ESTRUCTURA_UPDATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Estructura", idestructura);
                    cmd.Parameters.AddWithValue("@Id_Usuario", idusuario);
                    cmd.Parameters.AddWithValue("@CI_Responsable", ci);
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
        /// Obtiene Estructura de Usuario por IdUsuario
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        //lrojas:03102016
        public DataTable DA_Obtener_UsuarioEstructura(string IdUsuario)
        {
            try
            {
                string queryString = "SELECT Id_Estructura, Id_Usuario, CI_Responsable FROM VIAT_USUARIO_ESTRUCTURA WHERE Id_Usuario = '" + IdUsuario + "'";                
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
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO PARA LA EL SISTEMA VIATICOS
        public DataTable DA_Seleccionar_ESTRUCTURA_ORG(int IdEstruct)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("VT_ESTRUCTURA_ORG_SELECT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Estructura", IdEstruct);
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
        #region SELECCIONAR AL USUARIO POR EL CODIGO DE USIARIO
        public DataTable DA_Seleccionar_USUSRIO(string idusuario)
        {
            try
            {
                string queryString = "SELECT Id_Usuario, Id_Persona, Id_Regional, Id_Rol, Id_Categoria, Cargo, Clave, Estado FROM USUARIO WHERE  Id_Usuario = '" + idusuario + "'";
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
