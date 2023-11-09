using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecretSantaAPI.Models
{
    public class Gift
    {

        [Key]
        public int GiftId { get; set; }

        [Required]
        public string Title { get; set; } // gift name or title

        public string Description { get; set; } // optional description of the gift

        //foreign key for the User model
        public int UserId { get; set; }

        // ForeignKey relates Gift to User - which user is sending the gift.
        //This is helpful when you retrieve a Gift from the database and want to know which user sent it without requiring a separate query.
        [ForeignKey("UserId")]
        public User Sender { get; set; }
    }
}