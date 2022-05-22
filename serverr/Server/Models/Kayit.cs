using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class Kayit
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
    }
}
