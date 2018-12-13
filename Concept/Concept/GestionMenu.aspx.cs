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
            m_Produits.Add(new Produit("allo", "bonsoir", 50.0m,
           "", new CategorieProduit('b', "Boisson")));
            this.Menu.DataSource = m_Produits.Select(p => new ProdView(p));
            this.Menu.DataBind();
            
            

        }
    }
}