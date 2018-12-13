using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concept
{
    public class Menu
    {
        private int m_Identifiant;
        private List<Produit> m_ListeProduits;

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

        public List<Produit> ListeProduit { get; private set; }

        public void Ajouter(Produit p_produit)
        {
            this.m_ListeProduits.Add(p_produit);
        }

        public void Retirer(Produit p_produit)
        {
            this.m_ListeProduits.Remove(p_produit);
        }
    }
}