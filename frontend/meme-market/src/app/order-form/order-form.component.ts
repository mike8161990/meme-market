import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ExchangeService } from '../services/exchange.service';
import { NewOrderRequest, Order, OrderType } from '../types';

export interface DialogData {
  stockSymbol: string;
}

@Component({
  selector: 'app-order-form',
  templateUrl: './order-form.component.html',
  styleUrls: ['./order-form.component.css']
})
export class OrderFormComponent implements OnInit {

  stockSymbol: string;
  price: number;
  quantity: number;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private readonly dialogRef: MatDialogRef<OrderFormComponent>,
    private readonly exchangeService: ExchangeService
  ) { }

  ngOnInit(): void {
    this.stockSymbol = this.data.stockSymbol;
    this.price = 10;
    this.quantity = 10;
  }

  placeOrder(): void {
    let newOrderRequest: NewOrderRequest = {
      price: this.price,
      quantity: this.quantity,
      stockSymbol: this.stockSymbol,
      traderId: 1,
      type: OrderType.Buy
    };

    this.exchangeService.placeOrder(newOrderRequest);
    this.dialogRef.close();
  }

}
