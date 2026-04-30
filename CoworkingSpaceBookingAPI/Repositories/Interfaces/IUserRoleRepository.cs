using CoworkingSpaceBookingAPI.Domain.Entities;

namespace CoworkingSpaceBookingAPI.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<UserRole?> GetByIdAsync(int id);
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task AddAsync(UserRole entity);
        void Update(UserRole entity);
        void Delete(UserRole entity);
    }
}
