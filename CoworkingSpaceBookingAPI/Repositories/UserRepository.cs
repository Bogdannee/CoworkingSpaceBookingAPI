using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Infrastructure.Data;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoworkingSpaceBookingAPI.Repositories
{
    public class UserRepository : AbstractRepository, IUserRepository
    {
        private readonly DbSet<User> dbSet;

        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            dbSet = applicationDbContext.Set<User>();
        }

        public async Task<User> AddAsync(User entity)
        {
            dbSet.Add(entity);
            await applicationDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            dbSet.Remove(entity);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(int id, User entity)
        {
            var request = await GetByIdAsync(id);

            request.Name = entity.Name;
            request.Email = entity.Email;
            request.PasswordHash = entity.PasswordHash;
            request.UserRoleId = entity.UserRoleId;

            await applicationDbContext.SaveChangesAsync();
        }
    }
}
