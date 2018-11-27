using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concept
{
    public class Commande
    {
        private int m_Identifiant;
        private Utilisateur m_Client;
        private string m_AdresseLivraison;
        private DateTime m_Date;
        private StatutCommande m_Statut;
        private List<Produit> m_ListeProduits;

        public Commande(Utilisateur p_client, StatutCommande p_statut)
        {
            this.m_Client = p_client;
            this.m_AdresseLivraison = p_client.getAdresse();
            this.m_Date = DateTime.Now;
            this.m_Statut = p_statut;
            this.m_ListeProduits = new List<Produit>();
        }
        public Commande(Utilisateur p_client, StatutCommande p_statut, string p_adresse)
        {
            this.m_Client = p_client;
            this.m_AdresseLivraison = p_adresse;
            this.m_Date = DateTime.Now;
            this.m_Statut = p_statut;
            this.m_ListeProduits = new List<Produit>();
        }


        public Utilisateur getClient()
        {
            return this.m_Client;
        }
        public void setClient(Utilisateur p_client)
        {
            this.m_Client = p_client;
        }
        public string getAdresse()
        {
            return this.m_AdresseLivraison;
        }
        public void setAdresse(string p_adresse)
        {
            this.m_AdresseLivraison = p_adresse;
        }


        public void Ajouter(Produit p_produit, int p_quantite)
        {
            for (int i = 0; i < p_quantite; i++)
            {
                this.m_ListeProduits.Add(p_produit);
            }
        }
        public void Retirer(Produit p_produit, int p_quantite)
        {
            for (int i = 0; i < p_quantite; i++)
            {
                if (this.m_ListeProduits.Contains(p_produit))
                {
                    this.m_ListeProduits.Remove(p_produit);
                }
            }
        }

        public double CalculerTotal()
        {
            double prix = 0;
            foreach (Produit item in this.m_ListeProduits)
            {
                prix += item.getPrix();
            }
            return prix;
        }
    }
}