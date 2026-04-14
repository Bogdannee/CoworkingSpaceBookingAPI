namespace CoworkingSpaceBookingAPI.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public List<Workspace> Workspaces { get; set; }
    }
}
