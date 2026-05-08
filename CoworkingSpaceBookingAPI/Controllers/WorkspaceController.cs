using CoworkingSpaceBookingAPI.Domain.DTOs;
using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<WorkspaceDto>>> GetAll()
        {
            var workspaces = await _workspaceService.GetAllAsync();

            return Ok(workspaces);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WorkspaceDto>> GetById(int id)
        {
            var workspaceDto = await _workspaceService.GetByIdAsync(id);

            return Ok(workspaceDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<WorkspaceDto>> Create(WorkspaceDto workspaceDto)
        {
            var createdWorkspace = await _workspaceService.AddAsync(workspaceDto);

            return createdWorkspace;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, WorkspaceDto workspaceDto)
        {
            await _workspaceService.UpdateAsync(id, workspaceDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _workspaceService.DeleteAsync(id);

            return NoContent();
        }
    }
}
