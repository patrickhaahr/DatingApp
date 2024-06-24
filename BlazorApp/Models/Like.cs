using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorApp.Models.Enums;

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
        public LikeStatus Status { get; set; } = LikeStatus.Default;

        [ForeignKey("SenderId")]
        public Account Sender { get; set; }

        [ForeignKey("ReceiverId")]
        public Profile Receiver { get; set; }
    }
}
