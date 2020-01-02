using Microsoft.AspNetCore.Mvc;
using System;

namespace Cities.Components
{
    public class TimeViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(DateTime.Now);
        }
    }
}
