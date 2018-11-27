using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concept
{
    public class Utilisateur
    {
        private int m_IdUtilisateur;
        private string m_NomUtilisateur;
        private string m_MotDePasse;
        private TypeUtilisateur m_TypeUtilisateur;
        private List<Commande> m_ListeCommande;
        private string m_Adresse;
        private string m_Email;
        private Restaurant m_Restaurant;

        public Utilisateur(string p_nom, string p_passe,TypeUtilisateur p_typeU, 
            string p_adresse, string p_email, Restaurant p_restaurant)
        {
            this.m_NomUtilisateur = p_nom;
            this.m_MotDePasse = p_passe;
            this.m_TypeUtilisateur = p_typeU;
            this.m_ListeCommande = new List<Commande>();
            this.m_Adresse = p_adresse;
            this.m_Email = p_email;
            this.m_Restaurant = p_restaurant;
        }
        // get et set
        public string getNom()
        {
            return this.m_NomUtilisateur;
        }
        public void setNom(string p_nom)
        {
            this.m_NomUtilisateur = p_nom;
        }
        public string getMotDePasse()
        {
            return this.m_MotDePasse;
        }
        public void setMotDePasse(string p_passe)
        {
            this.m_MotDePasse = p_passe;
        }
        public TypeUtilisateur getTypeU()
        {
            return this.m_TypeUtilisateur;
        }
        public void setTypeU(TypeUtilisateur p_typeU)
        {
            this.m_TypeUtilisateur = p_typeU;
        }
        public string getAdresse()
        {
            return this.m_Adresse;
        }
        public void setAdresse(string p_adresse)
        {
            this.m_Adresse = p_adresse;
        }
        public string getEmail()
        {
            return this.m_Email;
        }
        
        public List<Commande> getCommandes()
        {
            return this.m_ListeCommande;
        }

        public Restaurant GetRestaurant()
        {
            return this.m_Restaurant;
        }


        public void AjouterCommande(Commande p_commande)
        {
            this.m_ListeCommande.Add(p_commande);
        }

        
    }
}