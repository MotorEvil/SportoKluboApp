using System;
using System.ComponentModel.DataAnnotations;

namespace SportoKluboApp.Models
{
    public class Treniruote
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Laikas { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Pavadinimas pprivalomas!")]
        public string Pavadinimas { get; set; }

        public bool IsDone { get; set; }

        [Required]
        public int LaisvosVietos { get; set; }

        public int Registracijos { get; set; }

        public string UserId { get; set; }

        public string TreniruotesDalyviai { get; set; }
    }
}