using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Test.GQL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        public string LicenseKey { get; set; }

        public ICollection<DataLeak> DataLeaks { get; set; } = new List<DataLeak>();
    }
}