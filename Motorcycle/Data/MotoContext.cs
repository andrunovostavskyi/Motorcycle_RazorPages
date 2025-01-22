using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Motorcycle.Data
{
    public class MotoContext : IdentityDbContext<IdentityUser>
    {
        public MotoContext(DbContextOptions<MotoContext> options)
            : base(options)
        {
        }

        public DbSet<Moto> Motorcycles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brend> Brends { get; set; }

    }
}
