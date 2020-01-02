using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models;
using System;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View("MakeBooking", new Appointment { Date = DateTime.Now });
        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
            if (ModelState.GetValidationState(nameof(appt.Date)) == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid
                && ModelState.GetValidationState(nameof(appt.ClientName)) == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid
                && appt.ClientName.Equals("Janek", StringComparison.OrdinalIgnoreCase)
                && appt.Date.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("", "Janek nie może rezerwować wizyt w poniedziałki.");
            }
            if (ModelState.IsValid)
            {
                return View("Completed", appt);
            }
            else
            {
                return View();
            }
        }

        public JsonResult ValidateDate(string Date)
        {
            DateTime parsedDate;

            if (!DateTime.TryParse(Date, out parsedDate))
            {
                return Json("Proszę podać prawidłową datę (dd.mm.rrr).");
            }
            else if (DateTime.Now > parsedDate)
            {
                return Json("Proszę podać datę w przyszłośći");
            }
            else
            {
                return Json(true);
            }
        }
    }
}
