using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Concept
{
    public partial class GestionMenu : System.Web.UI.Page
    {

        private static IList<Produit> m_Produits;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                m_Produits = new List<Produit>();
                BDGestion.Instance.ajouter(new Produit("Boisson fontaine", "", 1m, "", BDGestion.Instance.GetCategorieProduit('B')));
                BDGestion.Instance.ajouter(new Produit("Pepsi", "Bouteille", 1.25m, "", BDGestion.Instance.GetCategorieProduit('B')));
                BDGestion.Instance.ajouter(new Produit("Mountain Dew", "Bouteille", 1.25m, "", BDGestion.Instance.GetCategorieProduit('B')));
                BDGestion.Instance.ajouter(new Produit("Repas poitrine", "", 1.25m, "", BDGestion.Instance.GetCategorieProduit('R')));
                BDGestion.Instance.ajouter(new Produit("Repas cuisse", "", 1.25m, "", BDGestion.Instance.GetCategorieProduit('R')));
                BDGestion.Instance.ajouter(new Produit("Poutine poulet", "", 1.25m, "", BDGestion.Instance.GetCategorieProduit('R')));
            }
            this.view_Menu.DataSource = m_Produits.Select(p => new ProdView(p));
            this.view_Menu.DataBind();
            this.view_Produits.DataSource = BDGestion.Instance.GetProduits().Select(p => new ProdView(p));
            this.view_Produits.DataBind();
        }

        protected void btn_ajouter_Click(object sender, EventArgs e)
        {
            m_Produits.Add(new Produit("allo", "bonsoir", 50.0m, "", new CategorieProduit('b', "Boisson")));
            this.udapteMenu();
        }

        protected void btn_retirer_Click(object sender, EventArgs e)
        {
            m_Produits.RemoveAt(m_Produits.Count - 1);
            this.udapteMenu();
        }

        protected void btn_enregistrer_Click(object sender, EventArgs e)
        {

        }

        protected void btn_annuler_Click(object sender, EventArgs e)
        {

        }

        private void udapteMenu()
        {
            this.view_Menu.DataSource = m_Produits.Select(p => new ProdView(p));
            this.view_Menu.DataBind();
        }               
    }
}