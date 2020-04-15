using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportoKluboApp.Data;
using SportoKluboApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SportoKluboApp.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> JoinWorkoutAsync(Guid id, ApplicationUser user)
        {
            var item = await _context.Items
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (item == null)
            {
                return false;
            }

            if (item.Registracijos != item.LaisvosVietos)
            {
                item.TreniruotesDalyviai = item.TreniruotesDalyviai + user.UserName + ", ";

                item.Registracijos++;
            }

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> ExitWorkoutAsync(Guid id, ApplicationUser user)
        {
            var item = await _context.Items
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (item == null)
            {
                return false;
            }

            item.TreniruotesDalyviai = item.TreniruotesDalyviai
                .Replace(user.UserName + ", ", "");

            item.Registracijos--;

            if (item.Registracijos <= 0)
            {
                item.Registracijos = 0;
            }

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

    }
}
