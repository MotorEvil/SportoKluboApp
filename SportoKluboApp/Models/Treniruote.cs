using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportoKluboApp.Models
{
    public class Treniruote
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm dd-MM-yyyy}")]
        public DateTime Laikas { get; set; }

        [Required(ErrorMessage = "Pavadinimas privalomas!")]
        [StringLength(100, ErrorMessage = "Pavadinimas privalomas!")]
        public string Pavadinimas { get; set; }

        public bool IsDone { get; set; }

        [Required]
        public int LaisvosVietos { get; set; }

        public int Registracijos { get; set; }

        public string UserId { get; set; }

        public string TreniruotesDalyviai { get; set; }

        public ICollection<WorkoutUser> WorkoutUsers { get; set; }
    }
}