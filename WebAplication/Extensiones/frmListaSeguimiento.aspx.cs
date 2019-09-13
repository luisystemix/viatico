using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Threading;
using DataBusiness.DB_Registro;
using DataBusiness.DB_Extensiones;
using DataEntity.DE_Extensiones;

namespace WebAplication.Extensiones
{
    public partial class frmListaSeguimiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                  if (!IsPostBack)
                   {
                        LblIdInsOrg.Text = Session["IdInsOrg"].ToString();
                        LblIdInsProd.Text = Session["IdInsProd"].ToString();
                        LblIdUsuario.Text = Session["IdUser"].ToString();
                        LblEtapa.Text = Session["Etapa"].ToString();
                        LblId_Etapa.Text = Session["Id_Etapa"].ToString();//**LR
                        LblEstado.Text = Session["Estado"].ToString();
                        Datos_Org_ENCABEZADO();
                        Llenar_GVSEGUIMIENTO();
                        Llenar_DDLSEGUIMIENTO();
                        if (Convert.ToBoolean(LblEstado.Text) == true)
                        {
                            if(GVListaSeg.Rows.Count > 0)
                            {
                                DDLOpcion.Visible = false;
                                LblEtapa.Visible = true;
                                LblId_Etapa.Visible = true;
                                BtnRealizarSeg.Enabled = true;
                            }
                            else
                            {
                                //LblEtapa.Text = "VERIFICACION_PARCELA";
                                LblId_Etapa.Text = "1";
                                DDLOpcion.Visible = false;
                                LblEtapa.Visible = true;
                                LblId_Etapa.Visible = true;
                                BtnRealizarSeg.Enabled = true;
                            }
                        }
                        else
                        {
                             BtnRealizarSeg.Enabled = false;
                             DDLOpcion.Visible = true;
                             LblEtapa.Visible = false;
                             LblId_Etapa.Visible = false;
                        }
                    }
                }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region FUNCION PARA LLENAR DE REGITROS LA GRILLA
        private void Llenar_GVSEGUIMIENTO()
        {
            DB_EXT_Seguimiento ListSeg = new DB_EXT_Seguimiento();
            //GVListaSeg.DataSource = ListSeg.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg.Text), LblIdInsProd.Text, "","SEGUIMIENTO");
            //******************************TRATAMIENTO PARA LAS ETAPAS
            DB_EXT_Seguimiento ListSegPendiente = new DB_EXT_Seguimiento();
            DataTable dt = new DataTable();
            List<EXT_SeguimientoPendiente> LSP = ListSegPendiente.DB_Desplegar_SEGUIMIENTOS_PENDIENTE();            
            dt = ListSeg.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg.Text), LblIdInsProd.Text, "", "SEGUIMIENTO");
            //dt.Columns.Add("Id_Etapa", typeof(String));
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
                            break;
                            //fila["Id_Etapa"] = row.Id_Seguimiento_pendiente.ToString();
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
                            break;
                            //fila["Id_Etapa"] = row.Id_Seguimiento_pendiente.ToString();
                        }
                    }
                }
            }
            //******************************
            GVListaSeg.DataSource = dt;
            GVListaSeg.DataBind();
        }
        private void Llenar_DDLSEGUIMIENTO()
        {
            DB_EXT_Seguimiento ListSegPendiente = new DB_EXT_Seguimiento();
            //ListSegPendiente.DB_Desplegar_SEGUIMIENTOS_PENDIENTE();
            List<EXT_SeguimientoPendiente> LSP= ListSegPendiente.DB_Desplegar_SEGUIMIENTOS_PENDIENTE();
            DDLOpcion.DataSource = LSP;
            DDLOpcion.DataValueField = "Id_Seguimiento_pendiente";
            DDLOpcion.DataTextField = "Nombre";
            DDLOpcion.DataBind();
            DDLOpcion.Items.Insert(0, new ListItem("Seleccione Opción", "0", true));
            
        }
        #endregion
        #region FUNCIONES PARA CARGAR LOS DAOS DE LA ORGANIZACION
        private void Datos_Org_ENCABEZADO()
        {
            DB_AP_Registro_Org d_org = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = d_org.DB_Desplegar_ENCABEZADO_ORG(Convert.ToInt32(LblIdInsOrg.Text));
            LblOrg.Text = dt.Rows[0][2].ToString();
            LblIdCamp.Text = dt.Rows[0][5].ToString();
            LblProg.Text = dt.Rows[0][9].ToString();
            LblCamp.Text = dt.Rows[0][6].ToString();
            LblIdReg.Text = dt.Rows[0][7].ToString();
            DB_AP_Productor p = new DB_AP_Productor();
            dt = p.DB_Seleccionar_ENCABEZADO_PROD(LblIdInsProd.Text, "DATS_PROD");
            LblProductor.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString();
        }
        #endregion

        protected void DDLOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DDLOpcion.SelectedValue=="0")
            {
                LblMsj1.Text = "Debe seleccionar una opción de seguimiento";
                BtnRealizarSeg.Enabled = false;
            }
            else
            {
                //switch (LblEtapa.Text)
                switch (Convert.ToInt16(LblId_Etapa.Text))//LR
                {
                    case 1://"VERIFICACION_PARCELA"://LR
                        if (DDLOpcion.SelectedValue == "0")
                        {
                            LblMsj1.Text = "Tiene que seleccionar un valor para continuar";
                            BtnRealizarSeg.Enabled = false;
                        }
                        else 
                        {
                            BtnRealizarSeg.Enabled = true;
                            LblMsj1.Text = string.Empty;
                        }
                    break;
                    case 2://"VERIFICACION_SIEMBRA"://LR
                            if (DDLOpcion.SelectedValue == "1")//"VERIFICACION_PARCELA")//LR
                            {
                                LblMsj1.Text = "El sistema ya cuenta con el registro de la inspección";
                                BtnRealizarSeg.Enabled = false;
                            }
                            else
                            {
                              if(DDLOpcion.SelectedValue=="0")
                              {
                                  LblMsj1.Text = "Tiene que seleccionar un valor para continuar";
                                  BtnRealizarSeg.Enabled = false;
                              }
                              else
                              {
                                BtnRealizarSeg.Enabled = true;
                                LblMsj1.Text = string.Empty;
                              }
                            }
                    break;
                    case 3://"VERIFICACION_CULTIVO"://LR
                            if (DDLOpcion.SelectedValue == "1")//"VERIFICACION_PARCELA")//LR                            
                            {
                                LblMsj1.Text = "El sistema ya cuenta con un registro de la superficie declarada";
                                BtnRealizarSeg.Enabled = false;
                            }
                            else 
                            {
                                if (DDLOpcion.SelectedValue == "2") //"VERIFICACION_SIEMBRA")//LR                                
                                {
                                    LblMsj1.Text = "El sistema ya cuenta con un registro de la inspección de la siembra";
                                    BtnRealizarSeg.Enabled = false;
                                }
                                else
                                {
                                    if (DDLOpcion.SelectedValue == "0")
                                    {
                                        LblMsj1.Text = "Tiene que seleccionar un valor para continuar";
                                        BtnRealizarSeg.Enabled = false;
                                    }
                                    else
                                    {
                                        BtnRealizarSeg.Enabled = true;
                                        LblMsj1.Text = string.Empty;
                                    }
                                }
                            }
                    break;
                }
           }
        }
        protected void Enviar_ETAPA(int etapa) 
        {
            switch(etapa)
            {
                case 1: //"VERIFICACION_PARCELA":
                    Response.Redirect("frmParcelaCoordenadas.aspx");
                    break;
                case 2: //"VERIFICACION_SIEMBRA":
                    Response.Redirect("frmParcelaSiembra.aspx");
                    break;
                case 3: //"VERIFICACION_CULTIVO":
                    Response.Redirect("frmParcelaCultivo.aspx");
                    break;
            }
        }
        protected void BtnRealizarSeg_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(LblEstado.Text) == true)
            {
                Session.Add("Etapa", LblEtapa.Text);
            }
            else
            {
                LblEtapa.Text = DDLOpcion.SelectedItem.Text;
                LblId_Etapa.Text = DDLOpcion.SelectedValue;//**LR
                Session.Add("Etapa", LblEtapa.Text);
                Session.Add("Id_Etapa", LblId_Etapa.Text);//**LR

            }
            Enviar_ETAPA(Convert.ToInt16(LblId_Etapa.Text));//**LR
        }

        protected void GVListaSeg_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string tipo = Convert.ToString(e.CommandName);
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            StringBuilder sbMensaje = new StringBuilder();
            GVListaSeg.Columns[0].Visible = true;
            Llenar_GVSEGUIMIENTO();
            Session.Add("IdSeguimiento", GVListaSeg.Rows[rowIndex].Cells[0].Text);
            Session.Add("Etapa", GVListaSeg.Rows[rowIndex].Cells[1].Text);
            switch (tipo)
            {
                case "Reporte":
                    //sbMensaje.Append("<script type='text/javascript'>");
                    //sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repSeguimientosTecnicos.aspx?ci=" + GVListaSeg.Rows[rowIndex].Cells[0].Text);
                    //sbMensaje.Append("</script>");
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                    break;
                case "Modificar":
                    if (GVListaSeg.Rows[rowIndex].Cells[6].Text=="ENVIADO")
                    {
                        Response.Redirect("frmParcelaModificar.aspx");
                    }
                    else
                    {
                        LblMsj1.Text = "El seguimiento ya fue APROBADO, no se puede realizar modificaciones";
                    }
                    break;
            }
            GVListaSeg.Columns[0].Visible = false;
            Llenar_GVSEGUIMIENTO();
        }

        protected void ImgSegCultivo_Click(object sender, ImageClickEventArgs e)
        {
            
            Session.Add("IdUsuario", LblIdUsuario.Text);            
            //Session.Add("IdInsOrganizacion", LblIdInsOrg.Text);
            Session.Add("ProgramaSeleccionado", LblProg.Text);
            StringBuilder sbMensaje = new StringBuilder();
            //Response.Redirect("repSeguimientoCultivo.aspx", true);

            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1415,height=750,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repSeguimientoCultivo.aspx");
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
        }

        protected void ImgBoletaSeg_Click(object sender, ImageClickEventArgs e)
        {
            StringBuilder sbBoletaSeg = new StringBuilder();
            sbBoletaSeg.Append("<script type='text/javascript'>");
            sbBoletaSeg.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=900,height=750,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Extensiones/repBoletaSeguimiento.aspx");
            sbBoletaSeg.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbBoletaSeg.ToString());
        }
    }
}