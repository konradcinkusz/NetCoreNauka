using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PurchasePrice { get; set; }        
        public decimal RetailPrice { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public IEnumerable<Price> Prices { get; set; }
    }
}
