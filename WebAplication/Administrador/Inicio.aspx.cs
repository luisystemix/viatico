using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;

namespace WebAplication.Administrador
{
    public partial class Inicio : System.Web.UI.Page
    {
        public int aux;
        protected void Page_Load(object sender, EventArgs e)
        {         
            if (!IsPostBack)
            {
                if (Session["estado"].ToString() == "nuevo")
                {
                    Desplegar_CAMPANIHA();
                    //Desplegar_CAMPANIHA_PARAMETROS();
                    Panel2.Visible = true;
                }
                else
                {
                    LblIdCamp.Text = Session["IdCamp"].ToString();
                    DB_AP_Campanhia camp = new DB_AP_Campanhia();
                    AP_Campanhia ca = new AP_Campanhia();
                    ca = camp.DB_Buscar_CAMPANHIA(Convert.ToInt32(LblIdCamp.Text));
                    LblCamp.Text = ca.Nombre +" - "+ca.Region;
                    Panel3.Visible = true;
                    Desplegar_CAMPANIHA_PARAMETROS();
                    //Panel1.Visible = true;
                }
            }
        }
        #region FUNCIONES INDEPENDIENTES
        private void GenerarCamp()
        {
            if (TxtInicio.Text.Substring(6, 4) == TxtFinal.Text.Substring(6, 4))
            {
                LblCamp.Text = DDLCamp.SelectedItem.Text + " " + TxtInicio.Text.Substring(6, 4);
            }
            else
            {
                LblCamp.Text = DDLCamp.SelectedItem.Text + " " + TxtInicio.Text.Substring(6, 4) + "-" + TxtFinal.Text.Substring(6, 4);
            }
            TxtFinal.Enabled = false;
            TxtInicio.Enabled = false;
            DDLCamp.Enabled = false;
            DDLRegion.Enabled = false;
            BtnGeneraCamp.Enabled = false;
            Panel3.Visible = true;
        }
        #endregion
        #region FUNCION PARA DESPLEGAR LA LISTA DE LAS CAMPAÑIAS
        protected void Desplegar_CAMPANIHA()
        {
            DB_AP_Campanhia ListCamp = new DB_AP_Campanhia();

            GVCampaniha.DataSource = ListCamp.DB_Desplegar_CAMPANHIA();
            GVCampaniha.DataBind();
        }
        #endregion
        #region FUNCION PARA DESPLEGAR LA LISTA DE LAS CAMPAÑIAS
        protected void Desplegar_CAMPANIHA_PARAMETROS()
        {
            DB_AP_Registro_Org ListCamp = new DB_AP_Registro_Org();
            GVCampanihaParam.DataSource = ListCamp.DA_Desplegar_CAMPANHIA_PARAMETROS(Convert.ToInt32(LblIdCamp.Text));
            GVCampanihaParam.DataBind();
        }
        #endregion
        #region FUNCION PARA REGISTRAR CAMPAÑA
        protected void Registrar_CAMPANIHA()
        {
            DB_AP_Campanhia rc = new DB_AP_Campanhia();
            AP_Campanhia c = new AP_Campanhia();
            c.Nombre = LblCamp.Text;
            c.Fecha_Inicio = Convert.ToDateTime(TxtInicio.Text);
            c.Fecha_Final = Convert.ToDateTime(TxtFinal.Text);
            c.Region = DDLRegion.SelectedItem.Text;
            c.Estado = "INICIADO";
            rc.DA_Registrar_CAMPANHIA(c);
            DB_AP_Registro_Org maxid = new DB_AP_Registro_Org();
            LblIdCamp.Text = maxid.DB_MaxId("AP_CAMPANHIA", "Id_Campanhia");
        }
        #endregion
        #region FUNCION PARA REGISTRAR LOS PARAMETROS DEL PROGRAMA DE LA CAMPAÑA 
        protected void Registrar_CAMPANIHA_PARAM_PROG()
        {
                DB_AP_Parametros_Camp rpc = new DB_AP_Parametros_Camp();
                AP_ParametrosCamp pc = new AP_ParametrosCamp();
                pc.Id_Campanhia = Convert.ToInt32(LblIdCamp.Text);
                pc.Tipo_Produccion = DDLTipoProd.SelectedItem.Text;
                pc.Has_Min = Convert.ToDecimal(TxtHmin.Text);
                pc.Has_Max = Convert.ToDecimal(TxtHmax.Text);
                pc.Programa = DDLProg.SelectedItem.Text;
                pc.Estado = "ACTIVO";
                rpc.DA_Registrar_PARAMETRO_CAMP(pc);
        }
        #endregion
        #region EVENTO BOTON GENERA CAMPAÑIA
        protected void BtnGeneraCamp_Click(object sender, EventArgs e)
        {
            GenerarCamp();
            BtnRegistrarCamp.Text = "Registrar Campaña";
        }
        #endregion
        #region EVENTO BOTON REGISTRAR CAMPAÑA Y/O SUS PARAMETROS
        protected void BtnRegistrarCamp_Click(object sender, EventArgs e)
        {
           if (TxtHmin.Text != "")
            {
                if (TxtHmax.Text != "")
                {
                    if (Convert.ToDecimal(TxtHmax.Text) > Convert.ToDecimal(TxtHmin.Text))
                    {
                        if (BtnRegistrarCamp.Text == "Registrar Campaña")
                         {
                           Registrar_CAMPANIHA();
                           Registrar_CAMPANIHA_PARAM_PROG();
                         }
                        else
                         {
                           Registrar_CAMPANIHA_PARAM_PROG();
                         }
                         Desplegar_CAMPANIHA();
                         Desplegar_CAMPANIHA_PARAMETROS();
                    }
                    else 
                    {
                        LblMsj.Text = "La superficie máxima no puede ser menor a la superficie mínima";                    
                    }
                }
                else
                {
                    LblMsj.Text = "Error el campo de texto superficie máxima no puede estar vacío";
                }
            }
           else
            {
                LblMsj.Text = "Error el campo de texto superficie mínima no puede estar vacío";
            }
            
        }
        #endregion
        #region FUNCIONES DE LA GRILLA
        protected void GVCampaniha_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            switch (tipo)
            {
                case "Parametro":
                    LblCamp.Text=GVCampaniha.Rows[rowIndex].Cells[0].Text;
                    LblIdCamp.Text = GVCampaniha.Rows[rowIndex].Cells[5].Text;
                    BtnGeneraCamp.Enabled = false;
                    Panel2.Visible = true;
                    BtnRegistrarCamp.Text = "Registrar Programa";
                    break;
            }
        }
        #endregion

        protected void LnkIniciar_Click(object sender, EventArgs e)
        {
            //Panel1.Visible = true;
        }
    }
}