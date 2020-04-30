using SportoKluboApp.Models;
using System;
using System.Threading.Tasks;

namespace SportoKluboApp.Services
{
    public interface IUserService
    {
        Task<bool> JoinWorkoutAsync(Guid id, ApplicationUser user);

        Task<bool> ExitWorkoutAsync(Guid id, ApplicationUser user);
    }
}