using MemeMarket.Enums;

namespace MemeMarket.Dtos
{
    public class NewOrderRequest
    {
        public string StockSymbol { get; set; }
        public int TraderId { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public OrderType Type { get; set; }
    }
}
