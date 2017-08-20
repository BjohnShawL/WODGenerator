using System;
using System.Collections.Generic;

namespace WODGenerator.Models
{
    public partial class Attributes
    {
        public Attributes()
        {
            Characters = new HashSet<Characters>();
        }

        public int AttribId { get; set; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Stam { get; set; }
        public int Cha { get; set; }
        public int Manip { get; set; }
        public int Appear { get; set; }
        public int Perc { get; set; }
        public int Intel { get; set; }
        public int Wits { get; set; }

        public ICollection<Characters> Characters { get; set; }
    }
}
