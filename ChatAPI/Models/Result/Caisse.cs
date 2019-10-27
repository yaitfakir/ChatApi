using System;
using System.Collections.Generic;

namespace ChatAPI.Models.Result
{
    public partial class Caisse
    {
        public Caisse()
        {
            Journee = new HashSet<Journee>();
        }

        public int IdCaisse { get; set; }
        public int IdUser { get; set; }
        public DateTime DateDebut { get; set; }
        public decimal PrixUnit { get; set; }
        public DateTime? DateFin { get; set; }
        public decimal? PrixFinal { get; set; }
        public int IdMois { get; set; }
        public int? Status { get; set; }

        public virtual Mois IdMoisNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
        public virtual ICollection<Journee> Journee { get; set; }
    }
}
