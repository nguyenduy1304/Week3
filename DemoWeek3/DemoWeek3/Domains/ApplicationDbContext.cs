using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DemoWeek3.Domains
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }
    }
}
