using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoworkingSpaceBookingAPI.Domain.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("WorkspaceId")]
        public int WorkspaceId { get; set; }
        public DateTime ReservationStartTime { get; set; }
        public int ReservationDurationMinutes { get; set; }

        public User? User { get; set; }
        public Workspace? Workspace { get; set; }
    }
}
