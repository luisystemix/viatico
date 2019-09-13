using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_General;
using DataEntity.DE_Registro;
using DataBusiness.DB_Registro;
using DataBusiness.DB_Viaticos;
using DataEntity.DE_General;
using DataEntity.DE_Viaticos;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;

namespace WebAplication.Administrador
{
    public partial class frmNuevoUsuario : System.Web.UI.Page
    {
        private const string hashProvider = "HashProvider";
        private string Cargo_Usuario
        {
            get
            {
                if (ViewState["Cargo_Usuario"] != null)
                    return (string)ViewState["Cargo_Usuario"];

                return string.Empty;
            }
            set { ViewState["Cargo_Usuario"] = value; }
        }
        /// <summary>
        /// Variable Auxiliar que almacena Id_Usuario obtenido de la BD
        /// </summary>
        private string Id_Usuario_Aux
        {
            get
            {
                if (ViewState["Id_Usuario_Aux"] != null)
                    return (string)ViewState["Id_Usuario_Aux"];

                return string.Empty;
            }
            set { ViewState["Id_Usuario_Aux"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
         {
            try 
            { 
                if (!IsPostBack)
                {
                    LblEstado.Text=Session["Estado"].ToString();
                    LblIdRegional.Text = Session["IdRegional"].ToString();
                    Desplegar_CATEGORIAS();
                    Desplegar_INMEDIATO_SUP();
                    Desplegar_ROLES();
                    if(LblEstado.Text=="Modificar")
                    {
                        //**luis.rojas
                        Enabled_Actualizar(false);
                        //**
                        TxtCedula.Text = Session["ci"].ToString();
                        Buscar_PERSONA(TxtCedula.Text);
                        this.lbltitulo.Text = "MODIFICACION DE DATOS DEL USUARIO";
                    }
                    else
                    {
                        TxtCedula.Text = string.Empty;
                        DB_Regional reg = new DB_Regional();
                        DataTable dt = new DataTable();
                        dt = reg.DB_Seleccionar_REGIONAL(Convert.ToInt32(LblIdRegional.Text));
                        LblRegional.Text = dt.Rows[0][1].ToString();
                        this.lbltitulo.Text = "REGISTRO DE NUEVO USUARIO";
                        //Desplegar_CATEGORIAS();
                        //Desplegar_INMEDIATO_SUP();
                        //Desplegar_ROLES();
                    }
                }
            }
            catch(Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                //Response.Redirect("~/About.aspx");
            }
            //this.BtnRegistrar.Attributes.Add("onClick", "if(!confirm('Esta seguro de resetar su clave?')){return false;};");
        }

        protected void TxtCedula_TextChanged(object sender, EventArgs e)
        {   
            Buscar_PERSONA(TxtCedula.Text);
            if (string.Equals(this.LblEstado.Text, "Nuevo") && 
                !string.IsNullOrEmpty(this.TxtNombre.Text) && 
                !string.IsNullOrEmpty(this.TxtCedula.Text))
            {
                this.AdministraControles(false);
                string codus = @"<script type='text/javascript'>alert('{0}');</script>";
                codus = string.Format(codus, "☻ EL USUARIO YA ESTA REGISTRADO SU CODIGO ES: ► " + this.LblIdUsuario.Text + " .INGRESE OTRO C.I.(Opción Administrador Spia/Administrar Usuario)");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", codus, false);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.location ='frmAdminUsuario.aspx';", true);
            }
            //else
            //    this.AdministraControles(false);
        }
        #region BUSCAR PERSONA Y USUARIO
        private void Buscar_PERSONA(string ci)
        {
            Persona p = new Persona();
            DB_Persona np = new DB_Persona();
            p = np.DB_Buscar_PERSONA(ci);
            string idus = "";
            string aux="";
            if (p.ci == ci)
            {
                TxtCedula.Text = p.ci;
                //DDLExt.Items.Insert(0, new ListItem(p.ext, p.ext, true)); //lrojas:03102016
                DDLExt.SelectedValue = p.ext;
                //DDLExt.DataBind();
                TxtNombre.Text = p.Nombres;
                TxtApPat.Text = p.Primer_ap;
                TxtApMat.Text = p.Segundo_ap;
                TxtFechNac.Text = p.Fecha_nacimiento.ToShortDateString();
                TxtFonoFijo.Text = p.Telef_fijo;
                TxtFonoMovil.Text = p.Telef_cel;
                if (p.Sexo == true)
                {
                    //aux = "MUJER";
                    aux = "1";
                }
                else
                {                    
                    //aux = "VARON";
                    aux = "0";
                }
                //DDLSexo.Items.Insert(0, new ListItem(aux, p.Sexo.ToString(), true)); //lrojas:03102016                
                DDLSexo.SelectedValue = aux;
                //DDLSexo.DataBind();
                if (TxtApMat.Text!="")
                {
                    idus = TxtApPat.Text[0].ToString() + TxtApMat.Text[0].ToString() + TxtNombre.Text[0].ToString() + "-" + TxtCedula.Text;
                }
                else
                {
                    idus = TxtApPat.Text[0].ToString() + TxtNombre.Text[0].ToString() + "-" + TxtCedula.Text;
                }
                Id_Usuario_Aux = idus;
                Buscar_USUARIO(idus);                
            }
            else
            {
                //limparCampos_PERSONA();
                this.LimpiarControles();
            }
        }
        private void Buscar_USUARIO(string idUsiario) 
        {
            DataTable us = new DataTable();
            DB_Usuario nus = new DB_Usuario();
            us = nus.DB_Desplegar_USUARIO(Convert.ToInt32(LblIdRegional.Text), idUsiario, "USUARIO");
            if (us.Rows.Count != 0)
            {
                //if (us.Rows[0][0].ToString() == idUsiario)
                if (!string.IsNullOrEmpty(us.Rows[0][0].ToString()))
                { 
                    //LblIdUsuario.Text = idUsiario;
                    LblIdUsuario.Text = us.Rows[0][0].ToString();
                    TxtCargo.Text = us.Rows[0][5].ToString();
                    Cargo_Usuario = us.Rows[0][5].ToString();//luis.rojas 24-05-2016
                    //*ini* lrojas: 03102016
                    //DDLRol.Items.Insert(0, new ListItem(us.Rows[0][8].ToString(), us.Rows[0][3].ToString(), true));
                    //DDLRol.DataBind();
                    //DDLCategoria.Items.Insert(0, new ListItem(us.Rows[0][9].ToString(), us.Rows[0][4].ToString(), true));
                    //DDLCategoria.DataBind();
                    //DDLEstado.Items.Insert(0, new ListItem(us.Rows[0][7].ToString(), us.Rows[0][7].ToString(), true));
                    //DDLEstado.DataBind();
                    DB_Usuario r = new DB_Usuario();
                    List<Roles> listaR = r.DB_Obtener_Roles();
                    string Sis_Seleccionado = listaR.Where(s => s.Id_Rol == Convert.ToInt32(us.Rows[0][3].ToString())).FirstOrDefault().Rol;
                    DDLSistema.SelectedValue = Sis_Seleccionado;
                    Desplegar_ROLES();
                    DDLRol.SelectedValue = us.Rows[0][3].ToString();
                    DDLCategoria.SelectedValue = us.Rows[0][4].ToString();
                    DDLEstado.SelectedValue = us.Rows[0][7].ToString();
                    DataTable DT_UsEst = new DataTable();
                    DT_UsEst = r.DB_Obtener_UsuarioEstructura(idUsiario);
                    DDLSup.SelectedValue = DT_UsEst.Rows[0][0].ToString();
                    EventArgs e = new EventArgs();
                    object sender = new object();
                    DDLSup_SelectedIndexChanged(sender, e);
                    //*fin*
                    Buscar_CUENTAUSUARIO(idUsiario);
                }
                else
                {
                    limparCampos_PERSONA();
                }
            }
            else 
            {
                LblIdUsuario.Text = string.Empty;
                TxtCargo.Text = string.Empty;
                //DDLRol.Items.Insert(0, new ListItem(us.Rows[0][8].ToString(), us.Rows[0][3].ToString(), true));
                DDLRol.DataBind();
                //DDLCategoria.Items.Insert(0, new ListItem(us.Rows[0][9].ToString(), us.Rows[0][4].ToString(), true));
                DDLCategoria.DataBind();
            }
        }
        private void Buscar_CUENTAUSUARIO(string iduser)
        {
            DB_VT_Viaticos cu = new DB_VT_Viaticos();
            DataTable dt = new DataTable();
            dt = cu.DB_Seleccionar_CUENTA_USUARIO(iduser);
            if(dt.Rows.Count>0)
            {
                TxtNumCuenta.Text = dt.Rows[0][0].ToString();
                TxtBanco.Text = dt.Rows[0][1].ToString();
            }
        }
        private void limparCampos_PERSONA()
        {
            TxtNombre.Text = string.Empty;
            TxtApPat.Text = string.Empty;
            TxtApMat.Text = string.Empty;
            TxtCargo.Text = string.Empty;
            LblIdUsuario.Text = "";
        }
        #endregion
        #region FUNCIONES PARA DESPLEGAR REGIONALES EN EL COMBO
        protected void Desplegar_ROLES()
        {
            DB_Usuario r = new DB_Usuario();
            List<Roles> listaR = r.DB_Desplegar_ROL(Convert.ToInt32(DDLSistema.SelectedValue));
            DDLRol.DataSource = listaR;
            DDLRol.DataValueField = "Id_Rol";
            DDLRol.DataTextField = "Nombre_Rol";
            DDLRol.DataBind();
            //DDLRol.Items.Insert(0, new ListItem("Seleccione la Regional", "0", true));
        }
        protected void Desplegar_CATEGORIAS()
        {
            DB_Usuario r = new DB_Usuario();
            List<VT_Categoria> listaR = r.DB_Desplegar_CATEGORIA();
            DDLCategoria.DataSource = listaR;
            DDLCategoria.DataValueField = "Id_Categoria";
            DDLCategoria.DataTextField = "Nombre_Categoria";
            DDLCategoria.DataBind();
            //DDLCategoria.Items.Insert(0, new ListItem("Seleccione la Regional", "0", true));
        }
        protected void Desplegar_INMEDIATO_SUP()
        {
            DB_Usuario r = new DB_Usuario();
            List<VT_EstructuraOrg> listaR = r.DB_Desplegar_INMEDIATO_SUP();
            DDLSup.DataSource = listaR;
            DDLSup.DataValueField = "Id_Estructura";
            DDLSup.DataTextField = "Nombre";
            DDLSup.DataBind();
            DDLSup.Items.Insert(0, new ListItem("Seleccione su Dependencia", "0", true));
        }
        #endregion

        protected void DDLSup_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB_Usuario r = new DB_Usuario();
            DataTable dt = new DataTable();
            dt = r.DB_Seleccionar_ESTRUCTURA_ORG(Convert.ToInt32(DDLSup.SelectedValue));
            if (dt.Rows.Count == 0)//lrojas: 28/10/2016 validacion inmediato sup
                throw new Exception("No cuenta con Inmediato Superior, Seleccione su Dependencia");
            TxtCiResp.Text = dt.Rows[0][3].ToString();
            //**luis.rojas
            if (TxtCiResp.Text != string.Empty)
            {
                DB_Persona np = new DB_Persona();
                Persona presp = new Persona();                
                presp = np.DB_Buscar_PERSONA(TxtCiResp.Text);
                lblNom_Resp.Text = presp.Nombres + " " + presp.Primer_ap + " " + presp.Segundo_ap;                                
            }
            //**
        }
        #region FUNCIONES PARA VALIDAR DIGITACION DE LOS CAMPOS
        public Boolean validacion() 
        { 
           if(!string.IsNullOrEmpty(TxtCedula.Text) && !string.IsNullOrEmpty(TxtNombre.Text)
                && !string.IsNullOrEmpty(TxtApPat.Text) && !string.IsNullOrEmpty(TxtCargo.Text)
                )
           {
               return true;
           }
           else
           {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, "*** NOTA: LOS DATOS DEL USUARIO MINIMAMENTE REQUERIDOS SON : CEDULA IDENTIDAD, NOMBRE(S),APELLIDO PATERNO Y CARGO  !!!");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
           }

        }
        #endregion
        #region REGISTRAR AL NUEVO USUARIO
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {            
                if (validacion())
                {
                    if (string.IsNullOrEmpty(LblIdUsuario.Text))
                    {
                        Registrar_PERSONA();
                        Registrar_USUARIO();
                        Registrar_USUARIO_ESTRUCTURA();
                        Registrar_CUENTA();
                        string script = @"<script type='text/javascript'>alert('{0}');</script>";

                        script = string.Format(script, "☻ GENERADO CORRECTAMENTE EL CODIGO DE USUARIO ► " + this.LblIdUsuario.Text + " CORRESPONDIENTE A " + this.TxtApPat.Text + " " + this.TxtApMat.Text + " "+ this.TxtNombre.Text +" CON CI: " + this.TxtCedula.Text);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        ScriptManager.RegisterStartupScript(this, this.GetType(),"alert", "window.location ='frmAdminUsuario.aspx';", true);
                    }
                    else
                    {
                        string Id_Us = string.Empty;
                        if (TxtApMat.Text != "")
                        {
                            //Id_Us = TxtApPat.Text[0].ToString() + TxtApMat.Text[0].ToString() + TxtNombre.Text[0].ToString() + "-" + TxtCedula.Text;
                            Id_Us = this.GeneraCodigo();
                        }
                        else
                        {
                            Id_Us = this.GeneraCodigo();
                        }

                        //if (Id_Us != Id_Usuario_Aux)//validacion Codigo de Usuario
                        if (string.Equals(this.LblEstado.Text, "Modificar"))//validacion Codigo de Usuario
                            
                        {
                            
                            string codus = @"<script type='text/javascript'>alert('{0}');</script>";
                            //codus = string.Format(codus, "- Se realizó la modificación" + Id_Usuario_Aux + " su Codigo_Actual:" + Id_Us + " Verifique Nombre y Apellidos.");
                            codus = string.Format(codus, "☻ MODIFICACION CORRECTA PARA EL USUARIO CON C.I.: " + this.TxtCedula.Text + " CON CODIGO DE USUARIO ► " + this.LblIdUsuario.Text);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", codus, false);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.location ='frmAdminUsuario.aspx';", true);
                            //return;
                        }
                        //** VALIDAR LAS FUNCIONES - PERSONA - USUARIO     
                        Modificar_PERSONA();
                        Modificar_USUARIO();
                        DB_Usuario con = new DB_Usuario();
                        con.DB_Modificar_USUARIO_ESTRUCTURA(Convert.ToInt32(DDLSup.SelectedValue), Id_Us, TxtCiResp.Text);
                        if(RBTNSI.Checked == true)
                        {
                            DB_VT_Viaticos cu = new DB_VT_Viaticos();
                            DataTable dt = new DataTable();
                            VT_Cuenta c = new VT_Cuenta();
                            DB_VT_Viaticos rc = new DB_VT_Viaticos();
                            dt = cu.DB_Seleccionar_CUENTA_USUARIO(Id_Us);
                            if (dt.Rows.Count == 0)
                            {
                                c.Id_Usuario = Id_Us;
                                c.Cuenta = TxtNumCuenta.Text;
                                c.Banco = TxtBanco.Text;
                                c.Estado = "ACTIVO";                                
                                rc.DB_Registrar_CUENTA(c);
                            }
                            else
                            {
                                c.Id_Usuario = Id_Us;
                                c.Cuenta = TxtNumCuenta.Text;
                                c.Banco = TxtBanco.Text;
                                //c.Estado = "ACTIVO";                                
                                rc.DB_Modificar_CUENTA(c);    
                            }                                           
                        }                        
                        //
                        Buscar_PERSONA(TxtCedula.Text);
                        RBTNNO.Checked = true;
                        //object send = new object();
                        //EventArgs ea = new EventArgs();
                        //RBTNNO_CheckedChanged(send, ea);
                        TxtNumCuenta.Enabled = false;
                        TxtBanco.Enabled = false;                        
                    }
                }                
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }           
        }

        protected void AdministraControles(bool valorHabilitaDeshabilita)
        {
            this.TxtCedula.Enabled = valorHabilitaDeshabilita;
            this.TxtCedula.Enabled = valorHabilitaDeshabilita;
            this.TxtNombre.Enabled = valorHabilitaDeshabilita;
            this.TxtApPat.Enabled = valorHabilitaDeshabilita;
            this.TxtApMat.Enabled = valorHabilitaDeshabilita;
            this.TxtCargo.Enabled = valorHabilitaDeshabilita;
            this.TxtFonoFijo.Enabled = valorHabilitaDeshabilita;
            this.TxtFonoMovil.Enabled = valorHabilitaDeshabilita;
            this.TxtFechNac.Enabled = valorHabilitaDeshabilita;
            this.DDLSistema.Enabled = valorHabilitaDeshabilita;
            this.DDLRol.Enabled = valorHabilitaDeshabilita;
            this.DDLCategoria.Enabled = valorHabilitaDeshabilita;
            this.TxtCiResp.Enabled = valorHabilitaDeshabilita;
            this.DDLEstado.Enabled = valorHabilitaDeshabilita;
            this.TxtBanco.Enabled = valorHabilitaDeshabilita;
            this.TxtNumCuenta.Enabled = valorHabilitaDeshabilita;
            this.RBTNNO.Enabled = valorHabilitaDeshabilita;
            this.RBTNSI.Enabled = valorHabilitaDeshabilita;
            this.BtnRegistrar.Enabled = valorHabilitaDeshabilita;
            this.BtnCancelar.Enabled = valorHabilitaDeshabilita;
            this.DDLSexo.Enabled = valorHabilitaDeshabilita;
            this.DDLSup.Enabled = valorHabilitaDeshabilita;
            this.DDLExt.Enabled = valorHabilitaDeshabilita;
        }

        protected void LimpiarControles()
        {
            #region
            /*
            this.TxtCedula.Enabled =false;
            this.TxtNombre.Enabled = false;
            this.TxtApPat.Enabled = false;
            this.TxtApMat.Enabled = false;
            this.TxtCargo.Enabled = false;
            this.TxtFonoFijo.Enabled = false;
            this.TxtFonoMovil.Enabled = false;
            this.TxtFechNac.Enabled = false;
            this.DDLSistema.Enabled = false;
            this.DDLRol.Enabled = false;
            this.DDLCategoria.Enabled = false;
            this.TxtCiResp.Enabled = false;
            this.DDLEstado.Enabled = false;
            this.TxtBanco.Enabled = false;
            this.TxtNumCuenta.Enabled = false;
            this.RBTNNO.Enabled = false;
            this.RBTNSI.Enabled = false;
            this.BtnRegistrar.Enabled = false;
            this.BtnCancelar.Enabled = false;*/
            
            //this.TxtCedula.Text = string.Empty;
            this.TxtNombre.Text = string.Empty;
            this.TxtApPat.Text = string.Empty;
            this.TxtApMat.Text = string.Empty;
            this.TxtCargo.Text = string.Empty;
            this.TxtFonoFijo.Text = string.Empty;
            this.TxtFonoMovil.Text = string.Empty;
            this.TxtFechNac.Text = string.Empty;
            this.DDLSistema.SelectedItem.Value = "1";
            this.DDLRol.SelectedItem.Value = "2";
            this.DDLCategoria.SelectedItem.Value = "1";
            this.TxtCiResp.Text = string.Empty;
            this.DDLEstado.SelectedItem.Value = "HABILITADO";
            this.TxtBanco.Text = "No Definido";
            this.TxtNumCuenta.Text = "1000000-?";
            this.RBTNNO.Checked = true;
            this.RBTNSI.Checked = false;
            this.LblIdUsuario.Text = string.Empty;
            this.lblNom_Resp.Text = string.Empty;
            #endregion

        }
        #endregion
        #region FUNCION PARA MODIFICAR LOS DATOS DE PERSONA
        protected void Modificar_PERSONA()
        {
            try
            {
                DB_Persona Reg = new DB_Persona();
                Persona per = new Persona();
                per.Id_Persona = TxtCedula.Text;
                per.ci = TxtCedula.Text;
                per.ext = DDLExt.SelectedItem.Text;
                per.Nombres = TxtNombre.Text;
                per.Primer_ap = TxtApPat.Text;
                per.Segundo_ap = TxtApMat.Text;
                //**luis.rojas
                per.Fecha_nacimiento = Convert.ToDateTime(TxtFechNac.Text);
                if (DDLSexo.SelectedValue == "1")
                {
                    per.Sexo = true;//MUJER
                }
                else
                {
                    per.Sexo = false;//VARON
                }
                per.Telef_fijo = TxtFonoFijo.Text.Trim();
                per.Telef_cel = TxtFonoMovil.Text.Trim();
                //**
                per.Fecha_registro = DateTime.Now;
                per.Estado = "Activo";
                Reg.DB_Modificar_PERSONA(per);                
            }
            catch(Exception ex)
            {
                //string script = @"<script type='text/javascript'>alert('{0}');</script>";
                //script = string.Format(script, ex.Message);
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                throw new Exception(ex.Message);
            }
            
        }
        #endregion
        #region FUNCION PARA REGISTRAR PERSONA
        protected void Registrar_PERSONA()
        {
            DB_Persona Reg = new DB_Persona();
            Persona per = new Persona();
            per.Id_Persona = TxtCedula.Text;
            per.ci = TxtCedula.Text;
            per.ext = DDLExt.SelectedItem.Text;
            per.Nombres = TxtNombre.Text;
            per.Primer_ap = TxtApPat.Text;
            per.Segundo_ap = TxtApMat.Text;
            if (TxtFechNac.Text == string.Empty)
            {
                per.Fecha_nacimiento = Convert.ToDateTime("01/01/1990");
            }
            else
            {
                per.Fecha_nacimiento = Convert.ToDateTime(TxtFechNac.Text.ToString());
            }
            
            if (DDLSexo.SelectedValue == "1")
            {
                per.Sexo = true;//MUJER
            }
            else
            {
                per.Sexo = false;//VARON
            }
            //per.Sexo = true;
            if (TxtFonoFijo.Text == string.Empty)
            { 
                per.Telef_fijo = string.Empty;
            }
            else
            {
                per.Telef_fijo = TxtFonoFijo.Text; 
            }
            if (TxtFonoMovil.Text == string.Empty)
            {
                per.Telef_cel = string.Empty; 
            }
            else
            {
                per.Telef_cel = TxtFonoMovil.Text; 
            }            
            per.Fecha_registro = DateTime.Now;
            per.Estado = "Activo";
            Reg.DB_Registrar_PERSONA(per);
        }
        #region FUNCION DE REGISTRO Y MODIFICACION DE USUARIO
        protected void Registrar_USUARIO()
        {
            DB_Usuario Reg = new DB_Usuario();
            Usuario us = new Usuario();
            var vApellidoPaterno = string.Empty;
            us.Id_Usuario = this.GeneraCodigo();
            //LblIdUsuario.Text = TxtApPat.Text[0].ToString() + TxtApMat.Text[0].ToString() + TxtNombre.Text[0].ToString() + "-" + TxtCedula.Text;
            LblIdUsuario.Text = us.Id_Usuario;
            us.Id_Persona = TxtCedula.Text;
            us.Id_Regional = Convert.ToInt32(LblIdRegional.Text);
            us.Id_Rol = Convert.ToInt32(DDLRol.SelectedValue);
            us.Id_Categoria = Convert.ToInt32(DDLCategoria.SelectedValue);
            us.Cargo = TxtCargo.Text;
            //**luis.rojas 23-05-2016
            string Encrip = string.Empty;
            Encrip = Cryptographer.CreateHash(hashProvider, TxtCedula.Text.Trim());
            //**
            us.Clave = Encrip;
            us.Estado = DDLEstado.Text;
            Reg.DB_Registrar_USUARIO(us);
        }
        protected void Modificar_USUARIO()
        {
            try
            {

                DB_Usuario Reg = new DB_Usuario();
                Usuario us = new Usuario();
                us.Id_Usuario = this.GeneraCodigo();
                LblIdUsuario.Text = us.Id_Usuario;
                us.Id_Persona = TxtCedula.Text;
                us.Id_Regional = Convert.ToInt32(LblIdRegional.Text);
                us.Id_Rol = Convert.ToInt32(DDLRol.SelectedValue);
                us.Id_Categoria = Convert.ToInt32(DDLCategoria.SelectedValue);
                us.Cargo = TxtCargo.Text;
                us.Clave = TxtCedula.Text;
                us.Estado = DDLEstado.Text;
                ////Reg.DB_Registrar_USUARIO(us);
                ////**luis.rojas actualiza solo cargo de usuario
                //if (Cargo_Usuario != us.Cargo)
                //    Reg.DB_Actualiza_Cargo(us);
                ////**
                //Reg.DB_Modificar_USUARIO(us); //lrojas: 04/10/2016
                Reg.DB_Modificar_USUARIO_SIN_CLAVE(us); //lrojas: 06/10/2016
            }
            catch(Exception ex)
            {
                //string script = @"<script type='text/javascript'>alert('{0}');</script>";
                //script = string.Format(script, ex.Message);
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                throw new Exception(ex.Message);
            }
        }
        #endregion

        protected string GeneraCodigo()
        {
            string Id_Usuario = string.Empty;
            if (!string.IsNullOrEmpty(TxtApPat.Text) && !string.IsNullOrEmpty(TxtApMat.Text))
            {
                Id_Usuario = TxtApPat.Text[0].ToString() + TxtApMat.Text[0].ToString() + TxtNombre.Text[0].ToString() + "-" + TxtCedula.Text;
            }
            else
            {
                if (!string.IsNullOrEmpty(TxtApPat.Text) && string.IsNullOrEmpty(TxtApMat.Text))
                {
                    Id_Usuario = TxtApPat.Text[0].ToString() + string.Empty + TxtNombre.Text[0].ToString() + "-" + TxtCedula.Text;
                }
                else
                {
                    if (string.IsNullOrEmpty(TxtApPat.Text) && !string.IsNullOrEmpty(TxtApMat.Text))
                    {
                        Id_Usuario = string.Empty + TxtApMat.Text[0].ToString() + TxtNombre.Text[0].ToString() + "-" + TxtCedula.Text;
                    }
                }
            }
            return Id_Usuario;
        }

        protected void Registrar_USUARIO_ESTRUCTURA()
        {
            DB_Usuario Reg = new DB_Usuario();
            Reg.DB_Registrar_USUARIO_ESTRUCTURA(Convert.ToInt32(DDLSup.SelectedValue), LblIdUsuario.Text, TxtCiResp.Text);
        }
        #endregion
        protected void Registrar_CUENTA() 
        {
            VT_Cuenta c = new VT_Cuenta();
            c.Id_Usuario = LblIdUsuario.Text;
            c.Cuenta = TxtNumCuenta.Text;
            c.Banco = TxtBanco.Text;
            c.Estado = "ACTIVO";
            DB_VT_Viaticos rc = new DB_VT_Viaticos();
            rc.DB_Registrar_CUENTA(c);
        }

        protected void DDLSistema_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_ROLES();
        }

        protected void RBTNNO_CheckedChanged(object sender, EventArgs e)
        {
            if (TxtNumCuenta.Text != string.Empty)
            {
                TxtNumCuenta.Enabled = false;
                //TxtNumCuenta.Text = "1000000-?";
                TxtBanco.Enabled = false;
                //TxtBanco.Text = "No Definido";
            }
            else
            {
                TxtNumCuenta.Enabled = false;
                TxtNumCuenta.Text = "1000000-?";
                TxtBanco.Enabled = false;
                TxtBanco.Text = "No Definido";
            }
            
        }

        protected void RBTNSI_CheckedChanged(object sender, EventArgs e)
        {
            if (TxtNumCuenta.Text != string.Empty)
            {
                TxtNumCuenta.Enabled = true;
                //TxtNumCuenta.Text = string.Empty;
                TxtBanco.Enabled = true;
                //TxtBanco.Text = string.Empty;
            }
            else
            {
                TxtNumCuenta.Enabled = true;
                TxtNumCuenta.Text = string.Empty;
                TxtBanco.Enabled = true;
                TxtBanco.Text = string.Empty;
            }
            
        }
        protected void Enabled_Actualizar(bool val)
        {
            TxtCedula.Enabled = val;
            //TxtNombre.Enabled = val;
            //TxtApPat.Enabled = val;
            //TxtApMat.Enabled = val;
            ////TxtCargo.Enabled = val;
            DDLExt.Enabled = val;
            //DDLSistema.Enabled = val;
            //DDLRol.Enabled = val;
            //DDLCategoria.Enabled = val;
            //DDLSup.Enabled=val;
            TxtCiResp.Enabled = val;
            //RBTNSI.Enabled=val;
            //RBTNNO.Enabled=val;
            //DDLEstado.Enabled = val;
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            //Buscar_PERSONA(TxtCedula.Text);            
            if(string.Equals(this.LblEstado.Text,"Modificar"))
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.location ='frmAdminUsuario.aspx';", true);
            else
            this.LimpiarControles();
        }
    }
}