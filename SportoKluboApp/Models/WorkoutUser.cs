using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
