using System;
using System.Collections.Generic;

namespace ChatAPI.Models.Result
{
    public partial class Message
    {
        public int IdMessage { get; set; }
        public string MessageContent { get; set; }
        public int? IdUser { get; set; }
        public DateTime? DatTime { get; set; }

        public virtual Users IdUserNavigation { get; set; }
    }
}
