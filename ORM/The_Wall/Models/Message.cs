using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_Wall.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        [MinLength(12, ErrorMessage="Message must be at least 12 characters or longer")]
        [Display(Name="Post a message")]
        public string UserMessage { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

//(optionals)
//(optionals)
    // ---------- One to Many Relationship Nav ------------
    // ------------------The One Side----------------------
    // Navigation  1(ModelonOneSide) -> Many(ModelonManySide)
        public List<Comment> Comments { get; set; }
    // ------------------The Many Side---------------------
    // Foreign Key from Model on One Side Id:
        public int UserId { get; set; }
        // Navigation Property to Model on One Side:
        public User User { get; set; }

        // ---------- Many to Many RelationShip Nav ------------
        public List<MessageLiked> MessageLiked { get; set; }
    }
}