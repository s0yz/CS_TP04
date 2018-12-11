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
            Utilisateur u = new Utilisateur("test","",null,"adresse","testemail",null);
            Produit un = new Produit("test", "test", 2.12, null, null);
            Commande une = new Commande(null, new StatutCommande(1, "pending"),"resfef");
            une.Ajouter(un,3);
            this.m_ListCommande = new List<Commande>();
            this.m_ListCommande.Add(une);
          
        }

        public StringBuilder construireHtml()
        {
            StringBuilder html = new StringBuilder();
            html.Append("<form action=\"SuiviDesCommandes.aspx\" ");
            foreach (Commande item in this.m_ListCommande)
            {
                html.Append("<div>");
                html.Append("<table><tr>");
                html.Append("<h2> Numéro de commande : </h2>  <h3>" + item.Identifiant.ToString() + "</h3>" + "</tr>");
                html.Append("<tr><h2> Description de la commande </h2> </tr>");

                foreach (KeyValuePair<Produit, uint> prod in item)
                {
                    html.Append("<tr>" + prod.Value.ToString() + "x " + prod.Key.getDescription() + "</tr>");
                }

                html.Append("<tr><h2>Statut : </h2>" + "<h2>" + item.Statut.ToString() + "</h2></tr></table>");

                html.Append(string.Format("<input type=\"submit\" value=\"Accepter la commande {0}\">",item.Identifiant.ToString()));
                html.Append(string.Format("<input type=\"submit\" value=\"Refuser la commande {0}\">", item.Identifiant.ToString()));
                html.Append("</div>");
            }
            html.Append("</form>");
            return html;
        }
       
    }
}