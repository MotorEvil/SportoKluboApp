using SportoKluboApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportoKluboApp.Services
{
    public interface IWorkoutService
    {
        Task<Treniruote[]> GetTreniruotesAsync();
    }
}
