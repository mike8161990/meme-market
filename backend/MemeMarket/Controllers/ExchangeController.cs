using System;
using System.Collections.Generic;
using System.Linq;
using MemeMarket.Dtos;
using MemeMarket.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MemeMarket.Controllers
{
    [ApiController]
    [Route("api")]
    public class ExchangeController : ControllerBase
    {
        private readonly ILogger<ExchangeController> logger;

        public ExchangeController(ILogger<ExchangeController> logger)
        {
            this.logger = logger;
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
        public IEnumerable<Order> GetBuyOrders(string stockSymbol)
        {
            return this.GenerateFakeOrders(OrderType.Buy);
        }

        [HttpGet]
        [Route("orders/sell")]
        public IEnumerable<Order> GetSellOrders(string stockSymbol)
        {
            return this.GenerateFakeOrders(OrderType.Sell);
        }

        [HttpGet]
        [Route("positions")]
        public IEnumerable<Position> GetPositions()
        {
            var rng = new Random();
            return this.GetAllStocks().Select(s => new Position
            {
                Stock = s,
                Cost = rng.NextDouble() * 30,
                Quanity = rng.NextDouble() * 100
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
