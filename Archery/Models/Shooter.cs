
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public class Shooter:BaseModel
    {
        [Required]
        [Display(Name = "Tournoi")]
        public int TournamentID { get; set; }

        [ForeignKey("TournamentID")]
        public Tournament Tournament { get; set; }

        [Required]
        [Display(Name = "Arme")]
        public int BowTypeID { get; set; }

        [ForeignKey("BowTypeID")]
        public BowType BowType { get; set; }

        [Required]
        [Display(Name = "Tireur")]
        public int ArcherID { get; set; }

        [ForeignKey("ArcherID")]
        public Archer Archer { get; set; }

        [Display(Name = "Heure de Départ")]
        public DateTime? StatTime { get; set; }


    }
}