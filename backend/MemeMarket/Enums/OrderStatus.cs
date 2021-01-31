using System.ComponentModel;

namespace MemeMarket.Enums
{
    public enum OrderStatus
    {
        [Description("Open")]
        Open = 0,

        [Description("Completed")]
        Completed = 1,

        [Description("Cancelled")]
        Cancelled = 2
    }
}
