using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using DataBusiness.DB_General;
using DataEntity.DE_General;


namespace WebAplication
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Index.aspx");
            //Regex regex = new Regex(@"^[0-9]+$");
            //Regex regexUser = new Regex(@"^([a-zA-Z]{2,3})[-. ]?([0-9]{6,8})$");   //@"^([0-9]{3})[-. ]?([0-9]{4})$"
            //Regex regexPass = new Regex(@"^[^ ][a-zA-Z0-9]+[^]{2,20}$");
            ////string pattern = "^([\na-zA-Z0-9\'\"´`, ()/!&#@.///:ñÑáéíóúÁÉÍÓÚç!Ç_-]+)$?";
            //DB_AdminUser ad = new DB_AdminUser();
            //DataTable dt = new DataTable();
            //dt = ad.DB_verifica(txtUser.Text);
            //string aux = dt.Rows[0][0].ToString();
            //if (dt.Rows[0][0].ToString() == txtUser.Text)
            //{
            //    if (dt.Rows[0][5].ToString()==txtPassword.Text)
            //    {
            //        if (dt.Rows[0][6].ToString() == "HABILITADO")
            //        {
            //            Session.Add("IdUser", txtUser.Text);
            //            Response.Redirect("About.aspx");
            //        }
            //        else 
            //        {
            //            lblError.Text = "ERROR NO ES UN USUARIO VALIDO O FUE DADO DE BAJA";
            //        }

            //    }
            //    else 
            //    {
            //        lblError.Text = " ERROR EN LA CONTRASEÑA";
            //    }
            //}
            //else
            //{
            //    lblError.Text = " ERROR EN EL CODIGO";
            //}
            try
            {
                DB_AdminUser ad = new DB_AdminUser();
                int Id_User = 0;
                string User_Cifrados = string.Empty;
                //**luis.rojas REALIZA CIFRADO DE CLAVES DE USUARIOS
                if (txtUser.Text == "CIFRADO")
                {
                    if (txtPassword.Text == "CIFRADO")
                    {                        
                        User_Cifrados = ad.Cifrado_Claves_Usuario(txtUser.Text.ToUpper(), txtPassword.Text);
                        if (User_Cifrados == string.Empty)
                        {
                            User_Cifrados = "Todos los Usuarios Cifrados..!!";
                        }
                        string script = @"<script type='text/javascript'>alert('{0}');</script>";
                        script = string.Format(script, "USUARIOS CIFRADOS:"+User_Cifrados);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        return;
                    }
                }
                
                //**
            
                Id_User=ad.DB_verifica(txtUser.Text,txtPassword.Text);
             
                 switch (Id_User)
                 {
                     case -1:
                         //throw new Exception("El usuario no esta Activo");                             
                         lblError.Text = "ERROR NO ES UN USUARIO VALIDO O FUE DADO DE BAJA";                        
                         break;
                     case -2:
                         //lblError.Text = " ERROR EN LA CONTRASEÑA";
                         lblError.Text = " LA CONTRASEÑA INGRESADA ES INCORRECTA";
                         break;
                     case -3:
                         //lblError.Text = " ERROR EN EL CODIGO";
                         lblError.Text = " EL USUARIO NO VALIDO";
                         break;                     
                     case 1:
                         //Id_user = 1 validacion correcta
                         Session.Add("IdUser", txtUser.Text);
                         Response.Redirect("About.aspx",true);
                         break;                     
                     default:                        
                         
                         break;
                 }
                 
             }
             catch (Exception ex)
             {
                 ////throw ex;
                 //string script = @"<script type='text/javascript'>alert('{0}');</script>";
                 //script = string.Format(script, ex.Message);
                 //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);                 
                 
                 switch (ex.Message)
                 {
                     case "Longitud no válida para una matriz o cadena de caracteres Base-64.":
                         lblError.Text = "CLAVE NO CIFRADA";
                         break;
                     default:
                         lblError.Text = ex.Message;
                         break;
                 }
             }
            
                //Regex regexPass = new Regex(pattern);
                //if (regexUser.IsMatch(txtUser.Text.Trim()) && regexPass.IsMatch(txtPassword.Text.Trim()))
                //{                    
                //        lblUser.Text = "Correcto";
                //        //Session.Add("IdUser", txtUser.Text.Trim());
                //          Response.Redirect("About.aspx");
                //        //Response.Redirect("Registro/frmCronogramaReg.aspx");
                //        //Response.Redirect("Insumos/frmRegistroProv.aspx"); 
                //        //Response.Redirect("frmRegistroOrg.aspx");    
                //        //Response.Redirect("Registro/frmListarOrg.aspx");    
                //    //lblPass.Text = "";                    
                //}
                //else
                //{
                //    Response.Redirect("About.aspx");
                //    //Response.Redirect("Registro/frmListarOrg.aspx");    
                //    //Response.Redirect("Insumos/frmRegistroProv.aspx");
                //    //Response.Redirect("Registro/frmCronogramaReg.aspx");
                //    //Response.Redirect("Registro/frmRegistroOrg.aspx");   
                //    lblError.Text = "NO ES VALIDO:" + txtPassword.Text;
                //}
             
        }       
    }
}