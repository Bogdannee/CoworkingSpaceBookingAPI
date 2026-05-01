using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using CoworkingSpaceBookingAPI.Services.Interfaces;

namespace CoworkingSpaceBookingAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Booking> AddAsync(Booking entity)
        {
            var returnedEntity = await _bookingRepository.AddAsync(entity);

            return returnedEntity;
        }

        public async Task DeleteAsync(Booking entity)
        {
            await _bookingRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _bookingRepository.GetAllAsync();
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            return await _bookingRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Booking entity)
        {
            await _bookingRepository.UpdateAsync(entity);
        }
    }
}
