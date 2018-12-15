using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Concept
{
    public class ProdView
    {
        CategorieProduit m_Categorie;

        public ProdView(Produit p_Produit)
        {
            this.Nom = p_Produit.Nom;
            this.Prix = p_Produit.Prix;
            this.m_Categorie = p_Produit.Categorie;
        }

        [DisplayName("Produit")]
        public string Nom { get; private set; }

        [DisplayName("Prix")]
        public decimal Prix { get; private set; }

        [DisplayName("Categorie")]
        public string Categorie
        {
            get => m_Categorie.Categorie;
        }
    }
}