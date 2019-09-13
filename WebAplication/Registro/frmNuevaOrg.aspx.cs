﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI; 
using System.Data;
using System.Web.UI.WebControls;
using System.Text;
using DataEntity.DE_Registro;
using DataBusiness.DB_Registro;
using DataEntity.DE_General;
using DataBusiness.DB_General;

namespace WebAplication.Registro
{
    public partial class frmNuevaOrg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblAux.Text = Session["Estado"].ToString();
                    LblIdUser.Text = Session["IdUser"].ToString();

                    if (LblAux.Text == "nuevo")
                    {
                        Desplegar_ENCAVEZADO2();
                    }
                    else
                    {   
                        Desplegar_ENCAVEZADO1();
                        AP_InscripcionOrg io = new AP_InscripcionOrg();
                        AP_RepresentLegal rl = new AP_RepresentLegal();
                        DB_AP_Organizacion no = new DB_AP_Organizacion();
                        io = no.DB_Buscar_INSCRPCION_ORG(Convert.ToInt32(Session["IdInsOrg"].ToString()));
                        Buscar_ORGANIZACION(io.Id_Organizacion);
                        rl = no.DB_Buscar_REPRESENT_LEGAL(io.Id_InscripcionOrg);
                        Buscar_PERSONA(rl.Id_Persona);
                        Buscar_REPESENTANTE_LEGAL(io.Id_InscripcionOrg);
                        LblEstadoO.Text = "siorg";
                        LblEstadoP.Text = "siper";
                        LblEstadoTP.Text = "sitp";
                        LnkNuevaOrg.Visible = false;
                    }
                    Llenar_DDLTipProd();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Desplegar_ENCAVEZADO1()
        {
            DB_AP_Registro_Org vro = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = vro.DB_Desplegar_ENCABEZADO_ORG(Convert.ToInt32(Session["IdInsOrg"].ToString()));
            ((Label)contEncabezado11.FindControl("LblRegional")).Text = dt.Rows[0][8].ToString();
            ((Label)contEncabezado11.FindControl("LblIdRegional")).Text = dt.Rows[0][7].ToString();
            ((Label)contEncabezado11.FindControl("LblCampanhia")).Text = dt.Rows[0][6].ToString();
            ((Label)contEncabezado11.FindControl("LblIdCampanhia")).Text = dt.Rows[0][5].ToString();
            ((Label)contEncabezado11.FindControl("LblPrograma")).Text = dt.Rows[0][9].ToString();
        }
        #endregion
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Desplegar_ENCAVEZADO2()
        {
            DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = Usuario.DB_Desplegar_USUARIO(Session["IdUser"].ToString());
            ((Label)contEncabezado11.FindControl("LblRegional")).Text = dt.Rows[0][5].ToString();
            ((Label)contEncabezado11.FindControl("LblIdRegional")).Text = dt.Rows[0][4].ToString();
            DB_AP_Campanhia cam = new DB_AP_Campanhia();
            AP_Campanhia ca = new AP_Campanhia();
            ca = cam.DB_Buscar_CAMPANHIA(Convert.ToInt32(Session["IdCamp"].ToString()));
            ((Label)contEncabezado11.FindControl("LblCampanhia")).Text = ca.Nombre;
            ((Label)contEncabezado11.FindControl("LblIdCampanhia")).Text = Session["IdCamp"].ToString();
            ((Label)contEncabezado11.FindControl("LblPrograma")).Text = Session["Prog"].ToString();
        }
        #endregion
        #region FUNCION PARA LLENAR EL COMBO CON EL TIPO DE ORGANIZACION
        private void Llenar_DDLTipProd()
        {
            DB_AP_Parametros_Camp pc = new DB_AP_Parametros_Camp();
            List<AP_ParametrosCamp> Lista = pc.DB_Desplegar_PARAMETRO_CAMP(Convert.ToInt32(((Label)contEncabezado11.FindControl("LblIdCampanhia")).Text));
            DDLTipProd.DataSource = Lista;
            DDLTipProd.DataValueField = "Tipo_Produccion";
            DDLTipProd.DataTextField = "Tipo_Produccion";
            DDLTipProd.DataBind();
        }
        #endregion
        #region FUNCIONES INDEPENDIENTES BUSCAR PERSONA POR CEDULA DE IDENTIDAD
        private void Buscar_PERSONA(string ci)
        {
            Persona p = new Persona();
            DB_Persona np = new DB_Persona();
            p = np.DB_Buscar_PERSONA(ci);
            if (p.ci == ci)
            {
                TxtCedula.Text = p.ci;
                DDLExt.Items.Insert(0, new ListItem(p.ext, p.ext, true));
                DDLExt.DataBind();
                TxtNombre.Text = p.Nombres;
                TxtPaterno.Text = p.Primer_ap;
                TxtMaterno.Text = p.Segundo_ap;
                TxtFijo.Text = p.Telef_fijo;
                TxtMovil.Text = p.Telef_cel;
                LblEstadoP.Text = "siper";
            }
            else
            {
                LblEstadoP.Text = "noper";
                limparCampos_PERSONA();
            }
        }
        private void Buscar_ORGANIZACION(int id)
        {
            AP_Organizacion o = new AP_Organizacion();
            DB_AP_Organizacion no = new DB_AP_Organizacion();
            o = no.DB_Buscar_ORG(id);
            if (o.Id_Organizacion == id)
            {
                DDLDepartamento.Items.Insert(0,new ListItem(o.Departamento,o.Departamento,true));
                DDLDepartamento.DataBind();
                TxtSigla.Text = o.Sigla;
                DDLSigla.Items.Insert(0, new ListItem(o.Sigla, o.Id_Organizacion.ToString(), true));
                DDLSigla.DataBind();

                TxtPersonJuridi.Text = o.Personeria_Juridica;
                DDLTipoOrg.Items.Insert(0, new ListItem(o.Tipo,o.Tipo,true));
                DDLTipoOrg.DataBind(); 
                TxtNumResolucion.Text = o.Resolucion_Prefect;
                TxtFechCreacion.Text = o.Fecha_Creacion.ToString("dd/MM/yyyy");
                TxtDomicilio.Text = o.DomicilioOrg;
                //TxtSigla.Text = DDLSigla.SelectedItem.Text;
                LblEstadoO.Text = "siorg";
            }
            else
            {
                LblEstadoO.Text = "noorg";
            }
        }
        private void Buscar_INSCRIPCION_ORG(int id)
        {
            AP_InscripcionOrg io = new AP_InscripcionOrg();
            DB_AP_Organizacion no = new DB_AP_Organizacion();
            //io = no.DA_Buscar_INSCRPCION_ORG(id);
        }
        private void Buscar_REPESENTANTE_LEGAL(int id)/***************************************************************/
        {
            AP_RepresentLegal rl = new AP_RepresentLegal();
            DB_AP_Organizacion rlo = new DB_AP_Organizacion();
            rl = rlo.DB_Buscar_REPRESENT_LEGAL(id);
            TxtNumTesti.Text = rl.Nun_Testimonio;
            TxtFechaTetim.Text = rl.Fecha.ToString();
            DDLTipoPoder.Items.Insert(0,new ListItem(rl.Tipo_Poder,rl.Tipo_Poder,true));
            TxtNumNotario.Text = rl.Num_Notaria.ToString();
            TxtDistritoJudi.Text = rl.Distrito_Judicial.ToString();
            TxtAbogado.Text = rl.Abg_A_Cargo.ToString();
        }
        private void limparCampos_ORGANIZACION()
        {
            TxtSigla.Text = string.Empty;
            TxtPersonJuridi.Text = string.Empty;
            TxtFechCreacion.Text = string.Empty;
            TxtNumResolucion.Text = string.Empty;
            TxtDomicilio.Text = string.Empty;
        }
        private void limparCampos_PERSONA()
        {
            TxtNombre.Text = string.Empty;
            TxtPaterno.Text = string.Empty;
            TxtMaterno.Text = string.Empty;
            TxtFijo.Text = string.Empty;
            TxtMovil.Text = string.Empty;
        }
        #endregion     
        #region FUNCION PARA REGISTRAR LA ORGANIZACION
        protected void Registrar_ORG()
        {
            DB_AP_Organizacion RegOrg = new DB_AP_Organizacion();
            AP_Organizacion org = new AP_Organizacion();  
            org.Personeria_Juridica = TxtPersonJuridi.Text;
            org.Sigla = TxtSigla.Text;
            org.Departamento = DDLDepartamento.SelectedItem.Text;
            org.Resolucion_Prefect = TxtNumResolucion.Text;
            org.Fecha_Creacion = Convert.ToDateTime(TxtFechCreacion.Text);
            org.Tipo = DDLTipoOrg.SelectedItem.Text;
            org.DomicilioOrg = TxtDomicilio.Text;
            RegOrg.DB_Registrar_ORG(org);
        }
        #endregion       
        #region FUNCION PARA MODIFICAR LA ORGANIZACION
        protected void Modificar_ORG()
        {
            DB_AP_Organizacion RegOrg = new DB_AP_Organizacion();
            AP_Organizacion org = new AP_Organizacion();
            org.Id_Organizacion = Convert.ToInt32(DDLSigla.SelectedValue);
            org.Personeria_Juridica = TxtPersonJuridi.Text;
            org.Sigla = TxtSigla.Text;
            org.Departamento = DDLDepartamento.SelectedItem.Text;
            org.Resolucion_Prefect = TxtNumResolucion.Text;
            org.Fecha_Creacion = Convert.ToDateTime(TxtFechCreacion.Text);
            org.Tipo = DDLTipoOrg.SelectedItem.Text;
            org.DomicilioOrg = TxtDomicilio.Text;
            RegOrg.DB_Modificar_ORG(org);
        }
        #endregion       
        #region FUNCION PARA REGISTRAR LA INSCRIPCION DE UNA ORGANIZACION
        protected void Registrar_INSCRIP_ORG()
        { 
            DB_AP_Organizacion RegInsOrg = new DB_AP_Organizacion();
            AP_InscripcionOrg io = new AP_InscripcionOrg();
            io.Id_Organizacion = Convert.ToInt32(LblIdOrg.Text);
            io.Id_Campanhia = Convert.ToInt32(((Label)contEncabezado11.FindControl("LblIdCampanhia")).Text);
            io.Id_Regional = Convert.ToInt32(((Label)contEncabezado11.FindControl("LblIdRegional")).Text);
            io.Programa = ((Label)contEncabezado11.FindControl("LblPrograma")).Text;
            io.Fecha_Registro=DateTime.Now;
            io.Tipo_Produccion = DDLTipProd.SelectedItem.Text;
            io.Estado = "REGISTRADO";
            RegInsOrg.DB_Registrar_INSCRIP_ORG(io);
        }
        #endregion   
        #region FUNCION PARA REGISTRAR AL REPRESNTANTE LEGAL DE LA ORGAMIZACION
        protected void Registrar_REPRESENT_LEGAL()
        {
            DB_AP_Organizacion RegInsRepLeg = new DB_AP_Organizacion();
            AP_RepresentLegal irl = new AP_RepresentLegal();
            irl.Id_Persona = TxtCedula.Text;
            irl.Id_InscripcionOrg = Convert.ToInt32(LblIdOrg.Text);
            irl.Tipo_Poder = DDLTipoPoder.SelectedItem.Text;
            irl.Nun_Testimonio = TxtNumTesti.Text;
            irl.Domicilio = "";
            irl.Fecha = Convert.ToDateTime(TxtFechaTetim.Text);
            irl.Num_Notaria = TxtNumNotario.Text;
            irl.Distrito_Judicial = TxtDistritoJudi.Text;
            irl.Abg_A_Cargo = TxtAbogado.Text;
            RegInsRepLeg.DB_Registrar_REPRESENT_LEGAL(irl);
        }
        #endregion
        #region FUNCION PARA MODIFICAR AL REPRESNTANTE LEGAL DE LA ORGAMIZACION
        protected void Modificar_REPRESENT_LEGAL()
        {
            DB_AP_Organizacion RegInsRepLeg = new DB_AP_Organizacion();
            AP_RepresentLegal irl = new AP_RepresentLegal();
            irl.Id_Persona = TxtCedula.Text;
            irl.Id_InscripcionOrg = Convert.ToInt32(LblIdOrg.Text);
            irl.Nun_Testimonio = TxtNumTesti.Text;
            irl.Domicilio = "";
            irl.Fecha = Convert.ToDateTime(TxtFechaTetim.Text);
            irl.Num_Notaria = TxtNumNotario.Text;
            irl.Distrito_Judicial = TxtDistritoJudi.Text;
            irl.Abg_A_Cargo = TxtAbogado.Text;
            RegInsRepLeg.DB_Modificar_REPRESENT_LEGAL(irl);
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
            per.Primer_ap = TxtPaterno.Text;
            per.Segundo_ap = TxtMaterno.Text;
            per.Fecha_nacimiento = Convert.ToDateTime("01/01/1990");
            per.Sexo = true;
            per.Telef_fijo = TxtFijo.Text;
            per.Telef_cel = TxtMovil.Text;
            per.Fecha_registro = DateTime.Now;
            per.Estado = "Activo";
            Reg.DB_Registrar_PERSONA(per);           
        }
        #endregion
        #region FUNCION PARA MODIFICAR LOS DATOS DE PERSONA
        protected void Modificar_PERSONA()
        {
            DB_Persona Reg = new DB_Persona();
            Persona per = new Persona();
            per.Id_Persona = TxtCedula.Text;
            per.ci = TxtCedula.Text;
            per.ext = DDLExt.SelectedItem.Text;
            per.Nombres = TxtNombre.Text;
            per.Primer_ap = TxtPaterno.Text;
            per.Segundo_ap = TxtMaterno.Text;      
            per.Fecha_nacimiento = Convert.ToDateTime("01/01/1990");
            per.Sexo = true;
            per.Telef_fijo = TxtFijo.Text;
            per.Telef_cel = TxtMovil.Text;
            per.Fecha_registro = DateTime.Now;
            per.Estado = "ACTIVO";
            Reg.DB_Modificar_PERSONA(per);
        }
        #endregion
        #region FUNCION PARA REGISTRAR LOS DOCUMENTOS SOLICITADOS POR CAMPAÑA
        protected void Registrar_DOC_PRESENTADO()
        {
            DB_AP_Organizacion dp = new DB_AP_Organizacion();
            dp.DB_Registrar_DOC_PRESENTADO(Convert.ToInt32(LblIdOrg.Text), Convert.ToInt32(((Label)contEncabezado11.FindControl("LblIdCampanhia")).Text),DDLDepartamento.SelectedValue);
        }
        #endregion
        #region FUNCION PARA REGISTRAR A LA TABLA DE DOCUMENTOS SOLICITADOS VERIFICACION DE DOCUMENTOS
        protected void Registrar_DOC_VERIFICADO()
        {
            DB_AP_DocVerificado dp = new DB_AP_DocVerificado();
            AP_DocVerificado dv = new AP_DocVerificado();
            dv.Id_VerificarDoc = Convert.ToInt32(LblIdOrg.Text);
            dv.Id_InscripcionOrg = Convert.ToInt32(LblIdOrg.Text);
            dv.NumProductores = 0;
            dv.SuperficieTotal = 0;
            dv.Ci_Revisor = LblIdUser.Text; /******************************************************************************************** OJO AQUI SE NECESITA EL CI DEL USUARIO  **************/
            dv.Observacion = "";
            dv.Fecha = DateTime.Now;
            dv.Estado = "PENDIENTE";
            dp.DB_Registrar_DOC_VERIFICADO(dv);
        }
        #endregion
        #region FUNCION INDEPENDIENTES
        protected void Actualizar_COMBO()
        {
            DB_AP_Registro_Org org = new DB_AP_Registro_Org();
            List<AP_Organizacion> Lista = org.DB_Desplegar_ORG_DEP(DDLDepartamento.SelectedItem.Text);
            if (Lista.Count > 0)
            {
                DDLSigla.DataSource = Lista;
                DDLSigla.DataValueField = "Id_Organizacion";
                DDLSigla.DataTextField = "Sigla";
                DDLSigla.DataBind();
                DDLSigla.Items.Insert(0, new ListItem("Buscar Organización", "0", true));
                DDLSigla.Visible = true;
                TxtSigla.Visible = false;
                LnkNuevaOrg.Text = "[ Nuevo ]";
                LnkNuevaOrg.Visible = true;
                DDLDepartamento.Enabled = false;
            }
            else
            {
                DDLSigla.Visible = false;
                TxtSigla.Visible = true;
            }
        }
        #endregion


        #region FUNCIONES DE LOS CONTROLES
        protected void DDLDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Actualizar_COMBO();
        }
        //LISTAR TODAS LAS ORGANIZACIONES DE UN DEPARTAMENTO
        protected void LnkNuevaOrg_Click(object sender, EventArgs e)
        {
            limparCampos_ORGANIZACION();
            DDLSigla.Visible = false;
            DDLDepartamento.Enabled = false;
            TxtSigla.Visible = true;
            LblEstadoO.Text = "noorg";
        }
        // BUSCAR PERSONA POR SU CEDULA DE IDENTIDAD
        protected void TxtCedula_TextChanged(object sender, EventArgs e)
        {
            Buscar_PERSONA(TxtCedula.Text);
        }
        #endregion     
        #region FUNCIONES PARA VALIDAR DATOS
        private void validacion_REGISTRO()
        {
            if (DDLDepartamento.SelectedItem.Text != "BUSCAR --?--")
            {
                if(TxtSigla.Text!="")
                {
                    if (TxtPersonJuridi.Text != "")
                    {
                        if (TxtNumResolucion.Text != "")
                        {
                            if (TxtFechCreacion.Text != "")
                            {
                                if (TxtDomicilio.Text != "")
                                {
                                    LblMsj1.Text = "";
                                    if(TxtCedula.Text!="")
                                    {
                                        if(TxtNombre.Text!="")
                                        {
                                            if(TxtPaterno.Text!="")
                                            {
                                                if(TxtFechaTetim.Text!="")
                                                {
                                                    if(TxtNumNotario.Text!="")
                                                    {
                                                        if(TxtDistritoJudi.Text!="")
                                                        {
                                                            if(TxtAbogado.Text!="")
                                                            {
                                                                Registrar_INSCRIPCION();
                                                            }
                                                            else
                                                            {
                                                                LblMsj3.Text = "ERROR ABOGADO A CARGO";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            LblMsj3.Text = "ERROR DISTRITO JUDICIAL";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        LblMsj3.Text = "ERROR NUMRO DE NOTARIO";
                                                    }
                                                }
                                                else
                                                {
                                                    LblMsj3.Text="ERROR NUMRO DE TESTIMONIO";
                                                }
                                            }
                                            else
                                            {
                                                LblMsj2.Text = "ERROR APELLIDO PATERNO";
                                            }
                                        }
                                        else
                                        {
                                            LblMsj2.Text="ERROR NOMBRE";
                                        }
                                    }
                                    else
                                    {
                                        LblMsj2.Text = "ERROR CI";
                                    }
                                }
                                else
                                {
                                    LblMsj1.Text = "ERROR DOMICILIO";
                                }
                            }
                            else
                            {
                                LblMsj1.Text = "ERROR FECHA CREACION";
                            }
                        }
                        else
                        {
                            LblMsj1.Text = "ERROR NUMERO DE RESOLUCION";
                        }

                    }
                    else
                    {
                        LblMsj1.Text = "ERROR PERSONERIA JURIDICA";
                    }
                }
                else
                {
                    LblMsj1.Text = "ERROR SIGLA";
                }
            }
            else
            {
                LblMsj1.Text = "ERROR SELECCIONE UN DEPARTAMENTO";
            }
        }
        #endregion
        #region FUNCIONES PARA VALIDAR DATOS
        private void Registrar_INSCRIPCION()
        {
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            if (LblEstadoO.Text == "siorg")
            {
                Modificar_ORG();
                LblIdOrg.Text = DDLSigla.SelectedValue;
            }
            else
            {
                Registrar_ORG();
                LblIdOrg.Text = aux.DB_MaxId("AP_ORGANIZACION", "Id_Organizacion");
            }
            if (LblAux.Text == "nuevo")
            {
                Registrar_INSCRIP_ORG();
            }

            if (LblEstadoP.Text == "siper")
            {
                Modificar_PERSONA();
            }
            else
            {
                Registrar_PERSONA();
            }
            if (LblEstadoTP.Text == "sitp")
            {
                Modificar_REPRESENT_LEGAL();
            }
            else
            {
                LblIdOrg.Text = aux.DB_MaxId("AP_INSCRIPCION_ORG", "Id_InscripcionOrg");
                Registrar_REPRESENT_LEGAL();
            }
            if (LblAux.Text == "nuevo")
            {
                Registrar_DOC_VERIFICADO();
                Registrar_DOC_PRESENTADO();
                Session.Add("IdInsOrg", LblIdOrg.Text);
                Session.Add("Estado", "nuevo");
                Response.Redirect("frmControlDocOrg.aspx");
            }
            Response.Redirect("frmRegistroOrg.aspx");
        }
        #endregion
        #region FUNCION PARA REGISTRAR UNA NUEVA INSCRIPCION DE ORGANIZACON
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            validacion_REGISTRO();
        }
        #endregion
        #region BUSCAR LA ORGANIZACION Y COPIAR SUS DATOS
        protected void DDLSigla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLSigla.SelectedItem.Text != "Buscar Organización")
            {
                Buscar_ORGANIZACION(Convert.ToInt32(DDLSigla.SelectedValue));
            }
            else 
            {
                Actualizar_COMBO();
                TxtPersonJuridi.Text = string.Empty;
                TxtNumResolucion.Text = string.Empty;
                TxtFechCreacion.Text = string.Empty;
                TxtDomicilio.Text = string.Empty;
                TxtSigla.Text = string.Empty;
            }
        }
        #endregion
        protected void DDLTipProd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}