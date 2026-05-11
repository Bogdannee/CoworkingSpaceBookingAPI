using Microsoft.EntityFrameworkCore;
using Coworking.Domain.Entities;

namespace Coworking.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<WorkspaceType> WorkspaceTypes { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка точности для цены (Postgres должен знать масштаб decimal)
            modelBuilder.Entity<Workspace>()
                .Property(w => w.Price)
                .HasPrecision(18, 2);

            // Можно добавить уникальность Email
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
