using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<UserRole?> GetByIdAsync(int id);
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task<UserRole> AddAsync(UserRole entity);
        Task UpdateAsync(UserRole entity);
        Task DeleteAsync(UserRole entity);
    }
}
