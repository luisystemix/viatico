using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DataBusiness.DB_Registro;
using DataBusiness.DB_General;
using DataEntity.DE_General;
using DataEntity.DE_Registro;
using DataBusiness.DB_Extensiones;
using DataBusiness.DB_Control;

namespace WebAplication.Control
{
    public partial class frmListCronogramaSeg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUser.Text = Session["IdUser"].ToString();
                    Llenar_DDLRegional();
                    Desplegar_LISTA_CRONOGRAMAS();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }

        #region FUNCION PARA LLENAR EL COMBO CON EL TIPO DE ORGANIZACION
        private void Llenar_DDLRegional()
        {
            DB_AdminUser User = new DB_AdminUser();
            DataTable dt = User.DB_Desplegar_USUARIO(LblIdUser.Text);
            LblRegional.Text = dt.Rows[0][5].ToString();
            LblIdReg.Text=dt.Rows[0][4].ToString();
        }
        #endregion

        #region FUNCION PARA DESPLEGAR LA LISTDE LOS CRONOGRAMS
        protected void Desplegar_LISTA_CRONOGRAMAS()
        {
            DB_EXT_Cronogramas ListC = new DB_EXT_Cronogramas();
            GVCronogramas.DataSource = ListC.DB_Desplegar_LISTA_CRONOGRAMAS(LblIdUser.Text, 0, 0,"LISTA_CRONOGRAMAS");
            GVCronogramas.DataBind();
        }
        #endregion

        protected void GVCronogramas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            StringBuilder sbMensaje = new StringBuilder();
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            Session.Add("IdCrono", GVCronogramas.Rows[rowIndex].Cells[0].Text);
            switch (tipo)
            {
                case "imprimir":
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Control/repCronogramaSeg.aspx?ci=" + GVCronogramas.Rows[rowIndex].Cells[0].Text);
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "seguimiento":
                    Response.Redirect("frmListCronogramaSegAvance.aspx");                    
                    break;
                case "editar":
                    string idCronograma = GVCronogramas.Rows[rowIndex].Cells[0].Text;
                    Response.Redirect("frmCronogramaSeg.aspx?EditCronograma="+ idCronograma);
                    break;

            }
        }

        protected void LnkCronograma_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCronogramaSeg.aspx");
        }

        protected void GVCronogramas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int idcronograma = Convert.ToInt16(DataBinder.Eval(e.Row.DataItem, "Id_Cronograma"));
                DB_EXT_Cronogramas ListC = new DB_EXT_Cronogramas();
                DataTable CronogramaAvance = ListC.DB_Desplegar_LISTA_ACTIVIDADES_CRONOGRAMA(idcronograma);
                int count = 0;
                foreach (DataRow row in CronogramaAvance.Rows)
                {
                    decimal avance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                    DateTime fecha = Convert.ToDateTime(row["FechaDia"].ToString());
                    DateTime f1 = DateTime.Now;
                    DateTime fechaActual = Convert.ToDateTime(f1.ToShortDateString());
                    if (fechaActual > fecha)
                    {
                        if (fechaActual == fecha)
                        {

                        }
                        else
                        {  
                            if (avance < 100)
                            {
                                count = count + 1;
                            }
                        }
                        
                    }
                    //if (avance < 100)
                    //{
                    //    count = count + 1;
                    //}                    
                }
                if (count > 0)
                {
                    e.Row.ForeColor = System.Drawing.Color.Red; // This will make row back color red
                }
                //if ( != "")
                //{
                //    DB_EXT_Cronogramas ListC = new DB_EXT_Cronogramas();
                //    //DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
                //    //int idcronograma = Convert.ToInt32(aux.DB_MaxId("EXT_CRONOGRAMA", "Id_Cronograma"));            
                //    DataTable ListaCronograma = ListC.DB_Desplegar_LISTA_CRONOGRAMAS(LblIdUser.Text, 0, 0, "LISTA_CRONOGRAMAS");

                //    foreach (DataRow cr in ListaCronograma.Rows)
                //    {
                //        int idcronograma = Convert.ToInt16(cr["Id_Cronograma"].ToString());
                //        DataTable CronogramaAvance = ListC.DB_Desplegar_LISTA_ACTIVIDADES_CRONOGRAMA(idcronograma);
                //        int count = 0;
                //        foreach (DataRow row in CronogramaAvance.Rows)
                //        {                            
                //            decimal avance = Convert.ToDecimal(row["PorcentajeAvance"].ToString());
                //            if (avance < 100)
                //            {                                
                //                count = count + 1;
                //            }
                //        }
                //        if (count > 0)
                //        {
                //            e.Row.BackColor = System.Drawing.Color.Red; // This will make row back color red
                //        }
                        
                //    }
                //}
                //else
                //{

                //}
            }
        }
    }
}