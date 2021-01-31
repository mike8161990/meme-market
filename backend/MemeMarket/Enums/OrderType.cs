using System.ComponentModel;

namespace MemeMarket.Enums
{
    public enum OrderType
    {
        [Description("Buy")]
        Buy = 0,

        [Description("Sell")]
        Sell = 1
    }
}
