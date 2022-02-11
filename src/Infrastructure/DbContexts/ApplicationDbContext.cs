using Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Partner> Partners { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                           "Server=(localdb)\\mssqllocaldb;Database=TIAA;Trusted_Connection=True;MultipleActiveResultSets=true;",
                           b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            }
        }
    }

    public interface IApplicationDbContext
    {
        DbSet<Partner> Partners { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
