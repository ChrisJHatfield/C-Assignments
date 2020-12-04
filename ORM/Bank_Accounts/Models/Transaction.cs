using System;
using System.ComponentModel.DataAnnotations;

namespace Bank_Accounts.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        [Display(Name="Deposit/Withdraw")]
        public double Amount { get; set; }

        // Foreign Key from User Id:
        public int UserId { get; set; }
        // Navigation Property to User:
        public User User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}