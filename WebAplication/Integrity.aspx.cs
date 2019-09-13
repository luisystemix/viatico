using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAplication
{
    public partial class Integrity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["data"] != null)
            {
                string data = CCryptorEngine.Decrypt(Request.QueryString["data"]);
                string[] splitString = data.Split(new char[] { '#' });
                Session.Add("SpiaSeg", splitString[1].ToString());
                string[] SessionVar = splitString[0].Split(new char[] { '|' });
                int i = 0;
                string NomSession = "";
                string ValSession = "";
                foreach (string item in SessionVar)
                {                   
                    i++;
                    if (i % 2 == 0)
                    {                       
                        ValSession = item;
                        Session.Add(NomSession, ValSession);
                    }
                    else
                    {                       
                        NomSession = item;
                    }                    
                }
                string url = System.Configuration.ConfigurationManager.AppSettings["urlini"].ToString();
                Response.Redirect(url);              
            }
            else
            {               
                Session.Clear();
                string url = System.Configuration.ConfigurationManager.AppSettings["url"].ToString();
                Response.Redirect(url); 
            }
           
        }
    }
}