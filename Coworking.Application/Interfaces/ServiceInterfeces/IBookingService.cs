using Coworking.Application.DTOs;

namespace Coworking.Application.Interfaces.ServiceInterfeces
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
