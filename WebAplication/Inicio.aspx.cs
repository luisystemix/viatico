using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAplication
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Add("IdUser", "LQD-6002257");
                Response.Redirect("Default.aspx");
            }
        }
        protected void BtnAceprat_Click(object sender, EventArgs e)
        {
            //SELECT    USER_USUARIOS.Id_usuario, USER_USUARIOS.Id_Persona, USER_USUARIOS.Id_Rol, USER_USUARIOS.id_camp, USER_USUARIOS.id_regional, USER_ROLES.Rol, 
            //          USER_PERMISOS.Id_Modulo, USER_PERMISOS.Vista, USER_PERMISOS.Editar, USER_USUARIOS.Contrasenha, USER_USUARIOS.Estado
            //          FROM         USER_PERMISOS INNER JOIN
            //          USER_ROLES ON USER_PERMISOS.Id_Rol = USER_ROLES.Id_Rol INNER JOIN
            //          USER_USUARIOS ON USER_ROLES.Id_Rol = USER_USUARIOS.Id_Rol

            Session.Add("IdCamp", 1);
            Session.Add("IdReg", 2);
            Session.Add("IdPersona", "6002257");
            Session.Add("NomOrg", "");
            Session.Add("Vista", 1);
            Session.Add("Editar",1);
            Response.Redirect("WA_Organizaciones/Listado.aspx");
            //Response.Redirect("Default.aspx");
        }
    }
}