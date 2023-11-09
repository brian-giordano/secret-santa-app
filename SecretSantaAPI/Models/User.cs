using System.ComponentModel.DataAnnotations;

namespace SecretSantaAPI.Models
{
    public class User
    {
        public User()
        {
            WishList = new HashSet<Gift>();
            Assignments = new HashSet<Assignment>();
        }

        [Key]
        public int UserId { get; set; } // Primary key

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Navigation property for related Gift objects
        public virtual ICollection<Gift> WishList { get; set; }

        // Navigation property for Secret Santa assignments
        public virtual ICollection<Assignment> Assignments { get; set; }

        // Add additional properties that might be relevant for your app
        // For example, a password hash for authentication purposes
        // public byte[] PasswordHash { get; set; }
        // public byte[] PasswordSalt { get; set; }
    }
}
