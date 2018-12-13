using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Concept
{
    public class BDGestion
    {
        private SqlConnection m_Connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\admin\Documents\GitHub\CS_TP04\Concept\Concept\App_Data\Concept.mdf;Integrated Security = True");

        private BDGestion() {
            m_Connection.Open();
        }

        public static BDGestion Instance { get; } = new BDGestion();

        public void ajouter(Commande p_Commande, int p_Id_User, int p_Id_Resto)
        {
            int id_Commande = 0;
            SqlCommand command = new SqlCommand("CreerCommande", this.m_Connection)
            { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@p_Id_Utilisateur", p_Id_User);
            command.Parameters.AddWithValue("@p_Id_Restaurant", p_Id_Resto);
            command.Parameters.AddWithValue("@p_Id_Commande", id_Commande);
            command.Parameters.AddWithValue("@p_Adresse", p_Commande.AdresseLivraison);
            command.ExecuteNonQuery();
            command = new SqlCommand("AjouterDansCommande", this.m_Connection){ CommandType = CommandType.StoredProcedure };
            foreach (KeyValuePair<Produit, uint> produit in p_Commande)
            {
                command.Parameters.AddWithValue("@p_Id_Commande", id_Commande);
                command.Parameters.AddWithValue("@p_Id_Produit", produit.Key.Id);
                command.Parameters.AddWithValue("@p_Id_Commande", produit.Value);
                command.ExecuteNonQuery();
            }
        }

        public void ajouter(Produit p_Produit)
        {
            SqlCommand command = new SqlCommand("CreerProduit", this.m_Connection)
            { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@p_Nom", p_Produit.Nom);
            command.Parameters.AddWithValue("@p_Desc", p_Produit.Description);
            command.Parameters.AddWithValue("@p_Prix", p_Produit.Prix);
            command.Parameters.AddWithValue("@p_Path", "");
            command.Parameters.AddWithValue("@p_Categorie", p_Produit.Categorie);
            command.ExecuteNonQuery();
        }

        public void ajouter(Restaurant p_Restaurant)
        {
            // TODO
        }

        public void ajouter(Utilisateur p_Utilisateur)
        {
            SqlCommand command = new SqlCommand("CreerUtilisateur", this.m_Connection)
            { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@p_nom", p_Utilisateur.Nom);
            command.Parameters.AddWithValue("@p_password", p_Utilisateur.MotDePasse);
            command.Parameters.AddWithValue("@p_adresse", p_Utilisateur.Adresse);
            command.Parameters.AddWithValue("@p_email", p_Utilisateur.Email);
            command.Parameters.AddWithValue("@p_type", p_Utilisateur.Type);
            command.Parameters.AddWithValue("@p_restaurant", p_Utilisateur.Restaurant == null ? 0 : p_Utilisateur.Restaurant.Id);
            command.ExecuteNonQuery();
        }

        // Peut-être pas nécessaire...
        public void Sauvegarder()
        {
            // TODO
        }

        public IList<Commande> GetCommandes()
        {
            
            return null;
        }

        public IList<Commande> GetCommandes(int p_Id)
        {
            // TODO
            return null;
        }

        public IList<Commande> GetCommandesParStatut(int p_Id_Resto, char p_Id_Statut)
        {
            SqlCommand command = new SqlCommand("GetCommandesParStatut", this.m_Connection)
            { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@p_Id_Resto", p_Id_Resto);
            command.Parameters.AddWithValue("@p_Id_Statut", p_Id_Statut);
            command.ExecuteNonQuery();
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

        public void Supprimer(Restaurant p_Restaurant)
        {
            // TODO
        }

        public void SetStatutCommande(int p_Id_Commande, char p_Id_Statut)
        {
            // TODO
        }
    }
}