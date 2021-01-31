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
    Buy = 0,
    Sell = 1,
}

export enum OrderStatus {
    Open = 0,
    Closed = 1,
    Cancelled = 2,
}

export class Order {
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
