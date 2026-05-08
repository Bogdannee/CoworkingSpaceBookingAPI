using CoworkingSpaceBookingAPI.Domain.DTOs;
using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Services.Interfaces
{
    public interface IWorkspaceTypeService
    {
        Task<WorkspaceTypeDto?> GetByIdAsync(int id);
        Task<IEnumerable<WorkspaceTypeDto>> GetAllAsync();
        Task<WorkspaceTypeDto> AddAsync(WorkspaceTypeDto entity);
        Task UpdateAsync(int id, WorkspaceTypeDto entity);
        Task DeleteAsync(int id);
    }
}
