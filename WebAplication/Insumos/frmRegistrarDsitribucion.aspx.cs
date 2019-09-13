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
using System.Data.SqlClient;
using DataBusiness.DB_Registro;
using DataBusiness.DB_Insumos;
using DataEntity.DE_Insumos;
using DataEntity.DE_Registro;

namespace WebAplication.Insumos
{
    public partial class frmRegistrarDsitribucion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try 
            //{
            if (!IsPostBack)
            {
                LblIdUser.Text = Session["IdUser"].ToString();
                LblIdCamp.Text = Session["IdCamp"].ToString();
                LblIdReg.Text = Session["IdReg"].ToString();
                LblProg.Text = Session["IdProg"].ToString();
                Datos_ENCABEZADO();
//                Calcular_MUESTRA_TECNICO();
                Llenar_LISTA_PROVEEDORES(); 
                Llenar_ORGANIZACIONES_DESIGNADAS();
//                Llenar_GVDESIGNADO();
            }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        #region FUNCIONES DEL COMBO
        protected void Llenar_ORGANIZACIONES_DESIGNADAS()
        {
            DB_AP_InscripcionOrg ListOrg = new DB_AP_InscripcionOrg();
            DataTable dt = new DataTable();
            dt = ListOrg.DB_Desplegar_ORG_REG_CAMP("LISTORGCAMPREG", 0, Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblIdCamp.Text), LblProg.Text);
            DDLOrgAsig.DataSource = dt;
            DDLOrgAsig.DataValueField = "Id_InscripcionOrg";
            DDLOrgAsig.DataTextField = "Personeria_Juridica";
            DDLOrgAsig.DataBind();
        }
        #endregion
        #region FUNCIONES PARA CARGAR LOS DATOS DE LA ORGANIZACION
        private void Datos_ENCABEZADO()
        {
            //DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
            //DataTable dt = new DataTable();
            //dt = Usuario.DB_Desplegar_USUARIO(LblIdUser.Text);
            //LblRegional.Text = dt.Rows[0][5].ToString();
            //LblIdReg.Text = dt.Rows[0][4].ToString();
            //DB_AP_Campanhia camp = new DB_AP_Campanhia();
            //dt = camp.DB_Seleccionar_CAMPANHIA_REG_NOFIN(dt.Rows[0][10].ToString());
            //LblCamp.Text = dt.Rows[0][1].ToString();
            //LblIdCamp.Text = dt.Rows[0][0].ToString();
        }
        #endregion
        #region
        protected void Llenar_LISTA_PROVEEDORES() 
        {
            string[] valor = new string[7];
            valor[0] = "0";
            valor[1] = LblIdCamp.Text;
            valor[2] = LblIdReg.Text;
            valor[3] = DDLInsumo.SelectedItem.Text;
            valor[4] = LblProg.Text;
            valor[5] = "NN";
            valor[6] = "PROV_INSUMO";
            DB_AP_Proveedor prov = new DB_AP_Proveedor();
            DataTable dt = new DataTable();
            dt = prov.DB_Desplegar_PROVEEDOR_PARAMETROS(valor);
            DDLProveedor.DataSource = dt;
            DDLProveedor.DataValueField = "Id_InscripcionProv";
            DDLProveedor.DataTextField = "Razon_Social";
            DDLProveedor.DataBind();
        }
        #endregion
        protected void DDLInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_LISTA_PROVEEDORES();
            Llenar_ORGANIZACIONES_DESIGNADAS();
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
                Import_To_Grid(FilePath, Extension, "No");
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
            BtnCancelar.Visible = true;
        }

        protected void BtnImportar_Click(object sender, EventArgs e)
        {
            Comprovar_valores_GRILLA();
            if (LblMsj.Text == "")
            {
                Registrar_DISTRIBUCION();
            }
        }
        #region FUNCIONES
        protected void Comprovar_valores_GRILLA()
        {
            int j = 0;
            foreach (GridViewRow dgi in GridView1.Rows)
            {
                if (Seleccionar_IDPRODUCTOR(Convert.ToInt32(DDLOrgAsig.SelectedValue), LblProg.Text, GridView1.Rows[j].Cells[8].Text)=="NO")
                {
                    LblMsj.Text = LblMsj.Text + "El productor" + GridView1.Rows[j].Cells[7].Text + " de la Fila: " + (j + 1) + ", No EXISTE en la Organización; " + GridView1.Rows[j].Cells[9].Text + ", <br>";
                }
                j++;
            }
        }

        protected string Seleccionar_IDPRODUCTOR(int idInsOrg, string Prog, string idPersona)
        {
            DB_INS_Distribucion dis = new DB_INS_Distribucion();
            return dis.DB_Seleccionar_IDPRODUCTOR(idInsOrg, Prog, idPersona);
        }
        protected void Registrar_DISTRIBUCION()
        {
            //int tipo = 0;
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            int idDistrib = 0;
            INS_Distribucion disIns = new INS_Distribucion();
            INS_DistribucionDetalle disInsDet = new INS_DistribucionDetalle();
            DB_INS_Distribucion regDist = new DB_INS_Distribucion();

            DB_AP_Incripcion_Prod insprod = new DB_AP_Incripcion_Prod();
            AP_Productor p = new AP_Productor();
            
            disIns.Id_Campanhia = Convert.ToInt32(LblIdCamp.Text);
            disIns.Id_InscripcionOrg = Convert.ToInt32(DDLOrgAsig.SelectedValue);
            disIns.Id_InscripcionProv = Convert.ToInt32(DDLProveedor.SelectedValue);
            disIns.Id_Regional = Convert.ToInt32(LblIdReg.Text);
            disIns.Programa = LblProg.Text;
            disIns.Insumo = DDLInsumo.SelectedItem.Text;
            disIns.Fecha_Registro = DateTime.Now;
            regDist.DB_Registrar_DISTRIBUCION_INSUMO(disIns);
            idDistrib = Convert.ToInt32(aux.DB_MaxId("INS_DISTRIBUCION", "Id_Distribucion"));
            int j = 0;
            foreach (GridViewRow dgi in GridView1.Rows)
            {
                disInsDet.Id_Distribucion = idDistrib;
                disInsDet.Num_Bol_Cartera = Convert.ToInt32(GridView1.Rows[j].Cells[5].Text);
                disInsDet.Id_Productor = Seleccionar_IDPRODUCTOR(Convert.ToInt32(DDLOrgAsig.SelectedValue), LblProg.Text, GridView1.Rows[j].Cells[8].Text);
                p.Id_Productor = disInsDet.Id_Productor;
                p.Has_Ejecutado = Convert.ToDecimal(GridView1.Rows[j].Cells[4].Text);
                insprod.DB_Modificar_SUPEFICIE(p);
                disInsDet.Id_Persona = GridView1.Rows[j].Cells[8].Text;
                disInsDet.Id_Tipo_Insumo = 0;
                disInsDet.Nombre_Insumo = GridView1.Rows[j].Cells[16].Text;
                disInsDet.Unidad = GridView1.Rows[j].Cells[17].Text;
                disInsDet.CantidadDosis = Convert.ToDecimal(GridView1.Rows[j].Cells[18].Text);
                disInsDet.Precio = Convert.ToDecimal(GridView1.Rows[j].Cells[19].Text);
                regDist.DB_Registrar_DISTRIBUCION_DETALLE_INSUMO(disInsDet);
                j++;
            }
        }
        #endregion
    }
}