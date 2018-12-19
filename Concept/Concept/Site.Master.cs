using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Concept
{
    public partial class SiteMaster : MasterPage
    {
        public static string[] pagesAdmin = { "CreerCompte.aspx", "Gestion.aspx", "GestionMenu.aspx", "CreerRestaurant.aspx" };

        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (Utilisateur)Session["Utilisateur"];
            var NomPage = Path.GetFileName(Request.FilePath).ToLower();
            if (user != null && user.Type.Id != 'A' && pagesAdmin.Contains(NomPage))
            {
                Response.Redirect("Default.aspx");
            }
            Utilisateur u = (Utilisateur) this.Session["Utilisateur"];
            if (u != null)
            {
                this.a_connecter.InnerText = u.Nom;
            }            
        }
    }
}