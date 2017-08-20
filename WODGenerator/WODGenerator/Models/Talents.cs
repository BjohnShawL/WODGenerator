using System;
using System.Collections.Generic;

namespace WODGenerator.Models
{
    public partial class Talents
    {
        public Talents()
        {
            Abilities = new HashSet<Abilities>();
        }

        public int TalentId { get; set; }
        public int? Alertness { get; set; }
        public int? Athletics { get; set; }
        public int? Brawl { get; set; }
        public int? Dodge { get; set; }
        public int? Empathy { get; set; }
        public int? Expression { get; set; }
        public int? Intimidation { get; set; }
        public int? Leadership { get; set; }
        public int? Streetwise { get; set; }
        public int? Subterfuge { get; set; }
        public int? Awareness { get; set; }
        public int? Kenning { get; set; }
        public int? Persuasion { get; set; }
        public int? PrimalUrge { get; set; }
        public int? Intuition { get; set; }
        public int? MartialArts { get; set; }
        public int? Ledgermain { get; set; }

        public ICollection<Abilities> Abilities { get; set; }
    }
}
