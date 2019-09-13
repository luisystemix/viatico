using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAplication.Registro
{
    public partial class contEncabezado2 : System.Web.UI.UserControl
    {
        public String LabelOrg
        {
            get { return LblOrganizacion.Text; }
            set { LblOrganizacion.Text = Convert.ToString(value); }
        }
        public String LabelCamp
        {
            get { return LblCampanhia.Text; }
            set { LblCampanhia.Text = Convert.ToString(value); }
        }
        public String LabelProg
        {
            get { return LblPrograma.Text; }
            set { LblPrograma.Text = Convert.ToString(value); }
        }
        public String LabelIdInsOrg
        {
            get { return LblPrograma.Text; }
            set { LblId_Org.Text = Convert.ToString(value); }
        }   
    }
}