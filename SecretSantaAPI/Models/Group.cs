using System.ComponentModel.DataAnnotations;

namespace SecretSantaAPI.Models
{
    public class Group
    {
        [Key]
        public int GroupID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // Nav property to relate users to the group
        public virtual ICollection<User> Members { get; set; }

        [Required]
        public decimal MaxBudget { get; set; }

        public DateTime ExchangeDate { get; set; }

        // Member collection constructor - so it isn't null when a group is created.
        public Group()
        {
            Members = new HashSet<User>();
        }
    }
}