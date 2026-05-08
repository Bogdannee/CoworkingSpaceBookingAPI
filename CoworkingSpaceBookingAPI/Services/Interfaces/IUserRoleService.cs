using CoworkingSpaceBookingAPI.Domain.DTOs;
using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Services.Interfaces
{
    public interface IUserRoleService
    {
        Task<UserRoleDto?> GetByIdAsync(int id);
        Task<IEnumerable<UserRoleDto>> GetAllAsync();
        Task<UserRoleDto> AddAsync(UserRoleDto entity);
        Task UpdateAsync(int id, UserRoleDto entity);
        Task DeleteAsync(int id);
    }
}
