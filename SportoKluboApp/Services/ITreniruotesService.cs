using Microsoft.AspNetCore.Identity;
using SportoKluboApp.Models;
using System;
using System.Threading.Tasks;

namespace SportoKluboApp.Services
{
    public interface ITreniruotesService
    {
        Task<Treniruote[]> GetTreniruotesAsync(IdentityUser user);

        Task<bool> AddTreniruoteAsync(Treniruote newTreniruote, IdentityUser user);

        Task<bool> JoinTreniruoteAsync(Guid id, IdentityUser user);
    }
}