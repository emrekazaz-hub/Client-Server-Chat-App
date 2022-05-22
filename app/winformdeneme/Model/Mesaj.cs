using System;
using System.Collections.Generic;


namespace winformdeneme
{
    public partial class Mesaj
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int FromUser { get; set; }
        public int ToUser { get; set; }
        public DateTime SendDate { get; set; }
    }
}
