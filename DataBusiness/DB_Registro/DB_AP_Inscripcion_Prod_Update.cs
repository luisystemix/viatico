using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.DA_Registro;
using DataAccess.DA_General;
using DataBusiness.DB_General;
using DataEntity.DE_General;
using DataEntity.DE_Registro;

namespace DataBusiness.DB_Registro
{
    public class DB_AP_Inscripcion_Prod_Update
    {

        #region OBTENER LA LISTA DE LAS TABLAS INCRIPCION_PROD => PERSONA => INSCRIPCION_ORG
        public DataTable DB_Desplegar_INCRIPCIONPROD_PER_INSORG(int IdCamp, int IdReg, string ci, string nombre, string apellidoP, string apellidoM)
        {
            //VALIDAR DESDE AQUI
            DA_AP_Inscripcion_Prod_Update data = new DA_AP_Inscripcion_Prod_Update();
            return data.DA_Desplegar_INCRIPCIONPROD_PER_INSORG(IdCamp, IdReg, ci, nombre, apellidoP, apellidoM);
        }
        #endregion
        #region OBTENER EL DEPARTAMENTO DE LAS TABLAS REGIONAL => AP_INSCRIPCION_ORG
        public String DB_Desplegar_REGIONAL_AP_INSCRIPCION_ORG(Int32 Id_InscripcionOrg)
        {
            //VALIDAR DESDE AQUI
            DA_AP_Inscripcion_Prod_Update data = new DA_AP_Inscripcion_Prod_Update();
            return data.DA_Desplegar_REGIONAL_AP_INSCRIPCION_ORG(Id_InscripcionOrg);
        }
        #endregion
        #region VALIDAR DATOS DE BENEFICIARIO
        public void DB_Verificar_FORMULARIO_NEW_BENEFICIARIO(TextBox CI, DropDownList DROPLIST_EXT, TextBox Nombre, TextBox Paterno, TextBox Materno, TextBox FechaNac, TextBox Tel, TextBox Mov, RadioButton RadioButtonVaron, RadioButton RadioButtonMujer, ref Persona per, ref String men)
        {
            try
            {
                per.Fecha_nacimiento = Convert.ToDateTime(FechaNac.Text);
                per.Fecha_registro = DateTime.Now;
                per.Estado = "INSCRITO";
            }
            catch
            {
                men = "error en el formato de fecha";
            }
            if (men == "")
            {
                if (CI.Text == "") { men = "debe registrar un carnet"; } else { per.ci = CI.Text; }
            }
            if (men == "")
            {
                if (DROPLIST_EXT.SelectedIndex == 0) { men = "debe seleccionar una expedicion para el carnet."; } else { per.ext = DROPLIST_EXT.SelectedValue; }
            }
            if (men == "")
            {
                if (Nombre.Text.Trim() == "") { men = "debe registrar un nombre"; } else { per.Nombres = Nombre.Text.ToUpper(); }
            }
            if (men == "")
            {
                if (Paterno.Text.Trim() == "") { men = "debe registrar porlomenos el primer apellido"; } else { per.Primer_ap = Paterno.Text.ToUpper(); per.Segundo_ap = Materno.Text.ToUpper(); }
            }
            if (men == "")
            {
                if ((Tel.Text.Trim() == "") && (Mov.Text.Trim() == "")) { /*men = "debe registrar celular o movil";*/ per.Telef_fijo = Tel.Text; per.Telef_cel = Mov.Text;} else { per.Telef_fijo = Tel.Text; per.Telef_cel = Mov.Text; }
            }
            if (RadioButtonVaron.Checked == false && RadioButtonMujer.Checked == false) { men = "debe debe seleccionar genero"; }
            if (RadioButtonMujer.Checked == true) { per.Sexo = false; } else { per.Sexo = true; }
        }
        #endregion
        #region VALIDAR DATOS DE UBICACION
        public void DB_Verificar_FORMULARIO_NEW_UBICACION(DropDownList DropDownListMUN, DropDownList DropDownListCOM, DropDownList DropDownListTipo, TextBox TextBoxSUP, TextBox TextBoxRAU, TextBox CI, TextBox TextBoxOBS, ref AP_Productor pro, ref String men)
        {
            if (DropDownListMUN.SelectedIndex > 0)
            {
                if (DropDownListCOM.SelectedIndex > 0)
                {
                    if (DropDownListTipo.SelectedIndex > 0)
                    {
                        try
                        {
                            pro.Has_Inscrito = Convert.ToDecimal(TextBoxSUP.Text);
                            pro.Rau = Convert.ToInt32(TextBoxRAU.Text);
                            pro.Id_Comunidad = Convert.ToInt32(DropDownListCOM.SelectedValue);
                            pro.Tipo_Inscripcion = Convert.ToString(DropDownListTipo.SelectedValue);
                            pro.Id_Persona = CI.Text;
                            pro.Observacion = TextBoxOBS.Text;
                            
                        }
                        catch
                        {
                            men = "Debe ingresar una superficie o un numero de rau";
                        }
                    }
                    else
                    {
                        men = "Debe Seleccionar un tipo de Beneficiario";
                    }
                }
                else
                {
                    men = "Debe Seleccionar una Comunidad";
                }
            }
            else
            {
                men = "Debe Seleccionar un Municipio";
            }
        }
        #endregion
        #region VERIFICAR Y AGREGAR DATOS
        public String VERIFICAR_AGREGAR_DATOS_PERSONA_AP_INS_PRO(Persona per, AP_Productor pro, Int32 campanhia, Int32 InscripOrg)
        {
            String men = "";
            DB_Persona dat = new DB_Persona();
            if (false == dat.DB_Existe_PERSONA(per.ci))
            {
                DA_Persona datper = new DA_Persona();
                datper.DA_Registrar_PERSONA(per);
                DA_AP_Inscripcion_Prod proReg = new DA_AP_Inscripcion_Prod();
                pro.Id_Campanhia = campanhia;
                pro.Estado = "INSCRITO";
                pro.Id_InscripcionOrg = InscripOrg;
                DA_AP_Registro_Org reg_Org = new DA_AP_Registro_Org();
                String Programa = "";
                String TipoP = "";
                reg_Org.Seleccionar_Prog_DA_AP_INCRIPCION_ORG(InscripOrg, ref Programa, ref TipoP);
                pro.Programa = Programa;
                pro.Tipo_Produccion = TipoP;
                DB_AP_Registro_Prod regP = new DB_AP_Registro_Prod();
                pro.Id_Productor = regP.DB_GeneraCodigo_AP_INSCRIPCION_PRO(campanhia, InscripOrg, Programa);
                /*********************************/
                DB_AP_Organizacion org = new DB_AP_Organizacion();
                AP_InscripcionOrg io = new AP_InscripcionOrg();
                io = org.DB_Buscar_INSCRPCION_ORG(pro.Id_InscripcionOrg);
                DB_AP_Organizacion reg = new DB_AP_Organizacion();
                AP_Comunidad_Org comOrg = new AP_Comunidad_Org();
                comOrg.Id_Organizacion = io.Id_Organizacion;
                comOrg.Id_Comunidad = pro.Id_Comunidad;
                comOrg.Comunidad = "";
                reg.DB_Registrar_COMU_ORG(comOrg);
                /***********************************/

                /************************************/
                proReg.DA_Registrar_AP_INSCRIPCION_PROD(pro);
            }
            else
            {


                //DA_Persona datper = new DA_Persona();
                //datper.DA_Registrar_PERSONA(per);
                DA_AP_Inscripcion_Prod proReg = new DA_AP_Inscripcion_Prod();
                pro.Id_Campanhia = campanhia;
                pro.Estado = "INSCRITO";
                pro.Id_InscripcionOrg = InscripOrg;
                DA_AP_Registro_Org reg_Org = new DA_AP_Registro_Org();
                String Programa = "";
                String TipoP = "";
                reg_Org.Seleccionar_Prog_DA_AP_INCRIPCION_ORG(InscripOrg, ref Programa, ref TipoP);
                pro.Programa = Programa;
                pro.Tipo_Produccion = TipoP;
                DB_AP_Registro_Prod regP = new DB_AP_Registro_Prod();
                pro.Id_Productor = regP.DB_GeneraCodigo_AP_INSCRIPCION_PRO(campanhia, InscripOrg, Programa);
                /*********************************/
                DB_AP_Organizacion org = new DB_AP_Organizacion();
                AP_InscripcionOrg io = new AP_InscripcionOrg();
                io = org.DB_Buscar_INSCRPCION_ORG(pro.Id_InscripcionOrg);
                DB_AP_Organizacion reg = new DB_AP_Organizacion();
                AP_Comunidad_Org comOrg = new AP_Comunidad_Org();
                comOrg.Id_Organizacion = io.Id_Organizacion;
                comOrg.Id_Comunidad = pro.Id_Comunidad;
                comOrg.Comunidad = "";
                reg.DB_Registrar_COMU_ORG(comOrg);
                /***********************************/

                /************************************/
                proReg.DA_Registrar_AP_INSCRIPCION_PROD(pro);


                men = "Persona Existente..";
            }
            return men;
        }
        #endregion
        #region OBTENER DATOS DE LA RELACION AP_INCRIPCION => PERSONA
        public DataTable DB_BUSCAR_AP_INCRIPCION_PROD_PERSONA(String IdProd, String IdPerCi)
        {
            //VALIDAR DESDE AQUI
            DA_AP_Inscripcion_Prod_Update data = new DA_AP_Inscripcion_Prod_Update();
            return data.DA_BUSCAR_AP_INCRIPCION_PROD_PERSONA(IdProd, IdPerCi);
        }
        #endregion
        #region OBTENER DATOS DE LA RELACION COMUNIDAD=>MUNICIPIO=>PROVINCIA
        public DataTable DB_BUSCAR_COMUNIDAD_MUNICIPIO_PROVINCIA(Int32 IdCom)
        {
            //VALIDAR DESDE AQUI
            DA_AP_Inscripcion_Prod_Update data = new DA_AP_Inscripcion_Prod_Update();
            return data.DA_BUSCAR_COMUNIDAD_MUNICIPIO_PROVINCIA(IdCom);
        }
        #endregion
        #region ACTUALIZAR DATOS AP_INCRIPCION => PERSONA
        public String ACTUALIZAR_DATOS_PERSONA_AP_INS_PRO(Persona per, AP_Productor pro, Int32 campanhia, Int32 InscripOrg)
        {
            String men = "";
            DB_Persona dat = new DB_Persona();
            DA_Persona datper = new DA_Persona();
            datper.DA_Modificar_PERSONA(per);
            DA_AP_Inscripcion_Prod proReg = new DA_AP_Inscripcion_Prod();
            pro.Id_Campanhia = campanhia;
            pro.Estado = "INSCRITO";
            pro.Id_InscripcionOrg = InscripOrg;
            DA_AP_Registro_Org reg_Org = new DA_AP_Registro_Org();
            String Programa = "";
            String TipoP = "";
            reg_Org.Seleccionar_Prog_DA_AP_INCRIPCION_ORG(InscripOrg, ref Programa, ref TipoP);
            pro.Programa = Programa;
            pro.Tipo_Produccion = TipoP;
            proReg.DA_Actualizar_AP_INSCRIPCION_PROD(pro);
            return men;
        }
        #endregion
        #region CONTROLA LOS DATOS DE COORDENADAS
        public String DB_validar_ASIGNAR_COORDENADAS(TextBox TextBoxX, TextBox TextBoxY, ListBox ListNro, ListBox ListCoodX, ListBox ListCoodY)
        {
            String men = "";
            Decimal coodX = 0;
            Decimal coodY = 0;
            if (TextBoxX.Text.Trim() == "")
            {
                men = "Debe registrar una cordenada X";
            }
            else
            {
                try
                {
                    coodX = Convert.ToDecimal(TextBoxX.Text);
                }
                catch
                {
                    men = "error en el formato de fecha de la coordenada X";
                }
            }
            if (TextBoxY.Text.Trim() == "")
            {
                men = "Debe registrar una cordenada Y";
            }
            else
            {
                try
                {
                    coodY = Convert.ToDecimal(TextBoxY.Text);
                }
                catch
                {
                    men = "error en el formato de fecha de la coordenada Y";
                }
            }
            if (men == "")
            {
                ListCoodX.Items.Add(Convert.ToString(TextBoxX.Text));
                ListCoodY.Items.Add(Convert.ToString(TextBoxY.Text));
                ListNro.Items.Add(Convert.ToString(ListCoodY.Items.Count));
            }
            return men;
        }
        #endregion
        #region VALIDA LOS DATOS DEL FORMULARIO frmRegistroDatosTec
        public String DB_validar_REGISTRAR_AP_PLANO_UBICACION_COORDENADAS(TextBox TextBoxParcela, TextBox TextBoxDoc, ListBox ListNro, ListBox ListCoodX, ListBox ListCoodY, String Prod, Int32 idCom)
        {
            String men = "";
            Decimal Parcela;
            Decimal SupDoc;
            if (TextBoxParcela.Text.Trim() == "")
            {
                men = "Debe registrar el numero de parcela correspondiente...";
            }
            else
            {
                try
                {
                    Parcela = Convert.ToDecimal(TextBoxParcela.Text);
                }
                catch
                {
                    men = "Error en el formato de Nro de Parcela";
                }
            }
            if (men == "")
            {
                if (TextBoxDoc.Text.Trim() == "")
                {
                    men = "Debe registrar la Superficie Documento...?";
                }
                else
                {
                    try
                    {
                        SupDoc = Convert.ToDecimal(TextBoxDoc.Text);
                    }
                    catch
                    {
                        men = "Error en el formato de Superficie Documento..";
                    }
                    if (men == "")
                    {
                        if (ListNro.Items.Count >= 0)
                        {
                            DA_AP_Plano_Ubicacion dat = new DA_AP_Plano_Ubicacion();
                            if (dat.DA_Verificar_AP_PLANO_UBICACION(Prod) == false)
                            {
                                AP_PlanoUbicacion UBI = new AP_PlanoUbicacion();
                                DA_AP_Plano_Ubicacion UBI_bd = new DA_AP_Plano_Ubicacion();
                                Int32 idP = dat.DA_SELCCIONA_MAX_CODIGO();
                                UBI.Id_Plano = idP;
                                UBI.Id_Productor = Prod;
                                UBI.Numero_Parcela = Convert.ToInt32(TextBoxParcela.Text);
                                UBI.Superficie_Doc = Convert.ToDecimal(TextBoxDoc.Text);
                                UBI.Superficie_Mensura = 0;
                                UBI.Observacion = "";
                                UBI.Comunidad = idCom;
                                UBI_bd.DA_Registrar_AP_PLANO_UBICACION(UBI);
                                Int32 i = 0;
                                AP_Coordenadas coord = new AP_Coordenadas();
                                DA_AP_Coordenadas coor = new DA_AP_Coordenadas();
                                for (i = 0; i <= ListNro.Items.Count - 1; i++)
                                {
                                    coord.Id_Plano = idP;
                                    coord.Punto = Convert.ToInt32(ListNro.Items[i].Text);
                                    coord.X = Convert.ToString(ListCoodX.Items[i].Text);
                                    coord.Y = Convert.ToString(ListCoodY.Items[i].Text);
                                    coor.DA_Registrar_AP_COORDENADAS(coord);
                                }
                            }
                            else
                            {
                                men = "UBICACION EXISTENTE O REGITRADA CON ANTERIRIDAD...";
                            }
                        }
                        else
                        {
                            men = "debe registrar coordenadas correspondientes";
                        }
                    }
                }
            }
            return men;
        }
        #endregion
    }
}