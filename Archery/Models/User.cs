using Archery.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Index(IsUnique = true)]
        [EmailAttribute(ErrorMessage ="Le tireur ne peut pas être enregistré car l'email renseigné existe déjà")]
        public string Email { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Prénom")]
        public string FirstName { get; set;  }

        [StringLength(50)]
        [Required]
        [Display(Name = "Nom")]
        public string LastName { get; set;  }
        
        [Required]
        [Display(Name = "Date de Naissance")]
        [DataType(DataType.Date)]
        [Age(9,MaximumAge =80,ErrorMessage ="Le tireur doit avoir entre {1} et {2} ans ")] // Validateur de l'Age créé dans le dossier Validators, dans la classe Age.cs
        [Column(TypeName ="datetime2")] // pour que les dates soient comptées avant 01/01/1970
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Mot de Passe")]
        [DataType(DataType.Password)]
        [StringLength(150)] // assez long pour pouvoir crypter le mot de passe en base
        [RegularExpression(@"(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$", ErrorMessage = "Le format du Mot de Passe n'est pas bon")]
        public string Password { get; set;  }

        
        [Display(Name = "Confirmation du Mot de Passe")]
        [DataType(DataType.Password)]
        [NotMapped] // pour ne pas que la donnée soit enregistrée en base
        [Compare("Password", ErrorMessage ="La Confirmation du Mot de Passe n'est pas bonne")]
        public string ConfirmedPassword { get; set; }
    }
}