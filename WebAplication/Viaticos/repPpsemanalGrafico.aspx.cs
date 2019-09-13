using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAplication.Viaticos
{
    public partial class repPpsemanalGrafico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lblS1.ForeColor = System.Drawing.Color.Transparent; lblS2.ForeColor = System.Drawing.Color.Transparent; lblS3.ForeColor = System.Drawing.Color.Transparent;
            lblS4.ForeColor = System.Drawing.Color.Transparent; lblS5.ForeColor = System.Drawing.Color.Transparent; lblS6.ForeColor = System.Drawing.Color.Transparent;
            lblS7.ForeColor = System.Drawing.Color.Transparent; lblS8.ForeColor = System.Drawing.Color.Transparent; lblS9.ForeColor = System.Drawing.Color.Transparent;

            lblS10.ForeColor = System.Drawing.Color.Transparent; lblS11.ForeColor = System.Drawing.Color.Transparent; lblS12.ForeColor = System.Drawing.Color.Transparent;
            lblS13.ForeColor = System.Drawing.Color.Transparent; lblS14.ForeColor = System.Drawing.Color.Transparent; lblS15.ForeColor = System.Drawing.Color.Transparent;
            lblS16.ForeColor = System.Drawing.Color.Transparent; lblS17.ForeColor = System.Drawing.Color.Transparent; lblS18.ForeColor = System.Drawing.Color.Transparent;

            lblS19.ForeColor = System.Drawing.Color.Transparent; lblS20.ForeColor = System.Drawing.Color.Transparent; lblS21.ForeColor = System.Drawing.Color.Transparent;
            lblS22.ForeColor = System.Drawing.Color.Transparent; lblS23.ForeColor = System.Drawing.Color.Transparent; lblS24.ForeColor = System.Drawing.Color.Transparent;
            lblS25.ForeColor = System.Drawing.Color.Transparent; lblS26.ForeColor = System.Drawing.Color.Transparent; lblS27.ForeColor = System.Drawing.Color.Transparent;

            lblS28.ForeColor = System.Drawing.Color.Transparent; lblS29.ForeColor = System.Drawing.Color.Transparent; lblS30.ForeColor = System.Drawing.Color.Transparent;
            lblS31.ForeColor = System.Drawing.Color.Transparent; lblS32.ForeColor = System.Drawing.Color.Transparent; 

            lblS1.Text = Convert.ToString(Request.QueryString["s1"]);
            if (lblS1.Text == string.Empty)
                lblS1.Text = "0";
            lblS2.Text = Convert.ToString(Request.QueryString["s2"]);
            if (lblS2.Text == string.Empty)
                lblS2.Text = "0";
            lblS3.Text = Convert.ToString(Request.QueryString["s3"]);
            if (lblS3.Text == string.Empty)
                lblS3.Text = "0";
            lblS4.Text = Convert.ToString(Request.QueryString["s4"]);
            if (lblS4.Text == string.Empty)
                lblS4.Text = "0";
            lblS5.Text = Convert.ToString(Request.QueryString["s5"]);
            if (lblS5.Text == string.Empty)
                lblS5.Text = "0";
            lblS6.Text = Convert.ToString(Request.QueryString["s6"]);
            if (lblS6.Text == string.Empty)
                lblS6.Text = "0";
            lblS7.Text = Convert.ToString(Request.QueryString["s7"]);
            if (lblS7.Text == string.Empty)
                lblS7.Text = "0";
            lblS8.Text = Convert.ToString(Request.QueryString["s8"]);
            if (lblS8.Text == string.Empty)
                lblS8.Text = "0";
            lblS9.Text = Convert.ToString(Request.QueryString["s9"]);
            if (lblS9.Text == string.Empty)
                lblS9.Text = "0";
            //**************************************
            lblS10.Text = Convert.ToString(Request.QueryString["s10"]);
            if (lblS10.Text == string.Empty)
                lblS10.Text = "0";
            lblS11.Text = Convert.ToString(Request.QueryString["s11"]);
            if (lblS11.Text == string.Empty)
                lblS11.Text = "0";
            lblS12.Text = Convert.ToString(Request.QueryString["s12"]);
            if (lblS12.Text == string.Empty)
                lblS12.Text = "0";
            lblS13.Text = Convert.ToString(Request.QueryString["s13"]);
            if (lblS13.Text == string.Empty)
                lblS13.Text = "0";
            lblS14.Text = Convert.ToString(Request.QueryString["s14"]);
            if (lblS14.Text == string.Empty)
                lblS14.Text = "0";
            lblS15.Text = Convert.ToString(Request.QueryString["s15"]);
            if (lblS15.Text == string.Empty)
                lblS15.Text = "0";
            lblS16.Text = Convert.ToString(Request.QueryString["s16"]);
            if (lblS16.Text == string.Empty)
                lblS16.Text = "0";
            lblS17.Text = Convert.ToString(Request.QueryString["s17"]);
            if (lblS17.Text == string.Empty)
                lblS17.Text = "0";
            lblS18.Text = Convert.ToString(Request.QueryString["s18"]);
            if (lblS18.Text == string.Empty)
                lblS18.Text = "0";
            lblS19.Text = Convert.ToString(Request.QueryString["s19"]);
            if (lblS19.Text == string.Empty)
                lblS19.Text = "0";
            lblS20.Text = Convert.ToString(Request.QueryString["s20"]);
            if (lblS20.Text == string.Empty)
                lblS20.Text = "0";
            lblS21.Text = Convert.ToString(Request.QueryString["s21"]);
            if (lblS21.Text == string.Empty)
                lblS21.Text = "0";
            lblS22.Text = Convert.ToString(Request.QueryString["s22"]);
            if (lblS22.Text == string.Empty)
                lblS22.Text = "0";
            lblS23.Text = Convert.ToString(Request.QueryString["s23"]);
            if (lblS23.Text == string.Empty)
                lblS23.Text = "0";
            lblS24.Text = Convert.ToString(Request.QueryString["s24"]);
            if (lblS24.Text == string.Empty)
                lblS24.Text = "0";
            lblS25.Text = Convert.ToString(Request.QueryString["s25"]);
            if (lblS25.Text == string.Empty)
                lblS25.Text = "0";
            lblS26.Text = Convert.ToString(Request.QueryString["s26"]);
            if (lblS26.Text == string.Empty)
                lblS26.Text = "0";
            lblS27.Text = Convert.ToString(Request.QueryString["s27"]);
            if (lblS27.Text == string.Empty)
                lblS27.Text = "0";
            lblS28.Text = Convert.ToString(Request.QueryString["s28"]);
            if (lblS28.Text == string.Empty)
                lblS28.Text = "0";
            lblS29.Text = Convert.ToString(Request.QueryString["s29"]);
            if (lblS29.Text == string.Empty)
                lblS29.Text = "0";
            lblS30.Text = Convert.ToString(Request.QueryString["s30"]);
            if (lblS30.Text == string.Empty)
                lblS30.Text = "0";
            lblS31.Text = Convert.ToString(Request.QueryString["s31"]);
            if (lblS31.Text == string.Empty)
                lblS31.Text = "0";
            lblS32.Text = Convert.ToString(Request.QueryString["s32"]);
            if (lblS32.Text == string.Empty)
                lblS32.Text = "0";            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "MostrarOcultarDiv();", true);
            string script = string.Format("javascript:MostrarOcultarDiv('{0}')", "hola");
            ScriptManager.RegisterStartupScript(Page, Page.ClientScript.GetType(), "MessageAlert", script, true);
            lblS1.Text = txtDato.Text;


        }
    }
}