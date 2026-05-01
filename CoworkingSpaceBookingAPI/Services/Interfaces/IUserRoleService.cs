using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Services.Interfaces
{
    public interface IUserRoleService
    {
        Task<UserRole?> GetByIdAsync(int id);
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task<UserRole> AddAsync(UserRole entity);
        Task UpdateAsync(int id, UserRole entity);
        Task DeleteAsync(int id);
    }
}
