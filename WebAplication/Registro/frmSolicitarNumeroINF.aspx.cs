using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataEntity.DE_Registro;
using DataBusiness.DB_Registro; 
using DataEntity.DE_General;
using DataBusiness.DB_General;

namespace WebAplication.Registro
{
    public partial class frmSolicitarNumeroINF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                   Desplegar_ENCAVEZADO1();
                }
            }
            catch
            {
                Response.Redirect("~/About.aspx");
            }
        }
        protected void Generar_CODIGO_CONTRATO()
        {
            switch(DDLTipoInf.SelectedValue)
            {
                case "1":
                    LblNumero.Text=((Label)contEncabezado11.FindControl("LblCampanhia")).Text[0].ToString();
                    for (int i = 1; i< ((Label)contEncabezado11.FindControl("LblCampanhia")).Text.Count();i++)
                    {
                        if (((Label)contEncabezado11.FindControl("LblCampanhia")).Text[i].ToString() == " ")
                        {
                            LblNumero.Text = LblNumero.Text + ((Label)contEncabezado11.FindControl("LblCampanhia")).Text[i + 3].ToString() + ((Label)contEncabezado11.FindControl("LblCampanhia")).Text[i + 4].ToString();
                        }
                        if (((Label)contEncabezado11.FindControl("LblCampanhia")).Text[i].ToString() == "-")
                        {
                            LblNumero.Text = LblNumero.Text +"/"+((Label)contEncabezado11.FindControl("LblCampanhia")).Text[i + 3].ToString() + ((Label)contEncabezado11.FindControl("LblCampanhia")).Text[i + 4].ToString();
                        }
                    }
                    /************* CONTRUCCION DE CODIFICACION **************/
                    DB_Codificacion cont = new DB_Codificacion();
                    int num = cont.DB_Codigo_INFORME();
                    string dep = "";
                    switch (((Label)contEncabezado11.FindControl("LblRegional")).Text)
                    {
                        case "SANTA CRUZ":
                            dep = "SC";
                            break;
                        case "BENI":
                            dep = "BN";
                            break;
                        case "COCHABAMBA":
                            dep = "CB";
                            break;
                        case "TARIJA":
                            dep = "TJ";
                            break;
                        case "POTOSI":
                            dep = "PT";
                            break;
                        case "CHUQUISACA":
                            dep = "CH";
                            break;
                        case "ORURO":
                            dep = "OR";
                            break;
                        case "LA PAZ":
                            dep = "LP";
                            break;
                    }
                    LblNumero.Text = LblNumero.Text + ((Label)contEncabezado11.FindControl("LblPrograma")).Text[0].ToString() + "-" + num.ToString()+" "+dep;
                    break;
                case "2":
                    break;
            }
        }
        #region FUNCION PARA DESPLEGAR DATOS DEL USUARIO
        protected void Desplegar_ENCAVEZADO1()
        {
            DB_AP_Registro_Org vro = new DB_AP_Registro_Org();
            DataTable dt = new DataTable();
            dt = vro.DB_Desplegar_ENCABEZADO_ORG(Convert.ToInt32(Session["IdInsOrg"].ToString()));
            ((Label)contEncabezado11.FindControl("LblRegional")).Text = dt.Rows[0][8].ToString();
            ((Label)contEncabezado11.FindControl("LblIdRegional")).Text = dt.Rows[0][7].ToString();
            ((Label)contEncabezado11.FindControl("LblCampanhia")).Text = dt.Rows[0][6].ToString();
            ((Label)contEncabezado11.FindControl("LblIdCampanhia")).Text = dt.Rows[0][5].ToString();
            ((Label)contEncabezado11.FindControl("LblPrograma")).Text = dt.Rows[0][9].ToString();
        }
        #endregion

        protected void BtnSolicitNum_Click(object sender, EventArgs e)
        {
           // Generar_CODIGO_CONTRATO();
        }
    }
}