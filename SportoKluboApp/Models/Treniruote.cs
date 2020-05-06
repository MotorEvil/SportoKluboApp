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
        [Column(TypeName = "DateTime")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy HH:mm}")]
        //[DataType(DataType.DateTime)]
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

        public ICollection<WorkoutUser> WorkoutUsers { get; set; }
    }
}