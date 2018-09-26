using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public abstract class User
    {
        public int ID { get; set; }

        [Required]
        [Display(Name ="Adresse Mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        public string FirstName { get; set;  }

        [Required]
        [Display(Name = "Nom")]
        public string LastName { get; set;  }

        [Required]
        [Display(Name = "Date de Naissance")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Mot de Passe")]
        [DataType(DataType.Password)]
        public string Password { get; set;  }

        [Required]
        [Display(Name = "Confirmation du Mot de Passe")]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }
    }
}