using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using System.Collections.Generic;
using UsingViewComponent.Components;
using UsingViewComponent.Models;
using Xunit;

namespace UsingViewComponents.Tests
{
    public class SummaryViewComponentTests
    {
        [Fact]
        public void TestSummary()
        {
            //Przygotowanie.
            var mockRepository = new Mock<ICityRepository>();
            mockRepository.Setup(m => m.Cities).Returns(new List<City> {
                new City { Population=100 },
                new City { Population = 20000 },
                new City { Population = 1000000 },
                new City { Population = 500000 }
            });
            var viewComponent = new CitySummary(mockRepository.Object);

            //Dzia³anie
            ViewViewComponentResult result = viewComponent.Invoke(false) as ViewViewComponentResult;

            //Asercje.
            Assert.IsType(typeof(CityViewModel), result.ViewData.Model);
            Assert.Equal(4, ((CityViewModel)result.ViewData.Model).Cities);
            Assert.Equal(1520100, ((CityViewModel)result.ViewData.Model).Population);
        }
    }
}
