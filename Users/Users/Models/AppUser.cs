using Microsoft.AspNetCore.Identity;

namespace Users.Models
{
    public enum Cities
    {
        Brak, Londyn, Paryż, Chicago
    }

    public enum QualificationLevels
    {
        Brak, Podstawowe, Zaawansowane
    }

    public class AppUser : IdentityUser
    {
        public Cities City { get; set; }
        public QualificationLevels Qualifications { get; set; }
    }
}
