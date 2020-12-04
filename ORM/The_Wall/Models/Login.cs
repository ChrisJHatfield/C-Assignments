using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_Wall.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        [Display(Name="Email")]
        public string UserEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string UserPassword { get; set; }
    }
}