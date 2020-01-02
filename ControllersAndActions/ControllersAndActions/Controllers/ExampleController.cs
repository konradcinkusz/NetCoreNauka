using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        public StatusCodeResult Idx() => NotFound();
        public VirtualFileResult Index() => File("/lib/bootstrap/dist/css/bootstrap.css", "text/css");
    }
}
