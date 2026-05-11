using Coworking.Infrastructure.Data;

namespace Coworking.Infrastructure.Repositories
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
