using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;
using DataEntity.DE_General;
using DataBusiness.DB_General;
using DataEntity.DE_Registro;

namespace WebAplication.Administrador
{
    public partial class frmReunion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                LblIdCamp.Text = Session["IdCamp"].ToString();
                DB_AP_Campanhia buscamp = new DB_AP_Campanhia();
                AP_Campanhia ca = new AP_Campanhia();
                ca = buscamp.DB_Buscar_CAMPANHIA(Convert.ToInt32(LblIdCamp.Text));
                LblCamp.Text = ca.Nombre;
                /****************************************/
                Llenar_DDLRegional();
                /******************** GRILLA PARTICIPANTES *************************/
                DataTable dtListaParticipantes = new DataTable();
                dtListaParticipantes.Columns.AddRange(new DataColumn[7] { new DataColumn("N"), new DataColumn("Nombreparticipante"), new DataColumn("ci"), new DataColumn("Comunidad"), new DataColumn("Municipio"), new DataColumn("OrganizacionEmpresa"), new DataColumn("Cargo") });
                GVParticipantes.DataSource = dtListaParticipantes;
                GVParticipantes.DataBind();
                Session["datos"] = dtListaParticipantes;
                /****************** GRILLA TARAS Y ACTIVIDADES ******************/
                DataTable dtListaTareas = new DataTable();
                dtListaTareas.Columns.AddRange(new DataColumn[2] { new DataColumn("N"), new DataColumn("TemasAbordados") });
                GVTareas.DataSource = dtListaTareas;
                GVTareas.DataBind();
                Session["datos1"] = dtListaTareas;
            }
        }
        #region FUNCION PARA LLENAR EL COMBO CON EL TIPO DE ORGANIZACION
        private void Llenar_DDLRegional()
        {
            DB_Regional reg = new DB_Regional();
            List<Regional> Lista = reg.DB_Desplegar_REGIONAL();
            DDLRegional.DataSource = Lista;
            DDLRegional.DataValueField = "Id_Regional";
            DDLRegional.DataTextField = "Nombre";
            DDLRegional.DataBind();
        }
        #endregion
        protected void InicializarCampos()
        {
            TxtNombre.Text = String.Empty;
            TxtComunidad.Text = String.Empty;
            TxtMunicipio.Text = String.Empty;
            TxtOrgEmp.Text = String.Empty;
            TxtCargo.Text = String.Empty;
            TxtTarea.Text = String.Empty;
            TxtCi.Text = String.Empty;
        }
        protected void BtnParticipante_Click(object sender, EventArgs e)
        {
            DataTable dt = Session["datos"] as DataTable;
            DataRow row = dt.NewRow();
            row["N"] = GVParticipantes.Rows.Count + 1;
            row["Nombreparticipante"] = TxtNombre.Text;
            row["ci"] = TxtCi.Text;
            row["Comunidad"] = TxtComunidad.Text;
            row["Municipio"] = TxtMunicipio.Text;
            row["OrganizacionEmpresa"] = TxtOrgEmp.Text;
            row["Cargo"] = TxtCargo.Text;
            dt.Rows.Add(row);
            GVParticipantes.DataSource = dt;
            GVParticipantes.DataBind();
            Session["datos"] = dt;
            InicializarCampos();
        }

        protected void BtnTema_Click(object sender, EventArgs e)
        {
            DataTable dt = Session["datos1"] as DataTable;
            DataRow row = dt.NewRow();
            row["N"] = GVTareas.Rows.Count + 1;
            row["TemasAbordados"] = TxtTarea.Text;
            dt.Rows.Add(row);
            GVTareas.DataSource = dt;
            GVTareas.DataBind();
            Session["datos1"] = dt;
            InicializarCampos();
        }
        protected void Registrar_ASISTENCIA()
        {
            DB_AP_Reunion insert = new DB_AP_Reunion();
            AP_ReunionAsistencia ra = new AP_ReunionAsistencia(); 
            DataTable dt = Session["datos"] as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ra.Id_Reunion = Convert.ToInt32(LblIdReunion.Text);
                ra.Nombre = dt.Rows[i][1].ToString();
                ra.ci = dt.Rows[i][2].ToString();
                ra.Comunidad = dt.Rows[i][3].ToString();
                ra.Municipio = dt.Rows[i][4].ToString();
                ra.Representante = dt.Rows[i][5].ToString();
                ra.Cargo = dt.Rows[i][6].ToString();
                insert.DB_Registrar_ASISTENCIA(ra);
            }
        }
        protected void Registrar_TEMAS()
        {
            DB_AP_Reunion insert = new DB_AP_Reunion();
            AP_ReunionTareas rt = new AP_ReunionTareas(); 
            DataTable dt = Session["datos1"] as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rt.Id_Reunion = Convert.ToInt32(LblIdReunion.Text);
                rt.Criterios = dt.Rows[i][1].ToString();
                insert.DB_Registrar_TEMAS(rt);
            }
        }
        protected void Registrar_REUNION()
        {
            DB_AP_Reunion insert = new DB_AP_Reunion();
            AP_Reunion r = new AP_Reunion();
            r.Id_Campanhia = Convert.ToInt32(LblIdCamp.Text);
            r.Id_Regional = Convert.ToInt32(DDLRegional.SelectedValue);
            r.Tipo_Reunion = DDLTipoReunion.SelectedValue;
            r.Lugar = TxtLugar.Text;
            r.Fecha = Convert.ToDateTime(LblFecha.Text);
            r.Conclusion = TxtConclucion.Text;
            insert.DB_Registrar_REUNION(r);
            DB_AP_Registro_Org aux = new DB_AP_Registro_Org();
            LblIdReunion.Text = aux.DB_MaxId("AP_REUNION", "Id_Reunion");
            Registrar_ASISTENCIA();
            Registrar_TEMAS();
        }
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Registrar_REUNION();
        }
    }
}