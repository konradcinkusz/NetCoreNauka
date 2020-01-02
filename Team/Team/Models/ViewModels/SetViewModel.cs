using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Team.Models.ViewModels
{
    public class SetViewModel
    {
        public int SetID { get; set; }
        [Range(0, double.MaxValue)]
        public int Player1Points { get; set; }
        [Range(0, double.MaxValue)]
        public int Player2Points { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public SelectList SelectPlayer1 { get; set; }
        public string SelectedPlayer1 { get; set; }
        public SelectList SelectPlayer2 { get; set; }
        public string SelectedPlayer2 { get; set; }

    }
}
