using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Concept
{
    public partial class CreerCompte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Utilisateur"] == null || ((Utilisateur)Session["Utilisateur"]).Type.Id != 'A')
            {
                Response.Redirect("Default.aspx");
            }

        }

        protected void click_accepte(object sender, EventArgs e)
        {
            if (verif())
            {
                Utilisateur nouveau = new Utilisateur
                                     (this.tb_nom.Text, 
                                      this.tb_motDePasse.Text,
                                      BDGestion.Instance.TYPE_UTILISATEUR[Convert.ToChar(this.ddl_typeUtilisateur.SelectedItem.Value)],
                                      this.tb_adresse.Text,
                                      this.tb_email.Text,
                                      BDGestion.Instance.GetRestaurant(Convert.ToInt32(this.ddl_Restaurant.SelectedItem.Value)));
                BDGestion.Instance.ajouter(nouveau);

                Response.Redirect("Gestion.aspx");

            }
        }

        private bool verif()
        {
            return this.tb_nom.Text != "" && 
                this.tb_motDePasse.Text != "" &&
                this.tb_motDePasse.Text == this.tb_verifPasse.Text &&
                this.ddl_typeUtilisateur.SelectedValue != null &&
                this.tb_email.Text != null &&
                this.tb_adresse.Text != null &&
                this.ddl_Restaurant.SelectedValue != null;
        }

        protected void Annuler(object sender, EventArgs e)
        {
            Response.Redirect("Gestion.aspx");
        }
    }
}