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
        private static Menu m_Menu;

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!this.IsPostBack)
            {
                m_Menu = new Menu();                
            }
            this.udapteMenu();
        }

        protected void btn_ajouter_Click(object sender, EventArgs e)
        {
            var nom = this.view_Produits.SelectedRow.Cells[1].Text;
            var prod = BDGestion.Instance.GetProduits().SingleOrDefault(p => p.Nom.Equals(nom));
            if (prod != null) m_Menu.Ajouter(prod);
            this.udapteMenu();
        }

        protected void btn_retirer_Click(object sender, EventArgs e)
        {
            var i = this.view_Menu.SelectedIndex;
            if (m_Menu.ListeProduit.Count > 0 && i > -1)
            {
                m_Menu.ListeProduit.RemoveAt(i);
                this.udapteMenu();
            }
        }

        protected void btn_enregistrer_Click(object sender, EventArgs e)
        {
            var i = int.Parse(this.ddl_restaurant.SelectedValue);
            BDGestion.Instance.ajouter(m_Menu, i);
        }

        protected void btn_annuler_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gestion.aspx");
        }

        private void udapteMenu()
        {
            this.view_Menu.DataSource = m_Menu.ListeProduit.Select(p => new ProdView(p));
            this.view_Menu.DataBind();
            this.view_Produits.DataSource = BDGestion.Instance.GetProduits().Where(p => !m_Menu.ListeProduit.Contains(p)).Select(p => new ProdView(p));
            this.view_Produits.DataBind();
        }

        protected void ddl_restaurant_DataBound(object sender, EventArgs e)
        {
            if (this.ddl_restaurant.Items.Count < 1)
            {
                this.PH_CreationMenu.Visible = false;
                this.PH_Message.Visible = true;
            }
        }
    }
}