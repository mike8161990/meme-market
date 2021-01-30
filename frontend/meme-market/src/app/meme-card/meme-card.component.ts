import { Component, Input, OnInit } from '@angular/core';
import { Item } from '../account.service';

@Component({
  selector: 'app-meme-card',
  templateUrl: './meme-card.component.html',
  styleUrls: ['./meme-card.component.css']
})
export class MemeCardComponent implements OnInit {

  @Input() item: Item;

  constructor() { }

  ngOnInit(): void {
  }

}
