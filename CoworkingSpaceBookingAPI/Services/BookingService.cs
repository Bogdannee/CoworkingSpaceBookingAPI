using AutoMapper;
using CoworkingSpaceBookingAPI.Domain.DTOs;
using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Repositories;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using CoworkingSpaceBookingAPI.Services.Interfaces;

namespace CoworkingSpaceBookingAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookingService> _logger;

        public BookingService(IBookingRepository bookingRepository, IMapper mapper, ILogger<BookingService> logger)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<BookingDto> AddAsync(BookingDto bookingDto)
        {
            var bookingEntity = _mapper.Map<Booking>(bookingDto);

            var createdEntity = await _bookingRepository.AddAsync(bookingEntity);

            _logger.LogInformation("Создан новый Booking UserId: {UserId}, ID: {Id}", createdEntity.UserId, createdEntity.Id);

            return _mapper.Map<BookingDto>(createdEntity);
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation("Удаление Booking с ID: {Id}", id);

            await _bookingRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<BookingDto>> GetAllAsync()
        {
            var returnedEntities = await _bookingRepository.GetAllAsync();
            var bookingDtoList = _mapper.Map<List<BookingDto>>(returnedEntities);

            return bookingDtoList;
        }

        public async Task<BookingDto?> GetByIdAsync(int id)
        {
            var returnedEntity = await _bookingRepository.GetByIdAsync(id);

            if (returnedEntity == null)
            {
                throw new KeyNotFoundException($"Booking c id={id} не найден.");
            }

            var bookingDto = _mapper.Map<BookingDto>(returnedEntity);

            return bookingDto;
        }

        public async Task UpdateAsync(int id, BookingDto bookingDto)
        {
            var bookingEntity = _mapper.Map<Booking>(bookingDto);

            _logger.LogInformation("Обновление данных Booking UserId: {UserId}, ID: {Id}", bookingDto.UserId, id);

            await _bookingRepository.UpdateAsync(id, bookingEntity);
        }
    }
}
