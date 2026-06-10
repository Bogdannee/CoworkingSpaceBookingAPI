using Coworking.Domain.Entities;

namespace Coworking.Application.Interfaces.RepositoryInterfaces
{
    public interface IBookingRepository
    {
        Task<Booking?> GetByIdAsync(int id);
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking> AddAsync(Booking entity);
        Task UpdateAsync(int id, Booking entity);
        Task DeleteAsync(int id);
        Task<bool> HasOverlapAsync(int workspaceId, DateTime start, int durationMinutes);
    }
}
