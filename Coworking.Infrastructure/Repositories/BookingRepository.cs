using Coworking.Application.Interfaces.RepositoryInterfaces;
using Coworking.Domain.Entities;
using Coworking.Domain.Enums;
using Coworking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Coworking.Infrastructure.Repositories
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

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

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

        public async Task<bool> HasOverlapAsync(int workspaceId, DateTime start, int durationMinutes)
        {
            var end = start.AddMinutes(durationMinutes);

            return await dbSet.AnyAsync(b =>
                b.WorkspaceId == workspaceId &&
                b.Status != BookingStatus.Canceled &&
                b.ReservationStartTime < end &&
                b.ReservationStartTime.AddMinutes(b.ReservationDurationMinutes) > start);
        }

        public async Task UpdateAsync(int id, Booking entity)
        {
            var request = await GetByIdAsync(id);

            request.UserId = entity.UserId;
            request.WorkspaceId = entity.WorkspaceId;
            request.ReservationStartTime = entity.ReservationStartTime;
            request.ReservationDurationMinutes = entity.ReservationDurationMinutes;
            request.Status = entity.Status;

            await applicationDbContext.SaveChangesAsync();
        }
    }
}
