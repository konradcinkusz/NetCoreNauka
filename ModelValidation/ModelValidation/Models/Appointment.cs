using Microsoft.AspNetCore.Mvc;
using ModelValidation.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models
{
    public class Appointment
    {
        [Required]
        [Display(Name = "name")]
        public string ClientName { get; set; }
        [UIHint("Date")]
        [Required(ErrorMessage = "Proszę podać datę.")]
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }
        [MustBeTrueAttribute(ErrorMessage = "Zaakceptowanie warunków jest wymagane.")]
        public bool TermsAccepted { get; set; }
    }
}
