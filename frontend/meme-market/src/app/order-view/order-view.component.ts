import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSelectChange } from '@angular/material/select';
import { OrderFormComponent } from '../order-form/order-form.component';
import { ExchangeService } from '../services/exchange.service';
import { Order, Stock } from '../types';

@Component({
  selector: 'app-order-view',
  templateUrl: './order-view.component.html',
  styleUrls: ['./order-view.component.css']
})
export class OrderViewComponent implements OnInit {

  selectedStock: Stock;
  allStocks: Stock[];

  buyOrders: Order[];
  sellOrders: Order[];

  displayedColumns: string[] = [
    "quantity",
    "price"
  ]

  constructor(
    public readonly exchangeService: ExchangeService,
    private readonly dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.exchangeService.getAllStocks().subscribe((allStocks: Stock[]) => {
      this.allStocks = allStocks;
      this.selectedStock = this.allStocks[0];
      this.refreshOrders();
    });
  }

  refreshOrders() {
    this.exchangeService.getBuyOrders(this.selectedStock).subscribe((buyOrders: Order[]) => {
      this.buyOrders = buyOrders;
    });
    this.exchangeService.getSellOrders(this.selectedStock).subscribe((sellOrders: Order[]) => {
      this.sellOrders = sellOrders;
    });
  }

  stockSelected(event: MatSelectChange): void {
    this.selectedStock = event.value;
    this.refreshOrders();
  }

  openOrderForm(): void {
    let dialogRef = this.dialog.open(OrderFormComponent, {
      data: {
        stockSymbol: this.selectedStock.symbol
      }
    })

    dialogRef.afterClosed().subscribe(() => {
      this.refreshOrders();
    })
  }
}
