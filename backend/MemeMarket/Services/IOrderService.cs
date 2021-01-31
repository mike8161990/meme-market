using System.Collections.Generic;
using System.Threading.Tasks;
using MemeMarket.Dtos;

namespace MemeMarket.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOpenBuyOrders(string stockSymbol);
        Task<List<Order>> GetOpenSellOrders(string stockSymbol);
        Task PlaceOrder(NewOrderRequest orderRequest);
    }
}
