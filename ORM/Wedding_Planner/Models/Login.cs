using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner.Models
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