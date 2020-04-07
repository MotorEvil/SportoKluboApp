﻿using Microsoft.AspNetCore.Identity;
using SportoKluboApp.Models;
using System;
using System.Threading.Tasks;

namespace SportoKluboApp.Services
{
    public interface ITreniruotesService
    {
        Task<Treniruote[]> GetTreniruotesAsync();

        Task<bool> AddTreniruoteAsync(Treniruote newTreniruote);

        Task<bool> JoinTreniruoteAsync(Guid id, IdentityUser user);

        Task<bool> ExitTreniruoteAsync(Guid id, IdentityUser user);
    }
}