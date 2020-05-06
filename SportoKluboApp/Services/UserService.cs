using Microsoft.EntityFrameworkCore;
using SportoKluboApp.Data;
using SportoKluboApp.Models;
using System;
using System.Linq;
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

            var model = new WorkoutUser
            {
                TreniruoteId = item.Id,
                UserId = user.Id
            };

            if (item.Registracijos != item.LaisvosVietos)
            {
                _context.workoutUsers.Add(model);
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

            var model = new WorkoutUser
            {
                TreniruoteId = item.Id,
                UserId = user.Id
            };

            _context.workoutUsers.Remove(model);

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