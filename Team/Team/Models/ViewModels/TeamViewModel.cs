using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Team.Models.ViewModels
{
    public class TeamViewModel
    {
        public string Name { get; set; }
        [Required]
        public SelectList SelectPlayer1 { get; set; }
        public string SelectedPlayer1 { get; set; }
        [Required]
        public SelectList SelectPlayer2 { get; set; }
        public string SelectedPlayer2 { get; set; }
        [Required]
        public SelectList SelectPlayer3 { get; set; }
        [Required]
        public string SelectedPlayer3 { get; set; }
        public SelectList SelectPlayer4 { get; set; }
        public string SelectedPlayer4 { get; set; }
        public SelectList SelectPlayer5 { get; set; }
        public string SelectedPlayer5 { get; set; }
        public SelectList SelectPlayer6 { get; set; }
        public string SelectedPlayer6 { get; set; }
        public SelectList SelectPlayer7 { get; set; }
        public string SelectedPlayer7 { get; set; }
        public SelectList SelectPlayer8 { get; set; }
        public string SelectedPlayer8 { get; set; }
        public SelectList SelectPlayer9 { get; set; }
        public string SelectedPlayer9 { get; set; }
        public SelectList SelectPlayer10 { get; set; }
        public string SelectedPlayer10 { get; set; }
        public SelectList SelectPlayer11 { get; set; }
        public string SelectedPlayer11 { get; set; }
        public SelectList SelectPlayer12 { get; set; }
        public string SelectedPlayer12 { get; set; }
    }
}
