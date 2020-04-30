using SportoKluboApp.Models;
using System.Threading.Tasks;

namespace SportoKluboApp.Services
{
    public interface IWorkoutService
    {
        Task<Treniruote[]> GetTreniruotesAsync();
    }
}