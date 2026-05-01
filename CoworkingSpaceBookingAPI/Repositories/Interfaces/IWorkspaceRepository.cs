using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Repositories.Interfaces
{
    public interface IWorkspaceRepository
    {
        Task<Workspace?> GetByIdAsync(int id);
        Task<IEnumerable<Workspace>> GetAllAsync();
        Task<Workspace> AddAsync(Workspace entity);
        Task UpdateAsync(int id, Workspace entity);
        Task DeleteAsync(int id);
    }
}
