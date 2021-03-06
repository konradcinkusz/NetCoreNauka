﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
    public class MemoryRepository : IRepository
    {
        private IModelStorage storage;
        private string guid = Guid.NewGuid().ToString();
        public MemoryRepository(IModelStorage modelStorage)
        {
            storage = modelStorage;
            new List<Product>
            {
                new Product {Name = "Kajak", Price = 275M},
                new Product {Name = "Kamizelka ratunkowa", Price=48.95M},
                new Product {Name="Piłka nożna", Price = 19.50M}
            }.ForEach(p => AddProduct(p));

        }
        public Product this[string name] => storage[name];

        public IEnumerable<Product> Products => storage.Items;

        public void AddProduct(Product product) => storage[product.Name] = product;

        public void DeleteProduct(Product product) => storage.RemoveItem(product.Name);
        public override string ToString()
        {
            return guid;
        }
    }
}
