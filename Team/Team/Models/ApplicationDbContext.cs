using Microsoft.EntityFrameworkCore;

namespace Team.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<PlayersTeam> Teams { get; set; }
        public DbSet<Match> Matchs { get; set; }
        public DbSet<TeamMatch> TeamMatchs { get; set; }
        public DbSet<Set> Sets { get; set; }
    }
}
