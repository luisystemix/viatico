using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataEntity.DE_Extensiones;
using DataBusiness.DB_Extensiones;
using DataBusiness.DB_Registro;

namespace WebAplication.Control
{
    public partial class frmCronogramaTec : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUser.Text = Session["IdUser"].ToString();
                    LblIdCamp.Text = Session["IdCamp"].ToString();
                    LblIdReg.Text = Session["IdReg"].ToString();
                    LblProg.Text = Session["Programa"].ToString();
                    //Inicializar_ComboReg();
                    //Inicializar_ComboDep(DDLDepart.SelectedValue, LblZona.Text);/****************cambio el value del combo**/
                    DataTable dtListaPartida = new DataTable();
                    dtListaPartida.Columns.AddRange(new DataColumn[14] { new DataColumn("Tarea"), new DataColumn("Gestion"), new DataColumn("Enero"), new DataColumn("Febrero"), new DataColumn("Marzo"), new DataColumn("Abril"), new DataColumn("Mayo"), new DataColumn("Junio"), new DataColumn("Julio"), new DataColumn("Agosto"), new DataColumn("Septiembre"), new DataColumn("Octubre"), new DataColumn("Noviembre"), new DataColumn("Diciembre") });
                    GVCronograma.DataSource = dtListaPartida;
                    GVCronograma.DataBind();
                    Session["datos"] = dtListaPartida;
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
                DataTable dt = Session["datos"] as DataTable;
                DataRow row = dt.NewRow();
                row["Tarea"] = DDLTareas.SelectedValue;
                row["Gestion"] = DDLGestion.SelectedValue;
                row["Enero"] = Mes1.Checked;
                row["Febrero"] = Mes2.Checked;
                row["Marzo"] = Mes3.Checked;
                row["Abril"] = Mes4.Checked;
                row["Mayo"] = Mes5.Checked;
                row["Junio"] = Mes6.Checked;
                row["Julio"] = Mes7.Checked;
                row["Agosto"] = Mes8.Checked;
                row["Septiembre"] = Mes9.Checked;
                row["Octubre"] = Mes10.Checked;
                row["Noviembre"] = Mes11.Checked;
                row["Diciembre"] = Mes12.Checked;
                dt.Rows.Add(row);
                GVCronograma.DataSource = dt;
                GVCronograma.DataBind();
                Session["datos"] = dt;
                Inicializar_CHECK();
        }

        protected void GVCronograma_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Boolean mes1 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Enero").ToString());
                Boolean mes2 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Febrero").ToString());
                Boolean mes3 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Marzo").ToString());
                Boolean mes4 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Abril").ToString());
                Boolean mes5 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Mayo").ToString());
                Boolean mes6 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Junio").ToString());
                Boolean mes7 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Julio").ToString());
                Boolean mes8 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Agosto").ToString());
                Boolean mes9 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Septiembre").ToString());
                Boolean mes10 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Octubre").ToString());
                Boolean mes11 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Noviembre").ToString());
                Boolean mes12 = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Diciembre").ToString());
                var image1 = e.Row.FindControl("ImgEstado1") as Image;
                var image2 = e.Row.FindControl("ImgEstado2") as Image;
                var image3 = e.Row.FindControl("ImgEstado3") as Image;
                var image4 = e.Row.FindControl("ImgEstado4") as Image;
                var image5 = e.Row.FindControl("ImgEstado5") as Image;
                var image6 = e.Row.FindControl("ImgEstado6") as Image;
                var image7 = e.Row.FindControl("ImgEstado7") as Image;
                var image8 = e.Row.FindControl("ImgEstado8") as Image;
                var image9 = e.Row.FindControl("ImgEstado9") as Image;
                var image10 = e.Row.FindControl("ImgEstado10") as Image;
                var image11 = e.Row.FindControl("ImgEstado11") as Image;
                var image12 = e.Row.FindControl("ImgEstado12") as Image;

                if (mes1 == true)
                {
                    image1.ImageUrl = "~/images/img-1.png";
                }
                if (mes1 == false)
                {
                    image1.ImageUrl = "~/images/img-0.png";
                }
                if (mes2 == true)
                {
                    image2.ImageUrl = "~/images/img-1.png";
                }
                if (mes2 == false)
                {
                    image2.ImageUrl = "~/images/img-0.png";
                }
                if (mes3 == true)
                {
                    image3.ImageUrl = "~/images/img-1.png";
                }
                if (mes3 == false)
                {
                    image3.ImageUrl = "~/images/img-0.png";
                }
                if (mes4 == true)
                {
                    image4.ImageUrl = "~/images/img-1.png";
                }
                if (mes4 == false)
                {
                    image4.ImageUrl = "~/images/img-0.png";
                }
                if (mes5 == true)
                {
                    image5.ImageUrl = "~/images/img-1.png";
                }
                if (mes5 == false)
                {
                    image5.ImageUrl = "~/images/img-0.png";
                }
                if (mes6 == true)
                {
                    image6.ImageUrl = "~/images/img-1.png";
                }
                if (mes6 == false)
                {
                    image6.ImageUrl = "~/images/img-0.png";
                }
                if (mes7 == true)
                {
                    image7.ImageUrl = "~/images/img-1.png";
                }
                if (mes7 == false)
                {
                    image7.ImageUrl = "~/images/img-0.png";
                }
                if (mes8 == true)
                {
                    image8.ImageUrl = "~/images/img-1.png";
                }
                if (mes8 == false)
                {
                    image8.ImageUrl = "~/images/img-0.png";
                }
                if (mes9 == true)
                {
                    image9.ImageUrl = "~/images/img-1.png";
                }
                if (mes9 == false)
                {
                    image9.ImageUrl = "~/images/img-0.png";
                }
                if (mes10 == true)
                {
                    image10.ImageUrl = "~/images/img-1.png";
                }
                if (mes10 == false)
                {
                    image10.ImageUrl = "~/images/img-0.png";
                }
                if (mes11 == true)
                {
                    image11.ImageUrl = "~/images/img-1.png";
                }
                if (mes11 == false)
                {
                    image11.ImageUrl = "~/images/img-0.png";
                }
                if (mes12 == true)
                {
                    image12.ImageUrl = "~/images/img-1.png";
                }
                if (mes12 == false)
                {
                    image12.ImageUrl = "~/images/img-0.png";
                }
            }
        }
        #region restaurar CheckBox
        protected void Inicializar_CHECK()
        {
            Mes1.Checked = false;
            Mes2.Checked = false;
            Mes3.Checked = false;
            Mes4.Checked = false;
            Mes5.Checked = false;
            Mes6.Checked = false;
            Mes7.Checked = false;
            Mes8.Checked = false;
            Mes9.Checked = false;
            Mes10.Checked = false;
            Mes11.Checked = false;
            Mes12.Checked = false;
        }
        #endregion
        protected void DDLTareas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Inicializar_CHECK();
        }

        //protected void GVCronograma_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    int index = Convert.ToInt32(e.CommandArgument);
        //    GridViewRow row = GVCronograma.Rows[index];
        //}

        //int Buscar_Indice(string TextoBusqueda, DataTable DT)
        //{
        //    int iIndice = -1;
        //    bool encontrado = false;
        //    int contador = 0;
        //    while (encontrado == false && contador <= DT.Rows.Count - 1)
        //    {
        //        DataRow row = DT.Rows[contador];
        //        if (Convert.ToString(row[0]) == TextoBusqueda)
        //        {
        //            encontrado = true;
        //            iIndice = contador;
        //        }
        //        contador++;
        //    }
        //    return iIndice;
        //}

        protected void GVCronograma_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable DT = Session["datos"] as DataTable;
            DT.Rows.RemoveAt(e.RowIndex);
            GVCronograma.DataSource = DT;
            GVCronograma.DataBind();
            Session["datos"] = DT;
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            Registrar_CRONOGRAMA();
            Response.Redirect("frmListaCronogramaTec.aspx");
        }
        protected void Registrar_CRONOGRAMA()
        {
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            EXT_CronogramaTec ct = new EXT_CronogramaTec();
            EXT_CronogramaTecDetalle ctd = new EXT_CronogramaTecDetalle();
            DB_EXT_Cronogramas regc = new DB_EXT_Cronogramas(); 
            
            ct.Id_Campanhia = Convert.ToInt32(LblIdCamp.Text);
            ct.Id_Regional = Convert.ToInt32(LblIdReg.Text);
            ct.Id_Usuario = LblIdUser.Text;
            ct.Programa = LblProg.Text;
            ct.Fecha_Envio = DateTime.Now;
            ct.Estado = "ENVIADO";
            regc.DB_Registrar_CRONOGRAMA_TEC(ct);
            string id = aux.DB_MaxId("EXT_CRONOGRAMA_TEC", "Id_Cronograma_Tec");
            DataTable dt = Session["datos"] as DataTable;
            for (int i = 0; i < GVCronograma.Rows.Count; i++)
            {
                ctd.Id_Cronograma_Tec = Convert.ToInt32(id);
                ctd.Tarea = dt.Rows[i][0].ToString();
                ctd.Gestion = dt.Rows[i][1].ToString();
                ctd.Enero = Convert.ToBoolean(dt.Rows[i][2].ToString());
                ctd.Febrero = Convert.ToBoolean(dt.Rows[i][3].ToString());
                ctd.Marzo = Convert.ToBoolean(dt.Rows[i][4].ToString());
                ctd.Abril = Convert.ToBoolean(dt.Rows[i][5].ToString());
                ctd.Mayo = Convert.ToBoolean(dt.Rows[i][6].ToString());
                ctd.Junio = Convert.ToBoolean(dt.Rows[i][7].ToString());
                ctd.Julio = Convert.ToBoolean(dt.Rows[i][8].ToString());
                ctd.Agosto = Convert.ToBoolean(dt.Rows[i][9].ToString());
                ctd.Septiembre = Convert.ToBoolean(dt.Rows[i][10].ToString());
                ctd.Octubre = Convert.ToBoolean(dt.Rows[i][11].ToString());
                ctd.Noviembre = Convert.ToBoolean(dt.Rows[i][12].ToString());
                ctd.Diciembre = Convert.ToBoolean(dt.Rows[i][13].ToString());
                regc.DB_Registrar_CRONOGRAMA_TEC_DETALLE(ctd);
            }
        }
    }
}