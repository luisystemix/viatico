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

namespace WebAplication.Insumos
{
    public partial class frmRegistrarPropuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdInsProv.Text = Session["IdInsProv"].ToString();
                    LblIdUser.Text = Session["IdUser"].ToString();
                    LblInsumo.Text = Session["Insumo"].ToString();
                    Desplegar_DATOS_PROVEEDOR();
                    Desplegar_CONTRATOS_INSUMO();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Desplegar_CONTRATOS_INSUMO()
        {
            string[] valor = { LblIdInsProv.Text, LblIdCamp.Text, LblIdReg.Text, LblInsumo.Text, LblProg.Text, "1", "INSUMO_CONTRATO" };
            DB_AP_Proveedor pro = new DB_AP_Proveedor();
            DataTable dt = new DataTable();
            dt = pro.DB_Desplegar_PROVEEDOR_PARAMETROS(valor);
            GVContratos.DataSource = dt;
            GVContratos.DataBind();
        }
        #endregion
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Desplegar_DATOS_PROVEEDOR()
        {
            DB_AP_InscripcionProv insp = new DB_AP_InscripcionProv();
            AP_InscripcionProv ip = new AP_InscripcionProv();
            ip = insp.DB_Buscar_INSCRPCION_PROV(Convert.ToInt32(LblIdInsProv.Text));
            LblProg.Text = ip.Programa;
            LblIdCamp.Text = (ip.Id_Campanhia).ToString();
            LblIdReg.Text = (ip.Id_Regional).ToString();
            DB_AP_Proveedor p = new DB_AP_Proveedor();
            AP_Proveedor prov = new AP_Proveedor();
            prov = p.DB_Buscar_PROVEEDOR(Convert.ToString(ip.Id_Proveedor));
            LblProveedor.Text = prov.Razon_Social;
            DB_AP_Campanhia InsCamp = new DB_AP_Campanhia();
            AP_Campanhia camp = new AP_Campanhia();
            camp = InsCamp.DB_Buscar_CAMPANHIA(Convert.ToInt32(LblIdCamp.Text));
            LblCamp.Text = camp.Nombre;
            DB_Regional insreg = new DB_Regional();
            DataTable dt = new DataTable();
            dt = insreg.DB_Seleccionar_REGIONAL(Convert.ToInt32(LblIdReg.Text));
            LblRegional.Text=dt.Rows[0][1].ToString();
        }
        #endregion
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                //string FilePath = Server.MapPath(FolderPath + FileName);
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
                    //LblMsj.Text = "NO es El formato correcto solo se acepta formato .xls";
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                    break;
            }
            if(LblMsj.Text=="")
            {
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
        }
        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
            string FileName = GridView1.Caption;
            string Extension = Path.GetExtension(FileName);
            string FilePath = Server.MapPath(FolderPath + FileName);

            Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text);
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void LnkInportar_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }
        #region FUNCIONES 
        protected void Comprovar_valores_GRILLA()
        {   
            string Tipo = "";
            string Unidad = "";
            int j = 0;
            foreach (GridViewRow dgi in GridView1.Rows)
            {
                Tipo = GridView1.Rows[j].Cells[0].Text;
                Unidad = GridView1.Rows[j].Cells[3].Text;
                if (Unidad != "kg" && Unidad != "lt" && Unidad != "bolsa" && Unidad != "qq" && Unidad != "t" && Unidad != "@")
                {
                    LblMsj.Text = LblMsj.Text + "Error en: " + GridView1.Rows[j].Cells[3].Text + " Fila: " + (j + 1) + ", ";
                }
                if (Tipo != "CONVENCIONAL" && Tipo != "HIBRIDO" && Tipo != "TRANSGENICO" && Tipo != "DESECACION" && Tipo != "CONTROL DE MALEZAS" && Tipo != "TRATAMIENTO DE SEMILLA" && Tipo != "FUNGICIDAS" && Tipo != "HERBICIDAS" && Tipo != "INSECTICIDAS" && Tipo != "FERTILIZANTES" && Tipo != "COADYUVANTES")
                {
                    LblMsj.Text = LblMsj.Text + "Error en: " + GridView1.Rows[j].Cells[0].Text + " Fila: " + (j+1) + ", "; 
                }
                j++;
            }
        }
        #endregion
        #region FUNCIONES
        protected void Registrar_INSUMO_COMTRATO()
        {
            int tipo = 0;
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            int idmaxcontrato = 0;
            INS_ContratoInsumo conIns = new INS_ContratoInsumo();
            INS_DetalleInsumo DetIns = new INS_DetalleInsumo();
            DB_AP_InscripcionProv insProp = new DB_AP_InscripcionProv();
            conIns.Id_InscripcionProv = Convert.ToInt32(LblIdInsProv.Text);
            conIns.Id_Campanhia = Convert.ToInt32(LblIdCamp.Text);
            conIns.Id_Regional = Convert.ToInt32(LblIdReg.Text);
            conIns.Insumo = LblInsumo.Text;
            conIns.Programa = LblProg.Text;
            conIns.MontoTotal = 0;
            insProp.DB_Registrar_CONTRATO_INSUMO(conIns);
            idmaxcontrato = Convert.ToInt32(aux.DB_MaxId("INS_CONTRATO_INSUMO", "Id_Contrato_Insumo"));
            int j = 0;
            foreach (GridViewRow dgi in GridView1.Rows)
            {
                DetIns.Id_Contrato_Insumo = idmaxcontrato;
                switch (GridView1.Rows[j].Cells[0].Text)
                {
                    case "CONVENCIONAL":
                        tipo = 1;
                        break;
                    case "HIBRIDO":
                        tipo = 2;
                        break;
                    case "TRANSGENICO":
                        tipo = 3;
                        break;
                    case "DESECACION":
                        tipo = 4;
                        break;
                    case "CONTROL DE MALEZAS":
                        tipo = 15;
                        break;
                    case "TRATAMIENTO DE SEMILLA":
                        tipo = 5;
                        break;
                    case "FUNGICIDAS":
                        tipo = 6;
                        break;
                    case "HERBICIDAS":
                        tipo = 7;
                        break;
                    case "INSECTICIDAS":
                        tipo = 8;
                        break;
                    case "FERTILIZANTES":
                        tipo = 9;
                        break;
                    case "COADYUVANTES":
                        tipo = 10;
                        break;
                }
                DetIns.Id_Tipo_Insumo = tipo;
                DetIns.Nombre_Insumo = GridView1.Rows[j].Cells[1].Text;
                DetIns.Caracteristica = GridView1.Rows[j].Cells[2].Text;
                DetIns.Unidad = GridView1.Rows[j].Cells[3].Text;
                DetIns.CantidadDosis = Convert.ToDecimal(GridView1.Rows[j].Cells[4].Text);
                DetIns.Num_apli = Convert.ToInt32(GridView1.Rows[j].Cells[5].Text);
                DetIns.Precio = Convert.ToDecimal(GridView1.Rows[j].Cells[6].Text);
                insProp.DB_Registrar_CONTRATO_INSUMO_DETALLE(DetIns);
                j++;
            }
        }
        #endregion
        protected void BtnImportar_Click(object sender, EventArgs e)
        {
            Comprovar_valores_GRILLA();
            if (LblMsj.Text == "")
            {
                Registrar_INSUMO_COMTRATO();
            }
            else 
            {
                LblMsj.Text = "ERROR AL GUARDAR";
            }
        }
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            LblMsj.Text = string.Empty;
            GridView1.DataBind();
            BtnImportar.Visible = false;
            BtnCancelar.Visible = false;
        }

        protected void GVContratos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}