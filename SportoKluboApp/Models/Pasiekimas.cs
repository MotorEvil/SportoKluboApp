using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
