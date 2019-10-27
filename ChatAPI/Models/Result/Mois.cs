using System;
using System.Collections.Generic;

namespace ChatAPI.Models.Result
{
    public partial class Mois
    {
        public Mois()
        {
            Caisse = new HashSet<Caisse>();
        }

        public int IdMois { get; set; }
        public string NameMois { get; set; }

        public virtual ICollection<Caisse> Caisse { get; set; }
    }
}
