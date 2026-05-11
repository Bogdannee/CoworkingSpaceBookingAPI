using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Floor { get; set; }

        public List<Workspace> Workspaces { get; set; } = new();
    }
}
