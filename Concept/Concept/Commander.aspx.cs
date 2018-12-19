﻿using System;
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
        private Commande commande;
        private IList<Produit> listProduit;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Utilisateur"] == null)
            {
                Response.Redirect("Authentification.aspx");
            }
            if (!this.IsPostBack)
            {
                this.Session["commande"] = new Commande((Utilisateur)this.Session["Utilisateur"], "", DateTime.Now);
                this.commande = (Commande)this.Session["commande"];
                catProd = 'R';
                this.Session["cate"] = 'R';


            }
            this.listProduit = BDGestion.Instance.GetProduits();
            this.commande = (Commande)this.Session["commande"];
            if (this.Request.Form["Add"] != null)
            {
                bool trouve = false;
                for (int x =0; x < this.listProduit.Count && trouve == false; ++x)
                {
                    if (this.listProduit[x].Id == Convert.ToInt32(this.Request.Form["Add"].ToString().Substring(3)))
                    {
                        this.commande.Ajouter(this.listProduit[x], 1);
                        trouve = true;
                    }
                }
                catProd = (char)this.Session["cate"];
               
            }
            if(this.Request.Form["moin"] != null)
            {
                bool trouve = false;
                for (int x = 0; x < this.listProduit.Count && trouve == false; ++x)
                {
                    if (this.listProduit[x].Id == Convert.ToInt32(this.Request.Form["moin"].ToString().Substring(3)))
                    {
                        this.commande.Retirer(this.listProduit[x], 1);
                        trouve = true;
                    }
                }
                catProd = (char)this.Session["cate"];

            }
        }

        protected void entre_click(object sender, EventArgs e)
        {
            catProd = 'E';
            this.Session["cate"] = 'E';
        }

        protected void repas_click(object sender, EventArgs e)
        {
            catProd = 'R';
            this.Session["cate"] = 'R';
        }

        protected void dessert_click(object sender, EventArgs e)
        {
            catProd = 'D';
            this.Session["cate"] = 'D';
        }

        protected void boisson_click(object sender, EventArgs e)
        {
            catProd = 'B';
            this.Session["cate"] = 'B';
        }

        public string construireHtml()
        {
            IList<Produit> listProd = BDGestion.Instance.GetProduits();
            StringBuilder html = new StringBuilder();
            int nbreProd = 0;
            html.Append("<div class=\"col-3-de-4\">");
            html.Append("<div class=\"row\">");
            html.Append("<form action=\"/Commander.aspx\">");
            foreach (Produit prod in listProd)
            {
                if (prod.Categorie == BDGestion.Instance.CATEGORIE_PRODUIT[catProd])
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
                    html.Append(string.Format(" <img class=\"menu-item__img\" src=\"{0}\" alt=\" \">",prod.Image));
                    html.Append("<div class=\"menu-item__quantite-container\">");
                    html.Append(string.Format("<input type=\"submit\" name=\"Add\" id btn-add-product   class=\"menu-item__quantite\" value=\" + {0}\">",prod.Id));
                    html.Append(string.Format("<input type=\"submit\" name=\"moin\" class=\"menu-item__quantite\" value=\" - {0}\" />", prod.Id));
                    
                    html.Append("</div>");
                    html.Append("</div>");
                    html.Append("</div>");
                    nbreProd++;
                }
            }
            html.Append("</form>");
            html.Append("</div>");
            html.Append("</div>");
            return html.ToString();
        }

        protected void Accept_click(object sender, EventArgs e)
        {

            BDGestion.Instance.ajouter(this.commande,((Utilisateur)this.Session["Utilisateur"]).Id,1);
            this.Response.Redirect("Default.aspx");

        }
    }
}