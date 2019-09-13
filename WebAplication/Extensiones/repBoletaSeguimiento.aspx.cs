using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataBusiness.DB_Registro;
using DataBusiness.DB_Extensiones;
using DataBusiness.DB_General;
using DataEntity.DE_Extensiones;

namespace WebAplication.Extensiones
{
    public partial class repBoletaSeguimiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string LblIdInsOrg = Session["IdInsOrg"].ToString();
            string LblIdInsProd = Session["IdInsProd"].ToString();
            //LblIdUsuario.Text = Session["IdUser"].ToString();
            //LblEtapa.Text = Session["Etapa"].ToString();
            //LblId_Etapa.Text = Session["Id_Etapa"].ToString();//**LR
            //LblEstado.Text = Session["Estado"].ToString();

            //1 seguimiento - obtenemos lista de seguimiento de agricultor
            
            DB_EXT_Seguimiento ListSeg = new DB_EXT_Seguimiento();            
            //RATAMIENTO PARA LAS ETAPAS
            DB_EXT_Seguimiento ListSegPendiente = new DB_EXT_Seguimiento();
            DataTable dt_lista = new DataTable();
            List<EXT_SeguimientoPendiente> LSP = ListSegPendiente.DB_Desplegar_SEGUIMIENTOS_PENDIENTE();
            dt_lista = ListSeg.DB_Desplegar_SEGUIMIENTOS_PROD(Convert.ToInt32(LblIdInsOrg), LblIdInsProd, "", "SEGUIMIENTO");
            //dt.Columns.Add("Id_Etapa", typeof(String));
            foreach (DataRow fila in dt_lista.Rows)
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
            //GVListaSeg.DataSource = dt;
            //GVListaSeg.DataBind();
            //******************************
            //2 recorremos la lista para obtener idseguimiento y obenter la informacion del mismo
            bool flag_datos = false; // solo ingresara una vez los datos del productor
            string LblIdUser = string.Empty;
            int count = 0;
            string Obs_etapa = string.Empty;
                string Rec_etapa = string.Empty;

            string Obs_maleza = string.Empty;
                string Obs_maleza_intensidad = string.Empty;
                string Obs_maleza_tratamiento = string.Empty;

            string Obs_p_e = string.Empty;
                string Obs_p_e_intensidad = string.Empty;
                string Obs_p_e_tratamiento = string.Empty;
                
            string LblTecnico = string.Empty;
            string fasefenologica = string.Empty;
            foreach (DataRow fila in dt_lista.Rows)
            {

                string LblNum = fila["Id_Seguimiento"].ToString(); 
                string LblEtapa = fila["Etapa"].ToString();
                count++;
                DB_EXT_Seguimiento Seg = new DB_EXT_Seguimiento();
                DB_Usuario us = new DB_Usuario();
                if (!flag_datos)
                {
                    //DATOS PERSONA                    
                    DataTable dtseg = new DataTable();
                    dtseg = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum), "ENCABEZADO");
                    lblnombrebeneficiario.Text = dtseg.Rows[0][0].ToString();
                    //LblCedula.Text = dtseg.Rows[0][1].ToString();
                    lblorganizacion.Text = dtseg.Rows[0][2].ToString();
                    lblcomunidad.Text = dtseg.Rows[0][4].ToString();
                    lblmunicipio.Text = dtseg.Rows[0][5].ToString();
                    //LblProvincia.Text = dtseg.Rows[0][6].ToString();
                    //LblDep.Text = dtseg.Rows[0][7].ToString();
                    lblprograma.Text = dtseg.Rows[0][8].ToString();
                    lblregional.Text = dtseg.Rows[0][9].ToString();
                    lblcampania.Text = dtseg.Rows[0][10].ToString();
                    //LblIdUser.Text = dtseg.Rows[0][11].ToString();
                    LblIdUser = dtseg.Rows[0][11].ToString();
                    flag_datos = true;

                    DataTable dt_user = new DataTable();
                    dt_user = us.DB_Desplegar_USUARIO(0, LblIdUser, "USUARIO");
                    LblTecnico = dt_user.Rows[0][10].ToString();
                }
                //DATOS SEGUIMIENTO CULTIVO
                
               
                //string Obs_etapa = string.Empty;
                //string Rec_etapa = string.Empty;
                Obs_etapa += "<br/>"+ count + ".(" + LblEtapa + "): ";
                Rec_etapa += "<br/>"+ count + ".(" + LblEtapa + "): ";
                switch (LblEtapa)
                {
                    
                    //case "VERIFICACION_PARCELA":
                    case "VERIFICACION Y/O GEORREFERENCIACION  DE PARCELA":
                        //Panel1.Visible = true;
                        //GVCoordenadas.DataSource = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum.Text), "COORDENADAS");
                        //GVCoordenadas.DataBind();
                        //**
                        DataTable dtgeo = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum), "COORDENADAS");                        
                        foreach (DataRow dtRow in dtgeo.Rows)
                        {                            
                            lblcord_x.Text = dtRow["CoordenadaX"].ToString();
                            lblcord_y.Text = dtRow["CoordenadaY"].ToString();
                            Obs_etapa += dtRow["Observacion"].ToString();
                            Rec_etapa += dtRow["Recomendacion"].ToString();
                        }                        
                        break;
                    //case "VERIFICACION_SIEMBRA":
                    case "SEGUIMIENTO AL AVANCE DE SIEMBRA":
                        DataTable dtSiembraGET = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum), "SIEMBRA");
                        
                        foreach (DataRow dtRow in dtSiembraGET.Rows)
                        {                            
                            lblfecha_siembra.Text = Convert.ToDateTime(dtRow["Fecha_SiembraINI"].ToString()).ToShortDateString();
                            lbldensidad.Text = dtRow["Avance_Siembra"].ToString();
                            lblsistema_siembra.Text = dtRow["Sistema_Siembra"].ToString();
                            lblsemilla.Text = dtRow["Variedad_Semilla"].ToString();
                            lblcultivo_anterior.Text = dtRow["Cultivo_Anterior"].ToString();
                            Obs_etapa += dtRow["Observacion"].ToString();
                            Rec_etapa += dtRow["Recomendacion"].ToString();
                        }

                        break;
                    //case "VERIFICACION_CULTIVO":
                    case "SEGUIMIENTO Y/O MONITOREO DE CULTIVO":
                        DataTable dtCultivoGET = Seg.DB_Reporte_SEGUIMIENTOS(Convert.ToInt32(LblNum), "CULTIVO");
                        
                        foreach (DataRow dtRow in dtCultivoGET.Rows)
                        {                           
                            fasefenologica += dtRow["Nom_Fenologia"].ToString()+", ";
                            Obs_etapa += dtRow["Observacion"].ToString();
                            Rec_etapa += dtRow["Recomendacion"].ToString();
                        }                       

                        //TxtnumBol.Text = dtCultivoGET.Rows[0][8].ToString(); //numero de boleta
                        //LblIdSegParcela.Text = dtCultivoGET.Rows[0][22].ToString(); //Id_Seguimiento_Parcela
                        ////RECUPERAR_REGISTRO_CULTIVO();
                        break;
                }
                if (count == dt_lista.Rows.Count)
                {
                    Obs_etapa += "<br/><br/>";
                    Rec_etapa += "<br/><br/>";
                }
                //** obtener adversidad y plagas                
                /* //ADVERSIDAD AGROCLIMATICA COMENTADA HASTA QUE SE MODIFIQUE EL FORMULARIO
                string Obs_agroclimaticos = string.Empty;                
                Obs_agroclimaticos += count + ". (" + LblEtapa + ")";
                DataTable dt_Adversidad = new DataTable();

                //NOTA: 1.Adversidad_Presentada, 2.Adversidad_Presentadad_PME   
                dt_Adversidad = Seg.DB_ADVESIDAD_GET(1, Convert.ToInt32(LblNum));                
                foreach (DataRow rowAP in dt_Adversidad.Rows)
                {
                    string remplazo = string.Empty;
                    string tratamiento = rowAP["Tratamiento"].ToString();
                    if (tratamiento != string.Empty)
                        remplazo = RemplazarCaracteres(tratamiento);// remplaza caracteres é,í,ó,ú,ü,ñ,Á,É,Í,Ó,Ú,Ñ,Ü
                    //Observaciones += rowAP["Descripcion"].ToString() + "(" + rowAP["Porcentage"].ToString() + ")" + " (Tratamiento)" + rowAP["Tratamiento"].ToString() + ", ";
                    //Obs_agroclimaticos += rowAP["Descripcion"].ToString() + "(" + rowAP["Porcentage"].ToString() + "%)" + " (Tratamiento)" + remplazo + ", ";
                    Obs_agroclimaticos += rowAP["Adversidad"].ToString();
                }
                */
                //NOTA: 1.Adversidad_Presentada, 2.Adversidad_Presentadad_PME  
                //string Obs_maleza = string.Empty;
                //string Obs_maleza_intensidad = string.Empty;
                //string Obs_maleza_tratamiento = string.Empty;
                Obs_maleza += count + ". (<b>" + LblEtapa + "</b>):<br/>";
                Obs_maleza_intensidad += count + ". (<b>" + LblEtapa + "</b>):<br/>";
                Obs_maleza_tratamiento += count + ". (<b>" + LblEtapa + "</b>):<br/>";
                Obs_p_e += count + ". (<b>" + LblEtapa + "</b>):<br/>";
                Obs_p_e_intensidad += count + ". (<b>" + LblEtapa + "</b>):<br/>";
                Obs_p_e_tratamiento += count + ". (<b>" + LblEtapa + "</b>):<br/>";

                DataTable dt_Adversidad_PME = new DataTable();
                dt_Adversidad_PME = Seg.DB_ADVESIDAD_GET(2, Convert.ToInt32(LblNum));
                foreach (DataRow rowAP in dt_Adversidad_PME.Rows)
                {
                    string remplazo_tratamiento = string.Empty;
                    string tratamiento = rowAP["Tratamiento"].ToString();
                    if (tratamiento != string.Empty)
                        remplazo_tratamiento = RemplazarCaracteres(tratamiento);// remplaza caracteres é,í,ó,ú,ü,ñ,Á,É,Í,Ó,Ú,Ñ,Ü                    
                    //Obs_agroclimaticos += rowAP["Descripcion"].ToString() + "(" + rowAP["Porcentage"].ToString() + "%)" + " (Tratamiento)" + remplazo + ", ";
                    if (rowAP["Adversidad"].ToString()=="MALEZA")
                    {
                        Obs_maleza += "<i>" + rowAP["Descripcion"].ToString() + "</i><br/>";
                        //Obs_maleza_intensidad += rowAP["Descripcion"].ToString();
                        string convert = intensidad(Convert.ToInt16(rowAP["Intencidad"].ToString()));
                        Obs_maleza_intensidad += "<i>" + convert + "</i><br/>";
                        Obs_maleza_tratamiento += "<i>" + remplazo_tratamiento + "</i><br/>";
                    }
                    else
                    {
                        Obs_p_e += "<i>" + rowAP["Descripcion"].ToString() + "</i><br/>";//plaga,enfermedad
                        //Obs_p_e_intensidad += rowAP["Descripcion"].ToString();
                        string convert = intensidad(Convert.ToInt16(rowAP["Intencidad"].ToString()));
                        Obs_p_e_intensidad += "<i>" + convert + "</i><br/>";
                        Obs_p_e_tratamiento += "<i>" + remplazo_tratamiento + "</i><br/>";
                    }
                }
            }
            lblmaleza.Text = Obs_maleza;
            lblmaleza_intensidad.Text = Obs_maleza_intensidad;
            lblmaleza_tratamiento.Text = Obs_maleza_tratamiento;
            lblplaga_enf.Text = Obs_p_e;
            lblplaga_enf_instensidad.Text = Obs_p_e_intensidad;
            lblplaga_enf_tratamiento.Text = Obs_p_e_tratamiento;
            lblobservacion.Text = Obs_etapa;
            lblrecomendacion.Text = Rec_etapa;
            lblnombrerevisor.Text = LblTecnico;
            lblfase.Text = fasefenologica;
            
        }
        /// <summary>
        /// obtiene nombre según valor
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string intensidad(int value)
        {
            string intensidad_texto = string.Empty;
            switch (value)
                {   
                    /*<asp:ListItem Value="1">LEVE</asp:ListItem>
                    <asp:ListItem Value="2">MODERADO</asp:ListItem>
                    <asp:ListItem Value="3">FUERTE</asp:ListItem>
                    <asp:ListItem Value="4">MUY FUERTE</asp:ListItem>*/
                case 1:
                    intensidad_texto="LEVE";
                    break;                    
                case 2:
                    intensidad_texto="MODERADO";
                    break;                    
                case 3:
                    intensidad_texto="FUERTE";
                    break;
                case 4:
                    intensidad_texto="MUY FUERTE";
                    break;
                }

            return intensidad_texto;
        }
        /// <summary>
        /// Remplaza las cadenas de carateres hmtl
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        private string RemplazarCaracteres(string cadena)
        {
            string tratamiento = cadena;
            //&nbsp;
            if (tratamiento.Contains("&nbsp;") == true)
            {
                tratamiento = tratamiento.Replace("&nbsp;", "");
            }
            if (tratamiento.Contains("&#225;") == true)
            {
                tratamiento = tratamiento.Replace("&#225;", "á");
            }
            if (tratamiento.Contains("&#233;") == true)
            {
                tratamiento = tratamiento.Replace("&#233;", "é");
            }
            if (tratamiento.Contains("&#237;") == true)
            {
                tratamiento = tratamiento.Replace("&#237;", "í");
            }
            if (tratamiento.Contains("#243;") == true)
            {
                tratamiento = tratamiento.Replace("&#243;", "ó");
            }
            if (tratamiento.Contains("&#250;") == true)
            {
                tratamiento = tratamiento.Replace("&#250;", "ú");
            }
            if (tratamiento.Contains("&#252;") == true)
            {
                tratamiento = tratamiento.Replace("&#252;", "ü");
            }
            if (tratamiento.Contains("&#241;") == true)
            {
                tratamiento = tratamiento.Replace("&#241;", "ñ");
            }
            if (tratamiento.Contains("&#193;") == true)
            {
                tratamiento = tratamiento.Replace("&#193;", "Á");
            }
            if (tratamiento.Contains("&#201;") == true)
            {
                tratamiento = tratamiento.Replace("&#201;", "É");
            }
            if (tratamiento.Contains("&#205;") == true)
            {
                tratamiento = tratamiento.Replace("&#205;", "Í");
            }
            if (tratamiento.Contains("&#211;") == true)
            {
                tratamiento = tratamiento.Replace("&#211;", "Ó");
            }
            if (tratamiento.Contains("&#218;") == true)
            {
                tratamiento = tratamiento.Replace("&#218;", "Ú");
            }
            if (tratamiento.Contains("&#209;") == true)
            {
                tratamiento = tratamiento.Replace("&#209;", "Ñ");
            }
            if (tratamiento.Contains("&#220;") == true)
            {
                tratamiento = tratamiento.Replace("&#220;", "Ü");
            }
            //&#225; á ok
            //&#233; é ok
            //&#237; í ok
            //&#243; ó ok
            //&#250; ú ok
            //&#252; ü ok
            //&#241; ñ ok
            //&#193; Á ok
            //&#201; É ok
            //&#205; Í ok
            //&#211; Ó ok
            //&#218; Ú ok
            //&#209; Ñ ok
            //&#220; Ü ok
            return tratamiento;

        }
    }
}