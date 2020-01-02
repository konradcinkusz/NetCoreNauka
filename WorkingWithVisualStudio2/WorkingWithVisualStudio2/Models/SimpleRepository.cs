using System.Collections.Generic;

namespace WorkingWithVisualStudio2.Models
{
    public class SimpleRepository : IRepository
    {
        private static SimpleRepository sharedRepository = new SimpleRepository();
        private Dictionary<string, Product> products = new Dictionary<string, Product>();

        public static SimpleRepository SharedRepository => sharedRepository;

        public SimpleRepository()
        {
            var inititalItems = new[]
            {
                   new Product{ Name= "Kajak", Price=275M},
                   new Product {Name = "Kamizelka ratunkowa", Price = 48.95M},
                   new Product {Name = "Piłka nożna", Price = 19.50M},
                   new Product {Name = "Flaga narożna", Price= 34.95M}
               };
            foreach (var p in inititalItems)
            {
                AddProduct(p);
            }
            products.Add("Błąd", null);
        }
        public IEnumerable<Product> Products => products.Values;
        public void AddProduct(Product p) => products.Add(p.Name, p);
    }
}
