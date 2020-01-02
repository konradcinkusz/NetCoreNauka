using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team.Models;
using Team.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Team.Controllers
{
    public class SetController : Controller
    {
        private IPlayerRepository repository;
        private IRepository<Set> setService;
        public SetController(IPlayerRepository repo, IRepository<Set> setSrv)
        {
            repository = repo;
            setService = setSrv;
        }
        public ViewResult Index() => View(setService.All);

        public ViewResult Edit(int setID) => View(Empty());

        [HttpPost]
        public IActionResult Edit(SetViewModel set)
        {
            if (set.Player2Points < 11 || set.Player2Points < 11)
            {
                ModelState.AddModelError("", "Nieprawidłowa liczba punktów, obydwoje zawodników ma ich za mało");
            }
            if (set.Player1Points > 11 && set.Player2Points > 11 && Math.Abs(set.Player1Points - set.Player2Points) != 2)
            {
                ModelState.AddModelError("", "Nieprawidłowa liczba punktów");
            }
            if (ModelState.IsValid
                && int.TryParse(set.SelectedPlayer1, out int selectedPlayer1ID)
                && int.TryParse(set.SelectedPlayer2, out int selectedPlayer2ID)
                )
            {
                Set setToSave = new Set
                {
                    Player1 = repository.Players.Single(p => p.PlayerID == selectedPlayer1ID),
                    Player2 = repository.Players.Single(p => p.PlayerID == selectedPlayer2ID),
                    StartTime = set.StartTime,
                    EndTime = set.EndTime,
                    Player1Points = set.Player1Points,
                    Player2Points = set.Player2Points
                };
                setService.Save(setToSave);
                TempData["message"] = $"Zapisano: {setToSave.SetID}. {setToSave.Player1.Name} vs {setToSave.Player2.Name}";

                return RedirectToAction("Index");
            }
            else
            {
                return View(set);
            }
        }

        private SetViewModel Empty() => new SetViewModel
        {
            SelectPlayer1 = new SelectList(repository.Players.Select(p => new SelectListItem()
            {
                Text = p.Name,
                Value = p.PlayerID.ToString()
            }), "Value", "Text"),
            SelectPlayer2 = new SelectList(repository.Players.Select(p => new SelectListItem()
            {
                Text = p.Name,
                Value = p.PlayerID.ToString()
            }), "Value", "Text")
        };


        public ViewResult Create() => View("Edit", Empty());

        [HttpPost]
        public IActionResult Delete(int setId)
        {
            Set deletedSet = setService.Delete(setId);
            if (deletedSet != null)
            {
                TempData["message"] = $"Usunięto {deletedSet.SetID}.";
            }
            return RedirectToAction("Index");
        }
    }
}