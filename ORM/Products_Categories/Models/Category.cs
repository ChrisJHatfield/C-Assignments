using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Products_Categories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="Category Name should be at least 2 characters")]
        [MaxLength(45)]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // ---------- Many to Many RelationShip Nav ------------
        public List<Association> Associations { get; set; }
    }
}