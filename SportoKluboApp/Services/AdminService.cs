using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportoKluboApp.Data;
using SportoKluboApp.Models;
using SportoKluboApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportoKluboApp.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<bool> AddWorkoutAsync(Treniruote newTreniruote)
        {
            newTreniruote.Id = Guid.NewGuid();
            newTreniruote.Registracijos = 0;
            newTreniruote.IsDone = false;
            newTreniruote.TreniruotesDalyviai = "";

            _context.Items.Add(newTreniruote);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<string[]> WorkoutUsersAsync(Guid id)
        {
            var item = await _context.Items
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            char[] charsTotrim = { ',', ' ' };

            var users = item.TreniruotesDalyviai.Trim(charsTotrim).Split(", ").ToArray();

            return users;
        }

        public async Task<IdentityResult> AddSubscriptionAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var model = new ApplicationUser
            {
                Subscription = user.Subscription
            };

            var saveResult = await _userManager.UpdateAsync(user);

            return saveResult;
        }
    }
}
