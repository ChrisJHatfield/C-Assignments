using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Accounts.Models
{
    public class User
    {
        
        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="First Name should be at least 2 characters")]
        [MaxLength(45, ErrorMessage="First Name cannot exceed 45 characters")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="Last Name should be at least 2 characters")]
        [MaxLength(45, ErrorMessage="Last Name cannot exceed 45 characters")]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name="Email Address")]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage="Password should be at least 8 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password")]
        public string Confirm { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation  1(User) -> Many(Transaction)
        public List<Transaction> Balance { get; set; }

        
    }
}