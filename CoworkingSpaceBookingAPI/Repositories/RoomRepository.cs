using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Infrastructure.Data;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoworkingSpaceBookingAPI.Repositories
{
    public class RoomRepository : AbstractRepository, IRoomRepository
    {
        private readonly DbSet<Room> dbSet;

        public RoomRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            dbSet = applicationDbContext.Set<Room>();
        }

        public async Task AddAsync(Room entity)
        {
            await dbSet.AddAsync(entity);
            await applicationDbContext.SaveChangesAsync();
        }

        public void Delete(Room entity)
        {
            dbSet.Remove(entity);
            applicationDbContext.SaveChanges();
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Update(Room entity)
        {
            dbSet.Update(entity);
            applicationDbContext.SaveChanges();
        }
    }
}
