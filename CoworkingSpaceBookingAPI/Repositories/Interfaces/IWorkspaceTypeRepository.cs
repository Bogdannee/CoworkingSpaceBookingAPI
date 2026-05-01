using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Repositories.Interfaces
{
    public interface IWorkspaceTypeRepository
    {
        Task<WorkspaceType?> GetByIdAsync(int id);
        Task<IEnumerable<WorkspaceType>> GetAllAsync();
        Task<WorkspaceType> AddAsync(WorkspaceType entity);
        Task UpdateAsync(int id, WorkspaceType entity);
        Task DeleteAsync(int id);
    }
}
