using Coworking.Application.DTOs;

namespace Coworking.Application.Interfaces.ServiceInterfeces
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
