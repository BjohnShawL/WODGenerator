using System;
using System.Collections.Generic;

namespace WODGenerator.Models
{
    public partial class Skills
    {
        public Skills()
        {
            Abilities = new HashSet<Abilities>();
        }

        public int SkillsId { get; set; }
        public int? AnimalKen { get; set; }
        public int? Crafts { get; set; }
        public int? Drive { get; set; }
        public int? Ettiquette { get; set; }
        public int? Firearms { get; set; }
        public int? Melee { get; set; }
        public int? Performance { get; set; }
        public int? Security { get; set; }
        public int? Stealth { get; set; }
        public int? Survival { get; set; }
        public int? Archery { get; set; }
        public int? Commerce { get; set; }
        public int? Ride { get; set; }
        public int? MartialArts { get; set; }

        public ICollection<Abilities> Abilities { get; set; }
    }
}
