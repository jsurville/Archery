using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Archery.Models
{
    public class BowType:BaseModel
    {
        [Required]
        [Display(Name = "Nom de l'arme")]
        public string Name { get; set; }

        [Display(Name = "Tournois")]
        public ICollection<Tournament> TournamentList { get; set; }
    }
}