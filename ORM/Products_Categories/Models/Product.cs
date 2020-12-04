using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Products_Categories.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="Product Name should be at least 2 characters")]
        [MaxLength(45)]
        public string Name { get; set; }

        [Required]
        [MinLength(12, ErrorMessage="Product Description should be at least 12 characters")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // ---------- Many to Many RelationShip Nav ------------
        public List<Association> Associations { get; set; }
    }
}