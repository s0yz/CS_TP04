using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concept
{
    public class Restaurant
    {
        public Restaurant(int p_Id, string p_Adresse, string p_Telephone, string p_Path)
        {
            this.Id = p_Id;
            this.Adresse = p_Adresse;
            this.Telephone = p_Telephone;
            this.ImagePath = p_Path;
        }

        public int Id { get; private set; }

        public string Adresse { get; private set; }

        public string Telephone { get; private set; }

        public string ImagePath { get; private set; }

        public string Menu { get; set; }


    }
}