using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Commande(Utilisateur p_client, string p_adresse, DateTime p_Date)
        {
            this.Client = p_client;
            this.AdresseLivraison = p_adresse;
            this.Date = p_Date;
        }

        public int Identifiant { get; private set; }
        
        public Utilisateur Client { get; private set; }

        public string AdresseLivraison { get; private set; }
        
        public DateTime Date { get; private set; }

        public StatutCommande Statut { get; private set; }

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

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach(KeyValuePair<Produit, uint> produit in this)
            {
                builder.Append(string.Format("{0} x {1}<br\\>", produit.Key.Nom, produit.Value));
            }
            return builder.ToString();
        }

        public decimal CalculerTotal() => this.Sum(p => p.Key.Prix * p.Value);

        public IEnumerator<KeyValuePair<Produit, uint>> GetEnumerator() => this.m_Produits.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.m_Produits.GetEnumerator();
    }
}