using System;
using System.Collections.Generic;

namespace ChatAPI.Models.Result
{
    public partial class JourneeDetail
    {
        public int IdJourneeDetail { get; set; }
        public int IdJournee { get; set; }
        public int IdUser { get; set; }
        public decimal Prix { get; set; }
        public string Motif { get; set; }
        public DateTime Date { get; set; }
        public int? Status { get; set; }
        public byte[] Image { get; set; }

        public virtual Journee IdJourneeNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
    }
}
