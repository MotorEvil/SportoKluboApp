﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportoKluboApp.Data;
using SportoKluboApp.Models;
using SportoKluboApp.Models.ViewModels;
using SportoKluboApp.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SportoKluboApp.Controllers
{
    public class TreniruotesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWorkoutService _workoutService;
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;

        public TreniruotesController(UserManager<ApplicationUser> userManager,
            IWorkoutService treniruotesService,
            IAdminService adminService,
            IUserService userService,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _workoutService = treniruotesService;
            _adminService = adminService;
            _userService = userService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var treniruotes = await _workoutService
            .GetTreniruotesAsync();

            var model = new TreniruotesViewModel()
            {
                Treniruotes = treniruotes
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTreniruote(Treniruote model)
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

            var succsessful = await _adminService.AddWorkoutAsync(model);

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

            var successful = await _userService
                .JoinWorkoutAsync(id, currentUser);

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

            var successful = await _userService
                .ExitWorkoutAsync(id, currentUser);

            if (!successful)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<IActionResult> WorkoutUsers(Guid id)
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

            var userList = _context.workoutUsers
                .Where(x => x.TreniruoteId == id)
                .Include(x => x.ApplicationUser)
                .Include(x => x.Treniruote);

            return View(userList);
        }

        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> WorkoutIsDone(Guid id)
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

            var userList = await _adminService.WorkoutIsDoneAsync(id);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MinusSubscription(Guid id, string wid)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var successful = await _adminService.MinusSubscriptionAsync(id);

            var attendand = _context.workoutUsers.Where(x => x.UserId == id.ToString() && x.TreniruoteId.ToString() == wid).FirstOrDefault();

            attendand.Attended = true;

            await _context.SaveChangesAsync();

            return RedirectToAction("WorkoutUsers", new { id = wid });
        }
    }
}