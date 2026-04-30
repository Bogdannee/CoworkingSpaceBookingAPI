using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Services.Interfaces
{
    public interface IWorkspaceTypeService
    {
        Task<WorkspaceType?> GetByIdAsync(int id);
        Task<IEnumerable<WorkspaceType>> GetAllAsync();
        Task AddAsync(WorkspaceType entity);
        void Update(WorkspaceType entity);
        void Delete(WorkspaceType entity);
    }
}
