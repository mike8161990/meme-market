using System.Collections.Generic;

namespace MemeMarket.Dtos
{
    public class Trader
    {
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
        public List<Position> Positions { get; set; }
    }
}
