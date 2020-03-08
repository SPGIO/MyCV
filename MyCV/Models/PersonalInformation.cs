using System;
using System.ComponentModel.DataAnnotations;

namespace MyCV.Models
{
    public class PersonalInformation
    {
        [Key]
        public int Id { get; set; }

        public ImageFile ImageFile{ get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }

        public string FullName => (
            String.IsNullOrEmpty(MiddleName)
            ? $"{FirstName} {LastName}"
            : $"{FirstName} {MiddleName} {LastName}"
        );

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string City { get; set; }
        
        [Required]
        public int Zip { get; set; }
        
        [Required]
        public string Street { get; set; }

    }
}
