using System;
using System.ComponentModel.DataAnnotations;

namespace SportoKluboApp.Models
{
    public class Treniruote
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime? Laikas { get; set; }

        [Required]
        public string Pavadinimas { get; set; }

        public bool IsDone { get; set; }

        [Required]
        public int LaisvosVietos { get; set; }

        public int Registracijos { get; set; }

        public string UserId { get; set; }
    }
}