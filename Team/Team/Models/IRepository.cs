using System.Linq;

namespace Team.Models
{
    public interface IRepository<T>
    {
        IQueryable<T> All { get; }
        void Save(T t);
        T Delete(int ID);
    }
}
