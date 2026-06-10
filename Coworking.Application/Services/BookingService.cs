using AutoMapper;
using Coworking.Application.DTOs;
using Coworking.Application.Interfaces.RepositoryInterfaces;
using Coworking.Application.Interfaces.ServiceInterfeces;
using Coworking.Domain.Entities;
using Coworking.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace Coworking.Application.Services
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
            var isOverlap = await _bookingRepository.HasOverlapAsync(
                bookingDto.WorkspaceId,
                bookingDto.ReservationStartTime,
                bookingDto.ReservationDurationMinutes);

            if (isOverlap)
            {
                _logger.LogWarning("Попытка бронирования занятого места: Workspace {WorkspaceId}, Time {Time}",
                    bookingDto.WorkspaceId, bookingDto.ReservationStartTime);

                throw new InvalidOperationException("Это рабочее место уже занято на выбранное время.");
            }

            var bookingEntity = _mapper.Map<Booking>(bookingDto);
            bookingEntity.Status = BookingStatus.Created;

            var createdEntity = await _bookingRepository.AddAsync(bookingEntity);

            _logger.LogInformation("Создан новый Booking ID: {Id} для пользователя {UserId}",
                createdEntity.Id, createdEntity.UserId);

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
