using System;
using System.Collections.Generic;

namespace Team.Models
{
    public class TeamMatch
    {
        private readonly int matchesCount;
        public TeamMatch(int matches)
        {
            this.matchesCount = matches;
        }
        public int TeamMatchID { get; set; }
        public PlayersTeam Team1 { get; set; }
        public PlayersTeam Team2 { get; set; }
        public ICollection<Match> Matches { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int WinnerTeamID { get; set; }
    }
}
