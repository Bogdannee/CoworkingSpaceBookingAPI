using Microsoft.VisualBasic;

namespace CoworkingSpaceBookingAPI.Models
{
    public class Bookings
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Room Room { get; set; }
        public Workspace Workspace { get; set; }
        public DateAndTime ReservationDateAndTime { get; set; }
        public int ReservationDurationMinutes { get; set; }
    }
}
