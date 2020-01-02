using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Team.Models
{
    public class Match
    {
        private readonly int setCount;
        public Match(int setCount)
        {
            this.setCount = setCount;
        }
        public int MatchID { get; set; }
        [Range(0, 2)]
        public ICollection<Player> Players { get; set; }
        public ICollection<Set> Sets { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int WinnerPlayerID { get; set; }
    }
}
