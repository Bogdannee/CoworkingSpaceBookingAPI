using Coworking.Domain.Entities;

namespace Coworking.Application.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> AddAsync(User entity);
        Task UpdateAsync(int id, User entity);
        Task DeleteAsync(int id);
        Task<User?> GetByEmailAsync(string email);
    }
}
