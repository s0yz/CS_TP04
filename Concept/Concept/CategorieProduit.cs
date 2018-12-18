using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concept
{
    public class CategorieProduit
    {
        public CategorieProduit(char p_Id, string p_Categorie)
        {
            this.Id = p_Id;
            this.Categorie = p_Categorie;
        }

        public char Id { get; private set; }

        public string Categorie { get; private set; }

        public override string ToString() => Categorie;
    }
}