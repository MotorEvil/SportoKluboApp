using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MobileApp.Models
{
    public class Treniruote
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime Laikas { get; set; }

        [Required]
        public string Pavadinimas { get; set; }

        public bool IsDone { get; set; }

        [Required]
        public int? LaisvosVietos { get; set; }

        public int Registracijos { get; set; }

        public string UserId { get; set; }

        public string TreniruotesDalyviai { get; set; }

        public ICollection<WorkoutUser> WorkoutUsers { get; set; }
    }
}