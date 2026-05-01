using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Infrastructure.Data;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoworkingSpaceBookingAPI.Repositories
{
    public class BookingRepository : AbstractRepository, IBookingRepository
    {
        private readonly DbSet<Booking> dbSet;

        public BookingRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            dbSet = applicationDbContext.Set<Booking>();
        }

        public async Task<Booking> AddAsync(Booking entity)
        {
            dbSet.Add(entity);
            await applicationDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(Booking entity)
        {
            dbSet.Remove(entity);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(Booking entity)
        {
            dbSet.Update(entity);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
