using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportoKluboApp.Data;
using SportoKluboApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SportoKluboApp.Services
{
    public class PasiekimaiService : IPasiekimaiService
    {
        private readonly ApplicationDbContext _context;

        public PasiekimaiService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pasiekimas[]> GetPasiekimasAsync(ApplicationUser user)
        {
            return await _context.PasiekimasItem
                .Where(x => x.UserId == user.Id).ToArrayAsync();
        }
    }
}