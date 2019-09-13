using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DA_General;
using DataEntity.DE_General;
using DataEntity.DE_Viaticos;

namespace DataBusiness.DB_General
{
    public class DB_Usuario
    {
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        public DataTable DB_Desplegar_USUARIO(int IdRegional, string IdUsuario, string Parametro)
        {
            DA_Usuario data = new DA_Usuario();
            return data.DA_Desplegar_USUARIO(IdRegional, IdUsuario, Parametro);
        }
        #endregion
        #region DESPLEGAR TODOS LOS DATOS DE LA TABLA ROL
        public List<Roles> DB_Desplegar_ROL(int rol)
        {
            DA_Usuario data = new DA_Usuario();
            DataTable dt = new DataTable();
            dt = data.DA_Desplegar_ROL(rol);
            List<Roles> listReg = new List<Roles>();
            foreach (DataRow fila in dt.Rows)
            {
                Roles r = new Roles();
                r.Id_Rol = Convert.ToInt32(fila[0]);
                r.Nombre_Rol = Convert.ToString(fila[1]);
                r.Rol = Convert.ToString(fila[2]);
                r.Estado = Convert.ToString(fila[3]);
                listReg.Add(r);
            }
            return listReg;
        }
        /// <summary>
        /// Obtiene Roles del Sistema
        /// </summary> 
        //lrojas:03102016
        public List<Roles> DB_Obtener_Roles()
        {
            DA_Usuario data = new DA_Usuario();
            DataTable dt = new DataTable();
            dt = data.DA_Obtener_Roles();
            List<Roles> listReg = new List<Roles>();
            foreach (DataRow fila in dt.Rows)
            {
                Roles r = new Roles();
                r.Id_Rol = Convert.ToInt32(fila[0]);
                r.Nombre_Rol = Convert.ToString(fila[1]);
                r.Rol = Convert.ToString(fila[2]);
                r.Estado = Convert.ToString(fila[3]);
                listReg.Add(r);
            }
            return listReg;
        }
        #endregion
        #region DESPLEGAR TODOS LOS DATOS DE LA TABLA CATEGORIA
        public List<VT_Categoria> DB_Desplegar_CATEGORIA()
        {
            DA_Usuario data = new DA_Usuario();
            DataTable dt = new DataTable();
            dt = data.DA_Desplegar_CATEGORIA();
            List<VT_Categoria> listCat = new List<VT_Categoria>();
            foreach (DataRow fila in dt.Rows)
            {
                VT_Categoria c = new VT_Categoria();
                c.Id_Categoria = Convert.ToInt32(fila[0]);
                c.Nombre_Categoria = Convert.ToString(fila[1]);
                c.Estado = Convert.ToString(fila[2]);;
                listCat.Add(c);
            }
            return listCat;
        }
        #endregion
        #region DESPLEGAR TODOS LOS DATOS DE LA TABLA ESTRUCTURA ORGANIZACION
        public List<VT_EstructuraOrg> DB_Desplegar_INMEDIATO_SUP()
        {
            DA_Usuario data = new DA_Usuario();
            DataTable dt = new DataTable();
            dt = data.DA_Desplegar_INMEDIATO_SUP();
            List<VT_EstructuraOrg> listReg = new List<VT_EstructuraOrg>();
            foreach (DataRow fila in dt.Rows)
            {
                VT_EstructuraOrg r = new VT_EstructuraOrg();
                r.Id_Estructura = Convert.ToInt32(fila[0]);
                r.Nombre = Convert.ToString(fila[1]);
                r.Sigla = Convert.ToString(fila[2]);
                r.CI_Responsable = Convert.ToString(fila[3]);
                r.Estado = Convert.ToString(fila[4]);
                listReg.Add(r);
            }
            return listReg;
        }
        #endregion
        #region REGISTRAR LOS DATOS DE UN USUARIO
        public void DB_Registrar_USUARIO(Usuario u)
        {
            DA_Usuario Ins = new DA_Usuario();
            Ins.DA_Registrar_USUARIO(u);
        }
        /// <summary>
        /// Actualiza Cargo Usuario
        /// </summary>
        /// <param name="user"></param>
        public void DB_Actualiza_Cargo(Usuario user)
        {
            DA_Usuario Ins = new DA_Usuario();
            Ins.DA_Actualizar_Cargo(user);
        }
        #endregion

        #region MODIFICAR LOS DATOS DE UN USUARIO
        public void DB_Modificar_USUARIO(Usuario u)
        {
            DA_Usuario Ins = new DA_Usuario();
            Ins.DA_Modificar_USUARIO(u);
        }
        /// <summary>
        /// Actualiza Datos Usuario, sin Clave
        /// </summary>
        /// <param name="u"></param>
        public void DB_Modificar_USUARIO_SIN_CLAVE(Usuario u)
        {
            DA_Usuario Ins = new DA_Usuario();
            Ins.DA_Modificar_USUARIO_SIN_CLAVE(u);
        }
        #endregion
        #region REGISTRAR LOS DATOS DE UN USUARIO Y SU ESTRUCTURA Y DEPENDENCIA
        public void DB_Registrar_USUARIO_ESTRUCTURA(int idestructura, string idusuario, string ci)
        {
            DA_Usuario Ins = new DA_Usuario();
            Ins.DA_Registrar_USUARIO_ESTRUCTURA(idestructura,idusuario,ci);
        }
        /// <summary>
        /// Actualiza Usuario Estructura 
        /// </summary>
        /// <param name="idestructura"></param>
        /// <param name="idusuario"></param>
        /// <param name="ci"></param>
        public void DB_Modificar_USUARIO_ESTRUCTURA(int idestructura, string idusuario, string ci)
        {
            DA_Usuario Ins = new DA_Usuario();
            Ins.DA_Modificar_USUARIO_ESTRUCTURA(idestructura, idusuario, ci);
        }

       /// <summary>
        /// Obtiene Estructura de Usuario
       /// </summary>
       /// <param name="IdUsuario"></param>
       /// <returns></returns>
       //lrojas:03102016
        public DataTable DB_Obtener_UsuarioEstructura(string IdUsuario)
        {
            DA_Usuario data = new DA_Usuario();
            DataTable dt = new DataTable();
            dt = data.DA_Obtener_UsuarioEstructura(IdUsuario);            
            return dt;
        }
        #endregion
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        public DataTable DB_Seleccionar_ESTRUCTURA_ORG(int IdEstruct)
        {
            DA_Usuario data = new DA_Usuario();
            return data.DA_Seleccionar_ESTRUCTURA_ORG(IdEstruct);
        }
        #endregion
        #region SELECCIONAR AL USUARIO POR EL CODIGO DE USIARIO
        public DataTable DB_Seleccionar_USUSRIO(string idusuario)
        {
            DA_Usuario data = new DA_Usuario();
            return data.DA_Seleccionar_USUSRIO(idusuario);
        }
        #endregion
    }
}
