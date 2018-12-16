using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Concept
{
    public class Produit
    {        
        public Produit(int p_Id, string p_Nom, string p_Description, decimal p_Prix, string p_Image, CategorieProduit p_Categorie)
        {
            this.Id = p_Id;
            this.Nom = p_Nom;
            this.Description = p_Description;
            this.Prix = p_Prix;
            this.Image = p_Image;
            this.Categorie = p_Categorie;
        }

        public Produit(string p_Nom, string p_Description, decimal p_Prix, string p_Image, CategorieProduit p_Categorie)
        {
            this.Id = 0;
            this.Nom = p_Nom;
            this.Description = p_Description;
            this.Prix = p_Prix;
            this.Image = p_Image;
            this.Categorie = p_Categorie;
        }
                
        public int Id { get; private set; }

        [DisplayName("Produit")]
        public string Nom { get; private set; }

        [DisplayName("Description")]
        public string Description { get; private set; }

        [DisplayName("Prix")]
        public decimal Prix { get; private set; }

        [DisplayName("Image")]
        public string Image { get; private set; }

        [DisplayName("Catégorie")]
        public CategorieProduit Categorie{ get; private set; }
    }
}