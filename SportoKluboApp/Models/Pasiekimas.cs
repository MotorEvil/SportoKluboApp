using System;

namespace SportoKluboApp.Models
{
    public class Pasiekimas
    {
        public Guid Id { get; set; }

        public DateTime PasiekimoLaikas { get; set; }

        public string PasiekimoPavadinimas { get; set; }

        public string PratimoPavadinimas { get; set; }

        public string UserId { get; set; }
    }
}