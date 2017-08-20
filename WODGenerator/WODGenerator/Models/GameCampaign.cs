using System;
using System.Collections.Generic;

namespace WODGenerator.Models
{
    public partial class GameCampaign
    {
        public GameCampaign()
        {
            CharactersNavigation = new HashSet<Characters>();
        }

        public string CampaignName { get; set; }
        public string GameType { get; set; }
        public string GmName { get; set; }
        public int? Players { get; set; }
        public int? Characters { get; set; }
        public int GameId { get; set; }

        public ICollection<Characters> CharactersNavigation { get; set; }
    }
}
