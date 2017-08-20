using System;
using System.Collections.Generic;

namespace WODGenerator.Models
{
    public partial class Abilities
    {
        public Abilities()
        {
            Characters = new HashSet<Characters>();
        }

        public int AblId { get; set; }
        public int TalentId { get; set; }
        public int SkillsId { get; set; }
        public int KnowledgeId { get; set; }

        public Knowledge Knowledge { get; set; }
        public Skills Skills { get; set; }
        public Talents Talent { get; set; }
        public ICollection<Characters> Characters { get; set; }
    }
}
