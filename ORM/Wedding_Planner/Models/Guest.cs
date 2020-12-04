using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }

        // ----------- Many to Many RelationShip --------------
        public int UserId { get; set; }
        public User User { get; set; }

        public int WeddingId { get; set; }
        public Wedding Wedding { get; set; }
        // ----------------------------------------------------

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}