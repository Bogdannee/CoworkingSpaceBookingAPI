using CoworkingSpaceBookingAPI.Infrastructure.Data;

namespace CoworkingSpaceBookingAPI.Repositories
{
    public abstract class AbstractRepository
    {
        protected readonly ApplicationDbContext applicationDbContext;

        protected AbstractRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
    }
}
