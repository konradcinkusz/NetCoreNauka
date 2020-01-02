using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    public class GlobalController : Controller
    {
        public ViewResult Index() => View("Message", "To jest kontroler globalny.");
    }
}
