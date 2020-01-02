using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio2.Controllers;
using WorkingWithVisualStudio2.Models;
using Xunit;
using Moq;

namespace WorkingWithVisualStudio2.Tests
{
    public class HomeControllerTests
    {
        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete(Product[] products)
        {
            //Przygotowanie
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            var controller = new HomeController { Repository = mock.Object };

            //działanie
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //Asercje
            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p2.Price == p1.Price));
        }

        [Fact]
        public void RepositoryPropertyCallOnce()
        {
            //Przygotowanie
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(new[] { new Product { Name = "P1", Price = 100 } });
            var controller = new HomeController { Repository = mock.Object };

            //Działanie
            var result = controller.Index();

            //Asercje
            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}
