using Microsoft.EntityFrameworkCore;
using SportoKluboApp.Data;
using SportoKluboApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SportoKluboApp.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly ApplicationDbContext _context;

        public WorkoutService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Treniruote[]> GetTreniruotesAsync()
        {
            return await _context.Items.Where(x => x.IsDone == false).Include(x => x.WorkoutUsers).OrderBy(x => x.Laikas).ToArrayAsync();
        }
    }
}