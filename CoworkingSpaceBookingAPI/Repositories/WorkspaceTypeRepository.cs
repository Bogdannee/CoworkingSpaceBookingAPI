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

        public async Task<WorkspaceType> AddAsync(WorkspaceType entity)
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

        public async Task<IEnumerable<WorkspaceType>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        } 

        public async Task<WorkspaceType?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(int id, WorkspaceType entity)
        {
            var request = await GetByIdAsync(id);

            request.Type = entity.Type;

            await applicationDbContext.SaveChangesAsync();
        }
    }
}
