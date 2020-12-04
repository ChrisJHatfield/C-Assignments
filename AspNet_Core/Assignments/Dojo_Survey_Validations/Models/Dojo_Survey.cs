using System.ComponentModel.DataAnnotations;
namespace Dojo_Survey.Models
{
    public class Survey
    {
        [Required]
        [MinLength(2)]
        [Display(Name = "Your Name:")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Dojo Location:")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Favorite Language")]
        public string Language { get; set; }

        [MinLength(20,
        ErrorMessage = "Comment must be a minimum of 20 characters.")]
        [Display(Name = "Comment (optional):")]
        public string Comment { get; set; }
    }
}