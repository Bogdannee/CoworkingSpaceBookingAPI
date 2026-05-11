using Coworking.Application.DTOs;

namespace Coworking.Application.Interfaces.ServiceInterfeces
{
    public interface IRoomService
    {
        Task<RoomDto?> GetByIdAsync(int id);
        Task<IEnumerable<RoomDto>> GetAllAsync();
        Task<RoomDto> AddAsync(RoomDto entity);
        Task UpdateAsync(int id, RoomDto entity);
        Task DeleteAsync(int id);
    }
}
