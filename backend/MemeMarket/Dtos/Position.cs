namespace MemeMarket.Dtos
{
    public class Position
    {
        public Stock Stock { get; set; }
        public double Quantity { get; set; }
        public double CostBasis { get; set; }
        public double MarketPrice { get; set; }
        public double NetChange { get; set; }
    }
}
