using Microsoft.AspNetCore.Identity;
using SportoKluboApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportoKluboApp.Services
{
    public interface ITreniruotesService
    {
        Task<Treniruote[]> GetTreniruotesAsync(IdentityUser user);

        Task<bool> AddTreniruoteAsync(Treniruote newTreniruote, IdentityUser user);
    }
}
