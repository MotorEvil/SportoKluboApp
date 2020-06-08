using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SportoKluboApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Subscription { get; set; }

        public ICollection<WorkoutUser> WorkoutUsers { get; set; }
    }
}