import { ICustomer } from "./ICustomer";
import { IOrderItem } from "./IOrderItem";

export interface IOrderDetails {
    id: number;
    name: string;
    orderDate: string;
    orderStatus: string;
    customerId: number;
    customer: ICustomer;
    orderItems: IOrderItem[]
}