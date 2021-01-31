import { Component, Input, OnInit } from '@angular/core';
import { MatSelectChange } from '@angular/material/select';
import { ExchangeService } from '../services/exchange.service';
import { Stock } from '../types';

@Component({
  selector: 'app-order-view',
  templateUrl: './order-view.component.html',
  styleUrls: ['./order-view.component.css']
})
export class OrderViewComponent implements OnInit {

  selectedStock: Stock;
  allStocks: Stock[];

  displayedColumns: string[] = [
    "stock",
    "type",
    "status",
    "quantity",
    "price"
  ]

  constructor(public readonly exchangeService: ExchangeService) { }

  ngOnInit(): void {
    this.allStocks = this.exchangeService.getStocks();
    this.selectedStock = this.allStocks[0];
  }

  stockSelected(event: MatSelectChange): void {
    this.selectedStock = event.value;
  }

}
