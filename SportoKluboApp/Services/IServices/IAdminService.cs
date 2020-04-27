using Microsoft.AspNetCore.Identity;
using SportoKluboApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportoKluboApp.Services
{
    public interface IAdminService
    {
        Task<bool> AddWorkoutAsync(Treniruote newTreniruote);

       //ask<string[]> WorkoutUsersAsync(Guid id);

        Task<IdentityResult> AddSubscriptionAsync(Guid id, int sub);

        Task<bool> WorkoutIsDoneAsync(Guid id);

        Task<IdentityResult> MinusSubscriptionAsync(Guid id);
    }
}
