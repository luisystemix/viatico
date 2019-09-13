using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataEntity.DE_General;
using DataBusiness.DB_General;

namespace WebAplication
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idUser"] != null)
                {
                    DB_AdminUser User = new DB_AdminUser();
                    DataTable dt = User.DB_Desplegar_USUARIO(Session["IdUser"].ToString());
                    LblUser.Text = dt.Rows[0][1].ToString();
                    LblCargo.Text = dt.Rows[0][3].ToString();
                    LblRegional.Text = dt.Rows[0][5].ToString();
                    int rol = Convert.ToInt16(dt.Rows[0][6]);
                    Tipo_SITEMA(Convert.ToInt16(dt.Rows[0][7])); 
                    TreeNode nodo = new TreeNode();
                    TreeVMenu.Nodes.Clear();
                    nodo.Value = "0";
                    nodo.Text = " .: MENU :. ";
                    TreeVMenu.Nodes.Add(nodo);
                    User.MostrarNodos(nodo, rol);
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }                
        }
        #region FUNCION PARA MOSTRAR EL TIPO DE SISTEMA QUE EL USUARIOA ACCEDE 
        protected void Tipo_SITEMA(int rol) 
        {
            switch(rol)
            {
                case 1:
                    LblTipoSis.Text = "ADMINISTRADOR";
                    break;
                case 2:
                    LblTipoSis.Text = "PRODUCCIÓN";
                    break;
                case 3:
                    LblTipoSis.Text = "VIATICOS";
                    break;
            }
        }
        #endregion
        protected void lbCerrar_Click(object sender, EventArgs e)
        {
            //Para Cerrar la Session
            Session["idUser"] = null;
            Session.Abandon();
            Response.Redirect("~/Default.aspx", true);            
        }

        protected void TreeVMenu_SelectedNodeChanged(object sender, EventArgs e)
        {   
        }

        protected void lbPerfil_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Perfil.aspx", true);                 
            //string s = "window.open('Perfil.aspx', 'popup_window', 'width=700,height=450,left=200,top=150,resizable=yes');";            
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", s, true);
        }
    }
}
