using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Login_Registration.Models
{
    public class LogReg
    {
        [Key]
        public int LogRegId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="First Name should be at least 2 characters.")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="Last Name should be at least 2 characters.")]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage="Password should be at least 8 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }
    }
}