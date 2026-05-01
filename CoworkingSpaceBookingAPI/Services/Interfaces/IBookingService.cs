using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Services.Interfaces
{
    public interface IBookingService
    {
        Task<Booking?> GetByIdAsync(int id);
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking> AddAsync(Booking entity);
        Task UpdateAsync(int id, Booking entity);
        Task DeleteAsync(int id);
    }
}
