using Archery.Validators;
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
        [StringLength(150, ErrorMessage ="Le champ {0} doit contenir {1} caractères au maximum ")]
        [Display(Name ="Adresse Mail")]
        [RegularExpression(@"^[^\W][a-zA-Z0-9_]+(\.[a-zA-Z0-9_]+)*@[a-zA-Z0-9_]+(\.[a-zA-Z0-9_]+)*.[a-zA-Z]{2,4}$", ErrorMessage ="Le format n'est pas bon")]
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
        [Age(9,MaximumAge =80,ErrorMessage ="Le tireur doit avoir entre {1} et {2} ans ")] // Validateur de l'Age créé dans le dossier Validators, dans la classe Age.cs
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Mot de Passe")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$", ErrorMessage = "Le format du Mot de Passe n'est pas bon")]
        public string Password { get; set;  }

     
        [Display(Name = "Confirmation du Mot de Passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="La Confirmation du Mot de Passe n'est pas bonne")]
        public string ConfirmedPassword { get; set; }
    }
}