using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public required string Role { get; set; }
    }
}
