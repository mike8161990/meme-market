import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NewOrderRequest, Order, Position, Stock } from '../types';

@Injectable({
  providedIn: 'root'
})
export class ExchangeService {

  constructor(private http: HttpClient) { }

  getAllStocks(): Observable<Stock[]> {
    return this.http.get<Stock[]>("/api/stocks");
  }

  getPositions(): Observable<Position[]> {
    return this.http.get<Position[]>("/api/positions");
  }

  getBuyOrders(stock: Stock): Observable<Order[]> {
    return this.http.get<Order[]>("/api/orders/buy", {
      params: {
        stockSymbol: stock.symbol
      }
    });
  }

  getSellOrders(stock: Stock): Observable<Order[]> {
    return this.http.get<Order[]>("/api/orders/sell", {
      params: {
        stockSymbol: stock.symbol
      }
    });
  }

  placeOrder(newOrderRequest: NewOrderRequest): void {
    this.http.post<void>("/api/orders/place", newOrderRequest).subscribe();
  }
}
