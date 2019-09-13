using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataEntity.DE_General;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;

namespace DataAccess.DA_General
{
    public class DA_AdminUser
    {
        private const string hashProvider = "HashProvider";
        #region CADENA DE CONEXION
        private string conexionString = ConfigurationManager.ConnectionStrings["EMAPAConnectionString"].ConnectionString;
        #endregion
        /*********************************** FUNCIONES USUARIO ***************************************/
        #region DESPLEGAR DATOS DEL USUARIO => PERSONA => REGIONAL => ROLES
        public DataTable DA_Desplegar_USUARIO(string idUser)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_USUARIO", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUser", idUser);
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
        //lrojas:20-05-2016
        public DataTable DA_Usuario_Perfil(string idUser)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    DataTable dt = new DataTable();
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("GAP_USUARIO_PERFIL", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUser", idUser);
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
        //
        #endregion

        #region CIFRAR CALVE SE USUARIOS
        public string DA_Cifrado()
        {
            string User_Cifrados = string.Empty;
            try
            {
                string queryString = "SELECT * FROM USUARIO";                
                DataTable dt = new DataTable();
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, conexion);                    
                    da.Fill(dt);
                    conexion.Close();                    
                }
                foreach (DataRow row in dt.Rows)
                {
                    long number1 = 0;
                    string clave = row["Clave"].ToString();
                    bool canConvert = long.TryParse(clave, out number1);
                    if (canConvert == true)
                    {
                        Usuario ObjUsario = new Usuario();
                        User_Cifrados += row["Id_Usuario"].ToString()+"|";                        
                        ObjUsario.Id_Usuario = row["Id_Usuario"].ToString();                        
                        ObjUsario.Id_Regional = Convert.ToInt16(row["Id_Regional"].ToString());
                        ObjUsario.Id_Rol = Convert.ToInt16(row["Id_Rol"].ToString());
                        ObjUsario.Id_Categoria = Convert.ToInt16(row["Id_Categoria"].ToString());
                        ObjUsario.Cargo = row["Cargo"].ToString();
                        ObjUsario.Clave = row["Clave"].ToString();
                        ObjUsario.Estado = row["Estado"].ToString();                                        
                        //foreach (DataColumn column in dt.Columns)
                        //{
                        //    if (row[column] != null) // This will check the null values also (if you want to check).
                        //    {
                        //           // Do whatever you want.
                        //    }
                        // }
                        DA_Cifrado_UpdUser(ObjUsario);
                    }
                }
                return User_Cifrados;
            }                
            catch(Exception ex)
            {
                throw ex;                
            }
            
            
        }
        public void DA_Cifrado_UpdUser(Usuario u)
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
                    string Encrip = string.Empty;
                    Encrip = Cryptographer.CreateHash(hashProvider, u.Clave);
                    cmd.Parameters.AddWithValue("@Clave", Encrip);
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
        public DataTable DA_verifica(string iduser)
        {
             try
            {
                string queryString = "SELECT Id_Usuario, Id_Persona, Id_Regional, Id_Rol, Cargo, Clave, Estado FROM USUARIO WHERE Id_Usuario= '" + iduser + "'";
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
        /*********************************** FUNCIONES MODULOS ***************************************/

        SqlConnection var_conexion = new SqlConnection();
        SqlCommand var_comando = new SqlCommand();
        SqlDataAdapter var_adaptador = new SqlDataAdapter();

        public void abrirconexion()
        {
            //var_conexion.ConnectionString = var_cadenaconexion;
            var_conexion.ConnectionString = conexionString;
            if (var_conexion.State == ConnectionState.Closed)
                var_conexion.Open();
        }

        public void cerrarconexion()
        {
            if (var_conexion.State == ConnectionState.Open)
                var_conexion.Close();
        }

        #region ADICIONAR MODULO
        public void AddModulos(Modulo a)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT_MODULOS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Modulo", a.Id_Modulo);
                    cmd.Parameters.AddWithValue("@Modulo", a.Modulos);
                    cmd.Parameters.AddWithValue("@Url", a.Url);
                    cmd.Parameters.AddWithValue("@NodoPadre", a.NodoPadre);
                    cmd.Parameters.AddWithValue("@Pagina", a.Pagina);
                    cmd.Parameters.AddWithValue("@Nivel", a.Nivel);
                    cmd.Parameters.AddWithValue("@F_Registro", a.F_Registro);
                    cmd.Parameters.AddWithValue("@Estado", a.Estado);
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

        #region DESPLEGAR MODULO POR NODO Y TIPO
        public DataSet dtsNodoListar(string tipo, int idnodo, int rol)
        {
            DataSet var_resultado = new DataSet();
            try
            {
                var_comando.CommandText = "GAP_GENERAR_NODOS";
                var_comando.CommandType = CommandType.StoredProcedure;
                var_comando.Connection = var_conexion;
                var_comando.Parameters.Add("@tipo", SqlDbType.VarChar, 10).Value = tipo;
                var_comando.Parameters.Add("@param1", SqlDbType.Int).Value = idnodo;
                var_comando.Parameters.Add("@ROL", SqlDbType.Int).Value = rol;
                var_adaptador.SelectCommand = var_comando;
                var_adaptador.Fill(var_resultado, "consulta");
                var_comando.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return var_resultado;
        }
        #endregion
        /*********************************** FUNCIONES ROLES ***************************************/
        /*********************************** FUNCIONES PERMISOS ***************************************/
        /// <summary>
        /// Registra si se realizo el cambio o reseteo de Password por Usuario
        /// </summary>
        /// <param name="Id_User">Usuario al cual se modifico el pass</param>
        /// /// <param name="Id_User_Modificacion">Usuario que realizo la modificacion</param>
        public void DA_Registro_Log_Password(string Id_User,string Id_User_Modificacion)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    SqlCommand cmd = new SqlCommand("LOG_PASSWORD_INSERT", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Usuario", Id_User);
                    cmd.Parameters.AddWithValue("@Id_Usuario_Modificacion", Id_User_Modificacion);                    
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
    }
}
