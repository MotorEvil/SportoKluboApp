﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportoKluboApp.Models;

namespace SportoKluboApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Treniruote> Items { get; set; }

        public DbSet<Pasiekimas> PasiekimasItem { get; set; }
    }
}