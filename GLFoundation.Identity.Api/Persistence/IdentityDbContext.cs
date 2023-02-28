using GLFoundation.Identity.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace GLFoundation.Identity.Api.Persistence
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
