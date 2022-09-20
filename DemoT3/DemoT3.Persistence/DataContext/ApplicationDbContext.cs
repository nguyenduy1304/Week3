using DemoT3.Domains;
using DemoT3.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DemoT3.Persistence.Domains
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDetailConfiguration).Assembly);
        }
    }
}
