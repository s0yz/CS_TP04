using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concept
{
    public class FauxMain
    {
        static void Main()
        {
            BDGestion.Instance.ajouter(new Produit("Patate", "Patate", 10.10, "", new CategorieProduit('X', "Porno")));
        }
    }
}