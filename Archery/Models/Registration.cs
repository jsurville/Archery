using Archery.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archery.Models
{
    public class Registration:BaseModel
    {
        [Display(Name = "Horraires de participation")]
        public int TimeWindowId { get; set; }
        [Required(ErrorMessage = "Le Champ {0} est obligatoire")]
        [ForeignKey("TimeWindowId")]
        public TimeWindow TimeWindow { get; set; }


        public int TournoiId { get; set; }
        [Display(Name = "Tournoi")]
        [Required(ErrorMessage = "Le Champ {0} est obligatoire")]
        [ForeignKey("TournoiId")]
        public Tournament Tournoi { get; set; }

        public ICollection<Archer> ListArchers { get; set; }
    }
}