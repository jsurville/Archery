using Archery.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Archery.Areas.BackOffice.Models
{/// <summary>
/// Les classes ViewModel pour chaque View du controller Authetication
/// </summary>
    public class AuthenticationLoginViewModel
    {
        [Required(ErrorMessage ="Le champ {0} est obligatoire")]
        [Display(Name = "Login")]
        public string Mail { get; set; }


        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Mot de Passe")]
        [DataType(DataType.Password)]
        [StringLength(150)] // assez long pour pouvoir crypter le mot de passe en base
        public string Password { get; set; }
    }
}