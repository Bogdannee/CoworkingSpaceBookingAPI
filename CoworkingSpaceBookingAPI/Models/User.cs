using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoworkingSpaceBookingAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash {  get; set; }
        [ForeignKey("UserRoleId")]
        public int UserRoleId { get; set; }

        public UserRole Role { get; set; }
        public List<Booking> Bookings { get; set; } = new();
    }
}
