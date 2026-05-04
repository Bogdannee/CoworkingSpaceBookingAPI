using CoworkingSpaceBookingAPI.Domain.DTOs;
using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserReadDto?> GetByIdAsync(int id);
        Task<IEnumerable<UserReadDto>> GetAllAsync();
        Task<UserReadDto> AddAsync(UserCreateDto entity);
        Task UpdateAsync(int id, UserCreateDto entity);
        Task DeleteAsync(int id);
    }
}
