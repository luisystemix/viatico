using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Viaticos;
using DataEntity.DE_Viaticos;//lrojas:29/08/2016

namespace WebAplication.Viaticos
{
    public partial class repSolicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LblIdSolicit.Text = Session["IdSolicitud"].ToString();
                    Reporte_SOLICITUD();
                }
            }
            catch 
            {
                Response.Redirect("~/About.aspx");
            }
        }
        protected void Reporte_SOLICITUD()
        {
            /***************Inmediato superior************/
            DB_VT_Solicitud sol = new DB_VT_Solicitud();
            DataTable data = new DataTable();
            data = sol.DB_Reporte_SOLICITUD_US(LblIdSolicit.Text, "ENCABEZADO");
            LblNombre.Text = data.Rows[0][12].ToString();
            LblCargo.Text = data.Rows[0][4].ToString();
            LblFecha.Text = data.Rows[0][5].ToString();
            LblRegional.Text = data.Rows[0][11].ToString();
            LblTipoViaje.Text = data.Rows[0][9].ToString();
            LblMotivo.Text = data.Rows[0][7].ToString();
            LblCi.Text = data.Rows[0][13].ToString();
            LblCiSup.Text = data.Rows[0][15].ToString();
            LblCargoAutorizar.Text = data.Rows[0][16].ToString();

            data = sol.DB_Datos_InmediatoSuperior_GET(data.Rows[0][15].ToString());
            LblAutorizar.Text = data.Rows[0][3].ToString() + " " + data.Rows[0][4].ToString() + " " + data.Rows[0][5].ToString();            
          
            DataTable dt = new DataTable(); 
            dt.Clear();
            dt.Columns.Add("Id_Solicitud");
            dt.Columns.Add("Cont");
            dt.Columns.Add("Tramo");
            dt.Columns.Add("Zona");
            dt.Columns.Add("Destino");
            dt.Columns.Add("Lugar");
            dt.Columns.Add("Objetivo");
            dt.Columns.Add("Fecha_Salida");
            dt.Columns.Add("Via_Transporte");
            dt.Columns.Add("Tipo_Transporte");
            dt.Columns.Add("Nombre_Transporte");
            dt.Columns.Add("Identificador_Trasporte");
            dt.Columns.Add("HoraSalida");
            

            DataTable dtdetalle = new DataTable();
            dtdetalle = sol.DB_Reporte_SOLICITUD_US(LblIdSolicit.Text, "DETALLE");
            foreach (DataRow row in dtdetalle.Rows)
            {
                string destin = string.Empty;
                DataRow _ravi = dt.NewRow();
                _ravi["Id_Solicitud"] = row["Id_Solicitud"].ToString();
                _ravi["Cont"] = row["Cont"].ToString();
                _ravi["Tramo"] = row["Tramo"].ToString().ToUpper();
                _ravi["Zona"] = row["Zona"].ToString();
                if (row["Lugar"].ToString() == string.Empty)
                {
                    destin = row["Destino"].ToString();
                }
                else
                {
                    destin = row["Destino"].ToString() + " - " + row["Lugar"].ToString();
                }                
                _ravi["Destino"] = destin;
                _ravi["Lugar"] = row["Lugar"].ToString();
                _ravi["Objetivo"] = row["Objetivo"].ToString();
                _ravi["Fecha_Salida"] = row["Fecha_Salida"].ToString();
                _ravi["Via_Transporte"] = row["Via_Transporte"].ToString();
                _ravi["Tipo_Transporte"] = row["Tipo_Transporte"].ToString();
                _ravi["Nombre_Transporte"] = row["Nombre_Transporte"].ToString();
                _ravi["Identificador_Trasporte"] = row["Identificador_Trasporte"].ToString();
                _ravi["HoraSalida"] = row["HoraSalida"].ToString();
                dt.Rows.Add(_ravi);
            }
            GVSolicitud.DataSource = dt;
            GVSolicitud.DataBind();
                       
        }
    }
}