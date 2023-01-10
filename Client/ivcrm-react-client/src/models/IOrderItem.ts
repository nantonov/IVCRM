import { IProduct } from "./IProduct";

export interface IOrderItem {
    productId: number;
    orderId: number;
    quantity: number;
    price: number;
    product: IProduct;
    
}