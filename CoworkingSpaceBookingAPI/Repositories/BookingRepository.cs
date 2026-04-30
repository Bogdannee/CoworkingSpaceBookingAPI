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

        public async Task AddAsync(Booking entity)
        {
            await dbSet.AddAsync(entity);
            await applicationDbContext.SaveChangesAsync();
        }

        public void Delete(Booking entity)
        {
            dbSet.Remove(entity);
            applicationDbContext.SaveChanges();
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Update(Booking entity)
        {
            dbSet.Update(entity);
            applicationDbContext.SaveChanges();
        }
    }
}
