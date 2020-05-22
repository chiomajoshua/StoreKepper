using Microsoft.EntityFrameworkCore;
using StoreKeeper.Data.DbModel;

namespace StoreKeeper.Data.Persistence
{
    public class StoreKeeperDbContext : DbContext
    {
        public StoreKeeperDbContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}