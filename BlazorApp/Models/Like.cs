using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        [Required]
        public int SenderId { get; set; }

        [Required]
        public int ReceiverId { get; set; }

        [Required]
        public int Status { get; set; } = -1;

        [ForeignKey("SenderId")]
        public Account Sender { get; set; }

        [ForeignKey("ReceiverId")]
        public Profile Receiver { get; set; }
    }
}
