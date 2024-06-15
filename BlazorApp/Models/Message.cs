using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        [ForeignKey("SenderId")]
        public Account Sender { get; set; }

        [ForeignKey("ReceiverId")]
        public Profile Receiver { get; set; }

        [Required]
        public string MessageText { get; set; }

        public DateTime SentDate { get; set; } = DateTime.Now;
    }
}