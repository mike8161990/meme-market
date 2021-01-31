using MemeMarket.Enums;

namespace MemeMarket.Dtos {
    public class Order {
        public OrderType Type { get; set; }
        public OrderStatus Status { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
    }
}
