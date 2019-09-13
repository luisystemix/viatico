using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DataBusiness.DB_Viaticos;
using DataEntity.DE_Viaticos;
using System.Globalization;

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
                //Response.Redirect("~/About.aspx");
            }
        }
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Cargar_VALORES()
        {
            DB_VT_Solicitud memo = new DB_VT_Solicitud();
            DB_VT_Planilla pl = new DB_VT_Planilla();
            DataTable data = new DataTable();
            #region
            //data = pl.DB_Reporte_DETALLE_PLANILLA(LblIdSolicitud.Text, "DESTINOS");
            //LblDestino.Text = data.Rows[0][0].ToString();
            /**************************************************/
            ////DataTable data = new DataTable();
            #endregion
            data = memo.DB_Reporte_SOLICITUD_US(LblIdSolicitud.Text, "DETALLE");
            #region
            //if (data.Rows[0][3].ToString() == "Departamental")
            //{
            //    data = pl.DB_Reporte_DETALLE_PLANILLA(LblIdSolicitud.Text, "DESTINOS_LUGAR");
            //}
            //else
            //{
            //    data = pl.DB_Reporte_DETALLE_PLANILLA(LblIdSolicitud.Text, "DESTINOS");
            //}

            //LblDestino.Text = data.Rows[0][0].ToString();
            //ini lrojas 27072017: se modifico para obtener destino y lugar segun la zona
            #endregion
            string destinos = string.Empty;
            int fin = data.Rows.Count;
            int cont = 1;
            foreach (DataRow row in data.Rows)
            {
                string des = row["Zona"].ToString();
                string tramo = row["Tramo"].ToString();
                if (des == "Interdepartamental")
                {
                    if (tramo == "Salida")
                    {
                        if (cont == fin)
                        {
                            destinos = destinos + row["Destino"].ToString();
                        }
                        else
                        {
                            destinos = destinos + row["Destino"].ToString() + ", ";
                        }
                    }
                }
                else
                {
                    if (tramo == "Salida")
                    {
                        if (cont == fin)
                        {
                            destinos = destinos + row["Lugar"].ToString();
                        }
                        else
                        {
                            destinos = destinos + row["Lugar"].ToString() + ", ";
                        }
                    }

                }
                cont++;
            }

            LblDestino.Text = destinos;
            //fin lrojas 27072017: se modifico para obtener destino y lugar segun la zona

            /**************************************************/
            int contdias = 0;
            decimal totaldias = 0;
            decimal totaldias15 = 0;
            decimal total = 0;
            decimal total15 = 0;
            foreach (GridViewRow dgi in GVDetallePlanilla.Rows)
            {
                TextBox tx = (TextBox)dgi.Cells[5].Controls[1];
                decimal monto = Convert.ToDecimal(GVDetallePlanilla.Rows[dgi.RowIndex].Cells[6].Text);
                    //Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Monto"));
                DropDownList ddl = (DropDownList)dgi.Cells[3].Controls[1];
                contdias++;
                if (totaldias <= 9)
                {
                    if (ddl.SelectedItem.Text == "Interdepartamental")
                    {
                        total = total +  monto;
                        //total = total + ((Convert.ToDecimal(tx.Text) * Convert.ToDecimal(LblPgoDiaUrbano.Text)));
                        
                        Lbl100.Text = LblPgoDiaUrbano.Text;
                    }
                    else
                    {
                        total = total +  monto;
                        //total = total + ((Convert.ToDecimal(tx.Text) * Convert.ToDecimal(LblPgoDiaRural.Text)));
                        
                        Lbl100.Text = LblPgoDiaRural.Text;
                    }
                    totaldias = totaldias + Convert.ToDecimal(tx.Text);
                }
                else
                {
                    if (ddl.SelectedItem.Text == "Interdepartamental")
                    {
                        //total15 = total15 + ((((Convert.ToDecimal(tx.Text) * Convert.ToDecimal(LblPgoDiaUrbano.Text) * 70) / 100)));
                        total15 = total15 + (((monto * 70) / 100));
                    }
                    else
                    {
                        //total15 = total15 + ((((Convert.ToDecimal(tx.Text) * Convert.ToDecimal(LblPgoDiaRural.Text) * 70) / 100)));
                        total15 = total15 + ((( monto* 70) / 100));
                    }
                    totaldias15 = totaldias15 + Convert.ToDecimal(tx.Text);
                }
            }

            Lbl70.Text = Convert.ToString((Convert.ToDecimal(Lbl100.Text) * 70) / 100);
            //Lbl70.Text = string.Format("{0:N2}",(Convert.ToDecimal(Lbl100.Text)*70)/100);

            LblDiasCom15.Text = totaldias15.ToString();
            LblDiasCom.Text = totaldias.ToString(); 
            LblTotDias.Text = (totaldias + totaldias15).ToString();

            #region Lineas anterior que no permitia el redondeo correcto.
            //LblTotalMonto.Text = Convert.ToString(Math.Round(total, 0));
            //LblTotalMonto15.Text = Convert.ToString(Math.Round(total15, 0));
            //LblConIVA.Text = Convert.ToString(Math.Round(((total * 13) / 100), 0));
            //LblConIVA15.Text = Convert.ToString(Math.Round(((total15 * 13) / 100), 0));
            //LblLiquidoTotal.Text = Convert.ToString(Math.Round((total - ((total * 13) / 100)), 0));
            //LblLiquidoTotal15.Text = Convert.ToString(Math.Round((total15 - ((total15 * 13) / 100)), 0));
            //LblTotalPago.Text = Convert.ToString(Math.Round(((total - ((total * 13) / 100)) + (total15 - ((total15 * 13) / 100))), 0));
            //==================================================================================================
            #endregion
            decimal vTotal = Convert.ToDecimal(total);
            decimal vTotal15 = Convert.ToDecimal(total15);
            decimal vPctajeIva = Convert.ToDecimal((vTotal * 13)/ 100);
            decimal vPctajeIva15 = Convert.ToDecimal((vTotal15 * 13) / 100);

            LblTotalMonto.Text = Convert.ToString(Math.Round(total, 0)); //string.Format("{0:N2}",vTotal);
            LblTotalMonto15.Text = Convert.ToString(Math.Round(total15, 0)); //string.Format("{0:N2}", vTotal15);
            /*
            LblConIVA.Text = Convert.ToString(Math.Round(((total * 13) / 100), 0)); //string.Format("{0:N2}", vPctajeIva);
            LblConIVA15.Text = string.Format("{0:N2}", vPctajeIva15);
            LblLiquidoTotal.Text = string.Format("{0:N2}", vTotal - Convert.ToDecimal(LblConIVA.Text));
            LblLiquidoTotal15.Text = string.Format("{0:N2}", vTotal15 - Convert.ToDecimal(LblConIVA15.Text));
            */
            LblConIVA.Text = Convert.ToString(Math.Round(((total * 13) / 100), 0));
            LblConIVA15.Text = Convert.ToString(Math.Round(((total15 * 13) / 100), 0));
            LblLiquidoTotal.Text = Convert.ToString(Math.Round((total - ((total * 13) / 100)), 0));
            LblLiquidoTotal15.Text = Convert.ToString(Math.Round((total15 - ((total15 * 13) / 100)), 0));
            LblTotalPago.Text = Convert.ToString(Math.Round(((total - ((total * 13) / 100)) + (total15 - ((total15 * 13) / 100))), 0)); //string.Format("{0:N2}", (vTotal - Convert.ToDecimal(LblConIVA.Text) ) + (vTotal15 - Convert.ToDecimal(LblConIVA15.Text)  ));

            VT_Planilla plani = new VT_Planilla();
            if (LblEstado.Text == "INF-APROBADO")
            {
                plani = pl.DB_Seleccionar_PLANILLA(LblIdSolicitud.Text);
                TxtNumCheque.Text = plani.Num_Cheque;
                TxtNumCheque.Visible = true;
            }
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Cargar_ENCABEZADO()
        {
            VT_Cuenta cta = new VT_Cuenta();
            DB_VT_Planilla pl = new DB_VT_Planilla();
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            DataTable data = new DataTable();
            data = sol.DB_Reporte_SOLICITUD_US(LblIdSolicitud.Text, "ENCABEZADO");
            LblNombre.Text = data.Rows[0][12].ToString();
            LblEstado.Text = data.Rows[0][10].ToString();
            LblCargo.Text = data.Rows[0][4].ToString();
            LblCategoria.Text = data.Rows[0][14].ToString();
            LblIdUser.Text = data.Rows[0][1].ToString();
            DB_VT_Categoria cat = new DB_VT_Categoria();
            DataTable data1 = new DataTable(); 
            data1 = cat.DB_Seleccionar_CATEGORIA(Convert.ToInt32(LblCategoria.Text), data.Rows[0][2].ToString());
            LblMoneda.Text = data1.Rows[0][5].ToString();

            LblPgoDiaUrbano.Text = data1.Rows[0][3].ToString(); 
            
            LblPgoDiaRural.Text = data1.Rows[0][4].ToString();

            data = sol.DB_Reporte_SOLICITUD_US(LblIdSolicitud.Text, "FECHAMAXMIN");
            LblFechaSalida.Text = Convert.ToDateTime(data.Rows[0][0].ToString()).ToString("dd/MM/yyyy");
            LblFechaRetorno.Text = Convert.ToDateTime(data.Rows[0][1].ToString()).ToString("dd/MM/yyyy");

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
                if (fecha == LblFechaRetorno.Text || fecha == LblFechaSalida.Text)
                {
                    
                }
                else 
                {
                    e.Row.Cells[2].Text = "";
                }
            }
        }
        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (LblEstado.Text == "INF-APROBADO" || LblEstado.Text == "APROBADO")
            {
                DB_VT_Planilla ip = new DB_VT_Planilla();
                VT_Planilla p = new VT_Planilla();
                VT_PlanillaDia pd = new VT_PlanillaDia();
                p = ip.DB_Seleccionar_PLANILLA(LblIdSolicitud.Text);
                int idplanilla = p.Id_Planilla;
                p.Id_Solicitud = LblIdSolicitud.Text;
                p.Tot_Num_Dias = Convert.ToDecimal(LblDiasCom.Text);
                p.Tot_Num_Dias15 = Convert.ToDecimal(LblDiasCom15.Text);
                p.Pago_Total = Convert.ToDecimal(LblTotalMonto.Text);
                p.Pago_Total15 = Convert.ToDecimal(LblTotalMonto15.Text);
                p.Liquido_Pagable = Convert.ToDecimal(LblTotalPago.Text);
                p.Num_Cheque = TxtNumCheque.Text;
                p.Fecha_Atendido = DateTime.Now;
                p.MontoPorDia = Convert.ToDecimal(Lbl100.Text);
                ip.DB_Modificar_PLANILLA(p);
                int contador = 1;
                foreach (GridViewRow dgi in GVDetallePlanilla.Rows)
                {
                    TextBox tx = (TextBox)dgi.Cells[5].Controls[1];
                    TextBox tx1 = (TextBox)dgi.Cells[7].Controls[1];
                    DropDownList ddl = (DropDownList)dgi.Cells[3].Controls[1];
                    pd.Id_Planilla = p.Id_Planilla;
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
                sbMensaje.AppendFormat("window.open('{0}','Titulo','top=0,left=0,width=1000,height=600,scrollbars=yes,resizable=no,directories=no,location=no,menubar=no,status=no,Titlebar=yes,toolbar=no');", "../Viaticos/repPlanillaPago.aspx?ci=" + p.Id_Solicitud);
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
                if (ddl.SelectedItem.Text == "Interdepartamental")
                {
                    GVDetallePlanilla.Rows[dgi.RowIndex].Cells[6].Text = (Convert.ToDecimal(tx.Text) * Convert.ToDecimal(LblPgoDiaUrbano.Text)).ToString();
                    // var asignaDiaxPago = (Convert.ToDouble(tx.Text) * Convert.ToDouble(LblPgoDiaUrbano.Text)).ToString();
                    // GVDetallePlanilla.Rows[dgi.RowIndex].Cells[6].Text = String.Format("{0:N2}", Convert.ToDecimal(asignaDiaxPago));
                }
                else
                {
                    GVDetallePlanilla.Rows[dgi.RowIndex].Cells[6].Text = (Convert.ToDecimal(tx.Text) * Convert.ToDecimal(LblPgoDiaRural.Text)).ToString();
                    //var asignaDiaxPago = (Convert.ToDouble(tx.Text) * Convert.ToDouble(LblPgoDiaRural.Text)).ToString();
                    //double valor = Math.Round(Convert.ToDouble(asignaDiaxPago));
                    //GVDetallePlanilla.Rows[dgi.RowIndex].Cells[6].Text = String.Format("{0:N2}", Convert.ToDecimal(asignaDiaxPago));
                }
            }
                Cargar_VALORES();
        }
        protected void DDLZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow dgi in GVDetallePlanilla.Rows)
            {
                TextBox tx = (TextBox)dgi.Cells[5].Controls[1];
                DropDownList ddl = (DropDownList)dgi.Cells[3].Controls[1];
                if (ddl.SelectedItem.Text == "Interdepartamental")
                {
                    GVDetallePlanilla.Rows[dgi.RowIndex].Cells[6].Text = (Convert.ToDecimal(tx.Text) * Convert.ToDecimal(LblPgoDiaUrbano.Text)).ToString();
                }
                else
                {
                    GVDetallePlanilla.Rows[dgi.RowIndex].Cells[6].Text = (Convert.ToDecimal(tx.Text) * Convert.ToDecimal(LblPgoDiaRural.Text)).ToString();
                }
            }
            Cargar_VALORES();
        }
        protected void GVDetallePlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {

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