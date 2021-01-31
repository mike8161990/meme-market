using Microsoft.EntityFrameworkCore;

namespace MemeMarket.Data
{
    public class MarketContext : DbContext
    {
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<StockEntity> Stocks { get; set; }
        public DbSet<TraderEntity> Traders { get; set; }

        public MarketContext(DbContextOptions<MarketContext> options) : base(options)
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder options) : base()

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarketContext).Assembly);
        }
    }
}
