using SportsStore.Models.Pages;
using SportsStore.Models.ViewModels;
using System.Collections.Generic;

namespace SportsStore.Models
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }
        PagedList<ProductViewModel> GetProductViewModels(QueryOptions options, long category = 0);
        PagedList<Product> GetProducts(QueryOptions options, long category = 0);
        PagedList<Product> GetProducts(QueryOptions options);
        Product GetProduct(long key);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void UpdateAll(Product[] products);
        void Delete(Product product);
    }
}
