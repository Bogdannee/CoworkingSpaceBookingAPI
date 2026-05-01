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

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetAll()
        {
            var users = await _userRoleService.GetAllAsync();

            return users.ToList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRole>> GetById(int id)
        {
            var user = await _userRoleService.GetByIdAsync(id);

            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<UserRole>> Create(UserRole userRole)
        {
            var createdUser = await _userRoleService.AddAsync(userRole);

            return createdUser;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UserRole userRole)
        {
            await _userRoleService.UpdateAsync(userRole);

            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(UserRole userRole)
        {
            await _userRoleService.DeleteAsync(userRole);

            return NoContent();
        }
    }
}
