using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;
using DataBusiness.DB_General;
using DataEntity.DE_Extensiones;
using DataBusiness.DB_Extensiones;

namespace WebAplication.Extensiones
{
    public partial class frmSeleccionarProd : System.Web.UI.Page
    {
        private string Contador
        {
            get
            {
                if (ViewState["Contador"] != null)
                    return (string)ViewState["Contador"];

                return string.Empty;
            }
            set { ViewState["Contador"] = value; }
        }
        private bool CambiosCBXEstado
        {
            get
            {
                if (ViewState["CambiosCBXEstado"] != null)
                    return (bool)ViewState["CambiosCBXEstado"];

                return false;
            }
            set { ViewState["CambiosCBXEstado"] = value; }
        }
        private int before_DDLOrgAsig
        {
            get
            {
                if (ViewState["before_DDLOrgAsig"] != null)
                    return (int)ViewState["before_DDLOrgAsig"];

                return -1;
            }
            set { ViewState["before_DDLOrgAsig"] = value; }
        }
        /// <summary>
        /// Coleccion Producotores Seleccionados por Organizacion
        /// </summary>       
        public IList<EXT_DesignacionProd> ColDesigProductores
        {
            get
            {
                if (ViewState["ColDesigProductores"] != null)
                    return (IList<EXT_DesignacionProd>)ViewState["ColDesigProductores"];
                else
                    return new List<EXT_DesignacionProd>();
            }
            set
            {
                ViewState["ColDesigProductores"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    Datos_ENCABEZADO();
                    Calcular_MUESTRA_TECNICO();//lrojas: 08/07/2017 aqui se controla la cantidad de productores permitidos
                    Llenar_ORGANIZACIONES_DESIGNADAS();
                    Llenar_GVDESIGNADO();

                    // lrojas: solo se muestra para occidente el control se lo realiza en CBXEstado_CheckedChanged
                    DB_AP_Registro_Org d_org = new DB_AP_Registro_Org();
                    DataTable dt = new DataTable();
                    string iduser = Session["IdUser"].ToString();
                    dt = d_org.DB_Desplegar_USUARIO(iduser);
                    string region = dt.Rows[0]["Region"].ToString();
                    //foreach (DataRow fila in dt.Rows)
                    //{
                    //    region = fila["Region"].ToString();
                    //}                   
                    if (region == "ORIENTE") 
                    {
                        bool visible = false;
                        LblMsj.Visible = visible;
                        LblContador.Visible = visible;
                        LblMaximo.Visible = visible;
                    }
                    else//OCCIDENTE CONTROLA LOS 20 productores
                    {
                        bool visible = true;
                        LblMsj.Visible = visible;
                        LblContador.Visible = visible;
                        LblMaximo.Visible = visible;
                    }
                    //Random();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCIONES PARA CARGAR LOS DATOS DE LA ORGANIZACION
        private void Datos_ENCABEZADO()
        {
            DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = Usuario.DB_Desplegar_USUARIO(LblIdUsuario.Text);
            LblRegional.Text = dt.Rows[0][5].ToString();
            LblIdReg.Text = dt.Rows[0][4].ToString();
            DB_AP_Campanhia camp = new DB_AP_Campanhia();
            dt = camp.DB_Seleccionar_CAMPANHIA_REG_NOFIN(dt.Rows[0][10].ToString());
            LblCamp.Text = dt.Rows[0][1].ToString();
            LblIdCamp.Text = dt.Rows[0][0].ToString();

        }
        #endregion
        #region
        private void Calcular_MUESTRA_TECNICO()
        {
            try
            {
                DB_EXT_DesignacionOrg ListDesOrg = new DB_EXT_DesignacionOrg();
                DataTable dt = new DataTable();
                //dt = ListDesOrg.DB_Seleccionar_DESIGNACION_ORG(0, 0,LblIdUsuario.Text, "", "MUESTRA_PROD");                        
                //if(dt.Rows.Count > 0)
                //{
                //    LblMaximo.Text = dt.Rows[0][3].ToString();
                //    LblMsj.Text = "Tiene: " + LblMaximo.Text + " productores o mas para seleccionar, segun la muestra valida";
                //}
                //else
                //{
                //    LblMaximo.Text = "0";
                //    LblMsj.Text = "Por el momento no se selecciono productores para su seguimiento";
                //}
                //**luis.rojas
                //lrojas: control cantidad de productores
                DB_AP_Registro_Org d_org = new DB_AP_Registro_Org();
                DataTable dt_dat_user = new DataTable();
                string iduser = Session["IdUser"].ToString();
                dt_dat_user = d_org.DB_Desplegar_USUARIO(iduser);
                string region = dt_dat_user.Rows[0]["Region"].ToString();
                string maximopermitido = "";
                //foreach (DataRow fila in dt.Rows)
                //{
                //    region = fila["Region"].ToString();
                //}
                //NO controla cantidad de productores por eso se puso un valor alto para que las validaciones en CBXEstado_CheckedChanged no cambie
                if (region == "ORIENTE")
                {
                    maximopermitido = "10000";
                }
                else//OCCIDENTE CONTROLA LOS 20 productores
                {
                    maximopermitido = "20";
                }
                dt = ListDesOrg.DB_Seleccionar_DESIGNACION_PROD_ORG_CONSULTAS(Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblIdCamp.Text), LblIdUsuario.Text, DDLPrograma.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    LblMsj.Text = "Productores Seleccionados, segun la muestra valida";
                    //LblMaximo.Text = "20";
                    LblMaximo.Text = maximopermitido;
                    //LblContador.Text = dt.Rows.Count.ToString();
                    var dtaux = dt.AsEnumerable().Where(x => x.Field<string>("Id_Usuario") == LblIdUsuario.Text).ToList();
                    int count = dtaux.Count;
                    //foreach (DataRow dtRow in dt.Rows)
                    //{
                    //    if (dtRow["Id_Usuario"].ToString() == LblIdUsuario.Text)
                    //    {
                    //        count++;
                    //    }
                    //}
                    LblContador.Text = Convert.ToString(count);
                    Contador = Convert.ToString(count);
                }
                else
                {
                    LblContador.Text = "0";
                    //LblMaximo.Text = "20";
                    LblMaximo.Text = maximopermitido;
                    LblMsj.Text = "Por el momento no se selecciono productores para su seguimiento";
                    //**
                    //if (dt.Rows.Count == 0)
                    //{
                    //    Random();
                    //}
                    //**
                }
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }

        }
        #endregion
        #region FUNCIONES DE LA GRILLA
        private void Llenar_GVDESIGNADO()
        {
            if (DDLOrgAsig.SelectedValue != "")
            {
                DB_EXT_DesignacionProd ListDes = new DB_EXT_DesignacionProd();
                GVDesignadoProd.DataSource = ListDes.DB_Desplegar_DESIGNACION_PROD(LblIdUsuario.Text, Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), DDLPrograma.SelectedValue, Convert.ToInt32(DDLOrgAsig.SelectedValue), "LIST_SELECCION");
            }
            GVDesignadoProd.DataBind();
        }
        #endregion
        #region FUNCIONES DEL COMBO
        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Calcular_MUESTRA_TECNICO();
                Llenar_ORGANIZACIONES_DESIGNADAS();
                Llenar_GVDESIGNADO();
                //**
                //Random();
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }

        }
        #endregion
        #region FUNCIONES DEL COMBO
        protected void Llenar_ORGANIZACIONES_DESIGNADAS()
        {
            DB_EXT_DesignacionOrg desigorg = new DB_EXT_DesignacionOrg();
            DataTable dt = new DataTable();
            dt = desigorg.DB_Seleccionar_DESIGNACION_ORG(Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblIdCamp.Text), LblIdUsuario.Text, DDLPrograma.SelectedValue, "MUESTRA_PROD");
            DDLOrgAsig.DataSource = dt;
            DDLOrgAsig.DataValueField = "Id_InscripcionOrg";
            DDLOrgAsig.DataTextField = "Personeria_Juridica";
            DDLOrgAsig.DataBind();
        }
        #endregion
        #region FUNCION PARA REGISTRAR LOS PRODUCTORES SELECCIONADOS
        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(LblContador.Text) <= Convert.ToInt32(LblMaximo.Text))
                {
                    DB_EXT_DesignacionProd Ins = new DB_EXT_DesignacionProd();
                    EXT_DesignacionProd dp = new EXT_DesignacionProd();
                    CheckBox myCheckBox = new CheckBox();
                    int i = 0;
                    string aux = "";
                    //foreach (GridViewRow dgi in GVDesignadoProd.Rows)
                    //{
                    //    aux = GVDesignadoProd.Rows[i].Cells[9].Text;
                    //    if (aux == "&nbsp;")
                    //    {
                    //        myCheckBox = (CheckBox)dgi.Cells[10].Controls[1];
                    //        GVDesignadoProd.Columns[8].Visible = true;
                    //        Llenar_GVDESIGNADO();
                    //        Calcular_MUESTRA_TECNICO();//luis.rojas
                    //        dp.Id_Usuario = LblIdUsuario.Text;
                    //        dp.Id_Productor = GVDesignadoProd.Rows[i].Cells[8].Text;
                    //        dp.Estado = myCheckBox.Checked;
                    //        if (myCheckBox.Checked == true)
                    //        {   // ni no esxiste lo inserta
                    //            dp.Etapa = "VERIFICACION_PARCELA";
                    //            Ins.DB_Registrar_DESIGNACION_PROD(dp);
                    //        }
                    //        else
                    //        {   //
                    //            dp.Etapa = "VERIFICACION_PARCELA";
                    //            Ins.DB_Registrar_DESIGNACION_PROD(dp);
                    //        }

                    //    }
                    //    i++;
                    //}
                    //************************************************
                    foreach (EXT_DesignacionProd row in ColDesigProductores)
                    {
                        //si existe lo elimina sino lo crea
                        Ins.DB_Registrar_DESIGNACION_PROD(row);
                    }
                    Llenar_GVDESIGNADO();
                    Calcular_MUESTRA_TECNICO();//luis.rojas
                    ColDesigProductores = new List<EXT_DesignacionProd>();

                }
                else
                {
                    LblMsj.Text = "No se puede registrar porque esta fuera del rango de la muestra";
                }
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('{0}');</script>";
                script = string.Format(script, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }

        }
        #endregion

        protected void CBXEstado_CheckedChanged(object sender, EventArgs e)
        {
            int aux = 0;
            int index = 0;
            GridViewRow rowSelect = ((GridViewRow)((CheckBox)sender).NamingContainer);
            index = rowSelect.RowIndex;
            //LblContador.Text = "0";
            GridViewRow row = GVDesignadoProd.Rows[index];
            CheckBox chec = (CheckBox)row.FindControl("CBXEstado");
            if (chec.Checked == true)
            {
                if (Convert.ToInt32(LblContador.Text) < Convert.ToInt32(LblMaximo.Text))
                {
                    LblContador.Text = Convert.ToString(Convert.ToInt32(LblContador.Text) + 1);
                    CambiosCBXEstado = true;
                    EXT_DesignacionProd ObjDesigprod = new EXT_DesignacionProd();
                    ObjDesigprod.Id_Usuario = LblIdUsuario.Text;
                    ObjDesigprod.Id_Productor = row.Cells[8].Text;
                    ObjDesigprod.Estado = chec.Checked;
                    ObjDesigprod.Etapa = "VERIFICACION_PARCELA";
                    if (ColDesigProductores.Count == 0)
                    {
                        IList<EXT_DesignacionProd> Col = new List<EXT_DesignacionProd>();
                        ColDesigProductores = Col;
                    }
                    EXT_DesignacionProd ObjDP = ColDesigProductores.Where
                                                                            (x => x.Id_Usuario == ObjDesigprod.Id_Usuario &&
                                                                                  x.Id_Productor == ObjDesigprod.Id_Productor &&
                                                                                  x.Etapa == ObjDesigprod.Etapa).SingleOrDefault();

                    if (ObjDP == null)
                    {
                        ColDesigProductores.Add(ObjDesigprod);
                    }

                }
                else
                {
                    aux = 1;
                    LblMsj.Text = "Ya llego al màximo de productores seleccionados segùn la muestra ";// + LblMaximo.Text;
                    chec.Checked = false;
                }
            }
            else
            {
                LblContador.Text = Convert.ToString(Convert.ToInt32(LblContador.Text) - 1);
                CambiosCBXEstado = true;
                EXT_DesignacionProd ObjDesigprod = new EXT_DesignacionProd();
                ObjDesigprod.Id_Usuario = LblIdUsuario.Text;
                ObjDesigprod.Id_Productor = row.Cells[8].Text;
                ObjDesigprod.Estado = chec.Checked;
                ObjDesigprod.Etapa = "VERIFICACION_PARCELA";
                if (ColDesigProductores.Count == 0)
                {
                    IList<EXT_DesignacionProd> Col = new List<EXT_DesignacionProd>();
                    ColDesigProductores = Col;
                }
                EXT_DesignacionProd ObjDP = ColDesigProductores.Where(x => x.Id_Usuario == ObjDesigprod.Id_Usuario &&
                                                                           x.Id_Productor == ObjDesigprod.Id_Productor &&
                                                                           x.Etapa == ObjDesigprod.Etapa).SingleOrDefault();
                if (ObjDP != null)
                {
                    //ObjDesigprod.Estado = true;
                    ColDesigProductores.Remove(ObjDP);
                }
                else
                    ColDesigProductores.Add(ObjDesigprod);
            }
        }

        protected void GVDesignadoProd_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string aux = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Estado"));
                if (aux != "")
                {
                    bool valor = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Estado"));
                    if (valor == true)
                    {
                        ((CheckBox)e.Row.FindControl("CBXEstado")).Checked = true;
                        //((CheckBox)e.Row.FindControl("CBXEstado")).Enabled = false;
                    }
                    //if (valor == false)
                    //{
                    //    ((CheckBox)e.Row.FindControl("CBXEstado")).Checked = false;
                    //}
                }
                else
                {

                }
            }
            //** inicia con el grid deshabilitado
            Checked_Enabled_GVDesignadoProd(false);
        }

        protected void ImgBtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("Prog", DDLPrograma.SelectedValue);
            Session.Add("IdUser", LblIdUsuario.Text);
            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repProdSeleccionados.aspx?ci=" + LblIdReg.Text);
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
        }

        protected void DDLOrgAsig_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (CambiosCBXEstado)
            if (ColDesigProductores.Count > 0)
            {
                DDLOrgAsig.SelectedIndex = before_DDLOrgAsig;
                lblMesajeOrganizacion.Text = "Se producieron cambios con productores seleccionados presione CANCELAR para omitir los cambios";
                //string script = @"<script type='text/javascript'>alert('{0}');</script>";
                //script = string.Format(script, "Se producieron cambios con productores seleccionados en_ \n" + before_DDLOrgAsig + "\n Seleccione CANCELAR para omitir los cambios");
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
            else
            {
                Llenar_GVDESIGNADO();
                lblMesajeOrganizacion.Text = string.Empty;
            }

        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("../About.aspx");
            Llenar_GVDESIGNADO();
            Calcular_MUESTRA_TECNICO();
            CambiosCBXEstado = false;
            lblMesajeOrganizacion.Text = string.Empty;
            ColDesigProductores = new List<EXT_DesignacionProd>();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void GVDesignadoProd_PreRender(object sender, EventArgs e)
        {
            if (GVDesignadoProd.Rows.Count > 0)
            {
                GVDesignadoProd.UseAccessibleHeader = true;
                GVDesignadoProd.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void DDLOrgAsig_PreRender(object sender, EventArgs e)
        {
            if (DDLOrgAsig.SelectedIndex != -1)
                before_DDLOrgAsig = DDLOrgAsig.SelectedIndex;
        }

        protected void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox showCheckBox = (CheckBox)sender;
            if (showCheckBox.Checked)
            {
                Checked_Enabled_GVDesignadoProd(true);
            }
            else
            {
                Checked_Enabled_GVDesignadoProd(false);
            }
        }
        protected void Checked_Enabled_GVDesignadoProd(bool flag)
        {
            if (flag == true)
            {
                foreach (GridViewRow row in GVDesignadoProd.Rows)
                {
                    CheckBox chkEstado = (CheckBox)row.FindControl("CBXEstado");
                    string aux = row.Cells[9].Text;
                    if (LblIdUsuario.Text == aux)
                    {
                        if (chkEstado.Checked == true)
                        {
                            //chkEstado.Enabled = flag;
                            string Etapa = row.Cells[11].Text;
                            if (Etapa == "VERIFICACION_PARCELA")
                            {
                                chkEstado.Enabled = flag;
                            }
                            else
                            {
                                if (Etapa == "1")
                                {
                                    chkEstado.Enabled = flag;
                                }
                            } 
                        }
                        else
                        { chkEstado.Enabled = flag; }
                    }
                    else
                    {
                        if (chkEstado.Checked == true)
                        { 
                           // chkEstado.Enabled = !flag;
                            string Etapa = row.Cells[11].Text;
                            if (Etapa == "VERIFICACION_PARCELA")
                            {
                                chkEstado.Enabled = !flag;
                            }
                            else
                            {
                                if (Etapa == "1")
                                {
                                    chkEstado.Enabled = !flag;
                                }
                            } 
                        }
                        else
                        { chkEstado.Enabled = flag; }
                    }


                }
            }
            else
            {
                foreach (GridViewRow row in GVDesignadoProd.Rows)
                {
                    CheckBox chkEstado = (CheckBox)row.FindControl("CBXEstado");
                    chkEstado.Enabled = flag;
                }
            }
        }
        /// <summary>
        /// Seleccion Aleatoria de Productores a Tecnicos, solo la promera vez
        /// </summary>
        private void Random()
        {
            //List<int> numeros = new List<int>();
            //Random rnumero = new Random();
            //while (numeros.Count<12)// 20
            //{
            //    int num = rnumero.Next(1, 30); //números aleatorios entre 1 y 30
            //    if (!numeros.Any(x => x == num))// verificamos números repetidos
            //    {
            //        numeros.Add(num);
            //    }
            //}
            DataTable dtAll = new DataTable();
            dtAll.Columns.Add("Personeria_Juridica");
            dtAll.Columns.Add("Productor");
            dtAll.Columns.Add("ci");
            dtAll.Columns.Add("Comunidad");
            dtAll.Columns.Add("Municipio");
            dtAll.Columns.Add("Provincia");
            dtAll.Columns.Add("Tipo_Produccion");
            dtAll.Columns.Add("Has_Inscrito");
            dtAll.Columns.Add("Id_Productor");
            dtAll.Columns.Add("Id_Usuario");
            dtAll.Columns.Add("Estado");            
            //0 muestra de tecnico
            DB_EXT_DesignacionOrg ListDesOrg = new DB_EXT_DesignacionOrg();
            DataTable dt0 = new DataTable();
            
            dt0 = ListDesOrg.DB_Seleccionar_DESIGNACION_PROD_ORG_CONSULTAS(Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblIdCamp.Text), LblIdUsuario.Text, DDLPrograma.SelectedValue);
            if (dt0.Rows.Count > 0)
            {
                //LblMsj.Text = "Productores Seleccionados, segun la muestra valida";
                //LblMaximo.Text = "20";                
                var dtaux = dt0.AsEnumerable().Where(x => x.Field<string>("Id_Usuario") == LblIdUsuario.Text).ToList();
                int count = dtaux.Count;               
                //LblContador.Text = Convert.ToString(count);
                //Contador = Convert.ToString(count);
                if (count == 0)
                {
                    //1 organizacion segun programa
                    DB_EXT_DesignacionOrg desigorg = new DB_EXT_DesignacionOrg();
                    DB_EXT_DesignacionProd ListDes = new DB_EXT_DesignacionProd();
                    DataTable dt1 = new DataTable();
                    DataTable dt2 = new DataTable();
                    dt1 = desigorg.DB_Seleccionar_DESIGNACION_ORG(Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblIdCamp.Text), LblIdUsuario.Text, DDLPrograma.SelectedValue, "MUESTRA_PROD");                   
                    //2 llenamos todos los productores de las organizaciones que tenga asignado el usuario
                    foreach (DataRow row in dt1.Rows)
                    {
                        string idOrg = row["Id_InscripcionOrg"].ToString();
                        dt2 = ListDes.DB_Desplegar_DESIGNACION_PROD(LblIdUsuario.Text, Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), DDLPrograma.SelectedValue, Convert.ToInt32(idOrg), "LIST_SELECCION");
                        foreach (DataRow row2 in dt2.Rows)
                        {
                            DataRow fila = dtAll.NewRow();
                            fila["Personeria_Juridica"] = row2["Personeria_Juridica"].ToString();
                            fila["Productor"] = row2["Productor"].ToString();
                            fila["ci"] = row2["ci"].ToString();
                            fila["Comunidad"] = row2["Comunidad"].ToString();
                            fila["Municipio"] = row2["Municipio"].ToString();
                            fila["Provincia"] = row2["Provincia"].ToString();
                            fila["Tipo_Produccion"] = row2["Tipo_Produccion"].ToString();
                            fila["Has_Inscrito"] = row2["Has_Inscrito"].ToString();
                            fila["Id_Productor"] = row2["Id_Productor"].ToString();
                            fila["Id_Usuario"] = row2["Id_Usuario"].ToString();
                            fila["Estado"] = row2["Estado"].ToString();
                            dtAll.Rows.Add(fila);
                        }                  
                    }
                    int total = dtAll.Rows.Count;
                    List<int> numeros = new List<int>();
                    Random rnumero = new Random();
                    int cc = 0;
                    while (numeros.Count < 20)// se asigna maximo 20 productores por tecnico entre todas sus organizaciones asignadas
                    {                        
                        int num = rnumero.Next(1, total); //números aleatorios entre 1 y 30
                        if (!numeros.Any(x => x == num))// verificamos números repetidos
                        {
                            numeros.Add(num);
                            cc++;
                            int index = num;
                            DataRow rowq = dtAll.Rows[index];
                            string iduser = rowq["Id_Usuario"].ToString();
                            if (iduser == string.Empty)
                            {
                                EXT_DesignacionProd ObjDesigprod = new EXT_DesignacionProd();
                                ObjDesigprod.Id_Usuario = LblIdUsuario.Text;
                                ObjDesigprod.Id_Productor = rowq["Id_Productor"].ToString();
                                //ObjDesigprod.Estado = chec.Checked;
                                ObjDesigprod.Estado = true;
                                ObjDesigprod.Etapa = "VERIFICACION_PARCELA";
                                if (ColDesigProductores.Count == 0)
                                {
                                    IList<EXT_DesignacionProd> Col = new List<EXT_DesignacionProd>();
                                    ColDesigProductores = Col;
                                }
                                EXT_DesignacionProd ObjDP = ColDesigProductores.Where(x => x.Id_Usuario == ObjDesigprod.Id_Usuario &&
                                                                                           x.Id_Productor == ObjDesigprod.Id_Productor &&
                                                                                           x.Etapa == ObjDesigprod.Etapa).SingleOrDefault();
                                if (ObjDP == null)
                                {
                                    ColDesigProductores.Add(ObjDesigprod);
                                }
                                else
                                {
                                    numeros.Remove(num);
                                }

                            }
                            else
                            {
                                numeros.Remove(num);
                            }
                             
                     }
                }
                DB_EXT_DesignacionProd Ins = new DB_EXT_DesignacionProd();
                foreach (EXT_DesignacionProd row in ColDesigProductores)
                {
                        //si existe lo elimina sino lo crea
                      Ins.DB_Registrar_DESIGNACION_PROD(row);
                }
                Llenar_GVDESIGNADO();
                Calcular_MUESTRA_TECNICO();//luis.rojas
                ColDesigProductores = new List<EXT_DesignacionProd>();
            }
                
         }            
       }
    }
}