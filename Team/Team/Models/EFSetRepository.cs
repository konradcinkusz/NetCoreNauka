using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Team.Models
{
    public class EFSetRepository : IRepository<Set>
    {
        private ApplicationDbContext context;
        public EFSetRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Set> All => context.Sets.Include(o=>o.Player1).Include(r=>r.Player2);

        public Set Delete(int ID)
        {
            Set dbEntry = context.Sets.FirstOrDefault(p => p.SetID == ID);
            if (dbEntry != null)
            {
                context.Sets.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void Save(Set t)
        {
            //if (t.SetID == 0)
            //{
            //    context.Sets.Add(t);
            //}
            //else
            //{
            //    Set dbEntry = context.Sets.FirstOrDefault(p => p.SetID == t.SetID);
            //    if (dbEntry != null)
            //    {
            //        dbEntry.Player1 = t.Player1;
            //        dbEntry.Player1Points = t.Player1Points;
            //        dbEntry.Player2 = t.Player2;
            //        dbEntry.Player2Points = t.Player2Points;
            //        dbEntry.SetID = t.SetID;
            //        dbEntry.StartTime = t.StartTime;
            //        dbEntry.EndTime = t.EndTime;
            //        dbEntry.Winner = t.Winner;
            //    }
            //}
            //context.SaveChanges();
        }
    }
}
