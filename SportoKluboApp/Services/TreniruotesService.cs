﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportoKluboApp.Data;
using SportoKluboApp.Models;
using System;
using System.Collections.Generic;
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

        public async Task<Treniruote[]> GetTreniruotesAsync(IdentityUser user)
        {
            return await _context.Items.Where(x => x.IsDone == false && x.UserId == user.Id).ToArrayAsync();
        }

        public async Task<bool> AddTreniruoteAsync(Treniruote newTreniruote, IdentityUser user)
        {
            newTreniruote.Id = Guid.NewGuid();
            newTreniruote.IsDone = false;
            newTreniruote.UserId = user.Id;

            _context.Items.Add(newTreniruote);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;

        }

    }
}
