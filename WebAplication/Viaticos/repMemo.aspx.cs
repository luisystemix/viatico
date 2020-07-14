using System;
using System.Data;
using DataBusiness.DB_Viaticos;
using DataEntity.DE_Viaticos;
using DataBusiness.DB_General;


namespace WebAplication.Viaticos
{
    public partial class repMemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdSolicit.Text = Session["IdSolicitud"].ToString();
                    //lblTest.Text = "JOSE LUIS";
                    Reporte_MEMORANDUM();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }

        public void AsignaTextoJefePorFecha(string fechaAprobacion)
        {
            if (Convert.ToDateTime(fechaAprobacion).Date <= Convert.ToDateTime("19/07/2018").Date)
            {
                LblGaf.Text = "AMPARO IMELDA RODRIGUEZ TELLEZ";
                LblCargoA.Text = "GERENTE ADMINISTRATIVO Y FINANCIERO a.i.";
            }
            else
               if (Convert.ToDateTime(fechaAprobacion).Date >= Convert.ToDateTime("20/07/2018").Date     && 
                   Convert.ToDateTime(fechaAprobacion).Date <= Convert.ToDateTime("26/07/2018").Date)
            {
                LblGaf.Text = "LAURA VIRGINIA MIRANDA DUNN";
                LblCargoA.Text = "JEFE DE UNIDAD FINANCIERA";
            }
            else if (Convert.ToDateTime(fechaAprobacion).Date >= Convert.ToDateTime("27/07/2018").Date && 
                     Convert.ToDateTime(fechaAprobacion).Date <= Convert.ToDateTime("31/07/2018").Date)
            {
                LblGaf.Text = "MARIA ANGELICA ESCOBAR VEIZAGA";
                LblCargoA.Text = "RESPONSABLE  DE RECURSOS HUMANOS a.i.";
            }
            
            if (Convert.ToDateTime(fechaAprobacion).Date >= Convert.ToDateTime("01/08/2018").Date && 
                Convert.ToDateTime(fechaAprobacion).Date <= Convert.ToDateTime("05/04/2019").Date)
            {
                LblGaf.Text = "VICTOR ROLANDO CANSAYA JUCHANI";
                LblCargoA.Text = "GERENTE ADMINISTRATIVO FINANCIERO";
            }

            if (Convert.ToDateTime(fechaAprobacion).Date >= Convert.ToDateTime("06/04/2019").Date &&
                Convert.ToDateTime(fechaAprobacion).Date <= Convert.ToDateTime("05/05/2019").Date)
            {
                LblGaf.Text = "LAURA VIRGINA MIRANDA DUNN";
                LblCargoA.Text = "JEFE DE UNIDAD FINANCIERA";
            }
            #region Se comenta la lineas debibo a que ILKA FATIMA CLAROS RIOS no quiere firmar indican
            //if (Convert.ToDateTime(fechaAprobacion).Date >= Convert.ToDateTime("15/04/2019").Date && 
            //        Convert.ToDateTime(fechaAprobacion).Date <= Convert.ToDateTime("17/04/2019").Date)
            //{
            //    LblGaf.Text = "ILKA FATIMA CLAROS RIOS";
            //    LblCargoA.Text = "GERENTE ADMINISTRATIVO FINANCIERO";
            //}

            //if (Convert.ToDateTime(fechaAprobacion).Date >= Convert.ToDateTime("18/04/2019").Date && 
            //    Convert.ToDateTime(fechaAprobacion).Date <= Convert.ToDateTime("05/05/2019").Date)
            //{
            //    LblGaf.Text = "LAURA VIRGINA MIRANDA DUNN";
            //    LblCargoA.Text = "JEFE DE UNIDAD FINANCIERA";
            //}
            #endregion
            if (Convert.ToDateTime(fechaAprobacion).Date >= Convert.ToDateTime("06/05/2019").Date)
            {
                LblGaf.Text = "SILVESTRE OSWALDO CLAVIJO PALACIOS";
                LblCargoA.Text = "GERENTE ADMINISTRATIVO FINANCIERO";
            }
            if (Convert.ToDateTime(fechaAprobacion).Date >= Convert.ToDateTime("25/06/2019").Date)
            {
                LblGaf.Text = "ALEJANDRO RAMIREZ BANZER";
                LblCargoA.Text = "GERENTE ADMINISTRATIVO FINANCIERO";
            }
        }
        protected void Reporte_MEMORANDUM()
        {
            DB_Usuario us = new DB_Usuario();
            DB_VT_Solicitud memo = new DB_VT_Solicitud();
            DataTable dt = new DataTable();
            dt = memo.DB_Reporte_SOLICITUD_US(LblIdSolicit.Text, "ENCABEZADO");

            string fechaAprobacion = dt.Rows[0][5].ToString(); //        08/04/2019 

            LblFecha.Text = string.Format("{0:D}", Convert.ToDateTime(dt.Rows[0][6].ToString()));

            this.AsignaTextoJefePorFecha(fechaAprobacion);

            LblPersonal.Text = dt.Rows[0][12].ToString();
            LblCargo.Text = dt.Rows[0][4].ToString();
            LblActividad.Text = dt.Rows[0][7].ToString();
            LblIdSolicitud.Text = LblIdSolicit.Text;
            /*******************lrojas:09112017*************/
            string auxiliar = dt.Rows[0][1].ToString(); 
            DataTable dt_us = new DataTable();
            DB_Usuario nus = new DB_Usuario();
            dt_us = nus.DB_Desplegar_USUARIO(0, auxiliar, "USUARIO");
            if (dt_us.Rows.Count != 0)
            {
                auxiliar = dt_us.Rows[0][1].ToString(); // id_persona

            }
            /**************************lrojas:09112017************************/
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            DataTable data = new DataTable();
            data = sol.DB_Reporte_SOLICITUD_US(LblIdSolicitud.Text, "ENCABEZADO");
            //string auxiliar = data.Rows[0][13].ToString();
            DB_VT_Informe aux = new DB_VT_Informe();
            data = aux.DB_Desplegar_DATOS_ESTRUCTURA(auxiliar);
            if (data.Rows.Count > 0)
            {
                if (data.Rows[0][1].ToString() == "GAF")
                {
                    data = aux.DB_Desplegar_DATOS_ESTRUCTURA("GG");
                    auxiliar = data.Rows[0][2].ToString();
                }
                else
                {
                    data = aux.DB_Desplegar_DATOS_ESTRUCTURA("GAF");
                    auxiliar = data.Rows[0][2].ToString();
                }
            }
            else
            {
                data = aux.DB_Desplegar_DATOS_ESTRUCTURA("GAF");
                auxiliar = data.Rows[0][2].ToString();
            }
            dt = us.DB_Desplegar_USUARIO(0, auxiliar, "PERSONAL");
            DB_VT_Planilla pl = new DB_VT_Planilla();            
            data=memo.DB_Reporte_SOLICITUD_US(LblIdSolicit.Text,"DETALLE");
           
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

            LblValor1.Text = destinos;
            //fin lrojas 28062017: se modifico para obtener destino y lugar segun la zona

            /////////////////////////DB_VT_Solicitud sol = new DB_VT_Solicitud(); //lrojas:09112017
            data = sol.DB_Reporte_SOLICITUD_US(LblIdSolicitud.Text, "FECHAMAXMINSOLICITUD");
            LblValor2.Text = data.Rows[0][0].ToString();
            LblValor5.Text = data.Rows[0][1].ToString();
            
            VT_SolicitudDestino sd = new VT_SolicitudDestino();
            sd = sol.DB_Seleccionar_SOLICITUD_DESTINO(LblIdSolicitud.Text,1);
            if (sd.Tipo_Transporte == "Particular")
            {
                LblValor3.Text = "los pasajes";
            }
            else
            {
                LblValor3.Text = "el vehículo y combustible";
            }
            LblValor4.Text = sd.Via_Transporte;
        }
    }
}