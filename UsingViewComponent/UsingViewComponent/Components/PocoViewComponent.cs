using System.Linq;
using UsingViewComponent.Models;

namespace UsingViewComponent.Components
{
    public class PocoViewComponent
    {
        private ICityRepository repository;

        public PocoViewComponent(ICityRepository repo)
        {
            repository = repo;
        }
        public string Invoke()
        {
            return $"{repository.Cities.Count()} miasta, "
                + $"{repository.Cities.Sum(c => c.Population)} osób";
        }
    }
}
