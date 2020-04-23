using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportoKluboApp.Models;

namespace SportoKluboApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WorkoutUser>().HasKey(x => new { x.UserId, x.TreniruoteId });

            builder.Entity<WorkoutUser>()
                .HasOne<ApplicationUser>(x => x.ApplicationUser)
                .WithMany(x => x.WorkoutUsers)
                .HasForeignKey(x => x.UserId);

            builder.Entity<WorkoutUser>()
                .HasOne<Treniruote>(x => x.Treniruote)
                .WithMany(x => x.WorkoutUsers)
                .HasForeignKey(x => x.TreniruoteId);

            base.OnModelCreating(builder);
        }

        public DbSet<WorkoutUser> workoutUsers { get; set; }

        public DbSet<Treniruote> Items { get; set; }

        public DbSet<Pasiekimas> PasiekimasItem { get; set; }
    }
}