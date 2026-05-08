using CoworkingSpaceBookingAPI.Domain.DTOs;
using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Services.Interfaces
{
    public interface IWorkspaceService
    {
        Task<WorkspaceDto?> GetByIdAsync(int id);
        Task<IEnumerable<WorkspaceDto>> GetAllAsync();
        Task<WorkspaceDto> AddAsync(WorkspaceDto entity);
        Task UpdateAsync(int id, WorkspaceDto entity);
        Task DeleteAsync(int id);
    }
}
