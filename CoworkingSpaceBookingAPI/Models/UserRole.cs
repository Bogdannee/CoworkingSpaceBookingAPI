using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoworkingSpaceBookingAPI.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public string Role { get; set; }
    }
}
