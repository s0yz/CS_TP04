using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Concept
{
<<<<<<< HEAD
    public class Commande : IEnumerable<Produit>
    {
        
        private List<Produit> m_ListeProduits;
=======
    public class Commande : IEnumerable<KeyValuePair<Produit, uint>>
    {        
        private Dictionary<Produit, uint> m_Produits = new Dictionary<Produit, uint>();
>>>>>>> master

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
        }

        public int Identifiant { get; private set; }

<<<<<<< HEAD
      
        public Utilisateur Client { get; private set; }

      
=======
        public Utilisateur Client { get; private set; }

>>>>>>> master
        public string AdresseLivraison { get; set; }
        
        public DateTime Date { get; private set; }

        public StatutCommande Statut { get; set; }

        public void Ajouter(Produit p_produit, uint p_quantite)
        {
            if (this.m_Produits.ContainsKey(p_produit))
            {
                this.m_Produits[p_produit] += p_quantite;
            }
            else this.m_Produits.Add(p_produit, p_quantite);
        }

        public void Retirer(Produit p_produit, uint p_quantite)
        {
            if (this.m_Produits.ContainsKey(p_produit))
            {
                if ((this.m_Produits[p_produit] -= p_quantite) < 1)
                {
                    this.m_Produits.Remove(p_produit);
                }
            }
        }
        
        public double CalculerTotal() => this.Sum(p => p.Key.getPrix() * p.Value);

<<<<<<< HEAD
        
        public double CalculerTotal() => this.Sum(p => p.getPrix());

        public IEnumerator<Produit> GetEnumerator() => m_ListeProduits.GetEnumerator();
=======
        public IEnumerator<KeyValuePair<Produit, uint>> GetEnumerator() => this.m_Produits.GetEnumerator();
>>>>>>> master

        IEnumerator IEnumerable.GetEnumerator() => this.m_Produits.GetEnumerator();
    }
}