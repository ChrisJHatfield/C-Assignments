using System;
using System.ComponentModel.DataAnnotations;

namespace Chef_Dishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name="Name of Dish")]
        public string Name { get; set; }
        
        [Required]
        [Range(1, 4000, ErrorMessage="Calories must be: > 0 or < 4000")]
        [Display(Name="# of Calories")]
        public int? Calories { get; set; }

        [Required]
        [MinLength(11, ErrorMessage="A Description Must have at least 11 characters.")]
        public string Description { get; set; }

        [Required]
        [Range(1, 5)]
        public int Tastiness { get; set; }

        //Foreign Key Id:
        public int ChefId { get; set; }
        //Navigation Property
        public Chef Chef { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}