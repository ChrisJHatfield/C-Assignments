using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required]
        [MaxLength(45, ErrorMessage="Dish Name is required!")]
        [Display(Name="Name of Dish")]
        public string Name { get; set; }

        [Required]
        [MaxLength(45, ErrorMessage="Chef Name is required!")]
        [Display(Name="Chef's Name")]
        public string Chef { get; set; }

        [Required]
        [Range(1, 5)]
        public int Tastiness { get; set; }

        [Required]
        [Range(1, 4000, ErrorMessage="Calories must be: > 0 or < 4000")]
        [Display(Name="# of Calories")]
        public int? Calories { get; set; }

        [Required]
        [MinLength(11, ErrorMessage="Description must be at least 11 characters!")]
        public string Description { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}