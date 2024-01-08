using System;
using System.Collections.Generic;

#nullable disable

namespace KepRendszerezo.Models
{
    public partial class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string People { get; set; }
        public string Colour { get; set; }
    }
}
