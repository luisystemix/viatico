using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;

namespace WebAplication.Registro
{
    public partial class frmCronogramaReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdUser.Text = Session["IdUser"].ToString();
                    LblPrograma.Text = Session["Prog"].ToString();
                    LblIdCamp.Text = Session["IdCamp"].ToString();
                    Seleccionar_CAMPANHIA();
                    Desplegar_USUARIO();
                    Desplegar_ACTIVIDADES_CAMP();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Seleccionar_CAMPANHIA()
        {
            DB_AP_Campanhia ca = new DB_AP_Campanhia();
            AP_Campanhia camp = new AP_Campanhia();
            camp = ca.DB_Buscar_CAMPANHIA(Convert.ToInt32(LblIdCamp.Text));
            LblCamp.Text = camp.Nombre;
        }
        #endregion
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Desplegar_USUARIO()
        {
            DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = Usuario.DB_Desplegar_USUARIO(LblIdUser.Text);
            LblRegional.Text = dt.Rows[0][5].ToString();
            LblIdReg.Text = dt.Rows[0][4].ToString();
        }
        #endregion
        #region FUNCION PARA DESPLEGAR LA LISTA DE ACTIVIDADES
        protected void Desplegar_ACTIVIDADES_CAMP()
        {
            DB_AP_CronogramaCamp act = new DB_AP_CronogramaCamp();
            GVActividades.DataSource = act.DB_Desplegar_ACTIVIDADES_CAMP();
            GVActividades.DataBind();
        }
        #endregion
        #region FUNCIONES INDEPENDIENTES PARA REGISTRAR EL CRONOGRAMA
        protected void Registrar_CRONOGRAMA()
        {
            AP_CronogramaCamp c = new AP_CronogramaCamp();
            AP_CronogramaCampDetalle cd =new AP_CronogramaCampDetalle();
            DB_AP_CronogramaCamp reg = new DB_AP_CronogramaCamp();
            c.Id_Campanhia = Convert.ToInt32(LblIdCamp.Text);
            c.Id_Regional = Convert.ToInt32(LblIdReg.Text);
            c.Programa = LblPrograma.Text;
            c.Tipo = "INICIAL";
            c.Fecha = DateTime.Now;
            c.Estado="ENVIADO";
            reg.DB_Registrar_CRONOGRAMA(c);
        }
        #endregion
        #region FUNCIONES INDEPENDIENTES PARA REGISTRAR EL CRONOGRAMA DETALLE
        protected void Registrar_CRONOGRAMA_DETALLE()
        {
            DB_AP_Registro_Org a = new DB_AP_Registro_Org();
            AP_CronogramaCampDetalle cd =new AP_CronogramaCampDetalle();
            DB_AP_CronogramaCamp reg = new DB_AP_CronogramaCamp();
            string aux="";
            bool sw = true;
            //cont = GVActividades.Rows.Count;
            foreach (GridViewRow dgi in GVActividades.Rows)
            {
                TextBox txini1 = (TextBox)dgi.Cells[2].Controls[1];
                TextBox txfin1 = (TextBox)dgi.Cells[3].Controls[1];
                if(txini1.Text =="" || txfin1.Text=="")
                 {
                    sw = false;
                    aux = GVActividades.Rows[dgi.RowIndex].Cells[1].Text;
                    break;
                 }
            }
            if (sw == true)
            {
                Registrar_CRONOGRAMA();
                int idCrono = Convert.ToInt32(a.DB_MaxId("AP_CRONOGRAMA_CAMP", "Id_Cronograma"));
                foreach (GridViewRow d in GVActividades.Rows)
                {
                    TextBox txini = (TextBox)d.Cells[2].Controls[1];
                    TextBox txfin = (TextBox)d.Cells[3].Controls[1];
                    cd.Id_Cronograma = idCrono;
                    cd.Id_Actividad = Convert.ToInt32(GVActividades.Rows[d.RowIndex].Cells[0].Text);
                    cd.Numero = d.RowIndex;
                    cd.Inicio_Planificado = Convert.ToDateTime(txini.Text);
                    cd.Final_Planificado = Convert.ToDateTime(txfin.Text);
                    cd.Inicio_Ejecutado = Convert.ToDateTime(txini.Text);
                    cd.Final_Ejecutado = Convert.ToDateTime(txfin.Text);
                    cd.Observacion = "";
                    reg.DB_Registrar_CRONOGRAMA_DETALLE(cd);
                }
            }
            else 
            {
                LblMsj.Text = "No se definio una fecha para:" + " "+ aux;
            }
            Response.Redirect("frmListaCronogramas.aspx");
        }
        #endregion
        #region FUNCION PARA REGISTRAR EL CRONOGRAMA
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Registrar_CRONOGRAMA_DETALLE();
        }
        #endregion

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("repCronogramaRegIni.aspx");
        }

        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}