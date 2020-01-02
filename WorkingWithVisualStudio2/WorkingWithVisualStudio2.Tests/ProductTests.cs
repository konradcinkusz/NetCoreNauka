using System;
using System.Collections.Generic;
using System.Text;
using WorkingWithVisualStudio2.Models;
using Xunit;

namespace WorkingWithVisualStudio2.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            //Przygotowanie
            var p = new Product { Name = "Test", Price = 100M };

            //Działanie
            p.Name = "Nowa nazwa";

            //Asercje
            Assert.Equal("Nowa nazwa", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            var p = new Product { Name = "Test", Price = 100M };
            p.Price = 200M;
            Assert.Equal(200M, p.Price);
        }
    }
}
