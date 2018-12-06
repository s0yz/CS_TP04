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
        public int m_nbreCommande;
        public int m_commanderendu;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Produit un = new Produit("test", "test", 2.12, null, null);
            Commande une = new Commande(null, new StatutCommande(1, "pending"),"resfef");
            une.Ajouter(un, 2);
            this.m_ListCommande = new List<Commande>();
            this.m_ListCommande.Add(une);
           // this.initList();
            this.nbreDeCommande();
        }

        public StringBuilder construireHtml(int p_rendu)
        {
            StringBuilder html = new StringBuilder();
            Commande com = this.m_ListCommande[p_rendu];
                html.Append("<div>");
                html.Append("<table><tr>");
                html.Append("<h2> Numéro de commande : </h2>  <h3>" + com.Identifiant.ToString() + "</h3>" + "</tr>");
                html.Append("<tr><h2> Description de la commande </h2> </tr>");
                foreach(var prod in com)
                {
                    html.Append("<tr>" + prod.Value.ToString() + "x " + prod.Key.getDescription() + "</tr>");
                }
                html.Append("<tr><h2>Statut : </h2>" + "<h2>" + com.Statut.ToString() + "</h2></tr></table>");
             html.Append(String.Format("<asp:Button Text=\"accepter\" runat\"server\" ID=\"btn{0}\" Visible=\"true\"/>", p_rendu));
            
            return html;
        }
       /* public void btnAccepter(int p_rendu)
        {
            Button btn = new Button();
            btn.Text = "Accepter";
            btn.ID = "btnAcc" + p_rendu.ToString();
            btn.Click += (sender, args) =>
            {
                this.m_ListCommande[p_rendu].Statut = BDGestion.Instance.GetStatutCommande(2); 
            };
            btn.Visible = true;
            this.placeHolder1 = new PlaceHolder();
            this.placeHolder1.Controls.Add(btn);
            this.placeHolder1.ID = btn.ID;
           // this.placeHolder1
        }*/
        public void btnRefuse(int p_rendu)
        {
            Button btn = new Button();
            btn.Text = "Refusé";
            btn.ID = "btnRef" + p_rendu.ToString();
            btn.Click += (sender, args) =>
            {
                this.m_ListCommande[p_rendu].Statut = BDGestion.Instance.GetStatutCommande(3);
            };
 
        }
        private void initList()
        {
            // avoir une methode getCommandeParStatut(Statut p_statut)??
            this.m_ListCommande = BDGestion.Instance.GetCommandes().ToList();
            
        }
        private void nbreDeCommande()
        {
            this.m_nbreCommande = this.m_ListCommande.Count();
        }
    }
}