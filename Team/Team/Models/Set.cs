using System;

namespace Team.Models
{
    public class Set
    {
        public int SetID { get; set; }
        public int Player1Id { get; set; }
        public Player Player1 { get; set; }
        public int Player1Points { get; set; }
        public int Player2Id { get; set; }
        public Player Player2 { get; set; }
        public int Player2Points { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int WinnerPlayerId { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }
    }
}
