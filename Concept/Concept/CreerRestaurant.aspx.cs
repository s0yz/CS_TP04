using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Concept
{
    public partial class CreerRestaurant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["image"] != null)
            {
                im_Resto.ImageUrl = Session["image"].ToString();
            }
        }

        protected void Upload(object sender, EventArgs e)
        {
            if (FileDialog.HasFile)
            {
                String savePath = String.Format(@"{0}/img/restaurant/{1}", Request.PhysicalApplicationPath, FileDialog.FileName);
                FileDialog.SaveAs(savePath);
                Session.Add("image", savePath);
                im_Resto.ImageUrl = String.Format("../img/restaurant/{0}", FileDialog.FileName);
            }
        }

        protected void Finish(object sender, EventArgs e)
        {
            Restaurant nouveauResto = new Restaurant(tb_adresse.Text, tb_telephone.Text, im_Resto.ImageUrl);
            nouveauResto.Commit();
        }
    }
}