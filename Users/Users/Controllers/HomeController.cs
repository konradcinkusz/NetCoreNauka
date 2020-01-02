using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Users.Models;

namespace Users.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<AppUser> userManager;
        public HomeController(UserManager<AppUser> usrMgr)
        {
            userManager = usrMgr;
        }

        [Authorize]
        public IActionResult Index() => View(GetData(nameof(Index)));
        //[Authorize(Roles = "Użytkownicy")]
        [Authorize(Policy = "MieszkańcyDC")]
        public IActionResult OtherAction() => View("Index", GetData(nameof(OtherAction)));
        [Authorize(Policy = "NieBartek")]
        public IActionResult NieBartek() => View("Index", GetData(nameof(NieBartek)));
        private Dictionary<string, object> GetData(string actionName) => new Dictionary<string, object>
        {
            ["Akcja"] = actionName,
            ["Użytkownik"] = HttpContext.User.Identity.Name,
            ["Uwierzytelniony?"] = HttpContext.User.Identity.IsAuthenticated,
            ["Typ uwierzytelnienia"] = HttpContext.User.Identity.AuthenticationType,
            ["Przypisany do roliUżytkownicy?"] = HttpContext.User.IsInRole("Użytkownicy"),
            ["Miasto"] = CurrentUser.Result.City,
            ["Kwalifikacje"] = CurrentUser.Result.Qualifications
        };
        [Authorize]
        public async Task<IActionResult> UserProps()
        {
            return View(await CurrentUser);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UserProps([Required]Cities city, [Required]QualificationLevels qualifications)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await CurrentUser;
                user.City = city;
                user.Qualifications = qualifications;
                await userManager.UpdateAsync(user);
                return RedirectToAction("Index");
            }
            return View(await CurrentUser);
        }
        private Task<AppUser> CurrentUser => userManager.FindByNameAsync(HttpContext.User.Identity.Name);
    }
}
