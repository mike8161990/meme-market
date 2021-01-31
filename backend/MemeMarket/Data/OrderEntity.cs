using MemeMarket.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemeMarket.Data
{
    public class OrderEntity
    {
        public int OrderId { get; set; }
        public int TraderId { get; set; }
        public int StockId { get; set; }
        public OrderType Type { get; set; }
        public OrderStatus Status { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public TraderEntity Trader { get; set; }
        public StockEntity Stock { get; set; }

        public class Configuration : IEntityTypeConfiguration<OrderEntity>
        {
            public void Configure(EntityTypeBuilder<OrderEntity> builder)
            {
                builder
                    .ToTable("Order")
                    .HasKey(k => k.OrderId);

                builder
                    .HasOne(o => o.Trader)
                    .WithMany(t => t.Orders);

                builder
                    .HasOne(o => o.Stock)
                    .WithMany(s => s.Orders);
            }
        }
    }
}
