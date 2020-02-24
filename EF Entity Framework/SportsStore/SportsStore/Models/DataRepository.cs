using Microsoft.EntityFrameworkCore;
using SportsStore.Models.Pages;
using SportsStore.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{
    public class DataRepository : IRepository
    {
        //private List<Product> data = new List<Product>();
        private DataContext context;
        public DataRepository(DataContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Product> Products => context.Products.Include(p => p.Category).ToArray();

        public PagedList<Product> GetProducts(QueryOptions options, long category = 0)
        {
            IQueryable<Product> query = context.Products.Include(p => p.Category);
            if (category != 0)
            {
                query = query.Where(p => p.CategoryId == category);
            }
            return new PagedList<Product>(query, options);
        }
        public PagedList<Product> GetProducts(QueryOptions options)
        {
            //var query = from p in context.Products
            //            join purchasePrice in context.Prices on p.Id equals purchasePrice.ProductId
            //            join retailPrice in context.Prices on p.Id equals retailPrice.ProductId
            //            where 
            //            (retailPrice.IsActive && retailPrice.PriceType == PriceType.Retail)
            //            ||
            //            (purchasePrice.IsActive && purchasePrice.PriceType == PriceType.Purchase)
            //            select new ProductViewModel
            //            {
            //                Product = p,
            //                PurchasePrice = purchasePrice.Value,
            //                RetailPrice = retailPrice.Value
            //            };
            return new PagedList<Product>(context.Products.Include(p => p.Category), options);
        }
        public PagedList<Product> GetProductsViewModels(QueryOptions options)
        {
            var query = from p in context.Products
                        join purchasePrice in context.Prices on p.Id equals purchasePrice.ProductId
                        where purchasePrice.IsActive && purchasePrice.PriceType == PriceType.Purchase
                        join retailPrice in context.Prices on p.Id equals retailPrice.ProductId
                        where retailPrice.IsActive && retailPrice.PriceType == PriceType.Retail
                        select new ProductViewModel
                        {
                            Product = p,
                            PurchasePrice = purchasePrice.Value,
                            RetailPrice = retailPrice.Value
                        };

            return new PagedList<Product>(context.Products.Include(p => p.Prices), options);
        }
        public Product GetProduct(long key) => context.Products.Include(p => p.Category).First(p => p.Id == key);
        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            Product p = context.Products.Find(product.Id);
            p.Name = product.Name;
            p.CategoryId = product.CategoryId;
            context.SaveChanges();
        }
        public void UpdateAll(Product[] products)
        {
            //context.Products.UpdateRange(products);
            Dictionary<long, Product> data = products.ToDictionary(p => p.Id);
            IEnumerable<Product> baseline = context.Products.Where(p => data.Keys.Contains(p.Id));

            foreach (Product databaseProduct in baseline)
            {
                Product requestProduct = data[databaseProduct.Id];
                databaseProduct.Name = requestProduct.Name;
                databaseProduct.Category = requestProduct.Category;
            }

            context.SaveChanges();
        }
        public void Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
