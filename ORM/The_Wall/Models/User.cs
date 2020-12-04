using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_Wall.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters or longer")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password")]
        public string Confirm { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // ---------- One to Many Relationship Nav ------------
    
    // ------------------The One Side----------------------
    //Navigation  1(ModelonOneSide) -> Many(ModelonManySide)
        public List<Message> Messages { get; set; }
        public List<Comment> Comments { get; set; }

        // ---------- Many to Many RelationShip Nav ------------
        public List<MessageLiked> MessageLiked { get; set; }
        public List<CommentLiked> CommentLiked { get; set; }
    }
}