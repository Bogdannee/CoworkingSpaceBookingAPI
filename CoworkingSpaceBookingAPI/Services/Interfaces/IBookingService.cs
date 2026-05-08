using CoworkingSpaceBookingAPI.Domain.DTOs;
using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingDto?> GetByIdAsync(int id);
        Task<IEnumerable<BookingDto>> GetAllAsync();
        Task<BookingDto> AddAsync(BookingDto entity);
        Task UpdateAsync(int id, BookingDto entity);
        Task DeleteAsync(int id);
    }
}
