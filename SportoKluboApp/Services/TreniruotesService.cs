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
            newTreniruote.Registracijos = 0;
            newTreniruote.IsDone = false;
            newTreniruote.TreniruotesDalyviai = "";

            _context.Items.Add(newTreniruote);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> JoinTreniruoteAsync(Guid id, IdentityUser user)
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

        public async Task<bool> ExitTreniruoteAsync(Guid id, IdentityUser user)
        {
            var item = await _context.Items
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (item == null)
            {
                return false;
            }

            item.TreniruotesDalyviai = item.TreniruotesDalyviai
                .Substring(item.TreniruotesDalyviai
                .IndexOf(user.UserName))
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