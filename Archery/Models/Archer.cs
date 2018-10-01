
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public class Archer:User
    {
        [Required(ErrorMessage = "Le Champ {0} est obligatoire")]
        [Display(Name = "Numéro de Licence")]
        [StringLength(15)]
        public string LicenseNumber { get; set; }
       

    }

}