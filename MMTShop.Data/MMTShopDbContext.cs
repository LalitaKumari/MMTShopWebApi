using Microsoft.EntityFrameworkCore;
using MMTShop.Core;

namespace MMTShop.Data
{
    public class MMTShopDbContext : DbContext
    {
        public MMTShopDbContext(DbContextOptions<MMTShopDbContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
