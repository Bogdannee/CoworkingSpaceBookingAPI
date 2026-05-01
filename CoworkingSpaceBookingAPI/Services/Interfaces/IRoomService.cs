using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Services.Interfaces
{
    public interface IRoomService
    {
        Task<Room?> GetByIdAsync(int id);
        Task<IEnumerable<Room>> GetAllAsync();
        Task<Room> AddAsync(Room entity);
        Task UpdateAsync(Room entity);
        Task DeleteAsync(Room entity);
    }
}
