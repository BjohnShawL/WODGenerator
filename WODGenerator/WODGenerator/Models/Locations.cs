using System;
using System.Collections.Generic;

namespace WODGenerator.Models
{
    public partial class Locations
    {
        public Locations()
        {
            Characters = new HashSet<Characters>();
        }

        public int LocId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? Gauntlet { get; set; }
        public int? FactionId { get; set; }

        public ICollection<Characters> Characters { get; set; }
    }
}
