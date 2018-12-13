using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concept
{
    public class Utilisateur
    {
        public Utilisateur(string p_nom, string p_passe,TypeUtilisateur p_typeU, 
            string p_adresse, string p_email, Restaurant p_restaurant)
        {
            this.Nom = p_nom;
            this.MotDePasse = p_passe;
            this.Type = p_typeU;
            this.Commandes = new List<Commande>();
            this.Adresse = p_adresse;
            this.Email = p_email;
            this.Restaurant = p_restaurant;
        }
        public string Nom { get; private set; }

        public string MotDePasse { get; private set; }

        public TypeUtilisateur Type { get; private set; }

        public string Adresse { get; private set; }

        public string Email { get; private set; }

        public List<Commande> Commandes { get; private set; }

        public Restaurant Restaurant { get; private set; }

        public void AjouterCommande(Commande p_commande)
        {
            this.Commandes.Add(p_commande);
        }
    }
}