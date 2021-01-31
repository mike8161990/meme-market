using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemeMarket.Data
{
    public class StockEntity
    {
        public int StockId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public List<OrderEntity> Orders { get; set; }

        public class Configuration : IEntityTypeConfiguration<StockEntity>
        {
            public void Configure(EntityTypeBuilder<StockEntity> builder)
            {
                builder
                    .ToTable("Stock")
                    .HasKey(k => k.StockId);

                builder
                    .HasMany(s => s.Orders)
                    .WithOne(o => o.Stock);
            }
        }
    }
}
