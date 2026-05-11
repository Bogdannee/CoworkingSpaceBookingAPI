using Coworking.Application.DTOs;

namespace Coworking.Application.Interfaces.ServiceInterfeces
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
