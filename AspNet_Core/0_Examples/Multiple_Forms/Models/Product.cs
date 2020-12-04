using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Multiple_Forms.Models
{
    public class Product
    {
        [Required]
        [Display(Name="Product Name")]
        public string ProductName { get; set; }
        [Required]
        public double Price { get; set; }
    }
}