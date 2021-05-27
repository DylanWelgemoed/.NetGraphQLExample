using System.ComponentModel.DataAnnotations;

namespace GraphQL.Test.GQL.Models
{
    public class DataLeak
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string BreachSource { get; set; }
        [Required]
        [MaxLength(128)]
        public string BreachType { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}