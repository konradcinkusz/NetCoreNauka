using DependencyInjection.Controllers;
using DependencyInjection.Infrastructure;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DependencyInjection.Tests
{
    public class DITests
    {
        [Fact]
        public void ControllerTest()
        {
            //Przygotowanie
            var data = new[] { new Product { Name = "Test", Price = 100 } };
            var mock = new Mock<IRepository>();
            mock.Setup(p => p.Products).Returns(data);
            HomeController controller = new HomeController(mock.Object);

            //Działanie
            ViewResult result = controller.Index();

            //Asercje.
            Assert.Equal(data, result.ViewData.Model);
        }
    }
}

