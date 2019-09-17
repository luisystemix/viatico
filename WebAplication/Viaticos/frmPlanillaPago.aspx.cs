using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DataBusiness.DB_Viaticos;
using DataEntity.DE_Viaticos;

namespace WebAplication.Viaticos
{
    public partial class frmPlanillaPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdSolicitud.Text = Session["IdSolicitud"].ToString();
                    Cargar_ENCABEZADO();
                    Cargar_GRILLA();
                    Cargar_VALORES();
                    if (LblEstado.Text == "PROCESADO")
                    {
                        BtnAceptar.Enabled = false;
                    }
                }
            }
            catch(Exception ex)
            {
                string scriptf = @"<script type='text/javascript'>alert('{0}');</script>";
                scriptf = string.Format(scriptf, ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", scriptf, false);
                return;      
            }
        }
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Cargar_VALORES()
        {
                DB_VT_Solicitud memo = new DB_VT_Solicitud();
            DB_VT_Planilla pl = new DB_VT_Planilla();
            DataTable data = new DataTable();
            data = memo.DB_Reporte_SOLICITUD_US(LblIdSolicitud.Text, "DETALLE");
            string destinos = string.Empty;
            int fin = data.Rows.Count;
            int cont = 1;
            foreach (DataRow row in data.Rows)
            {
                string des = row["Zona"].ToString();
                string tramo = row["Tramo"].ToString();
                if (tramo == "Salida")
                {
                    destinos = cont == fin ? destinos + row["Lugar"].ToString() : destinos + row["Lugar"].ToString() + ", ";
                }               
                cont++;
            }

            LblDestino.Text = destinos;

            int contdias = 0;
            decimal totaldias = 0;
            decimal totaldias15 = 0;
            decimal monto = 0;
            decimal total = 0;
            decimal total15 = 0;
            foreach (GridViewRow dgi in GVDetallePlanilla.Rows)
            {
                TextBox tx = (TextBox)dgi.Cells[5].Controls[1];
                DropDownList ddl = (DropDownList)dgi.Cells[3].Controls[1];
                monto = Convert.ToDecimal(GVDetallePlanilla.Rows[dgi.RowIndex].Cells[6].Text);
                contdias++;
                if (totaldias <= 9)
                {
                    total = total + monto;
                    Lbl100.Text = ddl.SelectedItem.Text == "Interdepartamental" ? LblPgoDiaUrbano.Text : LblPgoDiaRural.Text;
                    totaldias = totaldias + Convert.ToDecimal(tx.Text);
                }
                else
                {
                    total15 = total15 + (((monto * 70) / 100));
                    totaldias15 = totaldias15 + Convert.ToDecimal(tx.Text);
                }
            }

            Lbl70.Text = Convert.ToString((Convert.ToDecimal(Lbl100.Text)*70)/100);

            LblDiasCom15.Text = totaldias15.ToString();
            LblDiasCom.Text = totaldias.ToString(); 
            LblTotDias.Text = (totaldias + totaldias15).ToString();

            LblTotalMonto.Text = Convert.ToString(Math.Round(total,0));
            LblTotalMonto15.Text = Convert.ToString(Math.Round(total15,0));

            total15=total = 0;  // QUITA EL RC IVA 13%

            LblConIVA.Text = Convert.ToString(Math.Round(((total * 13) / 100),0));
            LblConIVA15.Text = Convert.ToString(Math.Round(((total15 * 13) / 100),0));

            LblConIVA.Visible = LblConIVA15.Visible = false;    //OCULTA LOS CONTROLES DONDE APARECE EL DESCUENTO DEL RC IVA 13%

            LblLiquidoTotal.Text = (Convert.ToInt32(LblTotalMonto.Text) - Convert.ToInt32(LblConIVA.Text)).ToString();
            LblLiquidoTotal15.Text = (Convert.ToInt32(LblTotalMonto15.Text) - Convert.ToInt32(LblConIVA15.Text)).ToString();

            LblTotalPago.Text = (Convert.ToInt32(LblLiquidoTotal.Text) + Convert.ToInt32(LblLiquidoTotal15.Text)).ToString();
            VT_Planilla plani = new VT_Planilla();
            if (LblEstado.Text == "INF-APROBADO")
            {
                plani = pl.DB_Seleccionar_PLANILLA(LblIdSolicitud.Text);
                TxtNumCheque.Text = plani.Num_Cheque;
                TxtNumCheque.Visible = true;
            }
        }
        protected void vaciadoaControles()
        {
            //REGISTRO DE CATEGORIA -SP:DB_Reporte_SOLICITUD_US -PARAMETER:ENCABEZADO
            DataTable dataEncabezado = new DataTable();
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            dataEncabezado= sol.DB_Reporte_SOLICITUD_US(LblIdSolicitud.Text, "ENCABEZADO");
            LblNombre.Text = dataEncabezado.Rows[0][12].ToString();
            LblEstado.Text = dataEncabezado.Rows[0][10].ToString();
            LblCargo.Text = dataEncabezado.Rows[0][4].ToString();
            LblCategoria.Text = dataEncabezado.Rows[0][14].ToString();
            LblIdUser.Text = dataEncabezado.Rows[0][1].ToString();
            string valorTipo = dataEncabezado.Rows[0][2].ToString();

            //REGISTRO DE CATEGORIA -SP:DB_Seleccionar_CATEGORIA
            DB_VT_Categoria categoria = new DB_VT_Categoria();
            DataTable dataCategoria = new DataTable();
            dataCategoria = categoria.DB_Seleccionar_CATEGORIA(Convert.ToInt32(LblCategoria.Text), valorTipo);
            LblMoneda.Text = dataCategoria.Rows[0][5].ToString();
            LblPgoDiaUrbano.Text = dataCategoria.Rows[0][3].ToString();
            LblPgoDiaRural.Text = dataCategoria.Rows[0][4].ToString();

            //REGISTRO DE REPORTE SOLICITUD - SP:DB_Reporte_SOLICITUD_US -PARAMETER:FECHAMAXMIN
            DataTable dataSolFechaMaxMin = new DataTable();
            dataSolFechaMaxMin = sol.DB_Reporte_SOLICITUD_US(LblIdSolicitud.Text, "FECHAMAXMIN");
            LblFechaSalida.Text = Convert.ToDateTime(dataSolFechaMaxMin.Rows[0][0].ToString()).ToString("dd/MM/yyyy");
            LblFechaRetorno.Text = Convert.ToDateTime(dataSolFechaMaxMin.Rows[0][1].ToString()).ToString("dd/MM/yyyy");
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Cargar_ENCABEZADO()
        {
            VT_Cuenta cta = new VT_Cuenta();
            DB_VT_Planilla pl = new DB_VT_Planilla();
            this.vaciadoaControles();
            if (LblEstado.Text == "APROBADO")
            {
                cta = pl.DB_Seleccionar_CUENTA(LblIdUser.Text);                              
                TxtNumCheque.Text = cta.Cuenta;
            }
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Cargar_GRILLA()
        {
            DB_VT_Planilla pl = new DB_VT_Planilla();
            GVDetallePlanilla.DataSource = pl.DB_Reporte_DETALLE_PLANILLA(LblIdSolicitud.Text, "DETALLEDIAS");
            GVDetallePlanilla.DataBind();
        }
        #endregion
        protected void GVDetallePlanilla_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((TextBox)e.Row.FindControl("TxtObser")).Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Observacion"));
                ((TextBox)e.Row.FindControl("TxtNumDias")).Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Num_Dias"));
                ((DropDownList)e.Row.FindControl("DDLZona")).Items.Insert(0, new ListItem(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Area")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Area")), true));
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string fecha = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FechaDia")).ToString("dd/MM/yyyy");
                if (fecha != LblFechaRetorno.Text && fecha != LblFechaSalida.Text)
                {
                    e.Row.Cells[2].Text = "";
                }               
            }
        }
        public VT_Planilla LlenadoPlanilla(string idSolicitud, DB_VT_Planilla ip, ref int idplanilla)
        {
            VT_Planilla regPlanilla = new VT_Planilla();
            regPlanilla = ip.DB_Seleccionar_PLANILLA(idSolicitud);
            idplanilla = regPlanilla.Id_Planilla;
            regPlanilla.Id_Solicitud = idSolicitud;
            regPlanilla.Tot_Num_Dias = Convert.ToDecimal(LblDiasCom.Text);
            regPlanilla.Tot_Num_Dias15 = Convert.ToDecimal(LblDiasCom15.Text);
            regPlanilla.Pago_Total = Convert.ToDecimal(LblTotalMonto.Text);
            regPlanilla.Pago_Total15 = Convert.ToDecimal(LblTotalMonto15.Text);
            regPlanilla.Liquido_Pagable = Convert.ToDecimal(LblTotalPago.Text);
            regPlanilla.Num_Cheque = TxtNumCheque.Text;
            regPlanilla.Fecha_Atendido = DateTime.Now;
            regPlanilla.MontoPorDia = Convert.ToDecimal(Lbl100.Text);
            return regPlanilla;
        }
        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            int idplanilla = 0;
            string idSolicitud = string.Empty;
            if (LblEstado.Text == "INF-APROBADO" || LblEstado.Text == "APROBADO")
            {
                DB_VT_Planilla ip = new DB_VT_Planilla();
                VT_PlanillaDia pd = new VT_PlanillaDia();
                ip.DB_Modificar_PLANILLA(this.LlenadoPlanilla(LblIdSolicitud.Text, ip, ref idplanilla));

                int contador = 1;
                foreach (GridViewRow dgi in GVDetallePlanilla.Rows)
                {
                    TextBox tx = (TextBox)dgi.Cells[5].Controls[1];
                    TextBox tx1 = (TextBox)dgi.Cells[7].Controls[1];
                    DropDownList ddl = (DropDownList)dgi.Cells[3].Controls[1];
                    pd.Id_Planilla = idplanilla;
                    pd.Cont = contador;
                    pd.Num_Dias = Convert.ToDecimal(tx.Text);
                    pd.Area = ddl.SelectedItem.Text;
                    pd.Destino = GVDetallePlanilla.Rows[dgi.RowIndex].Cells[4].Text;
                    pd.Monto = Convert.ToDecimal(GVDetallePlanilla.Rows[dgi.RowIndex].Cells[6].Text);
                    pd.Observacion = tx1.Text;
                    ip.DB_Modificar_PLANILLA_DIA(pd);
                    contador++;
                }
                DB_VT_Solicitud s = new DB_VT_Solicitud();
                s.DB_Cambiar_ESTADO(LblIdSolicitud.Text, "PROCESADO");
                BtnAceptar.Enabled = false;
                StringBuilder sbMensaje = new StringBuilder();
                sbMensaje.Append("<script type='text/javascript'>");
                //sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repPlanillaPago.aspx?ci=" + p.Id_Solicitud);
                sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repPlanillaPago.aspx?ci=" + LblIdSolicitud.Text);
                sbMensaje.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                //Response.Redirect("frmRevisarInformes.aspx");
            }
            else
            {
                Response.Write("<script>window.alert('No se puede procesar su planilla de pago, por que NO se tiene un informe de viaje APROBADO.');</script>");
            }
        }
        protected void TxtNumDias_TextChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow dgi in GVDetallePlanilla.Rows)
            {
                TextBox tx = (TextBox)dgi.Cells[5].Controls[1];
                DropDownList ddl = (DropDownList)dgi.Cells[3].Controls[1];
                string pgoDiaUrbanoRural = ddl.SelectedItem.Text == "Interdepartamental" ? LblPgoDiaUrbano.Text : LblPgoDiaRural.Text;
                GVDetallePlanilla.Rows[dgi.RowIndex].Cells[6].Text = string.Format("{0:n2}", (Convert.ToDecimal(tx.Text) * Convert.ToDecimal(pgoDiaUrbanoRural)));
            }
                Cargar_VALORES();
        }
        protected void DDLZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow dgi in GVDetallePlanilla.Rows)
            {
                TextBox tx = (TextBox)dgi.Cells[5].Controls[1];
                DropDownList ddl = (DropDownList)dgi.Cells[3].Controls[1];
                string pgoDiaUrbanoRural = ddl.SelectedItem.Text == "Interdepartamental"? LblPgoDiaUrbano.Text: LblPgoDiaRural.Text;
                GVDetallePlanilla.Rows[dgi.RowIndex].Cells[6].Text = 
                                (Convert.ToDecimal(tx.Text) * Convert.ToDecimal(pgoDiaUrbanoRural)).ToString();               
            }
            Cargar_VALORES();
        }
        protected void ImgBtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            if (LblEstado.Text == "PROCESADO")
            {
                Session.Add("IdSolicitud", LblIdSolicitud.Text);
                StringBuilder sbMensaje = new StringBuilder();
                sbMensaje.Append("<script type='text/javascript'>");
                sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repPlanillaPago.aspx?ci=" + LblIdSolicitud.Text);
                sbMensaje.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensaje", sbMensaje.ToString());
                LblMsj.Text = string.Empty;
            }
            else
            {
                LblMsj.Text="Para poder ver el reporte, tiene que procesar la planilla de pago";
            }
        }
        protected void DDLCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            VT_Cuenta cta = new VT_Cuenta();
            DB_VT_Planilla pl = new DB_VT_Planilla();
            if (DDLCuenta.SelectedValue == "N° Cuenta")
            {
                cta = pl.DB_Seleccionar_CUENTA(LblIdUser.Text);
                TxtNumCheque.Text = cta.Cuenta;
            }
            else
            {
                TxtNumCheque.Text = string.Empty;
            }
        }
    }
}