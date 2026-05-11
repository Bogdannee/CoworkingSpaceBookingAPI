using Coworking.Domain.Entities;

namespace Coworking.Application.Interfaces.RepositoryInterfaces
{
    public interface IUserRoleRepository
    {
        Task<UserRole?> GetByIdAsync(int id);
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task<UserRole> AddAsync(UserRole entity);
        Task UpdateAsync(int id, UserRole entity);
        Task DeleteAsync(int id);
    }
}
