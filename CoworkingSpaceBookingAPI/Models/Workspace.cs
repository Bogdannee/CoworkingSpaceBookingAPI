using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoworkingSpaceBookingAPI.Models
{
    public class Workspace
    {
        [Key]
        public int Id { get; set; }
        public bool HasSocket { get; set; }
        public int Price { get; set; }
        [ForeignKey("RoomId")]
        public int RoomId { get; set; }
        [ForeignKey("WorkspaceTypeId")]
        public int WorkspaceTypeId { get; set; }
        public WorkspaceType? WorkspaceType { get; set; }
        public Room? Room { get; set; }
    }
}
