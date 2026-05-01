using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Infrastructure.Data;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoworkingSpaceBookingAPI.Repositories
{
    public class UserRoleRepository : AbstractRepository, IUserRoleRepository
    {
        private readonly DbSet<UserRole> dbSet;

        public UserRoleRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            dbSet = applicationDbContext.Set<UserRole>();
        }

        public async Task<UserRole> AddAsync(UserRole entity)
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

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<UserRole?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(int id, UserRole entity)
        {
            var requested = await GetByIdAsync(id);

            requested.Role = entity.Role;

            await applicationDbContext.SaveChangesAsync();
        }
    }
}
