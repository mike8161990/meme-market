import { Component, OnInit } from '@angular/core';
import { Order, OrderStatus, OrderType, Stock } from './types';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  stock: Stock;
  
  constructor() {}

  ngOnInit(): void {
    this.stock = {
      name: "Gamestop",
      symbol: "GME"
    }
  }
}
