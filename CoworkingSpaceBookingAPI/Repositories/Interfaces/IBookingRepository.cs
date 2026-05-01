using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking?> GetByIdAsync(int id);
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking> AddAsync(Booking entity);
        Task UpdateAsync(int id, Booking entity);
        Task DeleteAsync(int id);
    }
}
