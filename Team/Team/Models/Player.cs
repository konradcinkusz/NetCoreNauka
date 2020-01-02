using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Team.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public int? PlayerAccountID { get; set; }
        [Required(ErrorMessage ="Proszę podać imię zawodnika")]
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwisko zawodnika")]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }
        public ICollection<Set> PlayedSets { get; set; }
        public ICollection<Match> PlayedMatches { get; set; }
        public ICollection<TeamMatch> PlayedTeamMatches { get; set; }
        public ICollection<PlayersTeam> PlayerTeams { get; set; }
    }
}
