namespace Coworking.Application.DTOs
{
    public class RoomDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Floor { get; set; }
    }
}
