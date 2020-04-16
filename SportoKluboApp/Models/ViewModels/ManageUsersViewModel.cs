using Microsoft.AspNetCore.Identity;

namespace SportoKluboApp.Models.ViewModels
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Administrators { get; set; }

        public ApplicationUser[] Everyone { get; set; }

    }
}