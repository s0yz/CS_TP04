using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concept
{
    public class StatutCommande
    {
        public StatutCommande(char p_id, string p_libelle)
        {
            this.ID = p_id;
            this.Libelle = p_libelle;
        }

        public char ID { get; private set; }

        public string Libelle { get; private set; }

        public override string ToString() => Libelle;
    }

}