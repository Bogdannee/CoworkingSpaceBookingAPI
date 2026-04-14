namespace CoworkingSpaceBookingAPI.Models
{
    public class Workspace
    {
        public int Id { get; set; }
        public WorkspaceType WorkspaceType { get; set; }
        public bool HasSocket { get; set; }
        public int Price { get; set; }
    }
}
