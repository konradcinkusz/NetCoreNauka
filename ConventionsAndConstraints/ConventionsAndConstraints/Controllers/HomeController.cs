﻿using ConventionsAndConstraints.Models;
using Microsoft.AspNetCore.Mvc;
using ConventionsAndConstraints.Infrastructure;

namespace ConventionsAndConstraints.Controllers
{
    //[AdditionalActions]
    public class HomeController : Controller
    {
        public IActionResult Index() => View("Result", new Result { Controller = nameof(HomeController), Action = nameof(Index) });
        [ActionName("Index")]
        [UserAgent("edge")]
        public IActionResult Other() => View("Result", new Result { Controller = nameof(HomeController), Action = nameof(Other) });

        [UserAgent("edge")]
        public IActionResult List() => View("Result", new Result { Controller = nameof(HomeController), Action = nameof(List) });
    }
}
