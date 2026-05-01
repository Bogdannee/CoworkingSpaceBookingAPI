using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Infrastructure.Data;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoworkingSpaceBookingAPI.Repositories
{
    public class WorkspaceRepository : AbstractRepository, IWorkspaceRepository
    {
        private readonly DbSet<Workspace> dbSet;

        public WorkspaceRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            dbSet = applicationDbContext.Set<Workspace>();
        }

        public async Task<Workspace> AddAsync(Workspace entity)
        {
            dbSet.Add(entity);
            await applicationDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(Workspace entity)
        {
            dbSet.Remove(entity);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Workspace>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Workspace?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(Workspace entity)
        {
            dbSet.Update(entity);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
