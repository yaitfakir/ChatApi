using System;
using System.Collections.Generic;

namespace ChatAPI.Models.Result
{
    public partial class Todo
    {
        public int IdTodo { get; set; }
        public string TodoName { get; set; }
        public decimal? Prix { get; set; }
        public int Statue { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public int? IdJourneeDetail { get; set; }
    }
}
