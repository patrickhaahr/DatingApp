using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        [ForeignKey("SenderId")]
        public Account Sender { get; set; }

        [ForeignKey("ReceiverId")]
        public Profile Receiver { get; set; }

        public int Status { get; set; } = 0;
    }
}
