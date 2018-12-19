using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Concept
{
    public class Commande : IEnumerable<KeyValuePair<Produit, uint>>
    {        
        private Dictionary<Produit, uint> m_Produits = new Dictionary<Produit, uint>();

        public Commande(int p_Id, Utilisateur p_Client, StatutCommande p_Statut, string p_Adresse, DateTime p_Date)
        {
            Identifiant = p_Id;
            Client = p_Client;
            Statut = p_Statut;
            AdresseLivraison = p_Adresse;
            Date = p_Date;
        }
    
        public Commande(Utilisateur p_Client, string p_Adresse, DateTime p_Date)
        {

            Client = p_Client;
            AdresseLivraison = p_Adresse;
            Date = p_Date;
        }

        public int Identifiant { get; private set; }
        
        public Utilisateur Client { get; private set; }

        public string AdresseLivraison { get; private set; }
        
        public DateTime Date { get; private set; }

        public StatutCommande Statut { get; private set; }

        public Dictionary<Produit, uint> Produits { get
            {
                return this.m_Produits;
            }
            private set
            {
                this.m_Produits = value;
            }
        }

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

        
        public decimal CalculerTotal() => this.Sum(p => p.Key.Prix * p.Value);

        public IEnumerator<KeyValuePair<Produit, uint>> GetEnumerator() => this.m_Produits.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.m_Produits.GetEnumerator();
    }
}