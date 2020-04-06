using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportoKluboApp.Data;
using SportoKluboApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SportoKluboApp.Services
{
    public class TreniruotesService : ITreniruotesService
    {
        private readonly ApplicationDbContext _context;

        public TreniruotesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Treniruote[]> GetTreniruotesAsync()
        {
            return await _context.Items.Where(x => x.IsDone == false).ToArrayAsync();
        }

        public async Task<bool> AddTreniruoteAsync(Treniruote newTreniruote)
        {
            newTreniruote.Id = Guid.NewGuid();
            newTreniruote.IsDone = false;
            newTreniruote.Registracijos = 0;

            _context.Items.Add(newTreniruote);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> JoinTreniruoteAsync(Guid id, IdentityUser user)
        {
            //neranda item id ir del to ismeta false
            var item = await _context.Items
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (item == null)
            {
                return false;
            }

            item.UserId = item.UserId + user.Id.ToString() + ", ";
            item.Registracijos++;
            item.TreniruotesDalyviai = item.TreniruotesDalyviai + user.UserName.ToString() + ", ";

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }
    }
}