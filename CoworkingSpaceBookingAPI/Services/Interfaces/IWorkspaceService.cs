using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Services.Interfaces
{
    public interface IWorkspaceService
    {
        Task<Workspace?> GetByIdAsync(int id);
        Task<IEnumerable<Workspace>> GetAllAsync();
        Task AddAsync(Workspace entity);
        void Update(Workspace entity);
        void Delete(Workspace entity);
    }
}
