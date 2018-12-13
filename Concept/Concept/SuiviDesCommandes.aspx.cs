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
                BDGestion.Instance.setStatutCommande(cmd, 'A');
                this.Request.Form["commandeA"] = null;
            }
            else if(this.Request.Form["commandeR"] != null)
            {
                int cmd = Convert.ToInt32(this.Request.Form["commandeR"]);
                BDGestion.Instance.setStatutCommande(cmd, 'R');
                this.Request.Form["commandeR"] = null;
            }

            this.m_ListCommande = BDGestion.Instance.GetCommandesParStatut(0,'P').ToList();
        }

        public string construireHtml()
        {
            StringBuilder html = new StringBuilder();
            html.Append("");
            html.Append("<form action=\"SuiviDesCommandes.aspx\">");
            foreach (Commande item in this.m_ListCommande)
            {
                html.Append("<div class=\"commande-container\"");
                html.Append( "<table><tr>");
                html.Append(string.Format(" <h2 class=\"commande - container__numero\">Numéro de commande : {0}</h2></tr>",item.Identifiant.ToString()));
                html.Append ("<tr><h3 class=\"commande - container__description\">Description de la commande :</h3> </tr>");

                foreach (KeyValuePair<Produit, uint> prod in item)
                {
                    html.Append(string.Format("<tr><p class=\"commande - container__description - item\">{0}x {1}</p></tr>",prod.Value.ToString(),prod.Key.Description.ToString()));
                }

                html.Append ("<tr><h3 class=\"commande - container__statut\">Statut : En attente</h3></tr></table>");

                html.Append (string.Format("<input type=\"submit\" name=\"commandeA\" value=\"{0}\">",item.Identifiant.ToString()));
                html.Append (string.Format("<input type=\"submit\" name=\"commandeR\" value=\"{0}\">", item.Identifiant.ToString()));
                html.Append ("</div>");
            }
            html.Append ("</form>");
            return html.ToString();
        }
       
    }
}