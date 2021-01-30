import { Injectable } from '@angular/core';

export class User {
  name: string;
  pointBalance: number;
  items: Item[];
}

export class Item {
  name: string;
  tagLine: string;
  imageUrl: string;
  price: number;
}

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private readonly user: User = {
    name: "Mike Schwartz",
    pointBalance: 100,
    items: [
      {
        name: "Gamestop Stock",
        tagLine: "We just like the stock.",
        imageUrl: "assets/wall-street-bets.jpg",
        price: 125
      },
      {
        name: "Dogecoin",
        tagLine: "...To the moon!",
        imageUrl: "assets/dogecoin.png",
        price: 10
      }
    ]
  }

  constructor() { }

  public getUser(): User {
    return this.user;
  }
}
