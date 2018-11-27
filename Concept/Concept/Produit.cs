using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concept
{
    public class Produit
    {
        private int m_Identifiant;
        private string m_Nom;
        private string m_Description;
        private double m_Prix;
        private string m_Image;
        private CategorieProduit m_Categorie;

        public Produit(string p_nom, string p_description, double p_prix,
            string p_image,CategorieProduit p_categorie)
        {
            this.m_Nom = p_nom;
            this.m_Description = p_description;
            this.m_Prix = p_prix;
            this.m_Image = p_image;
            this.m_Categorie = p_categorie;
        }

        public void setNom(string p_nom)
        {
            this.m_Nom = p_nom;
        }
        public string getNom()
        {
            return this.m_Nom;
        }
        public void setDescription(string p_description)
        {
            this.m_Description = p_description;
        }
        public string getDescription()
        {
            return this.m_Description;
        }
        public void setPrix(double p_prix)
        {
            this.m_Prix = p_prix;
        }
        public double getPrix()
        {
            return this.m_Prix;
        }
        public void setImage(string p_image)
        {
            this.m_Image = p_image;
        }
        public string getImage()
        {
            return this.m_Image;
        }
        public void setCategorie(CategorieProduit p_categorie)
        {
            this.m_Categorie = p_categorie;
        }
        public CategorieProduit getCategorie()
        {
            return this.m_Categorie;
        }


    }
}