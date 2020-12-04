using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chef_Dishes.Models
{
    public class Chef
    {
        
        [Key]
        public int ChefId { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name="Date of Birth")]
        // [DisplayFormat(DataFormatString="{0: mm dd yyyy}")]
        public DateTime Birthday { get; set; }

        //Navigation Property
        public List<Dish> ChefDishes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}