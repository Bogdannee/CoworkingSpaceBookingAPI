using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoworkingSpaceBookingAPI.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Floor { get; set; }

        public List<Workspace> Workspaces { get; set; } = new();
    }
}
