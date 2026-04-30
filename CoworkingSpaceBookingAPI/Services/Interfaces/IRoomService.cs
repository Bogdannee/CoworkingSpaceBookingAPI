using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Services.Interfaces
{
    public interface IRoomService
    {
        Task<Room?> GetByIdAsync(int id);
        Task<IEnumerable<Room>> GetAllAsync();
        Task AddAsync(Room entity);
        void Update(Room entity);
        void Delete(Room entity);
    }
}
