using Archery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Models
{

    public class Tournament:BaseModel
    {
        [Display(Name = "Lieu")]
        [Required(ErrorMessage = "Le Champ {0} est obligatoire")]
        public string Location { get; set; }

        [Display(Name = "Nombre max de participants")]
        [Required(ErrorMessage = "Le Champ {0} est obligatoire")]
        public int Capacity { get; set; }

        [Display(Name = "Date de Début")]
        [DataType(DataType.DateTime)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Date de Fin")]
        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }

        [Display(Name ="Nom de l'arme")]
        [Required(ErrorMessage = "Le Champ {0} est obligatoire")]
        public ICollection<BowType> BowList { get; set; }

        public ICollection<Archer> ArcherList { get; set; }

        [Display(Name = "Prix par personne")]
        [Required(ErrorMessage = "Le Champ {0} est obligatoire")]
        public double? FeePerson { get; set; }

    }
}