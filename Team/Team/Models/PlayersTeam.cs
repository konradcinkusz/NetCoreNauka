using System.Collections.Generic;

namespace Team.Models
{
    public class PlayersTeam
    {
        private readonly int playersCount;
        public PlayersTeam(int playersCount)
        {
            this.playersCount = playersCount;
        }
        public int TeamID { get; set; }
        public string Name { get; set; }
        public ICollection<Player> Players { get; set; }

    }
}
