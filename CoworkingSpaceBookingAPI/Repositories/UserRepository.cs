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

        public async Task AddAsync(User entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void Delete(User entity)
        {
            dbSet.Remove(entity);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Update(User entity)
        {
            dbSet.Update(entity);
        }

        public async Task SaveChangesAsync()
        {
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
