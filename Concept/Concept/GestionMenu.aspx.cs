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

        List<Produit> m_Produits = new List<Produit>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Menu.DataSource = m_Produits;
            this.Menu.UpdateRow(0, false);
            m_Produits.Add(new Produit("allo", "bonsoir", 0.0,
            "", new CategorieProduit()));
            
        }
    }
}