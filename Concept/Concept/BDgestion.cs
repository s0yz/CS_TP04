using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Concept
{
    public class BDGestion
    {
        public const string pathCed = @"U:\Soyz\Documents\GitHub\CS_TP04\Concept\Concept\App_Data\Concept.mdf";
        public const string pathMax = @"C:\Users\admin\Documents\GitHub\CS_TP04\Concept\Concept\App_Data\Concept.mdf";
        public readonly IDictionary<char, StatutCommande> STATUT_COMMANDE;
        public readonly IDictionary<char, CategorieProduit> CATEGORIE_PRODUIT;
        public readonly IDictionary<char, TypeUtilisateur> TYPE_UTILISATEUR;
        private SqlConnection m_Connection = new SqlConnection($@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename={pathMax};Integrated Security = True");

        private BDGestion() {
            m_Connection.Open();
            this.STATUT_COMMANDE = this.GetStatutsCommande();
            this.CATEGORIE_PRODUIT = this.GetCategoriesProduit();
            this.TYPE_UTILISATEUR = this.GetTypesUtilisateur();
        }

        public static BDGestion Instance { get; } = new BDGestion();

        public void ajouter(Commande p_Commande, int p_Id_User, int p_Id_Resto)
        {
            SqlCommand command = new SqlCommand("CreerCommande", this.m_Connection)
            { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@p_Id_Utilisateur", p_Id_User);
            command.Parameters.AddWithValue("@p_Id_Restaurant", p_Id_Resto);
            command.Parameters.AddWithValue("@p_Adresse", p_Commande.AdresseLivraison);
            SqlDataReader receiver = command.ExecuteReader();
            //Verify
            receiver.Read();
            int id_Commande = (int)receiver["id_commande"];
            command = new SqlCommand("AjouterDansCommande", this.m_Connection){ CommandType = CommandType.StoredProcedure };
            foreach (KeyValuePair<Produit, uint> produit in p_Commande)
            {
                command.Parameters.AddWithValue("@p_Id_Commande", id_Commande);
                command.Parameters.AddWithValue("@p_Id_Produit", produit.Key.Id);
                command.Parameters.AddWithValue("@p_Nb", produit.Value);
                command.ExecuteNonQuery();
            }
            receiver.Close();
        }

        public void ajouter(Produit p_Produit)
        {
            SqlCommand command = new SqlCommand("CreerProduit", this.m_Connection)
            { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@p_Nom", p_Produit.Nom);
            command.Parameters.AddWithValue("@p_Desc", p_Produit.Description);
            command.Parameters.AddWithValue("@p_Prix", p_Produit.Prix);
            command.Parameters.AddWithValue("@p_Path", "");
            command.Parameters.AddWithValue("@p_Categorie", p_Produit.Categorie.Id);
            command.ExecuteNonQuery();
        }

        public void ajouter(Restaurant p_Restaurant)
        {
            SqlCommand command = new SqlCommand("CreerRestaurant", this.m_Connection)
            { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@p_Adresse", p_Restaurant.Adresse);
            command.Parameters.AddWithValue("@p_Telephone", p_Restaurant.Telephone);
            command.Parameters.AddWithValue("@p_Path", p_Restaurant.ImagePath);
            command.ExecuteNonQuery();
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

        public void ajouter(Menu p_Menu, int p_Id_Resto)
        {
            SqlCommand command = new SqlCommand("CreerMenu", this.m_Connection)
            { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@p_Restaurant", p_Id_Resto);
            command.ExecuteNonQuery();
            command = new SqlCommand("GetMenuResto", this.m_Connection)
            { CommandType = CommandType.StoredProcedure };
            SqlDataReader reader = command.ExecuteReader();
            //Verifier
            reader.Read();
            int id_menu = (int)reader["id_menu"];
            foreach (Produit produit in p_Menu.ListeProduit)
            {
                command = new SqlCommand("AjouterAuMenu", this.m_Connection)
                { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@p_Id_Menu", id_menu);
                command.Parameters.AddWithValue("@p_Id_Menu", produit.Id);
                command.ExecuteNonQuery();
            }
            reader.Close();
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

        public IList<Commande> GetCommandes(int p_Id_User)
        {
            SqlCommand command = new SqlCommand("GetCommandesParUser", this.m_Connection)
            { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@p_Id_Utilisateur", p_Id_User);
            SqlDataReader reader = command.ExecuteReader();
            List<Commande> commandes = new List<Commande>();
            while (reader.Read())
            {
                commandes.Add(new Commande(
                    (int)reader["id_commande"],
                    this.GetUtilisateur((int)reader["id_utilisateur"]),
                    STATUT_COMMANDE[(char)reader["id_statut"]],
                    (string)reader["adresse"],
                    (DateTime)reader["date_livraison"]));
                IDictionary<Produit, uint> produits = this.GetProduits((int)reader["id_commande"]);
                foreach (KeyValuePair<Produit, uint> produit in produits)
                {
                    commandes.Last<Commande>().Ajouter(produit.Key, produit.Value);
                }
            }
            reader.Close();
            return commandes;
        }

        public IList<Commande> GetCommandesParStatut(int p_Id_Resto, char p_Id_Statut)
        {
            SqlCommand command = new SqlCommand("GetCommandesParStatut", this.m_Connection)
            { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@p_Id_Resto", p_Id_Resto);
            command.Parameters.AddWithValue("@p_Id_Statut", p_Id_Statut);
            SqlDataReader reader = command.ExecuteReader();
            List<Commande> commandes = new List<Commande>();
            while (reader.Read()) {
                commandes.Add(new Commande(
                    (int)reader["id_commande"], 
                    this.GetUtilisateur((int)reader["id_utilisateur"]), 
                    STATUT_COMMANDE[(char)reader["id_statut"]], 
                    (string)reader["adresse"], 
                    (DateTime)reader["date_livraison"]));
                IDictionary<Produit, uint> produits = this.GetProduits((int)reader["id_commande"]);
                foreach (KeyValuePair<Produit, uint> produit in produits)
                {
                    commandes.Last<Commande>().Ajouter(produit.Key, produit.Value);
                }
            }
            reader.Close();
            return commandes;
        }

        public IList<Produit> GetProduits()
        {
            SqlCommand command = new SqlCommand("GetProduits", this.m_Connection)
            { CommandType = CommandType.StoredProcedure };
            SqlDataReader reader = command.ExecuteReader();
            List<Produit> produits = new List<Produit>();
            while (reader.Read()) {
                //produits.Add(new Produit(
                //    (int)reader["id_produit"],
                //    (string)reader["nom"],
                //    (string)reader["desc_prod"],
                //    (decimal)reader["prix"],
                //    (string)reader["path_image"],
                //    this.CATEGORIE_PRODUIT[(char)reader["id_cat"]]
                //));
                produits.Add(new Produit(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetDecimal(3),
                    reader.GetString(4),
                    this.CATEGORIE_PRODUIT[Convert.ToChar(reader["id_cat"])]
                ));
            }
            reader.Close();
            return produits;
        }

        public IDictionary<Produit, uint> GetProduits(int p_Id_Commande)
        {
            SqlCommand command = new SqlCommand("GetProduitsDeCommande", this.m_Connection) { CommandType = CommandType.StoredProcedure };
            SqlDataReader product_reader = command.ExecuteReader();
            Dictionary<Produit, uint> commandes = new Dictionary<Produit, uint>();
            while (product_reader.Read())
            {
                commandes.Add(new Produit(
                        (int)product_reader["id_produit"],
                        (string)product_reader["nom"],
                        (string)product_reader["desc_prod"],
                        (decimal)product_reader["prix"],
                        (string)product_reader["path_image"],
                        this.CATEGORIE_PRODUIT[(char)product_reader["id_cat"]]
                    ), 
                    (uint)product_reader["nb"]);
            }
            product_reader.Close();
            return commandes;
        }

        public Produit GetProduit(int p_Id)
        {
            // TODO
            return null;
        }

        public IList<Restaurant> GetRestaurants()
        {
            SqlCommand command = new SqlCommand("GetRestaurantAll", this.m_Connection) { CommandType = CommandType.StoredProcedure };
            SqlDataReader reader = command.ExecuteReader();
            List<Restaurant> restaurants = new List<Restaurant>();
            SqlDataReader menuGetter;
            while (reader.Read())
            {
                restaurants.Add(new Restaurant(
                    (int)reader["id_restaurant"],
                    (string)reader["adresse"],
                    (string)reader["telephone"],
                    (string)reader["path_image"]
                    ));
                IList<Produit> produits = new List<Produit>();
                command = new SqlCommand("GetMenuResto", this.m_Connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@p_Id_Resto", reader["id_restaurant"]);
                menuGetter = command.ExecuteReader();
                //Verifier
                menuGetter.Read();
                restaurants.Last<Restaurant>().Menu = GetMenu((int)menuGetter["id_menu"]);
            }
            reader.Close();
            return restaurants;
        }

        public Menu GetMenu(int p_Id)
        {
            Menu menu = new Menu();
            SqlCommand command = new SqlCommand("GetMenu", this.m_Connection) { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@p_Id_Menu", p_Id);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                menu.Ajouter(new Produit(
                    (int)reader["id_produit"],
                    (string)reader["nom"],
                    (string)reader["desc_prod"],
                    (decimal)reader["prix"],
                    (string)reader["path_image"],
                    CATEGORIE_PRODUIT[(char)reader["id_cat"]]
                    ));
            }
            reader.Close();
            return menu;
        }

        public Restaurant GetRestaurant(int p_Id)
        {
            SqlCommand command = new SqlCommand("GetRestaurantUn", this.m_Connection) { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@p_Id_Restaurant", p_Id);
            SqlDataReader reader = command.ExecuteReader();
            //Verifier
            reader.Read();
            Restaurant restaurant = new Restaurant(
                (int)reader["id_restaurant"],
                (string)reader["adresse"],
                (string)reader["telephone"],
                (string)reader["path_image"]
                );
            restaurant.Menu = this.GetMenu((int)reader["id_menu"]);
            reader.Close();
            return restaurant;
        }
        
        public Utilisateur Authentifier(string p_Nom, string p_Password)
        {
            SqlCommand command = new SqlCommand("AuthentifierUser", this.m_Connection) { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@p_Nom", p_Nom);
            command.Parameters.AddWithValue("@p_Password", p_Password);
            SqlDataReader reader = command.ExecuteReader();
            //Verifier
            if (reader.Read())
            {
                var u = new Utilisateur(
                    (int)reader["id_utlisateur"],
                    (string)reader["nom"],
                    (string)reader["password_user"],
                    TYPE_UTILISATEUR[(char)reader["id_type"]],
                    (string)reader["adresse"],
                    (string)reader["email"],
                    this.GetRestaurant((int)reader["id_restaurant"]),
                    this.GetCommandes((int)reader["id_utilisateur"])
                    );
                reader.Close();
                return u;
            }
            else
            {
                return null;
            }
        }

        public Utilisateur GetUtilisateur(int p_Id)
        {
            SqlCommand command = new SqlCommand("GetUtilisateur", this.m_Connection) { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@p_Id_Utilisateur", p_Id);
            SqlDataReader reader = command.ExecuteReader();
            //Verifier
            if (reader.Read())
            {
                var u = new Utilisateur(
                    (int)reader["id_utlisateur"],
                    (string)reader["nom"],
                    (string)reader["password_user"],
                    TYPE_UTILISATEUR[(char)reader["id_type"]],
                    (string)reader["adresse"],
                    (string)reader["email"],
                    this.GetRestaurant((int)reader["id_restaurant"]),
                    this.GetCommandes((int)reader["id_utilisateur"])
                    );
                reader.Close();
                return u;
            }
            else
            {
                return null;
            }
        }

        public IDictionary<char, TypeUtilisateur> GetTypesUtilisateur()
        {
            SqlCommand command = new SqlCommand("GetTypesUtilisateur", this.m_Connection) { CommandType = CommandType.StoredProcedure };
            SqlDataReader reader = command.ExecuteReader();
            Dictionary<char, TypeUtilisateur> types = new Dictionary<char, TypeUtilisateur>();
            while (reader.Read())
            {
                types.Add(Convert.ToChar(reader["id_type"]), new TypeUtilisateur(Convert.ToChar(reader["id_type"]), reader.GetString(1)));
                //types.Add((char)reader["id_type"], new TypeUtilisateur((char)reader["id_type"], (string)reader["desc_type"]));
            }
            reader.Close();
            return types;
        }

        public TypeUtilisateur GetTypeUtilisateur(int p_Id)
        {
            // TODO
            return null;
        }

        public IDictionary<char, StatutCommande> GetStatutsCommande()
        {
            SqlCommand command = new SqlCommand("GetStatutCommande", this.m_Connection) { CommandType = CommandType.StoredProcedure };
            SqlDataReader reader = command.ExecuteReader();
            Dictionary<char, StatutCommande> statut = new Dictionary<char, StatutCommande>();
            while (reader.Read())
            {
                statut.Add(Convert.ToChar(reader["id_statut"]), new StatutCommande(Convert.ToChar(reader["id_statut"]), reader.GetString(1)));
                //statut.Add((char)reader["id_statut"], new StatutCommande((char)reader["id_statut"], reader["desc_statut"].ToString()));
            }
            reader.Close();
            return statut;
        }

        public StatutCommande GetStatutCommande(int p_Id)
        {
            // TODO
            return null;
        }

        public IDictionary<char, CategorieProduit> GetCategoriesProduit()
        {
            SqlCommand command = new SqlCommand("GetCategoriesProduits", this.m_Connection) { CommandType = CommandType.StoredProcedure };
            SqlDataReader reader = command.ExecuteReader();
            Dictionary<char, CategorieProduit> categories = new Dictionary<char, CategorieProduit>();
            while (reader.Read())
            {
                categories.Add(Convert.ToChar(reader["id_cat"]), new CategorieProduit(Convert.ToChar(reader["id_cat"]), reader.GetString(1)));
                //categories.Add((char)reader["id_cat"], new CategorieProduit((char)reader["id_cat"], (string)reader["desc_cat"]));
            }
            reader.Close();
            return categories;
        }

        public CategorieProduit GetCategorieProduit(char p_Id)
        {
            return GetCategoriesProduit()[p_Id];
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
            SqlCommand command = new SqlCommand("SetStatutCommande", this.m_Connection)
            { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("@p_Id_Commande", p_Id_Commande);
            command.Parameters.AddWithValue("@p_Id_Statut", p_Id_Statut);
            command.ExecuteNonQuery();
        }
    }
}