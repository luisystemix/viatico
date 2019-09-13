using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;
using DataBusiness.DB_General;
using DataEntity.DE_Extensiones;
using DataBusiness.DB_Extensiones;

namespace WebAplication.Extensiones
{
    public partial class frmSeguimientoTecnico : System.Web.UI.Page
    {
        #region "Miembros IUsuarios"
        private DataTable DT_PROD_CONSULTAS //**LR
        {
            get
            {
                if (ViewState["DT_PROD_CONSULTAS"] != null)
                    return (DataTable)ViewState["DT_PROD_CONSULTAS"];

                return new DataTable();
            }
            set { ViewState["DT_PROD_CONSULTAS"] = value; }
        }        
        #endregion 
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUsuario.Text = Session["IdUser"].ToString();
                    LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                    Datos_Org_ENCABEZADO();
                    Llenar_GVDESIGNADO();
                    Llenar_NO_SELECCIONADOS();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Datos_Org_ENCABEZADO()
        {
            DB_AP_Registro_Org d_org = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = d_org.DB_Desplegar_ENCABEZADO_ORG(Convert.ToInt32(LblIdInsOrg.Text));
            LblOrg.Text = dt.Rows[0][2].ToString();
            LblIdCamp.Text = dt.Rows[0][5].ToString();
            LblCamp.Text = dt.Rows[0][6].ToString();
            LblIdReg.Text = dt.Rows[0][7].ToString();
            LblReg.Text = dt.Rows[0][8].ToString();
            LblPrograma.Text = dt.Rows[0][9].ToString();   

        }
        #endregion
        #region FUNCIONES DE LA GRILLA
        private void Llenar_GVDESIGNADO()
        {
            DB_EXT_DesignacionProd ListDes = new DB_EXT_DesignacionProd();
            DataTable dt = new DataTable();
            //GVDesignado.DataSource = ListDes.DB_Desplegar_DESIGNACION_PROD(LblIdUsuario.Text, 0, 0, LblPrograma.Text, Convert.ToInt32(LblIdInsOrg.Text), "SEGDESIGNADOS");
            //******************************TRATAMIENTO PARA LAS ETAPAS
            DB_EXT_Seguimiento ListSegPendiente = new DB_EXT_Seguimiento();            
            List<EXT_SeguimientoPendiente> LSP = ListSegPendiente.DB_Desplegar_SEGUIMIENTOS_PENDIENTE();
            //LSP[0].Nombre_Anterior
            DT_PROD_CONSULTAS = ListDes.DB_Desplegar_DESIGNACION_PROD(LblIdUsuario.Text, 0, 0, LblPrograma.Text, Convert.ToInt32(LblIdInsOrg.Text), "SEGDESIGNADOS");
            dt = DT_PROD_CONSULTAS;//copiamos 
            dt.Columns.Add("Id_Etapa", typeof(String));            
            foreach (DataRow fila in dt.Rows)
            {
                int number1 = 0;
                string Etapa = fila["Etapa"].ToString();
                bool canConvert = int.TryParse(Etapa, out number1);
                if (canConvert == true)
                {
                    foreach (EXT_SeguimientoPendiente row in LSP)
                    {
                        int id_sp = row.Id_Seguimiento_pendiente;
                        int etapaobtenida = Convert.ToInt16(fila["Etapa"]);
                        if (id_sp == etapaobtenida)
                        {
                            fila["Etapa"] = row.Nombre;
                            fila["Id_Etapa"] = row.Id_Seguimiento_pendiente.ToString();
                            break;
                        }
                    }
                }
                else
                {
                    foreach (EXT_SeguimientoPendiente row in LSP)
                    {
                        string old_name = row.Nombre_Anterior;
                        string etapaobtenida = fila["Etapa"].ToString();
                        if (old_name == etapaobtenida)
                        {
                            fila["Etapa"] = row.Nombre;
                            fila["Id_Etapa"] = row.Id_Seguimiento_pendiente.ToString();
                            break;
                        }
                    }
                }
            }
            //******************************
            GVDesignado.DataSource = dt;
            GVDesignado.DataBind();
            if (GVDesignado.Rows.Count==0)
            {
                LblMsj1.Text = "No se seleccionó productores que formen parte de la muestra.";
            }
            else
            {
                LblMsj1.Text = string.Empty;
            }
            
        }
        private void Llenar_NO_SELECCIONADOS() 
        {
            DB_EXT_DesignacionProd ListDes = new DB_EXT_DesignacionProd();
            GVNoDesignado.DataSource = ListDes.DB_Desplegar_DESIGNACION_PROD(LblIdUsuario.Text, Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), LblPrograma.Text, Convert.ToInt32(LblIdInsOrg.Text), "NO_SELECCIONADOS");
            GVNoDesignado.DataBind();
        }
        protected void GVDesignado_RowCommand(object sender, GridViewCommandEventArgs e)
        { 
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVDesignado.Columns[5].Visible = true;
            GVDesignado.Columns[4].Visible = true;
            Llenar_GVDESIGNADO();
            Session.Add("IdInsProd", GVDesignado.Rows[rowIndex].Cells[5].Text);
            Session.Add("Etapa", GVDesignado.Rows[rowIndex].Cells[3].Text);
            Session.Add("Id_Etapa", GVDesignado.Rows[rowIndex].Cells[12].Text);//**LR
            Session.Add("Estado", GVDesignado.Rows[rowIndex].Cells[4].Text);
            switch (tipo)
            {
                case "Parcela":
                    //if (GVDesignado.Rows[rowIndex].Cells[3].Text != "DISTRIBUCION_SEMILLA")//**LR
                    //{
                        Response.Redirect("frmListaSeguimiento.aspx");
                    //}
                    //else
                    //{
                    //    LblMsj.Text = "Tiene que realizar el seguimiento a la distribución de semilla, antes de verificar la siembra.";
                    //}
                    break;
                case "Semilla":
                    Response.Redirect("frmListaDistribSemilla.aspx");
                    break;
                case "Agroquimico":
                    Response.Redirect("frmListaDistribAgroquimico.aspx");
                    break;
                case "Rendimiento":
                     DB_EXT_Fenologia nd = new DB_EXT_Fenologia();
                     List<EXT_Fenologia> ListaF = new List<EXT_Fenologia>();
                     Response.Redirect("frmListaRendimiento.aspx");         
                    break;
                case "Costos":
                    Response.Redirect("frmListaCostos.aspx");
                    break;
            }
            GVDesignado.Columns[5].Visible = false;
            GVDesignado.Columns[4].Visible = false;
            Llenar_GVDESIGNADO();
        }
        #endregion
        #region FUNCIONES DE LA GRILLA
        protected void GVDesignado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                Boolean valor = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Estado").ToString());
                var image = e.Row.FindControl("ImgEstado") as Image;
                if (valor == true)
                {
                    image.ImageUrl = "~/images/img-1.png";
                }
                if (valor == false)
                {
                    image.ImageUrl = "~/images/img-0.png";
                }
            }
        }
        #endregion
        protected void GVNoDesignado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DB_EXT_DesignacionProd Ins = new DB_EXT_DesignacionProd();
            EXT_DesignacionProd dp = new EXT_DesignacionProd();
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVNoDesignado.Columns[5].Visible = true;
            Llenar_NO_SELECCIONADOS(); 
            Session.Add("IdInsProd", GVNoDesignado.Rows[rowIndex].Cells[5].Text);
            switch (tipo)
            {
                case "Habilitar":
                    dp.Id_Usuario = LblIdUsuario.Text;
                    dp.Id_Productor = GVNoDesignado.Rows[rowIndex].Cells[5].Text;
                    dp.Estado = false;
                    dp.Etapa = "VERIFICACION_PARCELA";
                    Ins.DB_Registrar_DESIGNACION_PROD(dp);
                    Llenar_GVDESIGNADO();
                    break;
            }
            GVNoDesignado.Columns[5].Visible = false;
            Llenar_NO_SELECCIONADOS(); 
        }

        protected void GVNoDesignado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string valor = DataBinder.Eval(e.Row.DataItem, "Estado").ToString();
                //var image = e.Row.FindControl("ImgEstado") as Image;
                //if (valor == "")
                //{
                //    //image.ImageUrl = "~/images/img-0.png";

                //}
            }
        }
    }
}