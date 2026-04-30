using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Services.Interfaces
{
    public interface IUserRoleService
    {
        Task<UserRole?> GetByIdAsync(int id);
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task AddAsync(UserRole entity);
        void Update(UserRole entity);
        void Delete(UserRole entity);
    }
}
