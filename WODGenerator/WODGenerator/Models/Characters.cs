using System;
using System.Collections.Generic;

namespace WODGenerator.Models
{
    public partial class Characters
    {
        public int CharId { get; set; }
        public string Name { get; set; }
        public int? Alignment { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Species { get; set; }
        public int LocId { get; set; }
        public int? Inventory { get; set; }
        public int? PlotHook { get; set; }
        public int GameId { get; set; }
        public int AttribId { get; set; }
        public int AblId { get; set; }

        public Abilities Abl { get; set; }
        public Attributes Attrib { get; set; }
        public GameCampaign Game { get; set; }
        public Locations Loc { get; set; }
    }
}
