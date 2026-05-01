using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Services;
using CoworkingSpaceBookingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoworkingSpaceBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkspaceTypeController : ControllerBase
    {
        readonly IWorkspaceTypeService _workspaceTypeService;

        public WorkspaceTypeController(IWorkspaceTypeService workspaceTypeService)
        {
            _workspaceTypeService = workspaceTypeService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkspaceType>>> GetAll()
        {
            var workspaceTypes = await _workspaceTypeService.GetAllAsync();

            return workspaceTypes.ToList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkspaceType>> GetById(int id)
        {
            var workspaceType = await _workspaceTypeService.GetByIdAsync(id);

            return workspaceType;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<WorkspaceType>> Create(WorkspaceType workspaceType)
        {
            var createdWorkspaceType = await _workspaceTypeService.AddAsync(workspaceType);

            return createdWorkspaceType;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, WorkspaceType workspaceType)
        {
            await _workspaceTypeService.UpdateAsync(id, workspaceType);

            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _workspaceTypeService.DeleteAsync(id);

            return NoContent();
        }
    }
}
