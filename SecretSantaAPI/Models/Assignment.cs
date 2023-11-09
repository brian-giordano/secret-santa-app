using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecretSantaAPI.Models
{
    // represents which user is assigned to give a gift to which other user.
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [ForeignKey("Giver")]
        public int GiverUserId { get; set; }
        public virtual User Giver { get; set; } = null!;

        [ForeignKey("Receiver")]
        public int ReceiverUserId { get; set; }
        public virtual User Receiver { get; set; } = null!;

        [ForeignKey("Gift")]
        public int GiftId { get; set; }
        public virtual Gift Gift { get; set; } = null!;

        public Assignment()
        {

        }
    }
}