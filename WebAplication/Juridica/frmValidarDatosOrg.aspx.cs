using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;
using DataEntity.DE_General;
using DataBusiness.DB_General;

namespace WebAplication.Juridica
{
    public partial class frmValidarDatosOrg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Desplegar_INSCRIPCION_ORG(); 
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
        #region FUNCION PRINCIPAL PARA CARGAR TODO EL FORMULARIO
        protected void Desplegar_INSCRIPCION_ORG() 
        {
            Desplegar_ENCAVEZADO1();
            AP_InscripcionOrg io = new AP_InscripcionOrg();
            AP_RepresentLegal rl = new AP_RepresentLegal();
            DB_AP_Organizacion no = new DB_AP_Organizacion();
            io = no.DB_Buscar_INSCRPCION_ORG(Convert.ToInt32(Session["IdInsOrg"].ToString()));
            LblIdOrg.Text = io.Id_Organizacion.ToString();
            LblTipoProd.Text = io.Tipo_Produccion.ToString();
            Buscar_ORGANIZACION(io.Id_Organizacion);
            rl = no.DB_Buscar_REPRESENT_LEGAL(io.Id_InscripcionOrg);
            Buscar_PERSONA(rl.Id_Persona);
            Buscar_REPESENTANTE_LEGAL(io.Id_InscripcionOrg);
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
            }
            else
            {
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
                DDLDepartamento.Items.Insert(0, new ListItem(o.Departamento, o.Departamento, true));
                DDLDepartamento.DataBind();
                TxtSigla.Text = o.Sigla;
                TxtPersonJuridi.Text = o.Personeria_Juridica;
                DDLTipoOrg.Items.Insert(0, new ListItem(o.Tipo, o.Tipo, true));
                DDLTipoOrg.DataBind();
                TxtNumResolucion.Text = o.Resolucion_Prefect;
                TxtFechCreacion.Text = o.Fecha_Creacion.ToString();
                TxtDomicilio.Text = o.DomicilioOrg;
            }
        }
        private void Buscar_REPESENTANTE_LEGAL(int id)/***************************************************************/
        {
            AP_RepresentLegal rl = new AP_RepresentLegal();
            DB_AP_Organizacion rlo = new DB_AP_Organizacion();
            rl = rlo.DB_Buscar_REPRESENT_LEGAL(id);
            TxtNumTesti.Text = rl.Nun_Testimonio;
            TxtFechaTetim.Text = rl.Fecha.ToString();
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
        protected void TxtCedula_TextChanged(object sender, EventArgs e)
        {
            Buscar_PERSONA(TxtCedula.Text); 
        }
        #region FUNCIONES PARA VALIDAR DATOS
        private void validacion_REGISTRO()
        {
            if (TxtSigla.Text != "")
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
                                if (TxtCedula.Text != "")
                                {
                                    if (TxtNombre.Text != "")
                                    {
                                        if (TxtPaterno.Text != "")
                                        {
                                            if (TxtFechaTetim.Text != "")
                                            {
                                                Registrar_INSCRIPCION();
                                            }
                                            else
                                            {
                                                LblMsj3.Text = "ERROR NUMRO DE TESTIMONIO";
                                            }
                                        }
                                        else
                                        {
                                            LblMsj2.Text = "ERROR APELLIDO PATERNO";
                                        }
                                    }
                                    else
                                    {
                                        LblMsj2.Text = "ERROR NOMBRE";
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
        #endregion
        #region FUNCION PARA MODIFICAR LA ORGANIZACION
        protected void Modificar_ORG()
        {
            DB_AP_Organizacion RegOrg = new DB_AP_Organizacion();
            AP_Organizacion org = new AP_Organizacion();
            org.Id_Organizacion = Convert.ToInt32(LblIdOrg.Text);
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
        protected void Modificar_INSCRIP_ORG()
        {
            DB_AP_Organizacion RegInsOrg = new DB_AP_Organizacion();
            AP_InscripcionOrg io = new AP_InscripcionOrg();
            io.Id_InscripcionOrg = Convert.ToInt32(Session["IdInsOrg"].ToString());
            io.Tipo_Produccion = LblTipoProd.Text;
            io.Estado = "APROBADO-LEGAL";
            RegInsOrg.DB_Modificar_INSCRIP_ORG(io);
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
        #region FUNCIONES PARA VALIDAR DATOS
        private void Registrar_INSCRIPCION()
        {
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            Modificar_ORG();
            Modificar_INSCRIP_ORG();
            Modificar_PERSONA();
            Modificar_REPRESENT_LEGAL();
            Response.Redirect("frmValidarOrg.aspx");
        }
        #endregion
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            validacion_REGISTRO();
        }
    }
}