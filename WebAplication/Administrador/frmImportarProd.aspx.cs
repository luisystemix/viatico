using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;
using DataBusiness.DB_General;
using DataEntity.DE_General;

namespace WebAplication.Administrador
{
    public partial class frmImportarProd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Llenar_DDLRegional();
                Desplegar_REGIONAL();
                Desplegar_CAMPANIA();
                Llenar_DDLOrganizacion();
                Seleccionar_ORG();
            }
            LblMsj.Text = string.Empty;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string FilePath = Server.MapPath(FolderPath + FileName);
                FileUpload1.SaveAs(FilePath);
                //Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text);
                //Import_To_Grid(FilePath, Extension, "No");
                Import_To_Grid(FilePath, Extension, "Yes");
                BtnImportar.BorderColor = System.Drawing.Color.Blue;
                BtnImportar.BorderStyle = BorderStyle.Solid;

            }
        }
        private void Import_To_Grid(string FilePath, string Extension, string isHDR)
        {
            string conStr = "";
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;
                case ".xlsx": //Excel 07
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                    break;
            }
            conStr = String.Format(conStr, FilePath, isHDR);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            //Read Data from First Sheet
            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();

            //Bind Data to GridView
            GridView1.Caption = Path.GetFileName(FilePath);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            BtnImportar.Visible = true;
            //BtnCancelar.Visible = true;
        }

        protected void DDLSigla_SelectedIndexChanged(object sender, EventArgs e)
        {
            Seleccionar_ORG();
            //Limpiar_Grid();
        }
        #region FUNCIONES
        private void Seleccionar_ORG()
        {
            DB_AP_InscripcionOrg Oreg = new DB_AP_InscripcionOrg();
            DataTable dt = new DataTable();
            if (DDLSigla.SelectedValue != "")
            {
                dt = Oreg.DB_Desplegar_ORG_REG_CAMP("SELECT_ORG", Convert.ToInt32(DDLSigla.SelectedValue), Convert.ToInt32(DDLRegional.SelectedValue), Convert.ToInt32(DDLCamp.SelectedValue), DDLPrograma.SelectedValue);
                LblDep.Text = dt.Rows[0][3].ToString();
                LblPersonJuridi.Text = dt.Rows[0][1].ToString();
            }
        }
        private void Desplegar_REGIONAL()
        {
            DB_Regional reg = new DB_Regional();
            DataTable dt = new DataTable();
            dt = reg.DB_Seleccionar_REGIONAL(Convert.ToInt32(DDLRegional.SelectedValue));
            LblRegion.Text = dt.Rows[0][7].ToString();
        }
        #endregion
        #region FUNCION PARA LLENAR EL COMBO REGIONAL
        private void Llenar_DDLRegional()
        {
            DB_Regional reg = new DB_Regional();
            List<Regional> Lista = reg.DB_Desplegar_REGIONAL();
            DDLRegional.DataSource = Lista;
            DDLRegional.DataValueField = "Id_Regional";
            DDLRegional.DataTextField = "Nombre";
            DDLRegional.DataBind();
        }
        #endregion

        #region FUNCION PARA LLENAR EL COMBO CON ORGANIZACION
        private void Llenar_DDLOrganizacion()
        {
            DB_AP_InscripcionOrg Oreg = new DB_AP_InscripcionOrg();
            DataTable dt = new DataTable();
            dt = Oreg.DB_Desplegar_ORG_REG_CAMP("LIST_ORG_IDREG", 0, Convert.ToInt32(DDLRegional.SelectedValue), Convert.ToInt32(DDLCamp.SelectedValue), DDLPrograma.SelectedValue);
            //DDLSigla.Items.Insert(0, new ListItem("Seleccione Organización", "0", true));
            DDLSigla.DataSource = dt;
            DDLSigla.DataValueField = "Id_InscripcionOrg";
            DDLSigla.DataTextField = "Sigla";
            DDLSigla.DataBind();
        }
        #endregion
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Desplegar_CAMPANIA()
        {
            DataTable dt = new DataTable();
            DB_AP_Campanhia camp = new DB_AP_Campanhia();
            dt = camp.DB_Desplegar_CAMPANHIA_REGION(LblRegion.Text);
            DDLCamp.DataSource = dt;
            DDLCamp.DataValueField = "Id_Campanhia";
            DDLCamp.DataTextField = "Nombre";
            DDLCamp.DataBind();
            Seleccionar_ORG();
            Limpiar_Grid();
        }
        #endregion
        #region FUNCIONES DEL COMBO
        protected void DDLRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_REGIONAL();
            Desplegar_CAMPANIA();
            LblIdCamp.Text = DDLCamp.SelectedValue;
            Llenar_DDLOrganizacion();
            Seleccionar_ORG();
            Limpiar_Grid();
        }

        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DDLOrganizacion();
            Seleccionar_ORG();
            Limpiar_Grid();
        }

        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DDLOrganizacion();
            Seleccionar_ORG();
        }
        #endregion
        #region FUNCION PARA REGISTRAR LA IMPORTACION

        protected void Registrar_COMU_ORG(int IdComunidad)
        {
            DB_AP_Organizacion org = new DB_AP_Organizacion();
            AP_InscripcionOrg io = new AP_InscripcionOrg();
            io = org.DB_Buscar_INSCRPCION_ORG(Convert.ToInt32(DDLSigla.SelectedValue));
            DB_AP_Organizacion reg = new DB_AP_Organizacion();
            AP_Comunidad_Org comOrg = new AP_Comunidad_Org();
            comOrg.Id_Organizacion = io.Id_Organizacion;
            comOrg.Id_Comunidad = IdComunidad;
            comOrg.Comunidad = "";
            reg.DB_Registrar_COMU_ORG(comOrg);
        }
        protected void Registrar_PERSONA(Persona p)
        {
            DB_Persona pe = new DB_Persona();
            pe.DB_Registrar_PERSONA(p);
        }
        protected void Registrar_INSCRIP_PRODUCTOR(AP_Productor p)
        {
            DB_AP_Incripcion_Prod proReg = new DB_AP_Incripcion_Prod();
            proReg.DB_Registrar_AP_INSCRIPCION_PROD(p);
        }
        protected void BtnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                DB_AP_Comunidad busc = new DB_AP_Comunidad();
                DB_AP_Registro_Prod regP = new DB_AP_Registro_Prod();
                DataTable dt = new DataTable();
                int i = 0;
                foreach (GridViewRow dgi in GridView1.Rows)
                {
                    if (GridView1.Rows[i].Cells[0].Text == "&nbsp;")//lrojas: si hay espacios se salta
                        break;
                    //****
                    //if (GridView1.Rows[i].Cells[1].Text == "&nbsp;")
                    //    break;
                    //if (GridView1.Rows[i].Cells[6].Text == "&nbsp;")
                    //   break;

                    if (DDLSigla.SelectedValue == string.Empty)
                    {
                        LblMsj.Text = "SELECCIONE ORGANIZACIÓN SEGÚN PROGRAMA.";
                        return;
                    }
                    //**
                    if (GridView1.Rows[i].Cells[9].Text == "&nbsp;")
                    {
                        string auxiliar = GridView1.Rows[i].Cells[6].Text+ GridView1.Rows[i].Cells[7].Text + GridView1.Rows[i].Cells[8].Text;
                        //ingresar ci con extencion manualmente
                    }
                    //**
                    ////if (GridView1.Rows[i].Cells[2].Text != DDLSigla.SelectedItem.Text)
                    //if (GridView1.Rows[i].Cells[5].Text != DDLSigla.SelectedItem.Text)//NOMBRE COMUNIDAD
                    //{
                    //    //string nombre = GridView1.Rows[i].Cells[3].Text + " "+ GridView1.Rows[i].Cells[4].Text + " " + GridView1.Rows[i].Cells[5].Text;
                    //    string nombre = GridView1.Rows[i].Cells[6].Text + " " + GridView1.Rows[i].Cells[7].Text + " " + GridView1.Rows[i].Cells[8].Text;
                    //    LblMsj.Text = "LA ORGANIZACIÓN SELECCIONADA NO CONCUERDA CON LA DEL ARCHIVO (NOMBRE_COMUNIDAD). \n Productor: " + nombre;
                    //    return;
                    //}

                    /********************* VERIFICAR SI LA ORGANIZACION ES PARTE DE ESTA COMUIDAD ***********************/
                    //dt = busc.DB_Buscar_COMU_ORG(Convert.ToInt32(DDLSigla.SelectedValue), Convert.ToInt32(GridView1.Rows[i].Cells[1].Text), "0", "COMU_ORG");
                    dt = busc.DB_Buscar_COMU_ORG(Convert.ToInt32(DDLSigla.SelectedValue), Convert.ToInt32(GridView1.Rows[i].Cells[5].Text), "0", "COMU_ORG"); //
                    if (dt.Rows.Count <= 0)
                    {
                        //Registrar_COMU_ORG(Convert.ToInt32(GridView1.Rows[i].Cells[1].Text));
                        Registrar_COMU_ORG(Convert.ToInt32(GridView1.Rows[i].Cells[5].Text));
                    }
                    /************************** BUSCA PERSONA  *********************************/
                    //dt = busc.DB_Buscar_COMU_ORG(Convert.ToInt32(DDLSigla.SelectedValue), 0, GridView1.Rows[i].Cells[6].Text, "PERSONA");
                    dt = busc.DB_Buscar_COMU_ORG(Convert.ToInt32(DDLSigla.SelectedValue), 0, GridView1.Rows[i].Cells[9].Text, "PERSONA");// 9 CI
                    if (dt.Rows.Count <= 0)
                    {
                        Persona p = new Persona();
                        /*p.Id_Persona = GridView1.Rows[i].Cells[6].Text;
                        p.ci = GridView1.Rows[i].Cells[6].Text;
                        p.ext = GridView1.Rows[i].Cells[7].Text;
                        p.Nombres = GridView1.Rows[i].Cells[3].Text;
                        p.Primer_ap = GridView1.Rows[i].Cells[4].Text;
                        p.Segundo_ap = GridView1.Rows[i].Cells[5].Text;*/
                        p.Id_Persona = GridView1.Rows[i].Cells[9].Text;//CI
                        p.ci = GridView1.Rows[i].Cells[9].Text;//CI
                        p.ext = GridView1.Rows[i].Cells[10].Text;//EXT_CI
                        p.Nombres = GridView1.Rows[i].Cells[6].Text;//NOMBRE
                        p.Primer_ap = GridView1.Rows[i].Cells[7].Text;//AP_PATERNO
                        p.Segundo_ap = GridView1.Rows[i].Cells[8].Text;//AP_MATERNO

                        p.Fecha_nacimiento = Convert.ToDateTime("01/01/1900");
                        p.Sexo = true;
                        p.Telef_fijo = "";
                        p.Telef_cel = "";
                        p.Fecha_registro = DateTime.Now;
                        p.Estado = "INSCRITO";
                        Registrar_PERSONA(p);
                    }
                    /******************** busca productor *******************/
                    //dt = busc.DB_Buscar_COMU_ORG(Convert.ToInt32(DDLSigla.SelectedValue), 0, GridView1.Rows[i].Cells[6].Text, "PRODUCTOR");
                    dt = busc.DB_Buscar_COMU_ORG(Convert.ToInt32(DDLSigla.SelectedValue), 0, GridView1.Rows[i].Cells[9].Text, "PRODUCTOR");
                    if (dt.Rows.Count <= 0)
                    {
                        AP_Productor pr = new AP_Productor();
                        /*pr.Id_Productor = regP.DB_GeneraCodigo_AP_INSCRIPCION_PRO(Convert.ToInt32(DDLCamp.SelectedValue), Convert.ToInt32(DDLSigla.SelectedValue), DDLPrograma.SelectedValue);
                        pr.Id_Persona = GridView1.Rows[i].Cells[6].Text;
                        pr.Id_Comunidad = Convert.ToInt32(GridView1.Rows[i].Cells[1].Text);
                        pr.Id_InscripcionOrg = Convert.ToInt32(DDLSigla.SelectedValue);
                        pr.Id_Campanhia = Convert.ToInt32(DDLCamp.SelectedValue);
                        pr.Programa = DDLPrograma.SelectedValue;
                        pr.Tipo_Inscripcion = "Beneficiario";
                        pr.Tipo_Produccion = "PEQUEÑO";
                        pr.Has_Inscrito = Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text);
                        pr.Has_Ejecutado = Convert.ToDecimal(0);
                        pr.Has_Propio = Convert.ToDecimal(0);
                        pr.Rau = 0;
                        pr.Estado = "INSCRITO";
                        pr.Observacion = "";*/
                        pr.Id_Productor = regP.DB_GeneraCodigo_AP_INSCRIPCION_PRO(Convert.ToInt32(DDLCamp.SelectedValue), Convert.ToInt32(DDLSigla.SelectedValue), DDLPrograma.SelectedValue);
                        pr.Id_Persona = GridView1.Rows[i].Cells[9].Text;//ci
                        pr.Id_Comunidad = Convert.ToInt32(GridView1.Rows[i].Cells[5].Text);//idcomunidad
                        pr.Id_InscripcionOrg = Convert.ToInt32(DDLSigla.SelectedValue);
                        pr.Id_Campanhia = Convert.ToInt32(DDLCamp.SelectedValue);
                        pr.Programa = DDLPrograma.SelectedValue;
                        pr.Tipo_Inscripcion = "Beneficiario";
                        pr.Tipo_Produccion = "PEQUEÑO";
                        pr.Has_Inscrito = Convert.ToDecimal(GridView1.Rows[i].Cells[11].Text);//hectareas inscritas
                        pr.Has_Ejecutado = Convert.ToDecimal(0);
                        pr.Has_Propio = Convert.ToDecimal(0);
                        pr.Rau = 0;
                        pr.Estado = "INSCRITO";
                        pr.Observacion = "";
                        //**nuevos
                        pr.Departamento = LblDep.Text;
                        pr.Id_Provincia = Convert.ToInt32(GridView1.Rows[i].Cells[2].Text);//id_provincia
                        pr.Id_Municipio = Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);//id_municipio
                        pr.Id_Organizacion = Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);//id_organizacion
                        pr.Id_Credito = GridView1.Rows[i].Cells[0].Text;//id_credito
                        //**
                        Registrar_INSCRIP_PRODUCTOR(pr);
                    }
                    i++;
                }
                if (GridView1.Rows.Count == 0)
                {
                    LblMsj.Text = "SIN DATOS DE IMPORTACIÓN";
                }
                else
                {
                    LblMsj.Text = "IMPORTACIÓN CONCLUIDA CON EXITO";
                }
            }
            catch (Exception ex)
            {

                LblMsj.Text = ex.Message;
                //string script = @"<script type='text/javascript'>alert('{0}');</script>";
                //script = string.Format(script, ex.Message);
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        #endregion
        #region FUNCIONES DE VERIFICACION
        private void Buscar_PERSONA()
        {

        }
        private void Buscar_INCRIPTPROD()
        {

        }
        private void Buscar_IDCOMU_ORG()
        {

        }
        protected void BtnVerificar_Click(object sender, EventArgs e)
        {
            DB_AP_Comunidad busc = new DB_AP_Comunidad();
            DB_AP_Registro_Prod regP = new DB_AP_Registro_Prod();
            DataTable dt = new DataTable();
            int i = 0;

            Label1.Text = regP.DB_GeneraCodigo_AP_INSCRIPCION_PRO(Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(DDLSigla.SelectedValue), DDLPrograma.SelectedValue);
            foreach (GridViewRow dgi in GridView1.Rows)
            {
                dt = busc.DB_Buscar_COMU_ORG(Convert.ToInt32(DDLSigla.SelectedValue), Convert.ToInt32(GridView1.Rows[i].Cells[1].Text), "0", "COMU_ORG");
                if (dt.Rows.Count > 0)
                {
                    LblMsj.Text = "EXISTE LA COMUNIDAD " + GridView1.Rows[i].Cells[2].Text;
                }
                else
                {
                    /************************** BUSCA PERSONA  *********************************/
                    dt = busc.DB_Buscar_COMU_ORG(Convert.ToInt32(DDLSigla.SelectedValue), 0, GridView1.Rows[i].Cells[6].Text, "PERSONA");
                    if (dt.Rows.Count > 0)
                    {
                        LblMsj.Text = LblMsj.Text + " --- " + "EXISTE LA PERSONA " + GridView1.Rows[i].Cells[4].Text + " " + GridView1.Rows[i].Cells[5].Text + "Con cedula de identidad: " + GridView1.Rows[i].Cells[6].Text;
                    }
                    else
                    {
                        /******************** busca productor *******************/
                        dt = busc.DB_Buscar_COMU_ORG(Convert.ToInt32(DDLSigla.SelectedValue), 0, GridView1.Rows[i].Cells[6].Text, "PRODUCTOR");
                        if (dt.Rows.Count > 0)
                        {
                            LblMsj.Text = LblMsj.Text + " --- " + "EXISTE EL PRODUCTOR DE NOMBRE" + GridView1.Rows[i].Cells[4].Text + " " + GridView1.Rows[i].Cells[5].Text + " Con cedula de identidad: " + GridView1.Rows[i].Cells[6].Text;
                        }
                        else
                        {
                            BtnImportar.Enabled = false;
                        }
                    }
                }
                i++;
            }
        }
        protected void Limpiar_Grid()
        {
            DataTable dt = new DataTable();
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        #endregion
    }
}