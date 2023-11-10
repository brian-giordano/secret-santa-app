using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecretSantaAPI.Models
{
    // represents which user is assigned to give a gift to which other user.
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        public int GiverId { get; set; }

        [ForeignKey(nameof(GiverId))]

        public virtual User Giver { get; set; } = null!;

        [ForeignKey(nameof(ReceiverId))]
        public int ReceiverId { get; set; }
        public virtual User Receiver { get; set; } = null!;

        [ForeignKey(nameof(GiftId))]
        public int GiftId { get; set; }
        public virtual Gift Gift { get; set; } = null!;

        public Assignment()
        {

        }
    }
}