using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room?> GetByIdAsync(int id);
        Task<IEnumerable<Room>> GetAllAsync();
        Task<Room> AddAsync(Room entity);
        Task UpdateAsync(int id, Room entity);
        Task DeleteAsync(int id);
    }
}
