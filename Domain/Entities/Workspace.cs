using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Workspace
    {
        [Key]
        public int Id { get; set; }
        public required bool HasSocket { get; set; }
        public required int Price { get; set; }
        [ForeignKey("RoomId")]
        public required int RoomId { get; set; }
        [ForeignKey("WorkspaceTypeId")]
        public required int WorkspaceTypeId { get; set; }
        public WorkspaceType? WorkspaceType { get; set; }
        public Room? Room { get; set; }
    }
}
