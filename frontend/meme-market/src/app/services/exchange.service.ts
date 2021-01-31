import { Injectable } from '@angular/core';
import { Order, OrderStatus, OrderType, Stock } from '../types';

@Injectable({
  providedIn: 'root'
})
export class ExchangeService {

  constructor() { }

  getStocks(): Stock[] {
    return [
      {
        name: "Gamestop",
        symbol: "GME"
      },
      {
        name: "AMC Entertainment Holdings",
        symbol: "AMC"
      }
    ]
  }

  getStockOrders(stock: Stock): Order[] {
    if (stock.symbol == "GME") {
      return [
        {
          stock: stock,
          quantity: 1,
          price: 125,
          status: OrderStatus.Open,
          type: OrderType.Buy
        },
        {
          stock: stock,
          quantity: 1,
          price: 123,
          status: OrderStatus.Open,
          type: OrderType.Buy
        },
        {
          stock: stock,
          quantity: 1,
          price: 121,
          status: OrderStatus.Open,
          type: OrderType.Sell
        },
        {
          stock: stock,
          quantity: 1,
          price: 120,
          status: OrderStatus.Open,
          type: OrderType.Sell
        }
      ]
    }
    else {
      return [
        {
          stock: stock,
          quantity: 2,
          price: 15,
          status: OrderStatus.Open,
          type: OrderType.Buy
        }
      ]
    }
  }
}
