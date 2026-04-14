using CoworkingSpaceBookingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Xml.Linq;

namespace CoworkingSpaceBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        static private UserRole newUserRole = new UserRole() { Id = 1, Role = "User" };
        static private List<User> _users = new List<User>()
        {
            new User() { Id = 1, Email = "email1", Name = "Name1", Role = newUserRole},
            new User() { Id = 2, Email = "email2", Name = "Name2", Role = newUserRole},
            new User() { Id = 3, Email = "email3", Name = "Name3", Role = newUserRole}
        };

        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            return Ok(_users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            user.Id = _users.Count + 1;
            user.Role = newUserRole;
            _users.Add(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, User updatedUser)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.Id = updatedUser.Id;
            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;
            existingUser.Role = updatedUser.Role;

            return Ok(existingUser);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _users.Remove(user);

            return Ok(user);
        }
    }
}
