using System.ComponentModel.DataAnnotations;

namespace Cities.Models
{
    public class City
    {
        [Display(Name = "Miasto")]
        public string Name { get; set; }
        [Display(Name = "Kraj")]
        public string Country { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Populacja")]
        public int? Population { get; set; }
        [Display(Name = "Uwagi")]
        public string Notes { get; set; }
    }
}
