using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportoKluboApp.Models;
using SportoKluboApp.Models.ViewModels;
using SportoKluboApp.Services;

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
            .GetTreniruotesAsync(currentUser);

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

            var succsessful = await _treniruotesService.AddTreniruoteAsync(newTreniruote, currentUser);

            if (!succsessful)
            {
                return BadRequest("Could not add item.");
            }

            return RedirectToAction("Index");
        }
    }
}