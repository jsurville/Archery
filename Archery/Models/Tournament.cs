using Archery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [AllowHtml] // permet d'autoriser l'nevoi de code Html dans la description, car on utilise Tiny MCE
        public string Description { get; set; }

        [Display(Name = "Lieu")]
        [Required(ErrorMessage = "Le Champ {0} est obligatoire")]
        [StringLength(50)]
        public string Location { get; set; }

        [Display(Name = "Nbre de tireurs")]
        [Required(ErrorMessage = "Le Champ {0} est obligatoire")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Le Champ {0} est obligatoire")]
        [Display(Name = "Date Début")]
        [DataType(DataType.DateTime)]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Le Champ {0} est obligatoire")]
        [Display(Name = "Date Fin")]
        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }

       
        [Display(Name ="Arme")]
        public ICollection<BowType> BowList { get; set; }

        [Display(Name = "Liste des Tireurs")]
        public ICollection<Archer> ArcherList { get; set; }

        [Display(Name = "Prix/pers")]
        public double? FeePerson { get; set; }

        [Display(Name ="Images")]
        public ICollection<TournamentPicture> Pictures { get; set; } // pas obligé

    }
}