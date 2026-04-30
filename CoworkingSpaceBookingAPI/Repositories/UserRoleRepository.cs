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

        public async Task AddAsync(UserRole entity)
        {
            await dbSet.AddAsync(entity);
            await applicationDbContext.SaveChangesAsync();
        }

        public void Delete(UserRole entity)
        {
            dbSet.Remove(entity);
            applicationDbContext.SaveChanges();
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<UserRole?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Update(UserRole entity)
        {
            dbSet.Update(entity);
            applicationDbContext.SaveChanges();
        }
    }
}
