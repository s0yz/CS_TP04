using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concept
{
    public class Menu
    {
        public Menu()
        {
            this.Id = 0;
            this.ListeProduit = new List<Produit>();
        }

        public Menu(int p_Id)
        {
            this.Id = p_Id;
            this.ListeProduit = new List<Produit>();
        }

        public int Id { get; private set; }

        public IList<Produit> ListeProduit { get; private set; }

        public void Ajouter(Produit p_produit)
        {
            this.ListeProduit.Add(p_produit);
        }

        public void Retirer(Produit p_produit)
        {
            this.ListeProduit.Remove(p_produit);
        }
    }
}