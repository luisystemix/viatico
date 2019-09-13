using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_General;
using DataEntity.DE_General;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;

namespace WebAplication.Insumos
{
    public partial class frmNuevoProv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Desplegar_USUARIO();
                LblAux.Text = Session["Estado"].ToString();
                if (LblAux.Text == "nuevo")
                {
                    LblProg.Text = Session["Programa"].ToString();
                    LblInsumo.Text = Session["Insumo"].ToString();
                }
                else
                {
                    Cargar_PROVEEDOR(); 
                }
            }
        }
        #region FUNCION QUE CARGA LOS DATOS DE UNA EMPRESA PROVEEDORA EXISTENTE
        protected void Cargar_PROVEEDOR() 
        {
            LnkNuevo.Visible = false;
            LblIdInsProv.Text = Session["IdInsProv"].ToString();
            AP_InscripcionProv ip = new AP_InscripcionProv();
            AP_RepresentLegalProv rp = new AP_RepresentLegalProv();
            DB_AP_InscripcionProv insP = new DB_AP_InscripcionProv();
            DB_AP_RepresentLegalProv rlp = new DB_AP_RepresentLegalProv();
            ip = insP.DB_Buscar_INSCRPCION_PROV(Convert.ToInt32(LblIdInsProv.Text));
            TxtMatriculaComer.Text = ip.Matricula_Comercio;
            TxtDomicilio.Text = ip.Domicilio;
            Buscar_PROVEEDOR(ip.Id_Proveedor.ToString());
            rp = rlp.DB_Buscar_REPRESENT_LEGAL_PROV(Convert.ToInt32(LblIdInsProv.Text));
            Buscar_PERSONA(rp.Id_Persona);
            TxtNumTesti.Text = rp.Num_Testimonio;
            TxtFechaTetim.Text = rp.Fecha.ToString();
            DDLTipoPoder.Items.Insert(0, new ListItem(rp.Tipo_Poder, rp.Tipo_Poder, true));
            DDLTipoPoder.DataBind();
            LblEP.Text = "1";
            LblRL.Text = "1";
            LblTP.Text = "1";
        }
        #endregion
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Desplegar_USUARIO()
        {
            DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = Usuario.DB_Desplegar_USUARIO(Session["IdUser"].ToString());
            LblRegional.Text = dt.Rows[0][5].ToString();
            LblIdReg.Text = dt.Rows[0][4].ToString();
            LblCamp.Text = dt.Rows[0][7].ToString();
            LblIdCamp.Text = dt.Rows[0][6].ToString();
        }
        #endregion
        #region FUNCIONES DE EVENTOS SIMPLES
        protected void TxtCedula_TextChanged(object sender, EventArgs e)
        {
            Buscar_PERSONA(TxtCedula.Text);
        }
        protected void TxtNIT_TextChanged(object sender, EventArgs e)
        {
               Buscar_PROVEEDOR(TxtNIT.Text);
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
                //LblEstadoP.Text = "siper";
            }
            else
            {
                //LblEstadoP.Text = "noper";
                //limparCampos_PERSONA();
            }
        }
        #endregion
        #region BUSCAR UNA EMPRESA PROVEEDORA POR EL NUMERO DE NIT O EL CODIGO INTERNO
        private void Buscar_PROVEEDOR(string valor)
        {
            AP_Proveedor p = new AP_Proveedor();
            DB_AP_Proveedor np = new DB_AP_Proveedor();
            p = np.DB_Buscar_PROVEEDOR(valor);
            if (p.NIT == TxtNIT.Text || p.Id_Proveedor == Convert.ToInt32(valor))
            {
                TxtNIT.Text = p.NIT;
                TxtRazonSocial.Text = p.Razon_Social;
                TxtNumTestim.Text = p.Num_Testimonio;
                TxtFechCreacion.Text = p.Fecha_Creacion.ToString();
                DDLDepartamento.Items.Insert(0, new ListItem(p.Departamento, p.Departamento, true));
                DDLDepartamento.DataBind();
            }
            else
            {
                //LblEstadoP.Text = "noper";
                //limparCampos_PERSONA();
            }
        }
        #endregion
        #region FUNCION PARA REGISTRAR LA TABLA PROVEEDOR
        protected void Registrar_PROVEEDOR()
        {
            DB_AP_Proveedor RegProv = new DB_AP_Proveedor();
            AP_Proveedor prov = new AP_Proveedor();
            prov.NIT = TxtNIT.Text;
            prov.Razon_Social = TxtRazonSocial.Text;
            prov.Num_Testimonio = TxtNumTestim.Text;
            prov.Fecha_Creacion = Convert.ToDateTime(TxtFechCreacion.Text);
            RegProv.DB_Registrar_PROVEEDOR(prov);
        }
        #endregion 
        #region FUNCION PARA REGISTRAR LA TABLA INSCRIPCION PROVEEDOR
        protected void Registrar_INSCRIP_PROVEEDOR()
        {
            DB_AP_InscripcionProv RegInsProv = new DB_AP_InscripcionProv();
            AP_InscripcionProv Insprov = new AP_InscripcionProv();
            Insprov.Id_Campanhia = Convert.ToInt32(LblIdCamp.Text);
            Insprov.Id_Proveedor = Convert.ToInt32(LblIdInsProv.Text);
            Insprov.Id_Regional = Convert.ToInt32(LblIdReg.Text);
            Insprov.Insumo = LblInsumo.Text;
            Insprov.Programa = LblProg.Text;
            Insprov.Matricula_Comercio = TxtMatriculaComer.Text;
            Insprov.Domicilio = TxtDomicilio.Text;
            Insprov.Estado = "REGISTRADO";
            RegInsProv.DB_Registrar_INSCRIP_PROVEEDOR(Insprov);
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
            //if (estado == 0)
            //{
            Reg.DB_Registrar_PERSONA(per);
            //}
            //else
            //{
            //  NOrg.UpdateOrganizacion(org);

            //}
        }
        #endregion
        #region FUNCION PARA REGISTRAR AL REPRESNTANTE LEGAL DE LA ORGAMIZACION
        protected void Registrar_REPRESENT_LEGAL()
        {
            DB_AP_RepresentLegalProv RegInsRepLeg = new DB_AP_RepresentLegalProv();
            AP_RepresentLegalProv irl = new AP_RepresentLegalProv();
            irl.Id_InscripcionProv = Convert.ToInt32(LblIdInsProv.Text);
            irl.Id_Persona = TxtCedula.Text; 
            irl.Tipo_Poder = DDLTipoPoder.SelectedItem.Text;
            irl.Num_Testimonio = TxtNumTesti.Text;
            irl.Domicilio = "";
            irl.Fecha = Convert.ToDateTime(TxtFechaTetim.Text);
            RegInsRepLeg.DB_Registrar_REPRESENT_LEGAL_PROV(irl);
        }
        #endregion
        #region FUNCION PARA REGISTRAR A LA TABLA DE DOCUMENTOS SOLICITADOS VERIFICACION DE DOCUMENTOS DE LOS PROVEEDORES
        protected void Registrar_DOC_VERIFICADO_PROV()
        {
            DB_AP_DocVerificadoProv dp = new DB_AP_DocVerificadoProv();
            AP_DocVerificadoProv dv = new AP_DocVerificadoProv();
            dv.Id_VerificarDocProv = Convert.ToInt32(LblIdInsProv.Text);
            dv.Id_InscripcionProv = Convert.ToInt32(LblIdInsProv.Text);
            dv.Ci_Revisor = "5944343"; /*********************************** OJO AQUI SE NECESITA EL CI DEL USUARIO  **************/
            dv.Observacion = "";
            dv.Fecha = DateTime.Now;
            dv.Estado = "PENDIENTE";
            dp.DB_Registrar_DOC_VERIFICADO_PROV(dv);
        }
        #endregion
        #region FUNCION PARA REGISTRAR LOS DOCUMENTOS SOLICITADOS POR CAMPAÑA A LOS PROVEEDORES
        protected void Registrar_DOC_PRESENTADO_PROV()
        {
            DB_AP_DocPresentadoProv dp = new DB_AP_DocPresentadoProv();
            dp.DB_Registrar_DOC_PRESENTADO_PROV(Convert.ToInt32(LblIdInsProv.Text), Convert.ToInt32(LblIdCamp.Text),1);
        }
        #endregion
        #region MODIFICAR LA TABLA PROVEEDOR
        protected void Modificar_PROVEEDOR()
        {
            AP_InscripcionProv ip = new AP_InscripcionProv();
            DB_AP_InscripcionProv insP = new DB_AP_InscripcionProv();
            ip = insP.DB_Buscar_INSCRPCION_PROV(Convert.ToInt32(LblIdInsProv.Text));

            DB_AP_Proveedor Regprov = new DB_AP_Proveedor();
            AP_Proveedor prov = new AP_Proveedor();
            prov.Id_Proveedor = ip.Id_Proveedor;
            prov.Razon_Social = TxtRazonSocial.Text;
            prov.NIT = TxtNIT.Text;
            prov.Num_Testimonio = TxtNumTestim.Text;
            prov.Fecha_Creacion = Convert.ToDateTime(TxtFechCreacion.Text);
            prov.Departamento = DDLDepartamento.SelectedItem.Text;
            Regprov.DB_Modificar_PROVEEDOR(prov);
        }
        #endregion 
        #region MODIFICAR LA TABLA PROVEEDOR
        protected void Modificar_INSCRIP_PROVEEDOR()
        {
            DB_AP_InscripcionProv insP = new DB_AP_InscripcionProv();
            AP_InscripcionProv ip = new AP_InscripcionProv();
            ip.Id_InscripcionProv=Convert.ToInt32(LblIdInsProv.Text);
            ip.Matricula_Comercio = TxtMatriculaComer.Text;
            ip.Domicilio = TxtDomicilio.Text;
            insP.DB_Modificar_INSCRIP_PROVEEDOR(ip);
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
            per.Estado = "Activo";
            Reg.DB_Modificar_PERSONA(per);
        }
        #endregion
        #region FUNCION PARA MODIFICAR AL REPRESNTANTE LEGAL DE LA EMPRESA PROVEEDORA
        protected void Modificar_REPRESENT_LEGAL_PROVEEDOR()
        {
            DB_AP_RepresentLegalProv RegInsRepLegProv = new DB_AP_RepresentLegalProv();
            AP_RepresentLegalProv irlp = new AP_RepresentLegalProv();
            irlp.Tipo_Poder = DDLTipoPoder.SelectedItem.Text;
            irlp.Num_Testimonio = TxtNumTesti.Text;
            irlp.Fecha = Convert.ToDateTime(TxtFechaTetim.Text);
            RegInsRepLegProv.DB_Modificar_REPRESENT_LEGAL_PROV(irlp);
        }
        #endregion
        #region FUNCIONES PARA VALIDAR DATOS
        private void validacion_REGISTRO()
        {
            if (TxtNIT.Text != "")
            {
                if (TxtMatriculaComer.Text != "")
                {
                    if (TxtRazonSocial.Text != "")
                    {
                        if (TxtNumTestim.Text !="")
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
                           LblMsj1.Text = "NUMERO TESTIMONIO DE CREACION";
                       }
                    }
                    else
                    {
                        LblMsj1.Text = "ERROR NUMERO DE RAZON SOCIAL";
                    }

                }
                else
                {
                    LblMsj1.Text = "ERROR MATRICULA COMERCIO";
                }
            }
            else
            {
                LblMsj1.Text = "ERROR NIT";
            }
        }
        #endregion
        #region FUNCIONES PARA REGISTRAR DATOS
        private void Registrar_INSCRIPCION()
        {
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();

            if (LblEP.Text == Convert.ToString(1))
            {
                Modificar_PROVEEDOR();
                Modificar_INSCRIP_PROVEEDOR();
            }
            else
            {
                Registrar_PROVEEDOR();
                LblIdInsProv.Text = aux.DB_MaxId("AP_PROVEEDOR", "Id_Proveedor");
                Registrar_INSCRIP_PROVEEDOR();
            }
            if (LblRL.Text == Convert.ToString(1))
            {
                Modificar_PERSONA();
            }
            else
            {
                Registrar_PERSONA();
            }
            if (LblTP.Text == Convert.ToString(1))
            {
                Modificar_REPRESENT_LEGAL_PROVEEDOR();
            }
            else
            {
                LblIdInsProv.Text = aux.DB_MaxId("AP_INSCRIPCION_PROV", "Id_InscripcionProv");
                Registrar_REPRESENT_LEGAL();
            }
            if (LblAux.Text == "nuevo")
            {
                Session.Add("IdInsProv", LblIdInsProv.Text);
                Registrar_DOC_VERIFICADO_PROV();
                Registrar_DOC_PRESENTADO_PROV();
                Response.Redirect("frmControlDocProv.aspx");
            }
            else 
            {
                Response.Redirect("frmRegistroProv.aspx");
            }
        }
        #endregion
        #region FUNCION PARA REGISTRAR UNA NUEVA INSCRIPCION DE UN PROVEEDOR
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            validacion_REGISTRO();
        }
        #endregion
    }
}