using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concept
{
    public class TypeUtilisateur
    {
        public TypeUtilisateur(int p_id,string p_role)
        {
            this.Id = p_id;
            this.Role = p_role;
        }
        public int Id { get; private set;}
        public string  Role { get; private set;}
}
}