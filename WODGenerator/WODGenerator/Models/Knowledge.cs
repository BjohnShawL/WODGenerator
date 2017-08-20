using System;
using System.Collections.Generic;

namespace WODGenerator.Models
{
    public partial class Knowledge
    {
        public Knowledge()
        {
            Abilities = new HashSet<Abilities>();
        }

        public int KnowledgeId { get; set; }
        public int? Academics { get; set; }
        public int? Bureaucracy { get; set; }
        public int? Computer { get; set; }
        public int? Finance { get; set; }
        public int? Investigation { get; set; }
        public int? Law { get; set; }
        public int? Linguistics { get; set; }
        public int? Medicine { get; set; }
        public int? Occult { get; set; }
        public int? Politics { get; set; }
        public int? Science { get; set; }
        public int? Cosmology { get; set; }
        public int? Greymare { get; set; }
        public int? Enigmas { get; set; }
        public int? Rituals { get; set; }
        public int? HearthWisdom { get; set; }
        public int? Seneschal { get; set; }
        public int? Theology { get; set; }

        public ICollection<Abilities> Abilities { get; set; }
    }
}
