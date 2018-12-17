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

        private static List<Produit> m_Produits;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                m_Produits = new List<Produit>();
            }
            this.view_Menu.DataSource = m_Produits;//.Select(p => new ProdView(p));
            this.view_Menu.DataBind();
            this.view_Produits.DataSource = m_Produits;//.Select(p => new ProdView(p));
            this.view_Produits.DataBind();
        }

        protected void btn_ajouter_Click(object sender, EventArgs e)
        {
            m_Produits.Add(new Produit("allo", "bonsoir", 50.0m, "", new CategorieProduit('b', "Boisson")));
        }

        protected void btn_retirer_Click(object sender, EventArgs e)
        {
            m_Produits.RemoveAt(m_Produits.Count - 1);
        }

        protected void btn_enregistrer_Click(object sender, EventArgs e)
        {

        }

        protected void btn_annuler_Click(object sender, EventArgs e)
        {

        }
    }
}