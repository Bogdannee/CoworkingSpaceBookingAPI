using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Domain.DTOs
{
    public class WorkspaceDto
    {
        public int Id { get; set; }
        public required bool HasSocket { get; set; }
        public required int Price { get; set; }
        public required int RoomId { get; set; }
        public required int WorkspaceTypeId { get; set; }
    }
}
