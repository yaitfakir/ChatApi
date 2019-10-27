using System;
using System.Collections.Generic;

namespace ChatAPI.Models.Result
{
    public partial class Journee
    {
        public Journee()
        {
            JourneeDetail = new HashSet<JourneeDetail>();
        }

        public int IdJournee { get; set; }
        public int IdCaisse { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Prix { get; set; }

        public virtual Caisse IdCaisseNavigation { get; set; }
        public virtual ICollection<JourneeDetail> JourneeDetail { get; set; }
    }
}
