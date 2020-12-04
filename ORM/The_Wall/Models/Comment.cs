using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_Wall.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        [MinLength(12, ErrorMessage="Comment must be at least 12 characters or longer")]
        [Display(Name="Post a Comment")]
        public string UserComment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // ---------- One to Many Relationship Nav ------------
    // ------------------The Many Side---------------------
    // Foreign Key from Model on One Side Id:
        public int UserId { get; set; }
        // Navigation Property to Model on One Side:
        public User User { get; set; }

            // Foreign Key from Model on One Side Id:
        public int MessageId { get; set; }
        // Navigation Property to Model on One Side:
        public Message Message { get; set; }

        // ---------- Many to Many RelationShip Nav ------------
        public List<CommentLiked> CommentLiked { get; set; }
    }
}