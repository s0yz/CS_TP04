using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concept
{
    public class Commande : IEnumerable<Produit>
    {
        
        private List<Produit> m_ListeProduits;

        public Commande(Utilisateur p_client) :
            this(p_client, BDGestion.Instance.GetStatutCommande(0), p_client.getAdresse())
        {
        }

        public Commande(Utilisateur p_client, StatutCommande p_statut) :
            this(p_client, p_statut, p_client.getAdresse())
        {
        }

        public Commande(Utilisateur p_client, StatutCommande p_statut, string p_adresse)
        {
            this.Client = p_client;
            this.AdresseLivraison = p_adresse;
            this.Date = DateTime.Now;
            this.Statut = p_statut;
            this.m_ListeProduits = new List<Produit>();
        }

        public int Identifiant { get; private set; }

      
        public Utilisateur Client { get; private set; }

      
        public string AdresseLivraison { get; set; }
        
        public DateTime Date { get; private set; }

        public StatutCommande Statut { get; set; }

        public void Ajouter(Produit p_produit, int p_quantite)
        {
            for (int i = 0; i < p_quantite; i++)
            {
                this.m_ListeProduits.Add(p_produit);
            }
        }

        public void Retirer(Produit p_produit, uint p_quantite)
        {
            for (int i = 0; i < p_quantite; i++)
            {
                this.m_ListeProduits.Remove(p_produit);
            }
        }

        
        public double CalculerTotal() => this.Sum(p => p.getPrix());

        public IEnumerator<Produit> GetEnumerator() => m_ListeProduits.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_ListeProduits.GetEnumerator();
    }
}