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

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le Champ {0} est obligatoire")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Lieu")]
        [Required(ErrorMessage = "Le Champ {0} est obligatoire")]
        [StringLength(50)]
        public string Location { get; set; }

        [Display(Name = "Nombre max de participants")]
        [Required(ErrorMessage = "Le Champ {0} est obligatoire")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Le Champ {0} est obligatoire")]
        [Display(Name = "Date de Début")]
        [DataType(DataType.DateTime)]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Le Champ {0} est obligatoire")]
        [Display(Name = "Date de Fin")]
        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }

        [Display(Name ="Nom de l'arme")]
        public ICollection<BowType> BowList { get; set; }

        [Display(Name = "Liste des Tireurs")]
        public ICollection<Archer> ArcherList { get; set; }

        [Display(Name = "Prix par personne")]
        public double? FeePerson { get; set; }

    }
}