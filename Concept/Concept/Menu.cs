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

        public void Ajouter(Produit p_produit)
        {
            this.m_ListeProduits.Add(p_produit);
        }
        public void Retirer(Produit p_produit)
        {
            this.m_ListeProduits.Remove(p_produit);
        }
        public int getId()
        {
            return this.m_Identifiant;
        }
        public List<Produit> getProduits()
        {
            return this.m_ListeProduits;
        }
    }
}