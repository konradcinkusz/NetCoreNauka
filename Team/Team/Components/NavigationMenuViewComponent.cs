using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Team.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(new List<string> { "Set", "Player", "Team" });
        }
    }
}
