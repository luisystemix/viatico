using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataEntity.DE_General;
using DataBusiness.DB_General;
using DataBusiness.DB_Viaticos;
using DataEntity.DE_Viaticos;
using DataBusiness.DB_Registro;

namespace WebAplication.Administrador
{
    public partial class frmAdminUsuario : System.Web.UI.Page
    {
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
            LblMensaje.Text = string.Empty;
            if (!IsPostBack)
            {
                Desplegar_REGIONAL();
                Desplegra_USUARIOS();
            }
        }
        #region FUNCIONES PARA DESPLEGAR REGIONALES EN EL COMBO
        protected void Desplegar_REGIONAL()
        {
            DB_Regional r = new DB_Regional();
            List<Regional> listaR = r.DB_Desplegar_REGIONAL();
            DDLRegional.DataSource = listaR;
            DDLRegional.DataValueField = "Id_Regional";
            DDLRegional.DataTextField = "Nombre";
            DDLRegional.DataBind();
            DDLRegional.Items.Insert(0, new ListItem("Seleccione la Regional", "0", true));
        }
        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegra_USUARIOS();
        }
        #endregion
        #region FUNCIONES PARA DESPLEGAR REGIONALES EN EL COMBO
        protected void  Desplegra_USUARIOS()
        {
            DB_Usuario ListUser = new DB_Usuario();
            /*if (ListUser.DB_Desplegar_USUARIO(Convert.ToInt32(DDLRegional.SelectedValue), "0", "POR-REGIONAL").Rows.Count==0)
            {
            }
            else
            {
            }*/
            GVListaUser.DataSource = ListUser.DB_Desplegar_USUARIO(Convert.ToInt32(DDLRegional.SelectedValue), "0", "POR-REGIONAL");
            GVListaUser.DataBind();
        }
        #endregion

        protected void LnkNuevo_Click(object sender, EventArgs e)
        {
            if (DDLRegional.SelectedItem.Text == "Seleccione la Regional")
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, "SELECCIONE REGIONAL..!");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            else
            {
             Session.Add("IdRegional", DDLRegional.SelectedValue);
             Session.Add("Estado", "Nuevo");
             Response.Redirect("frmNuevoUsuario.aspx");
            }
        }
        #region MODIFICAR USUARIO O DAR DE BAJA AL USUARIO
        public void Inhabilitar_USUSRIO(string idusuario)
        {
            Usuario u = new Usuario();
            DataTable dt = new DataTable();
            DB_Usuario us = new DB_Usuario();
            dt = us.DB_Seleccionar_USUSRIO(idusuario);
            u.Id_Usuario = dt.Rows[0][0].ToString();
            u.Id_Regional=Convert.ToInt32(dt.Rows[0][2].ToString());
            u.Id_Rol=Convert.ToInt32(dt.Rows[0][3].ToString());
            u.Id_Categoria=Convert.ToInt32(dt.Rows[0][4].ToString());
            u.Cargo=dt.Rows[0][5].ToString();
            u.Clave=dt.Rows[0][6].ToString();
            u.Estado = "IN-HABILITADO";
            us.DB_Modificar_USUARIO(u);
            Desplegra_USUARIOS();
        }
        #endregion
        protected void GVListaUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //DataTable dt = new DataTable();
                //DB_VT_Solicitud sol = new DB_VT_Solicitud();
                string tipo = Convert.ToString(e.CommandName);
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                Session.Add("ci", GVListaUser.Rows[rowIndex].Cells[2].Text);
                Session.Add("IdRegional", DDLRegional.SelectedValue);
                string Id_Usuario = GVListaUser.Rows[rowIndex].Cells[0].Text;
                switch (tipo)
                {
                    case "Editar":
                        Session.Add("Estado", "Modificar");
                        Response.Redirect("frmNuevoUsuario.aspx");
                        break;
                    case "inhabilitar":
                        //Inhabilitar_USUSRIO(GVListaUser.Rows[rowIndex].Cells[0].Text);
                        Inhabilitar_USUSRIO(Id_Usuario);
                        break;
                    case "Resert"://lrojas:06/10/2016
                        string ci_usuario = GVListaUser.Rows[rowIndex].Cells[2].Text;
                        DB_AdminUser db = new DB_AdminUser();                        
                        DataTable dt = new DataTable();
                        dt = db.DB_Usuario_Perfil(Id_Usuario);                    
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
                        }
                        VS_Usuario.Clave = ci_usuario;
                        db.DB_Usuario_Perfil_Actualizar(VS_Usuario);

                        string Id_User_Modificacion = Session["IdUser"].ToString();
                        db.DB_Registra_Log_Password(Id_Usuario, Id_User_Modificacion);

                        string script = @"<script type='text/javascript'>alert('{0}');</script>";
                        script = string.Format(script, "Contraseña Reiniciada Usuario: "+Id_Usuario);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        break;
                } 
            }
            catch(Exception ex)
            {
                //Response.Redirect("~/About.aspx");
                //string script = @"<script type='text/javascript'>alert('{0}');</script>";
                //script = string.Format(script, ex.Message);
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                LblMensaje.Text = ex.Message;
            }

            
        }

        protected void ImgBuscar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void GVListaUser_PreRender(object sender, EventArgs e)
        {
            if (GVListaUser.Rows.Count > 0)
            {
                GVListaUser.UseAccessibleHeader = true;
                GVListaUser.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}