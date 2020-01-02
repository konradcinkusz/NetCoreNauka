using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Team.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IServiceProvider services)
        {
            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
            if (!context.Players.Any())
            {
                context.Players.AddRange(
                    new Player
                    {
                        Name = "Tomasz",
                        Surname = "Czyszanowski"
                    },
                    new Player
                    {
                        Name = "Daniel",
                        Surname = "Pawełczyk"
                    },
                    new Player
                    {
                        Name = "Konrad",
                        Surname = "Cinkusz"
                    },
                    new Player
                    {
                        Name = "Bartosz",
                        Surname = "Kowalski"
                    },
                    new Player
                    {
                        Name = "Joanna",
                        Surname = "Cinkusz"
                    },
                    new Player
                    {
                        Name = "Przemysław",
                        Surname = "Kopeć"
                    },
                    new Player
                    {
                        Name = "Damian",
                        Surname = "Podhalański"
                    },
                    new Player
                    {
                        Name = "Jan",
                        Surname = "Nowak"
                    },
                    new Player
                    {
                        Name = "Feliks",
                        Surname = "Skrzypek"
                    },
                    new Player
                    {
                        Name = "Janusz",
                        Surname = "Korwin-Mikke"
                    },
                    new Player
                    {
                        Name = "Andrzej",
                        Surname = "Galop"
                    },
                    new Player
                    {
                        Name = "Jolanta",
                        Surname = "Kaczka"
                    },
                    new Player
                    {
                        Name = "Mikołaj",
                        Surname = "Stawrogin"
                    });
                context.SaveChanges();
            }
        }
    }
}
