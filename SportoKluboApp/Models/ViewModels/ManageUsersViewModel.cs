using Microsoft.AspNetCore.Identity;

namespace SportoKluboApp.Models.ViewModels
{
    public class ManageUsersViewModel
    {
        public IdentityUser[] Administrators { get; set; }

        public IdentityUser[] Everyone { get; set; }
    }
}