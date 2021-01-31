using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemeMarket.Dtos;
using MemeMarket.Enums;
using MemeMarket.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MemeMarket.Controllers
{
    [ApiController]
    [Route("api")]
    public class ExchangeController : ControllerBase
    {
        private readonly ILogger<ExchangeController> logger;
        private readonly IOrderService orderService;

        public ExchangeController(
            ILogger<ExchangeController> logger,
            IOrderService orderService
        )
        {
            this.logger = logger;
            this.orderService = orderService;
        }

        [HttpGet]
        [Route("stocks")]
        public IEnumerable<Stock> GetAllStocks()
        {
            return new List<Stock> {
                new Stock
                {
                    Name = "Gamestop",
                    Symbol = "GME"
                },
                new Stock
                {
                    Name = "AMC Entertainment Holdings, Inc.",
                    Symbol = "AMC"
                },
                new Stock
                {
                    Name = "BlackBerry Limited",
                    Symbol = "BB"
                }
            };
        }

        [HttpGet]
        [Route("orders/buy")]
        public async Task<IEnumerable<Order>> GetBuyOrders(string stockSymbol)
        {
            return await this.orderService.GetOpenBuyOrders(stockSymbol);
        }

        [HttpGet]
        [Route("orders/sell")]
        public async Task<IEnumerable<Order>> GetSellOrders(string stockSymbol)
        {
            return await this.orderService.GetOpenSellOrders(stockSymbol);
        }

        [HttpPost]
        [Route("orders/place")]
        public async Task PlaceOrder(NewOrderRequest orderRequest)
        {
            await this.orderService.PlaceOrder(orderRequest);
        }

        [HttpGet]
        [Route("positions")]
        public IEnumerable<Position> GetPositions()
        {
            var rng = new Random();
            return this.GetAllStocks().Select(s => new Position
            {
                Stock = s,
                CostBasis = rng.NextDouble() * 30,
                Quantity = rng.NextDouble() * 100,
                MarketPrice = rng.NextDouble() * 30,
                NetChange = rng.NextDouble() * 30
            });
        }

        private IEnumerable<Order> GenerateFakeOrders(OrderType type)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(i => new Order
            {
                Price = rng.NextDouble() * 30,
                Quantity = rng.NextDouble() * 10,
                Status = OrderStatus.Open,
                Type = type
            })
            .ToArray();
        }
    }
}
