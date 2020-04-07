using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportoKluboApp.Models;
using SportoKluboApp.Models.ViewModels;
using SportoKluboApp.Services;
using System;
using System.Threading.Tasks;

namespace SportoKluboApp.Controllers
{
    public class TreniruotesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITreniruotesService _treniruotesService;

        public TreniruotesController(UserManager<IdentityUser> userManager, ITreniruotesService treniruotesService)
        {
            _userManager = userManager;
            _treniruotesService = treniruotesService;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return Challenge();
            }

            var treniruotes = await _treniruotesService
            .GetTreniruotesAsync();

            var model = new TreniruotesViewModel()
            {
                Treniruotes = treniruotes
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTreniruote(Treniruote newTreniruote)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return Challenge();
            }

            var succsessful = await _treniruotesService.AddTreniruoteAsync(newTreniruote);

            if (!succsessful)
            {
                return BadRequest("Could not add item.");
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> JoinTreniruote(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return Challenge();
            }

            var successful = await _treniruotesService
                .JoinTreniruoteAsync(id, currentUser);

            if (!successful)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExitTreniruote(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return Challenge();
            }

            var successful = await _treniruotesService
                .ExitTreniruoteAsync(id, currentUser);

            if (!successful)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}