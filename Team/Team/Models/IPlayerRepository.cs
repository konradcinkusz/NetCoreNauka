using System.Linq;

namespace Team.Models
{
    public interface IPlayerRepository
    {
        IQueryable<Player> Players { get; }
        void SavePlayer(Player player);
        Player DeletePlayer(int playerID);
    }
}
