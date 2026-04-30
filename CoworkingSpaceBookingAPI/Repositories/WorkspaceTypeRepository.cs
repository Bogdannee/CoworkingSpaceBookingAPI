using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Infrastructure.Data;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoworkingSpaceBookingAPI.Repositories
{
    public class WorkspaceTypeRepository : AbstractRepository, IWorkspaceTypeRepository
    {
        private readonly DbSet<WorkspaceType> dbSet;

        public WorkspaceTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            dbSet = applicationDbContext.Set<WorkspaceType>();
        }

        public async Task AddAsync(WorkspaceType entity)
        {
            await dbSet.AddAsync(entity);
            await applicationDbContext.SaveChangesAsync();
        }

        public void Delete(WorkspaceType entity)
        {
            dbSet.Remove(entity);
            applicationDbContext.SaveChanges();
        }

        public async Task<IEnumerable<WorkspaceType>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        } 

        public async Task<WorkspaceType?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Update(WorkspaceType entity)
        {
            dbSet.Update(entity);
            applicationDbContext.SaveChanges();
        }
    }
}
