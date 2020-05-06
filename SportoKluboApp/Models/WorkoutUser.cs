using System;

namespace SportoKluboApp.Models
{
    public class WorkoutUser
    {
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public Guid TreniruoteId { get; set; }
        public Treniruote Treniruote { get; set; }
    }
}