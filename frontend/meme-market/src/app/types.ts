export class Trader {
    name: string;
    orders: Order[];
    positions: Position[];
}

export class Stock {
    name: string;
    symbol: string;
}

export enum OrderType {
    Buy = "Buy",
    Sell ="Sell",
}

export enum OrderStatus {
    Open = "Open",
    Closed = "Closed",
    Cancelled = "Cancelled",
}

export class Order {
    stock: Stock;
    type: OrderType;
    status: OrderStatus;
    quantity: number;
    price: number;
}

export class Position {
    stock: Stock;
    quantity: number;
    cost: number;
}
