using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Multiple_Forms.Models
{
    public class User
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public int Age { get; set; }
    }
}