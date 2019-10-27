using System;
using System.Collections.Generic;

namespace ChatAPI.Models.Result
{
    public partial class Users
    {
        public Users()
        {
            Caisse = new HashSet<Caisse>();
            JourneeDetail = new HashSet<JourneeDetail>();
            Message = new HashSet<Message>();
        }

        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public int? IsAdmin { get; set; }
        public byte[] Image { get; set; }
        public string Tokens { get; set; }

        public virtual ICollection<Caisse> Caisse { get; set; }
        public virtual ICollection<JourneeDetail> JourneeDetail { get; set; }
        public virtual ICollection<Message> Message { get; set; }
    }
}
