using Coworking.Application.DTOs;
using Coworking.Application.Interfaces.ServiceInterfeces;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<WorkspaceTypeDto>>> GetAll()
        {
            var workspaceTypes = await _workspaceTypeService.GetAllAsync();

            return Ok(workspaceTypes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WorkspaceTypeDto>> GetById(int id)
        {
            var workspaceType = await _workspaceTypeService.GetByIdAsync(id);

            return Ok(workspaceType);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<WorkspaceTypeDto>> Create(WorkspaceTypeDto workspaceTypeDto)
        {
            var createdWorkspaceType = await _workspaceTypeService.AddAsync(workspaceTypeDto);

            return createdWorkspaceType;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, WorkspaceTypeDto workspaceTypeDto)
        {
            await _workspaceTypeService.UpdateAsync(id, workspaceTypeDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _workspaceTypeService.DeleteAsync(id);

            return NoContent();
        }
    }
}
