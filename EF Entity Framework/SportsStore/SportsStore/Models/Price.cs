using System;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models
{
    public enum PriceType
    {
        None = 0,
        Purchase = 1,
        Retail = 2 
    }
    public class Price
    {
        public long Id { get; set; }
        public decimal Value { get; set; }
        public PriceType PriceType { get; set; } = PriceType.None;
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
