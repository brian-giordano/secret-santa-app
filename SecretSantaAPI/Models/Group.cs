using System.ComponentModel.DataAnnotations;

namespace SecretSantaAPI.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        // Nav property to relate users to the group
        public virtual ICollection<UserGroup> UserGroups { get; set; }

        [Required]
        public decimal MaxBudget { get; set; }

        public DateTime ExchangeDate { get; set; }

        // Group collection constructor - so it isn't null when a group is created.
        public Group()
        {
            UserGroups = new HashSet<UserGroup>();
        }
    }
}