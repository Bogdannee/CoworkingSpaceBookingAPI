using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoworkingSpaceBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkspaceController : ControllerBase
    {
        readonly IWorkspaceService _workspaceService;

        public WorkspaceController(IWorkspaceService userService)
        {
            _workspaceService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workspace>>> GetAll()
        {
            var workspaces = await _workspaceService.GetAllAsync();

            return workspaces.ToList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workspace>> GetById(int id)
        {
            var workspace = await _workspaceService.GetByIdAsync(id);

            return workspace;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<Workspace>> Create(Workspace workspace)
        {
            var createdworkspace = await _workspaceService.AddAsync(workspace);

            return createdworkspace;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Workspace workspace)
        {
            await _workspaceService.UpdateAsync(id, workspace);

            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _workspaceService.DeleteAsync(id);

            return NoContent();
        }
    }
}
