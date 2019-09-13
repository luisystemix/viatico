using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataBusiness.DB_Registro;
using DataEntity.DE_Registro;
using DataBusiness.DB_General;
using DataEntity.DE_Extensiones;
using DataBusiness.DB_Extensiones;

namespace WebAplication.Extensiones
{
    public partial class frmDesignarOrgTPE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdCamp.Text = Session["IdCamp"].ToString();
                    LblMuestra.Text = Session["Muestra"].ToString();
                    LblNumProd.Text = Session["NumProd"].ToString();
                    LblRegional.Text = Session["Reg"].ToString();
                    LblIdReg.Text = Session["IdReg"].ToString();
                    DB_AP_Campanhia cmp = new DB_AP_Campanhia();
                    AP_Campanhia c = new AP_Campanhia();
                    c = cmp.DB_Buscar_CAMPANHIA(Convert.ToInt32(LblIdCamp.Text));
                    LblCamp.Text = c.Nombre;
                    LblIdUser.Text = Session["IdUser"].ToString();
                    LblProg.Text = Session["Prog"].ToString();
                    //Desplegar_USUARIO();
                    Llenar_DDLPERSONAL_REGIONAL();
                    Llenar_GVORG_REG_CAMP();
                    Llenar_GVDESIGNADO();
                    //LblMunTec.Text = GVDesignado.Rows.Count.ToString();
                    //Actualizar_NUM_PROD();
                }
            }
            catch 
            {
                Response.Redirect("~/About.aspx");
            }
                //Actualizar_NUM_PROD();
        }
        //#region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        //protected void Desplegar_USUARIO()
        //{
        //    DB_AP_Registro_Org Usuario = new DB_AP_Registro_Org();
        //    DataTable dt = new DataTable();
        //    dt = Usuario.DB_Desplegar_USUARIO(LblIdUser.Text);
        //    LblRegional.Text = dt.Rows[0][5].ToString();
        //    LblIdReg.Text = dt.Rows[0][4].ToString();
        //}
        //#endregion
        #region FUNCION PARA LLENAR EL COMBO CON TODOS LOS USUARIOS
        private void Llenar_DDLPERSONAL_REGIONAL()
        {
            DB_Usuario tec = new DB_Usuario();
            DataTable List = new DataTable();
            List = tec.DB_Desplegar_USUARIO(Convert.ToInt32(LblIdReg.Text), "jose", "POR-REGIONAL");
            DDLTecnicos.DataSource = List;
            DDLTecnicos.DataValueField = "Id_Usuario";
            DDLTecnicos.DataTextField = "Persona";     
            DDLTecnicos.DataBind();
        }
        #endregion
        #region FUNCION PARA LLENARLA GRILLA
        private void Llenar_GVORG_REG_CAMP()
        {
            DB_AP_InscripcionOrg ListOrg = new DB_AP_InscripcionOrg();
            GVOrg.DataSource = ListOrg.DB_Desplegar_ORG_REG_CAMP("LISTORGCAMPREG",0 , Convert.ToInt32(LblIdReg.Text),Convert.ToInt32(LblIdCamp.Text), LblProg.Text);
            GVOrg.DataBind();
        }
        private void Llenar_GVDESIGNADO()
        {
            DB_EXT_DesignacionOrg ListDesOrg = new DB_EXT_DesignacionOrg();
            GVDesignado.DataSource = ListDesOrg.DB_Seleccionar_DESIGNACION_ORG(Convert.ToInt32(LblIdReg.Text), Convert.ToInt32(LblIdCamp.Text), "", LblProg.Text, "ASIGNADOS");
            GVDesignado.DataBind();
        }
        #endregion
        #region FUNCIONES DEL COMBO
        protected void DDLPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_GVORG_REG_CAMP();
            Llenar_GVDESIGNADO();
        }

        protected void DDLCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_GVORG_REG_CAMP();
        }
        #endregion
        #region FUNCIONES DE LA GRILLA
        protected void GVOrg_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DB_AP_InscripcionOrg io = new DB_AP_InscripcionOrg();
            DataTable dt = new DataTable();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string valor = DataBinder.Eval(e.Row.DataItem, "Id_InscripcionOrg").ToString();
                int num=Convert.ToInt32(valor);
                dt = io.DB_Obtener_SUM_HA_NUM_PROD(num, "CONTADOR-OFICIAL");
                e.Row.Cells[6].Text = dt.Rows[0][0].ToString();
                dt = io.DB_Obtener_SUM_HA_NUM_PROD(num, "OFICIAL");
                if(dt.Rows[0][0].ToString()=="")
                {
                    e.Row.Cells[7].Text = "0";
                }
                else
                {
                    e.Row.Cells[7].Text = dt.Rows[0][0].ToString();
                }
            }
        }
        #endregion
        #region FUNCIONES DE REGISTRO DE LA ASIGNACION
        protected void BtnDesignar_Click(object sender, EventArgs e)
        {
            int aux = 0;
            if (LblTecnico.Text != "")
            {
                EXT_DesignacionOrg DsOrg = new EXT_DesignacionOrg();
                DB_EXT_DesignacionOrg ins = new DB_EXT_DesignacionOrg();
                CheckBox myCheckBox = new CheckBox();
                foreach (GridViewRow dgi in GVOrg.Rows)
                {
                    myCheckBox = (CheckBox)dgi.Cells[8].Controls[1];
                    if (myCheckBox.Checked == true)
                    {
                        GVOrg.Columns[0].Visible = true;
                        Llenar_GVORG_REG_CAMP();
                        DsOrg.Id_Usuario = DDLTecnicos.SelectedValue;
                        DsOrg.Id_InscripcionOrg = Convert.ToInt32(GVOrg.Rows[dgi.RowIndex].Cells[0].Text);
                        GVOrg.Columns[0].Visible = false;
                        Llenar_GVORG_REG_CAMP();
                        DsOrg.Num_Productores = 0;
                        DsOrg.Superficie = Convert.ToDecimal(GVOrg.Rows[dgi.RowIndex].Cells[7].Text);
                        DsOrg.Estado = "SELECCIONADO";
                        ins.DA_Registrar_DESIGNACION_ORG(DsOrg);
                        aux = 1;
                    }
                }
                if (aux == 0)
                {
                    LblMsj.Text = "Debe seleccionar una organización para designar  al técnico";
                }
                else
                {
                    LblMsj.Text = string.Empty;
                }
            }
            else 
            {
                LblMsj.Text = "Debe seleccionar un técnico para continuar";
            }
            Llenar_GVDESIGNADO();
        }
        #endregion
        #region FUNCION PARA MODIFICAR LA TABLA MUESTRA
        private void Actualizar_DESIGNACION_ESTADO()
        {
            GVDesignado.Columns[9].Visible = true;
            GVDesignado.Columns[10].Visible = true;
            Llenar_GVDESIGNADO();
            DB_EXT_DesignacionOrg ListDesOrg = new DB_EXT_DesignacionOrg();
            foreach (GridViewRow dgi in GVDesignado.Rows)
            {
                ListDesOrg.DB_Actualizar_NUM_PROD(Convert.ToInt32(GVDesignado.Rows[dgi.RowIndex].Cells[10].Text), 0, GVDesignado.Rows[dgi.RowIndex].Cells[9].Text, "ASIGNADO", "MODIF_MUESTRA_PROD");
            }
            GVDesignado.Columns[9].Visible = false;
            GVDesignado.Columns[10].Visible = false;
            Llenar_GVDESIGNADO();
        }
        #endregion
        #region FUNCION PARA MODIFICAR LA TABLA MUESTRA
        private void  Modificar_MUESTRA(int numero)
        {
            DB_EXT_DesignacionProd mus = new DB_EXT_DesignacionProd();
            DataTable dt = new DataTable();
            dt = mus.DB_Desplegar_MUESTRA(Convert.ToInt32(LblIdCamp.Text), Convert.ToInt32(LblIdReg.Text), LblProg.Text, "MUESTRA");
            EXT_MuestraSeguimiento m = new EXT_MuestraSeguimiento();
            m.Id_Muestra=Convert.ToInt32(dt.Rows[0][9].ToString());
            m.Num_Org=Convert.ToInt32(dt.Rows[0][3].ToString());
            m.Num_Prod=Convert.ToInt32(dt.Rows[0][4].ToString());
            m.Num_Muestra=Convert.ToInt32(dt.Rows[0][5].ToString());
            m.Num_Tecnicos= Convert.ToInt32(dt.Rows[0][6].ToString())+numero;
            mus.DB_Modificar_MUESTRA(m);
        }
        #endregion
        protected void ImgPrint_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("Prog", LblProg.Text);
            Session.Add("IdCamp", LblIdCamp.Text);
            Session.Add("IdReg", LblIdReg.Text);
            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repDesignacionOrgTPE.aspx?ci=" + LblIdReg.Text);
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
        }
        protected void LnkBtnSeleccionar_Click(object sender, EventArgs e)
        {
            DB_Usuario us = new DB_Usuario();
            DataTable dt = new DataTable();
            dt = us.DB_Desplegar_USUARIO(Convert.ToInt32(LblIdReg.Text), DDLTecnicos.SelectedValue, "USUARIO");
            LblTecnico.Text = dt.Rows[0][10].ToString();
            LblCargo.Text = dt.Rows[0][5].ToString();
        }

        protected void GVDesignado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DB_EXT_DesignacionOrg d = new DB_EXT_DesignacionOrg();
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GVDesignado.Columns[9].Visible = true;
            GVDesignado.Columns[10].Visible = true;
            Llenar_GVDESIGNADO();
            switch (tipo)
            {
                case "Eliminar":
                    d.DB_Eliminar_DESIGNACION_ORG(GVDesignado.Rows[rowIndex].Cells[9].Text, Convert.ToInt32(GVDesignado.Rows[rowIndex].Cells[10].Text));
                    break;
            }
            GVDesignado.Columns[9].Visible = false;
            GVDesignado.Columns[10].Visible = false;
            Llenar_GVDESIGNADO();
        }

        protected void DDLTecnicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Llenar_GVDESIGNADO();
        }
        protected void TxtNumProd_TextChanged(object sender, EventArgs e)
        {
            int aux=0;
            foreach (GridViewRow dgi in GVDesignado.Rows)
             {
                TextBox tx = (TextBox)dgi.Cells[8].Controls[1];
                aux = aux + Convert.ToInt32(tx.Text);
                if (aux <= Convert.ToInt32(LblMuestra.Text))
                {
                    LblTotal.Text = aux.ToString();
                    LblMsj1.Text = string.Empty;
                }
                else 
                {
                    LblMsj1.Text = "¡¡¡Sobrepaso el número de productores estipulados por la MUESTRA!!!";
                    ((TextBox)dgi.Cells[8].Controls[1]).Text = "0";
                }
             }
        }
        protected void BtnEnviarDesignacion_Click(object sender, EventArgs e)
        {
               Actualizar_DESIGNACION_ESTADO();
               LblMsj1.Text = string.Empty;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            LblMsj.Text = "HOLAAAAAAAAAAAAAAAAAAAAA";
        }
    }
}