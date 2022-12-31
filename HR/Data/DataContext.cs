using Microsoft.EntityFrameworkCore;

namespace HR.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Branch> Branches => Set<Branch>();
        public DbSet<Employ> Employees => Set<Employ>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
