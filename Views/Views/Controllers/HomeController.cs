using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View("MyView", new string[] { "Jabłka", "Pomarańcze", "Gruszki" });

        public ViewResult List() => View();
    }
}
