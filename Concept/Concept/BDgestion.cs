using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concept
{
    public class BDGestion
    {
        private BDGestion() { }

        public static BDGestion Instance { get; } = new BDGestion();

        public void ajouter(Commande p_Commande, int p_Id)
        {
            // TODO
        }

        public void ajouter(Produit p_Produit)
        {
            // TODO
        }

        public void ajouter(Restaurant p_Restaurant)
        {
            // TODO
        }

        public void ajouter(Utilisateur p_Utilisateur)
        {
            // TODO
        }

        // Peut-être pas nécessaire...
        public void Sauvegarder()
        {
            // TODO
        }

        public IList<Commande> GetCommandes()
        {
            // TODO
            return null;
        }

        public IList<Commande> GetCommandes(int p_Id)
        {
            // TODO
            return null;
        }

        public IList<Produit> GetProduits()
        {
            // TODO
            return null;
        }

        public Produit GetProduit(int p_Id)
        {
            // TODO
            return null;
        }

        public IList<Restaurant> GetRestaurants()
        {
            // TODO
            return null;
        }

        public Restaurant GetRestaurant(int p_Id)
        {
            // TODO
            return null;
        }    

        public Utilisateur GetUtilisateur(int p_Id)
        {
            // TODO
            return null;
        }

        public IList<TypeUtilisateur> GetTypesUtilisateur()
        {
            // TODO
            return null;
        }

        public TypeUtilisateur GetTypeUtilisateur(int p_Id)
        {
            // TODO
            return null;
        }

        public IList<StatutCommande> GetStatutsCommande()
        {
            // TODO
            return null;
        }

        public StatutCommande GetStatutCommande(int p_Id)
        {
            // TODO
            return null;
        }

        public IList<CategorieProduit> GetCategoriesProduit()
        {
            // TODO
            return null;
        }

        public CategorieProduit GetCategorieProduit(int p_Id)
        {
            // TODO
            return null;
        }

        public void Supprimer(Utilisateur p_Utilisateur)
        {
            // TODO
        }

        public void Supprimer(Restaurant p_Utilisateur)
        {
            // TODO
        }
    }
}