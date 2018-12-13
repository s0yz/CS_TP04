using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Concept
{
    public partial class SuiviDesCommandes : System.Web.UI.Page
    {
        

        public List<Commande> m_ListCommande;

        public int m_commanderendu;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.m_ListCommande = new List<Commande>();
            
            if (this.Request.Form["commandeA"] != null)
            {
                int cmd = Convert.ToInt32(this.Request.Form["commandeA"]);
                BDGestion.Instance.setStatutCommande(cmd, 'un statut');
                this.Request.Form["commandeA"] = null;
            }
            else if(this.Request.Form["commandeR"] != null)
            {
                int cmd = Convert.ToInt32(this.Request.Form["commandeR"]);
                BDGestion.Instance.setStatutCommande(cmd, 'un statut');
                this.Request.Form["commandeR"] = null;
            }

            this.m_ListCommande = BDGestion.Instance.GetCommandesParStatut(0, 0).ToList();
        }

        public string construireHtml()
        {
            StringBuilder html = new StringBuilder();
            html.Append("<form action=\"SuiviDesCommandes.aspx\">");
            foreach (Commande item in this.m_ListCommande)
            {
                html.Append( "<div class=\"conteneur\"");
                html.Append("<div id=\"test\" class=\"conteneur\" ");
                html.Append( "<table><tr>");
                html.Append("  <h3> Numéro de commande : " + item.Identifiant.ToString() + "</h3>" + "</tr>");
                html.Append ("<tr><h2> Description de la commande </h2> </tr>");

                foreach (KeyValuePair<Produit, uint> prod in item)
                {
                    html.Append( "<tr>" + prod.Value.ToString() + "x " + prod.Key.getDescription() + "</tr>");
                }

                html.Append ("<tr><h2>Statut : </h2>" + "<h2>" + item.Statut.ToString() + "</h2></tr></table>");

                html.Append (string.Format("<input type=\"submit\" name=\"commandeA\" value=\"{0}\">",item.Identifiant.ToString()));
                html.Append (string.Format("<input type=\"submit\" name=\"commandeR\" value=\"{0}\">", item.Identifiant.ToString()));
                html.Append ("</div>");
            }
            html.Append ("</form>");
            return html.ToString();
        }
       
    }
}