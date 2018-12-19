using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Concept
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utilisateur u = (Utilisateur) this.Session["Utilisateur"];
            if (u != null)
            {
                this.a_connecter.InnerText = u.Nom;
            }
        }
    }
}