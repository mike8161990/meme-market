using System;
using MemeMarket.Data;
using MemeMarket.Dtos;

namespace MemeMarket.Mappers
{
    public static class OrderMapper
    {
        public static Func<OrderEntity, Order> OrderEntityToOrder = order => new Order
        {
            Price = order.Price,
            Quantity = order.Quantity,
            Status = order.Status,
            Type = order.Type
        };
    }
}
