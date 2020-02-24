using SportsStore.Models;

namespace SportsStore.Models.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal RetailPrice { get; set; }
    }
}
