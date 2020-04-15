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

        Task<string[]> WorkoutUsersAsync(Guid id);
    }
}
