﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportoKluboApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Subscription { get; set; }

        public ICollection<WorkoutUser> WorkoutUsers { get; set; }
    }
}
