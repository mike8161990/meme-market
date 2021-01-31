using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemeMarket.Data
{
    public class TraderEntity
    {
        public int TraderId { get; set; }
        public string Name { get; set; }
        public List<OrderEntity> Orders { get; set; }

        public class Configuration : IEntityTypeConfiguration<TraderEntity>
        {
            public void Configure(EntityTypeBuilder<TraderEntity> builder)
            {
                builder
                    .ToTable("Trader")
                    .HasKey(k => k.TraderId);
                
                builder
                    .HasMany(t => t.Orders)
                    .WithOne(o => o.Trader);
            }
        }
    }
}
