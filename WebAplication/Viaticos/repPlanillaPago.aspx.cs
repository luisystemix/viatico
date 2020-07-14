using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Viaticos;
using DataEntity.DE_Viaticos;

namespace WebAplication.Viaticos
{
    public partial class repPlanillaPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdSolicitud.Text = Session["IdSolicitud"].ToString();
                    LblFechaActual.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    
                    Cargar_ENCABEZADO();
                    Cargar_GRILLA();
                    Cargar_VALORES();
                }
            }
            catch 
            {
                Response.Redirect("~/About.aspx");
            }
        }
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Cargar_VALORES()
        {
            DB_VT_Solicitud memo = new DB_VT_Solicitud();
            DB_VT_Planilla pl = new DB_VT_Planilla();
            DataTable data = new DataTable();
            //data = pl.DB_Reporte_DETALLE_PLANILLA(LblIdSolicitud.Text, "DESTINOS");
            //LblDestino.Text = data.Rows[0][0].ToString();
            /**************************************************/
            data = memo.DB_Reporte_SOLICITUD_US(LblIdSolicitud.Text, "DETALLE");
            #region comentado
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
            /*****************************************************/
            data = pl.DB_Reporte_DETALLE_PLANILLA(LblIdSolicitud.Text, "DIASMONTO");            
            //Lbl100.Text = data.Rows[0][12].ToString();
            //Lbl70.Text = Convert.ToString((Convert.ToDecimal(data.Rows[0][12].ToString()) * 70) / 100)

            //*ini* lrojas: 26/09/2016
            decimal Monto_1 = (Math.Round(Convert.ToDecimal(data.Rows[0][12].ToString()), 0)); 
            //decimal Monto = Convert.ToDecimal(data.Rows[0][12].ToString());            
            string AlCien = string.Format("{0:n0}", (Math.Truncate(Monto_1 * 100) / 100));    //string.Format("{0:N2}", (Monto_1 * 100) / 100);            
            Lbl100.Text = AlCien;
            decimal Monto2 = ((Monto_1 * 70) / 100);
            string AlSetenta = string.Format("{0:n0}", (Math.Truncate(Monto2 * 100) / 100));
            //string AlSetenta = string.Format("{0:N2}", Convert.ToDecimal((Monto2 * 100) / 100));
            
            Lbl70.Text = AlSetenta;
            #region
            //*fin*           
            //LblDiasCom.Text = data.Rows[0][2].ToString();
            //LblDiasCom10.Text = data.Rows[0][3].ToString();

            //decimal DiasC = (Math.Round(Convert.ToDecimal(data.Rows[0][2].ToString()), 0));
            //string DiasC_S = string.Format("{0:n0}", (Math.Truncate(DiasC * 100) / 100));
            //LblDiasCom.Text = DiasC_S;
            #endregion
            LblDiasCom.Text = Convert.ToDecimal(data.Rows[0][2].ToString()).ToString();

            /*decimal DiasC10 = (Math.Round(Convert.ToDecimal(data.Rows[0][3].ToString()), 0));
            string DiasC10_S = string.Format("{0:n0}", (Math.Truncate(DiasC10 * 100) / 100));
            LblDiasCom10.Text = DiasC10_S;*/

            LblDiasCom10.Text = Convert.ToDecimal(data.Rows[0][3].ToString()).ToString();

            //LblTotalMonto.Text = Convert.ToString(Math.Round((Convert.ToDecimal(Lbl100.Text) * Convert.ToDecimal(LblDiasCom.Text)),0));
            /*****************************/
            int contdias = 0;
            decimal totaldias = 0;
            decimal total = 0;
            decimal total15 = 0;
            foreach (GridViewRow dgi in GVDetallePlanilla.Rows)
            {
                //TextBox tx = (TextBox)dgi.Cells[5].Controls[1];
                decimal monto = Convert.ToDecimal(GVDetallePlanilla.Rows[dgi.RowIndex].Cells[6].Text);
                //Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Monto"));
                //DropDownList ddl = (DropDownList)dgi.Cells[3].Controls[1];
                contdias++;
                if (totaldias <= 9)
                {
                    if (GVDetallePlanilla.Rows[dgi.RowIndex].Cells[3].Text == "Interdepartamental")
                    {
                        total = total + monto;
                    }
                    else
                    {
                        total = total + monto;
                    }
                    totaldias = totaldias + Convert.ToDecimal(GVDetallePlanilla.Rows[dgi.RowIndex].Cells[5].Text);
                }
                else
                {
                    if (GVDetallePlanilla.Rows[dgi.RowIndex].Cells[3].Text == "Interdepartamental")
                    {
                        total15 = total15 + (((monto * 70) / 100));
                    }
                    else
                    {
                        total15 = total15 + (((monto * 70) / 100));
                    }
                }
            }
            /**********************/
            //*ini* lrojas 26/09/2016
            //LblTotalMonto.Text = Convert.ToString(Math.Round(total, 0));            
            decimal TotalMonto = (Math.Round(total, 0)); //total;
            string TMonto = string.Format("{0:n0}", (Math.Truncate(TotalMonto * 100) / 100)); //string.Format("{0:N2}", (TotalMonto * 100) / 100);
            LblTotalMonto.Text = TMonto;
            //*fin*
    
            if (Convert.ToDecimal(LblDiasCom10.Text)==0)
            {
                LblTotalMonto10.Text = "0";
            }
            else
            {
                //LblTotalMonto10.Text = Convert.ToString(Math.Round(total,0));   //MI REVISION JLAH
                //LblTotalMonto10.Text = Convert.ToString(Math.Round(total15, 0));

                //*ini* lrojas 26/09/2016                
                decimal tm10 = (Math.Round(total15, 0)); //total15;
                string tm10s = string.Format("{0:n0}", (Math.Truncate(tm10 * 100) / 100)); //string.Format("{0:N2}", (tm10 * 100) / 100);
                LblTotalMonto10.Text = tm10s;
                //*fin*
            }
            #region
            //*ini* lrojas 26/09/2016
            //LblConIVA.Text = Convert.ToString(Math.Round(((Convert.ToDecimal(LblTotalMonto.Text) * Convert.ToDecimal(data.Rows[0][6]))/100),0));
            //LblConIVA10.Text = Convert.ToString(Math.Round(((Convert.ToDecimal(LblTotalMonto10.Text) * Convert.ToDecimal(data.Rows[0][6]))/100),0));

            //decimal iva = Math.Round(((Convert.ToDecimal(LblTotalMonto.Text) * Convert.ToDecimal(data.Rows[0][6])) / 100), 0);
            #endregion

            //decimal v13Porciento = Convert.ToDecimal(data.Rows[0][6]);
            //decimal valorpcte = Math.Round((Convert.ToDecimal(LblTotalMonto.Text) * v13Porciento / 100),2);
            //decimal valorMonto10 = Convert.ToDecimal(LblTotalMonto10.Text) * v13Porciento/100;
            //string iva = valorpcte.ToString();
            //LblConIVA.Text = iva;
            //decimal Ltotal = Convert.ToDecimal(LblTotalMonto.Text) - Convert.ToDecimal(iva);
            //LblLiquidoTotal.Text = string.Format("{0:N2}", (Ltotal * 100) / 100);

            //decimal iva10 = Math.Round((Convert.ToDecimal(LblTotalMonto10.Text) * v13Porciento / 100), 2); //valorMonto10 / 100;
            //LblConIVA10.Text = iva10.ToString();  // string.Format("{0:N2}", (iva10 * 100) / 100);
            //decimal Ltotal10 = Convert.ToDecimal(LblTotalMonto10.Text) - Convert.ToDecimal(LblConIVA10.Text);
            //LblLiquidoTotal10.Text = string.Format("{0:N2}", (Ltotal10 * 100) / 100);

            //#region
            ////LblLiquidoTotal.Text = Convert.ToString(Math.Round((Convert.ToDecimal(LblTotalMonto.Text)-Convert.ToDecimal(LblConIVA.Text)), 0));
            ////LblLiquidoTotal10.Text = Convert.ToString(Math.Round(Convert.ToDecimal(LblTotalMonto10.Text)-Convert.ToDecimal(LblConIVA10.Text), 0));
            ////var diferencia = string.Format("{0:N2}",(Convert.ToDecimal(LblTotalMonto.Text) - Convert.ToDecimal(LblConIVA10.Text)).ToString());
            //#endregion
            ////LblTotalPago.Text = Convert.ToString(Math.Round(Convert.ToDecimal(data.Rows[0][7]),0));
            //decimal TPago = Convert.ToDecimal(data.Rows[0][7]);
            //LblTotalPago.Text = string.Format("{0:N2}", (TPago * 100) / 100);


            //decimal iva = Math.Round(((Convert.ToDecimal(LblTotalMonto.Text) * Convert.ToDecimal(data.Rows[0][6])) / 100), 0);
            //PARA NO DESCONTAR IVA
            decimal iva = 0;
            LblConIVA.Text = string.Format("{0:n0}", (Math.Truncate(iva * 100) / 100));

            //decimal iva10 = Math.Round(((Convert.ToDecimal(LblTotalMonto10.Text) * Convert.ToDecimal(data.Rows[0][6])) / 100), 0);
            //PARA NO DESCONTAR IVA
            decimal iva10 = 0;
            LblConIVA10.Text = string.Format("{0:n0}", (Math.Truncate(iva10 * 100) / 100));
            //OCULTAR MONTOS DE DESCUENTO
            LblConIVA.Visible = LblConIVA10.Visible = false;

            //LblLiquidoTotal.Text = Convert.ToString(Math.Round((Convert.ToDecimal(LblTotalMonto.Text)-Convert.ToDecimal(LblConIVA.Text)), 0));
            //LblLiquidoTotal10.Text = Convert.ToString(Math.Round(Convert.ToDecimal(LblTotalMonto10.Text)-Convert.ToDecimal(LblConIVA10.Text), 0));

            decimal Ltotal = Math.Round((Convert.ToDecimal(LblTotalMonto.Text) - Convert.ToDecimal(LblConIVA.Text)), 0);
            LblLiquidoTotal.Text = string.Format("{0:n0}", (Math.Truncate(Ltotal * 100) / 100));
            decimal Ltotal10 = Math.Round(Convert.ToDecimal(LblTotalMonto10.Text) - Convert.ToDecimal(LblConIVA10.Text), 0);
            LblLiquidoTotal10.Text = string.Format("{0:n0}", (Math.Truncate(Ltotal10 * 100) / 100));

            lblTotal.Text = (Ltotal + Ltotal10).ToString();
            lblRetencion.Text = string.Format("{0:n0}",data.Rows[0][6].ToString());

            //LblTotalPago.Text = Convert.ToString(Math.Round(Convert.ToDecimal(data.Rows[0][7]),0));
            decimal TPago = Math.Round(Convert.ToDecimal(data.Rows[0][7]), 0);
            LblTotalPago.Text = string.Format("{0:n0}", (Math.Truncate(TPago * 100) / 100));


            //*fin*

            VT_Planilla planilla = new VT_Planilla();
            planilla = pl.DB_Seleccionar_PLANILLA(LblIdSolicitud.Text);
            LblNumCuenta.Text = planilla.Num_Cheque;
        }
        #endregion
        #region OBTENER LA LISTA DE SOLICITUDES ENVIADAS
        protected void Cargar_ENCABEZADO()
        {
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            DataTable data = new DataTable();
            data = sol.DB_Reporte_SOLICITUD_US(LblIdSolicitud.Text, "ENCABEZADO");
            LblNombre.Text = data.Rows[0][12].ToString();
            LblCargo.Text = data.Rows[0][4].ToString();
            LblCategoria.Text = data.Rows[0][14].ToString();
            LblCI.Text = data.Rows[0]["Cedula"].ToString();//23/09/2016 lrojas se agrego ci
            DB_VT_Categoria cat = new DB_VT_Categoria();
            DataTable data1 = new DataTable();
            data1 = cat.DB_Seleccionar_CATEGORIA(Convert.ToInt32(LblCategoria.Text), data.Rows[0][2].ToString());

            data = sol.DB_Reporte_SOLICITUD_US(LblIdSolicitud.Text, "FECHAMAXMINSOLICITUD");
            LblFechaSalida.Text = Convert.ToDateTime(data.Rows[0][0].ToString()).ToString("dd/MM/yyyy");
            LblFechaRetorno.Text = Convert.ToDateTime(data.Rows[0][1].ToString()).ToString("dd/MM/yyyy");
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
                //LblTotalMonto.Text = (Convert.ToDecimal(LblTotalMonto.Text) + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Monto"))).ToString();                    
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
    }
}