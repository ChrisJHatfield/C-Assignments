using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="Wedder One must have at least 2 characters")]
        [Display(Name="Wedder One")]
        public string WedderOne { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="Wedder One must have at least 2 characters")]
        [Display(Name="Wedder Two")]
        public string WedderTwo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name="Wedding Address")]
        public string Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        // Many side of 1 to Many Relationship
        // Navigation Key
        public int UserId { get; set; }
        // Navigation Property
        public User User { get; set; }

        // Many to Many
        public List<Guest> Guests { get; set; }

    }
}