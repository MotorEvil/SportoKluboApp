using System;

namespace MobileApp.Models
{
    public class WorkoutUser
    {
        public string UserId { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }

        public Guid TreniruoteId { get; set; }
        public Treniruote Treniruote { get; set; }

        public bool Attended { get; set; }
    }
}