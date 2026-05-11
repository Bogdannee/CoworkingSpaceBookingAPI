using Coworking.Infrastructure.Data;
using Coworking.Domain.Entities;
using Coworking.Application.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Coworking.Infrastructure.Repositories
{
    public class RoomRepository : AbstractRepository, IRoomRepository
    {
        private readonly DbSet<Room> dbSet;

        public RoomRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            dbSet = applicationDbContext.Set<Room>();
        }

        public async Task<Room> AddAsync(Room entity)
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

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(int id, Room entity)
        {
            var request = await GetByIdAsync(id);

            request.Name = entity.Name;
            request.Floor = entity.Floor;

            await applicationDbContext.SaveChangesAsync();
        }
    }
}
