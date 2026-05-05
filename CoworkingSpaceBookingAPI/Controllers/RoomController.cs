using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoworkingSpaceBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetAll()
        {
            var rooms = await _roomService.GetAllAsync();

            return rooms.ToList();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetById(int id)
        {
            var room = await _roomService.GetByIdAsync(id);

            return room;
        }

        [HttpPost]
        public async Task<ActionResult<Room>> Create(Room room)
        {
            var createdRoom = await _roomService.AddAsync(room);

            return createdRoom;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Room room)
        {
            await _roomService.UpdateAsync(id, room);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roomService.DeleteAsync(id);

            return NoContent();
        }
    }
}
