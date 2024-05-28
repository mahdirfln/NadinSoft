using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NadinSoft.Domain.Entities;
using NadinSoft.Infrastructure.Data.Mapping;
using System.Reflection.Emit;

namespace NadinSoft.Infrastructure.Data
{
    public class NadinSoftDbContext : DbContext
    {
        public NadinSoftDbContext(DbContextOptions<NadinSoftDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
