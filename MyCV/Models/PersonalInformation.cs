using System;
using System.ComponentModel.DataAnnotations;

namespace MyCV.Models
{
    public class PersonalInformation
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profilbillede")]
        public ImageFile ImageFile{ get; set; }
        
        [Required]
        [Display(Name = "Fornavn")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Efternavn")]
        public string LastName { get; set; }

        [Display(Name = "Mellemnavn")]
        public string MiddleName { get; set; }

        public string FullName => (
            String.IsNullOrEmpty(MiddleName)
            ? $"{FirstName} {LastName}"
            : $"{FirstName} {MiddleName} {LastName}"
        );

        [Required]
        [Phone]
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "By")]
        public string City { get; set; }
        
        [Required]
        [Display(Name = "Postnummer")]
        public int Zip { get; set; }
        
        [Required]
        [Display(Name = "Adresse")]
        public string Street { get; set; }

    }
}
