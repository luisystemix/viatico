using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DataBusiness.DB_Registro;
using DataBusiness.DB_Extensiones;
using DataEntity.DE_Extensiones;
using DataEntity.DE_Registro;
using DataBusiness.DB_General;

namespace WebAplication.Extensiones
{
    public partial class frmFenologiaRegional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            if (!IsPostBack)
            {
                LblIdUsuario.Text = Session["IdUser"].ToString();
                Datos_ENCABEZADO();
                Llenar_DDLCAMPANHIA();
                Llenar_DDLFECHAENVIA();
                LblFechaIni.Text = (Convert.ToDateTime(DDLSemanaEnvio.SelectedItem.Text).AddDays(-7)).ToString("dd/MM/yyyy");
                Desplegar_GRILLA();
                Desplegar_GRILLA_ENVIADOS();
            }
            //}
            //catch
            //{
            //    Response.Redirect("~/About.aspx");
            //}
        }
        #region FUNCIONES PARA CARGAR LOS DATOS DE LA ORGANIZACION
        private void Datos_ENCABEZADO()
        {
            DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = Usuario.DB_Desplegar_USUARIO(LblIdUsuario.Text);
            LblRegional.Text = dt.Rows[0][5].ToString();
            LblIdReg.Text = dt.Rows[0][4].ToString();
            LblRegion.Text = dt.Rows[0][10].ToString();
        }
        #endregion
        #region FUNCION PARA LLENAR EL COMBO CON TODAS LAS CAMPAÑAS
        private void Llenar_DDLCAMPANHIA()
        {
            DB_AP_Campanhia cam = new DB_AP_Campanhia();
            DataTable dt = new DataTable();
            dt = cam.DB_Seleccionar_CAMPANHIA_REG_NOFIN(LblRegion.Text);
            DDLCamp.DataSource = dt;
            DDLCamp.DataValueField = "Id_Campanhia";
            DDLCamp.DataTextField = "Nombre";
            DDLCamp.DataBind();
        }
        #endregion
        #region FUNCION PARA LLENAR EL COMBO 
        private void Llenar_DDLFECHAENVIA()
        {
            DB_EXT_Fenologia fendetalle = new DB_EXT_Fenologia();
            DataTable dt = new DataTable();
            dt = fendetalle.DB_Reporte_FENOLOGIA_DETALLE(0, DDLProg.SelectedValue, Convert.ToInt32(DDLCamp.SelectedValue), Convert.ToInt32(LblIdReg.Text), 0, "", DateTime.Now,"FENOLOGIA_POR_FECHA");
            if (dt.Rows.Count > 0)
            {
                DDLSemanaEnvio.DataSource = dt;
                DDLSemanaEnvio.DataValueField = "Fecha_Semana_Envio";
                DDLSemanaEnvio.DataTextField = "Fecha_Semana_Envio";
                DDLSemanaEnvio.DataBind();
            }
            else
            {
                DDLSemanaEnvio.Items.Insert(0, new ListItem(DateTime.Now.ToString("dd/MM/yyyy"), "Fecha_Semana_Envio"));
            }
        }
        #endregion
        private void Desplegar_GRILLA_ENVIADOS() 
        {
            DB_EXT_Fenologia fendetalle = new DB_EXT_Fenologia();
            GVEnviadosSemana.DataSource = fendetalle.DB_Seleccionar_ENVIOS_SEMANA(Convert.ToInt32(LblIdReg.Text));
            GVEnviadosSemana.DataBind();
        }

        private void Desplegar_GRILLA()
        {
            DB_EXT_Fenologia fendetalle = new DB_EXT_Fenologia();
            switch (DDLProg.SelectedValue)
            {  
                case "TRIGO":
                        GVDetalleFenologiaTrigo.Visible = true;
                        GVDetalleFenologiaTrigo.DataSource = fendetalle.DB_Reporte_FENOLOGIA_DETALLE(0, DDLProg.SelectedValue, Convert.ToInt32(DDLCamp.SelectedValue), Convert.ToInt32(LblIdReg.Text), 0, "", Convert.ToDateTime(DDLSemanaEnvio.SelectedItem.Text), "FENOLOGIA_TRIGO");
                        GVDetalleFenologiaTrigo.DataBind();
                    if(GVDetalleFenologiaTrigo.Rows.Count > 0)
                    {
                        Promedios_Totales();
                    }
                    break;
                //case "MAIZ":
                //    if (LblIdInsOrg.Text == "Total")
                //    {
                //        GVDetalleFenologiaMaiz.Visible = true;
                //        GVDetalleFenologiaMaiz.DataSource = fendetalle.DB_Reporte_FENOLOGIA_DETALLE(0, LblPrograma.Text, Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblNumSegCult.Text), "", "FENOLOGIA_MAIZ");
                //        GVDetalleFenologiaMaiz.DataBind();
                //    }
                //    else
                //    {
                //        GVDetalleFenologiaMaiz.Visible = true;
                //        GVDetalleFenologiaMaiz.DataSource = fendetalle.DB_Reporte_FENOLOGIA_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), LblPrograma.Text, Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblNumSegCult.Text), "", "DETALLE_FENOLOGIA_MAIZ");
                //        GVDetalleFenologiaMaiz.DataBind();
                //    }
                //    break;
                //case "ARROZ":
                //    if (LblIdInsOrg.Text == "Total")
                //    {
                //        GVDetalleFenologiaArroz.Visible = true;
                //        GVDetalleFenologiaArroz.DataSource = fendetalle.DB_Reporte_FENOLOGIA_DETALLE(0, LblPrograma.Text, Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblNumSegCult.Text), "", "FENOLOGIA_ARROZ");
                //        GVDetalleFenologiaArroz.DataBind();
                //    }
                //    else
                //    {
                //        GVDetalleFenologiaArroz.Visible = true;
                //        GVDetalleFenologiaArroz.DataSource = fendetalle.DB_Reporte_FENOLOGIA_DETALLE(Convert.ToInt32(LblIdInsOrg.Text), LblPrograma.Text, Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblNumSegCult.Text), "", "DETALLE_FENOLOGIA_ARROZ");
                //        GVDetalleFenologiaArroz.DataBind();
                //    }
                //    break;
            }
        }
        /*************************/
        #region
        protected void Promedios_Totales() 
        {
            decimal filas = GVDetalleFenologiaTrigo.Rows.Count;
            decimal suma = GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[5].Text));
            LblTotSupSem.Text = Convert.ToString(Math.Round((suma),2));
            LblTotNumBenef.Text = Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[4].Text)))), 2));
            LblTotAvSiem.Text = Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[9].Text))) / filas), 2));
            LblTotGerm.Text = Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[10].Text))) / filas), 2));
            LblTotPlant.Text=Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[11].Text))) / filas), 2));
            LblTotMacolla.Text=Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[12].Text))) / filas), 2));
            LblTotEmbu.Text=Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[13].Text))) / filas), 2));
            LblTotEspi.Text=Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[14].Text))) / filas), 2));
            LblTotFlora.Text=Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[15].Text))) / filas), 2));
            LblTotLlenGran.Text=Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[16].Text))) / filas), 2));
            LblTotMadura.Text=Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[17].Text))) / filas), 2));
            LblTotAvCos.Text=Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[18].Text))) / filas), 2));
            LblTotRend.Text = Convert.ToString(Math.Round((Convert.ToDecimal(GVDetalleFenologiaTrigo.Rows.Cast<GridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[19].Text))) / filas), 2));
        }
        #endregion
        protected void GVDetalleFenologiaTrigo_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();

                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 4;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Semilla</div>";
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Fecha y avance de siembra</div>";
                HeaderCell.ColumnSpan = 3;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>ETAPA FENOLOGICA EN %</div>";
                HeaderCell.ColumnSpan = 8;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Cosecha y acopio</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Fecha cosecha</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow.Cells.Add(HeaderCell);

                GVDetalleFenologiaTrigo.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }

        protected void DDLProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_DDLFECHAENVIA();
            Desplegar_GRILLA();
        }

        protected void BtnEnviarSeg_Click(object sender, EventArgs e)
        {
            /**************************************************** VALIDAR QUE SOLAMENTE SE ENVIE SI TIENE TODAS LAS ORGANIZACIONES DE LA REGIONAL ***/ 
            DB_EXT_Fenologia index = new DB_EXT_Fenologia();
            EXT_FaseFenEnvioSem ffsem = new EXT_FaseFenEnvioSem();
            EXT_FaseFenEnvioSemanaTrigo ffsTrigo = new EXT_FaseFenEnvioSemanaTrigo();
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            ffsem.Id_Campanhia = Convert.ToInt32(DDLCamp.SelectedValue);
            ffsem.Id_Regional = Convert.ToInt32(LblIdReg.Text);
            ffsem.Programa = DDLProg.SelectedValue;
            ffsem.Fecha_Envio = DateTime.Now;
            ffsem.Estado = "ENVIADO";
            ffsem.Fecha_Semana = Convert.ToDateTime(DDLSemanaEnvio.SelectedValue);
            index.DB_Registrar_FACE_FENOLOGICA_SEMANAL(ffsem);
            int valor = Convert.ToInt32(aux.DB_MaxId("EXT_FASE_FEN_ENVIO_SEM", "Id_Envio_FenologiaSemanal"));
                        /***********************************/
            ffsTrigo.Id_Envio_FenologiaSemanal = valor;
            ffsTrigo.Num_Prod_Vigente=Convert.ToInt32(LblTotNumBenef.Text);
            ffsTrigo.Sup_Sembrada=Convert.ToDecimal(LblTotSupSem.Text);
            ffsTrigo.Avance_Siembra=Convert.ToDecimal(LblTotAvSiem.Text);
            ffsTrigo.Germinacion=Convert.ToDecimal(LblTotGerm.Text);
            ffsTrigo.Plantula=Convert.ToDecimal(LblTotPlant.Text);
            ffsTrigo.Macollamiento=Convert.ToDecimal(LblTotMacolla.Text);
            ffsTrigo.Embuche=Convert.ToDecimal(LblTotEmbu.Text);
            ffsTrigo.Espigazon=Convert.ToDecimal(LblTotEspi.Text);
            ffsTrigo.Floracion=Convert.ToDecimal(LblTotFlora.Text);
            ffsTrigo.Llenado_Grano=Convert.ToDecimal(LblTotLlenGran.Text);
            ffsTrigo.Maduracion=Convert.ToDecimal(LblTotMadura.Text);
            ffsTrigo.Avance_cosecha=Convert.ToDecimal(LblTotAvCos.Text);
            ffsTrigo.Rendimiento = Convert.ToDecimal(LblTotRend.Text);
            index.DB_Registrar_FACE_FENOLOGICA_SEMANAL_ENVIO_TRIGO(ffsTrigo);
            int i = 0;
            GVDetalleFenologiaTrigo.Columns[0].Visible = true;
            Desplegar_GRILLA();
            foreach (GridViewRow dgi in GVDetalleFenologiaTrigo.Rows)
            {
                index.DB_Indexar_FACE_FENOLOGICA_SEMANAL(valor, Convert.ToInt32(GVDetalleFenologiaTrigo.Rows[i].Cells[0].Text));
                i++;
            }
            GVDetalleFenologiaTrigo.Columns[0].Visible = false;
            Desplegar_GRILLA();
            Desplegar_GRILLA_ENVIADOS();
        }

        protected void GVEnviadosSemana_RowCreated(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();

                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 5;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "<div style='text-align: center'>Periodo</div>";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                GVEnviadosSemana.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }

        protected void GVEnviadosSemana_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            StringBuilder sbMensaje = new StringBuilder();
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVEnviadosSemana.Columns[8].Visible = true;
            GVEnviadosSemana.Columns[9].Visible = true;
            GVEnviadosSemana.Columns[10].Visible = true;
            Desplegar_GRILLA_ENVIADOS();
            Session.Add("Programa", GVEnviadosSemana.Rows[rowIndex].Cells[3].Text);
            Session.Add("NumSeg", GVEnviadosSemana.Rows[rowIndex].Cells[8].Text);
            Session.Add("IdCamp", GVEnviadosSemana.Rows[rowIndex].Cells[9].Text);
            Session.Add("IdReg", GVEnviadosSemana.Rows[rowIndex].Cells[10].Text);
            Session.Add("fecha", GVEnviadosSemana.Rows[rowIndex].Cells[6].Text);
            switch (tipo)
            {
                case "imprimir":
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Control/repFaceFenologica.aspx?ci=" + GVEnviadosSemana.Rows[rowIndex].Cells[5].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                break;
            }
            GVEnviadosSemana.Columns[8].Visible = false;
            GVEnviadosSemana.Columns[9].Visible = false;
            GVEnviadosSemana.Columns[10].Visible = false;
            Desplegar_GRILLA_ENVIADOS();
        }

        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLSemanaEnvio_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desplegar_GRILLA();
        }
    }
}