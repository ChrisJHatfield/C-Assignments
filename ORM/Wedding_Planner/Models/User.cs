using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="First Name should be at least 2 characters")]
        [Display(Name="First Name:")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="Last Name should be at least 2 characters")]
        [Display(Name="Last Name:")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage="Password should be at least 8 characters or longer")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="PW Confirm")]
        public string Confirm { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // 1 side of the 1 to Many Relationship
        public List<Wedding> Weddings { get; set; }

        // Many to Many
        public List<Guest> Guests { get; set; }

    }
}