using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    [Route("app/[controller]/actions/[action]/{id:weekday?}")]
    public class CustomController : Controller
    {
        public ViewResult Index() => View("Result", new Result { Controller = nameof(CustomController), Action = nameof(Index) });

        public ViewResult List(string id)
        {
            Result r = new Result
            {
                Controller = nameof(CustomController),
                Action = nameof(List)
            };
            r.Data["id"] = id ?? "<brak wartości>";
            r.Data["catchall"] = RouteData.Values["catchall"];
            return View("Result", r);
        }
    }
}
