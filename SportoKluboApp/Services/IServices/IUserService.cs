using Microsoft.AspNetCore.Identity;
using SportoKluboApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportoKluboApp.Services
{
    public interface IUserService
    {
        Task<bool> JoinWorkoutAsync(Guid id, ApplicationUser user);

        Task<bool> ExitWorkoutAsync(Guid id, ApplicationUser user);


    }
}
