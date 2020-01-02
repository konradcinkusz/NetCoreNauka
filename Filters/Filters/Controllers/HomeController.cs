using Filters.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Filters.Controllers
{
    [Message("To jest filtr o zasięgu kontrolera", Order = 10)]
    public class HomeController : Controller
    {
        [Message("To jest pierwszy filtr o zasięgu akcji", Order = 1)]
        [Message("To jest drugi filtr o zasięgu akcji", Order = 1)]
        public ViewResult Index() => View("Message", "To jest metoda akcji Index() kontrolera HomeController");
        public ViewResult SecondAction() => View("Message", "To jest metoda akcji SecondAction() kontrolera HomeController");
        public ViewResult GenerateException(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            else if (id > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            else
            {
                return View("Message", $"Wartość wynosi {id}.");
            }
        }
    }
}

