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

        public async Task AddAsync(Workspace entity)
        {
            await dbSet.AddAsync(entity);
            await applicationDbContext.SaveChangesAsync();
        }

        public void Delete(Workspace entity)
        {
            dbSet.Remove(entity);
            applicationDbContext.SaveChanges();
        }

        public async Task<IEnumerable<Workspace>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Workspace?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Update(Workspace entity)
        {
            dbSet.Update(entity);
            applicationDbContext.SaveChanges();
        }
    }
}
