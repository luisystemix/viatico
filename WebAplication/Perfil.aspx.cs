using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBusiness.DB_General;
using DataEntity.DE_General;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using System.IO;

namespace WebAplication
{
    public partial class Perfil : System.Web.UI.Page
    {
        private const string hashProvider = "HashProvider";
        #region "Miembros Usuarios"        
        public Usuario VS_Usuario
        {
            get
            {
                if (ViewState["VS_Usuario"] != null)
                    return (Usuario)ViewState["VS_Usuario"];

                return new Usuario();
            }
            set { ViewState["VS_Usuario"] = value; }
        }    
        
        #endregion 
        protected void Page_Load(object sender, EventArgs e)
        {
            
            lblError.Text = string.Empty;
            txt_Contrasena.BackColor = System.Drawing.Color.Empty;
            txt_Repetir_Contrasena.BackColor = System.Drawing.Color.Empty;
            txt_Contrasena_Antigua.BackColor = System.Drawing.Color.Empty;
            if (!IsPostBack)
            {
                try
                {
                    DB_AdminUser db = new DB_AdminUser();
                    DataTable dt = new DataTable();
                    dt = db.DB_Usuario_Perfil(Session["IdUser"].ToString());                    
                    foreach (DataRow row in dt.Rows)
                    {
                        Usuario ObjUsuario = new Usuario();
                        ObjUsuario.Id_Usuario = row["Id_Usuario"].ToString();
                        ObjUsuario.Id_Regional = Convert.ToInt16(row["Id_Regional"].ToString());
                        ObjUsuario.Id_Rol = Convert.ToInt16(row["Id_Rol"].ToString());
                        ObjUsuario.Id_Categoria = Convert.ToInt16(row["Id_Categoria"].ToString());
                        ObjUsuario.Cargo = row["Cargo"].ToString();
                        ObjUsuario.Clave = row["Clave"].ToString();
                        ObjUsuario.Estado = row["Estado User"].ToString();

                        VS_Usuario = ObjUsuario;

                        txt_Id_Usuario.Text = row["Id_Usuario"].ToString();
                        txt_Id_Regional.Text = row["Regional"].ToString();
                        txt_Id_Rol.Text = row["Nombre_Rol"].ToString();
                        txt_Id_Categoria.Text = row["Nombre_Categoria"].ToString();
                        txt_Cargo.Text = row["Cargo"].ToString();                        
                        if (row["Estado User"].ToString() == "HABILITADO")
                        {
                            Chk_Estado.Checked = true;
                        }
                        else
                        {
                            Chk_Estado.Checked = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
                
            }
        }

        protected void btCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                DB_AdminUser db = new DB_AdminUser();                
                Usuario ObjUsuario = new Usuario();
                string pass_obtenido = VS_Usuario.Clave;
                
                if (Cryptographer.CompareHash(hashProvider, txt_Contrasena_Antigua.Text, pass_obtenido))
                {
                    if (txt_Contrasena.Text.Trim() != string.Empty)
                    {
                        if (txt_Contrasena.Text.Trim() == txt_Repetir_Contrasena.Text.Trim())
                        {
                            ObjUsuario = VS_Usuario;
                            ObjUsuario.Clave = txt_Contrasena.Text.Trim();
                            db.DB_Usuario_Perfil_Actualizar(ObjUsuario);
                            db.DB_Registra_Log_Password(ObjUsuario.Id_Usuario, txt_Id_Usuario.Text);//LROJAS:07/10/2016
                            Session["idUser"] = null;
                            Session.Abandon();
                            Response.Redirect("~/Default.aspx", true); 

                        }
                        else
                        {
                            lblError.Text = "Contraseñas no Coinciden";
                            txt_Contrasena.Focus();                            
                        }
                    }
                    else
                    {
                        lblError.Text = "Ingrese Contraseña";
                        txt_Contrasena.Focus();
                    }
                    
                }
                else
                {
                    lblError.Text = "Contraseña Incorrecta";
                    txt_Contrasena_Antigua.Focus();
                    //txt_Contrasena_Antigua.BackColor = System.Drawing.Color.Tomato;
                    
                }

                
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("About.aspx", true);          
        }
    }
}