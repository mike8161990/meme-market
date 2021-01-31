using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemeMarket.Data;
using MemeMarket.Dtos;
using MemeMarket.Enums;
using MemeMarket.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MemeMarket.Services
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> logger;
        private readonly MarketContext context;
        private readonly IStockService stockService;

        public OrderService(
            ILogger<OrderService> logger,
            MarketContext context,
            IStockService stockService
        )
        {
            this.logger = logger;
            this.context = context;
            this.stockService = stockService;
        }

        public async Task<List<Order>> GetOpenBuyOrders(string stockSymbol)
        {
            var stockId = await this.stockService.GetStockId(stockSymbol);

            return this.context.Orders
                .Where(o => o.StockId == stockId)
                .Where(o => o.Status == OrderStatus.Open)
                .Where(o => o.Type == OrderType.Buy)
                .OrderBy(o => o.Price)
                .Take(10)
                .Select(OrderMapper.OrderEntityToOrder)
                .ToList();
        }

        public async Task<List<Order>> GetOpenSellOrders(string stockSymbol)
        {
            var stockId = await this.stockService.GetStockId(stockSymbol);

            return this.context.Orders
                .Where(o => o.StockId == stockId)
                .Where(o => o.Status == OrderStatus.Open)
                .Where(o => o.Type == OrderType.Sell)
                .OrderByDescending(o => o.Price)
                .Take(10)
                .Select(OrderMapper.OrderEntityToOrder)
                .ToList();
        }

        public async Task PlaceOrder(NewOrderRequest orderRequest)
        {
            var stockId = await this.stockService.GetStockId(orderRequest.StockSymbol);

            var newOrder = new OrderEntity
            {
                Price = orderRequest.Price,
                Quantity = orderRequest.Quantity,
                Status = OrderStatus.Open,
                Type = orderRequest.Type,
                StockId = stockId,
                TraderId = orderRequest.TraderId
            };

            await this.context.Orders.AddAsync(newOrder);
            await this.context.SaveChangesAsync();
        }
    }
}
