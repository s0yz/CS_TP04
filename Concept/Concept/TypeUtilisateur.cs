using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concept
{
    public class TypeUtilisateur
    {
        private int m_IDType;
        private readonly string m_Role;

        public TypeUtilisateur(int p_id,string p_role)
        {
            this.m_IDType = p_id;
            this.m_Role = p_role;
        }
        public int getId()
        {
            return this.m_IDType;
        }
        public string getRole()
        {
            return this.m_Role;
        }
    }
}