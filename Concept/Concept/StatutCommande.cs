using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concept
{
    public class StatutCommande
    {
        private int m_Id;
        private readonly string m_Libelle;

        public StatutCommande(int p_id, string p_libelle)
        {
            this.m_Id = p_id;
            this.m_Libelle = p_libelle;
        }

        public string getLibelle()
        {
            return this.m_Libelle;
        }
    }

}