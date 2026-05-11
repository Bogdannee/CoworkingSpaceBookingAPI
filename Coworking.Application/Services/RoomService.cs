using AutoMapper;
using Coworking.Application.DTOs;
using Coworking.Application.Interfaces.ServiceInterfeces;
using Coworking.Application.Interfaces.RepositoryInterfaces;
using Microsoft.Extensions.Logging;
using Coworking.Domain.Entities;

namespace Coworking.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RoomService> _logger;

        public RoomService(IRoomRepository roomRepository, IMapper mapper, ILogger<RoomService> logger)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<RoomDto> AddAsync(RoomDto roomDto)
        {
            var roomEntity = _mapper.Map<Room>(roomDto);

            var createdEntity = await _roomRepository.AddAsync(roomEntity);

            _logger.LogInformation("Создан новый Room Name: {Name}, ID: {Id}", createdEntity.Name, createdEntity.Id);

            return _mapper.Map<RoomDto>(createdEntity);
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation("Удаление Room с ID: {Id}", id);

            await _roomRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            var returnedEntities = await _roomRepository.GetAllAsync();
            var roomDtoList = _mapper.Map<List<RoomDto>>(returnedEntities);

            return roomDtoList;
        }

        public async Task<RoomDto?> GetByIdAsync(int id)
        {
            var returnedEntity = await _roomRepository.GetByIdAsync(id);

            if (returnedEntity == null)
            {
                throw new KeyNotFoundException($"Room c id={id} не найден.");
            }

            var roomDto = _mapper.Map<RoomDto>(returnedEntity);

            return roomDto;
        }

        public async Task UpdateAsync(int id, RoomDto roomDto)
        {
            var roomEntity = _mapper.Map<Room>(roomDto);
            _logger.LogInformation("Обновление данных Room ID: {Id}", id);

            await _roomRepository.UpdateAsync(id, roomEntity);
        }
    }
}
