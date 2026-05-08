using AutoMapper;
using CoworkingSpaceBookingAPI.Domain.DTOs;
using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Repositories;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using CoworkingSpaceBookingAPI.Services.Interfaces;

namespace CoworkingSpaceBookingAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<RoomDto> AddAsync(RoomDto roomDto)
        {
            var roomEntity = _mapper.Map<Room>(roomDto);

            var createdEntity = await _roomRepository.AddAsync(roomEntity);

            return _mapper.Map<RoomDto>(createdEntity);
        }

        public async Task DeleteAsync(int id)
        {
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

            await _roomRepository.UpdateAsync(id, roomEntity);
        }
    }
}
