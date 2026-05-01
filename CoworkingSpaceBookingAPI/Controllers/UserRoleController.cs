using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoworkingSpaceBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        // GET: api/<UserRoleController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetAll()
        {
            var users = await _userRoleService.GetAllAsync();

            return users.ToList();
        }

        // GET api/<UserRoleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRole>> GetById(int id)
        {
            var user = await _userRoleService.GetByIdAsync(id);

            return user;
        }

        // POST api/<UserRoleController>
        [HttpPost]
        public async Task<ActionResult<UserRole>> Create(UserRole userRole)
        {
            var createdUser = await _userRoleService.AddAsync(userRole);

            return createdUser;
        }

        // PUT api/<UserRoleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserRole userRole)
        {
            await _userRoleService.UpdateAsync(id, userRole);

            return NoContent();
        }

        // DELETE api/<UserRoleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRoleService.DeleteAsync(id);

            return NoContent();
        }
    }
}
