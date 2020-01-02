using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Areas.Admin.Models;

namespace UrlsAndRoutes.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private Person[] data = new Person[]
        {
            new Person {Name ="Alicja", City="Londyn"},
            new Person {Name="Bartek", City="Paryż"},
            new Person {Name ="Janek", City="Nowy Jork"}
        };
        public ViewResult Index() => View(data);
    }
}
