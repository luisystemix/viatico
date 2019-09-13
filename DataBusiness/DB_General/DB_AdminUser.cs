using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using DataEntity.DE_General;
using DataAccess.DA_General;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;

namespace DataBusiness.DB_General
{
    public class DB_AdminUser
    {
        private const string hashProvider = "HashProvider";
        /*********************************** FUNCIONES USUARIO ***************************************/
        #region DESPLEGAR DATOS DEL USUARIO => PERSONA => REGIONAL => ROLES
        public DataTable DB_Desplegar_USUARIO(string idUser)
        {
            DA_AdminUser User = new DA_AdminUser();
            return User.DA_Desplegar_USUARIO(idUser);
        }
        public DataTable DB_Usuario_Perfil(string idUser)
        {
            DA_AdminUser User = new DA_AdminUser();
            return User.DA_Usuario_Perfil(idUser);
        }
        public void DB_Usuario_Perfil_Actualizar(Usuario user)
        {           
                           
                DA_AdminUser User = new DA_AdminUser();
                User.DA_Cifrado_UpdUser(user);   
        }
        #endregion
        /// <summary>
        /// REALIZA CIFRADO DE CLAVES DE USUARIOS
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string Cifrado_Claves_Usuario(string usuario, string password)
        {
            try
            {
                DA_AdminUser da = new DA_AdminUser();
                string User_Cifrados = da.DA_Cifrado();                               
                return User_Cifrados;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// Ingresar Usuario y Password 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int DB_verifica(string usuario, string password) 
        {
            DA_AdminUser da = new DA_AdminUser();
            //DataTable dt = new DataTable();
            //dt = da.DA_verifica(usuario);

            //REALIZA CIFRADO DE CLAVES DE USUARIOS
            //lrojas:19-05-2016
            DataTable dt = new DataTable();
            int Id_User = 0;
            try
            {                               
                dt = da.DA_verifica(usuario);            
                //string aux = dt.Rows[0][0].ToString();
                if (dt.Rows.Count == 0)
                {
                    Id_User = -3;
                    return Id_User;
                }
                if (dt.Rows[0]["Id_Usuario"].ToString() == usuario)
                {
                    //if (dt.Rows[0][5].ToString() == password)
                    string pass_obtenido = dt.Rows[0]["Clave"].ToString();
                    if (Cryptographer.CompareHash(hashProvider, password, pass_obtenido))
                    {
                        if (dt.Rows[0]["Estado"].ToString() == "HABILITADO")
                        {                            
                            Id_User = 1;
                        }
                        else
                        {
                            Id_User = -1;
                            //lblError.Text = "ERROR NO ES UN USUARIO VALIDO O FUE DADO DE BAJA";
                        }

                    }
                    else
                    {
                        Id_User = -2;
                        //lblError.Text = " ERROR EN LA CONTRASEÑA";
                    }
                }
                else
                {
                    Id_User = -3;
                    //lblError.Text = " ERROR EN EL CODIGO";
                }
                return Id_User;
            }                
            catch (Exception ex)
            {
                throw ex;                
            }
            //
            //return Id_User;
        }

        /*********************************** FUNCIONES MODULOS ***************************************/
        #region MOSTRAR NODOS
        public void MostrarNodos(TreeNode pad, int rol)
        {
            DataSet dts = new DataSet();
            DA_AdminUser cn = new DA_AdminUser();
            cn.abrirconexion();
            int i = 0;

            dts = cn.dtsNodoListar("nodos", Convert.ToInt32(pad.Value), rol);

            string jose = Convert.ToString(dts.Tables["consulta"].Rows.Count);
            for (i = 1; i <= dts.Tables["consulta"].Rows.Count; i++)
            {
                TreeNode nodo = new TreeNode();
                nodo.Text = dts.Tables["consulta"].Rows[i - 1]["Modulos"].ToString();
                if (dts.Tables["consulta"].Rows[i - 1]["Pagina"].ToString() == "1")
                {
                    nodo.NavigateUrl = dts.Tables["consulta"].Rows[i - 1]["Url"].ToString();
                }
                nodo.Value = dts.Tables["consulta"].Rows[i - 1]["Id_Modulo"].ToString();
                pad.ChildNodes.Add(nodo);
                MostrarNodos(nodo, rol);
            }
            cn.cerrarconexion();
        }
        #endregion
        /*********************************** FUNCIONES ROLES ***************************************/
        /*********************************** FUNCIONES PERMISOS ***************************************/
        /// <summary>
        /// Registra si se realizo el cambio o reseteo de Password por Usuario
        /// </summary>
        /// <param name="Id_User">Usuario al cual se modifico el pass</param>
        /// /// <param name="Id_User_Modificacion">Usuario que realizo la modificacion</param>
        public void DB_Registra_Log_Password(string Id_User, string Id_User_Modificacion)
        {
            DA_AdminUser User = new DA_AdminUser();
            User.DA_Registro_Log_Password(Id_User,Id_User_Modificacion);          

        }
    }
}
