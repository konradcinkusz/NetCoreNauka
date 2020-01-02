using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Team.Models;

namespace Team.Controllers
{
    public class PlayerController : Controller
    {
        private IPlayerRepository repository;
        public PlayerController(IPlayerRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index() => View(repository.Players);

        public ViewResult Edit(int playerId) => View(repository.Players.FirstOrDefault(p => p.PlayerID == playerId));

        [HttpPost]
        public IActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                repository.SavePlayer(player);
                TempData["message"] = $"Zapisano: {player.Name}";
                return RedirectToAction("Index");
            }
            else
            {
                //Błąd w wartościach danych
                return View(player);
            }
        }

        public ViewResult Create() => View("Edit", new Player());

        [HttpPost]
        public IActionResult Delete(int playerId)
        {
            Player deletedPlayer = repository.DeletePlayer(playerId);
            if (deletedPlayer != null)
            {
                TempData["message"] = $"Usunięto {deletedPlayer.Name}.";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SeedDatabase()
        {
            SeedData.EnsurePopulated(HttpContext.RequestServices);
            return RedirectToAction(nameof(Index));
        }
    }
}