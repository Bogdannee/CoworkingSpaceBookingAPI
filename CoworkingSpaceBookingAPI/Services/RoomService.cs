using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using CoworkingSpaceBookingAPI.Services.Interfaces;

namespace CoworkingSpaceBookingAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Room> AddAsync(Room entity)
        {
            var returnedEntity = await _roomRepository.AddAsync(entity);

            return returnedEntity;
        }

        public async Task DeleteAsync(Room entity)
        {
            await _roomRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _roomRepository.GetAllAsync();
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _roomRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Room entity)
        {
            await _roomRepository.UpdateAsync(entity);
        }
    }
}
