using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportoKluboApp.Models;
using SportoKluboApp.Models.ViewModels;
using SportoKluboApp.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SportoKluboApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ManageUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAdminService _adminService;

        public ManageUsersController(IAdminService adminService ,UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _adminService = adminService;
        }

        public async Task<IActionResult> Index()
        {
            var admins = (await _userManager
                .GetUsersInRoleAsync("Administrator"))
                .ToArray();

            var everyone = await _userManager.Users
                .ToArrayAsync();

            var model = new ManageUsersViewModel
            {
                Administrators = admins,
                Everyone = everyone
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSubscription(Guid id, int sub)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var successful = await _adminService.AddSubscriptionAsync(id, sub);

            if (successful.Succeeded)
            {
                return RedirectToAction("Index");
            }

/*            foreach (var error in successful.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
*/            return RedirectToAction("Index");

        }
    }
}