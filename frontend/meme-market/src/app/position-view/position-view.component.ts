import { Component, OnInit } from '@angular/core';
import { ExchangeService } from '../services/exchange.service';
import { Position } from '../types';

@Component({
  selector: 'app-position-view',
  templateUrl: './position-view.component.html',
  styleUrls: ['./position-view.component.css']
})
export class PositionViewComponent implements OnInit {

  positions: Position[];

  displayedColumns: string[] = [
    "stock",
    "quantity",
    "costBasis",
    "marketPrice",
    "netChange"
  ]

  constructor(public readonly exchangeService: ExchangeService) { }

  ngOnInit(): void {
    this.exchangeService.getPositions().subscribe((positions: Position[]) => {
      this.positions = positions;
    });
  }
}
