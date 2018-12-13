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
            this.Menu.DataSource = m_Produits;
            this.Menu.DataBind();
            
            m_Produits.Add(new Produit("allo", "bonsoir", 0.0,
            "", new CategorieProduit()));

        }
    }
}