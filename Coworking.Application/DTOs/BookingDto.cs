using Coworking.Domain.Enums;

namespace Coworking.Application.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public required int UserId { get; set; }
        public required int WorkspaceId { get; set; }
        public required DateTime ReservationStartTime { get; set; }
        public required int ReservationDurationMinutes { get; set; }
        public BookingStatus Status { get; set; }
    }
}
