using System.ComponentModel;

namespace MemeMarket.Enums
{
    public enum OrderStatus
    {
        [Description("Open")]
        Open,

        [Description("Completed")]
        Completed,

        [Description("Cancelled")]
        Cancelled
    }
}
