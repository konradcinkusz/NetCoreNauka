using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team.Models
{
    public class EFPlayerRepository : IPlayerRepository
    {
        private ApplicationDbContext context;
        public EFPlayerRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Player> Players => context.Players;

        public Player DeletePlayer(int playerID)
        {
            Player dbEntry = context.Players.FirstOrDefault(p => p.PlayerID == playerID);
            if (dbEntry != null)
            {
                context.Players.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SavePlayer(Player player)
        {
            if (player.PlayerID == 0)
            {
                context.Players.Add(player);
            }
            else
            {
                Player dbEntry = context.Players.FirstOrDefault(p => p.PlayerID == player.PlayerID);
                if (dbEntry != null)
                {
                    dbEntry.Name = player.Name;
                    dbEntry.Surname = player.Surname;
                }
            }
            context.SaveChanges();
        }
    }
}
