using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAplication.Viaticos
{
    public partial class repEFGrafico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblS1.ForeColor = System.Drawing.Color.Transparent;
            lblS2.ForeColor = System.Drawing.Color.Transparent;
            lblS3.ForeColor = System.Drawing.Color.Transparent;
            lblS4.ForeColor = System.Drawing.Color.Transparent;
            lblS5.ForeColor = System.Drawing.Color.Transparent;
            lblS6.ForeColor = System.Drawing.Color.Transparent;
            lblS7.ForeColor = System.Drawing.Color.Transparent;
            lblS8.ForeColor = System.Drawing.Color.Transparent;
            lblS9.ForeColor = System.Drawing.Color.Transparent;
            lblS10.ForeColor = System.Drawing.Color.Transparent;
            lblS11.ForeColor = System.Drawing.Color.Transparent;
            lblS12.ForeColor = System.Drawing.Color.Transparent;

            lblS1.Text = Convert.ToString(Request.QueryString["s1"]);
            if (lblS1.Text == string.Empty)
                lblS1.Text = "10";
            lblS2.Text = Convert.ToString(Request.QueryString["s2"]);
            if (lblS2.Text == string.Empty)
                lblS2.Text = "10";
            lblS3.Text = Convert.ToString(Request.QueryString["s3"]);
            if (lblS3.Text == string.Empty)
                lblS3.Text = "10";
            lblS4.Text = Convert.ToString(Request.QueryString["s4"]);
            if (lblS4.Text == string.Empty)
                lblS4.Text = "10";
            lblS5.Text = Convert.ToString(Request.QueryString["s5"]);
            if (lblS5.Text == string.Empty)
                lblS5.Text = "10";
            lblS6.Text = Convert.ToString(Request.QueryString["s6"]);
            if (lblS6.Text == string.Empty)
                lblS6.Text = "10";
            lblS7.Text = Convert.ToString(Request.QueryString["s7"]);
            if (lblS7.Text == string.Empty)
                lblS7.Text = "10";
            lblS8.Text = Convert.ToString(Request.QueryString["s8"]);
            if (lblS8.Text == string.Empty)
                lblS8.Text = "10";
            lblS9.Text = Convert.ToString(Request.QueryString["s9"]);
            if (lblS9.Text == string.Empty)
                lblS9.Text = "10";
            lblS10.Text = Convert.ToString(Request.QueryString["s10"]);
            if (lblS10.Text == string.Empty)
                lblS10.Text = "10";
            lblS11.Text = Convert.ToString(Request.QueryString["s11"]);
            if (lblS11.Text == string.Empty)
                lblS11.Text = "10";
            lblS12.Text = Convert.ToString(Request.QueryString["s12"]);
            if (lblS12.Text == string.Empty)
                lblS12.Text = "10";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string script = string.Format("javascript:MostrarOcultarDiv('{0}')", "hola");

            ScriptManager.RegisterStartupScript(Page, Page.ClientScript.GetType(), "MessageAlert", script, true);

            //lblS1.Text = txtDato.Text;
        }
    }
}