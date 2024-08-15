using Microsoft.EntityFrameworkCore;
using PrintSerApp.Entities;

namespace PrintSerApp.Data
{
    public class PrintDbContext(DbContextOptions<PrintDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<PrintEntity>(new PrintMap());
        }

        public DbSet<PrintEntity> Prints { get; set; }
    }
}