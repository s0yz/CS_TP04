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

        }

        protected void click_accepte(object sender, EventArgs e)
        {

        }

        private bool verif()
        {
            return this.tb_nom.Text != "" && this.tb_motDePasse.Text != "" && this.tb_motDePasse.Text == this.tb_verifPasse.Text && this.ddl_typeUtilisateur.SelectedValue != null;
        }
    }
}