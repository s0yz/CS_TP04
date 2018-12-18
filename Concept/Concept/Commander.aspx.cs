using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Concept
{
    public partial class Commander : System.Web.UI.Page
    {
        private char catProd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                catProd = 'R';
            }
            if(this.Request.Form["Add"] != null)
            {
                string valeur = this.Request.Form["Add"].ToString().Substring(3);
                int qte = Convert.ToInt32(this.Request.Form["Quantite" + valeur]);

            }
        }

        protected void entre_click(object sender, EventArgs e)
        {
            catProd = 'E';
        }

        protected void repas_click(object sender, EventArgs e)
        {
            catProd = 'R';
        }

        protected void dessert_click(object sender, EventArgs e)
        {
            catProd = 'D';
        }

        protected void boisson_click(object sender, EventArgs e)
        {
            catProd = 'B';
        }

        public string construireHtml()
        {
            IList<Produit> listProd = BDGestion.Instance.GetProduits();
            StringBuilder html = new StringBuilder();
            int nbreProd = 0;
            html.Append("<div class=\"col-3-de-4\">");
            html.Append("<div class=\"row\">");
            foreach (Produit prod in listProd)
            {
                

                if(prod.Categorie == BDGestion.Instance.CATEGORIE_PRODUIT[catProd])
                {
                    if (nbreProd == 3)
                    {
                        html.Append("</div");
                        html.Append("<div class=\"row\">");
                        nbreProd = 0;
                    }
                    html.Append("<div class=\"col-1-de-3\">");
                    html.Append("<div class=\"menu-item\">");
                    html.Append(string.Format("<h3 class=\"menu-item__titre\">{0}</h3>",prod.Nom));
                    html.Append(string.Format("<h3 class=\"menu-item__prix\" >{0}</h3>",prod.Prix));
                    html.Append(string.Format(" <img class=\"menu-item__img\" src=\"{0}\" alt=\"Repas poulet\">",prod.Image));
                    html.Append("<div class=\"menu-item__quantite-container\">");
                    html.Append("<form action=\"/Commander.aspx\">");
                    html.Append(string.Format("<input type=\"submit\" name=\"Add\"  class=\"menu-item__quantite\" value=\" + {0} \">",prod.Nom));
                    html.Append(string.Format("<input type=\"text\" class=\"menu-item__quantite\" name=\"Quantite{0}\" value=\"0\">", prod.Nom));
                    html.Append(string.Format("<input type=\"submit\" name=\"moin\" class=\"menu-item__quantite\" value=\" - {0} \" />", prod.Nom));
                    html.Append("</form>");
                    html.Append("</div>");
                    html.Append("<a href = \"#\" class=\"btn btn--commande-ajouter\">Ajouter</a>");
                    html.Append("</div>");
                    html.Append("</div>");
                    /* < div class="menu-item">
                        <h3 class="menu-item__titre">Repas poulet</h3>
                        <h3 class="menu-item__prix" >14,99$</h3>
                        <img class="menu-item__img" src="/img/repas_poulet.jpg" alt="Repas poulet">
                        <a href = "#" class="menu-item__details">Voir les détails</a>
                        <div class="menu-item__quantite-container">
                            <button class="btn btn--quantite">+</button>
                            <p class="menu-item__quantite">5</p>
                            <button class="btn btn--quantite">-</button>
                        </div>
                        <a href = "#" class="btn btn--commande-ajouter">Ajouter</a>
                    </div>*/
                    nbreProd++;
                }


            }
            html.Append("</div>");
            html.Append("</div>");
            return html.ToString();
        }
    }
}