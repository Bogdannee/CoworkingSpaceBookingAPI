using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Repositories.Interfaces
{
    public interface IWorkspaceTypeRepository
    {
        Task<WorkspaceType?> GetByIdAsync(int id);
        Task<IEnumerable<WorkspaceType>> GetAllAsync();
        Task AddAsync(WorkspaceType entity);
        void Update(WorkspaceType entity);
        void Delete(WorkspaceType entity);
        Task SaveChangesAsync();
    }
}
