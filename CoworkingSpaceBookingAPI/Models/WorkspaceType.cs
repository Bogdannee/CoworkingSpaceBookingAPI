using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoworkingSpaceBookingAPI.Models

{
    public class WorkspaceType
    {
        [Key]
        public int Id { get; set; }
        public required string Type { get; set; }
    }
}
